namespace PicturePortal.Contracts.DTOs;

public class ImageInfoDto
{
    public required string Id { get; init; }
    public required string Title { get; init; }
    public required UserDto Author { get; init; }
    public IEnumerable<string> Tags { get; init; } = Array.Empty<string>();
    public IEnumerable<CommentDto> Comments { get; init; } = Array.Empty<CommentDto>();
}
