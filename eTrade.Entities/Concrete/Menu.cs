using eTrade.Core.Entities.EntityFramework;

namespace eTrade.Entities.Concrete
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
