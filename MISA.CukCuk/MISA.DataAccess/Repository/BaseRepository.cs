using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        protected IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        /// Xoá bản ghi theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public int Delete(Guid id)
        {
            return _databaseContext.Delete(id);
        }

        /// <summary>
        /// Lấy thông tin toàn bộ bản ghi
        /// </summary>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        /// <summary>
        /// Lấy thông tin bản ghi theo Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public T GetById(Guid employeeId)
        {
            return _databaseContext.GetById(employeeId);
        }

        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public int Insert(T employee)
        {
            return _databaseContext.Insert(employee);
        }

        /// <summary>
        /// Chính sửa thông tin bản ghi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/2020)
        public int Update(Guid id,T employee)
        {
            return _databaseContext.Update(id, employee);
        }
    }
}
