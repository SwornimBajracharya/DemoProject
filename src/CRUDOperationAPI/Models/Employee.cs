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
        public virtual int? UserID { get; set; }
        public string Designation { get; set; }
        public bool IsWorking { get; set; } 
        public decimal Salary { get; set; }
        public bool IsFullTimer { get; set; } 
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime ModifiedTimeStamp { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contacts Contacts { get; set; }
        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
    }
}
