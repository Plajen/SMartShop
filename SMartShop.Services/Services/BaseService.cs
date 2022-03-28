using SMartShop.Domain.Enums;
using SMartShop.Domain.Models;
using SMartShop.Domain.Requests;
using SMartShop.Domain.Responses;
using SMartShop.Infra.Interfaces;
using SMartShop.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SMartShop.Services.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        protected readonly IBaseRepository<TEntity> _repository;

        protected const string COMANDO_NAO_IDENTIFICADO = "Comando não identificado";
        protected const string ERRO_SOLICITACAO_SERVICO = "O serviço encontrou um erro ao processar a solicitação";

        public BaseService(IBaseRepository<TEntity> repository) => _repository = repository;

        #region HTTP Methods

        public async Task<InternalResponse<TEntity>> Get(Request<TEntity> request)
        {
            if (request.Entity == null)
            {
                if (request.Command == CommandEnum.Obtain && request.Id != null)
                    return await Obtain(request.Id.Value);

                if (request.Command == CommandEnum.List)
                    return await List(request);

                if (request.Command == CommandEnum.Count)
                    return await Count(request);

                return new InternalResponse<TEntity>(COMANDO_NAO_IDENTIFICADO);
            }

            return new InternalResponse<TEntity>(ERRO_SOLICITACAO_SERVICO);
        }

        public async Task<InternalResponse<TEntity>> Post(Request<TEntity> request, int userId)
        {
            if (request.Entity != null)
            {
                if (request.Command == CommandEnum.Create)
                    return await Create(request.Entity, userId);

                return new InternalResponse<TEntity>(COMANDO_NAO_IDENTIFICADO);
            }

            return new InternalResponse<TEntity>(ERRO_SOLICITACAO_SERVICO);
        }

        public async Task<InternalResponse<TEntity>> Patch(Request<TEntity> request, int userId)
        {
            if (request.Entity != null)
            {
                if (request.Command == CommandEnum.Activate)
                    return await Activate(request.Entity, userId);

                if (request.Command == CommandEnum.Deactivate)
                    return await Deactivate(request.Entity, userId);

                if (request.Command == CommandEnum.SoftDelete)
                    return await SoftDelete(request.Entity, userId);

                if (request.Command == CommandEnum.Undelete)
                    return await Undelete(request.Entity, userId);

                return new InternalResponse<TEntity>(COMANDO_NAO_IDENTIFICADO);
            }

            return new InternalResponse<TEntity>(ERRO_SOLICITACAO_SERVICO);
        }

        public async Task<InternalResponse<TEntity>> Put(Request<TEntity> request, int userId)
        {
            if (request.Entity != null)
            {
                if (request.Command == CommandEnum.Update)
                    return await Update(request.Entity, userId);

                return new InternalResponse<TEntity>(COMANDO_NAO_IDENTIFICADO);
            }

            return new InternalResponse<TEntity>(ERRO_SOLICITACAO_SERVICO);
        }

        public async Task<InternalResponse<TEntity>> Delete(Request<TEntity> request)
        {
            if (request.Entity == null)
            {
                if (request.Command == CommandEnum.HardDelete && request.Id != null)
                    return await HardDelete(request.Id.Value);

                return new InternalResponse<TEntity>(COMANDO_NAO_IDENTIFICADO);
            }

            return new InternalResponse<TEntity>(ERRO_SOLICITACAO_SERVICO);
        }

        #endregion

        #region Specific Methods

        protected virtual async Task<InternalResponse<TEntity>> Obtain(int id) 
            => await _repository.Read(id: id);

        protected virtual async Task<InternalResponse<TEntity>> List(Request<TEntity> request) 
            => await _repository.Read(request);

        protected virtual async Task<InternalResponse<TEntity>> Count(Request<TEntity> request) 
            => await _repository.Read(request, count: true);

        protected virtual async Task<InternalResponse<TEntity>> Create(TEntity entity, int userId)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = userId;
            return await _repository.Create(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> Update(TEntity entity, int userId)
        {
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = userId;
            return await _repository.Update(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> Activate(TEntity entity, int userId)
        {
            entity.Active = true;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = userId;
            return await _repository.Update(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> Deactivate(TEntity entity, int userId)
        {
            entity.Active = false;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = userId;
            return await _repository.Update(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> SoftDelete(TEntity entity, int userId)
        {
            entity.Deleted = true;
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = userId;
            return await _repository.Update(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> Undelete(TEntity entity, int userId)
        {
            entity.Deleted = false;
            entity.DeletedAt = null;
            entity.DeletedBy = null;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = userId;
            return await _repository.Update(entity);
        }

        protected virtual async Task<InternalResponse<TEntity>> HardDelete(int id) 
            => await _repository.Delete(id);

        #endregion
    }
}
