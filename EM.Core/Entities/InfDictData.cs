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
    [Table("Inf_DictData")]
    public class InfDictData : Entity<Guid>
    {
        /// <summary>
        /// 字典项数据值
        /// </summary>
        [Required]
        public virtual string DictValue { get; set; }

        /// <summary>
        /// 字典类型
        /// </summary>
        public virtual InfDictType DictType { get; set; }
    }
}
