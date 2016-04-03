using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
    /// <summary>
    /// 车辆信息管理权限
    /// </summary>
    public static partial class PermissionNames
    {


        /// <summary>
        /// 车辆信息管理权限
        /// </summary>
        public const string VehVehicle = "Entities.VehVehicle";
        /// <summary>
        /// 车辆信息创建权限
        /// </summary>
        public const string VehVehicle_CreateVehVehicle = "Entities.VehVehicle.CreateVehVehicle";
        /// <summary>
        /// 车辆信息修改权限
        /// </summary>
        public const string VehVehicle_UpdateVehVehicle = "Entities.VehVehicle.UpdateVehVehicle";
        /// <summary>
        /// 车辆信息删除权限
        /// </summary>
        public const string VehVehicle_DeleteVehVehicle = "Entities.VehVehicle.DeleteVehVehicle";

    }

}

