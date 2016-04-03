using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 用车记录列表Dto
    /// </summary>
    public class VehUseRecordListDto : EntityDto<System.Guid>
    {
        /// <summary>
        /// 使用单位名称
        /// </summary>
        public string UseCompanyName { get; set; }
        /// <summary>
        /// 车牌
        /// </summary>
        public string NumberPlate { get; set; }
        /// <summary>
        /// 车辆品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 外出时间
        /// </summary>
        public DateTime GoOutDate { get; set; }
        /// <summary>
        /// 回厂时间
        /// </summary>
        public DateTime GoBackDate { get; set; }
        /// <summary>
        /// 责任人
        /// </summary>
        public string DutyPerson { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }
    }
}
