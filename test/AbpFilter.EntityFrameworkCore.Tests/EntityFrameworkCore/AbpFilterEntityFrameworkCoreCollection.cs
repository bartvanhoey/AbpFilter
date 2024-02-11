using Xunit;

namespace AbpFilter.EntityFrameworkCore;

[CollectionDefinition(AbpFilterTestConsts.CollectionDefinitionName)]
public class AbpFilterEntityFrameworkCoreCollection : ICollectionFixture<AbpFilterEntityFrameworkCoreFixture>
{

}
