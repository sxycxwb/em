using Abp.Application.Services.Dto;
using System;

namespace EM.Application.Dto
{
    public class DeleteDto<TId> : IdInput<TId>
    {
        /// <summary>
        /// 删除人ID
        /// </summary>
        public long? DeleterUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime DeletionTime { get { return DateTime.Now; } }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int IsDeleted { get { return 1; } }
    }
}