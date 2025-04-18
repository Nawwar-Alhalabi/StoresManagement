using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Store)
                  .WithMany(x => x.users)
                  .HasForeignKey(x => x.StoreId).IsRequired(false);

            builder.HasOne(x => x.MedicalDepartment)
               .WithMany(x => x.users)
               .HasForeignKey(x => x.Medical_DepId).IsRequired(false);
        }
    }
}
