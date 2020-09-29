$(document).ready(function () {
    //load dữ liệu
    try {
        var baseJS = new BaseJS();
    } catch (e) {
        console.log('fail from base.js');
    }
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
            $(".form-dialog").show();
        });
        $(".btn-close, #btn_close").click(function () {
            $(".form-dialog").hide();
        });
        $('#tbCustomer tbody').on('click', 'tr', this, this.rowOnClick);

        $('#toolbar-item-reload').click(this.btnReloadDataOnClick.bind(this));



    }


    /**
     * Load dữ liệu 
     * Author: Lê Mạnh
     * */
    loadData() {
        try {
            var data = this.Data;
            var self = this;
            var fields = $('#tbCustomer thead .thead td')
            $.each(data, function (index, obj) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var fieldNumber = $(field).attr('fieldNumber');
                    var value = obj[fieldName];
                    if (fieldNumber == 'Salary') {
                        var td = $(`<td style="text-align: right;">` + commonJS.formatMoney(value) + `</td>`);
                    } else if (fieldNumber == 'DateOfBirth') {
                        var td = $(`<td>` + commonJS.formatDate(value) + `</td>`);
                    } else {
                        var td = $(`<td title="`+value+`">` + value + `</td>`);
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

