using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class Projects
    {
        [Key]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}
