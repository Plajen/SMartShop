using Microsoft.EntityFrameworkCore;
using SMartShop.Domain.Models;
using SMartShop.Domain.Responses;
using SMartShop.Infra.Context;
using SMartShop.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SMartShop.Infra.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        protected readonly SmartShopDbContext _context;

        public RefreshTokenRepository(SmartShopDbContext context) => _context = context;

        public async Task<InternalResponse<RefreshToken>> Read(int userId)
        {
            var response = new InternalResponse<RefreshToken>();

            try
            {
                response.EntityResult = new List<RefreshToken>()
                {
                    await _context.RefreshTokens.SingleAsync(x => x.UserId == userId)
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

        public async Task<InternalResponse<RefreshToken>> Create(RefreshToken entity)
        {
            var response = new InternalResponse<RefreshToken>();

            try
            {
                response.EntityResult = new List<RefreshToken>() { _context.Add(entity).Entity };
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

        public async Task<InternalResponse<RefreshToken>> Delete(int userId)
        {
            var response = new InternalResponse<RefreshToken>();

            try
            {
                var entity = await Read(userId);

                if (entity.Success == false)
                {
                    response = entity;
                    return response;
                }

                _context.Remove(entity);
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
    }
}
