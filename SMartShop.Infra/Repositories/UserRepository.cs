using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SMartShop.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private const string USUARIO_JA_EXISTENTE = "O usuário já existe";

        public UserRepository(SmartShopDbContext context) : base(context) { }

        public async Task<InternalResponse<User>> Read(Request<User> request = null, int? id = null, bool count = false, string username = "")
        {
            if (request == null)
            {
                if (id != null && id > 0)
                    return await FindByIdAsync(id.Value);

                if (id == null && !string.IsNullOrWhiteSpace(username))
                    return await FindByUserName(username);
            }

            if (request != null && id == null)
            {
                if (count == true)
                {
                    return await CountAsync(request);
                }

                return await ListAsync(request);
            }

            return new InternalResponse<User>(ERRO_SOLICITACAO_REPOSITORIO);
        }

        public override async Task<InternalResponse<User>> Create(User entity)
        {
            var response = new InternalResponse<User>();

            try
            {
                var user = await FindByUserName(entity.Username);

                if (user != null)
                {
                    response.Success = false;
                    response.Errors.Add(USUARIO_JA_EXISTENTE);
                    return response;
                }

                response.EntityResult = new List<User>() { _context.Add(entity).Entity };
                await _context.SaveChangesAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        private async Task<InternalResponse<User>> FindByUserName(string username)
        {
            var response = new InternalResponse<User>();

            try
            {
                response.EntityResult = new List<User>()
                {
                    await _context.Users.Include(x => x.Role).SingleAsync(x => x.Username.ToLower() == username)
                };

                response.Success = response.EntityResult.Count > 0;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Errors.Add(ex.Message);
            }

            return response;
        }
    }
}
