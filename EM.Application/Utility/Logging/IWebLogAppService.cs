using Abp.Application.Services;
using EM.Application.Dto;
using EM.Logging.Dto;

namespace EM.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
