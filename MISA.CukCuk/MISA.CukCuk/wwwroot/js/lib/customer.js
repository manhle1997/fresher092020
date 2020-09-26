$(document).ready(function () {
    //load dữ liệu
    var customer = new CustomerJS; 
})

/**
 * class quản lí các function cho trang customer
 * */

class CustomerJS {
    constructor() {
        this.loadData();
        this.initEvents();
    }

    /**
     * Hàm tạo sự kiện 
     * */

    initEvents() {
        $("#toolbar-item-add").click(function () {
            $(".form-dialog").show();
        });
        $(".btn-close, #btn_close").click(function () {
            $(".form-dialog").hide();
        });
        $('#tbCustomer').on('click', 'tr', this, this.rowOnClick);

        $('#toolbar-item-reload').click(this.btnReloadDataOnClick.bind(this))
    }


    /**
     * Load dữ liệu 
     * */
    loadData() {
        //lấy dữ liệu về

    try {
        var customers = data;
        $.each(customers, function (index, customer) {
            var trHTML = $(`<tr>
                                    <td>`+ customer["customerCode"] + `</td>
                                    <td>`+ customer["customerName"] + `</td>
                                    <td>`+ customer["customerCompany"] + `</td>
                                    <td>`+ customer["taxCode"] + `</td>
                                    <td>`+ customer["address"] + `</td>
                                    <td>`+ customer["phoneNumber"] + `</td>
                                    <td>`+ customer["email"] + `</td>
                                </tr>`);

            $("#tbCustomer tbody").append(trHTML);
        })
    }
    catch (e) {
        console.log('error');
    }
    }

    //TODO: btn ReloadData
    btnReloadDataOnClick() {
        this.loadData();
    }

    //TODO: can sua
    rowOnClick() {
        $(this).siblings().removeClass('row-selected')
        $(this).addClass('row-selected');
    }

}


var data = [
    {
        customerCode : "KH000003",
        customerName : "Lê Quốc Mạnh",
        customerCompany : "Đại Học Bách Khoa",
        taxCode : "1111",
        address : "!57B, đường Chùa Láng, Hà Nội",
        phoneNumber : "0854681997",
        email : "lqmanhddt@gmail.com"
    },
    {
        customerCode : "KH000003",
        customerName : "Lê Quốc Cường",
        customerCompany : "Đại Học Bách Khoa",
        taxCode : "1111",
        address : "157B, đường Chùa Láng, Hà Nội",
        phoneNumber : "0854681997",
        email : "lqmanhddt@gmail.com"
    },
    {
        customerCode : "KH000003",
        customerName : "Lê Quốc Hùng",
        customerCompany : "Đại Học Bách Khoa",
        taxCode : "1111",
        address : "157B, đường Chùa Láng, Hà Nội",
        phoneNumber : "0854681997",
        email : "lqmanhddt@gmail.com"
    }
];