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
    /// 字典类型
    /// </summary>
    [Table("Inf_DictType")]
    public class InfDictType : Entity<Guid>
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        [Required]
        public virtual string TypeName { get; set; }
    }
}
