using MISA.Common.Models;
using MISA.DataAccess.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataAccess.Repository
{
    public class EmployeeRepository :BaseRepository<Employee> ,IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseContext<Employee> databaseContext) : base(databaseContext)
        {
        }

        /// <summary>
        /// Check employee by Code
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns></returns>
        /// Author: Lê Mạnh (20/10/200)
        public bool CheckEmployeeByCode(string employeeCode)
        {
            var objectValue = _databaseContext.Get("Proc_GetEmployeeByCode", employeeCode);
            if (objectValue == null)
                return false;
            else
                return true;
        }

        
    }
}
