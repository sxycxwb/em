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
    /// 用车记录
    /// </summary>
    [Table("Veh_UseRecord")]
    public class VehUseRecord : FullAuditedEntity<Guid>
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
        /// 责任人
        /// </summary>
        public virtual int OwnershipRatio { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual int Contact { get; set; }

        /// <summary>
        /// 使用单位
        /// </summary>
        public virtual string UseCompany { get; set; }

    }
}
