using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesApp.Shared.Models.Configurations
{
    public class AccountingPeriodConfiguration : IEntityTypeConfiguration<AccountingPeriod>
    {
        public void Configure(EntityTypeBuilder<AccountingPeriod> period) {
            period.HasKey(x => x.IdAccountingPeriod);

            period.Property(x => x.CreationDateTime)
                  .IsRequired();

            period.Property(x => x.StartDateInclusive)
                  .IsRequired();

            period.Property(x => x.EndDateExclusive)
                  .IsRequired();
        }
    }
}
