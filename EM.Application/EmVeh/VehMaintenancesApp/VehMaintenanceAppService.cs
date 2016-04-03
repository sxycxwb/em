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

namespace EM.Application.VehMaintenancesApp
{
    /// <summary>
    /// 维保记录服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.VehMaintenance)]
    public class VehMaintenanceAppService : EMAppServiceBase, IVehMaintenanceAppService
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        public ILogger Logger { get; set; }

        #region 维保记录管理

        /// <summary>
        /// 根据查询条件获取维保记录分页列表
        /// </summary>
        public async Task<PagedResultOutput<VehMaintenanceListDto>> GetPagedVehMaintenances(GetVehMaintenanceInput input)
        {
            string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_Maintenance A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();

            if (!string.IsNullOrEmpty(input.UseCompanyId))
            {
                querySql += " AND UseCompanyId = @UseCompanyId";
                param.Add("UseCompanyId", input.UseCompanyId);
            }

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
                var VehMaintenanceCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql)).ToString();
                var VehMaintenanceListDtos = conn.Query<VehMaintenanceListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<VehMaintenanceListDto>(int.Parse(VehMaintenanceCount), VehMaintenanceListDtos);
            }
        }

        /// <summary>
        /// 获取指定id的维保记录信息
        /// </summary>
        [Audited]
        public async Task<VehMaintenanceEditDto> GetVehMaintenance(IdInput<System.Guid> input)
        {
            try
            {
                string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_Maintenance A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

                //TODO:根据传入的参数添加过滤条件
                var param = new DynamicParameters();
                if (!string.IsNullOrEmpty(input.Id.ToString()))
                {
                    querySql += " AND A.ID =@ID";
                    param.Add("ID", input.Id);
                }
                using (var conn = DBUtility.GetMySqlConnection())
                {
                    var VehMaintenanceListDtos = conn.Query<VehMaintenanceEditDto>(querySql, param);
                    return VehMaintenanceListDtos.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增维保记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehMaintenance_CreateVehMaintenance)]
        public async Task<int> CreateVehMaintenance(VehMaintenanceEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into veh_maintenance(");
            strSql.Append("Id,UseCompanyId,NumberPlate,Brand,TripDistance,Date,Type,Costs,DutyPerson,Contact,Description,IsDeleted,CreationTime,CreatorUserId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@UseCompanyId,@NumberPlate,@Brand,@TripDistance,@Date,@Type,@Costs,@DutyPerson,@Contact,@Description,@IsDeleted,@CreationTime,@CreatorUserId)");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.Id = Guid.NewGuid();
                input.CreatorUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 更新维保记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehMaintenance_UpdateVehMaintenance)]
        public async Task<int> UpdateVehMaintenance(VehMaintenanceEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update veh_maintenance set ");
            strSql.Append("UseCompanyId=@UseCompanyId,");
            strSql.Append("NumberPlate=@NumberPlate,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("TripDistance=@TripDistance,");
            strSql.Append("Date=@Date,");
            strSql.Append("Type=@Type,");
            strSql.Append("Costs=@Costs,");
            strSql.Append("DutyPerson=@DutyPerson,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("Description=@Description,");
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
        /// 删除维保记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehMaintenance_DeleteVehMaintenance)]
        public async Task<int> DeleteVehMaintenance(DeleteDto<Guid> input)
        {
            string updateSql = "update veh_Maintenance set IsDeleted=@IsDeleted,DeleterUserId=@DeleterUserId,DeletionTime=@DeletionTime where ID=@ID";
            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.DeleterUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(updateSql, input);
            }
        }

        #endregion

    }
}
