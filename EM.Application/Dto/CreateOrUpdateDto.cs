using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using System;
using Abp.Runtime.Session;

namespace EM.Application.Dto
{
    public class CreateOrUpdateDto
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        public int IsDeleted { get { return 0;} }

        /// <summary>
        /// 最后修改人ID
        /// </summary>
        public long? LastModifierUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModificationTime { get { return DateTime.Now; } }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get { return DateTime.Now; } }
    }
}