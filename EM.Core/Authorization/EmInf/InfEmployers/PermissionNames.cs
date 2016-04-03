using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
    /// <summary>
    /// 人员管理权限
    /// </summary>
    public static partial class PermissionNames
    {
        /// <summary>
        /// 人员管理权限
        /// </summary>
        public const string InfEmployer = "Entities.InfEmployer";
        /// <summary>
        /// 人员创建权限
        /// </summary>
        public const string InfEmployer_CreateInfEmployer = "Entities.InfEmployer.CreateInfEmployer";
        /// <summary>
        /// 人员修改权限
        /// </summary>
        public const string InfEmployer_UpdateInfEmployer = "Entities.InfEmployer.UpdateInfEmployer";
        /// <summary>
        /// 人员删除权限
        /// </summary>
        public const string InfEmployer_DeleteInfEmployer = "Entities.InfEmployer.DeleteInfEmployer";

    }

}

