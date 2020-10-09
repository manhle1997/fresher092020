﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Models;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //Lấy danh sách toàn bộ nhân viên
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var employees = new List<Employee>();
                string connectionString = "Server=35.194.166.58;Port=3306;Database=MISACukCuk_F09_LQMANH;Uid=nvmanh;Pwd=12345678@Abc;";
                //Khởi tạo đối tượng mysql connection kết nối cơ sở dữ liệu
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                //Khởi tạo đối tượng sql command cho phép thao tác với dữ liệu
                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                //kiểu tương tác với procedure
                mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //Kiểu khai báo truy vấn
                mySqlCommand.CommandText = "PROC_GetEmployees";
                //Mở kết nối Database
                mySqlConnection.Open();
                //Thực thi công việc với Database
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                //Xử lý dữ liệu trả về
                while (mySqlDataReader.Read())
                {
                    var employee = new Employee();
                    for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                    {
                        var colName = mySqlDataReader.GetName(i);
                        var value = mySqlDataReader.GetValue(i);
                        var property = employee.GetType().GetProperty(colName);
                        if (property != null && value != DBNull.Value)
                        {
                            property.SetValue(employee, value);
                        }
                    }
                    // Thêm đôi tượng khách hàng vừa build được vào list:
                    employees.Add(employee);
                }
                // đóng kết nối
                mySqlConnection.Close();
                return employees;
            }
            catch (Exception )
            {

                throw;
            }
            
        }

        // GET api/<EmployeesController>/5
        [Route("{id}")]
        [HttpGet("{id}")]
        public IEnumerable<Employee> Get(Guid id)
        {
            var employees = new List<Employee>();
            string connectionString = "Server=35.194.166.58;Port=3306;Database=MISACukCuk_F09_LQMANH;Uid=nvmanh;Pwd=12345678@Abc;";
            //Khởi tạo đối tượng mysql connection kết nối cơ sở dữ liệu
            MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
            MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            mySqlCommand.CommandText = "PROC_GetEmployeeById";
            mySqlCommand.Parameters.AddWithValue("EmployeeId", id);
            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            //Xử lý dữ liệu trả về
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var colName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var property = employee.GetType().GetProperty(colName);
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(employee, value);
                    }
                }
                // Thêm đôi tượng khách hàng vừa build được vào list:
                employees.Add(employee);
            }
            // đóng kết nối
            mySqlConnection.Close();
            return employees;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public bool Post([FromBody] Employee value)
        {
            var employees = new List<Employee>();
            return true;
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}