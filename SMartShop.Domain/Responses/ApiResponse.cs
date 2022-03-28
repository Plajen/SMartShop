using System.Collections.Generic;
using System.Linq;

namespace SMartShop.Domain.Responses
{
    public class ApiResponse<TEntity>
    {
        public object Result { get; private set; }
        public List<string> Errors { get; private set; } = new List<string>();
        public bool Success { get; set; } = true;

        public ApiResponse(InternalResponse<TEntity> result)
        {
            if (!result.Success)
            {
                Success = false;
                Errors.AddRange(result.Errors);
                return;
            }

            if (result.EntityResult.Count == 1)
                Result = result.EntityResult.Single();

            if (result.EntityResult.Count > 1)
                Result = result.EntityResult;

            if (result.EntityResult.Count == 0 && result.NumericResult != null)
                Result = result.NumericResult;
        }

        public ApiResponse(string error)
        {
            Errors.Add(error);
            Success = false;
        }
    }
}
