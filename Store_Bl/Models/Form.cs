using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bl.Models
{
    [NotMapped]
    public class Form
    {
        public int Id { get; set; }
        public int Folder { get; set; }
        public int Serial { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
