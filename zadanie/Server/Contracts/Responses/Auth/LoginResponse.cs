using System.Diagnostics.CodeAnalysis;
using PicturePortal.Contracts.Responses.Base;

namespace PicturePortal.Contracts.Responses.Auth;

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
