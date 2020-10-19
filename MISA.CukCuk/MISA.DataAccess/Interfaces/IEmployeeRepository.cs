using MISA.Common.Models;
using System;
using System.Collections.Generic;

namespace MISA.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
       
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã nhân viên 
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true: có, false:Không</returns>
        /// Created By: Lê Mạnh
        bool CheckEmployeeByCode(string employeeCode);
    }
}
