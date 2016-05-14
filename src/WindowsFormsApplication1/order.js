seajs.use([
    "jdf/1.0.0/unit/globalInit/2.0.0/globalInit.js",
    "jdf/1.0.0/ui/lazyload/1.0.0/lazyload",
    "jdf/1.0.0/ui/switchable/1.0.0/switchable",
    "jdf/1.0.0/ui/tips/1.0.0/tips",
    "jdf/1.0.0/ui/dialog/1.0.0/dialog",
    "jdf/1.0.0/ui/placeholder/1.0.0/placeholder",
    "jdf/1.0.0/ui/scrollbar/1.0.0/scrollbar",
    "jdf/1.0.0/ui/drag/1.0.0/drag",
    "user/purchase/2.0.0/js/purchase-recommend",
    "user/purchase/2.0.0/js/subtwl"
  ], function (globalInit,lazyload,switchable,tips,dialog,placeholder,scrollbar,drag,someMoreRecommend,subtwl){//FE 模块加载 start
  globalInit();
  //$.ajaxSettings.async = false;  

//*************************公共方法和变量*************************
var cartUrl = OrderAppConfig.Protocol+"cart.jd.com";
var lipinkaPhysicalUrl = OrderAppConfig.Protocol+"market.jd.com/giftcard/#entity";
var orderUrl = OrderAppConfig.Domain+"/order/getOrderInfo.action";

/**
 * 清除submit错误消息
 */
function cleanSubmitMessage() {
  $("#submit_message").html("");
  $("#submit_message").hide();
}

function subStr(id){
  $(id).each(function(){ 
    var objString = $.trim($(this).text());
    if(objString.indexOf("...") == -1){
    var objLength = $.trim($(this).text()).length;
    var num = $(this).attr('limit');
    $(this).attr('title',objString); 
    if(objLength > num)
      objString = $(this).text(objString.substring(0,num) + '...'); 
    }
  });
}window.subStr=subStr;

function subStrConsignee(){
	//新地址标签
	  $(".consignee-item").not(".addr-more").each(function(){ 
	    	var addressName = $(this).find("span").text();
	    	if(isEmpty(addressName)){
	    		setOneSpanAlias($(this));
	    	}else{
	    		var num = $(this).find("span").attr('limit');
	    		$(this).find("span").text(addressName.substring(0,num));
	    	}
	  });
	  //老版功能
	 // setConsigneeAiles();
  subStr(".addr-detail .addr-name");
  subStr(".addr-detail .addr-info");
}window.subStrConsignee=subStrConsignee;

function setOneSpanAlias(id){
	  var selectDiv = $(id).next();
      var consignee = selectDiv.find(".addr-info").text().split(' ')[0];
      var name = $.trim(selectDiv.find(".addr-name").text());
      var objLength = name.length;
      var num = $(id).find("span").attr('limit');
      $(id).find("span").attr('title',name);
      if(objLength > num)
        $(id).find("span").text(name.substring(0,num) + '... ' + consignee);
      else
        $(id).find("span").text(name + ' ' + consignee);	
}


//默认设置地址别名
function setConsigneeAlies(){
  $(".consignee-item").not(".addr-more").each(function(){ 
	    if($(this).next().next().find("a").size() != 2){
	      var selectDiv = $(this).next();
	      var consignee = selectDiv.find(".addr-info").text().split(' ')[0];
	      var name = $.trim(selectDiv.find(".addr-name").text());
	      var objLength = name.length;
	      var num = $(this).find("span").attr('limit');
	      $(this).find("span").attr('title',name);
	      if(objLength > num)
	        $(this).find("span").text(name.substring(0,num) + '... ' + consignee);
	      else
	        $(this).find("span").text(name + ' ' + consignee);
	    }
	  });
}


/**
 * 判断服务是否返回有消息【此方法别动】
 *
 * @param data
 * @returns {Boolean}
 */
function isHasMessage(data) {
  if (data.errorMessage) {
    return true;
  } else {
    try {
      if (data != null && data.indexOf("\"errorMessage\":") > -1) {
        var mesageObject = eval("(" + data + ")");
        if (mesageObject != null && mesageObject.errorMessage != null) {
          return true;
        }
      }
    } catch (e) {}
  }
  return false;
}
window.isHasMessage = isHasMessage;

/**
 * 将消息返回【此方法别动】
 * 
 * @param data
 * @return
 */
function getMessage(data) {
  if (data.errorMessage) {
    return data.errorMessage;
  } else {
    try {
      var mesageObject = eval("(" + data + ")");
      if (mesageObject != null && mesageObject.errorMessage != null && mesageObject.errorMessage != "") {
        return mesageObject.errorMessage;
      }
    } catch (e) {}
  }
  return null;
}
window.getMessage = getMessage;

/**
 * 判断用户是否登录【此方法别动】
 */
function isUserNotLogin(data) {
  if (data.error == "NotLogin") {
    return true;
  } else {
    try {
      var obj = eval("(" + data + ")");
      if (obj != null && obj.error != null && obj.error == "NotLogin") {
        return true;
      }
    } catch (e) {
    }
  }
  return false;
}window.isUserNotLogin=isUserNotLogin;

/**
 * 去登录页面
 */
function goToLogin() {
  if (isLocBuy()) {
    window.location.href = OrderAppConfig.LoginLocUrl + "?rid=" + Math.random();
  } else {
    window.location.href = OrderAppConfig.LoginUrl + "?rid=" + Math.random();
  }
}window.goToLogin=goToLogin;

/**
 * 去购物车页面
 */
function goCart() {
  if (isLipinkaPhysical()) {
    window.location.href = lipinkaPhysicalUrl;
  } else {
    if(g_outSkus){
      if(g_noStockType == "600158"){
        log('gz_ord', 'gz_proc', 6, 'qbwhfhgwc');
      }else if(g_noStockType == "600157"){
        log('gz_ord', 'gz_proc', 6, 'bfwhfhgwc');
      }
      window.location.href = cartUrl + '?outSkus=' + g_outSkus + '&rid=' + Math.random();
    }else{
      window.location.href = cartUrl + "?rid=" + Math.random();
    }
  }

}window.goCart=goCart;
/**
 * 刷新结算页面
 */
function goOrder() {
  
  var isUnregister = $("#isUnregister").val();
  if (isUnregister || isUnregister == "true") {
    window.location.href = orderUrl + "?rid=" + Math.random();
  }
  else {
    var href = window.location.href;
    var url = href;
    if(href.indexOf(".action") > -1){
      url = href.substring(0,href.indexOf(".action")+7)+"?rid=" + Math.random();
    }
    if($("#flowType").val() == 10){
      url = addFlowTypeParam(url);
    }
    window.location.href = url;   
  }
}window.goOrder=goOrder;

/**
 * 大家电刷新结算页面
 */
function bigItemGoOrder() {
  var href = window.location.href;
  var url = href;
  if(href.indexOf(".action") > -1){
    url = href.substring(0,href.indexOf(".action")+7)+"?t=1&rid=" + Math.random();
  }
  if($("#flowType").val() == 10){
    url = addFlowTypeParam(url);
  }
  window.location.href = url;
}window.bigItemGoOrder=bigItemGoOrder;

// ******************************************************收货地址开始**************************************************************
/**
 * 获取收货地址列表
 * 
 * @param consigneeId
 */
function consigneeList(selectId) {
  $('.consignee-cont').css({'height':'42px'});
  $('.ui-scrollbar-wrap').css('height', '42px');
  var isUnregister = $("#isUnregister").val();
  // 如果是免注册下单，不用获取收货地址列表
  if (isUnregister || isUnregister == "true") return;
  
  var flowType =  $("#flowType").val();
  if(flowType == 1 || flowType == 13){
    return;
  }
  var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/consigneeList.action";
  var consigneeId = $("#consignee_id").val();
  if (isEmpty(consigneeId)) {
    consigneeId = 0;
  }
  var param = "consigneeParam.id=" + consigneeId;
  // param = addFlowTypeParam(param);
  jQuery.ajax({
    type: "POST",
    dataType: "text",
    url: actionUrl,
    data: param,
    cache: false,
    success: function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      
      // 服务器返回异常处理,如果有消息div则放入,没有则弹出
      if (isHasMessage(dataResult)) {
        goOrder();
        return;
      }
      // 成功后如果有divID直接放入div，没有则返回结果
      else {
        $("#consignee-list").append(dataResult);
        itemListOver.init("#consignee-list");
        var commonConsigeeSize = $("#hidden_consignees_size").val();
        var consigneeSize = parseInt(commonConsigeeSize);
        if ($("#isOpenConsignee").val() == 1) {
          $("#hidden_consignees_size").val(consigneeSize = consigneeSize - 1);
        }
        if (consigneeSize == 1 || consigneeSize == 0) {
          $("#consigneeItemAllClick").addClass("hide");
          $("#consigneeItemHideClick").addClass("hide");
        } else if (consigneeSize > 1) {
           var selectDiv = $(".consignee-item").next().next();
           selectDiv.find(".del-consignee").removeClass("hide");
           selectDiv.find(".setdefault-consignee").removeClass("hide");
           $("#consigneeItemAllClick").removeClass("hide");
           $("#consigneeItemHideClick").addClass("hide");
           $('.ui-scrollbar-main .consignee-scroll ul li').first().nextAll().hide();
        }
        if (checkIsNewUser()) {
          if ($(".consignee-item").length > 1) {
            $(".consignee-item").first().click();
          } else {
              if (isLocBuy()) {
              edit_LocConsignee();
            } else {
              use_NewConsignee();
            }
          }
        }
        
        //yanwenqi 国际够增加身份证idcard 如果是国际购，判断是否有身份证号，没有就弹出让 他编辑
        if(flowType == 10){
          var selectDiv = $(".consignee-item.item-selected").next();
          var idCard = selectDiv.find(".addr-idCard").html();
 
          if(idCard == "未完善身份证信息"){
            $(".consignee-item.item-selected").next().next().find(".edit-consignee").click();
          }
        }
        //end
      }
    subStrConsignee();
    },
    error: function(XMLHttpResponse) {
      //ignore
    }
  });
}
window.consigneeList = consigneeList;
//异步加载收货人列表
consigneeList();

window.consigneeScroll = null;
function show_ConsigneeAll(){
  $("#consigneeItemAllClick").addClass("hide");
  $("#consigneeItemHideClick").removeClass("hide");
  $("#consignee1").removeClass("consignee-off");
  $("#del_consignee_type").val("0");
  $(".consignee-item").parents("li").css("display","list-item");
  var _height = ($('.ui-scrollbar-main .consignee-scroll ul li').length * 42)+"px";
  $('.consignee-cont').css({'height': _height});
  $('.ui-scrollbar-wrap').css({'height':_height});
  //收货人地址滑动 start
  if($('.ui-scrollbar-main .consignee-scroll ul li').length > 4) {
	  if(consigneeScroll) {
		  consigneeScroll.resetUpdate($('.ui-scrollbar-main .consignee-scroll ul li').length);
	  } else {
		  consigneeScroll = $('.consignee-scrollbar').scrollbar({
		       width: 11,
		       scrollClass: 'ui-scrollbar-item-consignee', 
		       mainClass: 'ui-scrollbar-main',
		       hasHeadTail: false,
		       limit: true,
		       wrapHeight: 168
		   });
		  consigneeScroll.resetUpdate = function(length) {
			  //$("#del_consignee_type").val() 展开修改成0  收起修改成1  新增修改成0
			  var flag = $("#del_consignee_type").val();
			  if(flag == "0"){
		        var _height = (length * 42);
		        $('.consignee-cont').css({'height': _height+"px"});
		        if(_height >= 168) {
		          $('.ui-scrollbar-wrap').css({'height': '168px'});
		        } else {
		          $('.ui-scrollbar-wrap').css({'height': _height+"px"});
		        }
		      }
		      if(length>4 && flag == "0"){// 展开状态才显示，否则保持不变
		        $('.ui-scrollbar-bg').css({'display': 'block', 'top': '0'});
		        $('.consignee-scrollbar').css('position', 'absolute');
		      }else{
		        $('.ui-scrollbar-bg').css('display', 'none');
		        $('.consignee-scrollbar').css({'height': '', 'position': ''});
		      }  
		      this.update();
		  };
	  }
  }
  //end
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
  $('.consignee-cont').css({'height':'42px'});
  $('.ui-scrollbar-bg').css('display', 'none');
  $('.ui-scrollbar-item-consignee').css('display', 'none');
  $('.ui-scrollbar-wrap').css('height', '42px');
  $('#consignee-content ul').css({
    'top': '0px',
    'position':'absolute'
  });
  // 地址列表切换至第一页
  var li_selected = $(".consignee-item.item-selected").parent("li");//当前选中li
  var first_li = $(".consignee-item").parents("li").last();//当前列表第一项
  var _tempstr = first_li.find("div span").find(".addr-default").html();
  if(_tempstr && _tempstr.indexOf("默认地址") > -1) {
    // 1.插入在默认地址之后
    li_selected.clone().insertAfter(first_li);
  } else {
    // 2.插入在地址列表第一位
    li_selected.clone().insertBefore(first_li);
  }
  li_selected.remove();
  // 收起并定位第一页功能
  $(".consignee-item").parents("li").css("display","none");
  $(".consignee-item.item-selected").parent("li").css("display","list-item");
  if(consigneeScroll) {
	  //滚轮从新定位
	  consigneeScroll.goTop();
  }
  // 初始化地址组件的绑定事件，否则移动dom会导致绑定失效，因此改动组件采用delegate绑定
} window.hide_ConsigneeAll = hide_ConsigneeAll;

function setResetFlag(index,value){
  //第一给打1表示进入结算页和切换地址时执行判断是否自动选中自提逻辑
  if(index > 9||!(value == '0'||value == '1')){
    return;
  }
  var resetFlag_arr = $("#resetFlag").val().split("");
  resetFlag_arr[index]=value;
  $("#resetFlag").val(resetFlag_arr.join(""));
}window.setResetFlag = setResetFlag;
function initResetFlag(){
  $("#resetFlag").val("0000000000");
}window.initResetFlag = initResetFlag;
/**
 * 保存收货地址（包含保存常用人收货地址，根据id区分）
 */
function tab_save_Consignee(isGiftBy) {
  $("body").append('<div id="g-loading" class="purchase-loading"><div class="loading-cont"></div></div>');
  var id = $("#consignee-list .item-selected").attr("consigneeId");
  
  if (id == undefined || id == null || id == "" || id == 0) {
    goOrder();
    delayRemoveLoading('#g-loading');
    return;
  }
  if(!isGiftBy) {
    if (id == $("#consignee_id").val()) {
        delayRemoveLoading('#g-loading');
        return;
      }
  }
  //yanwenqi 全球购添加身份验证，如果用户选择其他收货人时，判断是否有身份证 
  var flowType =  $("#flowType").val();
  if(flowType == 10){
    var selectDiv = $(".consignee-item.item-selected").next();
    var idCard = selectDiv.find(".addr-idCard").html();
     
    if(idCard == "未完善身份证信息"){
      $(".consignee-item.item-selected").next().next().find(".edit-consignee").click();
    }
  }
  //end
  
  // 如果不隐藏重新获取用户填写的信息
  var consignee_id = id;
  var consignee_type = null;
  var isUpdateCommonAddress = 0;
  var consignee_commons_size = $("#hidden_consignees_size").val();
  var giftSender_consignee_name = "";
  var giftSender_consignee_mobile = "";
  var noteGiftSender = false;
  if(isGiftBuy()){
    noteGiftSender= true;
    giftSender_consignee_name = $("#consigneeList_giftSenderConsigneeName").val();
    giftSender_consignee_mobile = $("#consigneeList_giftSenderConsigneeMobile").val();
  }
  consignee_id = id;
  if (consignee_type == "")
    consignee_type = 1;
  var param = "consigneeParam.id=" + consignee_id + "&consigneeParam.type=" + consignee_type + "&consigneeParam.commonConsigneeSize=" + consignee_commons_size + "&consigneeParam.isUpdateCommonAddress=" + isUpdateCommonAddress + "&consigneeParam.giftSenderConsigneeName=" + giftSender_consignee_name + "&consigneeParam.giftSendeConsigneeMobile=" + giftSender_consignee_mobile + "&consigneeParam.noteGiftSender=" + noteGiftSender;
  param = addFlowTypeParam(param);
  var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/saveConsignee.action";
  jQuery.ajax({
    type: "POST",
    dataType: "json",
    url: actionUrl,
    data: param,
    cache: false,
    success: function(consigneeResult, textStatus) {
      if (isUserNotLogin(consigneeResult)) {
        goToLogin();
        delayRemoveLoading('#g-loading');
        return;
      }
      if (consigneeResult.success) {
        var invoiceHtml = $("#part-inv").html();
        if (consigneeResult.restInvoiceByAddress == 22) {
          $("#part-inv").html(invoiceHtml.replace("办公用品", "办公用品（附购物清单）"));
        }
        if (consigneeResult.restInvoiceByAddress == 2) {
          $("#part-inv").html(invoiceHtml.replace("（附购物清单）", ""));
        }
        if (consigneeResult.supportElectro) {
          if(null != consigneeResult.restInvoiceCompanyName){
             $("#part-inv").html("<span class='mr10'>普通发票（纸质）&nbsp; </span><span class='mr10'> "+consigneeResult.restInvoiceCompanyName+"&nbsp; </span><span class='mr10'>明细&nbsp; </span><a onclick='edit_Invoice()' class='ftx-05 invoice-edit' href='#none'>修改</a>");
          }else{
             $("#part-inv").html("<span class='mr10'>普通发票（纸质）&nbsp; </span><span class='mr10'> 个人&nbsp; </span><span class='mr10'>明细&nbsp; </span><a onclick='edit_Invoice()' class='ftx-05 invoice-edit' href='#none'>修改</a>");
          }
        }
        if (consigneeResult.defaultElectro) {
          $("#part-inv").html("<span class='mr10'>普通发票（电子）&nbsp; </span><span class='mr10'> 个人&nbsp; </span><span class='mr10'>明细&nbsp; </span><a onclick='edit_Invoice()' class='ftx-05 invoice-edit' href='#none'>修改</a>");
        }
        if (consigneeResult.resultCode == "isRefreshArea") {
          openEditConsigneeDialog(consignee_id);
        } else {
          restData();
          var areaIds=consigneeResult.consigneeShowView.provinceId + "-" + consigneeResult.consigneeShowView.cityId + "-" + consigneeResult.consigneeShowView.countyId + "-" + consigneeResult.consigneeShowView.townId;
          // 弹出对应提示
          $("#consignee-ret").html(consigneeResult.consigneeHtml); //弹出对应提示
          $("#consignee_id").val(consigneeResult.consigneeShowView.id);
          $("#hideAreaIds").val(areaIds);
          if (isBigItemChange())
            bigItemChangeArea();
          if (hasTang9())
            tang9ChangeArea();
          setResetFlag(0,'1');
          save_Pay(0);
          openConsignee();
          consigneeInfo();
          if ($("#isPresale").val() == "true") {
            $("#hiddenUserMobileByPresale").val(consigneeResult.consigneeShowView.mobile);
            if ($("#presaleMobile input").size() > 0) {
              $("#presaleMobile input").val(consigneeResult.consigneeShowView.mobile);
            } else if ($("#userMobileByPresale").size() > 0) {
              $("#userMobileByPresale").html(consigneeResult.consigneeShowView.mobile);
            }
          }
        }
        //重新加载优惠券列表
        if($("#invokeNewCouponInterface").val() != "true"){
          reloadCoupon(consigneeResult.reloadCoupon);
        }else{
          reloadCouponNew(consigneeResult.reloadCoupon);
          reloadGiftCard();
        }
      } else {
        delayRemoveLoading('#g-loading');
        openEditConsigneeDialog(consignee_id);
        return;
      }
      delayRemoveLoading('#g-loading');
    },
    error: function(XMLHttpResponse) {
      goOrder();
      delayRemoveLoading('#g-loading');
      return;
    }
  });
}
window.tab_save_Consignee = tab_save_Consignee;

function gift_save_Consignee()
{  
  if(!checkGiftUserName()) return false;
  if(!checkGiftMobile())   return false;
  //$("#consignee_id").val(-1);
  tab_save_Consignee(true);
  var gift_user_mobile = $("#consigneeList_giftSenderConsigneeMobile").val();
  var sNum = "****";
  var begin = 3;
  var gift_user_mobile_dis = gift_user_mobile.substring(0,begin)+sNum+gift_user_mobile.substring(sNum.length+begin);
  $("#gift_user_name").html($("#consigneeList_giftSenderConsigneeName").val());
  if(!(gift_user_mobile.indexOf("*")>0))
  {
    $("#gift_user_mobile").html(gift_user_mobile_dis);
  }
  else
  {
    $("#consigneeList_giftSenderConsigneeMobile").val($("#gift_user_mobile").html().replace(/(^\s*)|(\s*$)/g,''));
  }
  $("#gift_info").show();
  $("#gift_input").hide();
}
window.gift_save_Consignee = gift_save_Consignee;

function checkGiftMobile()
{
  var value = $("#consigneeList_giftSenderConsigneeMobile").val();
  if(value == '')
  {
    $("#error_gift_mobile").show();
    $("#error_gift_mobile").html("电话号码不能为空");
    $("#consigneeList_giftSenderConsigneeMobile").focus();
    return false;
  }
  if (!(check_mobile(value) || new RegExp(/^\d{3}\*\*\*\*\d{4}$/).test(value)))
  {
    $("#error_gift_mobile").show();
    $("#error_gift_mobile").html("电话号码格式不正确");
    $("#consigneeList_giftSenderConsigneeMobile").focus();
    return false;
  }
  $("#error_gift_mobile").hide();
  return true;
}
window.checkGiftMobile = checkGiftMobile;

function checkGiftUserName()
{
  if($("#consigneeList_giftSenderConsigneeName").val()=='')
  {
    $("#error_gift_name").show();
    $("#error_gift_name").html("送礼人不能为空");
    $("#consigneeList_giftSenderConsigneeName").focus();
    return false;
  }
  
  if(!/^[a-zA-Z\u4e00-\u9fa5\\.]{0,20}$/i.test($("#consigneeList_giftSenderConsigneeName").val())){
    $("#error_gift_name").show();
    $("#error_gift_name").html("送礼人只能包含中文或字母");
    $("#consigneeList_giftSenderConsigneeName").focus();
    return false;
  }
  $("#error_gift_name").hide();
  return true;
}
window.checkGiftUserName = checkGiftUserName;

function editGiftUserInfo()
{
  $("#gift_info").hide();
  $("#gift_input").show();
}

window.editGiftUserInfo = editGiftUserInfo;
/**
 * 删除收货人地址
 */
function delete_Consignee(id) {
  $.closeDialog();
  var commonConsigeeSize = $("#hidden_consignees_size").val();
  var consigneeSize = parseInt(commonConsigeeSize);
  var param = "consigneeParam.id=" + id;
  var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/deleteConsignee.action";
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      if (isHasMessage(dataResult)) {
        showMessageWarn(getMessage(dataResult));
      } else {
        if (consigneeSize > 1) {
          consigneeSize = consigneeSize - 1;
          $("#hidden_consignees_size").val("" + consigneeSize);
        }
        $("#consignee_index_" + id).remove();
        if(window.consigneeScroll) {
          consigneeScroll.resetUpdate(consigneeSize);
	  	}
        // 如果没有选中的则默认选中第一个地址
        if($("#consignee_id").val()==id) {
        	$(".consignee-item").first().click().parent().css("display", "list-item");
        }
        if(consigneeSize == 1){
          var selectDiv = $(".consignee-item.item-selected").next().next();
          selectDiv.find(".del-consignee").addClass("hide");
          selectDiv.find(".setdefault-consignee").addClass("hide");
          $("#consigneeItemAllClick").addClass("hide");
          $("#consigneeItemHideClick").addClass("hide");
        }
      }
    },
    error : function(XMLHttpResponse) {
      goOrder();
      return false;
    }
  });
}window.delete_Consignee = delete_Consignee;

/**
 * 使用新收货人地址
 */
function use_NewConsignee() {
  if (checkMaxConsigneeSize()) {
    showLargeMessage('地址限制','您的地址数，已经达到限制个数！');
    return;
  }
  $('body').dialog({
    title:'新增收货人信息',
    width:690,
    height:330,
    type:'iframe',
    source:OrderAppConfig.DynamicDomain + "/consignee/editConsignee.action"
  });
}window.use_NewConsignee=use_NewConsignee;

/**
 * 设置默认收货人地址
 */
