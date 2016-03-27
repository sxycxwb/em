using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EM.Entities;
using EM.Entities.Dtos;
using EM.Authorization;

namespace EM.Application.InfStationsApp
{
    /// <summary>
    /// 电厂服务实现
    /// </summary>
    [AbpAuthorize(PermissionNames.InfStation)]
    public class InfStationAppService : EMAppServiceBase, IInfStationAppService
    {
        private readonly IRepository<InfStation,System.Guid> _infStationRepository;

        public InfStationAppService(
            IRepository<InfStation,System.Guid> infStationRepository
            )
        {
            _infStationRepository = infStationRepository;
        }

        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        public async Task<PagedResultOutput<InfStationListDto>> GetPagedInfStations(GetInfStationInput input)
        {
            var query = _infStationRepository.GetAll();
			//TODO:根据传入的参数添加过滤条件

			var infStationCount = query.Count();
            var infStations = query
                .OrderBy(d => input.Sorting)
                .PageBy(input)
                .ToList();

            var infStationListDtos = infStations.MapTo<List<InfStationListDto>>();
            return new PagedResultOutput<InfStationListDto>(
                infStationCount,
                infStationListDtos
               );
        }


        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        public async Task<InfStationEditDto> GetInfStation(System.Guid id)
        {
            var entity = await _infStationRepository.GetAsync(id);
            return entity.MapTo<InfStationEditDto>();
        }

        /// <summary>
        /// 新增或更改电厂
        /// </summary>
        public async Task CreateOrUpdateInfStation(CreateOrUpdateInfStationInput input)
        {
            if (input.InfStationEditDto.Id.HasValue)
            {
				await UpdateInfStation(input.InfStationEditDto);
            }
            else
            {
                await CreateInfStation(input.InfStationEditDto);
            }
        }

        /// <summary>
        /// 新增电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.InfStation_CreateInfStation)]
        public virtual async Task<InfStationEditDto> CreateInfStation(InfStationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增

            var entity = await _infStationRepository.InsertAsync(input.MapTo<InfStation>());
            return entity.MapTo<InfStationEditDto>();
        }

        /// <summary>
        /// 更新电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.InfStation_UpdateInfStation)]
        public virtual async Task UpdateInfStation(InfStationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新

            var entity = await _infStationRepository.GetAsync(input.Id.Value);
            await _infStationRepository.UpdateAsync(input.MapTo(entity));
        }

        /// <summary>
        /// 删除电厂
        /// </summary>
        [AbpAuthorize(PermissionNames.InfStation_DeleteInfStation)]
        public async Task DeleteInfStation(IdInput<System.Guid> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _infStationRepository.DeleteAsync(input.Id);
        }



        #endregion

    }
}
