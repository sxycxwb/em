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
    /// 人员
    /// </summary>
    [Table("Inf_Employer")]
    public class InfEmployer : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 人员姓名
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
        public virtual string Duty { get; set; }
        /// <summary>
        /// 第一学历
        /// </summary>
        public virtual string Education { get; set; }
        /// <summary>
        /// 第一专业
        /// </summary>
        public virtual string Profession { get; set; }
        /// <summary>
        /// 最高学历
        /// </summary>
        public virtual string HighEducation { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public virtual string Contact { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual Guid StationId { get; set; }

    }
}
