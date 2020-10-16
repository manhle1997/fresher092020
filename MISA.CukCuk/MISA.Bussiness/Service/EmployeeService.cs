using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService : IEmployeeBussiness
    {
        IEmployeeRepository _databaseAccess;
        public EmployeeService(IEmployeeRepository databaseAccess)
        {
            _databaseAccess = databaseAccess;
        } 
        public bool Delete(Guid id)
        {
            return _databaseAccess.Delete(id);
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _databaseAccess.GetEmployeeById(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _databaseAccess.GetEmployees();
        }

        public bool Insert(Employee employee)
        {
            return _databaseAccess.Insert(employee);
        }

        public bool Update(Guid id, Employee employee)
        {
            return _databaseAccess.Update(id, employee);
        }
    }
}
