using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using EM.Entities;
using EM.Application.Dto;

namespace EM.Entities.Dtos
{
    /// <summary>
    /// 区域编辑Dto
    /// </summary>
    public class InfZoneEditDto
    {

        public System.Guid? Id { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public virtual Guid ZoneName { get; set; }

    }
}
