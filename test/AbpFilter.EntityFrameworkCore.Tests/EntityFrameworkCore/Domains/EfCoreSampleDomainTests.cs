using AbpFilter.Samples;
using Xunit;

namespace AbpFilter.EntityFrameworkCore.Domains;

[Collection(AbpFilterTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AbpFilterEntityFrameworkCoreTestModule>
{

}
