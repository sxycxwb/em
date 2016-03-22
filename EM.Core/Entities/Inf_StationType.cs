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
    /// 电厂类型
    /// </summary>
    public class Inf_StationType : Entity<Guid>
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required]
        public virtual string TypeName { get; set; }
    }
}
