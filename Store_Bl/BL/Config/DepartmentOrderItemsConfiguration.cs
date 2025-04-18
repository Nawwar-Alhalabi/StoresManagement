using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class DepartmentOrderItemsConfiguration : IEntityTypeConfiguration<DepartmentOrderItems>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DepartmentOrderItems> builder)
        {
            builder.HasOne(x => x.DepartmentOrderForm)
                  .WithMany(x => x.DepartmentOrderItems)
                  .HasForeignKey(x => x.DepartmentOrderFormId).IsRequired();
        }
    }
}
