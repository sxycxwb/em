using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Entities.Dtos;

namespace EM.Entities
{
	/// <summary>
    /// 电厂服务接口
    /// </summary>
    public interface IInf_StationAppService : IApplicationService
    {
        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        Task<PagedResultOutput<Inf_StationListDto>> GetPagedInf_Stations(GetInf_StationInput input);


        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        Task<Inf_StationEditDto> GetInf_Station(System.Guid id);

        /// <summary>
        /// 新增或更改电厂
        /// </summary>
        Task CreateOrUpdateInf_Station(CreateOrUpdateInf_StationInput input);

        /// <summary>
        /// 新增电厂
        /// </summary>
        Task<Inf_StationEditDto> CreateInf_Station(Inf_StationEditDto input);

        /// <summary>
        /// 更新电厂
        /// </summary>
        Task UpdateInf_Station(Inf_StationEditDto input);

        /// <summary>
        /// 删除电厂
        /// </summary>
        Task DeleteInf_Station(IdInput<System.Guid> input);


        /// <summary>
        /// 批量删除电厂
        /// </summary>
        Task BatchDeleteInf_Station(IEnumerable<System.Guid> input);



        #endregion

    }
}
