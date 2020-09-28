
$(document).ready(function () {
    //load dữ liệu
    try {
        var baseJS = new BaseJS();
    } catch (e) {
        console.log('fail from base.js');
    }
})

/**
 * class quản lí các function cho trang customer
 * */

class BaseJS {

    constructor() {
        debugger;
        this.getData();
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
            var data = this.Data;
            var self = this;
            $.each(data, function (index, obj) {
                var trHTML = self.makeTrHTML(obj);

                $("#tbCustomer tbody").append(trHTML);
            })
        }
        catch (e) {
            console.log('error from load data');
        }
    }

    /**
     * hàm lấy dữ liệu
     * */
    getData() {
        this.Data = [];
    }


    /**
     * Build Html for Tr
     * */
    makeTrHTML(obj) {

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
        customerCode: "KH000003",
        customerName: "Lê Quốc Mạnh",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com"
    },
    {
        customerCode: "KH000003",
        customerName: "Lê Quốc Cường",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com"
    },
    {
        customerCode: "KH000003",
        customerName: "Lê Quốc Hùng",
        customerCompany: "Đại Học Bách Khoa",
        taxCode: "1111",
        address: "157B, đường Chùa Láng, Hà Nội",
        phoneNumber: "0854681997",
        email: "lqmanhddt@gmail.com"

    }
];