using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class Customer:BaseEntity
    {
        public string NameSurname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
