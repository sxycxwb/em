using Abp.Authorization;
using EM.Authorization.Roles;
using EM.MultiTenancy;
using EM.Users;

namespace EM.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
