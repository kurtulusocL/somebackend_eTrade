using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<BasketItem> BasketItems { get;set; }
    }
}
