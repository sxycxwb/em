using System;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using EM.Entities;
using EM.Application.Dto;

namespace EM.Entities.Dtos
{
    /// <summary>
    /// 维保记录查询Dto
    /// </summary>
    public class GetVehMaintenanceInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

        /// <summary>
        /// 模糊查询参数
        /// </summary>
        public string Filter { get; set; }

        public string UseCompanyId { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
