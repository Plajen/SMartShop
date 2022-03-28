using SMartShop.Domain.Models;
using SMartShop.Domain.Responses;
using System.Threading.Tasks;

namespace SMartShop.Infra.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<InternalResponse<RefreshToken>> Create(RefreshToken entity);
        Task<InternalResponse<RefreshToken>> Read(int userId);
        Task<InternalResponse<RefreshToken>> Delete(int userId);
    }
}
