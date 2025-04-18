using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    public class ClsReceiptForm(ApplicationDbContext context)
    {
       
        public bool Add(ReceiptForm receiptForm)
        {
            try
            {
                context.ReceiptForms.Add(receiptForm);
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

        public List<ReceiptForm> GetAll()
        {
            throw new NotImplementedException();
        }
        public List<ReceiptForm> GetAllReceiptFormForStore(int storeId)
        {
            try
            {
                return context.ReceiptForms.Include(x => x.ItemsReceived).Include(x => x.store)
                    .Where(x => x.StoreId == storeId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ReceiptForm GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
