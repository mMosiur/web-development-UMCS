using System.Collections;

namespace PicturePortal.Contracts.Requests.Images;

public class CreateImageRequest
{
    public required string Title { get; init; }
    public required IFormFile File { get; init; }
    public string? Description { get; init; }
    public string? SpaceSeparatedTags { get; init; }
}
