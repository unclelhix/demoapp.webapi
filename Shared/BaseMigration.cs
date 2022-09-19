using DemoApplication.WebAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DemoApplication.WebAPI.Shared
{
    public abstract class BaseMigration
    {
        protected ApplicationDbContext ApplicationDbContext { get; }

        private readonly string _migrationIdentifierKey;

        protected abstract Task ProcessMigration();

        public BaseMigration(ApplicationDbContext applicationDbContext, string migrationIdentifierKey)
        {
            ApplicationDbContext = applicationDbContext;
            _migrationIdentifierKey = migrationIdentifierKey ?? throw new ArgumentNullException(migrationIdentifierKey);
        }
        
        public async Task ExecuteMigations()
        {
            using var transaction = await ApplicationDbContext.BeginTransactionAsync();

            await ProcessMigration();

            await ApplicationDbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }

        protected async Task<bool> TryAddMigration([CallerMemberName] string migrationKey = null)
        {
            var migrationItemKey = CreateMigrationItemKey(migrationKey);
            //if (await ApplicationDbContext.MigrationItemEntity.AnyAsync(x => x.MigrationKey == migrationItemKey))
            //{
            //    return false;
            //}

            //await ApplicationDbContext.MigrationItemEntity.AddAsync(new Models.MigrationItemEntity()
            //{
            //    MigrationKey = migrationItemKey
            //});

            return true;
        }

        protected string CreateMigrationItemKey([CallerMemberName] string migrationKey = null)
        {
            return $"{_migrationIdentifierKey}|{migrationKey}";
        }
    }
}
