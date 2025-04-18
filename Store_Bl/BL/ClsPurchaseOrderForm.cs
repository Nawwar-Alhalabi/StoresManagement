using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    public class ClsPurchaseOrderForm(ApplicationDbContext context)
    {
        
        public bool Add(PurchaseOrderForm purchaseOrderForm)
        {
            try
            {
                context.PurchaseOrderForms.Add(purchaseOrderForm);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public List<PurchaseOrderForm> GetAll()
        {
            var allPurchaseItems = context.PurchaseOrderForms.Include(x => x.ItemsPurchased).Include(x => x.Store).ToList();
            return allPurchaseItems;
        }

        public PurchaseOrderForm? GetById(int id)
        {
            try
            {
                var Pur_ord = context.PurchaseOrderForms.Include(x => x.Store).Include(x => x.ItemsPurchased).SingleOrDefault(x => x.Id == id);
                if (Pur_ord != null)
                {
                    return Pur_ord;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }    


        //public List<PurchaseOrderForm> GetAllPendingPurchaseOrders()
        //{
        //    try
        //    {
        //        return context.PurchaseOrderForms.Include(x => x.ItemsPurchased).Include(x => x.Store).Where(x => x.ManagerApproval == OrderStatus.pending).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}  
 
        //public bool ApprovePurchaseOrder(int id)
        //{
        //    try
        //    {
        //        var PurchaseOrder = context.PurchaseOrderForms.Single(x => x.Id == id);
        //        PurchaseOrder.ManagerApproval = OrderStatus.approved;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}  
        //public bool ApprovePurchaseOrderForAccountant(int id)
        //{
        //    try
        //    {
        //        var PurchaseOrder = context.PurchaseOrderForms.Single(x => x.Id == id);
        //        PurchaseOrder.AccountantApproval = OrderStatus.approved;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}   
        //public bool RejectPurchaseOrder(int id)
        //{
        //    try
        //    {
        //        var PurchaseOrder = context.PurchaseOrderForms.Single(x => x.Id == id);
        //        PurchaseOrder.ManagerApproval = OrderStatus.rejected;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}   
        //public bool RejectPurchaseOrderForAccountant(int id)
        //{
        //    try
        //    {
        //        var PurchaseOrder = context.PurchaseOrderForms.Single(x => x.Id == id);
        //        PurchaseOrder.AccountantApproval = OrderStatus.rejected;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}


        //public List<PurchaseOrderForm> GetAllPendingPurchaseOrdersForAccountant()
        //{
        //    try
        //    {
        //        return context.PurchaseOrderForms.Include(x => x.ItemsPurchased).Include(x => x.Store).Where(x => x.AccountantApproval == OrderStatus.pending).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}    
        //public List<PurchaseOrderForm> ShowApprovedPurchaseOrdersForOfficer(int storeId)
        //{
        //    try
        //    {
        //        return context.PurchaseOrderForms.Include(x => x.ItemsPurchased).Include(x => x.Store).Where(x => x.ManagerApproval == OrderStatus.approved && x.AccountantApproval == OrderStatus.approved && x.StoreId == storeId).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