function setAllDefaultAddress(id) {
  var param = "consigneeParam.id=" + id;
  var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/setAllDefaultAddress.action";
  param = addFlowTypeParam(param);
  jQuery.ajax( {
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      if (isHasMessage(dataResult)) {
        showMessageWarn(getMessage(dataResult));
      } else {
        $("#consignee-list").find(".consignee-item").each(function() {
          if ($(this).attr("consigneeid") != null) {
            $(this).next().next().find("span").remove();
            if($(this).attr("consigneeid") == id){
              $(this).next().next().find("a:first").remove();
              $(this).next().next().prepend("<span></span>");
              $(this).next().find("span:last").after("<span class='addr-default'>默认地址</span>");
              //$(this).find("span").text("默认地址");
            }else{
              if($(this).next().next().find("a").size() == 2){
                $(this).next().next().prepend("<a href='#none' class='ftx-05 setdefault-consignee' fid='"+$(this).attr("consigneeid")+"'>设为默认地址</a>");
                $(this).next().find("span:last").remove();
              }
            }
          }
        });
        subStrConsignee();
      }
    },
    error : function(XMLHttpResponse) {
      goOrder();
      //alert("系统繁忙，请稍后再试！");
      return false;
    }
  });
}window.setAllDefaultAddress=setAllDefaultAddress;

function consigneeInfo(){
  var selectDiv = $(".consignee-item.item-selected").next();
  var address = selectDiv.find(".addr-info").html();
  var name = selectDiv.find(".addr-name").html();
  var phone = selectDiv.find(".addr-tel").html();
  var info="<span class=\"mr20\">寄送至："+address+"</span>" + "<span>收货人："+name+" "+phone+"</span>";
  $(".fc-consignee-info").html(info);
}window.consigneeInfo=consigneeInfo;

/**
 * 验证收货地址消息提示
 * 
 * @param divId
 * @param value
 */
function check_Consignee(divId) {
  var errorFlag = false;
  var errorMessage = null;
  var value = null;
  // 验证收货人名称
  if (divId == "name_div") {
    value = $("#consignee_name").val();
    if (isEmpty(value)) {
      errorFlag = true;
      errorMessage = "请您填写收货人姓名";
    }
    if (value.length > 25) {
      errorFlag = true;
      errorMessage = "收货人姓名不能大于25位";
    }
    if (!is_forbid(value)) {
      errorFlag = true;
      errorMessage = "收货人姓名中含有非法字符";
    }
  }
  // 验证邮箱格式
  else if (divId == "email_div") {
    value = $("#consignee_email").val();
    if (!isEmpty(value)) {
      if (!check_email(value)) {
        errorFlag = true;
        errorMessage = "邮箱格式不正确";
      }
    } else {
      if (value.length > 50) {
        errorFlag = true;
        errorMessage = "邮箱长度不能大于50位";
      }
    }
  }
  // 验证地区是否完整
  else if (divId == "area_div") {
    var provinceId = $("#consignee_province").find("option:selected").val();
    var cityId = $("#consignee_city").find("option:selected").val();
    var countyId = $("#consignee_county").find("option:selected").val();
    var townId = $("#consignee_town").find("option:selected").val();
    // 验证地区是否正确
    if (isEmpty(provinceId) || isEmpty(cityId) || isEmpty(countyId)
        || ($("#span_town").html() != null && $("#span_town").html() != "" && !$("#span_town").is(":hidden") && isEmpty(townId))) {
      errorFlag = true;
      errorMessage = "请您填写完整的地区信息";
    }
  }
  // 验证收货人地址
  else if (divId == "address_div") {
    value = $("#consignee_address").val();
    if (isEmpty(value)) {
      errorFlag = true;
      errorMessage = "请您填写收货人详细地址";
    }
    if (!is_forbid(value)) {
      errorFlag = true;
      errorMessage = "收货人详细地址中含有非法字符";
    }
    if (value.length > 50) {
      errorFlag = true;
      errorMessage = "收货人详细地址过长";
    }
  }
  // 验证手机号码
  else if (divId == "call_mobile_div") {
    value = $("#consignee_mobile").val();
    divId = "call_div";
    if (isEmpty(value)) {
      errorFlag = true;
      errorMessage = "请您填写收货人手机号码";
    } else {
      if (!check_mobile(value)) {
        errorFlag = true;
        errorMessage = "手机号码格式不正确";
      }
    }
    if (!errorFlag) {
      value = $("#consignee_phone").val();
      if (!isEmpty(value)) {
        if (!is_forbid(value)) {
          errorFlag = true;
          errorMessage = "固定电话号码中含有非法字符";
        }
        if (!checkPhone(value)) {
          errorFlag = true;
          errorMessage = "固定电话号码格式不正确";
        }
      }
    }
  }
  // 验证电话号码
  else if (divId == "call_phone_div") {
    value = $("#consignee_phone").val();
    divId = "call_div";
    if (!isEmpty(value)) {
      if (!is_forbid(value)) {
        errorFlag = true;
        errorMessage = "固定电话号码中含有非法字符";
      }
      if (!checkPhone(value)) {
        errorFlag = true;
        errorMessage = "固定电话号码格式不正确";
      }
    }
    if (true) {
      value = $("#consignee_mobile").val();
      if (isEmpty(value)) {
        errorFlag = true;
        errorMessage = "请您填写收货人手机号码";
      } else {
        if (!check_mobile(value)) {
          errorFlag = true;
          errorMessage = "手机号码格式不正确";
        }
      }
    }
  }
  if (errorFlag) {
    $("#" + divId + "_error").html(errorMessage);
    $("#" + divId).addClass("message");
    return false;
  } else {
    $("#" + divId).removeClass("message");
    $("#" + divId + "_error").html("");
  }
  return true;
}window.check_Consignee=check_Consignee;

/**
 * 检查地址是否是最大数量
 * 
 * @returns {Boolean}
 */
function checkMaxConsigneeSize() {
  var isMaxConsigneeSize = false;
  var commonConsigeeSize = $("#hidden_consignees_size").val();
  if (commonConsigeeSize >= 20)
    isMaxConsigneeSize = true;
  return isMaxConsigneeSize;
}window.checkMaxConsigneeSize=checkMaxConsigneeSize;


// ******************************************************保存支付**************************************************************
/**
 * 保存支付与配送方式
 */
function save_Pay(type, onlineType) {
  if($("#flowType").val()=="1" || $("#flowType").val()=="13"){
    loadSkuList();
    return;
  }
  var payId;
  var otype;
  if(type == null || type == "" || type == "undefined" || type == undefined || type == "null"){
    payId = $('.payment-item.item-selected').attr('payId');
  }else{
    payId=type;
  }
  if(onlineType === 0 || onlineType === 1 || onlineType === 2 || onlineType === 3){
	  otype = onlineType;
  }else{
	  otype = $('.payment-item.item-selected').attr('onlinepaytype');
  }
  var pickShipmentItemCurr = $("#pick_shipment_item").hasClass("curr");
  var param = "shipParam.payId=" + payId + "&shipParam.pickShipmentItemCurr=" + pickShipmentItemCurr + "&shipParam.onlinePayType=" + otype;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : OrderAppConfig.DynamicDomain + "/payAndShip/getVenderInfo.action",
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      // 服务器返回异常处理,如果有消息div则放入,没有则弹出
      if (isHasMessage(dataResult)) {
        goOrder();
        return;
      }
      // 成功后如果有divID直接放入div，没有则返回结果
      else {
        $("#payShipAndSkuInfo").remove();
        $('#shipAndSkuInfo').append('<div id="payShipAndSkuInfo">'+dataResult+'</div>');
        preSaleShow();
        //add by zhuqingjie 此处调用异步
        doAsynGetSkuPayAndShipInfo();
        freshUI();
        //end add
      }
    },
    error : function(XMLHttpResponse) {
      initResetFlag();
      goOrder();
    }
});
}window.save_Pay=save_Pay;
// ---------------------------------------------------------------------------------------------------------------------------


/**
 * 加载四级地址名称
 * 
 * @param id
 */
function loadAllAreaName(id) {
  var address = null;
  //var consignee_where = $("#hidden_consignee_where_" + id).val();
  var provinceId = $("#hidden_consignee_provinceId_" + id).val();
  var cityId = $("#hidden_consignee_cityId_" + id).val();
  var countyId = $("#hidden_consignee_countyId_" + id).val();
  var townId = $("#hidden_consignee_townId_" + id).val();
  var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/loadAreaName.action";
  var param = "consigneeParam.provinceId=" + provinceId + "&consigneeParam.cityId=" + cityId + "&consigneeParam.countyId=" + countyId + "&consigneeParam.townId="
      + townId;
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      if (isHasMessage(dataResult)) {
        var message = getMessage(dataResult);
        alert(message);
      } else {
        //address = consignee_where.replace(dataResult, "");
        $("#hidden_consignee_address_" + id).val(address);
      }
    },
    error : function(XMLHttpResponse) {
      //alert("系统繁忙，请稍后再试！");
      return false;
    }
  });
}

/**
 * 判断轻松购是否弹开
 * 
 * @param id
 */
function open_easyBuyConsignee(id) {
  var isHidden = $("#consignee-form").is(":hidden");// 是否隐藏
  var consignee_type = $("#hidden_consignee_type_" + id).val();
  var consignee_townId = $("#hidden_consignee_townId_" + id).val();
  consignee_townId = consignee_townId + "";
  if (isNaN(consignee_townId)) {
    consignee_townId = "0";
  }
  consignee_townId = parseInt(consignee_townId);
  if (isHidden && (consignee_type == 0 || consignee_type == "0")) {
    var mobile = $("#hidden_consignee_mobile_" + id).val();
    if (isEmpty(mobile) || isNaN(mobile)) {
      show_ConsigneeDetail(id);
      return;
    }
  }
  if (isHidden && (consignee_type == 0 || consignee_type == "0") && consignee_townId <= 0) {
    var consignee_provinceId = $("#hidden_consignee_provinceId_" + id).val();
    var consignee_cityId = $("#hidden_consignee_cityId_" + id).val();
    var consignee_countyId = $("#hidden_consignee_countyId_" + id).val();
    var param = "consigneeParam.type=" + consignee_type + "&consigneeParam.provinceId=" + consignee_provinceId + "&consigneeParam.cityId=" + consignee_cityId
        + "&consigneeParam.countyId=" + consignee_countyId + "&consigneeParam.townId=0";
    var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/openEasyBuy.action";
    jQuery.ajax({
      type : "POST",
      dataType : "json",
      url : actionUrl,
      data : param,
      cache : false,
      success : function(data, textStatus) {
        if (isUserNotLogin(data)) {
          goToLogin();
          return;
        }
        if (data) {
          show_ConsigneeDetail(id);
        }
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
      }
    });
  }
}

/**
 * 判断是否展开地址
 */
function openConsignee() {
  var areaId = $("#hideAreaIds").val();
  var areaIds = null;
  if (areaId != null) {
    areaIds = new Array(); // 定义一数组
    areaIds = areaId.split("-");
  }
  if (areaIds != null && areaIds.length == 4) {
    var param = "consigneeParam.provinceId=" + areaIds[0] + "&consigneeParam.cityId=" + areaIds[1] + "&consigneeParam.countyId=" + areaIds[2]
        + "&consigneeParam.townId=" + areaIds[3];

    var actionUrl = OrderAppConfig.DynamicDomain + "/consignee/checkOpenConsignee.action";
    jQuery.ajax({
      type : "POST",
      dataType : "json",
      url : actionUrl,
      data : param,
      cache : false,
      success : function(data, textStatus) {
        if (isUserNotLogin(data)) {
          goToLogin();
          return;
        }
        if (data) {
          openEditConsigneeDialog($("#consignee_id").val());
          $("#ui-dialog-close").val(1);
        }
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
      }
    });
  }
}

function loadGiftBuySenderTip() {
  if (isGiftBuy()) {
    $("#saveConsigneeTitleDiv").text("保存收礼人信息");
    $("#saveConsigneeTitleMinDiv").text("保存收礼人信息");
    $("#giftSenderDiv").show();
    $("#consignee-giftSender-form").show();
  } else {
    $("#saveConsigneeTitleDiv").text("保存收货人信息");
    $("#saveConsigneeTitleMinDiv").text("保存收货人信息");
    $("#giftSenderDiv").hide();
    $("#consignee-giftSender-form").hide();
  }
}

/**
 * 校验送礼人姓名
 * 
 * @returns {Boolean}
 */
function checkGiftBuySenderName() {
  var value = $("#giftSender_consignee_name").val();
  var errorFlag = false;
  var errorMessage = "";
  if (isEmpty(value)) {
    errorFlag = true;
    errorMessage = "请您填写送礼人姓名";
  }
  if (value.length > 25) {
    errorFlag = true;
    errorMessage = "收货人姓名不能大于25位";
  }
  if (!is_forbid(value)) {
    errorFlag = true;
    errorMessage = "收货人姓名中含有非法字符";
  }
  if (errorFlag) {
    $("#giftSender_name_div_error").html(errorMessage);
    $("#giftSender_name_div").addClass("message");
    return false;
  } else {
    $("#giftSender_name_div").removeClass("message");
    $("#giftSender_name_div_error").html("");
    return true;
  }
}window.checkGiftBuySenderName=checkGiftBuySenderName;

/**
 * 校验送人手机号
 */
function checkGiftBuySenderMobile() {
  var value = $("#giftSender_consignee_mobile").val();
  var errorFlag = false;
  var errorMessage = "";
  if (isEmpty(value)) {
    errorFlag = true;
    errorMessage = "请您填写收货人手机号码";
  } else {
    if (!check_mobile_new(value)) {
      errorFlag = true;
      errorMessage = "手机号码格式不正确";
    }
  }
  if (errorFlag) {
    $("#giftSender_call_div_error").html(errorMessage);
    $("#giftSender_call_div").addClass("message");
    return false;
  } else {
    $("#giftSender_call_div").removeClass("message");
    $("#giftSender_call_div_error").html("");
    return true;
  }
}window.checkGiftBuySenderMobile=checkGiftBuySenderMobile;

// *****************************************************发票开始********************************************************************

/**
 * 编辑发票信息
 * 
 * @param consigneeId
 */
function edit_Invoice() {
  var url = OrderAppConfig.DynamicDomain + "/invoice/editInvoice.action?1=1";
  var dialogHeight = 500;
  if(isGiftBuy()) {
    dialogHeight = 580;
  }
  url = addFlowTypeParam(url); 
  $('body').dialog({
    title:'发票信息',
    width:600,
    height:dialogHeight,
    type:'iframe',
    autoIframe:false,
    iframeTimestamp:false,
    mainId:'mainId',
    source: url
  });
}
window.edit_Invoice = edit_Invoice;
/**
 * 
 * 删除发票信息
 * 
 * @param _id
 */
function delete_Invoice(id) {
  $('#mainId').hide();  
  var _$this = window.dialogIframe.$('#invoice-tit-list .invoice-item[date-fid=fid'+id+']');
  var diaDel = $('body').dialog({
    title:'提示',
    width:400,
    height:100,
    type:'html',
    mainId:'delMainId',
    source:'<div class="tip-box icon-box"><span class="warn-icon m-icon"></span><div class="item-fore"><h3>您确定要删除该发票信息吗？</h3></div><div class="op-btns ac"><a id="delSaveBtn" href="#none"class="btn-9">确定</a><a id="delcallBtn" href="#none" class="btn-9 ml10">取消</a></div></div>',
    onReady:function(){
      $('#delSaveBtn').bind('click',function(){
        var actionUrl = OrderAppConfig.AsyncDomain + "/invoice/deleteInvoiceFromUsual.action";        
        var invokeInvoiceBasicService = $("#invokeInvoiceBasicService").val();        
        var param = "invoiceParam.usualInvoiceId=" + id;
        param = param + "&invokeInvoiceBasicService=" + invokeInvoiceBasicService;
        jQuery.ajax({
          type : "POST",
          dataType : "json",
          url : actionUrl,
          data : param,
          cache : false,
          success : function(dataResult, textStatus) {
            if (isHasMessage(dataResult)) {
              var message = getMessage(dataResult);
              alert(message);
            } else {
              _$this.removeClass('invoice-item-selected');
              if($('#invoice-tit-list .invoice-item-selected').length<=0){
                _$this.prev().click();
              }
              _$this.remove();
              var len =window.dialogIframe.$('#invoice-tit-list').find('.invoice-item').length;
              if(len<11){
                window.dialogIframe.$('#add-invoice').show();
              }else{
                window.dialogIframe.$('#add-invoice').hide();
              }
              diaDel.close();           
              $('#mainId').show(); 
            }
          },
          error : function(XMLHttpResponse) {
            diaDel.close();
            $('#mainId').show(); 
            }
          });   
          
        });
      //点击取消click
      $('#delcallBtn').bind('click',function(){
        diaDel.close();
        $('#mainId').show(); 
      });
      //点击叉子click
      $('#delMainId .ui-dialog-close').bind('click',function(){
        $('#mainId').show(); 
      });
    }
  });
}window.delete_Invoice=delete_Invoice;


// *************************************************支付和配送方式开始***************************************************************

function getSelectedPaymentId() {
  var paymentId = 4;
  paymentId = $("input[name='payment'][checked]").val();
  return paymentId;
}


/**
 * 显示配送方式显示的时间
 */
function showCodeTime() {
  $(".t-item").each(function() {
    $(this).show();
  });
  $("#jdShipmentTip").show();
}

/**
 * 选中promise
 */
function selectedPromise() {
  $("#delivery-t4").attr('checked', true);
  $('#date-311').click();
}



function removeMessageTip() {
  $("#save-payAndShip-tip").html("");
  $("#save-consignee-tip").html("");
  $("#save-invoice-tip").html("");
}

/**
 * 用户选中支付方式radio弹出层显示支持与不支持的商品列表
 * 
 * @param obj
 */
var YP_Sku_Flag = null;

function showSkuDialog(obj) {
  if ($(obj).attr("payid") != 4) {
    $("#payment-bankList").hide();
  }
  if ($(obj).attr("payid") == 4) {
    $("#payment-bankList").show();
  }

  if ($(obj).attr("payid") != 1) {
    $("#payment-factoryShipCod").hide();
  }
  if ($(obj).attr("payid") == 1) {
    $("#payment-factoryShipCod").show();
  }
  if ($(obj).attr("payid") != 8) {
    $("#payRemark_8").hide();
  }
  if (YP_Sku_Flag) {
    YP_Sku_Flag = $(obj).parents('.item').parent().find('.item-selected :radio');
  }

  var payArr = $("[id^='pay-method-']");
  for (var i = 0; i < payArr.length; i++) {
    $(payArr[i]).parent().parent().removeClass("item-selected");
    var itempayid = $(payArr[i]).parent().parent().attr("payid");

    $("#supportPaySkus-" + itempayid).css("display", "none");
    // $("#otherSupportSkus-" + itempayid).css("display", "none");

  }
  var selectedPay = $(obj).parent().parent();
  selectedPay.addClass("item-selected");

  var payId = $(obj).attr("payid");
  // 清除其他选项的选中状态
  var itemList = $(".payment").find('.item');
  for (var i = 0; i < itemList.length; i++) {
    var item = itemList[i];
    var $item = $(item);
    $item.height(28);
    $item.find(".label").find("span").hide();
    $item.find(".label").find(".orange").show();
    $item.find(".sment-mark").css("display", "none");
  }

  var dialogDiv = $("#payment-dialog-" + payId)[0];
  if (!!dialogDiv) {
    $.jdThickBox({
      width : 550,
      height : 330,
      title : "请确认支付方式",
      _box : "payment_dialog",
      _con : "payment_dialog_box",
      _close : "payment_dialog_close",
      // source: $("#payment-dialog") // 当指定type时，页面元素容器
      source : '<div class="iloading" style="padding:20px;">正在加载中...<\/div>'
    }, function() {
      $("#payment_dialog, #payment_dialog_box").css("height", "auto");

      var PDHTML = $("#payment-dialog-" + payId)[0].value;

      $("#payment_dialog_box").html(PDHTML);

      $("#dialog-enter-" + payId).bind("click", function() {
        // 清除其他选项的选中状态
        var itemList = $(".payment").find('.item');
        for (var i = 0; i < itemList.length; i++) {
          var item = itemList[i];
          var $item = $(item);
          $item.height(28);
          $item.find(".label").find("span").hide();
          $item.find(".label").find(".orange").show();
          $item.find(".sment-mark").css("display", "none");
        }
    
        $("#supportPaySkus-" + payId).css("display", "inline-block");
        $("#otherSupportSkus-" + payId).css("display", "block");
        jdThickBoxclose();
        if ($("#otherSupportSkus-" + payId) && $("#otherSupportSkus-" + payId).length > 0 && $("#otherSupportSkus-" + payId).find('span').size() > 0) {
          selectedPay.height(56);
        } else {
          selectedPay.height(28);
        }
        YP_Sku_Flag = obj;
        $(obj).attr("checked", "checked");
      });
      $("#dialog-cancel-" + payId).bind("click", function() {

        var itemList = $(".payment").find('.item');
        for (var i = 0; i < itemList.length; i++) {
          var item = itemList[i];
          var $item = $(item);
          $item.height(28);
          $item.find(".label").find("span").hide();
          $item.find(".label").find(".orange").show();
          $item.find(".sment-mark").css("display", "none");
        }

        jdThickBoxclose();
        $(obj).attr('checked', false);
        $(obj).parents(".item").removeClass('item-selected');
        $("#pay-method-4").attr('checked', true);
        $("#pay-method-4").parents(".item").addClass('item-selected');
        //edit_Shipment(4);【dodoa 换成灵辉的方法】
      });
    });
  } else {
    //edit_Shipment(payId);【dodoa 换成灵辉的方法】
  }

}

/**
 * 支付配送展开后的弹窗
 * 
 * @param id
 * @param skuDivId
 * @return
 */
function showShipmentSkuList(id, skuDivId) {
  $("#" + skuDivId).removeClass("hide").show();
  var offset = $("#" + id).position();
  var x = offset.left + 60;
  $('#' + skuDivId).show().css({
    left : x,
    top : -2
  });
}

/**
 * 支付配送关闭后的配送的弹窗
 * 
 * @param id
 * @param SkuDiagId
 * @return
 */
function showShipmentSkuListOutside(id, SkuDiagId) {
  if ($("#payment-ship").find("#payment-window-1").html() != null) {
    $("#payment-ship").find("#payment-window-1").hide();
  }
  if ($("#payment-ship").find("#payment-window-2").html() != null) {
    $("#payment-ship").find("#payment-window-2").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-1").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-1").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-2").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-2").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-3").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-3").hide();
  }
  var topDistance = parseInt(id.substring(id.length - 1, id.length) - 1) * 20;
  $("#payment-ship").find("#" + SkuDiagId).css({
    position : "absolute",
    top : (20 + topDistance) + "px",
    left : 130,
    display : "block"
  });

}

/**
 * 支付配送关闭后的支付方式的弹窗
 * 
 * @param id
 * @param SkuDiagId
 * @return
 */
function showPaymentSkuListOutside(id, SkuDiagId) {
  if ($("#payment-ship").find("#payment-window-1").html() != null) {
    $("#payment-ship").find("#payment-window-1").hide();
  }
  if ($("#payment-ship").find("#payment-window-2").html() != null) {
    $("#payment-ship").find("#payment-window-2").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-1").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-1").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-2").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-2").hide();
  }
  if ($("#payment-ship").find("#pick-show-sku-out-3").html() != null) {
    $("#payment-ship").find("#pick-show-sku-out-3").hide();
  }

  var distance = 0;
  if ($.trim($("#payment-ship").find("#pay-name-for-window-1").text()).length == 5) {
    distance = 8;
  } else if ($.trim($("#payment-ship").find("#pay-name-for-window-1").text()).length == 7) {
    distance = 36;
  } else if ($.trim($("#payment-ship").find("#pay-name-for-window-1").text()).length == 8) {
    distance = 46;
  }
  if ("pay-name-for-window-1" == id) {
    $("#payment-ship").find("#payment-window-1").css({
      position : "absolute",
      top : -4,
      left : (165 + distance) + "px",
      display : "block"
    });
  } else {
    if ($.trim($("#payment-ship").find("#check-info-name").text()) != "") {
      distance += 368;
    }
    $("#payment-ship").find("#payment-window-2").css({
      position : "absolute",
      top : -4,
      left : (225 + distance) + "px",
      display : "block"
    });
  }
}

/**
 * 支付配送关闭后的配送方式商品弹窗
 * 
 * @param skuId
 * @return
 */
function removeShipmentSkuListOutside(skuId) {
  $("#payment-ship").find("#" + skuId).hide();
}
/**
 * 支付配送关闭后的支付方式商品弹窗
 * 
 * @param skuId
 * @return
 */
