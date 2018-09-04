using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DSCF.View
{
    public class EmployeeViewModel
    {
        [Display(Name="Employee Id")]
        public string id { get; set; }
        [Display(Name="Employee Name")]
        public string name { get; set; }
        [Display(Name="Email")]
        public string email { get; set; }
        [Display(Name="Department Id")]
        public string dept_id { get; set; }
        [Display(Name = "Active")]
        public bool active { get; set; }
    }
}
