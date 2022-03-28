using SMartShop.Domain.Models;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;

namespace SMartShop.Infra.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(SmartShopDbContext context) : base(context)
        {
        }
    }
}
