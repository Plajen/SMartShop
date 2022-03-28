using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMartShop.Domain.Requests;
using SMartShop.Services.Interfaces;
using System.Threading.Tasks;

namespace SMartShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service) => _service = service;

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request) 
            => Ok(await _service.Login(request));

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
            => Ok(await _service.RefreshToken(request));
    }
}
