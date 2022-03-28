using SMartShop.Domain.Models;
using SMartShop.Services.Interfaces;

namespace SMartShop.API.Controllers
{
    public class AddressController : BaseController<Address>
    {
        public AddressController(IAddressService service) : base(service) { }
    }
}
