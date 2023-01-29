using System.Diagnostics.CodeAnalysis;

namespace PicturePortal.Contracts.Responses;

public class LoginResponse : BaseSuccessResponse
{
    public required string Token { get; init; }

    public LoginResponse() { }

    [SetsRequiredMembers]
    public LoginResponse(string token)
    {
        Token = token;
    }
}
