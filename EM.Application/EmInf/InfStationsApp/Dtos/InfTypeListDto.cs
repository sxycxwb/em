using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 类型列表Dto
    /// </summary>
    public class InfTypeListDto 
    {
        /// <summary>
        /// 类型ID
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public virtual string TypeName { get; set; }

    }
}