function removePaymentSkuListOutside(skuId) {
  $("#payment-ship").find("#" + skuId).hide();
}
/**
 * 支付配送展开后的商品弹窗
 * 
 * @param skuDivId
 * @return
 */
function removeShipmentSkuListInside(skuDivId) {
  $("#" + skuDivId).hide();
}

function removeFreightSpan() {
  $("#transport").hide();
}window.removeFreightSpan = removeFreightSpan;

function changeBigItemDate(dateValue) {
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : OrderAppConfig.DynamicDomain + "/payAndShip/getInstallDates.action?payAndShipParam.bigSkuTimeId=" + dateValue,
    data : "",
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      $("#installOptionDiv").html(dataResult);
    },
    error : function(XMLHttpResponse) {
      //alert("系统繁忙，请稍后再试！");
      return false;
    }
  });
}

/**
 * 获取支票信息
 * 
 * @param type
 * @return
 */
function getCheckInfo(type) {

  // 2为支票, 如果选择的不为支票则清空支票信息div
  if (type != 2) {
    $("#checkInfo").html("");
  } else {
    var param = addFlowTypeParam();
    $.ajax({
      type : "POST",
      dataType : "text",
      url : OrderAppConfig.AsyncDomain + "/payAndShip/getShipmentCheckInfo.action",
      data : param,
      cache : false,
      success : function(dataResult, textStatus) {
        // 没有登录跳登录
        if (isUserNotLogin(dataResult)) {
          goToLogin();
          return;
        }
        $("#checkInfo").html(dataResult);
        $('.cheque-item :radio').bind('click', function() {
          $('.cheque-btn a').removeClass().addClass('btn-submit');
          $('.cheque-item').removeClass('current');
          $(this).parents('.cheque-item').addClass('current');
        });
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
        return false;
      }
    });
  }
}

/**
 * 跳转到公司转账
 * 
 * @return
 */
function goToCompanyTransfer() {
  // 设置当前选中支付方式为公司转账
  $("#pay-method-5").attr("checked", true);
  // 刷新配送方式
  //edit_Shipment(5);【dodoa 换成灵辉的方法】
  $("#pay-method-1").parents(".item").removeClass("item-selected").height(28);
  $("#supportPaySkus-1").hide();
  $("#otherSupportSkus-1").hide();
  $("#pay-method-5").parents(".item").addClass("item-selected");

}
// 关闭支付与配送方式中的提示框
function closeTip(type) {
  $("#" + type).css("display", "none");
}
// 获取radio中选中的值
function getRadioValue(name) {
  var list = document.getElementsByName(name);
  for (var i = 0; i < list.length; i++) {
    if (list[i].checked == true)
      return list[i].value;
  }
}
// 对选中的radio进行加亮
function lightRadio(name, id) {
  var list = document.getElementsByName(name);
  for (var i = 0; i < list.length; i++) {
    if (list[i].checked == true) {
      $("#" + id + "-" + list[i].value).attr("class", "item item-selected");
    } else {
      $("#" + id + "-" + list[i].value).attr("class", "item");
    }
  }
}
// 显示支票的提示选项
function showCheckDiv(id) {
  if (id == "2") {
    $("#tip1").css("display", "block");
  } else {
    $("#tip1").css("display", "none");
  }
}
/** *****************************************************优惠券************************************************* */

var item = "item";
var itemToggleActive = "item toggle-active";
var orderCouponItem = "orderCouponItem";
var orderGiftCardItem = "orderGiftCardItem";
var orderGiftECardItem = "orderEGiftCardItem";
var orderCouponId = "orderCouponId";
var giftCardId = "giftCardId";
var giftECardId = "eCardId";
var toggleWrap = "toggle-wrap";
var toggleWrapHide = "toggle-wrap hide";
var BALANCE_PWD_TYPE = "balancePwdType";
var JING_PWD_TYPE = "jingPwdType";
var LPK_PWD_TYPE = "lpkPwdType";
var dongType = "dongType";
var jingType = "jingType";
var freeFreight = "freeFreightType";

function couponTip() {
  $(function() {
    $("#coupons .virtual-from").find(".coupon-scope").each(function() {
      var $this = $(this), parent = $this.parents(".list"), dialog = parent.find(".coupon-tip");

      var left = $this.position().left + ($this.width() / 2);

      dialog.css({
        "left" : left + "px",
        "display" : "none"
      });

      $this.bind("mouseenter", function() {
        parent.css({
          "overflow" : "visible",
          "z-index" : 5
        });
        dialog.css("display", "block");
      }).bind("mouseleave", function() {
        parent.css({
          "overflow" : "hidden",
          "z-index" : 1
        });
        dialog.css("display", "none");
      });
    });
  });
}

/**
 * 优惠券查询
 */
function query_coupons() {
  var flag = $("#" + orderCouponId).css('display') == 'none'; // 判断隐藏还是显示优惠券列表
  if (flag) {// 显示优惠券列表
    $("#orderCouponItem").find(".toggler").html("<b></b>使用优惠券（京券/东券/免运费券）");
    var param = addFlowTypeParam();
    var url = OrderAppConfig.DynamicDomain + "/coupon/getCoupons.action";
    jQuery.ajax({
      type : "POST",
      dataType : "text",
      url : url,
      data : param,
      async : true,
      cache : false,
      success : function(result) {
        if (isUserNotLogin(result)) {
          goToLogin();
          return;
        }
        if (isHasMessage(result)) {
          var message = getMessage(result);
          alert(message);
          return;
        }
        checkPaymentPasswordSafe(JING_PWD_TYPE);
        $("#" + orderCouponId).css("display", "block");
        // 优惠券显示样式
        changeClassStyle(orderCouponId, toggleWrap);
        changeClassStyle(orderCouponItem, itemToggleActive);
        $("#" + OrderAppConfig.Module_Coupon).html(result);
        entityCouponInputEventInit();// 实体券输入框初始化
        // 东券提示文字
        couponTip();
        //isNeedPaymentPassword(); // 是否需要支付密码
        couponInfoTip();
          // 查看优惠券对应的商品列表 tips 初始化
        hideCouponTips();
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
      }
    });
  } else {
    // 隐藏优惠券列表
    $("#" + orderCouponId).css('display', 'none');
    // 优惠券隐藏样式
    changeClassStyle(orderCouponId, toggleWrapHide);
    changeClassStyle(orderCouponItem, item);
    showCouponAvailableNum();
  }
}
window.query_coupons = query_coupons;

/**
 * 优惠券查询
 */
function query_page_coupons(pageNum) {
    var param = "couponParam.pageNum="+pageNum;
    param = addFlowTypeParam(param);
    var url = OrderAppConfig.DynamicDomain + "/coupon/getCoupons.action";
    jQuery.ajax({
      type : "POST",
      dataType : "text",
      url : url,
      data : param,
      async : false,
      cache : false,
      success : function(result) {
        if (isUserNotLogin(result)) {
          goToLogin();
          return;
        }
        if (isHasMessage(result)) {
          var message = getMessage(result);
          alert(message);
          return;
        }
        
        $("#" + OrderAppConfig.Module_Coupon).html(result);
        // 如果列表是隐藏的，并且是优惠券新接口，则显示可用优惠券数量
        if($("#" + orderCouponId).css('display') == 'none' && $("#invokeNewCouponInterface").val() == "true"){
        	showCouponAvailableNum();
        }else{
            checkPaymentPasswordSafe(JING_PWD_TYPE,0);
	        entityCouponInputEventInit();// 实体券输入框初始化
	        // 东券提示文字
	        couponTip();
	        //isNeedPaymentPassword(); // 是否需要支付密码
	        couponInfoTip();
        }
        // 刷新优惠券优惠、运费优惠
        flushOrderCouponPriceByCoupon();
        hideCouponTips();
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
      }
    });
}
window.query_page_coupons = query_page_coupons;
/**
 * 显示优惠券的可用或不可用商品列表
 */
function showCouponSkuList(){
  var $el = $("#container");
  virtualTips = $el.tips({
      trigger: '.trigger-a',
      width: 260,
      type: 'click',
      sourceTrigger: '#tooltip-box04',
      callback:function(trigger,obj){
        var couponKey = $(trigger).attr("id");
        var availableType = $(trigger).text().indexOf("该券可用商品列表") > -1 ? 0 : 1;
        $('.tooltip-tit',obj).html(availableType == 0 ?"该券可用商品列表":"该券不可用商品列表");
        var param = "couponParam.couponKey=" + couponKey+"&couponParam.availableType="+availableType;;
        param = addFlowTypeParam(param);
        var url = OrderAppConfig.AsyncDomain + "/coupon/getSkuInfoByCouponKey.action";
        jQuery.ajax({
          type : "POST",
          dataType : "text",
          url : url,
          data : param,
          async : true,
          cache : false,
          success : function(result) {
            if (isUserNotLogin(result)) {
            goToLogin();
            return;
          }
          if (isHasMessage(result)) {
            var message = getMessage(result);
            alert(message);
            return;
          }
            $("#v-goods",obj).html(result);
          },
          error : function(XMLHttpResponse) {
            alert("系统繁忙，请稍后再试！");
          }
        });
      }
  });
}

function hideCouponTips(){
  $('#virtual-table').bind('scroll', function(){
    virtualTips.hide();
  });
  $(document).bind('scroll', function(){
    virtualTips.hide();
  });
}

/**
 * 调用后台接口获取可用优惠券数量
 */
function showCouponAvailableNumByRpc(availableCouponNum){
      if (Number(availableCouponNum)>0) {
        var numtext = availableCouponNum;
        if(Number(availableCouponNum)>99){
          numtext = "99+";
        }
        $("#orderCouponItem").find(".toggler").html('<b></b>使用优惠券（京券/东券/免运费券）<i class="num">'+numtext+'</i>');
      }else{
        $("#orderCouponItem").find(".toggler").html('<b></b>使用优惠券（京券/东券/免运费券）');
      }
}


/**
 * 获取可用优惠券数量
 */
function showCouponAvailableNum(){
  var flag = $("#" + orderCouponId).css('display') == 'none'; // 判断隐藏还是显示优惠券列表
  if(flag && $("#invokeNewCouponInterface").val() == "true"){
    var numtext = $("#canUseCouponDiv input[type='checkbox']").length;
    if(Number(numtext)>99){
      numtext = "99+";
    }
    if(numtext > 0){
      $("#orderCouponItem").find(".toggler").html('<b></b>使用优惠券（京券/东券/免运费券）<i class="num">'+numtext+'</i>');
    }else{
      $("#orderCouponItem").find(".toggler").html('<b></b>使用优惠券（京券/东券/免运费券）');
    }
  }
        
}

/**
 * 检查余额安全，是否开启支付密码
 */
function checkBalancePwdResult(type) {
  var param = "couponParam.fundsPwdType=" + type;
  param = addFlowTypeParam(param);
  var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(flag) {
      if (isUserNotLogin(flag)) {
        goToLogin();
        return;
      }
      if (!flag) {
        cancelUsedBalance(); // 账户不安全，设置余额不可用
        return flag;
      }
    }
  });
}

/**
 * 设置余额不可用
 */
function cancelUsedBalance() {
  if ($("#selectOrderBalance").is(':checked')) {// 选中状态
    $("#selectOrderBalance").click(); // JS模拟取消
  }
  $("#selectOrderBalance").attr('disabled', true);
  if ($("#showOrderBalance").css("display") != "none") {
    $("#safeVerciryPromptPart").show();
  }
}

/**
 * 选择京券
 */
function selectJing(obj, key, id) {
  var flag = (obj.checked) ? "1" : "0"; // 判断是否选中京券
  if (flag == 1) {// 选择京券，刷新优惠券列表
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/useCoupon.action", key, obj, 1, jingType);
  } else {
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/cancelCoupon.action", id, obj, 0, jingType);
  }
}window.selectJing = selectJing;

/**
 * 选择东券
 */
function selectDong(obj, key, id) {
  var flag = (obj.checked) ? "1" : "0"; // 判断是否选中东券
  if (flag == 1) {// 选择东券，刷新优惠券列表
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/useCoupon.action", key, obj, 1, dongType);
  } else {
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/cancelCoupon.action", id, obj, 0, dongType);
  }
}window.selectDong = selectDong;

/**
 * 选择免运费券
 */
function selectFreeFreight(obj, key, id) {
  var flag = (obj.checked) ? "1" : "0"; // 判断是否选中运费券
  if (flag == 1) {// 选择免运费券，刷新优惠券列表
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/useCoupon.action", key, obj, 1, freeFreight);
  } else {
    useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/cancelCoupon.action", id, obj, 0, freeFreight);
  }
}window.selectFreeFreight = selectFreeFreight;

/**
 * 添加实体券
 * 
 * @param obj
 */
function addEntityCoupon(obj) {

  if ($('#couponKeyPressFirst').val() == "" || $('#couponKeyPressSecond').val() == "" || $('#couponKeyPressThrid').val() == ""
      || $('#couponKeyPressFourth').val() == "") {
    showMessageWarn("请输入优惠券密码");
    return;
  }
  var key = $("#couponKeyPressFirst").val() + "-" + $("#couponKeyPressSecond").val() + "-" + $("#couponKeyPressThrid").val() + "-" + $("#couponKeyPressFourth").val();
  // TODO
  $("input[id^='couponKeyPress']").each(function() {
    $(this).val("");
  });
  useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/useCoupon.action", key, obj, 1, "");
}

function removeShiTiCoupon(id) {
  useOrCancelCoupon(OrderAppConfig.DynamicDomain + "/coupon/cancelCoupon.action", id, null, 0, "");
}

/**
 * 使用或者取消优惠券 1：使用优惠券，0：取消优惠券
 */
function useOrCancelCoupon(url, id, obj, flag, couponType) {
  var param = "";
  if (flag == 1) {// 使用券传的是couponKey
    param += "couponParam.couponKey=" + id;
  } else {// 取消券使用的是couponId
    param += "couponParam.couponId=" + id;
  }
  param += "&couponParam.pageNum="+$("#pageNum").val();;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        alert(message);
        if (obj.checked) {
          obj.checked = false;
        }
        return;
      }
      checkPaymentPasswordSafe(JING_PWD_TYPE, 0);// 用户安全，检查是否开启支付密码
      changeClassStyle(orderCouponId, toggleWrap);
      changeClassStyle(orderCouponItem, itemToggleActive);
      $("#" + OrderAppConfig.Module_Coupon).html(result);
      // 刷新显示：优惠券优惠金额，礼品卡优惠金额，余额优惠金额，实际应付总金额
      useCancelEditJdBean(0, null, true);
      flushOrderPriceByCoupon(); // 改变优惠券状态
      checkCouponWaste();// 检查优惠券是否存在浪费情况
      isNeedPaymentPassword(); // 是否需要支付密码
      hideCouponTips();
    }
  });

}

/**
 * 检查优惠券是否存在浪费情况
 */
function checkCouponWaste() {
  if ($("#hidden_wasteFlag").val() == "true") {
    alert("您的京券金额多于商品应付总额，京券差额不予退还哦~");
  }
}window.checkCouponWaste=checkCouponWaste;

//点击余额ajax请求一次校验支付密码开启 TODO 虚拟资产前端代码待重构，例如开启支付密码，页面异步刷新就可以取得这个状态，不必多次请求 LILONG
$('#balance-div .toggle-title').bind('click',function(){
  
  if ($("#balance-div").hasClass("toggle-active")) {
    $("#balance-div").removeClass("toggle-active");
    $("#jdBalance").addClass("hide");
  } else {
    $("#balance-div").addClass("toggle-active");
    $("#jdBalance").removeClass("hide");
  }

  if($("#safeBalancePart").hasClass('hide')) {
    checkPaymentPasswordSafe('balance', 0);
  }
});

/**
 * 使用优惠券、礼品卡时检查是否开启支付密码
 * 
 * @param type
 */
function checkPaymentPasswordSafe(type, giftCardType) {
  var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
  var param = "couponParam.fundsPwdType=" + type;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        alert(message);
        if (obj.checked) {
          obj.checked = false;
        }
        return;
      }
      if (!result) {
        // 增加余额提示开启密码的显示
        $("#safeBalancePart").removeClass("hide");
        // 增加优惠券提示开启密码的显示
        $("#safeJingPart").show();
        if (type == JING_PWD_TYPE) {
          cancelAllUsedCoupons();
          return;
        } else if (type == LPK_PWD_TYPE) {
          cancelAllUsedGiftCards(giftCardType);
          return;
        }
        
      }

    }
  });
}window.checkPaymentPasswordSafe = checkPaymentPasswordSafe;

/**
 * 刷新订单价格
 * 
 * @param orderPrice
 *            是一个json对象
 */
function flushOrderPrice(orderPrice, isFlushSkuList) {
  if (orderPrice == null) {
    return;
  }
  //根据店铺刷运费[京东商家运费和sop运费]
  var venderFreight = orderPrice.venderFreight;
  
  //yanwenqi sku刷运费
  var venderfreightSkuViews = orderPrice.venderfreightSkuViews;
  var venderRemoteFreight = orderPrice.venderRemoteFreight;
  $("#tooltip-box06 .ftx-01").each(function(){
            var freightVenderId=$(this).attr("freightByVenderId");
            var popJdShipment = $(this).attr("popJdShipment");
            freightHtml ="<span class='ftx-01' freightByVenderId='"+freightVenderId+"'  popJdShipment='"+popJdShipment+"'>免运费</span>";
            $(this).parent().html(freightHtml);
    });
  if(venderFreight != null){
    var jdFreight = null;
    for (var prop in venderFreight) {
        if (venderFreight.hasOwnProperty(prop)) {   
          //alert("prop: " + prop + " value: " + venderFreight[prop])  ;          
         $("#tooltip-box06 .ftx-01").each(function(){
            var freightVenderId=$(this).attr("freightByVenderId");
            var popJdShipment = $(this).attr("popJdShipment");

                if(prop == freightVenderId){
                  var freightSop = venderFreight[prop].toFixed(2);
                  var freightHtml = "";
                  if(freightSop == "0.00" || freightSop == "0" || freightSop == ""){
                    freightHtml ="<span class='ftx-01' freightByVenderId='"+freightVenderId+"'  popJdShipment='"+popJdShipment+"'>免运费</span>";
                  }
                  else{
                	  if(venderRemoteFreight.hasOwnProperty(prop)){
                		  freightHtml = "<span>运费：</span><strong class='ftx-01'  freightByVenderId='"+freightVenderId+"' popJdShipment='"+popJdShipment+"'>￥"+(freightSop-venderRemoteFreight[prop]).toFixed(2)+"</strong>"+"<span> 超重超大运费：</span><strong class='ftx-01'>￥"+venderRemoteFreight[prop].toFixed(2)+"</strong>"+"<span> <a href=\"http://help.jd.com/user/issue/109-188.html\"  target=\"_blank\">了解详情</a></span>";
                	  }else{
                		  freightHtml = "<span>运费：</span><strong class='ftx-01'  freightByVenderId='"+freightVenderId+"' popJdShipment='"+popJdShipment+"'>￥"+freightSop+"</strong>";
                	  }
                  }
                  
            	  //yanwenqi sku显示运费9999
            	  if(venderfreightSkuViews!=null){
            		  if(venderfreightSkuViews.hasOwnProperty(prop)){
          				freightSkuViewss = venderfreightSkuViews[prop];
        				for(var n = 0; n < freightSkuViewss.length;n++){
        					if(freightSkuViewss[n].remoteSkuFreight!="0" && freightSkuViewss[n].remoteSkuFreight!="0.00" && freightSkuViewss[n].remoteSkuFreight!=0){
	        					if($(("#"+freightSkuViewss[n].id+" .specal-frei-price"))){
	        						$(("#"+freightSkuViewss[n].id+" .specal-frei-price")).remove();
	        						//$(("#"+freightSkuViewss[n].id+" .specal-frei-price")).html("100￥"+freightSkuViewss[n].remoteSkuFreight);
	        						
	        					}
	        						$(("#"+freightSkuViewss[n].id)).append("<span class=\"specal-frei-price\" id=\""+freightSkuViewss[n].id+"\">￥"+freightSkuViewss[n].remoteSkuFreight.toFixed(2)+"</span>");
        					}else{
                  			  if($(("#"+freightSkuViewss[n].id+" .specal-frei-price"))){
                				  $(("#"+freightSkuViewss[n].id+" .specal-frei-price")).remove();
                			  }
        					}
        				}
            		  }else{
            			  //将此商家下的商品的悬浮运费去掉
            			  if($("#"+prop)){
            				  $("#"+prop).nextAll().each(function(){
            					  if($(this).find(".specal-frei-price")){
            						  $(this).find(".specal-frei-price").remove();
            					  }
            				  });
            			  }

            		  }
            	  }else{
            		  //将所有悬浮运费去掉
            		  if($("#tooltip-box06 .specal-frei-price")){
            			  $("#tooltip-box06 .specal-frei-price").each(function(){
            				  $(this).remove();
            			  });
            		  }
            	  }
                  
                  $(this).parent().html(freightHtml);
                }
                if(prop == 0 || prop == "0"){
                  jdFreight =  venderFreight[prop].toFixed(2);
                }            
          });
        }  
      }
    
     $("#tooltip-box06 .ftx-01").each(function(){
        var popJdShipment = $(this).attr("popJdShipment");
        var freightVenderId=$(this).attr("freightByVenderId");
            var freightHtml = "";
             if(popJdShipment == "true" && jdFreight != null){
               if(jdFreight == "0.00" || jdFreight == "0" || jdFreight == ""){
                  freightHtml ="<span class='ftx-01' freightByVenderId='"+freightVenderId+"'  popJdShipment='"+popJdShipment+"'>免运费</span>";
               }
               else{
                  freightHtml ="<strong class='ftx-01' freightByVenderId='"+freightVenderId+"'  popJdShipment='"+popJdShipment+"'>￥"+jdFreight+"</strong>";
               }
               $(this).parent().html(freightHtml);
             }   
      });
    
  } 
  // 修改运费
  if (orderPrice.freight != null) {
    if (orderPrice.freight > 0) {
      $("#freightPriceId").html("<font color='#FF6600'> ￥" + orderPrice.freight.toFixed(2) + "</font>");
      $("#freightSpan").html("<font color='#005EA7'>运费：</font>");
      
      if($(".presale-freight")){
        $(".presale-freight").html("(运费" + orderPrice.freight.toFixed(2) + "元在尾款阶段支付)");
        $(".presale-freight").removeClass("hide");
      }
      if($(".presale-freight2")){
        $(".presale-freight2").html("+<strong>运费：</strong>￥" + orderPrice.freight.toFixed(2));
      }
    } else {
      $("#freightPriceId").html("<font color='#000000'> ￥" + orderPrice.freight.toFixed(2) + "</font>");
      $("#freightSpan").html("<font color='#000000'>运费：</font>");
      if($(".presale-freight")){
        $(".presale-freight").addClass("hide");
      }
      if($(".presale-freight2")){
        $(".presale-freight2").html("+<strong>运费：</strong>￥0.00");
      } 
    }
    
    if(orderPrice.freeFreight > 0){
      $("#freeFreightPriceId").text("-￥" + orderPrice.freeFreight.toFixed(2));
      $("#showFreeFreight").css("display", "block");
    }else{
      $("#showFreeFreight").css("display", "none");
    }
    $("#freeFreightPriceNum").val(orderPrice.freightCouponNum);
    $("#freeFreightPricehidden").val(orderPrice.freeFreight);
  }




  // 修改优惠券结算信息
  if (orderPrice.couponDiscount != null) {
    $("#couponPriceId").text("-￥" + orderPrice.couponDiscount.toFixed(2));
    if (orderPrice.couponDiscount == 0) {
      $("#showCouponPrice").css("display", "none");
      $("#couponPriceId").css("display", "none");
    } else {
      $("#showCouponPrice").css("display", "block");
      $("#couponPriceId").css("display", "block");
    }
  } else {
    $("#couponPriceId").css("display", "none");
  }
  $("#couponPriceNum").val(orderPrice.couponNum);
  $("#couponPricehidden").val(orderPrice.couponDiscount);


  // 修改礼品卡结算信息
  if (orderPrice.giftCardDiscount != null) {
    $("#giftCardPriceId").text("-￥" + orderPrice.giftCardDiscount.toFixed(2));
    if (orderPrice.giftCardDiscount == 0) {
      $("#showGiftCardPrice").css("display", "none");
    } else {
      $("#showGiftCardPrice").css("display", "block");
    }
  } else {
    $("#showGiftCardPrice").css("display", "none");
  }
  $("#giftCardPriceNum").val(orderPrice.giftCardNum);
  $("#giftCardPricehidden").val(orderPrice.giftCardDiscount);

  // 修改余额
  if (orderPrice.usedBalance != null) {
    $("#usedBalanceId").text("-￥" + orderPrice.usedBalance.toFixed(2));
    if (orderPrice.usedBalance == 0) {
      $("#showUsedOrderBalance").css("display", "none");
    } else {
      $("#showUsedOrderBalance").css("display", "block");
    }
     $("#useBalanceShowDiscount").val(orderPrice.usedBalance.toFixed(2));
  } else {
    $("#showUsedOrderBalance").css("display", "none");
    $("#useBalanceShowDiscount").val(0);
  }
  // 修改京豆
  if (orderPrice.usedJdBeanDiscout != null) {
    $("#usedJdBeanId").text("-￥" + orderPrice.usedJdBeanDiscout.toFixed(2));
    if (orderPrice.usedJdBeanDiscout == 0) {
      $("#showUsedJdBean").css("display", "none");
    } else {
      $("#showUsedJdBean").css("display", "block");
    }
    $("#jdBeanexChange").val(orderPrice.usedJdBeanDiscout.toFixed(2));
  } else {
    $("#jdBeanexChange").val(0);
    $("#showUsedJdBean").css("display", "none");
  }

  // 修改应付余额
  if (orderPrice.payPrice != null) {
    var curPrice = orderPrice.promotionPrice - orderPrice.cashBack;
    var prePrice = $("#warePriceId").attr("v") - $("#cachBackId").attr("v");
    if (curPrice > prePrice) {
      $("#changeAreaAndPrice").show();
    } else {
      $("#changeAreaAndPrice").hide();
    }
    $("#warePriceId").attr("v", orderPrice.promotionPrice);
    $("#cachBackId").attr("v", orderPrice.cashBack);

    modifyNeedPay(orderPrice.payPrice.toFixed(2));
  }

  // 商品总金额
  if (orderPrice.skuNum != null && orderPrice.skuNum > 0) {
    $("#span-skuNum").text(orderPrice.skuNum);
  }
  if (orderPrice.promotionPrice != null) {
    $("#warePriceId").text("￥" + orderPrice.promotionPrice.toFixed(2));
    if($(".presale-total-money")){
      $(".presale-total-money").text("￥" + orderPrice.payPrice.toFixed(2));
    }
  }
  if($("#isNewVertual").val() == "true")
    refushVertualused();

  
  if (isFlushSkuList) {
    save_Pay(0);
  }
}window.flushOrderPrice=flushOrderPrice;

