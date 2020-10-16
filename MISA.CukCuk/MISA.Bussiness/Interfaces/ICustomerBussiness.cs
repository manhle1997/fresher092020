using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    /// <summary>
    /// Interface Thêm sửa xoá danh sách khách hàng
    /// </summary>
    /// Author: Lê Mạnh
    interface ICustomerBussiness
    {
        IEnumerable<Customer> GetEmployees();
        Customer GetEmployeeById(Guid id);
        bool Insert(Customer employee);
        public bool Update(Guid id, Customer employee);
        public bool Delete(Guid id);
    }
}
