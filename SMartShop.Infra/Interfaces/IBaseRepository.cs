using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using System.Threading.Tasks;

namespace SMartShop.Infra.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task<InternalResponse<TEntity>> Create(TEntity entity);
        Task<InternalResponse<TEntity>> Read(Request<TEntity> request = null, int? id = null, bool count = false);
        Task<InternalResponse<TEntity>> Update(TEntity entity);
        Task<InternalResponse<TEntity>> Delete(int id);
    }
}
