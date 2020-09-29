var commonJS = {
    formatMoney(money) {
        return money.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    }


}