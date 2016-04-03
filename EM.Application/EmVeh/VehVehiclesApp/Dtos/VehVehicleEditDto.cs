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
    /// 车辆信息编辑用Dto
    /// </summary>
    public class VehVehicleEditDto : CreateOrUpdateDto, IValidate
    {

		public System.Guid? Id {get;set;}

        /// <summary>
        /// 车牌
        /// </summary>
        public string NumberPlate { get; set; }

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 发动机编号
        /// </summary>
        public string EngineNumber { get; set; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        public DateTime ProductionTime { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public int TripDistance { get; set; }

        /// <summary>
        /// 累积费用
        /// </summary>
        public int AccumulatedCosts { get; set; }

        /// <summary>
        /// 使用单位ID
        /// </summary>
        public Guid UseCompanyId { get; set; }

    }
}
