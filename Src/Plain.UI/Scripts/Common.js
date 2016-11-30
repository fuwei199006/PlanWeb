mask = function () {
    return {
        show: function () {
            $("#maskBodyBg").css({ height: $(document).height() + "px" }).show();
        },
        hide: function () {
            $("#maskBodyBg").hide();
        }
    };
}();

//*显示居中对话框+遮罩(id,[true,false])*/
function setDialogCenter(divId, IsMask) {
    if (IsMask) {
        mask.show();
    }

    var divLeft = document.documentElement.clientWidth / 2 - $("#" + divId).width() / 2;
    var divTop = document.documentElement.clientHeight / 2 - $("#" + divId).height() / 2;
    var divScrollTop = document.documentElement.scrollTop + divTop; //当前浏览器可见元素的TOP
    var divScrollLeft = divLeft - document.documentElement.scrollLeft / 2;
    $("#" + divId).animate({ top: divScrollTop + "px", left: divScrollLeft + "px" }, 10)
                  .fadeIn(200);
}

//override dialog's title function to allow for HTML titles
if ($.widget) {
    $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
        _title: function (title) {
            var $title = this.options.title || '&nbsp;'
            if (("title_html" in this.options) && this.options.title_html == true)
                title.html($title);
            else title.text($title);
        }
    }));
}


function ShowSelectDialog(opt) {

    var url = opt.url;
    var title = opt.title;
    var option = opt.option;
    var divId = opt.divId;
    var e = opt.saveclick;
    var sender = opt.sender;
    var sourceSender = opt.sourceSender;
  

    var btns = [
        {
            text: "取消",
            "class": "btn btn-xs",
            click: function () {
                $(this).dialog("destroy");
            }
        }
    ];
    
    if (typeof (e) != "undefined") {
        btns.push(
            {
                text: "确定",
                "class": "btn btn-primary btn-xs",
                click: function (event) {
                    var rtn = e(event, this);
                    if (rtn != false) {
                        var vals = "";
                        var texts = "";
                        $(".selectList input:checked").each(function () {
                            var that = this;
                            vals += $(that).attr("keyval") + ",";
                            texts += $(that).attr("keytext") + ",";
                        });
                        if (vals.length > 0) {
                            vals = vals.substring(0, vals.length - 1);
                        }
                        if (texts.length > 0) {
                            texts = texts.substring(0, texts.length - 1);
                        }
                        $(sender).val(texts);
                        $(sourceSender).val(vals);
                        $(this).dialog("destroy");

                        opt.callback();
                    }
                    event.stopPropagation();
                    return false;
                }
            }
        );
    } else {
        btns[0].text = "关闭";
    }

    var commonOpt = {
        modal: true,
        title: "<div class='widget-header widget-header-small'><h4 class='smaller'>" + title + "</h4></div>",
        title_html: true,
        buttons: btns,
        close: function (event, ui) {
            $(this).dialog('destroy').remove();
        }
    };
    if (typeof (url) == "undefined") {
        var obj = $("#" + divId);
        var fun = obj.attr("init");
        if (typeof (fun) != "undefined") {
            var data = opt.data;
            eval(fun + "(data)");
        }
        var o = commonOpt;
        if (option) {
            $.extend(o, option);
        }
        var dialog = obj.removeClass('hide').dialog(o);
    } else {

        $.post(url, opt.data, function (html) {

            var o = commonOpt;
            if (option) {
                $.extend(o, option, { my: 'center', at: 'center', of: "body" });
            }
            $('<div id="dialogdiv">' + html + "</div>").dialog(o);
        });

    }

}

