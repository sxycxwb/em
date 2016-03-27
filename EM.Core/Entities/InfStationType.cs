using Abp.Domain.Entities;
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
    /// 电厂类型
    /// </summary>
    [Table("Inf_StationType")]
    public class InfStationType : Entity<Guid>
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required]
        public virtual string TypeName { get; set; }
    }
}
