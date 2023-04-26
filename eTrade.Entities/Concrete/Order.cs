using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Basket Basket { get; set; }
        public CompletedOrder CompletedOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
