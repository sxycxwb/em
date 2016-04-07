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
        /// 使用单位ID
        /// </summary>
        public virtual Guid UseCompanyId { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        public virtual string NumberPlate { get; set; }

        /// <summary>
        /// 车辆品牌
        /// </summary>
        public virtual string Brand { get; set; }

        /// <summary>
        /// 外出时间
        /// </summary>
        public virtual DateTime GoOutDate { get; set; }

        /// <summary>
        /// 回厂时间
        /// </summary>
        public virtual DateTime GoBackDate { get; set; }

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
