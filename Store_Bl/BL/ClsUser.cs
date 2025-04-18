using Microsoft.EntityFrameworkCore;
using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Store_Bl.Models.User;

namespace Store_Bl.BL
{
    public class ClsUser(ApplicationDbContext context)
    {
        public bool Add(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Edit(User user, int id)
        {
            try
            {
                var currentUser = context.Users.Find(id);
                if (currentUser != null)
                {
                    //currentUser.UserName = user.UserName;
                    //currentUser.Password = user.Password;
                    //currentUser.Role = user.Role;
                    //currentUser.StoreId = user.StoreId;
                    //currentUser.Medical_DepId = user.Medical_DepId;

                    currentUser = user;
                    context.Users.Update(currentUser);
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
        public User CheckLogin(User user)
        {
            try
            {
                var usr = context.Users.Include(x => x.Store).Include(x => x.MedicalDepartment).SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (usr != null)
                {
                    return usr;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var userToDelete = context.Users.Find(id);
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
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
        public List<User> GetAll()
        {
            return context.Users.ToList();
        }
        public User? GetById(int id)
        {
            return context.Users.Find(id);
        }



        //public bool CheckAccessPermission(enRoles Permission)
        //{
        //    if (_user.Role == Permission)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
