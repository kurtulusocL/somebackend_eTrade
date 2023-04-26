
namespace eTrade.Entities.Concrete
{
    public class ProductImage : File
    {
        public bool Showcase { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
