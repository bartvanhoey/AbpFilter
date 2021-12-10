using AbpFilter.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpFilter
{
    [DependsOn(
        typeof(AbpFilterEntityFrameworkCoreTestModule)
        )]
    public class AbpFilterDomainTestModule : AbpModule
    {

    }
}