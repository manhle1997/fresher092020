using MISA.DataAccess.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.DataAccess.DatabaseAccess
{
    public class DatabaseContext<T>: IDisposable, IDatabaseContext<T>
    {
        readonly string _connectionString = "Server=35.194.166.58;Port=3306;Database=MISACukCuk_F09_LQMANH;Uid=nvmanh;Pwd=12345678@Abc;";
        MySqlConnection _mySqlConnection;
        MySqlCommand _mySqlCommand;

        public DatabaseContext()
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
        /// Author: Lê Mạnh (20/10/2020)
        public IEnumerable<T> Get()
        {
            var employees = new List<T>();
            var className = typeof(T).Name;
            //Kiểu khai báo truy vấn
            _mySqlCommand.CommandText = $"Proc_Get{className}s";
            //Thực thi công việc với Database
            MySqlDataReader mySqlDataReader = _mySqlCommand.ExecuteReader();
            //Xử lý dữ liệu trả về
            while (mySqlDataReader.Read())
            {
                var employee = Activator.CreateInstance<T>();
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
        /// Lấy dữ liệu nhân viên theo storeName
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public IEnumerable<T> Get(string storeName)
        {
            var entities = new List<T>();
            _mySqlCommand.CommandText = storeName;
            // Thực hiện đọc dữ liệu:
            MySqlDataReader mySqlDataReader = _mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                var entity = Activator.CreateInstance<T>();
                //employee.EmployeeId = mySqlDataReader.GetGuid(0);
                //employee.EmployeeCode = mySqlDataReader.GetString(1);
                //employee.FullName = mySqlDataReader.GetString(2);

                for (int i = 0; i < mySqlDataReader.FieldCount; i++)
                {
                    var columnName = mySqlDataReader.GetName(i);
                    var value = mySqlDataReader.GetValue(i);
                    var propertyInfo = entity.GetType().GetProperty(columnName);
                    if (propertyInfo != null && value != DBNull.Value)
                        propertyInfo.SetValue(entity, value);
                }
                entities.Add(entity);
            }
            // 1. Kết nối với Database:
            // 2. Thực thi command lấy dữ liệu:
            // Trả về:
            return entities;

        }

        /// <summary>
        /// Lấy thông tin nhân viên theo mã nhân viên.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public T GetById(object id)
        {
            var employees = new List<T>();
            var className = typeof(T).Name;
            _mySqlCommand.CommandText = $"Proc_Get{className}ById";
            _mySqlCommand.Parameters.AddWithValue("@EmployeeId", id);
            MySqlDataReader mySqlDataReader = _mySqlCommand.ExecuteReader();
            //Xử lý dữ liệu trả về
            while (mySqlDataReader.Read())
            {
                var employee = Activator.CreateInstance<T>();
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
            return default;
        }

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public int Insert(T entity)
        {
            var entityName = typeof(T).Name;
            _mySqlCommand.Parameters.Clear();
            _mySqlCommand.CommandText = $"Proc_Insert{entityName}";
            MySqlCommandBuilder.DeriveParameters(_mySqlCommand);
            var parameters = _mySqlCommand.Parameters;
            var properties = typeof(T).GetProperties();

            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);
                var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    param.Value = property.GetValue(entity);
            }

            //Thực thi công việc
            var result = _mySqlCommand.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Chỉnh sửa thông tin bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int Update(Guid id,T employee)
        {
            // lấy dữ liệu từ database;
            // khởi tạo thông tin kết nối
            //var customers = new List<Customer>();
            var entityName = typeof(T).Name;
            //_sqlCommand.Parameters.Clear();
            _mySqlCommand.CommandText = $"Proc_Update{entityName}";
            _mySqlCommand.Parameters.AddWithValue($"@{entityName}Id", id);
            MySqlCommandBuilder.DeriveParameters(_mySqlCommand);
            var parameters = _mySqlCommand.Parameters;
            var properties = typeof(T).GetProperties();
            foreach (MySqlParameter param in parameters)
            {
                var paramName = param.ParameterName.Replace("@", string.Empty);
                var property = employee.GetType().GetProperty(paramName);
                //var property = entity.GetType().GetProperty(paramName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (paramName == $"{entityName}Id")
                    param.Value = id;
                else if (property != null)
                    param.Value = property.GetValue(employee);
            }
            var affectRows = _mySqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        /// <summary>
        /// Xoá bản ghi được chọn
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public int Delete(object id)
        {
            var entityName = typeof(T).Name;
            _mySqlCommand.Parameters.Clear();
            _mySqlCommand.CommandText = $"Proc_Delete{entityName}ById";
            //_sqlCommand.Parameters.AddWithValue($"@{entityName}Id", id);
            MySqlCommandBuilder.DeriveParameters(_mySqlCommand);
            if (_mySqlCommand.Parameters.Count > 0)
            {
                _mySqlCommand.Parameters[0].Value = id;
            }
            var affectRows = _mySqlCommand.ExecuteNonQuery();
            return affectRows;
        }

        /// <summary>
        /// Hàm huỷ
        /// </summary>
        public void Dispose()
        {
            //đóng kết nối database
            _mySqlConnection.Close();
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public object Get(string storeName, string code)
        {
            throw new NotImplementedException();
        }



    }
}
