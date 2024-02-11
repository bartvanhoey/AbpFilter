using AbpFilter.Samples;
using Xunit;

namespace AbpFilter.EntityFrameworkCore.Applications;

[Collection(AbpFilterTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AbpFilterEntityFrameworkCoreTestModule>
{

}
