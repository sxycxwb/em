using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Abp.Extensions;
using EM.Entities;

namespace EM.Entities.Dtos
{
    /// <summary>
    /// 电厂新增和编辑时用Dto
    /// </summary>
    
    public class CreateOrUpdateInf_StationInput : IValidate
    {

		public Inf_StationEditDto Inf_StationEditDto {get;set;}
 
    }
}
