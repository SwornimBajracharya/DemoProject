using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.ViewModels
{
    public class ClientProjectViewModel
    {
        public int ClientProjectID { get; set; }
        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientOffice { get; set; }
        public string OfficeAddress { get; set; }
        public string ClientContactNumber { get; set; }

    }
}
