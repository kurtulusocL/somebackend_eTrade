using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class CompletedOrder:BaseEntity
    {
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
    }
}
