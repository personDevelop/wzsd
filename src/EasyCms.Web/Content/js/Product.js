$(function () {
    $(".jqzoom").jqueryzoom({ xzoom: 380, yzoom: 410 });
});
//==================图片详细页函数=====================
//鼠标经过预览图片函数
function preview(img) {
    $("#preview .jqzoom img").attr("src", $(img).attr("src"));
    $("#preview .jqzoom img").attr("jqsrc", $(img).attr("bimg"));

    $("#spec-list .spec-items ul li img").removeClass("img-hover");
    $(img).addClass("img-hover");
}

//图片预览小图移动效果,页面加载时触发
$(function () {
    $(".m-tab-trigger li a").click(function () {
        $(".m-tab-trigger li").removeClass("curr");
        var index = $(this).parent().index();

        $(this).parent().addClass("curr");
        $(".ui-switchable-panel").hide();
        $("#product-detail-" + String(index + 1)).show();

    });
    var tempLength = 0; //临时变量,当前移动的长度
    var viewNum = 5; //设置每次显示图片的个数量
    var moveNum = 2; //每次移动的数量
    var moveTime = 300; //移动速度,毫秒
    var scrollDiv = $("#spec-list .spec-items ul"); //进行移动动画的容器
    var scrollItems = $("#spec-list .spec-items ul li"); //移动容器里的集合
    var moveLength = scrollItems.eq(0).width() * moveNum; //计算每次移动的长度
    var countLength = (scrollItems.length - viewNum) * scrollItems.eq(0).width(); //计算总长度,总个数*单个长度

    //下一张
    $("#spec-list #spec-backward").bind("click", function () {

        if (tempLength < countLength) {
            if ((countLength - tempLength) > moveLength) {
                scrollDiv.animate({ left: "-=" + moveLength + "px" }, moveTime);
                tempLength += moveLength;
            } else {
                scrollDiv.animate({ left: "-=" + (countLength - tempLength) + "px" }, moveTime);
                tempLength += (countLength - tempLength);
            }
        }

        initBtn();
    });
    //上一张
    $("#spec-list #spec-forward").bind("click", function () {
        if (tempLength > 0) {
            if (tempLength > moveLength) {
                scrollDiv.animate({ left: "+=" + moveLength + "px" }, moveTime);
                tempLength -= moveLength;
            } else {
                scrollDiv.animate({ left: "+=" + tempLength + "px" }, moveTime);
                tempLength = 0;
            }
        }
        initBtn();
    });
    initBtn();
    function initBtn() {
        if (tempLength == 0) {
            $("#spec-forward").addClass("disabled");


        } else {
            $("#spec-forward").removeClass("disabled");
        }
        if (tempLength >= countLength) {
            $("#spec-backward").addClass("disabled");

        } else {
            $("#spec-backward").removeClass("disabled");
        }

    }
});