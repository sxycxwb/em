using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Authorization.Users.Dto;

namespace EM.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultOutput<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
