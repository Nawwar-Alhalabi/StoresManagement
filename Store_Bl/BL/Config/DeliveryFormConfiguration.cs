using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class DeliveryFormConfiguration : IEntityTypeConfiguration<DeliveryForm>
    {
        public void Configure(EntityTypeBuilder<DeliveryForm> builder)
        {
            builder.HasOne(x => x.medicalDepartment)
                .WithMany(x => x.deliveryForms)
                .HasForeignKey(x => x.Med_Dep_Id)
                .IsRequired();

            builder.HasOne(x => x.store)
              .WithMany(x => x.deliveryForms)
              .HasForeignKey(x => x.storeId)
              .IsRequired();

            //builder.HasOne(x => x.departmentOrderForm)
            //   .WithOne(x => x.deliveryForm)
            //   .HasForeignKey<DeliveryForm>(x => x.departmentOrderFormId);

        }
    }
}
