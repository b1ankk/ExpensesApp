using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesApp.Shared.Models.Configurations
{
    public class OperationOwnerConfiguration : IEntityTypeConfiguration<OperationOwner>
    {
        public void Configure(EntityTypeBuilder<OperationOwner> owner)
        {
            owner.HasKey(x => x.IdOperationOwner);

            owner.Property(x => x.Owner)
                 .IsRequired()
                 .HasMaxLength(40);
        }
    }
}