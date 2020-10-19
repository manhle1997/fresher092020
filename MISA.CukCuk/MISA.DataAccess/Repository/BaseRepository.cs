using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        IDatabaseContext<T> _databaseContext;
        public BaseRepository(IDatabaseContext<T> databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public int Delete(Guid id)
        {
            return _databaseContext.Delete(id);
        }

        public IEnumerable<T> Get()
        {
            return _databaseContext.Get();
        }

        public T GetById(Guid employeeId)
        {
            return _databaseContext.GetById(employeeId);
        }

        public int Insert(T employee)
        {
            return _databaseContext.Insert(employee);
        }

        public int Update(T employee)
        {
            return _databaseContext.Update(employee);
        }
    }
}
