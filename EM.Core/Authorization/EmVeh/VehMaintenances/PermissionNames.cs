using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
    /// <summary>
    /// 维保记录管理权限
    /// </summary>
    public static partial class PermissionNames
    {
        /// <summary>
        /// 维保记录管理权限
        /// </summary>
        public const string VehMaintenance = "Entities.VehMaintenance";
        /// <summary>
        /// 维保记录创建权限
        /// </summary>
        public const string VehMaintenance_CreateVehMaintenance = "Entities.VehMaintenance.CreateVehMaintenance";
        /// <summary>
        /// 维保记录修改权限
        /// </summary>
        public const string VehMaintenance_UpdateVehMaintenance = "Entities.VehMaintenance.UpdateVehMaintenance";
        /// <summary>
        /// 维保记录删除权限
        /// </summary>
        public const string VehMaintenance_DeleteVehMaintenance = "Entities.VehMaintenance.DeleteVehMaintenance";

    }

}

