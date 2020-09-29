var commonJS = {
    formatMoney(money) {
        return money.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    },

    formatDate(date) {
        
        var dd = String(date.getDate()).padStart(2, '0');
        var mm = String(date.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = date.getFullYear();

        date = mm + '/' + dd + '/' + yyyy;
        return date;
    }
}

