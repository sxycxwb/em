using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Entities
{
    /// <summary>
    /// 字典数据项
    /// </summary>
    [Table("Inf_Zone")]
    public class InfZone : Entity<Guid>
    {
        /// <summary>
        /// 区域
        /// </summary>
        [Required]
        public virtual string ZoneName { get; set; }
    }
}
