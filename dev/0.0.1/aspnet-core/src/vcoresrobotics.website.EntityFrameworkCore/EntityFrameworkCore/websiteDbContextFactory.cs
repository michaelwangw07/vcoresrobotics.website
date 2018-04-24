using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using vcoresrobotics.website.Configuration;
using vcoresrobotics.website.Web;

namespace vcoresrobotics.website.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class websiteDbContextFactory : IDesignTimeDbContextFactory<websiteDbContext>
    {
        public websiteDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<websiteDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            websiteDbContextConfigurer.Configure(builder, configuration.GetConnectionString(websiteConsts.ConnectionStringName));

            return new websiteDbContext(builder.Options);
        }
    }
}
