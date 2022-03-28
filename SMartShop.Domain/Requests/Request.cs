using SMartShop.Domain.Enums;
using SMartShop.Domain.Models;

namespace SMartShop.Domain.Requests
{
    public class Request<TEntity> where TEntity : Entity
    {
        public CommandEnum Command { get; set; }
        public string SearchProperty { get; set; }
        public string SearchValue { get; set; }
        public string OrderBy { get; set; }
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public int? Id { get; set; }
        public TEntity Entity { get; set; } = default;

        public Request()
        {
            if (Entity == null && Id == null)
            {
                OrderBy = "Id ASC";
                Take = 50;
            }
        }

        public Request(int id, bool delete = false)
        {
            Id = id;
            Command = delete ? CommandEnum.HardDelete : CommandEnum.Obtain;
        }
    }
}
