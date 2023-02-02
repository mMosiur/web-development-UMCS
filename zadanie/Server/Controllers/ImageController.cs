using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using PicturePortal.Contracts.DTOs;
using PicturePortal.Contracts.Requests.Images;
using PicturePortal.Data;
using PicturePortal.Models;

namespace PicturePortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public ImageController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetImage(string id, CancellationToken cancellationToken)
    {
        if (!ObjectId.TryParse(id, out _))
        {
            return NotFound();
        }
        Image? image = await _dbContext.Images
            .Find(i => i.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        if (image is null)
        {
            return NotFound();
        }
        ContentDisposition disposition = new()
        {
            FileName = $"image.{image.Extension}",
            Inline = false
        };
        Response.Headers.Add("Content-Disposition", disposition.ToString());
        return File(image.Bytes, $"image/{image.Extension}");
    }

    [HttpGet("all")]
    [ProducesResponseType(typeof(IEnumerable<ImageInfoDto>), (int)HttpStatusCode.OK)]
    public IActionResult GetAllImages(CancellationToken cancellationToken)
    {
        IEnumerable<Image> images = _dbContext.Images
            .Find(i => true)
            .ToEnumerable(cancellationToken);
        return Ok(images.Select(i => new ImageInfoDto()
        {
            Id = i.Id,
            Title = i.Title,
            Author = new UserDto() { Id = i.AuthorId, DisplayName = "" }
        }));
    }

    [HttpGet("{id}/info")]
    [ProducesResponseType(typeof(ImageInfoDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetImageInfo(string id, CancellationToken cancellationToken)
    {
        if (!ObjectId.TryParse(id, out _))
        {
            return NotFound();
        }
        Image? image = await _dbContext.Images
            .Find(i => i.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        if (image is null)
        {
            return NotFound();
        }
        User? user = await _dbContext.Users.Find(u => u.Id == image.AuthorId).FirstOrDefaultAsync(cancellationToken);
        UserDto author = new()
        {
            Id = image.AuthorId,
            DisplayName = user?.Name ?? "Unknown"
        };
        ImageInfoDto dto = new()
        {
            Id = image.Id,
            Title = image.Title,
            Author = author,
            Tags = image.Tags,
            Comments = image.Comments.Select(c => new CommentDto() { AuthorName = c.AuthorName, Content = c.Content })
        };
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.UnsupportedMediaType)]
    // [Authorize] // No authorization for the time being
    public async Task<IActionResult> CreateImage([FromForm] CreateImageRequest request, CancellationToken cancellationToken)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ObjectId.Empty.ToString();
        string extension = Path.GetExtension(request.File.FileName)[1..];
        if (extension != "jpg" && extension != "jpeg" && extension != "png")
        {
            return new UnsupportedMediaTypeResult();
        }
        using Stream sourceStream = request.File.OpenReadStream();
        using MemoryStream memoryStream = new();
        await sourceStream.CopyToAsync(memoryStream, cancellationToken);
        ICollection<string> tags = request.SpaceSeparatedTags is not null
            ? request.SpaceSeparatedTags
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.ToLowerInvariant()).ToList()
            : Array.Empty<string>();
        Image image = new()
        {
            AuthorId = userId,
            Bytes = memoryStream.ToArray(),
            Extension = extension,
            DatePublished = DateTime.Now,
            Title = request.Title,
            Description = request.Description,
            Tags = tags
        };
        InsertOneOptions options = new();
        await _dbContext.Images.InsertOneAsync(image, options, cancellationToken);
        return CreatedAtAction(
            actionName: nameof(GetImage),
            routeValues: new { id = image.Id },
            value: new { ImageId = image.Id }
        );
    }
}
