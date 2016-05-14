 
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

    showFormurl("新增收件人信息", url, onclosedialog, { width: 690, height:417});

}
function onclosedialog( ) {

   

}