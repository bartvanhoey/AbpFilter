using Volo.Abp.Modularity;

namespace AbpFilter;

[DependsOn(
    typeof(AbpFilterDomainModule),
    typeof(AbpFilterTestBaseModule)
)]
public class AbpFilterDomainTestModule : AbpModule
{

}
