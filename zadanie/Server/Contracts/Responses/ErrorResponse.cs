namespace PicturePortal.Contracts.Responses;

public class ErrorResponse : BaseResponse
{
    public override bool Success => false;
    public required IEnumerable<string> Errors { get; init; }
}
