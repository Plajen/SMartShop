using SMartShop.Domain.Models;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;

namespace SMartShop.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SmartShopDbContext context) : base(context) { }
    }
}
