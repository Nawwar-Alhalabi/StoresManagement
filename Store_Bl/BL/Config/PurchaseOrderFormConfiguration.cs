using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class PurchaseOrderFormConfiguration : IEntityTypeConfiguration<PurchaseOrderForm>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderForm> builder)
        {
            builder.HasOne(x => x.Store)
                .WithMany(x => x.PurchaseOrderForms)
                .HasForeignKey(x => x.StoreId)
                .IsRequired();



        }
    }
}
