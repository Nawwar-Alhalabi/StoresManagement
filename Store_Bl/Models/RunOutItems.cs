using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.Models
{
    [NotMapped]
    public class RunOutItems
    {
        public int ItemCardNumber { get; set; }
        public int ItemName { get; set; }
        public int FinalBalance { get; set; }
    }
}
