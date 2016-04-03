using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 人员列表Dto
    /// </summary>
    public class InfEmployerListDto : EntityDto<System.Guid>
    {
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 职务
        /// </summary>
        public string Duty { get; set; }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 所属单位
        /// </summary>
        public string StationName { get; set; }
    }
}
