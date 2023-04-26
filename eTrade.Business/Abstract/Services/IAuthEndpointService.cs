
namespace eTrade.Business.Abstract.Services
{
    public interface IAuthEndpointService
    {
        public Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type);
        public Task<List<string>> GetRolesToEndpointAsync(string code, string menu);
    }
}
