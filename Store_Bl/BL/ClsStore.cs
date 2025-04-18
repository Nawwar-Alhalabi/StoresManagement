using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    public class ClsStore(ApplicationDbContext context)
    {
        public bool Add(Store store)
        {
            try
            {
                context.Stores.Add(store);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Store GetByName(string name)
        {
            var store = context.Stores.FirstOrDefault(x => x.StoreName == name);
            return store;
        }
        public Store GetStoreByKeeper(string officer)
        {
            var store = context.Stores.FirstOrDefault(x => x.Storekeeper == officer);
            return store;
        }
        public Store GetStoreForUser(User user)
        {
            var store = context.Stores.FirstOrDefault(x => x.Id == user.StoreId);
            return store;
        }
        public int GetItemBalanceInStore(int serialNumber)
        {
            try
            {
                var quantityRecieved = context.ItemsReceived.Where(x => x.SerialNumber == serialNumber).Sum(x => x.QuantityRecieved);
                var quantityDelivered = context.ItemsDelivered.Where(x => x.SerialNumber == serialNumber).Sum(x => x.QuantityDelivered);
                var itemBalance = quantityRecieved - quantityDelivered;
                return Convert.ToInt32(itemBalance);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var StoreToDelete = context.Stores.Find(id);
                if (StoreToDelete != null)
                {
                    context.Stores.Remove(StoreToDelete);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(Store store, int id)
        {
            try
            {
                var currentStore = context.Stores.Find(id);
                if (currentStore != null)
                {
                    currentStore = store;
                    context.Stores.Update(currentStore);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Store> GetAll()
        {
            return context.Stores.ToList();
        }
        public Store? GetById(int id)
        {
            return context.Stores.Find(id);
        }
    }
}
