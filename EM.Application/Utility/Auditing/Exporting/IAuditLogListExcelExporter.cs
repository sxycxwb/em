using System.Collections.Generic;
using EM.Application.Dto;
using EM.Auditing.Dto;

namespace EM.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
