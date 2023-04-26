using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class Basket:BaseEntity
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }

        public AppUser User { get; set; }
        public Order Order { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get; set; }
    }
}
