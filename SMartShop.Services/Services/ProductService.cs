using SMartShop.Domain.Models;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;

namespace SMartShop.Services.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IProductRepository repository) : base(repository)
        {
        }
    }
}
