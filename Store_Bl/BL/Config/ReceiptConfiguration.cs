using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL.Config
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<ReceiptForm>
    {
        public void Configure(EntityTypeBuilder<ReceiptForm> builder)
        {
            builder.HasOne(x => x.store)
                .WithMany(x => x.ReceiptForms)
                .HasForeignKey(x => x.StoreId)
                .IsRequired();

            //builder.HasOne(x => x.PurchaseOrderForm)
            //   .WithOne(x => x.ReceiptForm)
            //   .HasForeignKey<ReceiptForm>(x => x.PurchaseOrderFormId).IsRequired(false);
        }
    }
}
