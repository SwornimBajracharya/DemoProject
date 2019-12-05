using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class DepartmentEmployee
    {
        public int DepartmentEmployeeID { get; set; }
        public virtual int DepartmentID { get; set; }
        public virtual int EmployeeID { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Departments Departments { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
