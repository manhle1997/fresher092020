
$(document).ready(function () {
    //load dữ liệu
    var employeeJS = new EmployeeJS();
})

/**
 * class quản lí các function cho trang customer
 * */

class EmployeeJS extends BaseJS {
    constructor() {
        super();
    }
    getData() {
        this.Data = data;
    }
    makeTrHTML(employee) {
        var TrHTML = $(`<tr>
                                    <td>`+ employee["EmployeeCode"] + `</td>
                                    <td>`+ employee["FullName"] + `</td>
                                    <td>`+ employee["Gender"] + `</td>
                                    <td>`+ employee["DateOfBirth"] + `</td>
                                    <td>`+ employee["Mobile"] + `</td>
                                    <td>`+ employee["PositionName"] + `</td>
                                    <td>`+ employee["DepartmenName"] + `</td>
                                    <td>`+ employee["Email"] + `</td>
                                    <td style="text-align: right;">`+ employee["Salary"].toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + `</td>
                                    <td>`+ employee["WorkStatus"] + `</td>
                                </tr>`);
        return TrHTML;
    }


}

var data = [];
for (var i = 0; i < 8; i++) {
    var employee = {
        EmployeeCode: "KH000" + (i + 1),
        FullName: "Lê Quốc Manh" + i + 1,
        Gender: "Nam",
        DateOfBirth: new Date('1997-06-11'),
        Mobile: "0854681997",
        PositionName: "Giám đốc",
        DepartmenName: "Phòng đào tạo",
        Email: "lqmanhddt@gmail.com",
        Salary: 10000000,
        WorkStatus: "Đang làm việc"
    };
    data.push(employee);
}