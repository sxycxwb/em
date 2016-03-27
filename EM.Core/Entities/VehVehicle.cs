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
    /// 车辆信息
    /// </summary>
    [Table("Veh_Vehicle")]
    public class VehVehicle : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 车牌
        /// </summary>
        public virtual string NumberPlate { get; set; }


        /// <summary>
        /// 车辆品牌
        /// </summary>
        public virtual string Brand { get; set; }

        /// <summary>
        /// 车辆类型
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// 车辆颜色
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// 发动机编号
        /// </summary>
        public virtual string EngineNumber { get; set; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        [Required]
        public virtual DateTime ProductionTime { get; set; }

        /// <summary>
        /// 行驶里程
        /// </summary>
        public virtual int TripDistance { get; set; }

        /// <summary>
        /// 累积费用
        /// </summary>
        public virtual int AccumulatedCosts { get; set; }

        /// <summary>
        /// 使用单位ID
        /// </summary>
        public virtual Guid UseCompanyId { get; set; }

        /// <summary>
        /// 使用单位名称
        /// </summary>
        [NotMapped]
        public string UseCompanyName { get; set; }

    }
}
