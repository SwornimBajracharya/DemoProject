using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class Clients
    {
        [Key]
        public int ClientID { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientOffice { get; set; }
        public string OfficeAddress { get; set; }
        public string ClientContactNumber { get; set; }
    }
}
