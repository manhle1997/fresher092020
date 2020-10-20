﻿var commonJS = {

    /**
     * Hàm định đạng tiền tệ
     * @param {number} money
     */
    formatMoney(money) {
        try {
            money = parseInt(money);
            return money.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        } catch (e) {
        }  
    },

    /**
     * Hàm định dạng ngày tháng chuẩn dd/MM/yyyy    
     * @param {any} date
     */

    formatDate(date) {
        try {
            datetime = new Date(date)
            var dd = String(datetime.getDate()).padStart(2, '0');
            var mm = String(datetime.getMonth() + 1).padStart(2, '0'); //January is 0!
            var yyyy = datetime.getFullYear();

            datetime = dd + '/' + mm + '/' + yyyy;
            return datetime;
        } catch (e) {
        }
    },

    ///**
    // * 
    // * @param {any} datetime
    // */
    //convertDateToDatetimeISO(datetime) {
    //    var dateTimeISO = datetime + 'T02:05:41';
    //    return dateTimeISO;
    //}
    formatDateISO(date) {
        debugger;
        var now = new Date();

        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);

        var today = now.getFullYear() + "-" + (month) + "-" + (day);
        return today;
    }
}

