using Abp.Application.Features;
using EM.Authorization.Roles;
using EM.MultiTenancy;
using EM.Users;

namespace EM.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}