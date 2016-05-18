
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


function onclosedialog(result, isedit) {

    if (result.result) {
        //重新加载地址
        if (result.data) {
            if (!isedit) {
                isedit = false;
            }
            result.data = jQuery.parseJSON(result.data);
            if (isedit) {
                //先将之前的删掉
                $("#consignee-list").find(".consignee-item").each(function (index, n) {
                    if ($(n).attr("consigneeid") == result.data.ID) {
                        $(n).parent().remove();
                        return;
                    }
                });
            }

            //将之前选择的去掉，然后添加这个至首位，并处于选中状态，

            $("#consignee-list .ui-switchable-panel-selected").removeClass("ui-switchable-panel-selected").removeAttr("selected");
            $("#consignee-list").find(".item-selected").removeClass("item-selected");
            var contenthtmlarr = [];
            contenthtmlarr.push('<li class="ui-switchable-panel ui-switchable-panel-selected"   style="display: list-item;" selected="selected">');
            contenthtmlarr.push('<div class="consignee-item item-selected"   consigneeid="' + result.data.ID + '">');
            contenthtmlarr.push('<span title="' + result.data.ShipName + '" >' + result.data.ShipName + '</span><b></b></div>');
            contenthtmlarr.push('<div class="addr-detail">');
            contenthtmlarr.push(' <span title="' + result.data.ShipName + '" class="addr-name">' + result.data.ShipName + '</span>');
            contenthtmlarr.push('<span title="' + result.data.PathName + result.data.Address + '" class="addr-info" >' + result.data.PathName + result.data.Address + '</span>');
            contenthtmlarr.push('<span class="addr-tel">' + result.data.CelPhone + '</span></div>');
            contenthtmlarr.push('<div class="op-btns" consigneeid="' + result.data.ID + '">');

            contenthtmlarr.push(' <span></span><a class="ftx-05 setdefault-consignee" href="#none"  consigneeid="' + result.data.ID + '">设为默认地址</a><a class="ftx-05 edit-consignee" href="#none"  consigneeid="' + result.data.ID + '">编辑</a>');
            contenthtmlarr.push('<a class="ftx-05 del-consignee" href="#none" consigneeid="' + result.data.ID + '">删除</a></div> </li>');

            $("#consignee-list").prepend(contenthtmlarr.join(''));
            SetAddr(result.data.ID, $("#consignee-list").find("li").first());
        }
    }

}


function vertualHidOrShow() {
    if ($("#virtualdiv").hasClass("step-toggle-off")) {
        vertualhide();
    } else {
        vertualShow();
    }
}

function vertualhide() {
    $(".order-virtual").css("display", "none");
    $("#virtualdiv").removeClass("step-toggle-off");
    $("#virtualdiv").addClass("step-toggle-on");
}

function vertualShow() {
    $(".order-virtual").css("display", "block");
    $("#virtualdiv").removeClass("step-toggle-on");
    $("#virtualdiv").addClass("step-toggle-off");

}
function showCouponItem(flag) {
    if (flag) {
        $(".coupon-main").show();
        $(".balance-main").hide();
        $("#couponitem").addClass("curr");
        $("#balanceitem").removeClass("curr");
    } else {
        $(".coupon-main").hide();
        $(".balance-main").show();
        $("#balanceitem").addClass("curr");
        $("#couponitem").removeClass("curr");
    }
} window.showCouponItem = showCouponItem;
function showBalanceItem(flag) {
    if (flag) {
        $("#balanceitem").html('<span>余额</span><i></i>');
    } else {
        $("#balanceitem").html('<span>余额</span><i style="display: none"></i>');
    }
} window.showBalanceItem = showBalanceItem;

