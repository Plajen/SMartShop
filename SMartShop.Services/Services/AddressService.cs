using SMartShop.Domain.Models;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;

namespace SMartShop.Services.Services
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IAddressRepository repository) : base(repository)
        {
        }
    }
}
