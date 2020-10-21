using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Bussiness.Interfaces;
using MISA.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        IPositionService _positionService;
        public PositionsController(IPositionService positionService)
        {
            _positionService = positionService;
        }
        /// <summary>
        /// Lấy thông tin Vị trí
        /// </summary>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        // GET: api/<PositionsController>
        [HttpGet]
        public IActionResult Get()
        {

            var positions = _positionService.Get();
            if (positions.Count() > 0)
            {
                return Ok(positions);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Lấy thông tin vị trí theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var position = _positionService.GetById(id);
            if (position != null)
            {
                return Ok(position);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Thêm mới vị trí
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        // POST api/<PositionsController>
        [HttpPost]
        public IActionResult Post([FromBody] Position position)
        {
            var result = _positionService.Insert(position);
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
        /// Cập nhật thông tin vị trí
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Position position)
        {
            var result = _positionService.Update(id, position);
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
        /// Xoá thông tin vị trí
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _positionService.Delete(id);
            if (result == 1)
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
