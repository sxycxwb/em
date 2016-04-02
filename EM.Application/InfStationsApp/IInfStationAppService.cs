using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Entities.Dtos;

namespace EM.Application
{
	/// <summary>
    /// 电厂服务接口
    /// </summary>
    public interface IInfStationAppService : IApplicationService
    {
        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        Task<PagedResultOutput<InfStationListDto>> GetPagedInfStations(GetInfStationInput input);


        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        Task<InfStationEditDto> GetInfStation(Guid id);

        ///// <summary>
        ///// 新增电厂
        ///// </summary>
        //Task<InfStationEditDto> CreateInfStation(InfStationEditDto input);

        ///// <summary>
        ///// 更新电厂
        ///// </summary>
        //Task UpdateInfStation(InfStationEditDto input);

        ///// <summary>
        ///// 删除电厂
        ///// </summary>
        //Task DeleteInfStation(IdInput<System.Guid> input);

        #endregion

    }
}
