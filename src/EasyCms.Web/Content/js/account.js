
var DialogCtrl = {
    
    init: function (opts) {
        this.initconfig(opts);
        var mask = $("<div id='hui-overlay-mask'></div>");
        var obj = this.getSize();
        mask.height(obj.y);
        mask.width(obj.x);
        var contenthtmlarr = []; 
        contenthtmlarr.push("<div class='hui-dialog' style='width:" + this.opts.width + "px'>");
        contenthtmlarr.push("<div class='hui-dialog-title'><span>" + this.opts.title + "</span></div>");
        contenthtmlarr.push("<div class='hui-dialog-content' style='height:" + this.opts.height + "px;padding: 10px;background: #fff;overflow: hidden;'>");
        //contenthtmlarr.push("<iframe src='loginbox' marginwidth='0' marginheight='0' frameborder='0' scrolling='no' style='border: 0px; width: 100%; height: 100%;'></iframe>");
        contenthtmlarr.push(this.gethtml());
        contenthtmlarr.push("</div>");
        contenthtmlarr.push("<a class='hui-dialog-close' id='dialog-close' title='关闭'><span class='hui-icon hui-icon-delete'></span></a>");
        contenthtmlarr.push("</div>");
        var content = $(contenthtmlarr.join(''));
        $(document.body).append(mask);
        $(document.body).append(content);
        content.find("#dialog-close").bind("click", function () {
            //取出缓存数据,可以根据该值 判断窗口关闭时不同的动作
          var result=  $("#dialog-close").data("dialogResult");
          if (!result) {
              result = {};
          }
            mask.remove();
            content.remove();
            if (DialogCtrl.opts.onClose && $.isFunction(DialogCtrl.opts.onClose)) {
                DialogCtrl.opts.onClose(result);
            }
        });
        this.setPosition(content);
    },
    showFormurl: function (url, closeCallBack) {
        this.init({
            "type": "url",
            "url": url,
            "height": 400,
            onClose: closeCallBack
        });
    },
    showError: function (mes) {
        this.init({ "mes": mes, "infotype": "warn" });
    },
    showSuccess: function (mes) {
        this.init({ "mes": mes });
    },
    gethtml: function () {
        var html = [];
        if (this.opts.type == "url") {
            html.push("<iframe id='dialogframe' src='" + this.opts.url + "' marginwidth='0' marginheight='0' frameborder='0' scrolling='no' style='border: 0px; width: 100%; height: 100%;'></iframe>");
        } else {
            var iconclass = this.opts.infotype == "success" ? "success-icon" : "warn-icon";
            var iconthtml = "<div class='info'><span class='" + iconclass + " m-icon'></span><div class='infomes'>" + this.opts.info + "</div></div>";
            html.push(iconthtml);
        }
        return html.join("");
    },
    initconfig: function (opts) {
        this.opts = $.extend(this.opts,opts,{});
        this.opts.width = opts.width || 400;
        this.opts.height = opts.height || 100;
        this.opts.type = opts.type || "content";
        this.opts.url = opts.url || "";
        this.opts.title = opts.title || "提示";
        this.opts.info = opts.mes || "";
        this.opts.infotype = opts.infotype || "success";
        this.opts.postion = opts.postion || "center";

        //宽高 iframe or 提示类型 内容 title
    },
    setmesType: function (type) {
        this.opts.infotype = type;
    },
    setPosition: function (ele) {
        var obj = this.getPosition();
        ele.css("left", obj.x + "px");
        ele.css("top", obj.y + "px");
    }, 
    setResult: function (data) {
        $("#dialog-close").data("dialogResult", data); 
    },
    getPosition: function () {

        var width = $(window).width();
        var height = $(window).height();
        var left = (width - this.opts.width) / 2;
        var top = (height - this.opts.height - 100) / 2;
        return {
            x: left,
            y: top
        }
        //获取位置信息
    },
    getSize: function () {
        var h = $(document.body).height();
        if (h < $(window).height()) {
            h = $(window).height();
        }
        return {
            x: $(document.body).width(),
            y: h
        };
    }, 
    bindEvent: function () {
    }
};
$(function () {

});
function closeDialog(closeelement) {
    if (!closeelement) {
        closeelement = "#dialog-close";
    }
    
    parent.$(closeelement, parent.document).trigger("click");
  
}
function setResult(data, closeelement) {
    if (!closeelement) {
        closeelement = "#dialog-close";
    }
    parent.$(closeelement, parent.document).data("dialogResult", data);

}
function showFormurl(url,closeCallBack) {

    DialogCtrl.showFormurl(url, closeCallBack);
}

function openTips(msg) {

    DialogCtrl.showSuccess(msg);
}

function openTipsWrong(msg) {

    DialogCtrl.showError(msg);
}

function GetUserStauts(url) {
    var status = false;

    $.ajax({
        type: 'GET',
        async: false,
        url: url,
        dataType: "json",
        cache: false,
        error: function (e) {
            alert(e);
        },
        success: function (result) {
            status = result;
        }
    });

    return status;

}

