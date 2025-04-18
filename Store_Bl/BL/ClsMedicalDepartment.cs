using Store_Bl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.BL
{
    public class ClsMedicalDepartment(ApplicationDbContext context) 
    {
        public bool Add(MedicalDepartment medicalDepartment)
        {
            try
            {
                context.MedicalDepartments.Add(medicalDepartment);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<MedicalDepartment> GetAll()
        {
            return context.MedicalDepartments.ToList();
        }
        public MedicalDepartment? GetByName(string medicalDepartmentName)
        {
            var department = context.MedicalDepartments.FirstOrDefault(x => x.Dep_Name == medicalDepartmentName);
            return department;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public MedicalDepartment GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
