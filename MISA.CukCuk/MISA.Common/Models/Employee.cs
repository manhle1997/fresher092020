using System;


namespace MISA.Common.Models
{
    public class Employee
    {
        // Id nhân viên
        public Guid EmployeeId { get; set; }
        // Mã nhân viên
        public string EmployeeCode { get; set; }
        // Tên nhân viên
        public string EmployeeName { get; set; }
        // Giới tính nhân viên
        public Gender Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Gender.Female:
                        return "Nữ";
                    case Gender.Male:
                        return "Nam";
                    default:
                        return "Giới tính khác";
                }
            }
        }
        // Id Vị trí làm việc
        public Guid PositionId { get; set; }
        //Tên vị trí làm việc
        public string PositionName { get; set; }
        // Thu nhập
        public double Salary { get; set; }
        // Số điện thoại
        public string PhoneNumber { get; set; }
        // Ngày sinh
        public DateTime? DateOfBirth { get; set; }
        // Id phòng ban
        public Guid DepartmentId { get; set; }
        // Tên phòng ban làm việc
        public string DepartmentName { get; set; }
        // Mã số thuế nhân viên
        public string TaxCode { get; set; }
        // Email nhân viên
        public string Email { get; set; }
        // Trạng thái làm việc
        public WorkStatus WorkStatus { get; set; }

        public string WorkStatusName
        {
            get
            {
                switch (WorkStatus)
                {
                    case WorkStatus.Stop:
                        return "Đã nghỉ việc";
                    case WorkStatus.Trial:
                        return "Đang thử việc";
                    case WorkStatus.Working:
                        return "Đang làm việc";
                    default:
                        return "Đã nghỉ hưu";
                }
            }
        }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string IdentityPlace { get; set; }
        public DateTime? JoinDate { get; set; }

    }
}
