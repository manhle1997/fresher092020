
$(document).ready(function () {
    //load dữ liệu
    var customerJS = new CustomerJS();
})

/**
 * class quản lí các function cho trang customer
 * */

class CustomerJS extends BaseJS {
    constructor() {
        super();
    }
    getData() {
        this.Data = data;
    }
    makeTrHTML(customer) {
        var TrHTML = $(`<tr>
                                    <td>`+ customer["customerCode"] + `</td>
                                    <td>`+ customer["customerName"] + `</td>
                                    <td>`+ customer["customerCompany"] + `</td>
                                    <td>`+ customer["taxCode"] + `</td>
                                    <td>`+ customer["address"] + `</td>
                                    <td>`+ customer["phoneNumber"] + `</td>
                                    <td>`+ customer["email"] + `</td>
                                    <td>`+ customer["salary"] + `</td>
                                </tr>`);
        return TrHTML;
    }


}

var data = [
    {
        customerCode: "KH000003",
        customerName: "Lê Quốc Mạnh",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com",
        salary: 20000000

    },
    {
        customerCode: "KH000003",
        customerName: "Lê Quốc Cường",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com",
        salary: 20000000

    },
    {
        customerCode: "KH000003",
        customerName: "Lê Quốc Hùng",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com",
        salary: 20000000

    }
];