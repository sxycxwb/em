using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Auditing.Dto;
using EM.Application.Dto;

namespace EM.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultOutput<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);
    }
}