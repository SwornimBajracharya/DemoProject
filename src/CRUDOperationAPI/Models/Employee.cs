using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public virtual int? ContactId { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; } 
        public decimal Salary { get; set; }
        public float WorkingHrPerDay { get; set; }
        public bool IsFullTimer { get; set; } 

        [ForeignKey("ContactId")]
        public virtual Contacts Contacts { get; set; }
    }
}
