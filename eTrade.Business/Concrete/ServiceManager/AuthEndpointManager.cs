using eTrade.Business.Abstract.ReadServices;
using eTrade.Business.Abstract.Services;
using eTrade.Business.Abstract.WriteServices;
using eTrade.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTrade.Business.Concrete.ServiceManager
{
    public class AuthEndpointManager : IAuthEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly IEndpointReadService _endpointReadService;
        readonly IEndpointWriteService _endpointWriteService;
        readonly IMenuReadService _menuReadService;
        readonly IMenuWriteService _menuWriteService;
        readonly RoleManager<AppRole> _roleManager;
        public AuthEndpointManager(IApplicationService applicationService,
            IEndpointReadService endpointReadService,
            IEndpointWriteService endpointWriteService,
            IMenuReadService menuReadService,
            IMenuWriteService menuWriteService,
            RoleManager<AppRole> roleManager)
        {
            _applicationService = applicationService;
            _endpointReadService = endpointReadService;
            _endpointWriteService = endpointWriteService;
            _menuReadService = menuReadService;
            _menuWriteService = menuWriteService;
            _roleManager = roleManager;
        }

        public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
        {
            Menu _menu = await _menuReadService.GetSingleAsync(m => m.Name == menu);
            if (_menu == null)
            {
                _menu = new()
                {
                    Id = Guid.NewGuid(),
                    Name = menu
                };
                await _menuWriteService.AddAsync(_menu);

                await _menuWriteService.SaveAsync();
            }

            Endpoint? endpoint = await _endpointReadService.Table.Include(e => e.Menu).Include(e => e.Roles).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);

            if (endpoint == null)
            {
                var action = _applicationService.GetAuthorizeDefinitionEndpoints(type)
                        .FirstOrDefault(m => m.Name == menu)
                        ?.Actions.FirstOrDefault(e => e.Code == code);

                endpoint = new()
                {
                    Code = action.Code,
                    ActionType = action.ActionType,
                    HttpType = action.HttpType,
                    Definition = action.Definition,
                    Id = Guid.NewGuid(),
                    Menu = _menu
                };

                await _endpointWriteService.AddAsync(endpoint);
                await _endpointWriteService.SaveAsync();
            }

            foreach (var role in endpoint.Roles)
                endpoint.Roles.Remove(role);

            var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

            foreach (var role in appRoles)
                endpoint.Roles.Add(role);

            await _endpointWriteService.SaveAsync();
        }

        public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
        {
            Endpoint? endpoint = await _endpointReadService.Table
                .Include(e => e.Roles)
                .Include(e => e.Menu)
                .FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
            if (endpoint != null)
                return endpoint.Roles.Select(r => r.Name).ToList();
            return null;
        }
    }
}
