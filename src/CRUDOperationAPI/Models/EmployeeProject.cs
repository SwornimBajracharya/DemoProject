using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class EmployeeProject
    {
        public virtual int ProjectID { get; set; }
        public virtual int EmployeeID { get; set; }

        [ForeignKey("ProjectID")]
        public Projects Projects { get; set; }
        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }
}
