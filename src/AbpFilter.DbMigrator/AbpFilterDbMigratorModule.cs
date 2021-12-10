using AbpFilter.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpFilter.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpFilterEntityFrameworkCoreModule),
        typeof(AbpFilterApplicationContractsModule)
        )]
    public class AbpFilterDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
