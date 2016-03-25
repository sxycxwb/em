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
    [AutoMapFrom(typeof(Inf_Station))]
    public class Inf_StationListDto : EntityDto<System.Guid>
    {
        public Guid ZoneId { get; set; }
        public Guid StationTypeId { get; set; }
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
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
