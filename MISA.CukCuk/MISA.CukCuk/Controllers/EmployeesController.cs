using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MySql.Data.MySqlClient;
using MISA.Bussiness.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeBussiness;
        public EmployeesController(IEmployeeService employeeBussiness)
        {
            _employeeBussiness = employeeBussiness;
        }

        /// <summary>
        /// Lấy danh sách toàn bộ nhân viên
        /// </summary>
        /// <returns></returns>
        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {

            var employees = _employeeBussiness.Get();
            if (employees.Count() > 0)
            {
                return Ok(employees);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<EmployeesController>/5
        [Route("{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var employee = _employeeBussiness.GetById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Tạo mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var result = _employeeBussiness.Insert(employee);
            if (result == 1)
            {
                return CreatedAtAction("POST", result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Employee employee)
        {
            var result = _employeeBussiness.Update(id,employee);
            if (result == 1)
            {
                return CreatedAtAction("PUT", result);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Xoá thông tin nhân viên theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {         
            var result = _employeeBussiness.Delete(id);
            if (result == 1)
            {
                return CreatedAtAction("DELETE", result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
