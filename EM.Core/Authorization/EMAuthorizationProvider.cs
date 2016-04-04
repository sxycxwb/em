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
            //var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            #region 系统管理

            var sys = pages.CreateChildPermission(PermissionNames.InfStation, L("SysManagement"));

            //电厂管理
            var inf_Station = sys.CreateChildPermission(PermissionNames.InfStation, L("InfStation"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_CreateInfStation, L("CreateInfStation"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_UpdateInfStation, L("UpdateInfStation"));
            inf_Station.CreateChildPermission(PermissionNames.InfStation_DeleteInfStation, L("DeleteInfStation"));

            //人员管理
            var infEmployer = sys.CreateChildPermission(PermissionNames.InfEmployer, L("InfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_CreateInfEmployer, L("CreateInfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_UpdateInfEmployer, L("UpdateInfEmployer"));
            infEmployer.CreateChildPermission(PermissionNames.InfEmployer_DeleteInfEmployer, L("DeleteInfEmployer"));

            #endregion

            #region 车辆管理

            var veh = pages.CreateChildPermission(PermissionNames.InfStation, L("VehManagement"));

            //车辆信息管理
            var vehVehicle = veh.CreateChildPermission(PermissionNames.VehVehicle, L("VehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_CreateVehVehicle, L("CreateVehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_UpdateVehVehicle, L("UpdateVehVehicle"));
            vehVehicle.CreateChildPermission(PermissionNames.VehVehicle_DeleteVehVehicle, L("DeleteVehVehicle"));

            //用车记录管理
            var vehUseRecord = veh.CreateChildPermission(PermissionNames.VehUseRecord, L("VehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_CreateVehUseRecord, L("CreateVehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_UpdateVehUseRecord, L("UpdateVehUseRecord"));
            vehUseRecord.CreateChildPermission(PermissionNames.VehUseRecord_DeleteVehUseRecord, L("DeleteVehUseRecord"));

            //维保记录管理
            var vehMaintenance = veh.CreateChildPermission(PermissionNames.VehMaintenance, L("VehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_CreateVehMaintenance, L("CreateVehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_UpdateVehMaintenance, L("UpdateVehMaintenance"));
            vehMaintenance.CreateChildPermission(PermissionNames.VehMaintenance_DeleteVehMaintenance, L("DeleteVehMaintenance"));


            #endregion

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EMConsts.LocalizationSourceName);
        }
    }
}
