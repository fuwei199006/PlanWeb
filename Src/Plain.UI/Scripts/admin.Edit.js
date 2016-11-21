$(document).ready(function () {
    $("#cancel").click(function () {
        window.top.tb_remove();
    });

    var mainForm = $("#submit").parent().parent();
    mainForm.submit(function () {
        if (mainForm.valid()) {
            $("#submitloading").show();
       
        } else {
            //$(".validation-summary-errors").show();
            //$(".validation-summary-errors").hide(30000);
        }
    });

    //$("input[type='text']").blur(function () { $(this).removeClass("highlight"); }).focus(function () { $(this).addClass("highlight"); });

    //$(".integer").numeric(false, function () { alert("只能输入数字"); this.value = ""; this.focus(); });

    //$("#checkall").click(function () {
    //    var ischecked = this.checked;
    //    $("input:checkbox[name='ids']").each(function () {
    //        this.checked = ischecked;
    //    });

    //    $.uniform.update(':checkbox');
    //});
});
