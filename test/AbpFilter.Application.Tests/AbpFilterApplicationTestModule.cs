using Volo.Abp.Modularity;

namespace AbpFilter;

[DependsOn(
    typeof(AbpFilterApplicationModule),
    typeof(AbpFilterDomainTestModule)
)]
public class AbpFilterApplicationTestModule : AbpModule
{

}
