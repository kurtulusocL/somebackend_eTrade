using eTrade.Core.CrossCuttingConcern.Dtos.ApplicationDtos;

namespace eTrade.Business.Abstract.Services
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
