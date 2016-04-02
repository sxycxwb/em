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
using System;
using Abp.Auditing;
using Dapper;

namespace EM.Application.InfStationsApp
{
    /// <summary>
    /// 电厂服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.InfStation)]
    public class InfStationAppService : EMAppServiceBase, IInfStationAppService
    {
        private readonly IRepository _infStationRepository;


        public InfStationAppService(IRepository<InfStation, System.Guid> infStationRepository)
        {
            _infStationRepository = infStationRepository;
        }

        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        public async Task<PagedResultOutput<InfStationListDto>> GetPagedInfStations(GetInfStationInput input)
        {
            string querySql = "SELECT A.*,B.TYPENAME,C.ZONENAME FROM INF_STATION A,INF_STATIONTYPE B,INF_ZONE C WHERE A.ZONEID = C.ID AND A.TYPEID=B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();
            if (!string.IsNullOrEmpty(input.StationName))
            {
                querySql += " AND STATIONNAME LIKE @STATIONNAME";
                param.Add("STATIONNAME", "%" + input.StationName + "%");
            }

            using (var conn = DBUtility.GetMySqlConnection())
            {
                var infStationCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql)).ToString();
                var infStationListDtos = conn.Query<InfStationListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<InfStationListDto>(int.Parse(infStationCount), infStationListDtos);
            }
        }


        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        [Audited]
        public async Task<InfStationEditDto> GetInfStation(InfStationEditDto input)
        {
            string querySql = "SELECT A.*,B.TYPENAME,C.ZONENAME FROM INF_STATION A,INF_STATIONTYPE B,INF_ZONE C WHERE A.ZONEID = C.ID AND A.TYPEID=B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();
            if (!string.IsNullOrEmpty(input.Id.ToString()))
            {
                querySql += " AND ID =@ID";
                param.Add("ID", input.Id);
            }
            using (var conn = DBUtility.GetMySqlConnection())
            {
                var infStationListDtos = conn.Query<InfStationEditDto>(querySql, param).FirstOrDefault();
                return infStationListDtos;
            }
        }

        ///// <summary>
        ///// 新增电厂
        ///// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_CreateInfStation)]
        //public virtual async Task<InfStationEditDto> CreateInfStation(InfStationEditDto input)
        //{
        //    //TODO:新增前的逻辑判断，是否允许新增

        //    var entity = await _infStationRepository.InsertAsync(input.MapTo<InfStation>());
        //    return entity.MapTo<InfStationEditDto>();
        //}

        ///// <summary>
        ///// 更新电厂
        ///// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_UpdateInfStation)]
        //public virtual async Task UpdateInfStation(InfStationEditDto input)
        //{
        //    //TODO:更新前的逻辑判断，是否允许更新

        //    var entity = await _infStationRepository.GetAsync(input.Id.Value);
        //    await _infStationRepository.UpdateAsync(input.MapTo(entity));
        //}

        ///// <summary>
        ///// 删除电厂
        ///// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_DeleteInfStation)]
        //public async Task DeleteInfStation(IdInput<System.Guid> input)
        //{
        //    //TODO:删除前的逻辑判断，是否允许删除
        //    await _infStationRepository.DeleteAsync(input.Id);
        //}



        #endregion

    }
}
