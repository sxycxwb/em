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

namespace EM.Application.VehUseRecordsApp
{
    /// <summary>
    /// 用车记录服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.VehUseRecord)]
    public class VehUseRecordAppService : EMAppServiceBase, IVehUseRecordAppService
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        public ILogger Logger { get; set; }

        #region 用车记录管理

        /// <summary>
        /// 根据查询条件获取用车记录分页列表
        /// </summary>
        public async Task<PagedResultOutput<VehUseRecordListDto>> GetPagedVehUseRecords(GetVehUseRecordInput input)
        {
            string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_UseRecord A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

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

                querySql += " or Contact = @Contact";
                param.Add("Contact", "%" + input.Filter + "%");

                querySql += " or DutyPerson = @DutyPerson";
                param.Add("DutyPerson", "%" + input.Filter + "%");

                querySql += " or Brand = @Brand)";
                param.Add("Brand", "%" + input.Filter + "%");
            }

            using (var conn = DBUtility.GetMySqlConnection())
            {
                var VehUseRecordCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql)).ToString();
                var VehUseRecordListDtos = conn.Query<VehUseRecordListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<VehUseRecordListDto>(int.Parse(VehUseRecordCount), VehUseRecordListDtos);
            }
        }

        /// <summary>
        /// 获取指定id的用车记录信息
        /// </summary>
        
        public async Task<VehUseRecordEditDto> GetVehUseRecord(IdInput<System.Guid> input)
        {
            try
            {
                string querySql = "SELECT A.*,B.STATIONNAME UseCompanyName FROM Veh_UseRecord A,INF_Station B WHERE A.ISDELETED=0 AND A.UseCompanyId = B.ID ";

                //TODO:根据传入的参数添加过滤条件
                var param = new DynamicParameters();
                if (!string.IsNullOrEmpty(input.Id.ToString()))
                {
                    querySql += " AND A.ID =@ID";
                    param.Add("ID", input.Id);
                }
                using (var conn = DBUtility.GetMySqlConnection())
                {
                    var VehUseRecordListDtos = conn.Query<VehUseRecordEditDto>(querySql, param);
                    return VehUseRecordListDtos.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增用车记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehUseRecord_CreateVehUseRecord)]
        public async Task<int> CreateVehUseRecord(VehUseRecordEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into veh_userecord(");
            strSql.Append("Id,UseCompanyId,NumberPlate,Brand,GoOutDate,GoBackDate,DutyPerson,Contact,Description,IsDeleted,CreationTime,CreatorUserId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@UseCompanyId,@NumberPlate,@Brand,@GoOutDate,@GoBackDate,@DutyPerson,@Contact,@Description,@IsDeleted,@CreationTime,@CreatorUserId)");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.Id = Guid.NewGuid();
                input.CreatorUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 更新用车记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehUseRecord_UpdateVehUseRecord)]
        public async Task<int> UpdateVehUseRecord(VehUseRecordEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update veh_userecord set ");
            strSql.Append("UseCompanyId=@UseCompanyId,");
            strSql.Append("NumberPlate=@NumberPlate,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("GoOutDate=@GoOutDate,");
            strSql.Append("GoBackDate=@GoBackDate,");
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
        /// 删除用车记录
        /// </summary>
        //[AbpAuthorize(PermissionNames.VehUseRecord_DeleteVehUseRecord)]
        [Audited]
        public async Task<int> DeleteVehUseRecord(DeleteDto<Guid> input)
        {
            string updateSql = "update veh_UseRecord set IsDeleted=@IsDeleted,DeleterUserId=@DeleterUserId,DeletionTime=@DeletionTime where ID=@ID";
            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.DeleterUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(updateSql, input);
            }
        }

        #endregion

    }
}
