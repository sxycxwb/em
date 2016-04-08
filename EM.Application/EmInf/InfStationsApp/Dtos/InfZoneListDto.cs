using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
	/// <summary>
    /// 区域列表Dto
    /// </summary>
    public class InfZoneListDto 
    {
        /// <summary>
        /// 地区ID
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public virtual string ZoneName { get; set; }

    }
}
