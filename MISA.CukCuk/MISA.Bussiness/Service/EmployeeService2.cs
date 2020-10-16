using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISA.Bussiness.Service
{
    class EmployeeService2 : IEmployeeBussiness
    {
        IDatabaseAccess _databaseAccess;
        public EmployeeService2(IDatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employee = _databaseAccess.GetEmployees();
            var employeeToxics = employee.Where(e => e.Gender == Gender.Male).ToList();
            return employeeToxics;

        }

        public bool Insert(Employee employee)
        {
            //Check trùng mã
            throw new NotImplementedException();
        }

        public bool Update(Guid id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
