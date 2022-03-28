using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using SMartShop.Infra.CrossCutting.Infrastructure;
using SMartShop.Infra.CrossCutting.Infrastructure.Interfaces;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SMartShop.Services.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly ICrypto _crypto;

        public UserService(IUserRepository repository, ICrypto crypto) : base(repository)
            => _crypto = crypto;

        protected override async Task<InternalResponse<User>> Create(User entity, int authUserId)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = authUserId;
            entity.Salt = Guid.NewGuid().ToString();
            entity.Password = _crypto.Encrypt(entity.Password, entity.Salt);
            return await _repository.Create(entity);
        }

        protected override async Task<InternalResponse<User>> Obtain(int id)
        {
            var result = await _repository.Read(id: id);

            if (result.Success)
                result.EntityResult.FirstOrDefault().Password = "";

            return result;
        }

        protected override async Task<InternalResponse<User>> List(Request<User> request)
        {
            var result = await _repository.Read(request);

            if (result.Success)
                result.EntityResult.ForEach(x => x.Password = "");

            return result;
        }
    }
}
