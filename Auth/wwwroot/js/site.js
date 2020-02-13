/*Declaration des select2*/
$('.select-users').select2();
$('.select-files').select2();

/*Select/unselect team*/
$("#checkbox_users").click(function () {
    if ($("#checkbox_users").is(':checked') == true) {
        $(".select-users > option").prop("selected", "selected");
        $(".select-users").trigger("change");
    } else {
        $(".select-users").val('').trigger("change");
    }
});

/*Select/unselect files*/
$("#checkbox_files").click(function () {
    if ($("#checkbox_files").is(':checked') == true) {
        $(".select-files > option").prop("selected", "selected");
        $(".select-files").trigger("change");
    } else {
        $(".select-files").val('').trigger("change");
    }
});