function flushOrderPriceByCoupon() {
  // 修改运费
  if ($("#hiddenFreight_coupon")[0]) {
    $("#freightPriceId").text(" ￥" + $("#hiddenFreight_coupon").val());
  }

  // 运费券
  if($("#hiddenCouponDiscount")[0]) {
    $("#freeFreightPriceId").text("-￥" + $("#hiddenFreeFreight_coupon").val());
    if($("#hiddenFreeFreight_coupon").val() == 0) {
      $("#showFreeFreight").css("display", "none");
    } else {
      $("#showFreeFreight").css("display", "block");
    }
  } else {
    $("#showFreeFreight").css("display", "none");
  }
  // 修改优惠券结算信息
  if($("#hiddenCouponDiscount")[0]) {
    // 运费券金额拆分再合并
    var couponDiscount = $("#hiddenCouponDiscount").val();
    if($("#hiddenFreeFreight_coupon").val() > 0) {
      couponDiscount = eval(parseFloat(couponDiscount) + parseFloat($("#hiddenFreeFreight_coupon").val()));
    }
    $("#couponPrice").text(" " + parseFloat(couponDiscount).toFixed(2));
    $("#couponPriceId").text("-￥" + $("#hiddenCouponDiscount").val());
    if($("#hiddenCouponDiscount").val() == 0) {
      $("#showCouponPrice").css("display", "none");
      $("#couponPriceId").css("display", "none");
    } else {
      $("#showCouponPrice").css("display", "block");
      $("#couponPriceId").css("display", "block");
    }
  } else {
    $("#couponPriceId").css("display", "none");
  }

  // 修改礼品卡结算信息
  if ($("#hiddenGiftCardDiscount_coupon")[0]) {
    $("#giftCardPriceId").text("-￥" + $("#hiddenGiftCardDiscount_coupon").val());
    if ($("#hiddenGiftCardDiscount_coupon").val() == 0) {
      $("#showGiftCardPrice").css("display", "none");
    } else {
      $("#showGiftCardPrice").css("display", "block");
    }
  } else {
    $("#showGiftCardPrice").css("display", "none");
  }

  // 修改余额
  if ($("#hiddenUsedBalance_coupon")[0]) {
    $("#usedBalanceId").text("-￥" + $("#hiddenUsedBalance_coupon").val());
    if ($("#hiddenUsedBalance_coupon").val() == 0) {
      $("#showUsedOrderBalance").css("display", "none");
    } else {
      $("#showUsedOrderBalance").css("display", "block");
    }
   $("#useBalanceShowDiscount").val($("#hiddenUsedBalance_coupon").val());
  } else {
    $("#showUsedOrderBalance").css("display", "none");
    $("#useBalanceShowDiscount").val(0);
  }

  // 修改应付余额
  if ($("#hiddenPayPrice_coupon")[0]) {
	  modifyNeedPay($("#hiddenPayPrice_coupon").val());
  }
}window.flushOrderPriceByCoupon= flushOrderPriceByCoupon;


function flushOrderCouponPriceByCoupon() {
  // 运费券
  if($("#hiddenCouponDiscount")[0]) {
    $("#freeFreightPriceId").text("-￥" + $("#hiddenFreeFreight_coupon").val());
    if($("#hiddenFreeFreight_coupon").val() == 0) {
      $("#showFreeFreight").css("display", "none");
    } else {
      $("#showFreeFreight").css("display", "block");
    }
  } else {
    $("#showFreeFreight").css("display", "none");
  }
  // 修改优惠券结算信息
  if($("#hiddenCouponDiscount")[0]) {
    // 运费券金额拆分再合并
    var couponDiscount = $("#hiddenCouponDiscount").val();
    if($("#hiddenFreeFreight_coupon").val() > 0) {
      couponDiscount = eval(parseFloat(couponDiscount) - parseFloat($("#hiddenFreeFreight_coupon").val()));
    }
    $("#couponPrice").text($("#hiddenCouponDiscount").val());
    $("#couponPriceId").text("-￥" + parseFloat(couponDiscount).toFixed(2));
    if(parseFloat(couponDiscount) > 0) {
      $("#showCouponPrice").css("display", "block");
      $("#couponPriceId").css("display", "block");
    } else {
      $("#showCouponPrice").css("display", "none");
      $("#couponPriceId").css("display", "none");
    }
  } else {
    $("#couponPriceId").css("display", "none");
  }
  
  // 修改应付余额
  if ($("#hiddenPayPrice_coupon")[0]) {
	  modifyNeedPay($("#hiddenPayPrice_coupon").val());
  }
}

function changeOrderPrice(result) {
  $("#safeLpkPart").show(); // 显示开启支付密码提示框
  $("#lpk_count").text("0");// 礼品卡数量
  $("#lpk_discount").text("0.00"); // 礼品卡列表栏金额
  $("#giftCardPriceId").text("-￥0.00"); // 商品金额栏的礼品卡金额
  modifyNeedPay(result.factPrice.toFixed(2));
  $("#usedBalanceId").text("-￥" + result.usedBalance.toFixed(2));
  $("#useBalanceShowDiscount").val(result.usedBalance.toFixed(2));
  // 余额显示变化
  if (result.usedBalanceFlag) {
    $("#selectOrderBalance").attr("checked", true);
    $("#showUsedOrderBalance").show();
    checkBalancePwdResult(BALANCE_PWD_TYPE);
  } else {
    $("#selectOrderBalance").attr("checked", false);
    $("#showUsedOrderBalance").hide();
  }
  save_Pay(0);
}

function changeGiftCardState(result) {
  $("#lpk_count").text(result.giftCardNum);
  $("#lpk_discount").text(result.giftCardPrice.toFixed(2));
  $("input[id^='lpkItem_']").each(function() {
    var cardId = $(this).attr("id").split("_")[1];
    $(this).attr("checked", false); // 是否勾选
    $("#lpkCurUsed_" + cardId).html("0.00");
  });
  if (result.giftCardInfoViewList != null && result.giftCardInfoViewList.length > 0) {
    $.each(result.giftCardInfoViewList, function(i, giftCardInfo) { // 重置礼品卡列表
      $("#lpkItem_" + giftCardInfo.id).attr("checked", true); // 是否勾选
      $("#lpkCurUsed_" + giftCardInfo.id).text(giftCardInfo.curUsedMoney.toFixed(2));
      $("#lpkBalance_" + giftCardInfo.id).text(giftCardInfo.balance.toFixed(2));
    });
  }
}

/**
 * 填充结算页面余额相关的金额信息
 */
function changeBalanceState(result) {
  modifyNeedPay(result.payPrice.toFixed(2))// 实际应付金额
  var showBalance="使用余额（账户当前余额："+' <span class="ftx-01">'+result.leaveBalance.toFixed(2) +'</span>元）';
  $("#canUsedBalanceId").html(showBalance);// 剩余可用余额
  $("#usedBalanceId").text("-￥" + result.usedBalance.toFixed(2)); // 使用的余额
  $("#selectOrderBalance").attr("checked", result.checked);
  if (result.usedBalance > 0) {
    $("#showUsedOrderBalance").show();
  } else {
    $("#showUsedOrderBalance").hide();
  }
  save_Pay(0);
}

/**
 * 重置所有优惠券不可用
 */
function cancelAllUsedCoupons() {
  $("input[id^='coupon_']").each(function() {
    $(this).attr("disabled", true);
    if ($(this).is(':checked')) {
      return false;
    }
  });
  var param = addFlowTypeParam();
  var url = OrderAppConfig.DynamicDomain + "/coupon/cancelAllUsedCoupons.action";
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        showMessageError(message);
        return;
      }
      $("#" + OrderAppConfig.Module_Coupon).html(result);
      $("#safeJingPart").show();
      entityCouponInputEventInit();
      $("input[type=checkbox][id^='coupon_']").each(function() {
        $(this).attr("disabled", true);
      });
      flushOrderPriceByCoupon();
      hideCouponTips();
    }
  });
}window.cancelAllUsedCoupons = cancelAllUsedCoupons;

/**
 * 是否需要支付密码
 */
function isNeedPaymentPassword() {
  var onlinepaytype=$(".payment-item.item-selected").attr('onlinepaytype');
  var lastSelect = $("#jdpy_cardInfo").val();
  if(onlinepaytype=="1"||(onlinepaytype=="3" && $("#"+lastSelect).attr("sign")=="1")){
	  $("#paypasswordPanel").show();
	  return;
  }
  $("#txt_paypassword").val("");
  var param = addFlowTypeParam();
  var url = OrderAppConfig.DynamicDomain + "/order/isNeedPaymentPassword.action";
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(flag) {
      if (isUserNotLogin(flag)) {
        goToLogin();
        return;
      }
      if (isHasMessage(flag)) {
        var message = getMessage(flag);
        showMessageError(message);
        return;
      } else {
        if (flag) {
          $("#paypasswordPanel").show();
        } else {
          $("#paypasswordPanel").hide();
        }
      }
    }
  });
}window.isNeedPaymentPassword = isNeedPaymentPassword;

/**
 * 改变优惠券、礼品卡样式
 */
function changeClassStyle(classId, classStyle) {
  $("#" + classId).removeClass();
  $("#" + classId).addClass(classStyle);
}window.changeClassStyle = changeClassStyle;

/**
 * 是否显示 输入实体券密码框
 */
function showEntityPanel() {
  if ($("#entityPanel")[0]) {
    if ($("#entityPanel").css("display") == "none") {
      $("#entityPanel").css("display", "block");
    } else {
      $("#entityPanel").css("display", "none");
    }
  }
}window.showEntityPanel = showEntityPanel;

/** ***************************************************礼品卡******************************************** */

/**
 * 礼品卡输入事件
 */
function lipinkaInputEventInit(giftCardType) {
  var orderGiftCardModule = OrderAppConfig.Module_GiftCard;
  if (giftCardType == 3) {
    orderGiftCardModule = OrderAppConfig.Module_GiftECard;
  }

  $("#" + orderGiftCardModule + " .itxt").keyup(function() {
    var $this = $(this);
    $this.val($this.val().replace(/[^a-zA-Z0-9]/g, '').toUpperCase());
    $this.val($this.val().replace('O', '0'));
    if ($this.val().length == 4 && $this.attr('id') != 'lpkKeyPressForth-' + giftCardType) {
      $this.next().next().focus();
    }
  });
}window.lipinkaInputEventInit = lipinkaInputEventInit;

/**
 * 实体优惠券输入事件 FIXME 对实体券输入没有生效，事件绑定错误。没有线上bug提出来，所以是否需要修改，等上级指示。 DYY
 */
function entityCouponInputEventInit() {
  $("#entityPanel .itxt").keyup(function() {
    var $this = $(this);
    $this.val($this.val().replace(/[^a-zA-Z0-9]/g, '').toUpperCase());
    $this.val($this.val().replace('O', '0'));
    if ($this.val().length == 4 && $this.attr('id') != 'couponKeyPressFourth') {
      $this.next().next().focus();
    }
  });
  if($("#isNewVertual").val() == "true"){
     $("#entityPanel .itxt").mouseover(function(){
      $("#couponKeyPressFirst").parents().find(".error-msg").hide();
    });
     
  }
}window.entityCouponInputEventInit = entityCouponInputEventInit;

function showGiftCard(flag)
{
  if(flag == 0){
    $("#avaiCard").attr("class","curr");
    $("#ecard-available").show();
    $("#unavaiCard").attr("class"," ");
    $("#ecard-unavailable").hide();
  }
  else if(flag == 1){
    $("#avaiCard").attr("class"," ");
    $("#ecard-available").hide();
    $("#unavaiCard").attr("class","curr");
    $("#ecard-unavailable").show();
  }
}
window.showGiftCard = showGiftCard;

function query_giftCards(giftCardType) {
  var giftCardProxyId = giftCardId;
  var orderGiftCardProxyItem = orderGiftCardItem;
  var orderGiftCardModule = OrderAppConfig.Module_GiftCard;
  if (giftCardType == 3) {
    giftCardProxyId = giftECardId;
    orderGiftCardProxyItem = orderGiftECardItem;
    orderGiftCardModule = OrderAppConfig.Module_GiftECard;
  }

  var flag = $("#" + giftCardProxyId).attr('class') == "toggle-wrap hide";
  if (flag) {// 显示礼品卡列表
    var param = "giftCardParam.giftCardType=" + giftCardType;
    param = addFlowTypeParam(param);
    var url = OrderAppConfig.DynamicDomain + "/giftCard/getGiftCardList.action";
    jQuery.ajax({
      type : "POST",
      dataType : "text",
      url : url,
      data : param,
      async : true,
      cache : false,
      success : function(result) {
        if (isUserNotLogin(result)) {
          goToLogin();
          return;
        }
        if (isHasMessage(result)) {
          var message = getMessage(result);
          showMessageError(message);
          return;
        } else {
          checkPaymentPasswordSafe(LPK_PWD_TYPE, giftCardType);
          // 显示礼品卡样式
          $("#" + giftCardProxyId).css('display', 'block');
          changeClassStyle(giftCardProxyId, toggleWrap);

          changeClassStyle(orderGiftCardProxyItem, itemToggleActive);
          $("#" + giftCardProxyId + " " + "#" + orderGiftCardModule).html(result);
          lipinkaInputEventInit(giftCardType); // 礼品卡输入KEY限制
        }
        
        eInfoTip();
      },
      error : function(XMLHttpResponse) {
        //alert("系统繁忙，请稍后再试！");
      }
    });

    // 使用礼品卡时，关闭优惠券列表
    // 隐藏优惠券列表
    couponTip();
    // $("#" + orderCouponId).css('display', 'none');
    // 优惠券隐藏样式
    // changeClassStyle(giftCardProxyId, toggleWrapHide);
    // changeClassStyle(orderGiftCardProxyItem, item);
  } else {
    // 隐藏礼品卡列表
    // 隐藏礼品卡样式
    $("#" + giftCardProxyId).css("display", "none");
    changeClassStyle(giftCardProxyId, toggleWrapHide);
    changeClassStyle(orderGiftCardProxyItem, item);
  }

}window.query_giftCards = query_giftCards;
/**
 * 检查礼品卡安 如果使用礼品卡，必须开启支付密码
 */
function checkUsedGiftCardsPwd(type, giftCardType) {
  var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
  var param = "couponParam.fundsPwdType=" + type;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(flag) {
      if (isUserNotLogin(flag)) {
        goToLogin();
        return;
      }
      if (!flag) {
        // 账户不安全，设置所有礼品卡不可用
        cancelAllUsedGiftCards(giftCardType);
      }
    }
  });
}window.checkUsedGiftCardsPwd = checkUsedGiftCardsPwd;

/**
 * 选择礼品卡
 * 
 * @param obj
 * @param bindFlag
 * @param key
 * @param id
 */
function selectGiftCard(obj, key, id, giftCardType) {
  var checked = obj.checked;
  if (checked) {
    useOrCancelGiftCard(OrderAppConfig.DynamicDomain + "/giftCard/useGiftCard.action", key, obj, checked, false, giftCardType);
  } else {
    useOrCancelGiftCard(OrderAppConfig.DynamicDomain + "/giftCard/cancelGiftCard.action", id, obj, checked, false, giftCardType);
  }
}window.selectGiftCard = selectGiftCard;

/**
 * 添加礼品卡
 */
function addGiftCard(obj, giftCardType) {
  if ($("#lpkKeyPressFirst" + "-" + giftCardType).val() == "" || $("#lpkKeyPressSecond" + "-" + giftCardType).val() == ""
      || $("#lpkKeyPressThird" + "-" + giftCardType).val() == "" || $("#lpkKeyPressForth" + "-" + giftCardType).val() == "") {
    if (giftCardType == 3) {
      showMessageWarn("请输入京东E卡密码");
    } else {
      showMessageWarn("请输入京东卡密码");
    }
    return;
  }

  var param = "couponParam.fundsPwdType=GiftCard";
  var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(flag) {
      if (isUserNotLogin(flag)) {
        goToLogin();
        return;
      }
      if (flag) {
        var key = $("#lpkKeyPressFirst" + "-" + giftCardType).val() + "-" + $("#lpkKeyPressSecond" + "-" + giftCardType).val() + "-"
          + $("#lpkKeyPressThird" + "-" + giftCardType).val() + "-" + $("#lpkKeyPressForth" + "-" + giftCardType).val();
        useOrCancelGiftCard(OrderAppConfig.DynamicDomain + "/giftCard/useMaterialGiftCard.action", key, obj, false, true, giftCardType);
      } else {
        showLargeMessage("支付密码未开启", "为保障您的账户资金安全，请先开启支付密码");
        return;
      }
    }
  });

}window.addGiftCard = addGiftCard;

/**
 * 使用或者取消礼品卡
 * 
 * @param url
 * @param key
 * @param obj
 * @param checked
 * @param bindFlag
 */
function useOrCancelGiftCard(url, key, obj, checked, bindFlag, giftCardType) {
  var param = "giftCardParam.giftCardType=" + giftCardType + "&giftCardKey=" + key + "&fundsPwdtype=" + LPK_PWD_TYPE;
  var orderGiftCardModule = OrderAppConfig.Module_GiftCard;
  var giftCardProxyId = giftCardId;
  var orderGiftCardProxyItem = orderGiftCardItem;
  var giftCardTypeName = "京东卡";
  if (giftCardType == 3) {
    giftCardProxyId = giftECardId;
    orderGiftCardProxyItem = orderGiftECardItem;
    orderGiftCardModule = OrderAppConfig.Module_GiftECard;
    giftCardTypeName = "京东E卡";
  }
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      // 没有登录跳登录
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (result == false || result == "false") {
        // 隐藏礼品卡列表
        // 隐藏礼品卡样式
        $("#" + giftCardProxyId).css("display", "none");
        changeClassStyle(giftCardProxyId, toggleWrapHide);
        changeClassStyle(orderGiftCardProxyItem, item);
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        alert(message);
        if (checked == true) {
          $(obj).attr("checked", false);
        } else {
          $(obj).attr("checked", true);
        }
        return;
      }
      checkPaymentPasswordSafe(LPK_PWD_TYPE, giftCardType);
      $("#" + orderGiftCardModule).html(result);
      changeOrderInfoPrice(giftCardType);
      isNeedPaymentPassword();// 是否需要支付密码
      if (bindFlag && ($("#hiddenBindFlag" + "-" + giftCardType).val() == "true")) {

        if (confirm("密码正确！是否将该" + giftCardTypeName + "绑定至当前账号？")) {
          bindGiftCard(key, giftCardType); // 异步判断是否绑定成功
        }
      }
      lipinkaInputEventInit(giftCardType); // 礼品卡输入KEY限制
    }
  });
}window.useOrCancelGiftCard=useOrCancelGiftCard;

function changeOrderInfoPrice(giftCardType) {
  // 已优惠的礼品卡金额
  if ($("#hiddenGiftCardDiscount" + "-" + giftCardType)[0]) {
    $("#giftCardPriceId").text("-￥" + $("#hiddenGiftCardDiscount" + "-" + giftCardType).val());
    if ($("#hiddenGiftCardDiscount" + "-" + giftCardType).val() > 0) {
      $("#showGiftCardPrice").show();
    } else {
      $("#showGiftCardPrice").hide();
    }
  }

  // 余额
  if ($("#hiddenUsedBalance" + "-" + giftCardType)[0]) {
    $("#usedBalanceId").text("-￥" + $("#hiddenUsedBalance" + "-" + giftCardType).val());
    if ($("#hiddenUsedBalance" + "-" + giftCardType).val() > 0) {
      $("#showUsedOrderBalance").show();
    } else {
      $("#showUsedOrderBalance").hide();
    }
  }

  // 实际应付金额
  if ($("#hiddenPayPrice" + "-" + giftCardType)[0]) {
	modifyNeedPay($("#hiddenPayPrice" + "-" + giftCardType).val());
  }
  save_Pay(0);
}window.changeOrderInfoPrice = changeOrderInfoPrice;
/**
 * 绑定礼品卡
 */
function bindGiftCard(key, giftCardType) {
  var param = "giftCardParam.giftCardType=" + giftCardType + "&giftCardKey=" + key;
  var url = OrderAppConfig.DynamicDomain + "/giftCard/bindGiftCard.action";

  var orderGiftCardModule = OrderAppConfig.Module_GiftCard;
  if (giftCardType == 3) {
    orderGiftCardModule = OrderAppConfig.Module_GiftECard;
  }

  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        alert(message);
        return;
      }
      $("#" + orderGiftCardModule).html(result);
      isNeedPaymentPassword();// 是否需要支付密码
      lipinkaInputEventInit(giftCardType); // 礼品卡输入KEY限制
    }
  });
}window.bindGiftCard = bindGiftCard;

/**
 * 重置所有礼品卡不可用
 */
function cancelAllUsedGiftCards(giftCardType) {
  $("input[type=checkbox][id^='lpkItem_']").each(function() {
    $(this).attr("disabled", true);
    if ($(this).is(":checked")) {
    }
  });

  var orderGiftCardModule = OrderAppConfig.Module_GiftCard;
  if (giftCardType == 3) {
    orderGiftCardModule = OrderAppConfig.Module_GiftECard;
  }

  // 发请求取消所有礼品卡的使用
  var param = "giftCardParam.giftCardType=" + giftCardType;
  param = addFlowTypeParam(param);
  var url = OrderAppConfig.DynamicDomain + "/giftCard/cancelAllGiftCard.action";
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        showMessageError(message);
        $("input[type=checkbox][id^='lpkItem_']").attr("disabled", false);
        return;
      }
      $("#" + orderGiftCardModule).html(result);
      $("input[type=checkbox][id^='lpkItem_']").each(function() {
        $(this).attr("disabled", true);
      });
      $("#safeLpkPart" + "-" + giftCardType).show();
      changeOrderInfoPrice(giftCardType);
      lipinkaInputEventInit(giftCardType); // 礼品卡输入KEY限制
    }
  });
}window.cancelAllUsedGiftCards = cancelAllUsedGiftCards;
/** ***************************************************余额******************************************** */

