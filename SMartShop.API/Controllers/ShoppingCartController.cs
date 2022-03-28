using SMartShop.Domain.Models;
using SMartShop.Services.Interfaces;

namespace SMartShop.API.Controllers
{
    public class ShoppingCartController : BaseController<ShoppingCart>
    {
        public ShoppingCartController(IShoppingCartService service) : base(service)
        {
        }
    }
}
