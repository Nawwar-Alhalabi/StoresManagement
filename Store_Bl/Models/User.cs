using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.Models
{
    public class User 
    {
        public enum enRoles
        {
            Manager, Officer, MedicalEmployee, observer
        };

        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public enRoles Role { get; set; }
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
        public MedicalDepartment? MedicalDepartment { get; set; }
        public int? Medical_DepId { get; set; }
    }
}
