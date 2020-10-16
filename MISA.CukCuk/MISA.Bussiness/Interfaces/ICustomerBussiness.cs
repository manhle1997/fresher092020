using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Interfaces
{
    public interface ICustomerBussiness
    {
        /// <summary>
        /// Lấy danh sách khách hàng 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetCustomer();

        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Customer GetCustomerById(Guid id);

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool Insert(Customer employee);

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool Update(Guid id, Customer employee);

        /// <summary>
        /// Xóa thông tin khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id);
    }
}
