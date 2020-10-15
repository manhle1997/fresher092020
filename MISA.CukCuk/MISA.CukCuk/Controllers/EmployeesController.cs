using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Interfaces;
using MISA.CukCuk.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IDatabaseAccess _databaseAccess;
        public EmployeesController(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        //Lấy danh sách toàn bộ nhân viên
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            using DatabaseAccess databaseAccess = new DatabaseAccess();
            var employees = databaseAccess.GetEmployees();
            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }

        // Lấy thông tin nhân viên theo Id
        // GET api/<EmployeesController>/5
        [Route("{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            using DatabaseAccess databaseAccess = new DatabaseAccess();
            var employee = databaseAccess.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            using DatabaseAccess databaseAccess = new DatabaseAccess();
            var result = databaseAccess.Insert(employee);
            if (result == true)
            {
                return CreatedAtAction("POST", result);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Employee employee)
        {
            using DatabaseAccess databaseAccess = new DatabaseAccess();
            var result = databaseAccess.Update(id, employee);
            if (result == true)
            {
                return CreatedAtAction("POST", result);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            using DatabaseAccess databaseAccess = new DatabaseAccess();
            var result = databaseAccess.Delete(id);
            if (result == true)
            {
                return CreatedAtAction("POST", result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
