using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using KP.SmartSoc.Configuration;
using KP.SmartSoc.Web;

namespace KP.SmartSoc.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SmartSocDbContextFactory : IDesignTimeDbContextFactory<SmartSocDbContext>
    {
        public SmartSocDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SmartSocDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SmartSocDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SmartSocConsts.ConnectionStringName));

            return new SmartSocDbContext(builder.Options);
        }
    }
}
