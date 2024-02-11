using System;
using System.Collections.Generic;
using System.Text;
using AbpFilter.Localization;
using Volo.Abp.Application.Services;

namespace AbpFilter;

/* Inherit your application services from this class.
 */
public abstract class AbpFilterAppService : ApplicationService
{
    protected AbpFilterAppService()
    {
        LocalizationResource = typeof(AbpFilterResource);
    }
}
