using eTrade.Core.Entities.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTrade.Entities.Concrete
{
    public class File : BaseEntity
    {
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
    }
}
