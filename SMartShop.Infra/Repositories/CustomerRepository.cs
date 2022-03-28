using SMartShop.Domain.Models;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;

namespace SMartShop.Infra.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SmartShopDbContext context) : base(context)
        {
        }
    }
}
