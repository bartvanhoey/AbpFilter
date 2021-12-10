using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpFilter.Data;
using Volo.Abp.DependencyInjection;

namespace AbpFilter.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpFilterDbSchemaMigrator
        : IAbpFilterDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpFilterDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpFilterDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpFilterDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
