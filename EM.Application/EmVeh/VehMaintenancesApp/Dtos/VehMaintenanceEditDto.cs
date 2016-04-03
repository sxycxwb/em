using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using EM.Entities;
using EM.Application.Dto;

namespace EM.Entities.Dtos
{
    /// <summary>
    /// 维保记录编辑用Dto
    /// </summary>
    public class VehMaintenanceEditDto : CreateOrUpdateDto, IValidate
    {

		public System.Guid? Id {get;set;}
        /// <summary>
        /// 使用单位ID
        /// </summary>
        public Guid UseCompanyId { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        public string NumberPlate { get; set; }

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public int TripDistance { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public int Costs { get; set; }

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
