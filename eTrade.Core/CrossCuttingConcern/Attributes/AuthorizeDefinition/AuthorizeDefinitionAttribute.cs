using eTrade.Core.CrossCuttingConcern.Toolbox.Enum;

namespace eTrade.Core.CrossCuttingConcern.Attributes.AuthorizeDefinition
{
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string Menu { get; set; }
        public string Definition { get; set; }
        public ActionType ActionType { get; set; }
    }
}
