define(function (require) {
    var avalon = require("../avalon"),
        salary = require("salary");
    var _mainVm = avalon.define({
        $id: "salary",
        yearArr: [1, 2, 3, 4, 5],
        monthArr: [],

        fixdTime: [],//固定项目
        specialItems: [],//特别项目
        returnProject: [],//扣发项目
        otherItem: [],//其它项目
        referenceItem: [],//未知项目
        btnClick: function () {
            var date = $("#dllYear").val() + "-" + $("#dllMonth").val();
            $.post("Salary/GetSalary", { paras: JSON.stringify({ Date: date, UserCode: $("#thUserCode").text() }) }, function (res) {
                //console.log(res);
                _mainVm.fixdTime = res.fixdTime;
                _mainVm.specialItems = res.specialItems;
                _mainVm.returnProject = res.returnProject;
                _mainVm.otherItem = res.otherItem;
                _mainVm.referenceItem = res.referenceItem;

            });
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