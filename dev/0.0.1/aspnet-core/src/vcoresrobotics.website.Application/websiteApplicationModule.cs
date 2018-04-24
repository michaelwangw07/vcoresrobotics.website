using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using vcoresrobotics.website.Authorization;

namespace vcoresrobotics.website
{
    [DependsOn(
        typeof(websiteCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class websiteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<websiteAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(websiteApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
