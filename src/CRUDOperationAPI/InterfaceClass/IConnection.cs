using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI.InterfaceClass
{
    public interface IConnection
    {
       string Connections(string ConnectionString);
    }
}
