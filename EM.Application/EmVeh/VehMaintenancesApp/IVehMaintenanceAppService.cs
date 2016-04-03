using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Entities.Dtos;
using EM.Application.Dto;

namespace EM.Application
{
    /// <summary>
    /// 维保记录服务接口
    /// </summary>
    public interface IVehMaintenanceAppService : IApplicationService
    {
        #region 维保记录管理

        /// <summary>
        /// 根据查询条件获取维保记录分页列表
        /// </summary>
        Task<PagedResultOutput<VehMaintenanceListDto>> GetPagedVehMaintenances(GetVehMaintenanceInput input);


        /// <summary>
        /// 获取指定id的维保记录信息
        /// </summary>
        Task<VehMaintenanceEditDto> GetVehMaintenance(IdInput<System.Guid> input);

        /// <summary>
        /// 新增维保记录
        /// </summary>
        Task<int> CreateVehMaintenance(VehMaintenanceEditDto input);

        /// <summary>
        /// 更新维保记录
        /// </summary>
        Task<int> UpdateVehMaintenance(VehMaintenanceEditDto input);

        /// <summary>
        /// 删除维保记录
        /// </summary>
        Task<int> DeleteVehMaintenance(DeleteDto<Guid> input);

        #endregion

    }
}
