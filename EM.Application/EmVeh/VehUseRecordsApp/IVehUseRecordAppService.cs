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
    /// 用车记录服务接口
    /// </summary>
    public interface IVehUseRecordAppService : IApplicationService
    {
        #region 用车记录管理

        /// <summary>
        /// 根据查询条件获取用车记录分页列表
        /// </summary>
        Task<PagedResultOutput<VehUseRecordListDto>> GetPagedVehUseRecords(GetVehUseRecordInput input);


        /// <summary>
        /// 获取指定id的用车记录信息
        /// </summary>
        Task<VehUseRecordEditDto> GetVehUseRecord(IdInput<System.Guid> input);

        /// <summary>
        /// 新增用车记录
        /// </summary>
        Task<int> CreateVehUseRecord(VehUseRecordEditDto input);

        /// <summary>
        /// 更新用车记录
        /// </summary>
        Task<int> UpdateVehUseRecord(VehUseRecordEditDto input);

        /// <summary>
        /// 删除用车记录
        /// </summary>
        Task<int> DeleteVehUseRecord(DeleteDto<Guid> input);

        #endregion

    }
}
