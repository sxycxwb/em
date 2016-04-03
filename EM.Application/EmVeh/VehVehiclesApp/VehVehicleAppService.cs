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

namespace EM.Application.VehVehiclesApp
{
    /// <summary>
    /// 车辆服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.VehVehicle)]
    public class VehVehicleAppService : EMAppServiceBase, IVehVehicleAppService
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        public ILogger Logger { get; set; }

        #region 车辆管理

        /// <summary>
        /// 根据查询条件获取车辆分页列表
        /// </summary>
        public async Task<PagedResultOutput<VehVehicleListDto>> GetPagedVehVehicles(GetVehVehicleInput input)
        {
            string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_Vehicle A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();
            if (!string.IsNullOrEmpty(input.Filter))
            {
                querySql += " AND (NumberPlate = @NumberPlate";
                param.Add("NumberPlate", "%" + input.Filter + "%");

                querySql += " or EngineNumber = @EngineNumber";
                param.Add("EngineNumber", "%" + input.Filter + "%");

                querySql += " or Brand = @Brand)";
                param.Add("Brand", "%" + input.Filter + "%");
            }

            using (var conn = DBUtility.GetMySqlConnection())
            {
                var VehVehicleCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql)).ToString();
                var VehVehicleListDtos = conn.Query<VehVehicleListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<VehVehicleListDto>(int.Parse(VehVehicleCount), VehVehicleListDtos);
            }
        }

        /// <summary>
        /// 获取指定id的车辆信息
        /// </summary>
        [Audited]
        public async Task<VehVehicleEditDto> GetVehVehicle(IdInput<System.Guid> input)
        {
            try
            {
                string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_Vehicle A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

                //TODO:根据传入的参数添加过滤条件
                var param = new DynamicParameters();
                if (!string.IsNullOrEmpty(input.Id.ToString()))
                {
                    querySql += " AND A.ID =@ID";
                    param.Add("ID", input.Id);
                }
                using (var conn = DBUtility.GetMySqlConnection())
                {
                    var VehVehicleListDtos = conn.Query<VehVehicleEditDto>(querySql, param);
                    return VehVehicleListDtos.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增车辆
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehVehicle_CreateVehVehicle)]
        public async Task<int> CreateVehVehicle(VehVehicleEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into veh_vehicle(");
            strSql.Append("Id,NumberPlate,Brand,Type,Color,EngineNumber,ProductionTime,TripDistance,AccumulatedCosts,UseCompanyId,IsDeleted,CreationTime,CreatorUserId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@NumberPlate,@Brand,@Type,@Color,@EngineNumber,@ProductionTime,@TripDistance,@AccumulatedCosts,@UseCompanyId,@IsDeleted,@CreationTime,@CreatorUserId)");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.Id = Guid.NewGuid();
                input.CreatorUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 更新车辆
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehVehicle_UpdateVehVehicle)]
        public async Task<int> UpdateVehVehicle(VehVehicleEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update veh_vehicle set ");
            strSql.Append("NumberPlate=@NumberPlate,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("Type=@Type,");
            strSql.Append("Color=@Color,");
            strSql.Append("EngineNumber=@EngineNumber,");
            strSql.Append("ProductionTime=@ProductionTime,");
            strSql.Append("TripDistance=@TripDistance,");
            strSql.Append("AccumulatedCosts=@AccumulatedCosts,");
            strSql.Append("UseCompanyId=@UseCompanyId,");
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
        /// 删除车辆
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehVehicle_DeleteVehVehicle)]
        public async Task<int> DeleteVehVehicle(DeleteDto<Guid> input)
        {
            string updateSql = "update veh_vehicle set IsDeleted=@IsDeleted,DeleterUserId=@DeleterUserId,DeletionTime=@DeletionTime where ID=@ID";
            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.DeleterUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(updateSql, input);
            }
        }

        #endregion

    }
}
