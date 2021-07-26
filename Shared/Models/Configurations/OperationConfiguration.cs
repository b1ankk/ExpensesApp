using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesApp.Shared.Models.Configurations
{
    public class OperationConfiguration : IEntityTypeConfiguration<Operation>
    {
        public void Configure(EntityTypeBuilder<Operation> operation)
        {
            operation.HasKey(x => x.IdOperation);

            operation.Property(x => x.OperationDate)
                     .IsRequired();

            operation.Property(x => x.TransactionDate)
                     .IsRequired();

            operation.Property(x => x.TransactionType)
                     .IsRequired()
                     .HasMaxLength(40);

            operation.Property(x => x.Amount)
                     .IsRequired()
                     .HasPrecision(10, 2);

            operation.Property(x => x.Currency)
                     .IsRequired()
                     .HasMaxLength(10);

            operation.Property(x => x.AfterOperationBalance)
                     .IsRequired()
                     .HasPrecision(10, 2);

            operation.Property(x => x.Description)
                     .IsRequired()
                     .HasMaxLength(500);
        }
    }
}