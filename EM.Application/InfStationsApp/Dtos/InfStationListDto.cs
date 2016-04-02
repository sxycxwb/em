using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 电厂列表Dto
    /// </summary>
    public class InfStationListDto : EntityDto<System.Guid>
    {
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
        public virtual string StationName { get; set; }

        /// <summary>
        /// 投产时间
        /// </summary>
        public virtual DateTime ProductionTime { get; set; }

        /// <summary>
        /// 股权比例
        /// </summary>
        public virtual int OwnershipRatio { get; set; }

        /// <summary>
        /// 装机台数
        /// </summary>
        public virtual int MachineNumber { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public virtual string MachineModel { get; set; }

        /// <summary>
        /// 装机容量
        /// </summary>
        public virtual string MachineCapacity { get; set; }
    }
}
