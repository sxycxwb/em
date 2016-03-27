using System.Collections.Generic;
using Abp.Authorization;
using Abp.Localization;

namespace EM.Authorization
{
	 /// <summary>
     /// 电厂管理权限
     /// </summary>
  public static partial class PermissionNames
    {
        /// <summary>
        /// 电厂管理权限
        /// </summary>
        public const string InfStation = "Entities.InfStation";
		/// <summary>
        /// 电厂创建权限
        /// </summary>
        public const string InfStation_CreateInfStation = "Entities.InfStation.CreateInfStation";
		/// <summary>
        /// 电厂修改权限
        /// </summary>
        public const string InfStation_UpdateInfStation = "Entities.InfStation.UpdateInfStation";
		/// <summary>
        /// 电厂删除权限
        /// </summary>
        public const string InfStation_DeleteInfStation = "Entities.InfStation.DeleteInfStation";

    }
	
}

