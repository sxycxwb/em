using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EM.Entities.Dtos;
using EM.Authorization;

namespace EM.Entities
{
    /// <summary>
    /// 电厂服务实现
    /// </summary>
    [AbpAuthorize(PermissionNames.Inf_Station)]
    public class Inf_StationAppService : EMAppServiceBase, IInf_StationAppService
    {
        private readonly IRepository<Inf_Station, System.Guid> _inf_StationRepository;

        public Inf_StationAppService(
            IRepository<Inf_Station, System.Guid> inf_StationRepository
            )
        {
            _inf_StationRepository = inf_StationRepository;
        }

        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        public async Task<PagedResultOutput<Inf_StationListDto>> GetPagedInf_Stations(GetInf_StationInput input)
        {

            var query = _inf_StationRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件

            var inf_StationCount = query.Count();

            var inf_Stations = query
                .OrderBy(d => input.Sorting)
                .PageBy(input)
                .ToList();

            var inf_StationListDtos = inf_Stations.MapTo<List<Inf_StationListDto>>();
            return new PagedResultOutput<Inf_StationListDto>(
                inf_StationCount,
                inf_StationListDtos
               );
        }


        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        public async Task<Inf_StationEditDto> GetInf_Station(System.Guid id)
        {
            var entity = await _inf_StationRepository.GetAsync(id);
            return entity.MapTo<Inf_StationEditDto>();
        }

        /// <summary>
        /// 新增或更改电厂
        /// </summary>
        public async Task CreateOrUpdateInf_Station(CreateOrUpdateInf_StationInput input)
        {
            if (input.Inf_StationEditDto.Id.HasValue)
            {
                await UpdateInf_Station(input.Inf_StationEditDto);
            }
            else
            {
                await CreateInf_Station(input.Inf_StationEditDto);
            }
        }

        /// <summary>
        /// 新增电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.Inf_Station_CreateInf_Station)]
        public virtual async Task<Inf_StationEditDto> CreateInf_Station(Inf_StationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = await _inf_StationRepository.InsertAsync(input.MapTo<Inf_Station>());
            return entity.MapTo<Inf_StationEditDto>();
        }

        /// <summary>
        /// 更新电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.Inf_Station_UpdateInf_Station)]
        public virtual async Task UpdateInf_Station(Inf_StationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _inf_StationRepository.GetAsync(input.Id.Value);
            await _inf_StationRepository.UpdateAsync(input.MapTo(entity));
        }

        /// <summary>
        /// 删除电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.Inf_Station_DeleteInf_Station)]
        public async Task DeleteInf_Station(IdInput<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _inf_StationRepository.DeleteAsync(input.Id);
        }


        /// <summary>
        /// 批量删除电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.Inf_Station_DeleteInf_Station)]
        public async Task BatchDeleteInf_Station(IEnumerable<System.Guid> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _inf_StationRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        #endregion

    }
}
