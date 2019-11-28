using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDOperationAPI.Contexts;
using CRUDOperationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;
using CRUDOperationAPI.Connections;
using CRUDOperationAPI.Implementation;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDOperationAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        
        private EmployeeImplementation _employee;
        public EmployeeController(IOptions<ConnectionConfig> connectionConfig)
        {
            //_context = context;
            var connection = connectionConfig.Value;
            string connectionString = connection.myconn;
            _employee = new EmployeeImplementation(connectionString);
           

        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //return _context.Employees;
            //using (SqlConnection connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=EmployeeDb;Trusted_Connection=True;MultipleActiveResultSets=true"))
            //{
            //    var eventName = connection.QueryFirst<Employee>("SELECT * FROM Employees");
            //    yield return eventName;
            //}
            var getAllEmployee = _employee.GetAll();
            return getAllEmployee;

        }

        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmplooyes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employees = _employee.GetEmployeeByID(id);
            if (employees == null)
            {
                return NotFound();
            }
            //    var employees = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            //    if (employees == null)
            //    {
            //        return NotFound();
            //    }

               return Ok(employees);
            }

        // POST api/values

        [HttpPost]
        public async Task<IActionResult> PostEmployees([FromBody] Employee employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _employee.PostEmployee(employees);

            return CreatedAtAction("GetEmplooyes", new { id = employees.EmployeeId }, employees);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees([FromRoute] int id, [FromBody] Employee employees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employees.EmployeeId)
            {
                return BadRequest();
            }

            _employee.PutEmployee(employees);

            

            return NoContent();
        }
        //// DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = _employee.DeleteEmployee(id);
            //var employees = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employees == 0)
            {
                return NotFound();
            }

            //_context.Employees.Remove(employees);
            //await _context.SaveChangesAsync();

            return Ok(employees);
        }
        
     }
    }
