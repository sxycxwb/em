using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
    /// <summary>
    /// 用车记录管理权限
    /// </summary>
    public static partial class PermissionNames
    {


        /// <summary>
        /// 用车记录管理权限
        /// </summary>
        public const string VehUseRecord = "Entities.VehUseRecord";
        /// <summary>
        /// 用车记录创建权限
        /// </summary>
        public const string VehUseRecord_CreateVehUseRecord = "Entities.VehUseRecord.CreateVehUseRecord";
        /// <summary>
        /// 用车记录修改权限
        /// </summary>
        public const string VehUseRecord_UpdateVehUseRecord = "Entities.VehUseRecord.UpdateVehUseRecord";
        /// <summary>
        /// 用车记录删除权限
        /// </summary>
        public const string VehUseRecord_DeleteVehUseRecord = "Entities.VehUseRecord.DeleteVehUseRecord";

    }

}

