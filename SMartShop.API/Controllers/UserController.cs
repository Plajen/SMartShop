using Microsoft.AspNetCore.Authorization;
using SMartShop.Domain.Models;
using SMartShop.Services.Interfaces;

namespace SMartShop.API.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UserController : BaseController<User>
    {
        public UserController(IUserService service) : base(service) { }
    }
}
