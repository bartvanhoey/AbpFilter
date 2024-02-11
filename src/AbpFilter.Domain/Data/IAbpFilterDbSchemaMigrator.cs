using System.Threading.Tasks;

namespace AbpFilter.Data;

public interface IAbpFilterDbSchemaMigrator
{
    Task MigrateAsync();
}
