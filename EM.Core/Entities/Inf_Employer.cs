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
    /// 电厂
    /// </summary>
    public class Inf_Employer : FullAuditedEntity<Guid>
    {
       

        /// <summary>
        /// 员工姓名
        /// </summary>
        [Required]
        public virtual string Name { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [Required]
        public virtual string Duty { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual string Contact { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public virtual string Education { get; set; }

        /// <summary>
        /// 装机容量
        /// </summary>
        public virtual string MachineCapacity { get; set; }

        /// <summary>
        /// 电厂
        /// </summary>
        [ForeignKey("StationId")]
        public virtual Inf_Station Station { get; set; }
        public virtual Guid StationId { get; set; }

    }
}
