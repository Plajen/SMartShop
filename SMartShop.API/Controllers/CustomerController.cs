using SMartShop.Domain.Models;
using SMartShop.Services.Interfaces;

namespace SMartShop.API.Controllers
{
    public class CustomerController : BaseController<Customer>
    {
        public CustomerController(ICustomerService service) : base(service)
        {
        }
    }
}