function   ShowDialogCenter(opt) {

    var url = opt.url;
    var title = opt.title;
    var option = opt.option;
    var divId = opt.divId;
    var e = opt.saveclick;
    var btns = [];
    if (opt.buttons)
        btns = opt.buttons;
    btns.push({
        text: "取消",
        "class": "btn btn-xs",
        click: function () {
            if (opt.close) {
                opt.close();
            }
            $(this).dialog("destroy");
        }
    });

    if (typeof (e) != "undefined") {
        btns.push(
            {
                text: "确定",
                "class": "btn btn-primary btn-xs",
                click: function (event) {
                    var rtn = e(event, this); //返回true的话，关闭当前页面
                    if (rtn != false) {
                        $(this).dialog("destroy");
                    }
                    event.stopPropagation();
                    return false;
                }
            }
        );
    } else {
        btns[btns.length-1].text = "关闭";
    }

    var commonOpt = {
        modal: true,
        title: "<div class='widget-header widget-header-small'><h4 class='smaller'>" + title + "</h4></div>",
        title_html: true,
        buttons: btns,
        close: function (event, ui) {
            if (typeof (url) == "undefined") {
                $(this).dialog('destroy');
            } else {
                $(this).dialog('destroy').remove();
            }
            if (opt.close) {
                opt.close();
            }
            
        }
    };
    if (typeof (url) == "undefined") {

        var obj = $("#" + divId);
        var fun = obj.attr("init");
        if (typeof (fun) != "undefined") {
            var data = opt.data;
            eval(fun + "(data)");
        }

        fun = opt["init"];
        if (typeof (fun) != "undefined") {
            fun();
        }

        var o = commonOpt;
        if (option) {
            $.extend(o, option);
        }
        var dialog = obj.removeClass('hide').dialog(o);

    } else {
        htcrmCommon.showLoad();
        $.get(url, opt.data, function (html) {
            htcrmCommon.closeLoad();
            var o = commonOpt;
            if (option) {
                $.extend(o, option, { my: 'center', at: 'center', of: "body" });
            }
            
            $('<div id="dialogdiv">' + html + "</div>").dialog(o);
        });

    }

}


function ShowModelDiaLog(html) {
    mask.show();
    var obj = $("<div class='JqDialog' style='position: absolute;display:none'>" + html + "</div>");
    var div = obj.find("div.ui-dialog");
    div.draggable();
    var divLeft = document.documentElement.clientWidth / 2 - div.width() / 2;
    var divTop = document.documentElement.clientHeight / 2 - div.height() / 2;
    var divScrollTop = document.documentElement.scrollTop + divTop; //当前浏览器可见元素的TOP
    var divScrollLeft = divLeft - document.documentElement.scrollLeft / 2;
    $("body").append(obj);
    obj.css("top", divScrollTop + "px");
    obj.css("left", divScrollLeft + "px");
    obj.fadeIn(200);
}


function hidePop() {
    mask.hide();
    $(".popDiv").hide();
}

function closePop() {
    mask.hide();
    $("div.JqDialog").remove();
}

function setButtonTimeout($c, seconds) {
    if (seconds <= 0)
        return;
    $c.addClass('disabled');
    //$c.attr('disabled', 'disabled');
    var val = $c.val();
    
    var timer = window.setInterval(function () {
        if (seconds > 0 && $c.hasClass('disabled'))
            $c.val(val + '(' + seconds-- + ')');
        else {
            window.clearInterval(timer);
            $c.val(val);
            $c.removeClass('disabled');
        }
        
    }, 1000);
}

function stopButtonTimeout($c) {
    $c.removeClass('disabled');
}

$(function () {

    $(document).delegate("a.popClose,input.popClose", "click", function () {
        hidePop();
    });

    $(document).delegate("button.closePop,input.closePop", "click", function () {
        closePop();
    });
});


function addComma(nStr) {

    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;


}

//$(document)
//.ajaxStart(function () {
//    var img = $("#progressImgage");
//    img.show().css({
//        "position": "fixed",
//        "top": "50%",
//        "left": "50%",
//        "margin-top": function () { return -1 * img.height() / 2; },
//        "margin-left": function () { return -1 * img.width() / 2; }
//    });
//    mask.show();
//})
//.ajaxStop(function () {
//    var img = $("#progressImgage");
//    img.hide();
//    mask.hide();
//});

$.ajaxSetup({
    statusCode: {
        500: function (data) {

            if (closeLoad) {
                closeLoad();
            }
            var errorObj = $.parseJSON(data.responseText);
            $.gritter.add({
                title: '服务器错误',
                text: '请联系<a href="mailto:syhao@huazhu.com">管理员</a>，错误ID:' + errorObj.ErrorId,
                class_name: 'gritter-error'
                //                sticky: true,
                //                time: ''
            });

        },
        400: function (data) { //自定义HttpCode 服务端验证出错
            if (closeLoad) {
                closeLoad();
            }
            alert("表单验证出错. " + data.responseText);
        },
        499: function (data) { //自定义HttpCode 频繁提交请求
            if (closeLoad) {
                closeLoad();
            }
            alert(data.responseText);
        },
        498: function (data) { //自定义HttpCode 498 处理AjaxSession过期

            alert("用户连接超时，请重新登录系统。");
            window.location.href = "/Login";
        }
    }
});

