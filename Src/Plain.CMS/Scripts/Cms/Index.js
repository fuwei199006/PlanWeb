﻿/*
* @Author: fuwei16
* @Date:   2016-12-21 14:24:20
* @Last Modified by:   fuwei16
* @Last Modified time: 2016-12-21 16:05:09
*/

'use strict';

var home = function () {

    var _init = function () {
        setTimeout(function () {

            $('#mask').hide(10);
            $('#container').show();

        }, 1000);
    }

    var _active = function (name, obj) {
        $("#bread").html(name);
        //$(obj).addClass("active").siblings().removeClass("active");
    }

    return {
        init: _init,
        active:_active
    }

}();