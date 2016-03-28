using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Abp.WebApi.Controllers.Dynamic.Builders;
using EM.Application;

namespace EM.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(EMApplicationModule))]
    public class EMWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(EMApplicationModule).Assembly, "app")
                .Build();
            //DynamicApiControllerBuilder.For<IInfStationAppService>("em/infstation").Build();
            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
        }
    }
}
