
$(document).ready(function () {
    //load dữ liệu
    var employeeJS = new EmployeeJS("/api/employees");
})

/**
 * class quản lí các function cho trang employee
 * */
class EmployeeJS extends BaseJS {
    constructor(url) {
        super(url);
    }
    getData() {
        this.Data = data;
    }
    initEvents() {
        super.initEvents();
    }

}

var data = [];
for (var i = 0; i < 5; i++) {

    var employee = {
        EmployeeId: (i+1),
        EmployeeCode: "KH000" + (i + 1),
        EmployeeName: "Lê Quốc Mạnh" + (i + 1),
        Gender: "Nam",
        DateOfBirth: new Date("11/06/1997"),
        PhoneNumber: "0854681997",
        PositionName: "Giám đốc",
        DepartmentName: "Phòng đào tạo",
        Email: "lqmanhddt@gmail.com",
        Salary: 10000000,
        WorkStatus: "Đang làm việc"
    };
    data.push(employee);
}