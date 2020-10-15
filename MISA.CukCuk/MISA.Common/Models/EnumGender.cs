using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    /**
     * Enum giới tính
     */
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Other = 2
    }

    /**
     * Enum Trạng thái làm việc
     */
    public enum WorkStatus
    {
        Stop = 0, // Đã nghỉ việc
        Trial = 1, // Đang thử việc
        Working = 2, // Đang làm việc
        Retire = 3 // Đã nghỉ hưu
    }
}
