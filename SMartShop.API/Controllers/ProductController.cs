using SMartShop.Domain.Models;
using SMartShop.Services.Interfaces;

namespace SMartShop.API.Controllers
{
    public class ProductController : BaseController<Product>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
