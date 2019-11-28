using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDOperationAPI.Models;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace CRUDOperationAPI.Implementation
{
    public class EmployeeImplementation 
    {
        private string _connectionString;

        //private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);

        public EmployeeImplementation(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Employee> GetAll()
        {
            var data = new List<Employee>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                data = db.Query<Employee>("SELECT * FROM Employees").ToList();
            }
            return data;
        }

        public Employee GetEmployeeByID(int id)
        {
            Employee data;
            
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                data= db.Query<Employee>("Select * from Employees where EmployeeId = @EmployeeId", new { EmployeeId= id }).SingleOrDefault();
            }
            return data;
        }
        public int DeleteEmployee(int id)
        {
            int exe;
            //var data = new Employee();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               string data = "Delete from Employees where EmployeeID = @EmployeeID";
                exe = db.Execute(data, new
                {
                    EmployeeID = id
                });
            }
            return exe;
        }

        public void PostEmployee(Employee emp)
        {
            //var data = new Employee();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {

                    string sqlQuery = @"Insert into Employees (name, address, companyName, designation) Values (@Name,@Address,@CompanyName,@Designation)";
                    db.Execute(sqlQuery, new
                    {
                        Name = emp.Name,
                        Address = emp.Address,
                        CompanyName = emp.CompanyName,
                        Designation = emp.Designation
                    });
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void PutEmployee(Employee emp)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sqlQuery = @"Update Employees set Name = @Name, Address = @Address, CompanyName = @CompanyName, Designation = @Designation where EmployeeId = @EmployeeId";
                db.Execute(sqlQuery, new {
                    Name = emp.Name,
                    Address =emp.Address,
                    CompanyName = emp.CompanyName,
                    Designation = emp.Designation,
                    EmployeeId = emp.EmployeeId
                });

            }

        }
    }
}
