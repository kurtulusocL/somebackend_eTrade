using Microsoft.AspNetCore.Identity;

namespace eTrade.Entities.Concrete
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
