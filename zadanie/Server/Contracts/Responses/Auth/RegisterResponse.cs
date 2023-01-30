using System.Diagnostics.CodeAnalysis;
using PicturePortal.Contracts.Responses.Base;

namespace PicturePortal.Contracts.Responses.Auth;

public class RegisterResponse : BaseSuccessResponse
{
    public required string Token { get; init; }

    public RegisterResponse() { }

    [SetsRequiredMembers]
    public RegisterResponse(string token)
    {
        Token = token;
    }
}
