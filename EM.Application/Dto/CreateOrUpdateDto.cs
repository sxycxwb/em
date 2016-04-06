using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using System;
using Abp.Runtime.Session;
using Abp.Runtime.Validation;

namespace EM.Application.Dto
{
    public class CreateOrUpdateDto : IShouldNormalize
    {
        /// <summary>
        /// 删除标识
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 最后修改人ID
        /// </summary>
        public long? LastModifierUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModificationTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public long? CreatorUserId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }

        public void Normalize()
        {
            CreationTime = DateTime.Now;
            LastModificationTime = DateTime.Now;
            IsDeleted = 0;
        }
    }
}