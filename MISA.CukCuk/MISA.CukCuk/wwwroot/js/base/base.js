$(document).ready(function () {
    //load dữ liệu

})


class BaseJS {

    constructor(url) {
        this.geturl = url;
        this.getData();
        this.loadData();
        this.initEvents();
        this.getDataPosition();
        this.loadDataPosition();
        this.getDataDepartment();
        this.loadDataDepartment();
        this.getLastedEmployeeCode();
        this.getRecordIdSelected();
    }

    //#region InitEvents
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
            $("#employee-code").val(self.getLastedEmployeeCode());
            $("#employee-code").focus();

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
        $('.btn-copy-item').click(this.btnCopyOnClick.bind(this));
        
    }
    //#endregion

    //#region Copy
    /**
     * Nhân bản bản ghi với Code tăng lên 1 và mọi thông tin khác đều giống nhau
     * Author: Lê Mạnh (20/10/2020)
     * */
    btnCopyOnClick() {
        
        var self = this;
        self.FormMode = 'Add';
        self.getLastedEmployeeCode();
        var trSelected = $("table tr.row-selected");
        var id = 0;
        // Hiển thị dialog chi tiết
        
        if (trSelected.length > 0) {
            id = self.getRecordIdSelected();
            $.ajax({
                url: self.geturl + "/" + id,
                method: "GET",
                data: "",
                dataType: "json",
                contentType: "application/json",
                async: false
            }).done(function (res) {
                var objId = res;
                $(".form-dialog").show();
                var inputs = $("input[fieldName], select[fieldName]");
                $.each(inputs, function (index, input) {
                  
                    var fieldName = $(input).attr('fieldName');
                    if (fieldName == "dateOfBirth" || fieldName == 'identityDate' || fieldName == 'joinDate' || fieldName == 'identityNumber') {
                        
                        $(input).val(commonJS.formatDateISO(objId[fieldName]));
                    } else if (fieldName == "employeeCode") {
                        $(input).val(self.getLastedEmployeeCode());
                    }
                    else {
                        $(input).val(objId[fieldName]);
                    }
                })
            }).fail()
        } else {
            alert("Vui lòng chọn nhân viên bạn muốn nhân bản");
        }
        
    }
    //#endregion

    //#region Validate
    /**
     * Validate bắt buộc nhập
     * Author: lê Mạnh
     * */
    validateRequired(sender) {
        validData.validateRequired(sender.currentTarget);

    }
    //#endregion

    //#region Delete
    /**
     * Hàm xóa dữ liệu được chọn
     * Author: Lê Mạnh
     * */
    btnDeleteOnClick() {
        try {
            var self = this
            var trSelected = $("table tr.row-selected");
            debugger;
            if (trSelected.length > 0) {
                $('.form-dialog-delete').show();
                var id = self.getRecordIdSelected();
                var name = $(trSelected)[0].children[1].textContent;
                $('.form-dialog-delete .delete-confirm-text').text('Bạn có muốn xoá nhân viên ' + name + ' không ?');

                $('.btn-yes-delete').click(function () {
                    $.ajax({
                        url: self.geturl + "/" + id,
                        method: "DELETE",
                        data: "",
                        dataType: "json",
                        contentType: "application/json",
                        async: false
                    }).done(function (employee) {
                        self.loadData();
                        $('.form-dialog-delete').hide();
                    }).fail(function (employee) {
                    })
                })
                $('.btn-no-delete').click(function () {
                    $('.form-dialog-delete').hide();
                    trSelected.removeClass('row-selected');
                })
                
            }
            else {
                alert("Không có bản ghi nào được chọn");
            }


        } catch (e) {

        }

    }
    //#endregion

    //#region Save
    /**
    * Thực hiên lưu dữ liệu
    * Author: Lê Mạnh
    * */
    btnSaveOnClick() {

        //try {
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
            var inputs = $('input[fieldName], select[fieldName]');

            //build object dữ liệu
            var customer = {};

            $.each(inputs, function (index, input) {

                var fieldName = $(input).attr('fieldName');
                var value = $(input).val();
                customer[fieldName] = value;
                if (fieldName == "salary" || fieldName == "workStatus" || fieldName == "gender") {
                    customer[fieldName] = parseFloat(value);
                }
                if (fieldName == "dateOfBirth" || fieldName == "joinDate" || fieldName == "identityDate") {
                    customer[fieldName] = value + "T00:00:00";
                }

            });
            if (self.FormMode == 'Add') {
                alert('Thêm mới nhân viên thành công');
                $.ajax({
                    url: "/api/employees",
                    method: "POST",
                    data: JSON.stringify(customer),
                    contentType: "application/json"
                }).done(function (res) {
                    self.loadData();
                }).fail(function (res) {

                })
            }
            else {
                
                var trSelected = $("table tr.row-selected");
                var id = this.getRecordIdSelected();
                $.ajax({
                    url: self.geturl + "/" + id,
                    method: "PUT",
                    data: JSON.stringify(customer),
                    contentType: "application/json"
                }).done(function (res) {
                    self.loadData();
                }).fail(function (res) {

                })
                alert("Sửa thông tin thành công");
            }
            $(".form-dialog").hide();
            return;
        }
        //    //gọi service thực hiện lưu dữ liệu
        //} catch (e) {

        //}
    }
    //#endregion

    //#region Edit
    /**
    * Hàm Edit thông tin
    * Author: Lê Mạnh
    */
    btnEditOnClick() {
        this.FormMode = 'Edit';
        try {
            var self = this
            var trSelected = $("table tr.row-selected");
            // Hiển thị dialog chi tiết
            //var id = $(trSelected).children()[10].textContent;
            if (trSelected.length > 0) {
                var id = this.getRecordIdSelected();
                $.ajax({
                    url: self.geturl + "/" + id,
                    method: "GET",
                    data: "",
                    dataType: "json",
                    contentType: "application/json",
                    async: false
                }).done(function (employee) {
                    var objId = employee;
                    $(".form-dialog").show();
                    var inputs = $("input[fieldName], select[fieldName]");
                    $.each(inputs, function (index, input) {
                        debugger;
                        var fieldName = $(input).attr('fieldName');
                        if (fieldName == "dateOfBirth" || fieldName == 'identityDate' || fieldName == 'joinDate' || fieldName == 'identityNumber') {
                            debugger
                            $(input).val(commonJS.formatDateISO(objId[fieldName]));
                        }
                        else {
                            $(input).val(objId[fieldName]);
                        }
                    })
                }).fail()
               
            }
            else {
                alert('Vui lòng chọn nhân viên muốn sửa thông tin');
            }
            

        } catch (e) {

        }
    }
    //#endregion

    //#region LoadData
    /**
     * Load dữ liệu 
     * Author: Lê Mạnh
     * */
    //Todo Fix lỗi không binding được data lên page
    loadData() {
        var self = this;
        self.getLastedEmployeeCode();
        try {
            $("#tbCustomer tbody").empty();
            $.ajax({
                url: this.geturl,
                method: "GET",
                //data: {},
                dataType: "json",
                contentType: "application/json",
            }).done(function (response) {

                //response được trả về là 1 mảng các đối tượng là các json
                if (response) {
                    var fields = $('#tbCustomer thead .thead td')
                    var keyId = $('#tbCustomer').attr('keyId');
                    $.each(response, function (index, obj) {
                        var tr = $(`<tr></tr>`);
                        $.each(fields, function (index, field) {
                            var fieldName = $(field).attr('fieldName');
                            fieldName = fieldName.charAt(0).toLowerCase() + fieldName.slice(1); //viết thường chữ cái đầu của fieldName
                            var fieldNumber = $(field).attr('fieldNumber');
                            var value = obj[fieldName];

                            if (fieldNumber == 'DebitMoney' || fieldNumber == 'Salary') {
                                var td = $(`<td title="` + value + `" style="text-align: right;">` + commonJS.formatMoney(value) + `</td>`);
                            } else if (fieldNumber == 'DateOfBirth') {
                                var td = $(`<td title="` + value + `">` + commonJS.formatDate(value) + `</td>`);
                            } else if (fieldName == 'employeeId') {
                                var td = $(`<td style="display:none" title="` + value + `">` + value + `</td>`);
                            } else {
                                var td = $(`<td title="` + value + `">` + value + `</td>`);
                            }
                            $(tr).data('keyId', obj[keyId]);//Thêm data 'keyId' có giá trị là obj.CustomerId vào 'tr'
                            $(tr).data('data', obj); //Thêm data 'data' có giá trị là obj vào 'tr'
                            $(tr).append(td);
                        });
                        $("#tbCustomer tbody").append(tr);
                    });
                }
            }).fail(function (response) {
            })
        } catch (e) {

        }
    }
    //#endregion


    //#region get and load Department, Position
    /**
     * Lấy dữ liệu Position
     * Author: Lê Mạnh (20/10/2020)
     * */
    getDataPosition() {
        this.DataPosition = {};
        try {
            var self = this;
            $.ajax({
                url: "/api/positions",
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: "",
                async: false,
            }).done(function (position) {
                self.DataPosition = position;
            })
        } catch (e) {

        }
    }

    /**
     * Load dữ liệu position lên form
     * Author: Lê Mạnh (20/10/2020)
     * */
    loadDataPosition() {
        try {
            var self = this;
            $.each(this.DataPosition, function (index, obj) {
                $('.dialog .dialog-body .work-infor .position-selected').append('<option value="' + obj["positionId"] + '">' + obj["positionName"] + '</option>');
            })
        } catch (e) {

        }
    }

    /**
     * Lấy dữ liệu department 
     * Author: Lê Mạnh (20/10/2020)
     * */
    getDataDepartment() {
        this.DataDepartment = {};
        try {
            var self = this;
            $.ajax({
                url: "/api/departments",
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: "",
                async: false,
            }).done(function (department) {
                self.DataDepartment = department;
            })
        } catch (e) {

        }
    }


    /**
     * Load dữ liệu department lên form
     * Author: Lê Mạnh (20/10/2020)
     * */
    loadDataDepartment() {
        try {
            var self = this;
            $.each(this.DataDepartment, function (index, obj) {
                $('.dialog .dialog-body .work-infor .department-selected').append('<option value="' + obj["departmentId"] + '">' + obj["departmentName"] + '</option>');
            })
        } catch (e) {

        }
    }
    //#endregion

    /**
     * Hàm lấy dữ liệu
     * Author: Lê Mạnh (20/10/2020)
     * */
    getData() {
        this.Data = [];
    }

    /**
     * Hàm nạp lại dữ liệu
     * Author: Lê Mạnh
     * */
    btnReloadDataOnClick() {
        this.loadData();
    }

    /**
     * Đổi màu hàng được chọn
     * Author: Lê Mạnh (20/10/2020)
     * */
    rowOnClick() {
        $(this).siblings().removeClass('row-selected')
        $(this).addClass('row-selected');
    }

    /**
     * Hàm lấy KeyId của các bảng
     * Author: Lê Mạnh (20/10/2020)
     * */
    getKeyId() {
        try {
            var keyId = $('#tbCustomer').attr('keyId');
            debugger;
            return keyId;
        } catch (e) {

        }
    }


    /**
     * Lấy Id của bản ghi được chọn trong danh sách
     * Author: Lê Mạnh (20/10/2020)
     * */
    getRecordIdSelected() {
        // Lấy thông tin bản ghi đã chọn trong danh sách
        var recordSelected = $('#tbCustomer tbody tr.row-selected');
        // Lấy dữ liệu chi tiết bản ghi đã chọn
        //var id = recordSelected.data('keyId');
        var id = recordSelected.data("data")["employeeId"];
        return id;
    }

    /**
     * Lấy Id mới nhất của nhân viên
     * Author: Lê Mạnh (20/10/2020)
     * */
    getLastedEmployeeCode() {
        this.lastedCode = 0;
        try {
            var self = this;
            $.ajax({
                url: this.geturl,
                method: "GET",
                data: "",
                contentType: "application/json",
                dataType: "",
                async: false,
            }).done(function (employee) {
                self.lastedCode = employee[employee.length - 1]["employeeCode"];
                self.lastedCode = self.lastedCode.slice(0, 4) + (parseInt(self.lastedCode.slice(4)) + 1);
               // $('#employee-code').val($('#employee-code').val() + self.lastedCode);
            })
            return self.lastedCode;
        } catch (e) {

        }
    }


}

