using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using vcoresrobotics.website.Configuration;

namespace vcoresrobotics.website.Web.Host.Startup
{
    [DependsOn(
       typeof(websiteWebCoreModule))]
    public class websiteWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public websiteWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(websiteWebHostModule).GetAssembly());
        }
    }
}
