using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL.Config
{
    public class ItemsPurchasedConfiguration : IEntityTypeConfiguration<Itemspurchased>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Itemspurchased> builder)
        {
            builder.HasOne(x => x.PurchaseForm)
                  .WithMany(x => x.ItemsPurchased)
                  .HasForeignKey(x => x.PurchaseOrderFormId);
        }
    }
}
