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

        public bool CheckEmployeeByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        
    }
}
