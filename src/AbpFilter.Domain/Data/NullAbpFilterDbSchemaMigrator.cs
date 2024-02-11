using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpFilter.Data;

/* This is used if database provider does't define
 * IAbpFilterDbSchemaMigrator implementation.
 */
public class NullAbpFilterDbSchemaMigrator : IAbpFilterDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
