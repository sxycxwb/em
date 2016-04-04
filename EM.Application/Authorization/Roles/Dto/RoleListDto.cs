using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace EM.Authorization.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleListDto : EntityDto, IHasCreationTime
    {
        /// <summary>
        /// 租户中角色的唯一名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 角色中显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 表示该角色是否是静态的（预生成的和不能删除的）
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 该角色是否是默认赋给新用户的
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}