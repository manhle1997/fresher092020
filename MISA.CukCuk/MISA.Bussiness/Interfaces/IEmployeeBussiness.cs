using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    /// <summary>
    /// Lấy danh sách nhân viên
    /// </summary>
    /// Author: Mạnh Lê
    public interface IEmployeeBussiness
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        bool Insert(Employee employee);
        public bool Update(Guid id, Employee employee);
        public bool Delete(Guid id);
    }
}
