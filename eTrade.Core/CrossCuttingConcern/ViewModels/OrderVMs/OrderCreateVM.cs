
namespace eTrade.Core.CrossCuttingConcern.ViewModels.OrderVMs
{
    public class OrderCreateVM
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }
    }
}
