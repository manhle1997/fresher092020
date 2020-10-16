using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{

    public interface IEmployeeBussiness
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployees();

        /// <summary>
        /// Lấy danh sách nhân viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeById(Guid id);

        /// <summary>
        /// Thêm nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool Insert(Employee employee);

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(Guid id, Employee employee);

        /// <summary>
        /// Xóa thông tin nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id);
    }
}
