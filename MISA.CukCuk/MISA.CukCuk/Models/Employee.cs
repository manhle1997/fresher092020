using System;


namespace MISA.CukCuk.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; } = new Guid();
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public Gender Gender { get; set; }
        public string PositionName { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        


    }
}
