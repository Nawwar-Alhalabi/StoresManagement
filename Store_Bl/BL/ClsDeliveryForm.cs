using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    public class ClsDeliveryForm(ApplicationDbContext context)
    {
        public bool Add(DeliveryForm deliveryForm)
        {
            try
            {   // should be transaction

                context.DeliveryForms.Add(deliveryForm);
                context.SaveChanges();
                //var relatedDepartmentForm = context.DepartmentOrderForms.Include(x => x.DepartmentOrderItems).SingleOrDefault(x => x.Id == deliveryForm.departmentOrderFormId);
                //foreach (var item in relatedDepartmentForm.DepartmentOrderItems)
                //{
                //    var itemDelivered = deliveryForm.ItemsDelivered.Where(x => x.SerialNumber == item.SerialNumber).FirstOrDefault();
                //    if (itemDelivered != null)
                //    {
                //        item.ApprovedQuantity = itemDelivered.QuantityDelivered;
                //    }
                //    else
                //    {
                //        lstitems.Add(item);
                //    }

                //}
                //context.SaveChanges();
                //context.Database.ExecuteSqlRaw("EXEC InsertOrUpdateDeliveryReports");

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<DeliveryForm> GetAll()
        {
            return context.DeliveryForms.Include(x => x.ItemsDelivered).Include(x => x.medicalDepartment).ToList();
        }
        public List<DeliveryForm> GetAllDeliveryFormForStore(int StoreId)
        {
            try
            {
                return context.DeliveryForms.Include(x => x.ItemsDelivered).Include(x => x.medicalDepartment).Include(x => x.store)
                    .Where(x => x.storeId == StoreId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DeliveryForm GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public void Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
