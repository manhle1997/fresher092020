using MISA.Bussiness.Interfaces;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int Delete(Guid Id)
        {
            return _baseRepository.Delete(Id);
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid employeeId)
        {
            return _baseRepository.GetById(employeeId);
        }

        public int Insert(T employee)
        {
            return _baseRepository.Insert(employee);
        }

        public int Update(Guid id,T employee)
        {
            return _baseRepository.Update(id,employee);
        }
    }
}
