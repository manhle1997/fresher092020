using MISA.Bussiness.Interfaces;
using MISA.Common.Models;
using MISA.DataAccess;
using MISA.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Bussiness.Service
{
    public class DepartmentService :BaseService<Department>, IDepartmentBussiness
    {
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
    }
}
