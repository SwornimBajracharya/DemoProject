using CRUDOperationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI
{
    public interface IEmployee
    {
        List<Employee> GetAll();
        Employee GetEmployeeByID(int id);
        Employee DeleteEmployee(int id);
    }
}
