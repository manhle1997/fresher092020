using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DataAccess.Interfaces
{
    public interface IEmployeeRepository: IDatabaseAccess
    {
        /// <summary>
        /// Kiểm tra thông tin nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true: có, false:Không</returns>
        bool CheckEmployeeByCode(string employeeCode);
    }
}
