
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

}


/**
 *Data customer 
 * */
var data = [
    {
        CustomerCode: "KH0001",
        CustomerName: "Lê Quốc Mạnh",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        Salary: 20000000

    },
    {
        CustomerCode: "KH0002",
        CustomerName: "Lê Quốc Cường",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        Salary: 20000000

    },
    {
        CustomerCode: "KH0003",
        CustomerName: "Lê Quốc Hùng",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        Salary: 20000000

    }
];