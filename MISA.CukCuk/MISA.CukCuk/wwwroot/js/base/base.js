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
        var self = this;
        $("#toolbar-item-add").click(function () {
            self.FormMode = 'Add';
            $(".form-dialog input").val('');
            $(".form-dialog input").removeClass('not-required')
            $(".form-dialog").show();
        });
        $('#toolbar-item-edit').click(this.btnEditOnClick.bind(this));
        $('#toolbar-item-delete').click(this.btnDeleteOnClick.bind(this))
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
     * Hàm xóa dữ liệu được chọn
     * Author: Lê Mạnh
     * */
    btnDeleteOnClick() {
        self = this;
        //Lấy id của bản ghi được chọn
        var id = this.getRecordIdSelected();

        // Hiển thị thông báo xác nhận xóa
        var result = confirm("Bạn có muốn xóa khách hàng này");
        if (result) {
            var recordSelected = $('#tbCustomer tbody tr.row-selected');

            // Lấy dữ liệu chi tiết bản ghi đã chọn
            var id = recordSelected.data('keyId');
            var objectDetail = recordSelected.data('data');
            $.each(data, function (index, obj) {
                if (obj.CustomerId == objectDetail.CustomerId) {//nếu id của record được chọn trùng với id nào của data thì xoá object đó
                    data.splice(index, 1);
                }
                self.loadData();
            });

        }
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
            if (self.FormMode == 'Add') {
                alert('add');
                data.push(customer);
            }
            else {
                alert('edit');
            }

            self.Data = data;
            //Load lại data         
            self.loadData();
            $(".form-dialog").hide();
            return;
        }
        //gọi sẻvice thực hiện lư dữ liệu
    }

    /**
    * Hàm Edit thông tin
    * Author: Lê Mạnh
    */

    //TODO : đang làm dở edit infor
    btnEditOnClick() {
        self = this;

        this.FormMode = 'Edit';
        // Lấy thông tin bản ghi đã chọn trong danh sách
        var recordSelected = $('#tbCustomer tbody tr.row-selected');

        // Lấy dữ liệu chi tiết bản ghi đã chọn
        var id = recordSelected.data('keyId');
        var objectDetail = recordSelected.data('data');
        debugger;
        
        // Binding dữ liệu vào các input tương ứng trên form chi tiết
        //Load tất cả input trong dialog, với mỗi input gán cho giá trị tương ứng trong objectDetail
        var inputs = $('.dialog input');
        $.each(inputs, function (index, input) {
            var fieldName = $(input).attr('fieldName');
            input.value = objectDetail[fieldName];
        });

        // Hiển thị dialog chi tiết
        $(".form-dialog").show();
        $('#btn_save').click(function () {
            $.each(inputs, function (index, input) {
                var fieldName = $(input).attr('fieldName');
                objectDetail[fieldName] = input.value;
                
            });

            //$.each(data, function (index, obj) {
            //    if (obj.CustomerId == objectDetail.CustomerId) {
            //        data.splice(index, 1, objectDetail);
            //    }               
            //});
            self.loadData();
        });
        
        

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
            var keyId = $('#tbCustomer').attr('keyId');
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
                    $(tr).data('keyId', obj[keyId]);//Thêm data 'keyId' có giá trị là obj.CustomerId vào 'tr'
                    $(tr).data('data', obj); //Thêm data 'data' có giá trị là obj vào 'tr'
                    $(tr).append(td);


                });

                $("#tbCustomer tbody").append(tr);
            });
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



    /**
     * Lấy Id của bản ghi được chọn trong danh sách
     * */
    getRecordIdSelected() {
        // Lấy thông tin bản ghi đã chọn trong danh sách
        var recordSelected = $('#tbCustomer tbody tr.row-selected');

        // Lấy dữ liệu chi tiết bản ghi đã chọn
        var id = recordSelected.data('keyId');
        return id;
    }
}

