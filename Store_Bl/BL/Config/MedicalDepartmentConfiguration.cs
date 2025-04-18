using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL.Config
{
    public class MedicalDepartmentConfiguration : IEntityTypeConfiguration<MedicalDepartment>
    {
        public void Configure(EntityTypeBuilder<MedicalDepartment> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
