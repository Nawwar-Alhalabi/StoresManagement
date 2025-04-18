using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class ItemsReceivedConfiguration : IEntityTypeConfiguration<ItemsReceived>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemsReceived> builder)
        {
            builder.HasOne(x => x.ReceiptForm)
                  .WithMany(x => x.ItemsReceived)
                  .HasForeignKey(x => x.ReceiptFormId);
        }
    }
}
