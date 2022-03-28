using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using System.Threading.Tasks;

namespace SMartShop.Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<InternalResponse<User>> Read(Request<User> request = null, int? id = null, bool count = false, string username = "");
    }
}
