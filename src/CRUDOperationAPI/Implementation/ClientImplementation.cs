using CRUDOperationAPI.Connections;
using CRUDOperationAPI.InterfaceClass;
using CRUDOperationAPI.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CRUDOperationAPI.Models;
using Dapper;

namespace CRUDOperationAPI.Implementation
{
    public class ClientImplementation : IConnection, IClient
    {
        private string _connectionString;
        public ClientImplementation(IOptions<ConnectionConfig> connectionConfig)
        {
            var connection = connectionConfig.Value;
            string connectionString = connection.myconn;
            _connectionString = Connections(connectionString);
        }

        public string Connections(string ConnectionString)
        {
            return ConnectionString;
        }

        public int CountClient()
        {
            int exe;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                // string sqlQuery = "Select Count(Distinct(EmployeeID)) from Employees";
                // exe= db.Execute(sqlQuery);
                exe = db.Query<int>("Select Count(Distinct(ClientID)) from Clients").FirstOrDefault();
            }
            return exe;
        }

        public int DeleteClient(int id)
        {
            try
            {
                int exe;
                //var data = new Employee();
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    string data = "Delete from Clients where ClientID = @ClientID";
                    exe = db.Execute(data, new
                    {
                        ClientID = id
                    });
                }
                return exe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClientProjectViewModel> GetClientProject()
        {
            var data = new List<ClientProjectViewModel>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                data = db.Query<ClientProjectViewModel>("Select ClientProject.ClientProjectID,Clients.ClientID, Clients.ClientFirstName, Clients.ClientLastName, Clients.ClientOffice, Clients.OfficeAddress, Clients.ClientContactNumber, Projects.ProjectID, Projects.ProjectName  from ClientProject Join Clients ON (Clients.ClientID = ClientProject.ClientID) JOIN Projects ON (Projects.ProjectID = ClientProject.ProjectID)").ToList();
            }
            return data;
        }

        public ClientProjectViewModel GetClientByID(int id)
        {
            try
            {
                ClientProjectViewModel data;

                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    data = db.Query<ClientProjectViewModel>("SELECT * from Clients where ClientID = @ClientID", new { ClientID = id }).SingleOrDefault();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PostClient(ClientProjectViewModel client)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@ClientFirstName", client.ClientFirstName);
                    parameter.Add("@ClientLastName", client.ClientLastName);
                    parameter.Add("@ClientOffice", client.ClientOffice);
                    parameter.Add("@OfficeAddress", client.OfficeAddress);
                    parameter.Add("@ClientContactNumber", client.ClientContactNumber);
                    parameter.Add("@ProjectID", client.ProjectID);
                    db.Execute("InsertIntoClientProjects", parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PutClient(ClientProjectViewModel client)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@ClientFirstName", client.ClientFirstName);
                    parameter.Add("@ClientLastName", client.ClientLastName);
                    parameter.Add("@ClientOffice", client.ClientOffice);
                    parameter.Add("@OfficeAddress", client.OfficeAddress);
                    parameter.Add("@ClientContactNumber", client.ClientContactNumber);
                    parameter.Add("@ClientID", client.ClientID);
                    parameter.Add("@ClientProjectID", client.ClientProjectID);
                    parameter.Add("@ProjectID", client.ProjectID);
                    db.Execute("UpdateClient", parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClientProjectViewModel> GetALL()
        {
            var data = new List<ClientProjectViewModel>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                data = db.Query<ClientProjectViewModel>("Select * from clients").ToList();
            }
            return data;
        }
    }
}
