using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store_Bl.Models;

namespace Store_Bl.BL.Config
{
    public class DepartmentOrderFormConfiguration : IEntityTypeConfiguration<DepartmentOrderForm>
    {
        public void Configure(EntityTypeBuilder<DepartmentOrderForm> builder)
        {
            builder.HasOne(x => x.Store)
                .WithMany(x => x.DepartmentOrderForms)
                .HasForeignKey(x => x.StoreId)
                .IsRequired();

            builder.HasOne(x => x.MedicalDepartment)
               .WithMany(x => x.DepartmentOrderForms)
               .HasForeignKey(x => x.Med_Dep_Id)
               .IsRequired();


        }
    }
}
