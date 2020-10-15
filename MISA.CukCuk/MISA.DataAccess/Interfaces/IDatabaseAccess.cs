﻿using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess
{
    public interface IDatabaseAccess
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        bool Insert(Employee employee);
        public bool Update(Guid id, Employee employee);
        public bool Delete(Guid id);
    }
}
