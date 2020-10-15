

using MISA.Common.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess
{
    public class DatabaseAccess : IDisposable, IDatabaseAccess
    {
        readonly string _connectionString = "Server=35.194.166.58;Port=3306;Database=MISACukCuk_F09_LQMANH;Uid=nvmanh;Pwd=12345678@Abc;";
        MySqlConnection _mySqlConnection;
        MySqlCommand _mySqlCommand;
        public DatabaseAccess()
        {
            //Khởi tạo đối tượng mysql connection kết nối cơ sở dữ liệu
            _mySqlConnection = new MySqlConnection(_connectionString);
            //Mở kết nối Database
            _mySqlConnection.Open();
            //Khởi tạo đối tượng sql command cho phép thao tác với dữ liệu
            _mySqlCommand = _mySqlConnection.CreateCommand();
            //kiểu tương tác với procedure
            _mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        }

        /// <summary>
        /// Lấy dữ liệu của nhân viên
        /// </summary>
        /// <returns>Employees</returns>
        /// Author: Mạnh Lê
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            //Kiểu khai báo truy vấn
            _mySqlCommand.CommandText = "Proc_GetEmployees";
            //Thực thi công việc với Database
            MySqlDataReader mySqlDataReader = _mySqlCommand.ExecuteReader();
            //Xử lý dữ liệu trả về
            while (mySqlDataReader.Read())
            {
                var employee = new Employee();
                //employee.EmployeeId = mySqlDataReader.GetGuid(0); //dữ liêu tự động chuển về Guid
                //employee.EmployeeCode = mySqlDataReader.GetString(1); // dữ liệu tự động chuyển về dạng string
                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var colName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var property = employee.GetType().GetProperty(colName); //Cú pháp lấy theo tên
                    if (property != null && value != DBNull.Value)
                    {
                        property.SetValue(employee, value);
                    }
                }

                // Thêm đôi tượng khách hàng vừa build được vào list:
                employees.Add(employee);
            }
            return employees;
        }

        /// <summary>
        /// Lấy thông tin nhân viên theo mã nhân viên.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(Guid id)
        {
            var employees = new List<Employee>();
            _mySqlCommand.CommandText = "Proc_GetEmployeeById";
            _mySqlCommand.Parameters.AddWithValue("EmployeeId", id);
            MySqlDataReader mySqlDataReader = _mySqlCommand.ExecuteReader();
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
                return employee;
            }
            return null;
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Insert(Employee employee)
        {
            _mySqlCommand.CommandText = "Proc_InsertEmployee";
            _mySqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _mySqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _mySqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _mySqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _mySqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _mySqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _mySqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            _mySqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _mySqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            _mySqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _mySqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            _mySqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);
            _mySqlCommand.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            _mySqlCommand.Parameters.AddWithValue("@CreatedBy", "ManhLe");
            _mySqlCommand.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
            _mySqlCommand.Parameters.AddWithValue("@ModifiedBy", "ManhLe");
            //Thực thi công việc
            _mySqlCommand.ExecuteNonQuery();
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        public bool Update(Guid id, Employee employee)
        {
            _mySqlCommand.CommandText = "Proc_UpdateEmployee";
            _mySqlCommand.Parameters.AddWithValue("@EmployeeId", id);
            _mySqlCommand.Parameters.AddWithValue("@EmployeeCode", employee.EmployeeCode);
            _mySqlCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
            _mySqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
            _mySqlCommand.Parameters.AddWithValue("@PositionId", employee.PositionId);
            _mySqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
            _mySqlCommand.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            _mySqlCommand.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
            _mySqlCommand.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
            _mySqlCommand.Parameters.AddWithValue("@TaxCode", employee.TaxCode);
            _mySqlCommand.Parameters.AddWithValue("@Email", employee.Email);
            _mySqlCommand.Parameters.AddWithValue("@Address", employee.Address);
            _mySqlCommand.Parameters.AddWithValue("@WorkStatus", employee.WorkStatus);
            //Thực thi công việc
            _mySqlCommand.ExecuteNonQuery();          
            return true;
        }

        public bool Delete(Guid id)
        {
            _mySqlCommand.CommandText = "Proc_DeleteEmployee";
            _mySqlCommand.Parameters.AddWithValue("@EmployeeId", id);
            _mySqlCommand.ExecuteNonQuery();
            
            return true;
        }

        public void Dispose()
        {
            _mySqlConnection.Close();
        }
    }
}
