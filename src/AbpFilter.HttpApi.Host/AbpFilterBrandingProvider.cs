using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpFilter;

[Dependency(ReplaceServices = true)]
public class AbpFilterBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpFilter";
}
