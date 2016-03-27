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
    /// 维保记录    
    /// </summary>
    [Table("Veh_Maintenance")]
    public class VehMaintenance : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 使用单位ID
        /// </summary>
        public virtual Guid UseCompanyId { get; set; }

        /// <summary>
        /// 使用单位名称
        /// </summary>
        [NotMapped]
        public string UseCompanyName { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        public virtual string NumberPlate { get; set; }


        /// <summary>
        /// 车辆品牌
        /// </summary>
        public virtual string Brand { get; set; }


        /// <summary>
        /// 行驶里程
        /// </summary>
        public virtual int TripDistance { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        public virtual DateTime Date { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public virtual int Costs { get; set; }

        /// <summary>
        /// 责任人
        /// </summary>
        public virtual string DutyPerson { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual string Contact { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public virtual string Description { get; set; }
    }
}
