using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using EM.Authorization.Roles.Dto;
using EM.Authorization.Dto;

namespace EM.Authorization.Roles
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    //[AbpAuthorize(AppPermissions.Pages_Administration_Roles)]
    public class RoleAppService : EMAppServiceBase, IRoleAppService
    {
        private readonly RoleManager _roleManager;

        public RoleAppService(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleListDto>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return new List<RoleListDto>(roles.MapTo<List<RoleListDto>>());
        }

        //[AbpAuthorize(AppPermissions.Pages_Administration_Roles_Create, AppPermissions.Pages_Administration_Roles_Edit)]
        public async Task<GetRoleForEditOutput> GetInfRole(NullableIdInput input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var grantedPermissions = new Permission[0];
            RoleEditDto roleEditDto;

            if (input.Id.HasValue) //Editing existing role?
            {
                var role = await _roleManager.GetRoleByIdAsync(input.Id.Value);
                grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
                roleEditDto = role.MapTo<RoleEditDto>();
            }
            else
            {
                roleEditDto = new RoleEditDto();
            }

            return new GetRoleForEditOutput
                   {
                       Role = roleEditDto,
                       Permissions = permissions.MapTo<List<FlatPermissionDto>>().OrderBy(p => p.DisplayName).ToList(),
                       GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
                   };
        }

        /// <summary>
        /// 新增角色记录
        /// </summary>
        public async Task CreateInfRole(CreateOrUpdateRoleInput input)
        {
            await CreateRoleAsync(input);
        }

        /// <summary>
        /// 更新角色记录
        /// </summary>
        public async Task UpdateInfRole(CreateOrUpdateRoleInput input)
        {
            await UpdateRoleAsync(input);
        }


        //[AbpAuthorize(AppPermissions.Pages_Administration_Roles_Delete)]
        public async Task DeleteInfRole(EntityRequestInput input)
        {
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        //[AbpAuthorize(AppPermissions.Pages_Administration_Roles_Edit)]
        protected virtual async Task UpdateRoleAsync(CreateOrUpdateRoleInput input)
        {
            Debug.Assert(input.Role.Id != null, "input.Role.Id should be set.");

            var role = await _roleManager.GetRoleByIdAsync(input.Role.Id.Value);
            role.DisplayName = input.Role.DisplayName;
            role.IsDefault = input.Role.IsDefault;
            
            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        //[AbpAuthorize(AppPermissions.Pages_Administration_Roles_Create)]
        protected virtual async Task CreateRoleAsync(CreateOrUpdateRoleInput input)
        {
            var role = new Role(AbpSession.TenantId, input.Role.DisplayName) { IsDefault = input.Role.IsDefault };
            CheckErrors(await _roleManager.CreateAsync(role));
            await CurrentUnitOfWork.SaveChangesAsync(); //It's done to get Id of the role.
            await UpdateGrantedPermissionsAsync(role, input.GrantedPermissionNames);
        }

        private async Task UpdateGrantedPermissionsAsync(Role role, List<string> grantedPermissionNames)
        {
            var grantedPermissions = PermissionManager.GetPermissionsFromNamesByValidating(grantedPermissionNames);
            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);
        }
    }
}