function showLoad() {
    htcrmCommon.loadingCount++;
    var img = $("#progressImgage");
    img.show().css({
        "position": "fixed",
        "top": "50%",
        "left": "50%",
        "margin-top": function () { return -1 * img.height() / 2; },
        "margin-left": function () { return -1 * img.width() / 2; }
    });
    mask.show();
}

function closeLoad() {
    htcrmCommon.loadingCount--;
    if (htcrmCommon.loadingCount > 0)
        return;
    if (htcrmCommon.loadingCount < 0)
        htcrmCommon.loadingCount = 0;
    
    var img = $("#progressImgage");
    img.hide();
    mask.hide();
}

var htcrmCommon = {
    loadingCount: 0,
    showLoad: showLoad,
    closeLoad: closeLoad
};

// showpop
(function ($) {
    // 插件的定义     
    $.fn.showpop = function (options) {
        // build main options before element iteration     
        var opts = $.extend({}, $.fn.showpop.defaults, options);
        // iterate and reformat each matched element     
        return this.each(function () {
            $this = $(this);

            var fun = $this.attr("init");
            var data = options.data;
            if (fun != "") {
                setTimeout(function () {
                    eval(fun + "(data)");
                    setDialogCenter($this.attr("id"), true);
                }, 0);

            }
        });
    };

})(jQuery);


// 修复FormClone 不复制Select
(function ($) {
    // 插件的定义     
    $.fn.cloneForm = function () {

        var oldForm = $(this);
        var newForm = oldForm.clone();
        
        var $origSelects = $('select', oldForm); 
        var $clonedSelects = $('select', newForm); 

        $origSelects.each(function (i) {
            $clonedSelects.eq(i).val($(this).val());
        });
        return newForm;
    };

})(jQuery);



jQuery.extend({
    cloneArray: function (originalArray) {
        var clonedArray = $.map(originalArray, function (obj) {
            return $.extend({}, obj);
        });
        return clonedArray;
    },
    cloneArrayDeep: function (originalArray) {
        var clonedArray = $.map(true,originalArray, function (obj) {
            return $.extend({}, obj);
        });
        return clonedArray;
    }
});

(function ($) {
    var re = /([^&=]+)=?([^&]*)/g;
    var decode = function (str) {
        return decodeURIComponent(str.replace(/\+/g, ' '));
    };
    $.parseParams = function (query) {
        var params = {}, e;
        if (query) {
            if (query.substr(0, 1) == '?') {
                query = query.substr(1);
            }

            while (e = re.exec(query)) {
                var k = decode(e[1]);
                var v = decode(e[2]);
                if (params[k] !== undefined) {
                    if (!$.isArray(params[k])) {
                        params[k] = [params[k]];
                    }
                    params[k].push(v);
                } else {
                    params[k] = v;
                }
            }
        }
        return params;
    };
})(jQuery);

