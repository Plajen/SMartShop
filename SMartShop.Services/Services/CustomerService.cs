using SMartShop.Domain.Models;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;

namespace SMartShop.Services.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository) : base(repository)
        {
        }
    }
}
