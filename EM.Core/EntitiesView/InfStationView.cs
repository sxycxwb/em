using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Entities
{
    /// <summary>
    /// 电厂视图
    /// </summary>
    public class InfStationView : FullAuditedEntity<Guid>
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
        [Required]
        public virtual string StationName { get; set; }

        /// <summary>
        /// 投产时间
        /// </summary>
        [Required]
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
