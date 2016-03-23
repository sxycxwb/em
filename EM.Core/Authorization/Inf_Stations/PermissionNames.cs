using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
    //TODO:★请将此类剪切到core/Authorization文件夹下
    /// <summary>
    /// 电厂管理权限
    /// </summary>
    public static partial class PermissionNames
    {
        /// <summary>
        /// 电厂管理权限
        /// </summary>
        public const string Inf_Station = "Entities.Inf_Station";
        /// <summary>
        /// 电厂创建权限
        /// </summary>
        public const string Inf_Station_CreateInf_Station = "Entities.Inf_Station.CreateInf_Station";
        /// <summary>
        /// 电厂修改权限
        /// </summary>
        public const string Inf_Station_UpdateInf_Station = "Entities.Inf_Station.UpdateInf_Station";
        /// <summary>
        /// 电厂删除权限
        /// </summary>
        public const string Inf_Station_DeleteInf_Station = "Entities.Inf_Station.DeleteInf_Station";
    }

}

