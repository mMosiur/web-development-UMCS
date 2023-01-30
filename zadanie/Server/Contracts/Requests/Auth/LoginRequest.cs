namespace PicturePortal.Contracts.Requests.Auth;

public class LoginRequest
{
    public required string Username { get; init; }
    public required string Password { get; init; }
}
