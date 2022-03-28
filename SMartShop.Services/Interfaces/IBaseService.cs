using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using System.Threading.Tasks;

namespace SMartShop.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : Entity
    {
        Task<InternalResponse<TEntity>> Get(Request<TEntity> request);
        Task<InternalResponse<TEntity>> Post(Request<TEntity> request, int userId);
        Task<InternalResponse<TEntity>> Patch(Request<TEntity> request, int userId);
        Task<InternalResponse<TEntity>> Put(Request<TEntity> request, int userId);
        Task<InternalResponse<TEntity>> Delete(Request<TEntity> request);
    }
}
