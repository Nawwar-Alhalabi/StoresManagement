using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class ReportsConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Report> builder)
        {
            builder.HasOne(x => x.Store)
                  .WithMany(x => x.Reports)
                  .HasForeignKey(x => x.StoreId);
        }
    }
}
