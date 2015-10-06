Dialog = {
    imageUrl: "",
    dialogID: "创建时赋值",
    hasInit: false,
    AllWaysNew: true,
    opts: {},
    Url: "",
    onClose: null,
    create: function (diaID, title, imgUrl, allWaysNew) {
        this.dialogID = diaID;
        if (allWaysNew) {
            this.AllWaysNew = allWaysNew;
        }


        var html = '<div id="' + this.dialogID + '" style="display:none">';
        html += '<div id="windowHeader' + this.dialogID + '">';
        html += ' <span><img src="' + imgUrl + '" alt="" style="margin-right: 15px" /> <span id="windowTitle' + this.dialogID + '">' + title;
        html += '</span></span></div>';
        html += '<div style="overflow: hidden;" id="windowContent' + this.dialogID + '">';
        html += '<iframe id="iframe' + this.dialogID + '" height="100%" width="100%" style="margin:0px; padding:0px"></iframe>';
        html += '</div></div>';
        $("body").append(html);
    },
    innit: function () {
        if (!this.hasInit) {

            $("#" + this.dialogID).jqxWindow($.extend({
                showCollapseButton: true, autoOpen: false,
                height: 300, width: 500

            }, this.opts));
            this.hasInit = true;
            $("#" + this.dialogID).data("AllWaysNew", this.AllWaysNew);
            $("#" + this.dialogID).on('open', function (event) {
                var iframe = $(event.target).find("iframe");
                var url = $(event.target).data("Url");
                if (!iframe.attr("src")) {
                    iframe.attr("src", url);
                } else {
                    var AllWaysNew = $(event.target).data("AllWaysNew");
                    if (AllWaysNew) {
                        iframe.attr("src", url);
                    }
                }
            });
            $("#" + this.dialogID).on('close', function (event) {
                var onClose = $(event.target).data("dialog").onClose;
                if (!onClose) { } else {
                    onClose($(event.target));
                }
            });
        }

    },
    open: function (url, opts, title, onClose) {
        if (opts) {
            this.opts = opts;
        }
        $("#" + this.dialogID).data("dialog", url);
        $("#" + this.dialogID).data("Url", url);
        if (!onClose) {

        } else { this.onClose = onClose; }

        this.innit();
        if (title) {
            $("#windowTitle" + this.dialogID).text(title);
        }

        $("#" + this.dialogID).data("dialog", this);
        $("#" + this.dialogID).jqxWindow('open');


    }

};