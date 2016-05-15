 
function show_ConsigneeAll() {
    $("#consigneeItemAllClick").addClass("hide");
    $("#consigneeItemHideClick").removeClass("hide");
    $("#consignee1").removeClass("consignee-off");
    $("#del_consignee_type").val("0");
    $(".consignee-item").parents("li").css("display", "list-item");
    var _height = ($('.ui-scrollbar-main .consignee-scroll ul li').length * 42) + "px";
    $('.consignee-cont').css({ 'height': _height });
    $('.ui-scrollbar-wrap').css({ 'height': _height });
    
     
} window.show_ConsigneeAll = show_ConsigneeAll;

/**
 * update by lilong 20150511
 * ！！！注意：仅供前台更新收货人列表位置使用，不更新服务端数据不更新缓存
 * 点击【收起地址】功能，自动将选中追加至默认地址后第二位，如果没有默认地址则自动排在第一位
 */
function hide_ConsigneeAll() {
    $("#consigneeItemAllClick").removeClass("hide");
    $("#consigneeItemHideClick").addClass("hide");
    $("#consignee1").addClass("consignee-off");
    $("#del_consignee_type").val("1");
    $('.consignee-cont').css({ 'height': '42px' });
    $('.ui-scrollbar-bg').css('display', 'none');
    $('.ui-scrollbar-item-consignee').css('display', 'none');
    $('.ui-scrollbar-wrap').css('height', '42px');
    $('#consignee-content ul').css({
        'top': '0px',
        'position': 'absolute'
    });
    // 地址列表切换至第一页
    var li_selected = $(".consignee-item.item-selected").parent("li");//当前选中li
    var first_li = $(".consignee-item").parents("li").last();//当前列表第一项
    var _tempstr = first_li.find("div span").find(".addr-default").html();
    if (_tempstr && _tempstr.indexOf("默认地址") > -1) {
        // 1.插入在默认地址之后
        li_selected.clone().insertAfter(first_li);
    } else {
        // 2.插入在地址列表第一位
        li_selected.clone().insertBefore(first_li);
    }
    li_selected.remove();
    // 收起并定位第一页功能
    $(".consignee-item").parents("li").css("display", "none");
    $(".consignee-item.item-selected").parent("li").css("display", "list-item");
     
    // 初始化地址组件的绑定事件，否则移动dom会导致绑定失效，因此改动组件采用delegate绑定
} window.hide_ConsigneeAll = hide_ConsigneeAll;

$(function () {
    $('#consignee-addr')
        .delegate('li', 'mouseenter', function () {
            $(this).addClass('li-hover');
        })
        .delegate('li', 'mouseleave', function () {
            $(this).removeClass('li-hover');
        });
});

function AddAddr(url) {

    showFormurl("新增收件人信息", url, onclosedialog, { width: 690, height: 417 });

}


function onclosedialog(result,isedit) {

    if (result.result) {
        //重新加载地址
        if (result.data) {
            if (!isedit) {
                isedit = false;
            }
            result.data=  jQuery.parseJSON(result.data);
            if (isedit) {
                //先将之前的删掉
                $("#consignee-list").find(".consignee-item").each(function (index,n)
                {
                    if ($(n).attr("consigneeid")== result.data.ID) {
                        $(n).parent().remove();
                        return;
                    }
                } ); 
            }
           
            //将之前选择的去掉，然后添加这个至首位，并处于选中状态，

            $("#consignee-list .ui-switchable-panel-selected").removeClass("ui-switchable-panel-selected").removeAttr("selected");
            $("#consignee-list").find(".item-selected").removeClass("item-selected"); 
            var contenthtmlarr = [];
            contenthtmlarr.push('<li class="ui-switchable-panel ui-switchable-panel-selected"   style="display: list-item;" selected="selected">');
            contenthtmlarr.push('<div class="consignee-item item-selected"   consigneeid="' + result.data.ID + '">');
            contenthtmlarr.push('<span title="' + result.data.ShipName + '" >' + result.data.ShipName + '</span><b></b></div>');
            contenthtmlarr.push('<div class="addr-detail">');
            contenthtmlarr.push(' <span title="' + result.data.ShipName + '" class="addr-name">' + result.data.ShipName + '</span>' );
            contenthtmlarr.push('<span title="' + result.data.PathName + result.data.Address + '" class="addr-info" >' + result.data.PathName + result.data.Address + '</span>');
            contenthtmlarr.push('<span class="addr-tel">' + result.data.CelPhone + '</span></div>');
            contenthtmlarr.push('<div class="op-btns" consigneeid="' + result.data.ID + '">');
            
            contenthtmlarr.push(' <span></span><a class="ftx-05 setdefault-consignee" href="#none"  consigneeid="' + result.data.ID + '">设为默认地址</a><a class="ftx-05 edit-consignee" href="#none"  consigneeid="' + result.data.ID + '">编辑</a>');
            contenthtmlarr.push('<a class="ftx-05 del-consignee" href="#none" consigneeid="' + result.data.ID + '">删除</a></div> </li>');
            
            $("#consignee-list").prepend(contenthtmlarr.join(''));
        }
    }

}

$(function () {
    $("#consignee-list").delegate(".consignee-item", "click", function () {
       
        if (!$(this).hasClass("item-selected")) {
            $("#consignee-list .ui-switchable-panel-selected").removeClass("ui-switchable-panel-selected").removeAttr("selected");
            $("#consignee-list").find(".item-selected").removeClass("item-selected");
            $(this).parent().addClass("ui-switchable-panel-selected").attr("selected", "selected");
            $(this).addClass("item-selected");
        }
    });
    
    $("#consignee-list").delegate(".setdefault-consignee", "click", function () {
        var addrid = $(this).attr("consigneeid");
        var self = this;
        $.post("/addr/setdefault", { id: addrid }, function (result) {

            if (result.IsSuccess) {
                //去掉之前的默认标识
                $("#consignee-list").find('.addr-default').remove();
                //添加新默认标识
                $(self).parent().prev().append('<span class="addr-default">默认地址</span>');
            } else {
                openTipsWrong(result.Msg);
            }
        });
    });
   
    $("#consignee-list").delegate(".edit-consignee", "click", function () {
        var addrid = $(this).attr("consigneeid");
        showFormurl("编辑收件人信息", "/addr/index/" + addrid, function (result) { onclosedialog(result,true) }, { width: 690, height: 417 });
        
    });
    $("#consignee-list").delegate(".del-consignee", "click", function () {

        var addrid = $(this).attr("consigneeid");
        var self = this;
        $.post("/Addr/delete", { id: addrid }, function (result) {

            if (result.IsSuccess) {
               
               
                //添加新默认标识
                $(self).closest(".ui-switchable-panel").remove();
            } else {
                openTipsWrong(result.Msg);
            }
        });
    });
});