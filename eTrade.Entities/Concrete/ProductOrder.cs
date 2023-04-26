using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class ProductOrder:BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
