var view = function() {
    var _init = function() {
        var _commitVm = avalon.define({
            $id: "commit",
            commitList: [],
            addCommit: function () {
                var that = this;
                var commitContent = $("#txtCommit").val();
                if (!commitContent) {
                    $("#txtMsg").show();
                    return false;
                }
                $("#txtMsg").hide();
                $("#load").show();
                $.post("/PlainCms/CmsHome/AddCommit", { articleId: $("#txtArticleId").val(), content: commitContent, type: 0 }, function (res) {
                    $("#txtMsg").hide();
                    $("#load").hide();
                    $("#txtCommit").empty();
                    that.commitList.push(res)
                });
            }

        });
        $.post("/PlainCms/CmsHome/GetCommit", { articleId: $("#txtArticleId").val() }, function (res) {
            _commitVm.commitList = res;
        });
    };
 
    return {
        init:_init
    }
}();