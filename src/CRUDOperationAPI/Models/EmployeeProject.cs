using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeProjectID { get; set; }
        public virtual int ProjectID { get; set; }
        public virtual int EmployeeID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Projects Projects { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