function useOrCancelBalance(elelment) {

    if ($(elelment).prop("checked")) {
        var PayMoney = $("#order_PayMoney").val() * 1;
        var balance = $("#canUsedBalanceId").find(".ftx-01").text() * 1;
        if (balance > PayMoney) {
            $("#order_UserBalance").val(PayMoney);
        } else {
            $("#order_UserBalance").val(balance);
        }
        if (balance == 0) {
            $("#order_UserBalance").attr("readonly", "readonly");
        } else {
            $("#order_UserBalance").removeAttr("readonly");
        }

    } else {

        $("#order_UserBalance").attr("readonly", "readonly");
        $("#order_UserBalance").val(0);
    }
}
function SetAddr(addressid, element) {

    $("#order_AddressID").val(addressid);

    var name = "";
    var addr = "";
    var tel = "";
    if (element) {
        name = $(element).find(".addr-name").text();
        addr = $(element).find(".addr-info").text();
        tel = $(element).find(".addr-tel").text();
    }
    $(".trade-foot-detail-com").find(".fc-consignee-info > span").first().text("寄送至： " + addr);
    $(".trade-foot-detail-com").find(".fc-consignee-info > span").last().text("收件人：" + name + "   " + tel);
}
function ComputPrice()
{ 
    var total = $("#warePriceId").attr("value") * 1;
    var useCouponValue = $("#useCouponValue").attr("value") * 1;
    var balance = $("#order_UserBalance").val();
    if (!balance) {
        balance = 0;
    } else
    { balance *= 1;}
    
    $("#couponPriceId").val("-￥" + useCouponValue);
    $("#usedBalanceId").val("-￥" + balance);
    $("#total").val("-￥0.00");
    var payMoey = total - useCouponValue - balance;
    $("#order_PayMoney").val(payMoey);
    $("#sumPayPriceId").val("-￥" + payMoey);
}
$(function () {
    $("#order_IsInvoice").bind("change", function () {
        if ($(this).prop("checked")) {
            $("#order_InvoiceInfo").removeAttr("readonly");
            
        }
        else
        {
            $("#order_InvoiceInfo").attr("readonly", "readonly");
            $("#order_InvoiceInfo").val("");
        }
        
    });
    $("#order_UserBalance").bind("change", function () { $("#useBalanceLabel").text($(this).val()); ComputPrice(); });
    $("#consignee-list").delegate(".consignee-item", "click", function () {

        if (!$(this).hasClass("item-selected")) {
            $("#consignee-list .ui-switchable-panel-selected").removeClass("ui-switchable-panel-selected").removeAttr("selected");
            $("#consignee-list").find(".item-selected").removeClass("item-selected");
            $(this).parent().addClass("ui-switchable-panel-selected").attr("selected", "selected");
            $(this).addClass("item-selected");

            SetAddr($(this).attr("consigneeid"), $(this).parent());
        }
    });
    $(".coupons").delegate("li", "click", function () {
        var value = 0;
        if (!$(this).hasClass("selected")) {
            $(".coupons").find(".selected").removeClass("selected");
            $(this).addClass("selected");
            $("#order.Coupon[0].ID").val($(this).attr("couponID"));
              value = $(this).attr("value") * 1;
        } else {
            $(this).removeClass("selected")
            $("#order.Coupon[0].ID").val(""); 
        }
        if (value > 0) {
            $("#useCouponCount").text("1");
        } else {
            $("#useCouponCount").text("");
        }
        $("#useCouponValue").text(value);
        ComputPrice();
    });

    $("#payment-list").delegate(".payment-item", "click", function () {

        if (!$(this).hasClass("item-selected")) {
            $("#payment-list").find(".item-selected").removeClass("item-selected");
            $(this).addClass("item-selected");
            $("#order_PayTypeID").val($(this).attr("payid"));
            var v = $(this).attr("onlinepaytype");
            if (v=="1") {
                $("#order_CashOnDelivery").val("false");
            } else {
                $("#order_CashOnDelivery").val("true");
            }
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
        showFormurl("编辑收件人信息", "/addr/index/" + addrid, function (result) { onclosedialog(result, true) }, { width: 690, height: 417 });

    });
    $("#consignee-list").delegate(".del-consignee", "click", function () {

        var addrid = $(this).attr("consigneeid");
        var self = this;
        $.post("/Addr/delete", { id: addrid }, function (result) {

            if (result.IsSuccess) {
                var paenl = $(self).closest(".ui-switchable-panel");
                if (paenl.hasClass("selected")) {
                    SetAddr("", null);
                } 
                paenl.remove();
                 
            } else {
                openTipsWrong(result.Msg);
            }
        });
    });

    $("#order-submit").bind("click", function () {
        var msg = "";
        //检测有没有选择地址
        var regionid = $("#order_AddressID").val();
        if (!regionid) {
            msg = "请选择收件人地址;";
        }
        //检测在需要发票的情况下，有没有填写发票抬头
        if ($("#order_IsInvoice").prop("checked") && !$("#order_InvoiceInfo").val()) {
            
            msg += "请填写发票抬头;";
        }
        //检测 在使用余额的情况下，使用的金额是否大于余额
        var ye = $("#jdBalance").find("#hasye").text * 1;
        var useye = $("#order_UserBalance").val() * 1;
        if (useye>ye) {
            
            msg += "使用的余额超出了您剩余的余额,请修改;";
        }
        //检测支付金额是否小于0
        var paymoety = $("#order_PayMoney").val() * 1;
        if (paymoety <0) {
             
            msg += "支付余额不能小于0,请修改优惠券或使用的余额;";
        }


        $("#submit_check_info_message").html(msg);
        if (msg) {
            $("#submit_check_info_message").show();
        } else {
            $("form").submit();

        }
        



    });
});