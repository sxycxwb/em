using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Authorization.Roles.Dto;
using System.Collections.Generic;

namespace EM.Authorization.Roles
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        Task<List<RoleListDto>> GetRoles();

        Task<GetRoleForEditOutput> GetInfRole(NullableIdInput input);

        /// <summary>
        /// 新增角色记录
        /// </summary>
        Task CreateInfRole(CreateOrUpdateRoleInput input);

        /// <summary>
        /// 更新角色记录
        /// </summary>
        Task UpdateInfRole(CreateOrUpdateRoleInput input);

        Task DeleteInfRole(EntityRequestInput input);
    }
}