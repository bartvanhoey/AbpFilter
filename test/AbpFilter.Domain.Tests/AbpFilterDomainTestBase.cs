using Volo.Abp.Modularity;

namespace AbpFilter;

/* Inherit from this class for your domain layer tests. */
public abstract class AbpFilterDomainTestBase<TStartupModule> : AbpFilterTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
