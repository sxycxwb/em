using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
    /// <summary>
    /// 电厂编辑用Dto
    /// </summary>
    public class InfStationEditDto : IValidate
    {

		public System.Guid? Id {get;set;}

        /// <summary>
        /// 地区ID
        /// </summary>
        public virtual Guid ZoneId { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public virtual string ZoneName { get; set; }

        /// <summary>
        /// 类型Id
        /// </summary>
        public virtual Guid TypeId { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public virtual string TypeName { get; set; }


        /// <summary>
        /// 电厂名称
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 投产时间
        /// </summary>
        public DateTime ProductionTime { get; set; }

        /// <summary>
        /// 股权比例
        /// </summary>
        public int OwnershipRatio { get; set; }

        /// <summary>
        /// 装机台数
        /// </summary>
        public int MachineNumber { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string MachineModel { get; set; }

        /// <summary>
        /// 装机容量
        /// </summary>
        public string MachineCapacity { get; set; }

    }
}
