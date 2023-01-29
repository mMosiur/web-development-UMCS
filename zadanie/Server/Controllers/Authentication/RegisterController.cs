using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PicturePortal.Controllers.Authentication;

[ApiController]
[Route("api/auth/[controller]")]
[AllowAnonymous]
public class RegisterController : ControllerBase
{
    
}
