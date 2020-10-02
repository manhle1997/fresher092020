﻿
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

        this.removeData();
    }
    getData() {
        this.Data = data;

    }
    initEvents() {
        super.initEvents();
        $('[required]').blur(this.validateRequired);
        $('#btn_save').click(this.btnSaveOnClick.bind(this))

    }

    /**
     * Thực hiên lưu dữ liệu
     * Author: Lê Mạnh
     * */
    btnSaveOnClick() {
        self = this;
        //Validate dữ liệu
        //Check bắt buộc nhập
        var isValid = true;
        var inputRequireds = $('input[required]');
        $.each(inputRequireds, function (index, input) {
            
            if (!validData.validateRequired(input)) {
                isValid = false
            }
            
        })
        
        //build object dữ liệu
        //Nếu valid thì gán cho 1 object
        if (isValid) {
            var inputs = $('input[fieldName]')
            $.each(inputs, function (index.input) {
                var fieldName
            });


            var customer = {
                CustomerCode: $('#customer-code').val().trim(),
                CustomerName: $('#customer-name').val().trim(),
                CustomerCompany: $('#customer-company').val().trim(),
                TaxCode: $('#customer-taxcode').val().trim(),
                Address: $('#customer-address').val().trim(),
                PhoneNumber: $('#customer-phonenumber').val().trim(),
                Email: $('#customer-email').val().trim(),
                DebitMoney: $('#customer-debitmoney').val().trim()

            }
            data.push(customer);
            self.Data = data;
            debugger
        //Load lại data
            
            self.loadData();
            $(".form-dialog").hide();
            return;
        }


        

        //gọi sẻvice thực hiện lư dữ liệu
    }

    //#region Validate
    /**
     * Validate bắt buộc nhập
     * Author: lê Mạnh
     * */
    validateRequired(sender) {
        //lấy dữ liệu đã nhập\

        validData.validateRequired(sender.currentTarget);

        //nếu chưa nhập thì set border màudor
    }
    //#endregion



    /**
     * Hàm thêm mới dữ liệu 
     * Author: Lê Mạnh
     * */
    //addData() {
    //    try {
    //        $('#btn_save').click(function () {
    //            //Lấy dữ liệu nhập từ input
    //            var CustomerCode = $('#customer-code').val();
    //            var CustomerName = $('#customer-name').val();
    //            var CustomerCompany = $('#customer-company').val();
    //            var CustomerTaxCode = $('#customer-taxcode').val();
    //            var CustomerAddress = $('#customer-address').val();
    //            var CustomerPhonenumber = $('#customer-phonenumber').val();
    //            var CustomerEmail = $('#customer-email').val();

    //            //tạo đối tượng và lưu thông tin vào mảng data
    //            var customer = {
    //                CustomerCode: CustomerCode,
    //                CustomerName: CustomerName,
    //                CustomerCompany: CustomerCompany,
    //                TaxCode: CustomerTaxCode,
    //                Address: CustomerAddress,
    //                PhoneNumber: CustomerPhonenumber,
    //                Email: CustomerEmail,
    //                Salary: 20000000
    //            }

    //            //Thêm object customer vào Data
    //            data.push(customer);

    //            //Hàm xử lý append thêm tr vào bảng
    //            //var tr = $(`<tr></tr>`);
    //            //$.each(customer, function (index, value) {
    //            //    if (index == 'Salary') {
    //            //        var td = $(`<td title="` + value + `" style="text-align: right">` + commonJS.formatMoney(value) + `</td>`);
    //            //    } else {
    //            //        var td = $(`<td title="` + value + `">` + value + `</td>`);
    //            //    }           
    //            //    $(tr).append(td);
    //            //});
    //            //$("#tbCustomer tbody").append(tr);

    //            //thông báo
    //            alert("Lưu thông tin thành công");
    //            this.loadData();
    //            $(".form-dialog").hide();

    //        }.bind(this));
    //    } catch (e) {
    //        alert("Lưu thông tin không thành công");
    //    }

    //}



    /**
     * Hàm xóa dữ liệu 
     * Author: Lê Mạnh
     * */   
    //TODO: xoa du lieu đang làm dở
    removeData() {
        self = this;

        try {
            $('tbody tr').click(function () {

                var temp = this;
                debugger;
                $('.toolbar-item-icon-delete').click(function () {
                    debugger;
                    alert('Xóa thành công');
                    var customer = {
                        CustomerCode: temp.valueOf(0).children[0].textContent,
                        CustomerName: temp.valueOf(0).children[1].textContent,
                        CustomerCompany: temp.valueOf(0).children[2].textContent,
                        TaxCode: temp.valueOf(0).children[3].textContent,
                        Address: temp.valueOf(0).children[4].textContent,
                        PhoneNumber: temp.valueOf(0).children[5].textContent,
                        Email: temp.valueOf(0).children[6].textContent,
                        Salary: 20000000
                    }
                    var i;
                    for (i = 0; i < data.length; i++) {
                        if (data[i].CustomerCode == customer.CustomerCode) {
                            data.splice(i, 1);
                        };

                    }
                    self.loadData();


                });
                temp = t;
                //this.valueOf(0).children[0].textContent


            });
        } catch (e) {
            alert("Xóa thông tin không thành công");
        }



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
        DebitMoney: 20000000

    },
    {
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