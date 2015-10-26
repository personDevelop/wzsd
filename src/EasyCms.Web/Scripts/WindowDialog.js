Dialog = {
    hasInit: false,
    WindowOpts: {},
    opts: {},
    lastUrl: "",
    create: function (imgUrl) {
        var html = '<div id="modalDialog" style="display:none">';
        html += '<div id="windowHeadermodalDialog">';
        html += ' <span><img src="' + imgUrl + '" alt="" style="margin-right: 15px" /> <span id="windowTitlemodalDialog">模态窗口';
        html += '</span></span></div>';
        html += '<div style="overflow: hidden;" id="windowContentmodalDialog">';
        html += '<iframe id="iframemodalDialog" height="100%" width="100%" style="margin:0px; padding:0px"></iframe>';
        html += '</div></div>';
        $("body").append(html);
    },
    innit: function () {
        if (!this.hasInit) {
            $("#modalDialog").jqxWindow($.extend({
                showCollapseButton: true, autoOpen: false,
                height: 300, width: 500, maxWidth: 2000, maxHeight: 1200
            }, this.WindowOpts));
            this.hasInit = true;
            $("#modalDialog").on('open', function (event) {
                SetThisDialogState(false);
                var iframe = $(event.target).find("iframe");
                var dialog = $(event.target).data("dialog");
                var currentUrl = iframe.attr("src");
                if (dialog.lastUrl != currentUrl) {
                    iframe.attr("src", dialog.lastUrl);
                } else {
                    if (dialog.opts.AllWaysNew) {
                        iframe.attr("src", dialog.lastUrl);
                    }
                }

                if (dialog.opts.onopen) {
                    dialog.opts.onopen($(event.target));
                }
            });
            $("#modalDialog").on('close', function (event) {
                var dialog = $(event.target).data("dialog");
                if (dialog.opts.onClose) {
                    dialog.opts.onClose($(event.target));
                }
            });
        }

    },
    /*窗口url,窗口标题，额外的属性（目前只包含打开事件，和关闭事件，如果一个网页里只有一个模态窗口，也可以用windowOpts传递），windowOpts 针对jqxwindow的一些属性*/
    open: function (url, title, opts, windowOpts) {
        if (opts) {
            this.opts = opts;
        }
        this.lastUrl = url;
        if (windowOpts) {
            this.WindowOpts = windowOpts;
        }

        this.innit();
        if (title) {
            $("#windowTitlemodalDialog").text(title);
        }

        $("#modalDialog").data("dialog", this);
        $("#modalDialog").jqxWindow('open');

        if (opts.AllWayInit) {

            /*重新设置宽度和高度*/
            if (windowOpts.width) {
                $("#modalDialog").jqxWindow("width", windowOpts.width);
            }

            if (windowOpts.height) {
                $("#modalDialog").jqxWindow("height", windowOpts.height);
            }
        }
    }

};
function CloseThisDialog() {

    $("#modalDialog").jqxWindow("close");

}

function SetThisDialogState(isChange) {

    $("#modalDialog").data("isChange", isChange);

}
function GetThisDialogState() {

    return $("#modalDialog").data("isChange");

}



