
$(document).ready(function () {
    //load dữ liệu
    var customerJS = new CustomerJS();
})

/**
 * class quản lí các function cho trang customer
 * */
class CustomerJS extends BaseJS {
    constructor(url) {
        super(url);
    }
    getData() {
        this.Data = data;

    }
    initEvents() {
        super.initEvents();
    }
    addData() {
        $('#btn_save').click(function () {
            //Lấy dữ liệu nhập từ input
            var customerCode = $('#customer-code').val();
            var customerName = $('#customer-name').val();
            var customerCompany = $('#customer-company').val();
            var customerTaxCode = $('#customer-taxcode').val();
            var customerAddress = $('#customer-address').val();
            var customerPhonenumber = $('#customer-phonenumber').val();
            var customerEmail = $('#customer-email').val();

            //tạo đối tượng và lưu thông tin vào mảng data
            var customer = {
                CustomerCode: customerCode,
                CustomerName: customerName,
                CustomerCompany: customerCompany,
                TaxCode: customerTaxCode,
                Address: customerAddress,
                PhoneNumber: customerPhonenumber,
                Email: customerEmail,
                Salary: 20000000
            }

            data.push(customer);
            
            //thông báo
            alert("Lưu thông tin thành công");
            this.getData();
            this.loadData();
        }.bind(this));
    }

}
/**
 *Data customer 
 * */
var data = [
    {
        CustomerId: 1,
        CustomerCode: "KH0001",
        CustomerName: "Lê Quốc Mạnh",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        DebitMoney: 20000000

    },
    {
        CustomerId: 2,
        CustomerCode: "KH0002",
        CustomerName: "Lê Quốc Cường",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        DebitMoney: 20000000

    },
    {
        CustomerId: 3,
        CustomerCode: "KH0003",
        CustomerName: "Lê Quốc Hùng",
        CustomerCompany: "Đại Học Bách Khoa",
        TaxCode: "1111",
        Address: "157B, đường Chùa Láng, Hà Nội",
        PhoneNumber: "0854681997",
        Email: "lqmanhddt@gmail.com",
        DebitMoney: 20000000

    }
];