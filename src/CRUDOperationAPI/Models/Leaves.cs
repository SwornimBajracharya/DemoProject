using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class Leaves
    {
        [Key]
        public int LeaveID { get; set; }
        public virtual int EmployeeID { get; set; }
        public string LeaveReason { get; set; }
        public string LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ArrovedBy { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTimeStamp { get; set; }
        public DateTime ModifiedTimeStamp { get; set; }


        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
