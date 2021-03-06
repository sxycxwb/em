using System.Threading.Tasks;
using Abp.Application.Services;
using EM.Users.Dto;

namespace EM.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}