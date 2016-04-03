using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Entities.Dtos;
using EM.Application.Dto;

namespace EM.Entities
{
	/// <summary>
    /// 人员服务接口
    /// </summary>
    public interface IInfEmployerAppService : IApplicationService
    {
        #region 人员管理

        /// <summary>
        /// 根据查询条件获取人员分页列表
        /// </summary>
        Task<PagedResultOutput<InfEmployerListDto>> GetPagedInfEmployers(GetInfEmployerInput input);


        /// <summary>
        /// 获取指定id的人员信息
        /// </summary>
        Task<InfEmployerEditDto> GetInfEmployer(IdInput<System.Guid> input);

        /// <summary>
        /// 新增人员
        /// </summary>
        Task<int> CreateInfEmployer(InfEmployerEditDto input);

        /// <summary>
        /// 更新人员
        /// </summary>
        Task<int> UpdateInfEmployer(InfEmployerEditDto input);

        /// <summary>
        /// 删除人员
        /// </summary>
        Task<int> DeleteInfEmployer(DeleteDto<Guid> input);

        #endregion

    }
}
