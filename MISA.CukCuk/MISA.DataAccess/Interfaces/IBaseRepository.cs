using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <returns></returns>
        /// Author: Lê Mạnh (18/10/2020)
        IEnumerable<T> Get();

        /// <summary>
        /// Lấy danh sách bản ghi theo Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (18/10/2020)
        T GetById(Guid employeeId);

        /// <summary>
        /// Thêm thông tin bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (18/10/2020)
        int Insert(T employee);

        /// <summary>
        /// Cập nhật thông tin bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (18/10/2020)
        int Update(Guid id, T employee);

        /// <summary>
        /// Xoá thông tin bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (18/10/2020)
        int Delete(Guid id);
    }
}
