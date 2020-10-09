var validData = {
    /**
     * Thực hiện validate các trường bắt buộc nhập
     * 
     */
    validateRequired: function (input) {
        var value = $(input).val();
        //Thực hiện kiểm tra xem dữ liệu có nhập hay không
        if (!value || !(value && value.trim())) {
            $(input).addClass('not-required');
            $(input).attr('title', 'Trường này không được để trống');
            return false;
        } else {
            $(input).removeClass('not-required');
            $(input).removeAttr('title');
            return true;
        } 
    }


}
