using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EM.Application.Caching.Dto;

namespace EM.Application.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultOutput<CacheDto> GetAllCaches();

        Task ClearCache(IdInput<string> input);

        Task ClearAllCaches();
    }
}
