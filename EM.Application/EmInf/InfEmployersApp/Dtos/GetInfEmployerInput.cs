using System;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using EM.Entities;
using EM.Application.Dto;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 人员查询Dto
    /// </summary>
    public class GetInfEmployerInput : PagedAndSortedInputDto, IShouldNormalize
    {
        //DOTO:在这里增加查询参数

		/// <summary>
	    /// 模糊查询参数
		/// </summary>
		public string Filter { get; set; }

        /// <summary>
        /// 单位ID
        /// </summary>
        public string StationId { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}
