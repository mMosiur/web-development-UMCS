namespace PicturePortal.Contracts.Requests.Images;

public class CreateImageRequest
{
    public required IFormFile File { get; init; }
    public required string Title { get; init; }
}
