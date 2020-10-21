var commonJS = {

    /**
     * Hàm định đạng tiền tệ
     * @param {number} money
     * author: Lê Mạnh (20/10/2020)
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
     * author: Lê Mạnh (20/10/2020)
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
    // * Formant ISO date
    // * @param {any} datetime
    // */
    //author: Lê Mạnh (20/10/2020)
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

