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
using Abp.Runtime.Session;
using Castle.Core.Logging;
using System.Text;
using EM.Application.Dto;

namespace EM.Application.InfStationsApp
{
    /// <summary>
    /// 电厂服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.InfStation)]
    public class InfStationAppService : EMAppServiceBase, IInfStationAppService
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        public ILogger Logger { get; set; }

        #region 电厂管理

        /// <summary>
        /// 根据查询条件获取电厂分页列表
        /// </summary>
        public async Task<PagedResultOutput<InfStationListDto>> GetPagedInfStations(GetInfStationInput input)
        {
            string querySql = "SELECT A.*,B.TYPENAME,C.ZONENAME FROM INF_STATION A,INF_STATIONTYPE B,INF_ZONE C WHERE A.ISDELETED=0 AND A.ZONEID = C.ID AND A.TYPEID=B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();
            if (!string.IsNullOrEmpty(input.ZoneId))
            {
                querySql += " AND ZoneId = @ZoneId";
                param.Add("ZoneId", input.ZoneId);
            }
            if (!string.IsNullOrEmpty(input.TypeId))
            {
                querySql += " AND TypeId = @TypeId";
                param.Add("TypeId", input.TypeId);
            }

            using (var conn = DBUtility.GetMySqlConnection())
            {
                var infStationCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql), param).ToString();
                var infStationListDtos = conn.Query<InfStationListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<InfStationListDto>(int.Parse(infStationCount), infStationListDtos);
            }
        }

        /// <summary>
        /// 获取指定id的电厂信息
        /// </summary>
        public async Task<InfStationEditDto> GetInfStation(IdInput<System.Guid> input)
        {
            try
            {
                string querySql = "SELECT A.*,B.TYPENAME,C.ZONENAME FROM INF_STATION A,INF_STATIONTYPE B,INF_ZONE C WHERE A.ISDELETED=0 AND A.ZONEID = C.ID AND A.TYPEID=B.ID ";

                //TODO:根据传入的参数添加过滤条件
                var param = new DynamicParameters();
                if (!string.IsNullOrEmpty(input.Id.ToString()))
                {
                    querySql += " AND A.ID =@ID";
                    param.Add("ID", input.Id);
                }
                using (var conn = DBUtility.GetMySqlConnection())
                {
                    var infStationListDtos = conn.Query<InfStationEditDto>(querySql, param);
                    return infStationListDtos.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增电厂
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_CreateInfStation)]
        public async Task<int> CreateInfStation(InfStationEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into inf_station(");
            strSql.Append("Id,ZoneId,TypeId,StationName,ProductionTime,OwnershipRatio,MachineNumber,MachineModel,MachineCapacity,CreationTime,CreatorUserId,IsDeleted)");
            strSql.Append(" values (");
            strSql.Append("@Id,@ZoneId,@TypeId,@StationName,@ProductionTime,@OwnershipRatio,@MachineNumber,@MachineModel,@MachineCapacity,@CreationTime,@CreatorUserId,@IsDeleted)");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.Id = Guid.NewGuid();
                input.CreatorUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 更新电厂
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_UpdateInfStation)]
        public async Task<int> UpdateInfStation(InfStationEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update inf_station set ");
            strSql.Append("ZoneId=@ZoneId,");
            strSql.Append("TypeId=@TypeId,");
            strSql.Append("StationName=@StationName,");
            strSql.Append("ProductionTime=@ProductionTime,");
            strSql.Append("OwnershipRatio=@OwnershipRatio,");
            strSql.Append("MachineNumber=@MachineNumber,");
            strSql.Append("MachineModel=@MachineModel,");
            strSql.Append("MachineCapacity=@MachineCapacity,");
            strSql.Append("LastModificationTime=@LastModificationTime,");
            strSql.Append("LastModifierUserId=@LastModifierUserId");
            strSql.Append(" where Id=@Id ");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.LastModifierUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 删除电厂
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfStation_DeleteInfStation)]
        public async Task<int> DeleteInfStation(DeleteDto<Guid> input)
        {
            string updateSql = "update INF_STATION set IsDeleted=@IsDeleted,DeleterUserId=@DeleterUserId,DeletionTime=@DeletionTime where ID=@ID";
            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.DeleterUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(updateSql, input);
            }
        }

        #endregion

    }
}
