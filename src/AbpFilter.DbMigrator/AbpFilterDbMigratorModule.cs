using AbpFilter.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AbpFilter.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpFilterEntityFrameworkCoreModule),
    typeof(AbpFilterApplicationContractsModule)
    )]
public class AbpFilterDbMigratorModule : AbpModule
{
}
