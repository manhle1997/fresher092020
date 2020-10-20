using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class EmployeeService :BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool CheckEmployeeByCode(string employeeCode)
        {
            return _employeeRepository.CheckEmployeeByCode(employeeCode);
        }
    }
}