function useOrCancelBalance(obj) {
  var url = "";
  var flag = $(obj).is(':checked') ? 1 : 0;

  if (flag) {
    url = OrderAppConfig.DynamicDomain + "/balance/useBalance.action";
  } else {
    url = OrderAppConfig.DynamicDomain + "/balance/cancelBalance.action";
  }
  var param = "fundsPwdType=" + BALANCE_PWD_TYPE;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(result) {
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (isHasMessage(result)) {
        var message = getMessage(result);
        alert(message);
        if (flag == 1) {
          $(obj).attr("checked", false);
        } else {
          $(obj).attr("checked", true);
        }
        return;
      } else if (result != null && result == false) {
        // 开启支付密码接口失败
        cancelUsedBalance();
      } else if (result != null && result != false) {
        changeBalanceState(result);
        isNeedPaymentPassword();// 是否需要支付密码
        if ($("#selectOrderBalance").is(":checked")) { // 余额被使用时，验证是否安全
          checkBalancePwdResult(BALANCE_PWD_TYPE);
        }
      }
    }
  });
}window.useOrCancelBalance = useOrCancelBalance;
// ****************************************************订单页面相关****************************************************************

/**
 * 加载页面异步相关信息
 */
function loadOrderExt() {
  var actionUrl = OrderAppConfig.AsyncDomain + "/obtainOrderExt.action";
  var param = addFlowTypeParam();
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      // 服务器返回异常处理,如果有消息div则放入,没有则弹出
      if (isHasMessage(dataResult)) {
        var message = getMessage(dataResult);
        showMessageError(message);
      }
      // ===============3.备注==============
      if (dataResult.showOrderRemark) {
        showOrderRemark();
      }
      // ===============4.是否需要支付密码==============
      
      if (dataResult.needPayPwd) {
        $("#paypasswordPanel").show();
      } else{
    	  var onlinepaytype=$(".payment-item.item-selected").attr('onlinepaytype');
    	  var lastSelect = $("#jdpy_cardInfo").val();
    	  if(onlinepaytype!="1"&& !(onlinepaytype=="3" && $("#"+lastSelect).attr("sign")=="1")){
    		  $("#paypasswordPanel").hide();
    	  }
    	  
      }
      // ==================5.加载余额==================
      if (dataResult.balance && dataResult.balance.success) {
        var useFlag = dataResult.balance.checked;
        $("#selectOrderBalance").attr("checked", useFlag);
        var showBalance="使用余额（账户当前余额："+' <span class="ftx-01">'+ dataResult.balance.leavyMoney.toFixed(2) +'</span>元）';
        $("#canUsedBalanceId").html(showBalance);// 剩余可用余额
        if (dataResult.balance.leavyMoney > 0) {
          $('#balance-div .toggler').click();
          $('#selectOrderBalance').removeAttr('disabled');
        } else {
          $('#selectOrderBalance').attr('disabled','disabled');
        }
        // // 验证余额是否开启支付密码
        // if (dataResult.showOpenPayPwd) {
        //   cancelUsedBalance();
        // }
      }
      // 验证余额是否开启支付密码
      //位置调整
      if (dataResult.showOpenPayPwd) {
        cancelUsedBalance();
      }


      // 京豆优惠购是否足额和京豆优惠购商品id
      var showOpenPayPwd = dataResult.showOpenPayPwd;
      var existsJdbeanPromotion = dataResult.existsJdbeanPromotion;
      var checkJdbeanPromotion = dataResult.checkJdbeanPromotion;
      // 成功后如果有divID直接放入div，没有则返回结果
      checkShowOpenPwd(showOpenPayPwd, existsJdbeanPromotion, checkJdbeanPromotion);
      //优惠券异步加载可用优惠券数量
      if($("#isNewVertual").val() == "true"){
          vertualCoupontips();
          refushHasAvailableVertual(dataResult);
      }else if($("#invokeNewCouponInterface").val() == "true"){
    	  showCouponAvailableNumByRpc(dataResult.availableCouponNum);
    	  showCouponSkuList();
      }
    },
    error : function(XMLHttpResponse) {
      // ignore
    }
  });
}

/**
 * 加载商品清单库存状态数据
 */
function loadSkuListStockData(states) {
  $(".p-state").each(function() {
    var skuId = $(this).attr("skuId");
    if (states) {
      for (var keyId in states) {
        if (keyId == skuId) {
          var state = parseInt(states[keyId].a);
          var info;
          switch (state) {
          case 33:
          case 39:
          case 40:
            info = "有货";
            break;
          case 34:
            info = "<span style='color:#e4393c'>无货</span>";
            break;
          case 36:
            info = "预订";
            break;
          default:
            info = "<span style='color:#e4393c'>无货</span>";
          }
          //闪购JIT
          if(states[keyId].u && states[keyId].u == '1'){
            info = "有货";
          }
          $(this).html(info);
        }
      }
    } else {
      $(this).html("有货");
    }
  });
}

/**
 * 获取库存状态，新版需要根据收货地址区分区域，如1,2,3,4
 */
function getAreaIds() {
  if("1" == $("#flowType").val()) {// 本地生活流程，地址id可用1,0,0,0，库存组王振确认
    return "1,0,0,0";
  }
  var hideAreaIds = $("#hideAreaIds").val();
  if(hideAreaIds) {
    return hideAreaIds.split('-').join(',');
  } else {
    return "1,0,0,0";
  }
}

/**
 * 获取库存状态:获取所有商品
 */
function getAllSkuListId() {
  var allSkuListId = "";
  var mainSkuIdAndNums = $("#mainSkuIdAndNums").val();
  if (mainSkuIdAndNums != null && mainSkuIdAndNums != "") {
    var mainSkuIdAndNumsAry = mainSkuIdAndNums.split(",");
    if (mainSkuIdAndNumsAry != null && mainSkuIdAndNumsAry.length > 0) {
      for (var i = 0; i < mainSkuIdAndNumsAry.length - 1; i++) {
        if (mainSkuIdAndNumsAry[i] != null && mainSkuIdAndNumsAry[i] != "") {
          var skuAndNumAry = mainSkuIdAndNumsAry[i].split("_");
          // 新版库存状态接口需要传入sku数量，且入参格式变化为 12345,1;54321,2
          if (i == 0) {
            allSkuListId += skuAndNumAry[0] + "," + skuAndNumAry[1];
          } else {
            allSkuListId += ";" + skuAndNumAry[0] + "," + skuAndNumAry[1];
          }
        }
      }
    }
  }
  return allSkuListId;
}

/**
 * 异步加载商品清单库存状态
 * app=trade_ex 库存组王振提供
 */
function loadSkuListStock() {
  var areaIds = getAreaIds();
  var skus = getAllSkuListId();
  var actionUrl = OrderAppConfig.SkusStockStateUrl + "/ss/areaStockState/mget?app=trade_ex&ch=1&skuNum="+skus+"&area="+areaIds+"&r="+ Math.random();
  jQuery.ajax({
    type : "get",
    dataType : "jsonp",
    url : actionUrl,
    cache : false,
    success : function(dataResult) {
      loadSkuListStockData(dataResult);// 成功后如果有divID直接放入div，没有则返回结果
    },
    error : function(XMLHttpResponse) {
      // ignore no console log
    }
  });
}window.loadSkuListStock=loadSkuListStock;

/**
 * 添加备注
 */
function selectRemark(obj) {
  if ($("#remarkId").attr("class") == toggleWrapHide) {
    $("#remarkId").removeClass();
    $("#remarkId").addClass("toggle-wrap");
    changeClassStyle("orderRemarkItem", itemToggleActive);
    if ($("#remarkText").val() == "") {
      $("#remarkText").val("限45个字");
    }
  } else {
    $("#remarkId").removeClass();
    $("#remarkId").addClass("toggle-wrap hide");
    changeClassStyle("orderRemarkItem", item);
  }
}

/**
 * 订单页面余额
 */
function loadOrderBalance() {
  if (!$("#selectOrderBalance").is(":checked")) {
    var actionUrl = OrderAppConfig.AsyncDomain + "/isShowOrderBalance.action";
    var param = addFlowTypeParam();
    jQuery.ajax({
      type : "POST",
      dataType : "json",
      url : actionUrl,
      data : param,
      cache : false,
      success : function(result, textStatus) {
        // 没有登录跳登录
        if (isUserNotLogin(result)) {
          goToLogin();
          return;
        }
        if (result.resultFlag) {
          var useFlag = result.checked;
          $("#selectOrderBalance").attr("checked", useFlag);
          var showBalance="使用余额（账户当前余额："+' <span class="ftx-01">'+ result.leavyMoney.toFixed(2) +'</span>元）';
          $("#canUsedBalanceId").html(showBalance);// 剩余可用余额
          if (result.leavyMoney > 0) {
            $("#showOrderBalance").css("display", "block");
          } else {
            $("#showOrderBalance").css("display", "none");
          }
          checkBalancePwdResult(BALANCE_PWD_TYPE);// 验证余额是否开启支付密码
        }

      },
      error : function(XMLHttpResponse) {
      }
    });
  }
}

/**
 * 显示订单备注
 */
function showOrderRemark() {
  var remarkTemplate = "<div class='remark-tit'>添加订单备注</div>"
    + "<div id='remarkId' style='margin-bottom:7px'>"
    + "  <div class='form remark-cont'>"
    + "    <input type='text' id='remarkText' maxlength='45' size='15' class='itxt itxt01' placeholder='限45个字（定制类商品，请将购买需求在备注中做详细说明）'" 
    + "      onblur=" + "\"" + "if(this.value==''||this.value=='限45个字（定制类商品，请将购买需求在备注中做详细说明）'){this.value='限45个字（定制类商品，请将购买需求在备注中做详细说明）';this.style.color='#cccccc'}" 
    + "\"" + "onfocus=" + "\"" + "if(this.value=='限45个字（定制类商品，请将购买需求在备注中做详细说明）') {this.value='';};this.style.color='#000000';" 
    + "\"" + "  />  " 
    + "    <span class='ftx-03 ml10'>&nbsp;&nbsp;提示：请勿填写有关支付、收货、发票方面的信息</span>"
    + "  </div>" 
    + "</div>";
  $("#orderRemarkItem").show();
  $("#orderRemarkItem").html(remarkTemplate);
  // fix bug EXEX-68
  // $('.remark-tit').bind('click',function(){
  //   if($('#remarkId').is(":hidden")) {
  //     $('#remarkId').show();
  //   } else {
  //     $('#remarkId').hide();
  //   }
  // });
}

/**
 * 是否显示订单备注
 */
function loadOrderRemark() {
  var actionUrl = OrderAppConfig.AsyncDomain + "/isShowOrderRemark.action";
  var param = addFlowTypeParam();
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(result, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      if (result == true) {
        showOrderRemark();
      }else{
        $("#orderRemarkItem").hide();
        $("#orderRemarkItem").html('');
      }
    },
    error : function(XMLHttpResponse) {
    }
  });

}window.loadOrderRemark=loadOrderRemark;

function editOrderRemark(obj) {
  if ($(obj).val() == "限15个字") {
    $(obj).val("");
  }
}


// 判断是否加载验证码
function showCheckCode() {
  var showCheckCode = $("#showCheckCode").val();
  var encryptClientInfo = $("#encryptClientInfo").val();
  if (showCheckCode == "true") {
    refreshCheckCode(encryptClientInfo);
  }
}

/**
 * 获取验证码模版
 * 
 * @returns {String}
 */
function getCheckCodeTemplate(encryptClientInfo) {
  var rid = Math.random().toString() + "_" + Math.random().toString();
  var checkCodeUrl = "//captcha.jd.com/verify/image?acid=" + rid + "&srcid=trackWeb&is=" + encryptClientInfo;
  return "<span class='identifying-code'>" + "<img id='orderCheckCodeImg' src='" + checkCodeUrl + "' onclick='getNextCheckCode()' "
      + "alt='点击更换验证码' title='点击更换验证码' style='display:inline;cursor:pointer;border:#ebcca0 1px solid;' />"
      + "<input id='checkcodeTxt' type='text' style='height: 34px; width: 70px; margin: 0px 5px; padding-left: 2px; font-weight: bold; font-size: large;' />"
      + "<input id='checkcodeRid' type='hidden' value='" + rid + "' />" 
      + "<input id='encryptClientInfo' type='hidden' value='" + encryptClientInfo + "' />"
      + "</span>";
}

/**
 * 显示下一张验证码
 * 
 * @param obj
 */
function getNextCheckCode() {
  var obj = document.getElementById("orderCheckCodeImg");
  var rid = Math.random().toString() + "_" + Math.random().toString();
  var encryptClientInfo = $("#encryptClientInfo").val();

  var checkCodeUrl = "//captcha.jd.com/verify/image?acid=" + rid + "&srcid=trackWeb&is=" + encryptClientInfo;

  obj.src = checkCodeUrl;
  $("#checkcodeRid").val(rid);
  $('#checkcodeTxt').val("");
}window.getNextCheckCode = getNextCheckCode;

/**
 * 刷新验证码
 */
function refreshCheckCode(encryptClientInfo) {
  if (isEmpty($("#checkCodeDiv").html())) {
    $("#checkCodeDiv").html(getCheckCodeTemplate(encryptClientInfo));
  } else {
    getNextCheckCode();
  }
}

/**
 * 是否展开配收货人
 */
function isNewUser() {
  if (checkIsNewUser()) {
    if (isLocBuy()) {
      edit_LocConsignee();
    } else {
      use_NewConsignee();
    }
  }
}

/**
 * 检查是否是新用户
 * 
 * @returns {Boolean}
 */
function checkIsNewUser() {
  var val = $("#isOpenConsignee").val();
  if (val != undefined && (val == 1 || val == "1")) {
    return true;
  }
  return false;
}window.checkIsNewUser=checkIsNewUser;

/**
 * 是否刷新地址，针对轻松购
 * 
 * @return
 */
function isRefreshArea() {
  var val = $("#isRefreshArea").val();
  if (val != undefined && (val == 1 || val == "1")) {
    return true;
  }
  return false;
}

/**
 * 大家电换区逻辑
 */
function isBigItemChange() {
  if ($("#isChangeItemByArea").val() === "true") {
    return true;
  }
  return false;
}window.isBigItemChange=isBigItemChange;

/**
 * 是否含有糖酒
 */
function hasTang9() {
  if ($("#hasTang9").val() == "true" || $("#hasTang9").val() == true) {
    return true;
  }
  return false;
}window.hasTang9=hasTang9;

/**
 * 提交订单方法
 */
function submit_Order() {
  var actionUrl = OrderAppConfig.Domain + "/order/submitOrder.action";
  var checkcodeTxt = null;
  var checkCodeRid = null;
  var payPassword = null;
  var remark = null;
  var trackID = null;
  var mobileForPresale = null;
  var presalePayType = null;
  var param = "";
  // 检查如果存在没保存，则直接弹到锚点
  if (!$("#submit_check_info_message").is(":hidden")) {
    var anchor = $("#anchor_info").val();
    window.location.hash = anchor;
    return;
  }
  // 验证是否输入验证码
  if (!isEmpty($("#checkCodeDiv").html())) {
    checkcodeTxt = $("#checkcodeTxt").val();
    if (isEmpty(checkcodeTxt)) {
      alert("请先填写验证码!");
      return;
    }
  }
  // 验证码的随机码
  if (!isEmpty($("#checkCodeDiv").html())) {
    checkCodeRid = $("#checkcodeRid").val();
  }
  // 验证是否输入支付密码
  if (!$("#paypasswordPanel").is(":hidden")) {
    payPassword = $("#txt_paypassword").val();
    if (isEmpty(payPassword)) {
      $("#no-pwd-error").show();
      return;
    }
  }

  // 预售验证手机号
  if ($("#isPresale").val() == "true") {
    if ($("#presaleStepPay").val() == "1") {// 全款支付
      presalePayType = 1;
    }else if ($("#presaleStepPay").val() == "3") { // 定金支付
      presalePayType = 2;
    }else if ($("#presaleStepPay").val() == "5") { // 定金支付
      presalePayType = 2;
    }else if ($("#presaleStepPay").val() == "2"||$("#presaleStepPay").val() == "4") {
      if ($("#AllPayRadio").attr("class") == "presale-payment-item item-selected"){
        presalePayType = 1;
      } else {
        presalePayType = 2;
      }
    }
    if (presalePayType == 2) {// 定金支付必须要手机号码
      if (check_presaleMobile()) {
        if ($("#presaleMobile input").size() > 0) {
          mobileForPresale = $("#presaleMobile input").val();
          if(mobileForPresale.indexOf("*") > -1){
            return false;
          }
        } else {
          mobileForPresale = $("#userMobileByPresale").html();
        }
      } else {
        alert("请您先输入有效的预售手机号");
        return;
      }
    }
    if ($("#presaleEarnest").prop("checked") != true) {
      alert("请您同意交付定金");
      return;
    }
  }

  // 获取订单备注
  if (!isEmpty($("#orderRemarkItem").html())) {
    remark = $("#remarkText").val();
    if (remark == "限45个字"){
      remark = "";
    }
    else{
      if(!is_order_remark_forbid(remark)){alert('订单备注中含有非法字符'); return ;}
    }
  }

  if (!isEmpty(checkcodeTxt)) {
    param = param + "submitOrderParam.checkcodeTxt=" + checkcodeTxt;
  }
    param = param +"&overseaPurchaseCookies="+$("#overseaPurchaseCookies").val();
  if (!isEmpty(checkCodeRid)) {
    param = param + "&submitOrderParam.checkCodeRid=" + checkCodeRid;
  }
  if (!isEmpty(payPassword)) {
    param = param + "&submitOrderParam.payPassword=" + encodeURIComponent(stringToHex(payPassword));
  }
  if (!isEmpty(remark)) {
    param = param + "&submitOrderParam.remark=" + remark;
  }
  if (!isEmpty($("#sopNotPutInvoice").val())) {
    param = param + "&submitOrderParam.sopNotPutInvoice=" + $("#sopNotPutInvoice").val();
  } else {
    param = param + "&submitOrderParam.sopNotPutInvoice=" + false;
  }
  if (!isEmpty(mobileForPresale)) {
    param = param + "&submitOrderParam.presaleMobile=" + mobileForPresale;
  }
  if (null != presalePayType) {
    param = param + "&submitOrderParam.presalePayType=" + presalePayType;
  }
  if (isGiftBuy()) {
    var hidePrice = false;
    if (!$("#giftBuyHidePriceDiv").is(":hidden")) {
      hidePrice = $("#giftBuyHidePrice").is(":checked");
    }
    param = param + "&submitOrderParam.giftBuyHidePrice=" + hidePrice;
  }
  trackID = $("#TrackID").val();
  if (!isEmpty(trackID)) {
    param = param + "&submitOrderParam.trackID=" + trackID;
  }
  var indexFlag = param.substring(0, 1);
  if (indexFlag == "&") {
    param = param.substring(1, param.length);
  }
  param = addFlowTypeParam(param);
  var regionId = $("#regionId").val();
  var shopId = $("#shopId").val();
  if(regionId){
    param += "&regionId=" + regionId;
  }
  if(shopId){
    param += "&shopId=" + shopId;
  }
  var easyBuyFlag = $("#easyBuyFlag").val();
  if(easyBuyFlag == "1"||easyBuyFlag=="2"){
    param += "&ebf=" + easyBuyFlag;
  }
  var ignorePriceChange = $('#ignorePriceChange').val();
  if(ignorePriceChange){
    param += "&submitOrderParam.ignorePriceChange=" + ignorePriceChange;
  }
  var onlinepaytype = $(".payment-item.item-selected").attr('onlinepaytype');
  var paymentId = $(".payment-item.item-selected").attr('payid');
  try{
	  log('ord', 'trade', '20',paymentId+onlinepaytype);
	}catch(e){
	}
  if(onlinepaytype=="1"){
      var lastneedPay=$("#lastneedPay").val();
      var limit = $("#cod_bt").attr("limit");
      if(parseFloat(lastneedPay)>parseFloat(limit)){
    	  showSubmitErrorMessage("亲爱的用户您的白条剩余额度￥"+limit+"，请选择其他支付方式！");
    	  return;
      }
	  var baitiaoInfo = $("#baitiaoPayRequest").val();
	  if(!isEmpty(baitiaoInfo)){
		  param += "&" + baitiaoInfo;
	  }
  }
  if($(".payment-item[onlinepaytype=1]").length==0||$(".payment-item[onlinepaytype=1]").hasClass("payment-item-disabled")){
	  param += "&submitOrderParam.btSupport=0";
  }else{
	  param += "&submitOrderParam.btSupport=1";
  }
  if(onlinepaytype=="3"){
	  var card=$("#"+$("#jdpy_cardInfo").val());
	  var cardInfo = card.attr("cardInfo");
	  var cardkey = card.attr("key");
	  if(!isEmpty(cardInfo)){
		  param += "&submitOrderParam.cardInfo=" + cardInfo;
	  }
	  if(!isEmpty(cardkey)){
		  param += "&submitOrderParam.cardkey=" + cardkey;
	  }
	  param += "&submitOrderParam.cardsign=" + card.attr("sign");
	  param += "&submitOrderParam.cardvalid=" + card.attr("valid");
	  param += "&submitOrderParam.cardid=" + card.attr("id");
  }
  var eid = $('#eid').val();
  if(eid){
	param += "&submitOrderParam.eid=" + eid;
  }
  var fp = $('#fp').val();
  if(fp){
	 param += "&submitOrderParam.fp=" + fp;
  }
  var isBestCoupon =$('#isBestCoupon').val();
  if(isBestCoupon){
    param +="&submitOrderParam.isBestCoupon="+isBestCoupon;
  }

  var submitButtonABTest = $('#submitButtonABTest').val();
  if(submitButtonABTest && submitButtonABTest == 1){
    log('ord_abtest','trade_abtest', $('#order-submit').data('data-clkwl'));
  }
  // 提交loading
  $('body').append("<div id='submit_loading' class='purchase-loading'><div class='loading-cont'></div></div>");
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(result) {
      // 没有登录跳登录
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      $('#ignorePriceChange').val(0);
      if (result.success) {
        // 跳订单中心列表
    	if(result.payInfo){
    		$('#direct_pay input[name=orderId]').val(result.payInfo.orderId);
    		$('#direct_pay input[name=orderType]').val(result.payInfo.orderType);
    		$('#direct_pay input[name=toType]').val(result.payInfo.toType);
    		$('#direct_pay input[name=directPayInfoJson]').val(result.payInfo.directPayInfoJson);
    		$('#direct_pay input[name=payMethod]').val(result.payInfo.payMethod);
    		$('#direct_pay input[name=key]').val(result.payInfo.key);
    		 window.setTimeout("$('#direct_pay').submit();",450);
    		
    		return;
    	}
        if (result.goJumpOrderCenter) {
          successUrl = OrderAppConfig.Protocol +"order.jd.com/center/list.action";
          // 等待拆单，定时450毫秒
          window.setTimeout('window.location.href=successUrl+"?rd="+Math.random();', 450);
          return;

        } else {
          successUrl = "//success.jd.com/success/success.action";
          window.location.href = successUrl + "?orderId=" + result.orderId + "&rid=" + Math.random();
          return;
        }

      } else {
        if (result.message != null) {
          //价格提高
          if(result.resultCode == 600160){
            $("#submit_loading").remove();
            showPriceIncreaseDialog(result.message);
          } else if(result.message.indexOf("支付密码不正确") != -1){
        	  $("#submit_loading").remove();
        	  $("#pwd-error .error-msg").text(result.message);
        	  $("#pwd-error").show();
        	  return;
          }else if (result.message.indexOf("商品无货") != -1 && !isLocBuy()) {
            $("#submit_loading").remove();
            var outSkus = result.noStockSkuIds;
            var resultCode = result.resultCode;
            // 对无货商品的处理
            showSubmitErrorMessage(result.message);
            if (!isEmpty(outSkus)) {
              if (isLipinkaPhysical()) {
                return;
              }
              var flowType = $("#flowType").val();
              if((flowType == "" || flowType == 10) && resultCode != 600159){
                doOutSku(outSkus, resultCode);
              }else{
                window.location.href = cartUrl + '?outSkus=' + outSkus + '&rid=' + Math.random();
                return;
              }
            }
          } else if (result.message.indexOf("收货人信息中的省市县选择有误") != -1) {
            var consigneeId = $("#consignee_id").val();
            //consigneeList(consigneeId);
            $("#submit_loading").remove();
            showSubmitErrorMessage("亲爱的用户，由于地址已经升级，请重新选择！");
          } else if (result.message.indexOf("由于订单金额较大") != -1) {
            $("#submit_loading").remove();
            showSubmitErrorMessage(result.message);
            return;
          } else if (result.message.indexOf("验证码不正确") != -1) {
            $("#submit_loading").remove();
            showSubmitErrorMessage(result.message);
            getNextCheckCode();// 刷新验证码
            return;
          } else if (result.message.indexOf("正在参与预售活动") != -1) {
            var a = result.message.indexOf("您购买的商品");
            var b = result.message.indexOf("正在参与预售活动");
            var outSkus = result.message.substring(a + 6, b);
            if (!isEmpty(outSkus)) {
              var tmpHtml = "";
              var skuList = outSkus.split(",");
              for (var i = 0; i < skuList.length; i++) {
                tmpHtml = tmpHtml + "<a target=\"_parent\" href=\"http://item.jd.com/" + skuList[i] + ".html\">" + skuList[i] + "</a>,";
              }
              tmpHtml = tmpHtml.substring(0, tmpHtml.length - 1);
              result.message = "您购买的商品" + tmpHtml + "正在参与预售活动,请进入商品详情页单独购买";
            }
            $("#submit_loading").remove();
            showSubmitErrorMessage(result.message);
          } else {
            $("#submit_loading").remove();
            showSubmitErrorMessage(result.message);
            return;
          }
        } else {
          $("#submit_loading").remove();
          showSubmitErrorMessage("亲爱的用户请不要频繁点击, 请稍后重试...");
          return;
        }
      }
    },
    error : function(error) {
      $("#submit_loading").remove();
      $('#ignorePriceChange').val(0);
      showSubmitErrorMessage("亲爱的用户请不要频繁点击, 请稍后重试...");
    }
  });
}window.submit_Order = submit_Order;
  /**
   *  价格不一致 对话框
   */
