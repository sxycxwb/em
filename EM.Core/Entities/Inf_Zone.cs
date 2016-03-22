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
    /// 地区
    /// </summary>
    public class Inf_Zone : Entity<Guid>
    {
        /// <summary>
        /// 地区名称
        /// </summary>
        [Required]
        public virtual string ZoneName { get; set; }
    }
}