// 对Date的扩展，将 Date 转化为指定格式的String    
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，    
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)    
// 例子：    
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423    
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18    
Date.prototype.Format = function (fmt) { //author: meizz    
    var o = {
        "M+": this.getMonth() + 1,                 //月份    
        "d+": this.getDate(),                    //日    
        "h+": this.getHours(),                   //小时    
        "m+": this.getMinutes(),                 //分    
        "s+": this.getSeconds(),                 //秒    
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度    
        "S": this.getMilliseconds()             //毫秒    
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};

Date.prototype.addHours = function (h) {
    var copiedDate = new Date(this.getTime());
    copiedDate.setHours(copiedDate.getHours() + h);
    return copiedDate;
};
Date.prototype.addMinutes = function (minutes) {
    this.setMinutes(this.getMinutes() + minutes);
    return this;
};
$.ajaxSetup({
    cache: false
});

function QueryString() {
    var name, value, i;
    var str = location.href;
    var num = str.indexOf("?");
    str = str.substr(num + 1);
    var arrtmp = str.split("&");
    for (i = 0; i < arrtmp.length; i++) {
        num = arrtmp[i].indexOf("=");
        if (num > 0) {
            name = arrtmp[i].substring(0, num);
            value = arrtmp[i].substr(num + 1);
            this[name] = value;
        }
    }
}

function setValidatorAlert() {
    if (jQuery.validator) {
        jQuery.validator.setDefaults({
            showErrors: function (errorMap, errorList) {
                if (errorList.length > 0) {
                    alert(errorList[0].message);
                    return false;
                }
            },
            onfocusout: false
        });
    }
}

Array.prototype.contains = function (obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
};


function gd(year, month, day) {
    return new Date(year, month - 1, day).getTime();
}

function convertMonthDay(nS) {
    var date = new Date(nS);
    return (date.getMonth() + 1) + "月" + date.getDate() + "日";
}

function convertYearMonth(nS) {
    var date = new Date(nS);
    return date.getFullYear() + "年" + (date.getMonth() + 1) + "月";
}

function showTooltip(x, y, contents) {
    $("<div id='linetooltip'>" + contents + "</div>").css({
        position: "absolute",
        display: "none",
        top: y + 5,
        left: x + 5,
        border: "1px solid #fdd",
        padding: "2px",
        "background-color": "#fee",
        opacity: 0.80
    }).appendTo("body").fadeIn(200);
}
//function MyLoading(falg,divName) {
//
//    var loading = "<div id='dlading' style='position:absolute;left:0;width:100%;height:100%;top:0;background:#FFFFFF;opacity:0.8;filter:alpha(opacity=90);z-index:9999999;'>";
//    loading += "<div style='border:2px solid #B7CDFC;cursor:point;position:relative;top:45%;margin:0 auto;width:200px;height:36px;line-height:28px;font-size:14px;background:#fff;padding-left:5px;'>";
//    loading += "<h6 style='display:inline;line-height:28px;height:28px;float:left'><img src='/Images/loading.gif' width='16' height='16' valign='middle' style='margin-top:8px;float:left' />正在加载，请等待......</h6></div></div>";
//
//    if (falg) {
//        $("#" + divName).append(loading);
//    } else {
//        if ($("#dlading") != undefined) {
//            $("#dlading").remove();
//        }
//    }
//}

String.prototype.replaceAll = function (s1, s2) {

    var r = new RegExp(s1.replace(/([\(\)\[\]\{\}\^\$\+\-\*\?\.\"\'\|\/\\])/g, "\\$1"), "ig");
    return this.replace(r, s2);
};

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g,
        function (m, i) {
            return args[i];
        });
};

String.prototype.ltrim = function (p1) {

    var j;
    for (j = 0; this.charAt(j) == p1; j++) {
    }
    return this.substring(j, this.length);
};


$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};



function GetDateDifference(start, end) {
    // Parse the entries
    var startDate = Date.parse(start.replace('-', '/').replace('-', '/'));
    var endDate = Date.parse(end.replace('-', '/').replace('-', '/'));

    // Check the date range, 86400000 is the number of milliseconds in one day
    var difference = (endDate - startDate) / (86400000);

    return difference;
}

var SelectLoadData = function (parentArrayId, selectType, displayId, arrayId, func) {

    var valueArray = $("#" + parentArrayId).val();
    var displayCtrl = $("#" + displayId);
    var arrayCtrl = $("#" + arrayId);
    displayCtrl.val("");   //
    arrayCtrl.val("");
    if (valueArray == "") {
        func();
        return;
    }
    var url = '/Enterprise/DataAnalysis/LoadSelectData';
    var postData = { loadType: selectType, parentIds: valueArray };
    $.ajax({
        type: "POST",
        url: url,
        data: postData,
        dataType: "json",
        success: function (data) {

            var displayVal = '';
            var arrayVal = '';
          
            $.each(data, function (commentIndex, comment) {
                displayVal += comment.Text + ',';
                arrayVal += comment.Value + ',';
            });

            if (arrayVal.length > 0) {
                displayVal = displayVal.substring(0, displayVal.length - 1);
                arrayVal = arrayVal.substring(0, arrayVal.length - 1);
            }

            displayCtrl.val(displayVal);   //
            arrayCtrl.val(arrayVal);
            func();
        }
    });
};

Date.prototype.toShortDateString = function () {
    return [this.getFullYear(), this.getMonth() + 1, this.getDate()].join('-');
};