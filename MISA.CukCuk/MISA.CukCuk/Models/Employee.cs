using System;


namespace MISA.CukCuk.Models
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
        // Id Vị trí làm việc
        public Guid PositionId { get; set; }
        // Thu nhập
        public double Salary { get; set; }
        // Số điện thoại
        public string PhoneNumber { get; set; }
        // Ngày sinh
        public DateTime DateOfBirth { get; set; }
        // Id phòng ban
        public Guid DepartmentId { get; set; }
        // Mã số thuế nhân viên
        public string TaxCode { get; set; }
        // Email nhân viên
        public string Email { get; set; }
        // Địa chỉ nhân viên
        public string Address { get; set; }
        // Trạng thái làm việc
        public int WorkStatus { get; set; }




    }
}
