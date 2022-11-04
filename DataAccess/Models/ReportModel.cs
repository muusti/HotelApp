using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ReportModel
    {
        [DisplayName("Customer Full Name")]
        public string? CustomerFullName { get; set; }

        public string? Gender { get; set; }
        
    }
}
