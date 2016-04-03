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
    /// 人员编辑用Dto
    /// </summary>
    public class InfEmployerEditDto : CreateOrUpdateDto, IValidate
    {

		public System.Guid? Id {get;set;}
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Duty { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public Guid StationId { get; set; }

    }
}
