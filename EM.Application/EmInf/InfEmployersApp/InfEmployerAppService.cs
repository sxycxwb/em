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

namespace EM.Application.InfEmployersApp
{
    /// <summary>
    /// 人员服务实现
    /// </summary>
    //[AbpAuthorize(PermissionNames.InfEmployer)]
    public class InfEmployerAppService : EMAppServiceBase, IInfEmployerAppService
    {
        /// <summary>
        /// 日志对象
        /// </summary>
        public ILogger Logger { get; set; }

        #region 人员管理

        /// <summary>
        /// 根据查询条件获取人员分页列表
        /// </summary>
        public async Task<PagedResultOutput<InfEmployerListDto>> GetPagedInfEmployers(GetInfEmployerInput input)
        {
            string querySql = "SELECT A.*,B.STATIONNAME FROM INF_Employer A,INF_Station B WHERE A.ISDELETED=0 AND A.StationId = B.ID ";

            //TODO:根据传入的参数添加过滤条件
            var param = new DynamicParameters();
            if (!string.IsNullOrEmpty(input.StationId))
            {
                querySql += " AND StationId = @StationId";
                param.Add("StationId", input.StationId);
            }
            if (!string.IsNullOrEmpty(input.Filter))
            {
                querySql += " AND (Name = @Name";
                param.Add("Name", "%" + input.Filter + "%");

                querySql += " or Contact = @Contact";
                param.Add("Contact", "%" + input.Filter + "%");

                querySql += " or Duty = @Duty)";
                param.Add("Duty", "%" + input.Filter + "%");
            }

            using (var conn = DBUtility.GetMySqlConnection())
            {
                var infEmployerCount = conn.ExecuteScalar(DBUtility.GetCountSql(querySql)).ToString();
                var infEmployerListDtos = conn.Query<InfEmployerListDto>(DBUtility.GetPagedAndSortedSql(querySql, input.Sorting, input.SkipCount, input.MaxResultCount), param).ToList();
                return new PagedResultOutput<InfEmployerListDto>(int.Parse(infEmployerCount), infEmployerListDtos);
            }
        }

        /// <summary>
        /// 获取指定id的人员信息
        /// </summary>
        [Audited]
        public async Task<InfEmployerEditDto> GetInfEmployer(IdInput<System.Guid> input)
        {
            try
            {
                string querySql = "SELECT A.*,B.STATIONNAME FROM INF_Employer A,INF_Station B WHERE A.ISDELETED=0 AND A.StationId = B.ID  ";

                //TODO:根据传入的参数添加过滤条件
                var param = new DynamicParameters();
                if (!string.IsNullOrEmpty(input.Id.ToString()))
                {
                    querySql += " AND A.ID =@ID";
                    param.Add("ID", input.Id);
                }
                using (var conn = DBUtility.GetMySqlConnection())
                {
                    var infEmployerListDtos = conn.Query<InfEmployerEditDto>(querySql, param);
                    return infEmployerListDtos.First();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新增人员
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfEmployer_CreateInfEmployer)]
        public async Task<int> CreateInfEmployer(InfEmployerEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into inf_employer(");
            strSql.Append("Id,Name,BirthDate,Duty,Education,Contact,StationId,IsDeleted,CreationTime,CreatorUserId)");
            strSql.Append(" values (");
            strSql.Append("@Id,@Name,@BirthDate,@Duty,@Education,@Contact,@StationId,@IsDeleted,@CreationTime,@CreatorUserId)");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.Id = Guid.NewGuid();
                input.CreatorUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 更新人员
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfEmployer_UpdateInfEmployer)]
        public async Task<int> UpdateInfEmployer(InfEmployerEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update inf_employer set ");
            strSql.Append("Name=@Name,");
            strSql.Append("BirthDate=@BirthDate,");
            strSql.Append("Duty=@Duty,");
            strSql.Append("Education=@Education,");
            strSql.Append("Contact=@Contact,");
            strSql.Append("StationId=@StationId,");
            strSql.Append(" where Id=@Id ");

            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.LastModifierUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(strSql.ToString(), input);
            }
        }

        /// <summary>
        /// 删除人员
        /// </summary>
        //[AbpAuthorize(PermissionNames.InfEmployer_DeleteInfEmployer)]
        public async Task<int> DeleteInfEmployer(DeleteDto<Guid> input)
        {
            string updateSql = "update INF_Employer set IsDeleted=@IsDeleted,DeleterUserId=@DeleterUserId,DeletionTime=@DeletionTime where ID=@ID";
            using (var conn = DBUtility.GetMySqlConnection())
            {
                input.DeleterUserId = AbpSession.UserId;
                return await conn.ExecuteAsync(updateSql, input);
            }
        }

        #endregion

    }
}