function showPriceIncreaseDialog(message){

    var skuPriceDetialInfoList = JSON.parse(message);
    if(skuPriceDetialInfoList.length == 0){
      return;
    }
    var list = '';
    for(var i = 0; i < skuPriceDetialInfoList.length; i++){
      var name = skuPriceDetialInfoList[i].name;
      var imgUrl = skuPriceDetialInfoList[i].imgUrl;
      var discountPricePrevious = skuPriceDetialInfoList[i].discountPricePrevious;
      var discountPriceNow = skuPriceDetialInfoList[i].discountPriceNow;
      var giftList = skuPriceDetialInfoList[i].giftList;
      var yanBaoList = skuPriceDetialInfoList[i].yanBaoList;
      list += '<div class="goods-item">'+
      '<div class="p-img"><a href="#none"><img src="//img14.360buyimg.com/N4/' + imgUrl + '" alt=""></a></div>'+
      '<div class="goods-msg">'+
      '<div class="p-name"><a href="#none">' + name + '</a> </div>'+
      '<div class="p-price">当前价：<strong>￥' + discountPriceNow.toFixed(2) + '</strong><span class="ftx-03">初始价：<del>￥' + discountPricePrevious.toFixed(2) + '</del></span></div>'+
      '</div>' + '<div class="clr"></div><div class="gift-items">'
      list += getGiftList(giftList);
      list += getYanBaoList(yanBaoList);
      list += '</div></div>';
    }

    var listBefore = '<div class="price-change-thickbox"><div class="tip-box icon-box"><span class="joyc-icon m-icon"></span><div class="item-fore"><h3>部分商品优惠时间已过，确定提交订单？</h3></div></div><div class="goods-items">';
    var listAfter = '</div><div class="op-btns ac"><a href="#none" class="btn-9" onclick="reCheckOrderInfo()">返回查看订单</a><a href="javascript:$.closeDialog();" class="btn-1 ml10" onclick="submitOrderIgnorePrice()">提交订单</a></div></div>';
    list = listBefore + list + listAfter;
    $('body').dialog({
      title:'价格变动提示',
      width:670,
      type:'text',
      maskIframe: true,
      source:list,
      onReady:function() {
        $(".ui-dialog-close").hide();
      }
    });

}window.showPriceIncreaseDialog = showPriceIncreaseDialog;
  /**
   * 价格不一致 重新检查一下价格
   */
function reCheckOrderInfo(){
    log('gz_ord','gz_proc',6,'szfhckdd');
    window.location.reload();
}window.reCheckOrderInfo = reCheckOrderInfo;
  /**
   * 价格不一致 不顾价格变化，直接提交订单
   */
function submitOrderIgnorePrice(){
    log('gz_ord','gz_proc',6,'sztjdd');
    $('#ignorePriceChange').val(1);
    submit_Order();
}window.submitOrderIgnorePrice = submitOrderIgnorePrice;
  /**
   * 价格不一致 组装赠品信息
   * @param giftList
   * @returns {string}
   */
function getGiftList(giftList){
    var list = '';
    if(!giftList || giftList.length == 0) {
      return list;
    }

    for(var i = 0; i < giftList.length; i++){
      var name = giftList[i].name;
      var buyNum = giftList[i].buyNum;
      list += '<div class="gift-item ftx-03">'
      +'<p>【赠品】&nbsp;' + name + '&nbsp;x&nbsp;' + buyNum + '</p>'
      +'</div>';
    }
    return list;
}window.getGiftList = getGiftList;
  /**
   * 价格不一致 组装延保信息
   * @param yanBaoList
   * @returns {string}
   */
function getYanBaoList(yanBaoList){
    var list = '';
    if(!yanBaoList || yanBaoList.length == 0) {
      return list;
    }
    for(var i = 0; i < yanBaoList.length; i++){
      var name = yanBaoList[i].name;
      var buyNum = yanBaoList[i].buyNum;
      var discountPrice = yanBaoList[i].discountPrice;
      list +='<div class="gift-item ftx-03">'
      +'<p>【延保】&nbsp;' + name + '&nbsp;￥' + discountPrice.toFixed(2) + '&nbsp;x&nbsp;' + buyNum + '</p>'
      +'</div>';
    }
    return list;
}window.getYanBaoList = getYanBaoList;
/**
* 展示提交错误提示<p>
* 延时清除提交错误信息
*/
function showSubmitErrorMessage(message) {
  $("#submit_message").html(message);
  $("#submit_message").show().css('top',($("#submit_message").height()+2)*-1);
  setTimeout(function(){
    $("#submit_message").hide();
  }, 8000);
}

/**
 * 
 * 加密数据为unicode
 * 
 */
function stringToHex(str){
  var val="";
  for(var i = 0; i < str.length; i++){
    val += "u" + str.charCodeAt(i).toString(16);
  }
  return val;
}


/**
 * 使用以旧换新逻辑
 * 
 * @return
 */
function useOldRepalceNew() {
  var isReplace = false;
  if ($("#oldReplaceNew:checked").size() > 0) {
    isReplace = true;
  } else {
    isReplace = false;
  }
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : OrderAppConfig.AsyncDomain + "/useOldReplaceNew.action",
    data : addFlowTypeParam("isReplace=" + isReplace),
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      $("#span-skulist").html(dataResult);
      var orderPrice = eval("(" + $("#orderPriceInSkuList").val() + ")");
      // 修改优惠券结算信息
      if (orderPrice.couponDiscount != null) {
        $("#couponPriceId").text("-￥" + orderPrice.couponDiscount.toFixed(2));
        if (orderPrice.couponDiscount == 0) {
          $("#showCouponPrice").css("display", "none");
          $("#couponPriceId").css("display", "none");
        } else {
          $("#showCouponPrice").css("display", "block");
          $("#couponPriceId").css("display", "block");
        }
      } else {
        $("#couponPriceId").css("display", "none");
      }

      // 修改礼品卡结算信息
      if (orderPrice.giftCardDiscount != null) {
        $("#giftCardPriceId").text("-￥" + orderPrice.giftCardDiscount.toFixed(2));
        if (orderPrice.giftCardDiscount == 0) {
          $("#showGiftCardPrice").css("display", "none");
        } else {
          $("#showGiftCardPrice").css("display", "block");
        }
      } else {
        $("#showGiftCardPrice").css("display", "none");
      }

      // 修改余额
      if (orderPrice.usedBalance != null) {
        $("#usedBalanceId").text("-￥" + orderPrice.usedBalance.toFixed(2));
        if (orderPrice.usedBalance == 0) {
          $("#showUsedOrderBalance").css("display", "none");
        } else {
          $("#showUsedOrderBalance").css("display", "block");
        }
      } else {
        $("#showUsedOrderBalance").css("display", "none");
      }

      // 修改应付余额
      if (orderPrice.payPrice != null) {
    	 modifyNeedPay(orderPrice.payPrice.toFixed(2))
      }
      // 商品总金额
      if (orderPrice.promotionPrice != null) {
        $("#warePriceId").text("￥" + orderPrice.promotionPrice.toFixed(2));
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}

/** *********************************************有货先发****************************************************** */

/**
 * 大家电换区
 * 
 * @return
 */
function bigItemChangeArea() {
  var actionUrl = OrderAppConfig.AsyncDomain + "/isBigItemChangeArea.action";
  var param = addFlowTypeParam();
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      if (dataResult.resultFlag) {
        if (dataResult.message) {
          alert(dataResult.message);
        } else {
          alert("请注意：根据您最新的收货地址，您购物车中的商品或价格发生了变化！");
        }
        bigItemGoOrder();
      } else {
        if (dataResult.message) {
          alert(dataResult.message);
        }
      }

    },
    error : function(XMLHttpResponse) {
    }
  });
}window.bigItemChangeArea=bigItemChangeArea;

/**
 * 糖酒换区
 * 
 * @return
 */
function tang9ChangeArea() {
  var actionUrl = OrderAppConfig.AsyncDomain + "/tang9ChangeArea.action";
  var param = addFlowTypeParam();
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      if (dataResult.resultFlag) {
        if (dataResult.message) {
          alert(dataResult.message);
        } else {
          alert("请注意：根据您最新的收货地址，您购物车中的商品或价格发生了变化！");
        }
        goOrder();
      } else {
        if (dataResult.message) {
          alert(dataResult.message);
        }
      }

    },
    error : function(XMLHttpResponse) {
    }
  });
}window.tang9ChangeArea=tang9ChangeArea;

/** *********************************************京豆****************************************************** */
/**
 * 京豆支付展开关闭
 */
function showOrHideJdBean() {
  if ($("#orderBeanItem").hasClass("toggle-active")) {
    $("#orderBeanItem").removeClass("toggle-active");
    $("#jdBeans-new").hide();
  } else {
    var actionUrl = OrderAppConfig.DynamicDomain + "/jdbean/getJdBean.action";
    var params = addFlowTypeParam();
    jQuery.ajax({
      type : "POST",
      dataType : "html",
      data : params,
      url : actionUrl,
      cache : false,
      success : function(result) {
        // 没有登录跳登录
        if (isUserNotLogin(result)) {
          goToLogin();
          return;
        }
        $("#orderBeanItem").addClass("toggle-active");
        $("#jdBeans-new").html(result);
        flushOrderPrice(eval("(" + $("#jdBeanOrderPrice").val() + ")"), true);
        $("#jdBeans-new").show();
        var param = "couponParam.fundsPwdType=JdBean";
        var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
        param = addFlowTypeParam(param);
        jQuery.ajax({
          type : "POST",
          dataType : "json",
          url : url,
          data : param,
          async : true,
          cache : false,
          success : function(flag) {
            if (!flag) {
              if ($("#usedJdBean").length > 0) {
                // 取消京豆
                useJdBean(0);
              }
              $("#jdBean-safe-tip").show();
            }
          }
        });
      },
      error : function(XMLHttpResponse) {
      }
    });
  }
}
window.showOrHideJdBean = showOrHideJdBean;
/**
 * 取消使用京豆，不展开京豆选项
 */
