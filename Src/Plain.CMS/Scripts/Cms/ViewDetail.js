var view = function() {
    var _init = function() {
        var _commitVm = avalon.define({
            $id: "commit",
            commitList: []

        });
        $.post("/PlainCms/CmsHome/GetCommit", { articleId: $("#txtArticleId").val() }, function (res) {
            _commitVm.commitList = res;
        });
    };
 
    return {
        init:_init
    }
}();