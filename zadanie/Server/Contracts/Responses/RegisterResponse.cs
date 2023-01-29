using System.Diagnostics.CodeAnalysis;

namespace PicturePortal.Contracts.Responses;

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
