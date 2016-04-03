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
    /// 车辆服务接口
    /// </summary>
    public interface IVehVehicleAppService : IApplicationService
    {
        #region 车辆管理

        /// <summary>
        /// 根据查询条件获取车辆分页列表
        /// </summary>
        Task<PagedResultOutput<VehVehicleListDto>> GetPagedVehVehicles(GetVehVehicleInput input);


        /// <summary>
        /// 获取指定id的车辆信息
        /// </summary>
        Task<VehVehicleEditDto> GetVehVehicle(IdInput<System.Guid> input);

        /// <summary>
        /// 新增车辆
        /// </summary>
        Task<int> CreateVehVehicle(VehVehicleEditDto input);

        /// <summary>
        /// 更新车辆
        /// </summary>
        Task<int> UpdateVehVehicle(VehVehicleEditDto input);

        /// <summary>
        /// 删除车辆
        /// </summary>
        Task<int> DeleteVehVehicle(DeleteDto<Guid> input);

        #endregion

    }
}
