using SMartShop.Domain.Models;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;

namespace SMartShop.Services.Services
{
    public class ShoppingCartService : BaseService<ShoppingCart>, IShoppingCartService
    {
        public ShoppingCartService(IShoppingCartRepository repository) : base(repository)
        {
        }
    }
}
