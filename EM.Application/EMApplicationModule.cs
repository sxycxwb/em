using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace EM
{
    [DependsOn(typeof(EMCoreModule), typeof(AbpAutoMapperModule))]
    public class EMApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
