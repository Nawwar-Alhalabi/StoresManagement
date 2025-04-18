using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    // do not forget on delete cascade or set null
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) {  }

        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryForm> DeliveryForms { get; set; }
        public DbSet<DepartmentOrderForm> DepartmentOrderForms { get; set; }
        public DbSet<DepartmentOrderItems> DepartmentOrderItems { get; set; }
        public DbSet<PurchaseOrderForm> PurchaseOrderForms { get; set; }
        public DbSet<ReceiptForm> ReceiptForms { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<MedicalDepartment> MedicalDepartments { get; set; }
        public DbSet<ItemsDelivered> ItemsDelivered { get; set; }
        public DbSet<Itemspurchased> ItemsPurchased { get; set; }
        public DbSet<ItemsReceived> ItemsReceived { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


            modelBuilder.Entity<ItemsReceived>()
                   .ToTable(tb => tb.HasTrigger("trg_AfterInsertReceiptForm"));

            modelBuilder.Entity<ItemsDelivered>()
                   .ToTable(tb => tb.HasTrigger("trg_AfterInsertDeliveryForm"));

        }


    }
}
