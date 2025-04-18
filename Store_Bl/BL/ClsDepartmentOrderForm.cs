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
    public class ClsDepartmentOrderForm(ApplicationDbContext context)
    {

        public bool Add(DepartmentOrderForm departmentOrderForm)
        {
            try
            {
                context.DepartmentOrderForms.Add(departmentOrderForm);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DepartmentOrderForm GetById(int id)
        {
            try
            {
                var Dep_ord = context.DepartmentOrderForms.Include(x => x.Store).Include(x => x.MedicalDepartment).Include(x => x.DepartmentOrderItems).SingleOrDefault(x => x.Id == id);
                if (Dep_ord != null)
                {
                    return Dep_ord;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<DepartmentOrderForm> GetAll()
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

        //public List<DepartmentOrderForm> GetAllPendingDepartmentOrders()
        //{
        //    try
        //    {
        //        return context.DepartmentOrderForms.Include(x => x.DepartmentOrderItems).Include(x => x.MedicalDepartment).Include(x => x.Store).Where(x => x.IsApproved == OrderStatus.pending).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}    
        //public List<DepartmentOrderForm> GetAllPendingOrdersForDepartment(int medId)
        //{
        //    try
        //    {
        //        return context.DepartmentOrderForms.Include(x => x.DepartmentOrderItems).Include(x => x.MedicalDepartment).Include(x => x.Store).Where(x => x.IsApproved == OrderStatus.pending && x.Med_Dep_Id == medId).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        //public bool ApproveDepartmentOrder(int id)
        //{
        //    try
        //    {
        //        var departmentOrder = context.DepartmentOrderForms.Single(x => x.Id == id);
        //        departmentOrder.IsApproved = OrderStatus.approved;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //} 
        //public bool RejectDepartmentOrder(int id)
        //{
        //    try
        //    {
        //        var departmentOrder = context.DepartmentOrderForms.Single(x => x.Id == id);
        //        departmentOrder.IsApproved = OrderStatus.rejected;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}   
        //public List<DepartmentOrderForm> ShowApprovedDepartmentOrdersForOfficer(int id)
        //{
        //    try
        //    {
        //        return context.DepartmentOrderForms.Include(x => x.DepartmentOrderItems).Include(x => x.MedicalDepartment).Include(x => x.Store).Where(x => x.IsApproved == OrderStatus.approved && x.StoreId == id).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
