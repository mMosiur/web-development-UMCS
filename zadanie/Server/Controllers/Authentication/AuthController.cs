using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PicturePortal.Contracts.Responses;
using PicturePortal.Models;
using PicturePortal.Services;
using PicturePortal.Helpers;
using PicturePortal.Contracts.Responses.Auth;
using PicturePortal.Contracts.Requests.Auth;

namespace PicturePortal.Controllers.Authentication;

[ApiController]
[Route("api/auth")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly AuthService _authService;

    public AuthController(IConfiguration config, AuthService authService)
    {
        _authService = authService;
        _config = config;
    }

    private string GenerateToken(User user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: DateTime.UtcNow.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(token);
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        Result<User> result = await _authService.VerifyLoginInfo(request.Username, request.Password);
        if(result.IsFailed)
        {
            return result.ToBadRequest();
        }
        User user = result.Value;
        string token = GenerateToken(user);
        LoginResponse response = new(token);
        return Ok(response);
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(RegisterResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        Result<User> result = await _authService.CreateUser(request.Username, request.Password, cancellationToken);
        if (result.IsFailed)
        {
            return result.ToBadRequest();
        }
        User user = result.Value;
        string token = GenerateToken(user);
        RegisterResponse response = new(token);
        return Ok(response);
    }
}
