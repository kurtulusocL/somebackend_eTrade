
namespace eTrade.Core.CrossCuttingConcern.Dtos.ApplicationDtos
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<ActionDto> Actions { get; set; } = new();
    }
}
