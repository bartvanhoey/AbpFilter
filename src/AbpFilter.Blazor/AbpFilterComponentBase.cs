using AbpFilter.Localization;
using Volo.Abp.AspNetCore.Components;

namespace AbpFilter.Blazor;

public abstract class AbpFilterComponentBase : AbpComponentBase
{
    protected AbpFilterComponentBase()
    {
        LocalizationResource = typeof(AbpFilterResource);
    }
}
