using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace EM.Authorization
{
    public class EMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            //电厂管理
            var inf_Station = context.CreatePermission(PermissionNames.Inf_Station, L("Inf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.Inf_Station_CreateInf_Station, L("CreateInf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.Inf_Station_UpdateInf_Station, L("UpdateInf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.Inf_Station_DeleteInf_Station, L("DeleteInf_Station"));

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EMConsts.LocalizationSourceName);
        }
    }
}
