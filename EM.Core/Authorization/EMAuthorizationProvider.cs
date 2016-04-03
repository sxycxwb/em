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
            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            
            //电厂管理
            var inf_Station = context.CreatePermission(PermissionNames.InfStation, L("Inf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_CreateInfStation, L("CreateInf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_UpdateInfStation, L("UpdateInf_Station"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_DeleteInfStation, L("DeleteInf_Station"));

            //人员管理
            var infEmployer = context.CreatePermission(PermissionNames.InfEmployer, L("InfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_CreateInfEmployer, L("CreateInfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_UpdateInfEmployer, L("UpdateInfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_DeleteInfEmployer, L("DeleteInfEmployer"));

            //车辆信息管理
            var vehVehicle = context.CreatePermission(PermissionNames.VehVehicle, L("VehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_CreateVehVehicle, L("CreateVehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_UpdateVehVehicle, L("UpdateVehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_DeleteVehVehicle, L("DeleteVehVehicle"));

            //维保记录管理
            var vehMaintenance = context.CreatePermission(PermissionNames.VehMaintenance, L("VehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_CreateVehMaintenance, L("CreateVehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_UpdateVehMaintenance, L("UpdateVehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_DeleteVehMaintenance, L("DeleteVehMaintenance"));

            //用车记录管理
            var vehUseRecord = context.CreatePermission(PermissionNames.VehUseRecord, L("VehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_CreateVehUseRecord, L("CreateVehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_UpdateVehUseRecord, L("UpdateVehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_DeleteVehUseRecord, L("DeleteVehUseRecord"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EMConsts.LocalizationSourceName);
        }
    }
}
