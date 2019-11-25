using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter name of the employee")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter address of the employee")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter company name of the employee")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Please enter designation of the employee")]
        public string Designation { get; set; }
    }
}
