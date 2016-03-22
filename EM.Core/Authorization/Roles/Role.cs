using Abp.Authorization.Roles;
using EM.MultiTenancy;
using EM.Users;

namespace EM.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}