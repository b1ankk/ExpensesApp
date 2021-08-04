using ExpensesApp.Server.Models;
using ExpensesApp.Shared.Models;
using ExpensesApp.Shared.Models.Configurations;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExpensesApp.Server.Data
{
    public class DbContextImpl : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<OperationOwner> OperationOwners { get; set; }
        public DbSet<AccountingPeriod> AccountingPeriods { get; set; }
        
        
        public DbContextImpl(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions)
        {
            
        }
        
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.UseIdentityAlwaysColumns();
            
            builder.ApplyConfiguration(new OperationConfiguration());
            builder.ApplyConfiguration(new OperationTypeConfiguration());
            builder.ApplyConfiguration(new OperationOwnerConfiguration());
            builder.ApplyConfiguration(new AccountingPeriodConfiguration());
        }
    }
}
