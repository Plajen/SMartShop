using System.Collections.Generic;

namespace SMartShop.Domain.Responses
{
    public class InternalResponse<TEntity>
    {
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public List<TEntity> EntityResult { get; set; } = new List<TEntity>();
        public int? NumericResult { get; set; }

        public InternalResponse(TEntity entity)
        {
            EntityResult.Add(entity);
        }

        public InternalResponse(IEnumerable<TEntity> entities)
        {
            EntityResult.AddRange(entities);
        }

        public InternalResponse(int result)
        {
            NumericResult = result;
        }

        public InternalResponse(string error)
        {
            Success = false;
            Errors.Add(error);
        }

        public InternalResponse() { }
    }
}