function cancelJdBeanWithoutOpen() {
  var actionUrl = OrderAppConfig.DynamicDomain + "/jdbean/useJdBean.action";
  var param = "jdBeanParam.usedJdBean=0";
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "html",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(result) {
      flushOrderPrice(eval("(" + $("#jdBeanOrderPrice").val() + ")"), true);
      isNeedPaymentPassword();// 是否需要支付密码
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.cancelJdBeanWithoutOpen=cancelJdBeanWithoutOpen;
/**
 * 使用京豆
 */
function useJdBean(jdbean) {
  var actionUrl = OrderAppConfig.DynamicDomain + "/jdbean/useJdBean.action";
  var param = "jdBeanParam.usedJdBean=" + jdbean;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "html",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(result) {
      // 没有登录跳登录
      if (isUserNotLogin(result)) {
        goToLogin();
        return;
      }
      $("#orderBeanItem").addClass("toggle-active");
      $("#jdBeans-new").html(result);
      $("#jdBeans-new").show();
      flushOrderPrice(eval("(" + $("#jdBeanOrderPrice").val() + ")"), true);
      isNeedPaymentPassword();// 是否需要支付密码
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.useJdBean=useJdBean;

/**
 * 京豆使用取消修改
 * 
 * @return
 */
function useCancelEditJdBean(jdbean, rate, cancel) {
  if (jdbean < 0 || (cancel && $("#showUsedJdBean:visible").length == 0)) {
    return;
  }
  // 取消使用京豆，不用校验支付密码开启状态
  if (cancel) {
    useJdBean(0);
  } else {// 使用京豆，先校验支付密码开启状态
    var param = "couponParam.fundsPwdType=JdBean";
    var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
    param = addFlowTypeParam(param);
    jQuery.ajax({
      type : "POST",
      dataType : "json",
      url : url,
      data : param,
      async : true,
      cache : false,
      success : function(flag) {
        if (isUserNotLogin(flag)) {
          goToLogin();
          return;
        }
        if (flag) {
//          $("#jdBean-safe-tip").hide();
          useJdBean(jdbean);
        } 
        else {
          showLargeMessage("支付密码未开启", "为保障您的账户资金安全，请先开启支付密码");
//          $("#jdBean-safe-tip").show();
          return;
        }
      }
    });
  }
}window.useCancelEditJdBean = useCancelEditJdBean;


/** ******************************免注册下单开始******************************** */
function sendMobileCode() {
  var mobile = $("#consignee_mobile").val();

  if (!checkMobilePhone()) {
    return;
  }

  $("#sendMobileCodeBtn").attr("disabled", "disabled");
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : OrderAppConfig.DynamicDomain + "/order/sendMobileCode.action",
    data : "consigneeWithoutRegistParam.mobile=" + mobile,
    cache : false,
    success : function(dataResult) {
      if (dataResult.success) {
        $("#call_div_error").hide();
        $("#call_div").removeClass("message");
        // 倒计时
        $("#sendMobileCodeBtn").attr("disabled", "disabled");
        $("#sendMobileCodeBtn").val("120秒后重新获取");
        setTimeout(countDown, 1000);

      } else {
        var errorMessage = dataResult.message;
        if (errorMessage != null && errorMessage.indexOf("已注册") > -1) {
          errorMessage = errorMessage + "，<a href='https://passport.jd.com/new/login.aspx?ReturnUrl=http%3A%2F%2Fcart.jd.com%2Fcart%2Fcart.html' >立即登录</a>";
        }
        $("#call_div_error").html(errorMessage);
        $("#call_div_error").show();
        $("#call_div").addClass("message");
        //$("#sendMobileCodeBtn").attr("disabled", "");
        $("#sendMobileCodeBtn").removeAttr("disabled");
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.sendMobileCode = sendMobileCode;

function checkMobilePhone() {
  var mobile = $("#consignee_mobile").val();
  var checkFlag = true;
  var reg = /^1[3|4|5|8]\d{9}/;
  var errorMessage = "";
  if (isEmpty(mobile)) {
    errorMessage = "请输入手机号";
    checkFlag = false;
  } else {
    if (mobile.match(reg) == null) {
      checkFlag = false;
      errorMessage = "手机号格式错误";
    }
  }
  if (!checkFlag) {
    $("#call_div_error").html(errorMessage);
    $("#call_div_error").show();
    $("#call_div").addClass("message");
  } else {
    $("#call_div_error").hide();
    $("#call_div").removeClass("message");
  }
  return checkFlag;
} window.checkMobilePhone=checkMobilePhone;

/**
 * 发送验证码倒计时
 * 
 * @return
 */
function countDown() {
  var text = $("#sendMobileCodeBtn").val();
  var secondTxt = text.substring(0, text.indexOf("秒"));
  var second = parseInt(secondTxt);
  if (second <= 0) {
    //$("#sendMobileCodeBtn").attr("disabled", "");
    $("#sendMobileCodeBtn").removeAttr("disabled");
    $("#sendMobileCodeBtn").val("获取验证码");
  } else {
    second--;
    $("#sendMobileCodeBtn").val(second + "秒后重新获取");
    setTimeout(countDown, 1000);
  }
}

function checkMobileCode() {
  var code = $("#mobileCode").val();
  if (isEmpty(code)) {
    $("#mobileCode_div_error").html("验证失败，请核对手机号和验证码，必要时重新获取");
    $("#mobileCode_div").addClass("message");
    return;
  }
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : OrderAppConfig.DynamicDomain + "/order/checkMobileCode.action",
    data : "consigneeWithoutRegistParam.code=" + code,
    cache : false,
    success : function(dataResult) {
      if (dataResult) {
        $("#mobileCode_div_success").show();
        $("#mobileCode_div_error").hide();
        $("#mobileCode_div").removeClass("message");
      } else {
        $("#mobileCode_div_success").hide();
        $("#mobileCode_div_error").html("验证失败，请核对手机号和验证码，必要时重新获取");
        $("#mobileCode_div_error").show();
        $("#mobileCode_div").addClass("message");
        return;
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.checkMobileCode = checkMobileCode;
function save_ConsigneeWithoutRegister() {
  // 普通地址
  var consignee_id = 0;
  var consignee_type = 1;
  var consignee_provinceId = null;
  var consignee_cityId = null;
  var consignee_countyId = null;
  var consignee_townId = null;
  var consignee_name = null;
  var consignee_email = "";
  var consignee_address = null;
  var consignee_mobile = null;
  var consignee_phone = "";
  var consignee_provinceName = null;
  var consignee_cityName = null;
  var consignee_countyName = null;
  var consignee_townName = null;
  var isUpdateCommonAddress = 0;
  var mobileCode = "";

  consignee_provinceId = $("#consignee_province").find("option:selected").val();
  consignee_cityId = $("#consignee_city").find("option:selected").val();
  consignee_countyId = $("#consignee_county").find("option:selected").val();
  consignee_townId = $("#consignee_town").find("option:selected").val();
  consignee_provinceName = $("#consignee_province").find("option:selected").text().replace("*", "");
  consignee_cityName = $("#consignee_city").find("option:selected").text().replace("*", "");
  consignee_countyName = $("#consignee_county").find("option:selected").text().replace("*", "");
  if (!$("#span_town").is(":hidden")) {
    consignee_townName = $("#consignee_town").find("option:selected").text().replace("*", "");
  }

  consignee_name = $("#consignee_name").val();
  consignee_address = $("#consignee_address").val();
  consignee_mobile = $("#consignee_mobile").val();
  mobileCode = $("#mobileCode").val();
  var checkConsignee = true;
  // 验证收货人信息是否正确
  if (!check_Consignee("name_div")) {
    checkConsignee = false;
  }
  // 验证地区是否正确
  if (!check_Consignee("area_div")) {
    checkConsignee = false;
  }
  // 验证收货人地址是否正确
  if (!check_Consignee("address_div")) {
    checkConsignee = false;
  }
  // 验证手机号码是否正确
  if (!checkMobilePhone()) {
    checkConsignee = false;
  }
  if (isEmpty(mobileCode)) {
    $("#mobileCode_div_success").hide();
    $("#mobileCode_div_error").html("验证失败，请核对手机号和验证码，必要时重新获取");
    $("#mobileCode_div_error").show();
    $("#mobileCode_div").addClass("message");
    checkConsignee = false;
  }
  if (!checkConsignee) {
    return;
  }

  var param = "consigneeWithoutRegistParam.id=" + consignee_id + "&consigneeWithoutRegistParam.type=" + consignee_type + "&consigneeWithoutRegistParam.name="
      + consignee_name + "&consigneeWithoutRegistParam.provinceId=" + consignee_provinceId + "&consigneeWithoutRegistParam.cityId=" + consignee_cityId
      + "&consigneeWithoutRegistParam.countyId=" + consignee_countyId + "&consigneeWithoutRegistParam.townId=" + consignee_townId
      + "&consigneeWithoutRegistParam.address=" + consignee_address + "&consigneeWithoutRegistParam.mobile=" + consignee_mobile
      + "&consigneeWithoutRegistParam.email=" + consignee_email + "&consigneeWithoutRegistParam.phone=" + consignee_phone
      + "&consigneeWithoutRegistParam.provinceName=" + consignee_provinceName + "&consigneeWithoutRegistParam.cityName=" + consignee_cityName
      + "&consigneeWithoutRegistParam.countyName=" + consignee_countyName + "&consigneeWithoutRegistParam.townName=" + consignee_townName
      + "&consigneeWithoutRegistParam.isUpdateCommonAddress=" + isUpdateCommonAddress + "&consigneeWithoutRegistParam.code=" + mobileCode;

  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : OrderAppConfig.DynamicDomain + "/order/saveConsigneeWithoutRegist.action",
    data : param,
    cache : false,
    success : function(dataResult) {
      if (dataResult == null) {
        $("#mobileCode_div_success").hide();
        $("#mobileCode_div_error").html("验证失败，请核对手机号和验证码，必要时重新获取");
        $("#mobileCode_div_error").show();
        $("#mobileCode_div").addClass("message");
        return;
      }

      if (dataResult.success) {
        goOrder();
      } else {
        var errorMessage = dataResult.message;
        if (errorMessage.indexOf("已注册") > -1) {
          errorMessage = errorMessage + "，<a href='https://passport.jd.com/new/login.aspx?ReturnUrl=http%3A%2F%2Fcart.jd.com%2Fcart%2Fcart.html'>立即登录</a>";
          $("#call_div_error").html(errorMessage);
          $("#call_div_error").show();
          $("#call_div").addClass("message");
          //$("#sendMobileCodeBtn").attr("disabled", "");
          $("#sendMobileCodeBtn").removeAttr("disabled");
          return;
        }
        if (errorMessage.indexOf("验证失败") > -1) {
          $("#mobileCode_div_success").hide();
          $("#mobileCode_div_error").html("验证失败，请核对手机号和验证码，必要时重新获取");
          $("#mobileCode_div_error").show();
          $("#mobileCode_div").addClass("message");
          return;
        }
        //alert("系统繁忙，请稍后再试！");
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
} window.save_ConsigneeWithoutRegister = save_ConsigneeWithoutRegister;

function getSkuListWithUuid() {
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : OrderAppConfig.DynamicDomain + "/order/getSkuList.action",
    data : "",
    cache : false,
    success : function(dataResult) {
      $("#span-skulist").html(dataResult);
      modifyNeedPay($("#totalFee").val());
    },
    error : function(XMLHttpResponse) {
    }
  });
}

/** ******************************免注册下单结束******************************** */

/**
 * 是否是实体礼品卡流程
 */
function isLipinkaPhysical() {
  var lpkVal = $("#flowType").val();
  if (lpkVal == "4") {
    return true;
  } else {
    return false;
  }
}

/**
 * 是否是礼品购流程
 */
function isGiftBuy() {
  var giftBuyVal = $("#flowType").val();
  if (giftBuyVal == "2") {
    return true;
  } else {
    return false;
  }
}window.isGiftBuy=isGiftBuy;
/**
 * 是否是礼品购流程
 */
function isLocBuy() {
  var locBuyVal = $("#flowType").val();
  if (locBuyVal == "1") {
    return true;
  } else {
    return false;
  }
}

/**
 * 加载礼品购的“是否隐藏价格”的checkBox,同时改变返回购物车的连接
 */
function loadGiftBuyHidePrice() {
  if (isGiftBuy()) {
    //cartUrl = "http://cart.gift.jd.com/cart/cart.html";
    $("#cartRetureUrl").attr("href", "http://cart.gift.jd.com/cart/cart.html");
    $("#cartRetureUrl").text("返回修改礼品购购物车");
    $("#giftBuyHidePriceDiv").show();
    $("#consigneeTitleDiv").text("收礼人信息");
  } else {
    //cartUrl = "http://cart.jd.com/cart/cart.html";
    $("#cartRetureUrl").attr("href", cartUrl);
    $("#cartRetureUrl").text("返回修改购物车");
    $("#giftBuyHidePriceDiv").hide();
    $("#consigneeTitleDiv").text("收货人信息");
  }
} window.loadGiftBuyHidePrice = loadGiftBuyHidePrice;

function addFlowTypeParam(params) {
  var flowType = $("#flowType").val();
  if (isEmpty(flowType)) {
    return params;
  } else {
    if (isEmpty(params)) {
      return "flowType=" + flowType;
    } else {
      return params + "&flowType=" + flowType;
    }
  }
}window.addFlowTypeParam=addFlowTypeParam;

// ------------------------------------------------------------页面出来后异步加载-----------------------------------------------------------
//获取优惠券信息
if($("#isNewVertual").val() == "true"){
  resetCoupontab();
  query_coupons_vertual();
}
try{
	if($("#isPresale").val() == "false"){
		if($(".payment-item[onlinepaytype=2]").length>0){
			log('ord', 'trade', '30',1);
		}else{
			log('ord', 'trade', '30',2);
		}
	}
}catch(e){
}
// 预售结算页 有message提示
if ($("#isPresale").val() == "true") {
  $("#order-submit").prop("class", "checkout-submit-disabled");
  if ($("#presaleStepPay").val() == "1") {
      $("#order-submit").prop("class", "checkout-submit btn-1");
  }
  $("#presaleEarnest").bind("click", function() {
    if ($("#presaleEarnest").prop("checked") == true) {
      $("#order-submit").prop("class", "checkout-submit btn-1");
    } else {
      $("#order-submit").prop("class", "checkout-submit-disabled");
    }
  });
}

$("#payment-list .payment-item").not(".payment-item-disabled").each(function() {
  $(this).bind("click", function() {
    if($("#paymentViewHideId").html()==null){
      $(".payment-item").removeClass("item-selected");
      $(this).addClass("item-selected");
    }
  });
});

subStrConsignee();

var isUnregister = $("#isUnregister").val();
// 如果不是免注册下单，调用异步服务
if (isUnregister || isUnregister == "true") {
  loadProvinces();
  getSkuListWithUuid();
} else {
  // 大家电换区
  if (isBigItemChange()) {
    bigItemChangeArea();
  }
  // 糖酒
  if (hasTang9()) {
    tang9ChangeArea();
  }
  //isNewUser(); // 新用户展开地址
  loadOrderExt();
  //loadSkuListStock();
 if (!isLocBuy() && !checkIsNewUser()) {
     openConsignee();
     }
  // }// 异步不必加载收货人地址，无论新老用户
  if (!isLocBuy()) {
	insertEquipInfo();
    $('#reset_promise_311').val("0");
    copyFreightHtml();
    showOrHideFactoryShipCod();
    //showTangJiuSkuIcon();去除糖酒图标
    //异步调用,获取311、411、自提点等信息
    setResetFlag(0, '1');
    doAsynGetSkuPayAndShipInfo();
    freshTips();
    freshUI();
    //doGetVendorName();
    // 加载验证码
    showCheckCode();
  }else{
    freshTips();
  }
//  // 如果是礼品购流程，加载隐藏价格
//  if (isGiftBuy()) {
//    loadGiftBuyHidePrice();
//  }

  $('#consignee-addr')
    .delegate('li','mouseenter',function(){
      $(this).addClass('li-hover');
    })
    .delegate('li','mouseleave',function(){
      $(this).removeClass('li-hover');
    });
  //如果是国际站，需要调用广告接口获取cookie jda、jdv
  if($("#flowType").val() == "10"){
    getOverseaPurchaseCookies();
  }
}

/**
 * 修改选中样式
 */
(function(win) {
  var RadioChecked = function(o) {
    this.obj = o.obj;
    this.init();
  };
  RadioChecked.prototype = {
    init : function() {
      this.bindEvent();
    },
    bindEvent : function() {
      var self = this;
      self.obj.find('.hookbox').bind('click', function() {
        self.obj.find('.item-selected').removeClass('item-selected');
        $(this).parents('.item').addClass('item-selected');
      });
    }
  };
  win.radioSelect = function(o) {
    new RadioChecked(o);
  };
}(window));

(function(win) {
  var PaymentBank = function(obj, fun) {
    this.obj = obj;
    this.fn = fun || function() {
    };
    this.init();
  };
  PaymentBank.prototype = {
    init : function() {
      this.bindEvent();
    },
    bindEvent : function() {
      var self = this, liNodes = self.obj.find('li');
      liNodes.bind('click', function() {
        liNodes.removeClass('selected');
        $(this).addClass('selected');
        self.fn($(this));
      });
    }
  };
  win.paymentBank = function(o, fn) {
    new PaymentBank(o, fn);
  };
}(this));

function changeCodDate(codDateOffset, isJdOrOther) {
  var bigItemInstallInfo = "";
  if (isJdOrOther || isJdOrOther == "true") {
    bigItemInstallInfo = $("#bigItemInstallDateInfoForJd").val();
  } else {
    bigItemInstallInfo = $("#bigItemInstallDateInfoForOtherShip").val();
  }
  if (!isEmpty(bigItemInstallInfo)) {
    var installDateMap = eval('(' + bigItemInstallInfo + ')');
    var installDateMapHtml = "<option value=\"-1\">请选择日期</option>";
    for ( var key in installDateMap) {
      if (key == codDateOffset) {
        var dateListStr = installDateMap[key] + "";
        var dateList = dateListStr.split(',');
        for (var i = 0; i < dateList.length; i++) {
          if (i == 0) {
            installDateMapHtml += "<option selected value='" + dateList[i].split('-')[1] + "'>" + dateList[i].split('-')[0] + "</option>";
          } else {
            installDateMapHtml += "<option value='" + dateList[i].split('-')[1] + "'>" + dateList[i].split('-')[0] + "</option>";
          }
        }
        break;
      }
    }
    installDateMapHtml += "<option value=\"-2\">暂缓安装</option>";
    if (isJdOrOther || isJdOrOther == "true") {
      $('#jd-bigItem-install-date').html(installDateMapHtml);
    } else {
      $('#other-bigItem-install-date').html(installDateMapHtml);
    }
    return;
  }

  if ($('#jd-bigItem-install-date').length > 0) {
    var actionUrl = OrderAppConfig.DynamicDomain + "/payAndShip/getInstallDateList.action";
    if (codDateOffset == -1) {
      $('#jd-bigItem-install-date').html('<option value="-1">请选择日期</option>');
    } else {
      var param = "selectedCodDateOffSet=" + codDateOffset;
      param = addFlowTypeParam(param);
      jQuery.ajax({
        type : "POST",
        url : actionUrl,
        data : param,
        cache : false,
        success : function(dataResult, textStatus) {
          $('#jd-bigItem-install-date').html(dataResult);
        },
        error : function(XMLHttpResponse) {
        }
      });
    }
  }
}
/**
 * 将payAndShip中的运费弹窗复制到orderInfo中，因为取数据是在payAndShip中，而弹窗必须放到orderInfo最下面，否则会串行
 * 
 * @return
 */

function copyFreightHtml() {
  var freightHtml = $("#payment-ship").find("#transportInPay").html();
  if (freightHtml != "") {
    $("#transport").html(freightHtml);
  }
}

function showOrHideFactoryShipCod() {
  if ($("#factoryShipCod").val() == "true") {
    $('#factoryShipCodShowDivBottom').css("display", "block");
  }
}

function showFerightInsure() {
  var popVenderIdStr = $("#popVenderIdStr").val();
  if (popVenderIdStr == "") {
    return;
  }
  var param = "popVenderIdStr=" + popVenderIdStr;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    url : OrderAppConfig.AsyncDomain + "/showFerightInsure.action",
    data : param,
    cache : false,
    dataType : "json",
    success : function(dataResult) {
      if (dataResult.venderNameList && dataResult.venderNameList.length > 0) {
        for (var i = 0; i < dataResult.venderNameList.length; i++) {
          var tempVenderName = dataResult.venderNameList[i];
          var arrVenderName = tempVenderName.split(":");
          $(".yfx_div_remark").each(function() {
            if ($(this).attr("id") == arrVenderName[0]) {
              if (arrVenderName[1] != null && arrVenderName[1] != "undefined") {
                var showVenderName = arrVenderName[1];
                if (arrVenderName[1].length > 16)
                  showVenderName = arrVenderName[1].substring(0, 15) + "...";
                $(this).html(arrVenderName[1] + "为您购买了运费险，最高赔付20.00元/单");
                $(this).parent().parent().show();
              }
            }
          });
        }
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.showFerightInsure=showFerightInsure;

function showFreight() {
  var obj = $("#freightSpan");
  if ($("#transport").html() != null) {
    $("#transport").css({
      position : "absolute",
      top : (obj.offset().top) + "px",
      left : (obj.offset().left - 345) + "px",
      display : "block"
    });
  }
}

function checkShowOpenPwd(showOpenPayPwd, existsJdbeanPromotion, checkJdbeanPromotion) {
  if (existsJdbeanPromotion == true) {
    if (showOpenPayPwd == false) {
      $("#paypasswordPanel").show();
      if (checkJdbeanPromotion == false) {
        $("#submit_message").html("<span>京豆不足,不能使用京豆优惠购,点击<a href='//cart.jd.com/cart/cart.html?outBean=1'>返回购物车 </a></span> ").show();
      }
    } else {
      $("#submit_message").html(
          "<span>为保障您的账户资金安全，京豆暂时不可用，请先<a href='http://safe.jd.com/user/paymentpassword/safetyCenter.action' target='_blank'>开启支付密码 </a></span> ").show();
    }
  }
}

function operate_presaleMobile(thisObj) {
  if ($("#presaleMobile input").size() > 0) {// 点击保存
    var mobile = $("#presaleMobile input").val();
    if (testMobile(mobile) && mobile.indexOf("*") < 0 ) {
      $("#presaleMobile").html("<strong class=\"phone-num\" id=\"userMobileByPresale\" >" + mobile + "</strong></span>");
      $("#hiddenUserMobileByPresale").val(mobile);
      $(thisObj).html("修改");
      $("#cancelOperatePresaleMob").hide();
    } else {
      var html = "<input type=\"text\" class=\"itxt error-itxt\" maxlength=\"11\"><span class=\"error-msg\" style=\"color:red\">请输入正确的手机号</span></span>";
      $("#presaleMobile").html(html);
    }
  } else {// 点击修改
    $("#presaleMobile").html("<input type=\"text\"  class=\"itxt focus-itxt\" maxlength=\"11\"/>");
    $("#presaleMobile input").focus();
    $(thisObj).html("保存");
    if ($("#cancelOperatePresaleMob").size() > 0) {
      $("#cancelOperatePresaleMob").show();
    } else {
      var copm = $("<a href=\"#none\" class=\"a-link\" id=\"cancelOperatePresaleMob\">取消</a>");
      copm.bind("click", function() {
        $("#presaleMobile").html("<strong id=\"userMobileByPresale\" class=\"phone-num\">" + $("#hiddenUserMobileByPresale").val() + "</strong></span>");
        $("#cancelOperatePresaleMob").hide();
        $("#operatePresaleMobile").html("修改");
      });
      $(thisObj).after(copm).after("&nbsp;");
    }
  }
}
window.operate_presaleMobile = operate_presaleMobile;

function check_presaleMobile() {
  var mobile = "";
  if ($("#presaleMobile input").size() > 0) {
    mobile = $("#presaleMobile input").val();
  } else {
    mobile = $("#userMobileByPresale").html();
  }
  if (testMobile(mobile)) {
    return true;
  } else {
    return false;
  }
}

// 结算页手机号标准
function testMobile(mobile) {
  return check_mobile_new(mobile);
}

/**
 * 预售支付方式选择器
 * 
 * @param id
 */
function choosePresaleType(thisObj) {
  if ($(thisObj).prop("id") == "EarnestPayRadio") {
    $("#presaleEarnOnlyList").show();
    $("#presaleEarnOnlyInfo").show();
    $("#presaleAllPayList").hide();
    if ($("#presaleStepPay").val() == "4"){
      $("#step4Info").hide();
    }
    $(".presale-con .pay-chk").css("display", "block");
  } else {
    $("#presaleEarnOnlyList").hide();
    $("#presaleEarnOnlyInfo").hide();
    $("#presaleAllPayList").show();
    if ($("#presaleStepPay").val() == "4"){
      $("#step4Info").show();
    }
    //去掉同意支付定金checkbox
    $(".presale-con .pay-chk").css("display", "none");
    $("#presaleEarnest").attr("checked", true);
  }
  if ($("#presaleEarnest").prop("checked") == true) {
      $("#order-submit").prop("class", "checkout-submit btn-1");
  } else {
      $("#order-submit").prop("class", "checkout-submit-disabled");
  }
}window.choosePresaleType = choosePresaleType;
/**
 * 预售支付方式选择器
 * 
 * @param id
 */
function choosePresaleType2(thisObj) {
  if ($(thisObj).prop("id") == "EarnestPayRadio") {
    $("#presaleEarnOnlyList").show();
    $("#presaleEarnOnlyInfo").show();
    $("#presaleAllPayList").hide();
    $("#EarnestPayRadio").attr("class","presale-payment-item  item-selected");
    $("#AllPayRadio").attr("class","presale-payment-item");
    if ($("#presaleStepPay").val() == "4"){
      $("#step4Info").hide();
    }
    $(".presale-con .pay-chk").css("display", "inline");
    $("#presaleEarnest").attr("checked", false);
    $("#chooseAllPay").css("display", "none");
    $("#chooseEarnestPay").removeAttr("style");
    $("#chooseEarnestPay1").removeAttr("style");
    $("#pre-weikuan").removeAttr("style");
//    $("#chooseEarnestPay").css("display", "inline");   
  } else {
    $("#presaleEarnOnlyList").hide();
    $("#presaleEarnOnlyInfo").hide();
    $("#presaleAllPayList").show();
    $("#EarnestPayRadio").attr("class","presale-payment-item");
    $("#AllPayRadio").attr("class","presale-payment-item item-selected");
    if ($("#presaleStepPay").val() == "4"){
      $("#step4Info").show();
    }
    $("#chooseEarnestPay").css("display", "none");
    $("#chooseEarnestPay1").css("display", "none");
    $("#pre-weikuan").css("display", "none");
    $("#chooseAllPay").css("display", "inline");
    //去掉同意支付定金checkbox
    $(".presale-con .pay-chk").css("display", "none");
    $("#presaleEarnest").attr("checked", true);
  }
  if ($("#presaleEarnest").prop("checked") == true) {
      $("#order-submit").prop("class", "checkout-submit btn-1");
  } else {
      $("#order-submit").prop("class", "checkout-submit-disabled");
  }
}window.choosePresaleType2 = choosePresaleType2;
/**
 * 异步请求获取唐久商品icon
 */
function showTangJiuSkuIcon() {
  var skuIdAndNums = $("#mainSkuIdAndNums").val();
  var areaIds = $("#hideAreaIds").val();
  if (isEmpty(skuIdAndNums) || isEmpty(areaIds)) {
    return;
  }
  var param = "areaIds=" + areaIds + "&skuIdAndNums=" + skuIdAndNums;
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    url : OrderAppConfig.AsyncDomain + "/showTangJiuSkuIcon.action",
    data : param,
    cache : false,
    dataType : "json",
    success : function(dataResult) {
      var skuicons = eval(dataResult);
      if (!skuicons || skuicons == 'false') {
        return;
      }
      for (var i = 0; i < skuicons.length; i++) {
        var arrIcons = skuicons[i].icons;
        if (arrIcons != null && arrIcons.length > 0) {
          for (var j = 0; j < arrIcons.length; j++) {
            if (arrIcons[j] == 1 || arrIcons[j] == "1") {
              if ($("#speedFreightNote").length > 0 && $("#speedFreightNote").html().length > 0) {
                $("#promise_" + skuicons[i].skuId).append("<a class='promisejsd' title='下单后或支付成功后2小时送达' href='javascript:void(0);'></a>");
              }
            } else if (arrIcons[j] == 2 || arrIcons[j] == "2") {
              $("#promise_" + skuicons[i].skuId).append("<a class='promisexsd' title='9:00-18:00下单，一小时内送达' href='javascript:void(0);'></a>");

            }

          }
        }
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.showTangJiuSkuIcon = showTangJiuSkuIcon;

/**
 * 使用兑换码兑换优惠券 Author:曹森 DateTime:2014/04/23 16:00
 * 
 * @param
 */
function exchangeCoupons(obj) {
  if ($('#couponKeyPressFirst').val() == "" || $('#couponKeyPressSecond').val() == "" || $('#couponKeyPressThrid').val() == ""
      || $('#couponKeyPressFourth').val() == "") {
    showMessageWarn("请输入优惠券兑换码！");
    return;
  }

  var param = "couponParam.fundsPwdType=Coupon";
  var url = OrderAppConfig.DynamicDomain + "/coupon/checkFundsPwdResult.action";
  param = addFlowTypeParam(param);
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : url,
    data : param,
    async : true,
    cache : false,
    success : function(flag) {
      if (isUserNotLogin(flag)) {
        goToLogin();
        return;
      }
      if (flag) {
        var key = $("#couponKeyPressFirst").val() + $("#couponKeyPressSecond").val() + $("#couponKeyPressThrid").val() + $("#couponKeyPressFourth").val();
        $("input[id^='couponKeyPress']").each(function() {
          $(this).val("");
        });
        var param = "couponParam.couponKey=" + key;
        param = addFlowTypeParam(param);
        jQuery.ajax({
          type : "POST",
          dataType : "json",
          url : OrderAppConfig.AsyncDomain + "/coupon/exchangeCoupons.action",
          data : param,
          async : true,
          cache : false,
          success : function(result) {
            if (isUserNotLogin(result)) {
              goToLogin();
              return;
            }
            if (!result.resultFlag) {
              var message = result.message;
              showMessageError(message);
              if (obj.checked) {
                obj.checked = false;
              }
              return;
            }

            changeClassStyle(orderCouponId, toggleWrap);
            changeClassStyle(orderCouponItem, itemToggleActive);
            showMessageSucc(result.message);
            $("#" + orderCouponId).css('display', 'none');
            query_coupons();
            showEntityPanel();
          }
        });
      } else {
        showLargeMessage("支付密码未开启", "为保障您的账户资金安全，请先开启支付密码");
        return;
      }
    }
  });


  
}
window.exchangeCoupons = exchangeCoupons;

function shipmentToggle(th) {
  if ($(th).attr("id") == "jd-shipment") {// 选择京东配送
    $(th).parent().parent().addClass("item-selected");
    $("#pick-shipment").parent().parent().removeClass("item-selected");

    $("#jd-shipment-way-category").addClass("way-category-selected");
    $("#pick-shipment-way-category").removeClass("way-category-selected");

    $("#jd-show-sku-count").show();
    $("#jd-shipment-extend-info").show();

    if (!isEmpty($("#pick-shipment").val())) {
      $("#pick-shipment").attr("checked", false);
      $("#pick-show-sku-count").hide();
      $("#pick-shipment-extend-info").hide();
      $("#subway-sment").hide();
    }

  } else if ($(th).attr("id") == "pick-shipment") {// 选择自提
    $(th).parent().parent().addClass("item-selected");
    $("#pick-shipment-way-category").addClass("way-category-selected");

    if (!isEmpty($("#jd-shipment").val())) {
      $("#jd-shipment").parent().parent().removeClass("item-selected");
      $("#jd-shipment").attr("checked", false);
    }

    if (!isEmpty($("#other-shipment").val())) {
      $("#other-shipment").parent().parent().removeClass("item-selected");
      $("#other-shipment").attr("checked", false);
    }

    if (!isEmpty($("#jd-shipment-way-category").html())) {
      $("#jd-shipment-way-category").removeClass("way-category-selected");
    }

    if (!isEmpty($("#other-shipment-way-category").html())) {
      $("#other-shipment-way-category").removeClass("way-category-selected");
    }

    $("#pick-show-sku-count").show();
    $("#pick-shipment-extend-info").show();
    $("#subway-sment").show();
    if (!isEmpty($("#jd-shipment-extend-info").html()))
      $("#jd-shipment-extend-info").hide();
    if (!isEmpty($("#other-shipment-extend-info").html()))
      $("#other-shipment-extend-info").hide();

    if (!isEmpty($("#jd-show-sku-count").html()))
      $("#jd-show-sku-count").hide();
    if (!isEmpty($("#other-show-sku-count").html()))
      $("#other-show-sku-count").hide();

  } else if ($(th).attr("id") == "other-shipment") {// 选择京东三方配送
    $(th).parent().parent().addClass("item-selected");
    $("#pick-shipment").parent().parent().removeClass("item-selected");

    $("#other-shipment-way-category").addClass("way-category-selected");
    $("#pick-shipment-way-category").removeClass("way-category-selected");

    $("#other-shipment-extend-info").show();
    $("#other-show-sku-count").show();

    if (!isEmpty($("#pick-shipment").val())) {
      $("#pick-shipment").attr("checked", false);
      $("#pick-show-sku-count").hide();
      $("#pick-shipment-extend-info").hide();
      $("#subway-sment").hide();
    }

  }
}


/**
 * 获取商家名称
 */
function doGetVendorName(){
	
  var flowType = $("#flowType").val();
  
  if(flowType == "1" || flowType == "13"){
    return;
  }
  
  //因为异步获取的是pop商家名称，先把京东的赋值
  $(".vendor_name_yanbao").each(function() {
	  if($(this).attr("name") == 0 || $(this).attr("name") == "0"){
		  $(this).html("【京东自营】"); 
	  }
    });
  
  //end
  var actionUrl = OrderAppConfig.AsyncDomain +"/showFerightSopName.action";
  var param = "popVenderIdStr=" + $("#popVenderIdStr").val();
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      for ( var key in dataResult.sopNameMap) {
        $(".vendor_name_h").each(function() {
          //modify by yanwenqi  全球购自营的显示：京东全球购自营
          if ($(this).attr("id") == key) {
            if(key == 0){
              $(this).html("商家：京东全球购自营");
            }else{
              if (dataResult.sopNameMap[key] != null && dataResult.sopNameMap[key] != "undefined") {
                if (dataResult.sopNameMap[key].length > 16)
                  dataResult.sopNameMap[key] = dataResult.sopNameMap[key].substring(0, 15) + "";
                $(this).html("商家：" + dataResult.sopNameMap[key]);
              }
            }
          }
        });
      $(".vendor_name_freight").each(function() {
          if ($(this).attr("id") == key) {
            if (dataResult.sopNameMap[key] != null && dataResult.sopNameMap[key] != "undefined") {
              if (dataResult.sopNameMap[key].length > 16)
                dataResult.sopNameMap[key] = dataResult.sopNameMap[key].substring(0, 15) + "...";
                var sopName = $(this).html(); 
                if(sopName.indexOf("、") != -1)
                  $(this).html("、"+dataResult.sopNameMap[key]);
                else
                  $(this).html(dataResult.sopNameMap[key]);
            }
          }
        });
      
      $(".vendor_name_yanbao").each(function() {
    	 
    	  if($(this).attr("name") == 0 || $(this).attr("name") == "0"){
    		  $(this).html("【京东自营】"); 
    	  }else{
	          if ($(this).attr("name") == key) {
	              if (dataResult.sopNameMap[key] != null && dataResult.sopNameMap[key] != "undefined") {
	                if (dataResult.sopNameMap[key].length > 8){
	                  dataResult.sopNameMap[key] = dataResult.sopNameMap[key].substring(0, 7) + "...";
	                }
	                    $(this).html("【"+dataResult.sopNameMap[key]+"】");
	              }
	            }
    	  }
        });
      
        /*$(".yfx_div_remark").each(function() {
          if ($(this).attr("id") == key) {
            if (dataResult.sopNameMap[key] != null && dataResult.sopNameMap[key] != "undefined") {
              if (dataResult.sopNameMap[key].length > 16)
                dataResult.sopNameMap[key] = dataResult.sopNameMap[key].substring(0, 15) + "...";
              $(this).html(dataResult.sopNameMap[key] + "为您购买了运费险，最高赔付20.00元/单");
            }
          }
        });*/
      }
    },
    error : function(XMLHttpResponse) {
      //alert("系统繁忙，请稍后再试！");
    }
  });
}window.doGetVendorName=doGetVendorName;

function showPickDateList(){
  var isInvokePickDate = $("#is_invoke_pickdate").val();
  var pickId = $("#pick_sel_id").val();
  if(isInvokePickDate=="0"){
    return;
  }
  
  var param = "pickid="+pickId;
    param = addFlowTypeParam(param);
  // $(obj).parent().parent().css("class","item item-selected");
  //$(obj).parent().parent().addClass('item-selected').siblings().removeClass('item-selected');
  jQuery.ajax({
    type : "POST",
    dataType : "text",
    url : OrderAppConfig.AsyncDomain + "/payAndShip/getPickSiteDate.action",
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      var jsonO = eval("("+dataResult+")");  
      var pickDateHTML = "";
      for(var i=0;i<jsonO.length;i++){ 
        pickDateHTML = pickDateHTML+"<ul><li class='li_pick_shipment' date='"+jsonO[i].pickDate+"' picksite_date='"+jsonO[i].codDate+"' picksite_weekDay='"+jsonO[i].name+"' onclick='doSwithPickShipDate('',this)'>";
        pickDateHTML = pickDateHTML+  jsonO[i].codDate;
        pickDateHTML = pickDateHTML+  "<span class='data'>"+jsonO[i].name+"</span>";
        pickDateHTML = pickDateHTML+"</li></ul>";
      } 
      $("#pickSiteShipDate .date-box.date-list").html(pickDateHTML);
      $("#is_invoke_pickdate").val("0");
    },
    error : function(XMLHttpResponse) {
      //alert("系统繁忙，请稍后再试！");
      return false;
    }
  });
}window.showPickDateList=showPickDateList;

function showMessageSucc(c){
  showMessage(c,'succ');
}window.showMessageSucc=showMessageSucc;
function showMessageWarn(c){
  showMessage(c,'warn');
}window.showMessageWarn=showMessageWarn;
function showMessageError(c){
  showMessage(c,'error');
}window.showMessageError=showMessageError;

function showMessage(c,i){
  var showMessage = "<div class='tip-box icon-box'><span class="+i;
  showMessage = showMessage+"-icon m-icon'></span>";
  showMessage = showMessage+"<div class='item-fore'><h3 class='ftx-02'>"+c;
  showMessage = showMessage+"</h3></div><div class='op-btns ac'><a href='javascript:$.closeDialog();' class='btn-9'>确定</a></div></div>";
  $('body').dialog({
    title:'提示',
    width:320,
    height:120,
    type:'html',
    autoIframe:false,
    source:showMessage
  });
}window.showMessage=showMessage;

function showLargeMessage(title, largeMessage) {
  var showMessage = '<div class="tip-box icon-box"><span class="warn-icon m-icon"></span><div class="item-fore">'
      showMessage += '<h3>'+title+'</h3>'
      showMessage += '<div>'+largeMessage+'</div>'
      showMessage += '</div><div class="op-btns ac"><a href="javascript:$.closeDialog();" class="btn-9">关闭</a></div></div>';
  $('body').dialog({
    title:'提示',
    width:380,
    height:100,
    type:'html',
    autoIframe:false,
    source: showMessage
  });
}window.showLargeMessage = showLargeMessage;

function freshTips() {
  //页面tips展示
  var $el = $("#shipAndSkuInfo");
  $el.tips({
    trigger: '.qmark-tip',
    tipsClass: 'qmarkTip',
    mouseenterDelayTime: 300,
    autoResize:false,
    hasClose: false
  });
  // 京东大件商品tips
  $el.tips({
    trigger: '#jd-big-goods-item',
    width: 260,
    type: 'click',
    // source: $('#jdbigItem_surpportSku').html()
    sourceTrigger: '#jdbigItem_surpportSku'
  });
  
  // 京东非大件商品tips
  $el.tips({
    trigger: '#jd-goods-item',
    width: 260,
    type: 'click',
    // source: $('#jdbigItem_surpportSku').html()
    sourceTrigger: '#jdItem_surpportSku'
  });

  //显示京东第三方大家电列表
  $el.tips({
    trigger: '#jd-other-big-goods-item',
    width: 260,
    type: 'click',
    // source: $('#jdOtherbigItem_surpportSku').html()
    sourceTrigger: '#jdOtherbigItem_surpportSku'
  });

  //显示京东第三方中小件列表
  $el.tips({
    trigger: '#jd-other-goods-item',
    width: 260,
    type: 'click',
    // source: $('#jdOther_surpportSku').html()
    sourceTrigger: '#jdOther_surpportSku'
  });
  $el.tips({
    trigger: '#mainPaymentView-1',
    width: 260,
    type: 'click',
    // source:$('#mainPaymentViewHide').html()
    sourceTrigger: '#mainPaymentViewHide'
  });

  $el.tips({
    trigger: '#subPaymentView-1',
    width: 260,
    type: 'click',
    // source:$('#subPaymentViewHide').html()
    sourceTrigger: '#subPaymentViewHide'
  });
  $el.tips({
    trigger: '#pick_shipment_item',
    width: 260,
    type: 'click',
    // source: $("#noSupSkus_hideDiv").html()
    sourceTrigger: '#noSupSkus_hideDiv'
  });
  //展示价格说明
  $('#content').tips({
    trigger: '#price-desc',
    type:'click', 
    align:['top'],
    width: 180, 
    autoResize:true, 
    diff:6
  });

};
window.freshTips = freshTips;



function freshUI(){
  //初始化滑动状态
  $('.mode-tab-nav .mode-tab-item').hover(function() {
    $(this).addClass('hover');
  }, function() {
    $(this).removeClass('hover');
  });
}

function replaceStr(str,p1,p2){
  return (str == undefined || str == null || str == "")?"":str.replace(p1, p2);
}

//*******************************************************************地址和支付列表 Start ******************************
function paymentViewHide(){
  $('body').dialog({
      title:'请确认支付方式',
      width:620,
      height:320,
      type:'html',
      source:$("#paymentViewHide").html()
  });
}window.paymentViewHide=paymentViewHide;

function closeDialog(){
  $.closeDialog();
}window.closeDialog=closeDialog;

//删除收货人弹框
function deleteConsigneeDialog(id){
  $('body').dialog({
    title:'删除收货人信息',
    width:400,
    height:100,
    type:'html',
    source:'<div class="tip-box icon-box"><span class="warn-icon m-icon"></span><div class="item-fore"><h3>您确定要删除该收货地址吗？</h3></div><div class="op-btns ac"><a onclick="delete_Consignee('+id+')" href="#none" class="btn-9">确定</a><a href="javascript:$.closeDialog();" class="btn-9 ml10">取消</a></div></div>'
  });
}window.deleteConsigneeDialog=deleteConsigneeDialog;

//编辑收货人弹框
function openEditConsigneeDialog(id){
  var url = OrderAppConfig.DynamicDomain + "/consignee/editConsignee.action?consigneeId="+id;
  url = addFlowTypeParam(url); 
  $('body').dialog({
    title:'编辑收货人信息',
    width:690,
    height:350,
    type:'iframe',
    iframeTimestamp:false,
    source:url
  });
}window.openEditConsigneeDialog=openEditConsigneeDialog;


/**
 * 获取国际站cookies
 * 
 */
function getOverseaPurchaseCookies() {
  try {
    var actionUrl = "http://x.jd.com/clkinfo?rid="+Math.random()+"&callback=?";
    $.ajax({
      type : "post",
      dataType : "jsonp",
      url : actionUrl,
      jsonp : "jsonp", //传递给请求处理程序或页面的，用以获得jsonp回调函数名的参数名(一般默认为:callback)  
        jsonpCallback :"jsonp",
      cache : false,
      success : function(dataResult) {
        $("#overseaPurchaseCookies").val(dataResult.data);
      },
      error : function(XMLHttpResponse) {
      }
    });
  } catch (err) {
  }
}window.getOverseaPurchaseCookies = getOverseaPurchaseCookies;

function restData() {
  // 新用户保存后将值写回
  $("#isOpenConsignee").val("0");
  $("#isRefreshArea").val("0");
  $("#beforePickRegionId").val("");
  $("#beforePickSelRegionid").val("");
  $("#beforePickSiteId").val("");
  $("#beforePickName").val("");
}

//延迟关闭loading
function delayRemoveLoading(id){
  if(!$(id)) {
    return;
  }
  setTimeout(function(){
    $(id).remove();
  }, 300);
}
//******************************************************************* 地址和支付列表 End  ******************************



function couponInfoTip(){
  $(".virtual-table-body").each(function(i) {
    if($(this).find(".virtual-desc").attr("title") != undefined){
      var desc = $(this).find(".virtual-desc").attr("title");
      var tempStr = "此限品类优惠券不能购买商品";
      var descI = desc.indexOf(tempStr);
      if(descI > -1){
        $(this).find(".virtual-desc").html("此限品类优惠券不能购买以下商品，<a id='couponInfoId"+i+"'>查看详情 </a>");
        var $el = $(".virtual-table");
        $el.tips({
            trigger: "#couponInfoId"+i,
            width: 260,
            type: 'click',
            source:desc.substring(tempStr.length)
            //sourceTrigger: '#'
        });
      }
    }
  });
}window.couponInfoTip=couponInfoTip;


function eInfoTip(){
  var desc = $(".gift-item.gift-grid .tip.mt5").html();
  if(desc) { // 增加js防护
    var tempStr1 = "说明：订单中商品";
    var tempStr2 = "，不可使用京东E卡，谢谢.";
    var tempStr3 = "";
    desc = desc.substring(tempStr1.length,desc.indexOf(tempStr2)).split(",");
    $(desc).each(function(i) {tempStr3 += desc[i] + "</br>";});
    $(".gift-item.gift-grid .tip.mt5").html("说明：以下订单中商品  <a id='eInfo'>查看详情 </a>"+tempStr2);
    var $el = $("#eCardId");
    $el.tips({
      trigger: "#eInfo",
      width: 580,
      type: 'click',
      source:tempStr3
    });
  }
}window.eInfoTip=eInfoTip;
function loadSkuList() {
  var actionUrl = OrderAppConfig.AsyncDomain + "/loadSkuList.action";
  var param = addFlowTypeParam();
   //不重置默认地址
    param+="&t=1";
  var regionId = $("#regionId").val();
  var shopId = $("#shopId").val();
  if(regionId){
    param += "&regionId=" + regionId;
  }
  if(shopId){
    param += "&shopId=" + shopId;
  }
  jQuery.ajax({
    type : "POST",
    dataType : "json",
    url : actionUrl,
    data : param,
    cache : false,
    success : function(dataResult, textStatus) {
      // 没有登录跳登录
      if (isUserNotLogin(dataResult)) {
        goToLogin();
        return;
      }
      // 服务器返回异常处理,如果有消息div则放入,没有则弹出
      if (isHasMessage(dataResult)) {
        var message = getMessage(dataResult);
        alert(message);
      }
      if (dataResult.success) {
        if($("#flowType").val()=="1" || $("#flowType").val()=="13"){
          $("#skuListLoc").html(dataResult.skuList);
        }else{
          $("#span-skulist").html(dataResult.skuList);
        }
        loadSkuListStock();
        //showTangJiuSkuIcon();// 加载Icon
      }
    },
    error : function(XMLHttpResponse) {
    }
  });
}window.loadSkuList=loadSkuList;
//重新加载优惠券列表
function reloadCouponNew(reload){
  if($("#isNewVertual").val() == "true"){
    if("block" != $("#orderCouponId").css("display") && reload){
      alert('由于您变更了收货地址，优惠券信息会被重置，请重新选择！');
    }
    resetCoupontab();
    query_coupons_vertual();
  }else if($("#invokeNewCouponInterface").val() == "true"){
    if("block" != $("#orderCouponId").css("display") && reload){
    	alert('由于您变更了收货地址，优惠券信息会被重置，请重新选择！');
    }
    query_page_coupons($("#pageNum").val()); 
  }
}
window.reloadCouponNew = reloadCouponNew;
//重新加载优惠券列表
function reloadCoupon(reload){
  var display = $("#orderCouponId").css("display");
  var refreshOrderCouponId = false;
  if("block" == display){
    refreshOrderCouponId = true;
  }else{
    if(reload){
      refreshOrderCouponId = true;
      alert('由于您变更了收货地址，优惠券信息会被重置，请重新选择！');
    }
  }
  if(refreshOrderCouponId){
    $("#orderCouponId").css('display', 'none');
    query_coupons();
    isNeedPaymentPassword();
  }
}
window.reloadCoupon = reloadCoupon;
//处理无货弹层
var g_outSkus;
var g_noStockType;
function doOutSku(outSkus, noStockType){
  g_outSkus = outSkus;
  g_noStockType = noStockType;
  var outSkuArr = outSkus.split(",");
  if(noStockType == "600158"){
    //处理全部无货的情况
    try{
      var firstSku = g_outSkus.split(",")[0];
        someMoreRecommend(firstSku,'619028','trade-nostock-recommendation-render', function(hasData){
          if(!hasData){
            someMoreRecommend(firstSku,'108002','trade-nostock-recommendation-render', function(hasData2){
              if(!hasData2){
                goCart();
              }else{
                openWinForAllOutSku(670, 300, "nostock-box02");
              }
            });
          }else{
            openWinForAllOutSku(670, 300, "nostock-box02");
          }
        });
    } catch (e) {
      goCart();
    }
  }else if(noStockType == "600157"){
    //处理部分无货的情况
    try{
      var appendHtml = fillSkuList(outSkuArr);
      if(appendHtml){
        openWinForOutSku(670, 400, "nostock-box01", "out-skus", appendHtml);
      }else{
        goCart();
      }
    }catch (e){
      goCart();
    }
  }
}window.doOutSku = doOutSku;
//填充无货弹层中的商品信息
function fillSkuList(outSkuArr){
  var allGoodsObj = cloneGoodsObj();
  var goodsObj = null;
  var isNoStock = false;
  for(var i = 0; i < allGoodsObj.length; i++){
    var goodsItem = allGoodsObj[i];
    for(var h = 0; h < goodsItem.skuList.length; h++){
      isNoStock = false;
      goodsObj = goodsItem.skuList[h];
      for(var j = 0; j < outSkuArr.length; j++){
        if(goodsObj.skuId == outSkuArr[j]){
          goodsObj.noStock = true;
          isNoStock = true;
        }
        if(goodsObj.gifts.length > 0){
          var giftObj = null;
          for(var k = 0; k < goodsObj.gifts.length; k++){
            giftObj = goodsObj.gifts[k];
            if(giftObj.skuId == outSkuArr[j]){
              giftObj.noStock = true;
              isNoStock = true;
            }
          }
        }
      }
      if(isNoStock){
        if(goodsItem.productType == "suit"){
          goodsItem.noStock = true;
        }
      }
    }
  }
  var goodsHtmls = "";
  for(var i = 0; i < allGoodsObj.length; i++){
    var goodsItem = allGoodsObj[i];
    var goodsHtml = buildHtmlEle(goodsItem);
    goodsHtmls += goodsHtml;
  }
  return goodsHtmls;
}
//根据获取到的商品对象构建html元素
function buildHtmlEle(goodsObj){
  var goodHtml = "";
  for(var i=0; i < goodsObj.skuList.length; i++){
    goodHtml += buildItemHtml(goodsObj.skuList[i]);
  }
  if(goodsObj.productType == "suit"){
    //goodHtml = "<div class='goods-suit" + (goodsObj.noStock ? " nostock-item" : "") + "'>"
    goodHtml = "<div class='goods-suit'>"
        +         "<div class='goods-suit-tit'>"
        +               "<strong>"
        +         (goodsObj.suitName ? goodsObj.suitName : '')
        +               "</strong>"
        +     "</div>"
        +            goodHtml
        +      "</div>";
  }
  return goodHtml;
}
function buildItemHtml(goodsObj){
  var goodsItem ="<div class='goods-item"  + (goodsObj.noStock ? " nostock-item" : "") + "'>"
        +      "<div class='p-img'>"
        +         "<img src='" + goodsObj.skuImg + "' alt=''>"
        +      "</div>"
        +      "<div class='goods-msg'>"
        +          "<div class='p-name'>" + goodsObj.skuName + "</div>"
        +      "</div>"
        +      "<div class='p-stock'><span class='ftx-01'>" + (goodsObj.noStock ? "无货 ": "") + "</span></div>"
        +      "<div class='clr'></div>";
  if(goodsObj.gifts.length > 0){
    var giftsHtml = "<div class='gift-items'>";
    for(var i= 0; i < goodsObj.gifts.length; i++){
      var giftName = goodsObj.gifts[i].skuInfo;
      var giftHtml = "<div class='gift-item" + (goodsObj.gifts[i].noStock ? " nostock-item" : "") + "' style='text-indent: 0px'>"
          +            "<span class='gift-name'>"
          +                 "<p>" + giftName + "</p>"
          +             "</span>"
          +             "<div class='p-stock'><span class='ftx-01'>" + (goodsObj.gifts[i].noStock ? "无货" : "") + "</span></div>"
          +       "</div>";
      giftsHtml += giftHtml;    
    }
    giftsHtml += "</div>";
    goodsItem += giftsHtml;
  }
  goodsItem += "</div>";
  return goodsItem;
}
function cloneGoodsObj(){
  var goodsObjs = new Array();
  var goodsListEle = $("#skuPayAndShipment-cont  div[class^='goods-list']");
  for(var i = 0; i < goodsListEle.length; i++){
    var goodsItems = $(goodsListEle[i]).find("div[class^='goods-items']");
    for(var j = 0; j < goodsItems.length; j++){
      var goodsItem = $(goodsItems[j]);
      var goodsSuits = goodsItem.children("div[class^='goods-suit']");
      var goodsList = null;
      var goodsObj = {};
      if(goodsSuits.length > 0){
        //处理套装
        goodsObj.productType = "suit";
        var goodsSuitTit = $(goodsSuits[0]).find("div[class^='goods-suit-tit']");
        if(goodsSuitTit.length > 0){
          var suitTip = "";
          var goodsSuitTitEle = $(goodsSuitTit[0]);
          var suitType = goodsSuitTitEle.find("span[class^='sales-icon']");
          if(suitType.length <= 0){
            suitType = goodsSuitTitEle.find("span[class^='coop-cut-i']");
          }
          if(suitType.length > 0){
            suitTip += "【" + $(suitType[0]).html() + "】";
          }
          var suitName = goodsSuitTitEle.find("strong");
          if(suitName.length > 0){
            suitTip += $(suitName[0]).html();
          }
          goodsObj.suitName = suitTip;
        }
        goodsList = $(goodsSuits[0]).find("div[class^='goods-item']");
      }else{
        //处理单品
        goodsObj.productType = "item";
        goodsList = goodsItem.find("div[class^='goods-item']");
      }
      if(goodsList.length > 0){
        var cloneObjs = cloneProducts(goodsList);
        goodsObj.skuList = cloneObjs;
        goodsObjs.push(goodsObj);
      }
    }
  }
  return goodsObjs;
}window.cloneGoodsObj = cloneGoodsObj;
function cloneProducts(goodsEles){
  var goodsObjs = new Array();
  for(var i = 0; i < goodsEles.length; i++){
    var goodsEle = $(goodsEles[i]);
    var goodsObj = {};
    goodsObj.skuId = goodsEle.attr("goods-id");
    var skuImg = goodsEle.find("div[class='p-img'] img").first().attr("src");
    var skuName = goodsEle.find("div[class='p-name'] a").first().html();
    goodsObj.skuImg = skuImg;
    goodsObj.skuName = skuName;
    var gifts = goodsEle.find("div[class^='gift-item']");
    var giftArr = new Array();
    var gift;
    for(var j = 0; j < gifts.length; j++){
      gift = $(gifts[j]);
      var skuId = gift.attr("gift-id");
      var skuInfo = gift.find("p").first().html();
      giftArr.push({"skuId" :  skuId, "skuInfo" : skuInfo});
    }
    goodsObj.gifts = giftArr;
    goodsObjs.push(goodsObj);
  }
  return goodsObjs;
}window.cloneProducts = cloneProducts;
//打开无货弹层
function openWinForAllOutSku(width, height, sourceId){
  var appendHtml = $("#trade-nostock-recommendation-render").html();
  if(appendHtml){
    openWinForOutSku(width, height, sourceId, "trade-nostock-recommendation", appendHtml);
    $("#trade-nostock-recommendation-render").html("");
  }else{
    goCart();
  }
  
}window.openWinForAllOutSku = openWinForAllOutSku;
function openWinForOutSku(width, height, sourceId, targetEle, appendHtml){
  var sourceHtml = $("#" + sourceId).html();
    $("body").dialog({
        title: "很抱歉，无货啦",
        width: width,
        height: height,
        type: "html",
        source: sourceHtml,
        onReady:function(){
          $(".ui-dialog-close").hide();
          $("#" + targetEle).append(appendHtml);
        }
    });
}window.openWinForOutSku = openWinForOutSku;
//无货弹层后处理继续购物
function continueBuy(){
  log('gz_ord', 'gz_proc', 6, 'bfwhjxjs');
  goOrder();
  /*if(g_outSkus){
    //调用购物车接口uncheck购物车，如果成功则刷新结算页，否则按原有方式调转购物车
    var actionUrl = OrderAppConfig.Domain + "/order/unCheckCartItem.action";
    var param = {"outSkus" : g_outSkus};
    jQuery.ajax({
      type : "POST",
      dataType : "json",
      url : actionUrl,
      data : param,
      cache : false,
      success : function(result) {
        if(result.resultFlag){
          $.closeDialog();
          goOrder();
        }else{
          goCart();
        }
      },
      error : function(error) {
        goCart();
      }
    });
  }*/
}window.continueBuy = continueBuy;
/**
*运费弹窗
*/
function freightTips(){
  var $el = $("#container");
  $el.tips({
        tipsClass: "freight-tips",
        trigger: ".freight-icon",
        width: 336,
        type: "click",
        sourceTrigger: "#tooltip-box06",
        callback: function() {}
      });
}window.freightTips=freightTips;
freightTips();

//虚拟tab资产切换
$(".order-virtual").switchable({
  navItem:'ui-switchable-item',
  navSelectedClass:'curr',
  mainClass:'ui-switchable-panel',
  event: 'click',
  delay: 0
  //callback: showScrollVirtual
});

});////FE 模块加载 end

/**
 * 跨店铺满减点击 详情 更改背景色
 * @param promotionID 促销ID
 */
function changeBackGround(promotionID){
  if(!$("."+promotionID).hasClass("coop-cut-goods")){
    $(".coop-cut-goods").removeClass("coop-cut-goods");
    $("."+promotionID).addClass("coop-cut-goods");
  }else{
    $(".coop-cut-goods").removeClass("coop-cut-goods");
  }
}
preSaleShow();
function preSaleShow(){
	if($("#presale-type35").length>0){
		var skuId=$("#presale-type35").attr("name");
		var type=35;
		callYuShouByJsonp(type,skuId);
	}else if($("#chooseEarnestPay").length>0){
		var skuId=$("#chooseEarnestPay").attr("name"); 
		var type=24;
		callYuShouByJsonp(type,skuId);
	} 
}


function callYuShouByJsonp(type,skuId) {
//http://yushou.jd.com/youshouinfo.action?sku=1229987&callback=jQuery7288465&_=1444555665528
			 var actionUrl = "http://yushou.jd.com/youshouinfo.action?sku="+skuId+"&callback=?";
			    $.ajax({
			      type : "post",
			      dataType : "jsonp",
			      url : actionUrl,
			      jsonp : "jsonp", //传递给请求处理程序或页面的，用以获得jsonp回调函数名的参数名(一般默认为:callback)  
			        jsonpCallback :"jsonp",
			      cache : false,
			      success : function(dataResult) {
	    			  if ($("#AllPayRadio").attr("class") == "presale-payment-item item-selected") {
	    				    $("#chooseEarnestPay").css("display", "none");
	    				    $("#chooseAllPay").css("display", "inline");
	  			    	  if (dataResult.ret.expAmount == undefined || dataResult.ret.expAmount == null || dataResult.ret.expAmount == "" || dataResult.ret.expAmount == 0) {
				    		  return;
				    	  }else{
				    		  if(type==35){
				    			  $('#pre-state').after('<span id="pre-weikuan" class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>'); 
				    		  }else if(type==24){
				    			  $('#pre-state').after('<span id="pre-weikuan" class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>');
				    		  }
				    	  }
	    				    $("#pre-weikuan").css("display", "none");
	    				    return;
	    			  }
			    	  if (dataResult.ret.expAmount == undefined || dataResult.ret.expAmount == null || dataResult.ret.expAmount == "" || dataResult.ret.expAmount == 0) {
			    		  return;
			    	  }else{
			    		  if(type==35){
			    			  $('#pre-state').after('<span id="pre-weikuan" class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>'); 
			    			 // $('#presale-type35').append('<span class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>'); 
			    		  //alert(dataResult.ret.jdPrice);
			    		  }else if(type==24){
			    			  $('#pre-state').after('<span id="pre-weikuan" class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>');
			    			  //$('#pre-weikuan').append('<span class="presale-promotion">尾款已优惠'+dataResult.ret.expAmount+'元</span>');
			    		  //alert(dataResult.ret.jdPrice);
			    		  }
			    	  }
			       // $("#overseaPurchaseCookies").val(dataResult.data);
			      },
			      error : function(XMLHttpResponse) {
			      }
			    });
	}
function insertEquipInfo(){
	try{
		getJdEid(function(eid,fp){
			$("#eid").val(eid);
			$("#fp").val(fp);
		});
	}catch(e){
	}
}
$("#txt_paypassword").keyup(function(){
	$(".pay-pwd-error").hide();
});
function modifyNeedPay(price){
	$("#sumPayPriceId").text("￥" + price);
	resetBt(price);
}
