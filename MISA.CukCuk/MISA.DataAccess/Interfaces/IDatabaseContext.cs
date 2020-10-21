using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IDatabaseContext<T>
    {
        /// <summary>
        /// Get dữ liệu từ Database
        /// </summary>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        IEnumerable<T> Get();

        /// <summary>
        /// Get dữ liệu từ Database theo store name
        /// </summary>
        /// <param name="storeName"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        IEnumerable<T> Get(string storeName);

        /// <summary>
        /// Get dữ liệu từ Database theo store name, code
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        object Get(string storeName, string code);

        /// <summary>
        /// Get dữ liệu từ Database theo Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        T GetById(object employeeId);
        /// <summary>
        /// Thêm mới dữ liệu vào Database
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        int Insert(T employee);

        /// <summary>
        /// Cập nhật dữ liệu trên Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        int Update(Guid id,T employee);

        /// <summary>
        /// Xoá dữ liệu trên Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (15/10/2020)
        int Delete(object id);
    }
}
