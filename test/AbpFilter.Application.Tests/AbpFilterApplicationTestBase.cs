using Volo.Abp.Modularity;

namespace AbpFilter;

public abstract class AbpFilterApplicationTestBase<TStartupModule> : AbpFilterTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
