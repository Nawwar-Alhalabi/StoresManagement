using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class ItemsDeliveredConfiguration : IEntityTypeConfiguration<ItemsDelivered>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemsDelivered> builder)
        {
            builder.HasOne(x => x.DeliveryForm)
                  .WithMany(x => x.ItemsDelivered)
                  .HasForeignKey(x => x.DeliveryFormId);
        }
    }
}
