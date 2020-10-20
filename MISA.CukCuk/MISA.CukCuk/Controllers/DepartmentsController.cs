using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        IDepartmentService _departmentBussiness;
        public DepartmentsController(IDepartmentService departmentBussiness)
        {
            _departmentBussiness = departmentBussiness;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IActionResult Get()
        {

            var departments = _departmentBussiness.Get();
            if (departments.Count() > 0)
            {
                return Ok(departments);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
