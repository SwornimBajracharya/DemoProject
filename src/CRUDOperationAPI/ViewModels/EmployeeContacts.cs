using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.ViewModels
{
    public class EmployeeContacts
    {
        public int? EmployeeID { get; set; }
        public int? ContactID { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public decimal? Salary { get; set; }
        public float? WorkingHrPerDay { get; set; }
        public bool? IsFullTimer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
    }
}
