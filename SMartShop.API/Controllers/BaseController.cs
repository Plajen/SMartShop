using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using SMartShop.Services.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMartShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : Entity
    {
        private readonly IBaseService<TEntity> _service;

        private const string SOLICITACAO_INVALIDA = "Solicitação inválida à controller";
        private const string TOKEN_INVALIDO = "Solicitação com token inválido, tente novamente";

        public BaseController(IBaseService<TEntity> service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get(Request<TEntity> request)
            => Ok(new ApiResponse<TEntity>(await _service.Get(request)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => Ok(new ApiResponse<TEntity>(await _service.Get(new Request<TEntity>(id))));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Request<TEntity> request)
        {
            var userId = GetAuthUserId();
            if (userId == null)
                return BadRequest(new ApiResponse<TEntity>(TOKEN_INVALIDO));

            return Ok(new ApiResponse<TEntity>(await _service.Post(request, userId.Value)));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] Request<TEntity> request)
        {
            if (id != request.Entity.Id)
                return BadRequest(new ApiResponse<TEntity>(SOLICITACAO_INVALIDA));

            var userId = GetAuthUserId();
            if (userId == null)
                return BadRequest(new ApiResponse<TEntity>(TOKEN_INVALIDO));

            return Ok(new ApiResponse<TEntity>(await _service.Patch(request, userId.Value)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Request<TEntity> request)
        {
            if (id != request.Entity.Id)
                return BadRequest(new ApiResponse<TEntity>(SOLICITACAO_INVALIDA));

            var userId = GetAuthUserId();
            if (userId == null)
                return BadRequest(new ApiResponse<TEntity>(TOKEN_INVALIDO));

            return Ok(new ApiResponse<TEntity>(await _service.Put(request, userId.Value)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(new ApiResponse<TEntity>(await _service.Delete(new Request<TEntity>(id, true))));

        protected int? GetAuthUserId()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userHasId = int.TryParse(identity.Claims.ToArray()[0].Value, out int userId);

            return userHasId ? userId : null;
        }
    }
}
