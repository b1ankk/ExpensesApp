using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesApp.Shared.Models.Configurations
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> type)
        {
            type.HasKey(x => x.IdOperationType);

            type.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(60);
        }
    }
}