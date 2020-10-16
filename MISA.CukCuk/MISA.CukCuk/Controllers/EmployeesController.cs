using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DataAccess;
using MySql.Data.MySqlClient;
using MISA.Bussiness.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeBussiness _employeeBussiness;
        public EmployeesController(IEmployeeBussiness employeeBussiness)
        {
            _employeeBussiness = employeeBussiness;
        }

        //Lấy danh sách toàn bộ nhân viên
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {

            var employees = _employeeBussiness.GetEmployees();
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
            var employee = _employeeBussiness.GetEmployeeById(id);
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
            var result = _employeeBussiness.Insert(employee);
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
            var result = _employeeBussiness.Update(id, employee);
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
            var result = _employeeBussiness.Delete(id);
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
