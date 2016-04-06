using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;

namespace EM.Application.Dto
{
    public class DeleteDto<TId> : IdInput<TId>, IShouldNormalize
    {
        /// <summary>
        /// 删除人ID
        /// </summary>
        public long? DeleterUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletionTime { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int IsDeleted { get; set; }

        public void Normalize()
        {
            DeletionTime = DateTime.Now;
            IsDeleted = 1;
        }
    }
}