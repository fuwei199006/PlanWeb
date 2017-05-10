define(function (require) {
    var avalon = require("../avalon"),
        salary = require("salary");
    var _mainVm = avalon.define({
        $id: "salary",
        yearArr: [1, 2, 3, 4, 5],
        monthArr: [],
        salaryArr: [],
        fixdTime: [],//固定项目
        specialItems: [],//特别项目
        returnProject: [],//扣发项目
        otherItem: [],//其它项目
        unKnowItem: [],//未知项目
        btnClick: function () {
         
        }
    });

    var _init = function (option) {
        if (!!option) {
            _mainVm.yearArr = option.yearArr;
            _mainVm.monthArr = option.monthArr;
            _mainVm.currentYear = option.currentYear;
            _mainVm.currentMonth = option.currentMonth;
        }
    }

    return {
        init: _init
    }

});