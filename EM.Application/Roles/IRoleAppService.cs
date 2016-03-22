using System.Threading.Tasks;
using Abp.Application.Services;
using EM.Roles.Dto;

namespace EM.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
