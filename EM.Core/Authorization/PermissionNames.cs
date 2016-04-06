namespace EM.Authorization
{
    /// <summary>
    /// 权限名设置
    /// </summary>
    public static partial class PermissionNames
    {
        public const string Pages = "Pages";

        public const string Pages_Tenants = "Pages.Tenants";

        #region 系统管理
        /// <summary>
        /// 系统管理
        /// </summary>
        public const string Sys = "Sys";

        #region 电厂管理
        /// <summary>
        /// 电厂管理权限
        /// </summary>
        public const string InfStation = "Sys.InfStation";
        /// <summary>
        /// 电厂创建权限
        /// </summary>
        public const string InfStation_CreateInfStation = "Sys.InfStation.CreateInfStation";
        /// <summary>
        /// 电厂修改权限
        /// </summary>
        public const string InfStation_UpdateInfStation = "Sys.InfStation.UpdateInfStation";
        /// <summary>
        /// 电厂删除权限
        /// </summary>
        public const string InfStation_DeleteInfStation = "Sys.InfStation.DeleteInfStation";
        #endregion

        #region 人员管理权限
        /// <summary>
        /// 人员管理权限
        /// </summary>
        public const string InfEmployer = "Sys.InfEmployer";
        /// <summary>
        /// 人员创建权限
        /// </summary>
        public const string InfEmployer_CreateInfEmployer = "Sys.InfEmployer.CreateInfEmployer";
        /// <summary>
        /// 人员修改权限
        /// </summary>
        public const string InfEmployer_UpdateInfEmployer = "Sys.InfEmployer.UpdateInfEmployer";
        /// <summary>
        /// 人员删除权限
        /// </summary>
        public const string InfEmployer_DeleteInfEmployer = "Sys.InfEmployer.DeleteInfEmployer";
        #endregion

        #region 角色管理
        /// <summary>
        /// 角色管理权限
        /// </summary>
        public const string InfRole = "Sys.InfRole";
        /// <summary>
        /// 角色创建权限
        /// </summary>
        public const string InfRole_CreateInfRole = "Sys.InfRole.CreateInfRole";
        /// <summary>
        /// 角色修改权限
        /// </summary>
        public const string InfRole_UpdateInfRole = "Sys.InfRole.UpdateInfRole";
        /// <summary>
        /// 角色删除权限
        /// </summary>
        public const string InfRole_DeleteInfRole = "Sys.InfRole.DeleteInfRole";

        #endregion 

        #endregion

        #region 车辆管理
        /// <summary>
        /// 车辆管理
        /// </summary>
        public const string Veh = "Veh";

        #region 车辆信息
        /// <summary>
        /// 车辆信息管理权限
        /// </summary>
        public const string VehVehicle = "Veh.VehVehicle";
        /// <summary>
        /// 车辆信息创建权限
        /// </summary>
        public const string VehVehicle_CreateVehVehicle = "Veh.VehVehicle.CreateVehVehicle";
        /// <summary>
        /// 车辆信息修改权限
        /// </summary>
        public const string VehVehicle_UpdateVehVehicle = "Veh.VehVehicle.UpdateVehVehicle";
        /// <summary>
        /// 车辆信息删除权限
        /// </summary>
        public const string VehVehicle_DeleteVehVehicle = "Veh.VehVehicle.DeleteVehVehicle";

        #endregion

        #region 用车记录
        /// <summary>
        /// 用车记录管理权限
        /// </summary>
        public const string VehUseRecord = "Veh.VehUseRecord";
        /// <summary>
        /// 用车记录创建权限
        /// </summary>
        public const string VehUseRecord_CreateVehUseRecord = "Veh.VehUseRecord.CreateVehUseRecord";
        /// <summary>
        /// 用车记录修改权限
        /// </summary>
        public const string VehUseRecord_UpdateVehUseRecord = "Veh.VehUseRecord.UpdateVehUseRecord";
        /// <summary>
        /// 用车记录删除权限
        /// </summary>
        public const string VehUseRecord_DeleteVehUseRecord = "Veh.VehUseRecord.DeleteVehUseRecord";

        #endregion

        #region 维保记录
        /// <summary>
        /// 维保记录管理权限
        /// </summary>
        public const string VehMaintenance = "Veh.VehMaintenance";
        /// <summary>
        /// 维保记录创建权限
        /// </summary>
        public const string VehMaintenance_CreateVehMaintenance = "Veh.VehMaintenance.CreateVehMaintenance";
        /// <summary>
        /// 维保记录修改权限
        /// </summary>
        public const string VehMaintenance_UpdateVehMaintenance = "Veh.VehMaintenance.UpdateVehMaintenance";
        /// <summary>
        /// 维保记录删除权限
        /// </summary>
        public const string VehMaintenance_DeleteVehMaintenance = "Veh.VehMaintenance.DeleteVehMaintenance";
        #endregion 
        #endregion
    }
}