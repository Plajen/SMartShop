using SMartShop.Domain.Models;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;

namespace SMartShop.Infra.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(SmartShopDbContext context) : base(context)
        {
        }
    }
}
