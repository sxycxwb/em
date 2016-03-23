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
    [AutoMap(typeof(Inf_Station))]
    public class Inf_StationEditDto : IValidate
    {

		public System.Guid? Id {get;set;}
        public Guid ZoneId { get; set; }

        public Guid StationTypeId { get; set; }

        /// <summary>
        /// 电厂名称
        /// </summary>
        [Required]
        public string StationName { get; set; }

        /// <summary>
        /// 投产时间
        /// </summary>
        [Required]
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
