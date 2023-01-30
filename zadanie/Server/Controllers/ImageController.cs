using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using PicturePortal.Data;
using PicturePortal.Models;

namespace PicturePortal.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IMongoCollection<Image> _imageCollection;

    public ImageController(DatabaseContext dbContext)
    {
        _imageCollection = dbContext.Images;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> GetAsync(string id)
    {
        Image? image = await _imageCollection
            .Find(i => i.Id == id)
            .FirstOrDefaultAsync();
        if (image is null)
        {
            return NotFound();
        }
        System.Net.Mime.ContentDisposition disposition = new()
        {
            FileName = $"image.{image.Extension}",
            Inline = false
        };
        Response.Headers.Add("Content-Disposition", disposition.ToString());
        return File(image.Bytes, $"image/{image.Extension}");
    }

    [HttpPost]
    public async Task<ActionResult<string>> PostAsync(IFormFile file, CancellationToken cancellationToken)
    {
        string extension = Path.GetExtension(file.FileName).Substring(1);
        if(extension != "jpg" && extension != "jpeg" && extension != "png")
        {
            return new UnsupportedMediaTypeResult();
        }
        using Stream sourceStream = file.OpenReadStream();
        using MemoryStream memoryStream = new();
        await sourceStream.CopyToAsync(memoryStream, cancellationToken);
        Image image = new()
        {
            Bytes = memoryStream.ToArray(),
            Extension = extension
        };
        InsertOneOptions options = new();
        await _imageCollection.InsertOneAsync(image, options, cancellationToken);
        return Ok(image.Id);
    }
}
