using CRUDOperationAPI.Models;
using CRUDOperationAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationAPI
{
    public interface IEmployee
    {
        List<EmployeeContacts> GetAll();
        EmployeeContacts GetEmployeeByID(int id);
        int DeleteEmployee(int id);
        void PostEmployee(EmployeeContacts emp);
        void PutEmployee(EmployeeContacts emp);
        int CountEmployee();
        List<EmployeeProjectViewModel> GetEmployeeWithProject();
        void AssignProjectToEmployee(EmployeeProjectViewModel empPro);
        void UpdateProjectToEmployee(EmployeeProjectViewModel empPro);
        int DeleteEmployeeAndProject(int id);

    }
}
