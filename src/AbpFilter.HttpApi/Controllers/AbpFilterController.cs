using AbpFilter.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpFilter.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpFilterController : AbpControllerBase
{
    protected AbpFilterController()
    {
        LocalizationResource = typeof(AbpFilterResource);
    }
}
