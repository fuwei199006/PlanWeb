
//新菜单根据Url决定逻辑
(function () {
    var locationHref = window.location.href;
    $(".sidebar-menu ul").each(function (index, value) {

        var $a = $(value).find("li>a");
        var len = $a.length;
        for (var i = 0; i < len; i++) {
            if (locationHref.indexOf($($a[i]).attr("href")) > 0) {
                $(this).parent().addClass("active");
                $(this).addClass("menu-open");
                $($a[i]).parent().addClass("active");
                return false;
            }
        }


    });
})();