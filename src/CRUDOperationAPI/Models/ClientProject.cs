using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.Models
{
    public class ClientProject
    {
        public virtual int ProjectID { get; set; }
        public virtual int ClientID { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Projects Projects { get; set; }
        [ForeignKey("ClientID")]
        public virtual Clients  Clients { get; set; }
    }
}
