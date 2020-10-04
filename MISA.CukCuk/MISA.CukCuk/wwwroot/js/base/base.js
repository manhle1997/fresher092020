$(document).ready(function () {
    //load dữ liệu

})


class BaseJS {

    constructor() {
        this.getData();
        this.loadData();
        this.initEvents();
    }

    /**
     * Hàm tạo sự kiện cho button
     * */
    initEvents() {
        $("#toolbar-item-add").click(function () {
            $(".form-dialog input").val('');
            $(".form-dialog input").removeClass('not-required')
            $(".form-dialog").show();
        });

        $('#btn_save').click(this.btnSaveOnClick.bind(this))
        $(".btn-close, #btn_close").click(function () {
            $(".form-dialog").hide();
        });
        $('#tbCustomer tbody').on('click', 'tr', this, this.rowOnClick);

        $('#toolbar-item-reload').click(this.btnReloadDataOnClick.bind(this));
        $('input[required]').blur(this.validateRequired);
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
                isValid = false;
            }
        })

        
        //Nếu valid thì gán cho 1 object
        if (isValid) {
            // Lấy ra các input có các trường là fieldName
            var inputs = $('input[fieldName]');
            //build object dữ liệu
            var customer = {};
            $.each(inputs, function (index, input) {
                var fieldName = $(input).attr('fieldName');
                var value = $(input).val();
                customer[fieldName] = value;         
            });
            data.push(customer);
            debugger;
            self.Data = data;
            //Load lại data         
            self.loadData();
            $(".form-dialog").hide();
            return;
        }
        //gọi sẻvice thực hiện lư dữ liệu
    }


    /**
     * Load dữ liệu 
     * Author: Lê Mạnh
     * */
    loadData() {

        try {
            $("#tbCustomer tbody").empty();
            var data2 = this.Data;
            var self = this;
            var fields = $('#tbCustomer thead .thead td')
            $.each(data2, function (index, obj) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var fieldNumber = $(field).attr('fieldNumber');

                    var value = obj[fieldName];
                    if (fieldNumber == 'DebitMoney' || fieldNumber == 'Salary') {
                        var td = $(`<td title="` + value + `" style="text-align: right;">` + commonJS.formatMoney(value) + `</td>`);
                    } else if (fieldNumber == 'DateOfBirth') {
                        var td = $(`<td title="` + value + `">` + commonJS.formatDate(value) + `</td>`);
                    } else {
                        var td = $(`<td title="` + value + `">` + value + `</td>`);
                    }

                    $(tr).append(td);


                })

                $("#tbCustomer tbody").append(tr);
            })
        } catch (e) {

        }
    }

    /**
     * Hàm lấy dữ liệu
     * Author: Lê Mạnh
     * */
    getData() {
        this.Data = [];
    }

    btnReloadDataOnClick() {
        this.loadData();
    }

    /**
     * Đổi màu hàng được chọn
     * Author: Lê Mạnh
     * */
    rowOnClick() {
        $(this).siblings().removeClass('row-selected')
        $(this).addClass('row-selected');
    }
}

