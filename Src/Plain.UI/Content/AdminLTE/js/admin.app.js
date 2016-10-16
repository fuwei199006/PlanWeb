
//新菜单根据Url决定逻辑
(function () {
    var locationHref = window.location.href;
    $(".sidebar-menu ul>li>a").each(function () {

        if (locationHref.indexOf($(this).attr("href")) > 0) {
            $(this).parent().addClass("active");
            $(this).append("<span class='selected'></span>");

            $("#navigation .page-title span").html($(this).text());
            $("#navigation .page-title small").html($(this).attr("title") || "");
            $("#navigation .breadcrumb li:eq(1) span").html($(this).text());
            $("#navigation .breadcrumb li:eq(1) i").remove();
            $("#navigation .breadcrumb li:eq(2)").remove();

            document.title = $(this).text() + " - " + document.title;

            return false;
        }
        else {
            var parent = $(this);
            $(this).next("ul").each(function () {
                $("a", $(this)).each(function () {
                    if (locationHref.indexOf($(this).attr("href")) > 0) {
                        $(this).parent().addClass("active");

                        parent.parent().addClass("active");
                        $(".arrow", parent).addClass("open").before("<span class='selected'></span>");

                        $("#navigation .page-title span").html($(this).text());
                        $("#navigation .page-title small").html($(this).attr("title") || "");
                        $("#navigation .breadcrumb li:eq(1) span").html(parent.text());
                        $("#navigation .breadcrumb li:eq(2) span").html($(this).text());

                        document.title = $(this).text() + " - " + document.title;

                        return false;
                    }
                });
            });
        }
    });
})();