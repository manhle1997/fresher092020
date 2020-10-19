using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Department
    {
        //Id Phòng ban
        public Guid DepartmentId { get; set; }
        //Mã phòng ban
        public string DepartmentCode { get; set; }
        //Tên phòng ban
        public string DepartmentName { get; set; }

    }
}
