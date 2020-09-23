$(document).ready(function () {
    $(".btn-close").click(function () {
        $(".form-dialog").hide();
    });
});
$(document).ready(function () {
    $("#toolbar-item-add").click(function () {
        $(".form-dialog").show();
    });
});