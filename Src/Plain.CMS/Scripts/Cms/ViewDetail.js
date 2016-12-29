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
                    $("#txtMsg").html("评论不能为空...");
                    return false;
                }
                if (commitContent.length > 500) {
                    $("#txtMsg").show();
                    $("#txtMsg").html("字数过长,不能超过500...");
                    return false;
                }

                if ($("#txtUser").val()==="0") {
                    $("#txtMsg").show();
                    $("#txtMsg").html("请先登录...");
                    return false;
                }
                $("#txtMsg").hide();
                $("#load").show();
                $.post("/PlainCms/CmsHome/AddCommit", { articleId: $("#txtArticleId").val(), content: commitContent, type: 0 }, function (res) {
                    $("#txtMsg").hide();
                    $("#load").hide();
                    $("#txtCommit").val("");
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