
var commonCtrl = {
    init: function () {
        var mask = $("<div id='hui-overlay-mask'></div>");
        var obj = this.getSize();
        mask.height(obj.y);
        mask.width(obj.x);
        var contenthtmlarr = [];
        var $closebtn = $("<a class='hui-dialog-close' title='关闭'><span class='hui-icon hui-icon-delete'></span></a>");
        contenthtmlarr.push("<div class='hui-dialog'>");
        contenthtmlarr.push("<div class='hui-dialog-title'><span>您尚未登录</span></div>");
        contenthtmlarr.push("<div class='hui-dialog-content' style='height:400px;padding: 10px;background: #fff;overflow: hidden;'>");
        contenthtmlarr.push("<iframe src='loginbox' marginwidth='0' marginheight='0' frameborder='0' scrolling='no' style='border: 0px; width: 100%; height: 100%;'></iframe>");
        contenthtmlarr.push("</div>");
        contenthtmlarr.push("<a class='hui-dialog-close' title='关闭'><span class='hui-icon hui-icon-delete'></span></a>");
        contenthtmlarr.push("</div>");
        var content = $(contenthtmlarr.join(''));
        $(document.body).append(mask);
        $(document.body).append(content);
        content.find(".hui-dialog-close").click(function () {
            mask.remove();
            content.remove();
        });
    },
    gethtml: function () {
    },
    initconfig: function (opts) {
        this.width = opts.width || 400;
        this.height = opts.height || 300;
        this.type = opts.type || "content";
        this.title = opts.title || "提示";
        //宽高 iframe or 提示类型 内容 title
    },
    setPosition:function(){
    },
    getPosition: function () {
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
    commonCtrl.init();
});

