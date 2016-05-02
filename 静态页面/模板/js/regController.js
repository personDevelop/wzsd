var regiseterController;


$(function(){
	initLister();
});
function initLister()
{
	var ListerMap=[
		{selector:$("#mobile"),eventtype:"blur",callback:validatePhone },
		{selector:$("#imgcodetext"),eventtype:"blur",callback:validateCode },
		{selector:$("#firstpass"),eventtype:"blur",callback:validatePwd },
		{selector:$("#secpass"),eventtype:"blur",callback:validatePwdAgain }
	];
	for (var i =0; i <ListerMap.length; i++) {
		var eventtype=ListerMap[i]["eventtype"];
		var func=ListerMap[i]["callback"];
		ListerMap[i]["selector"].bind(eventtype,function(func,ele){
			return function(){func.call(this,ele)};
		}(func,ListerMap[i]["selector"]));
	}
	function triggerValidate(){
		for (var i =0; i <ListerMap.length; i++) {
			var eventtype=ListerMap[i]["eventtype"];
			var func=ListerMap[i]["callback"];
			ListerMap[i]["selector"].trigger(eventtype);
		}
	}
	window.ValidateForm=triggerValidate;
}

function validatePhone(ele){
	if (ele.val()=="") {
		alert(1);
		$("#mobileerror").show();
	}else{
		$("#mobileerror").hide();
	}
}

function validateCode(ele){
	if (ele.val()=="") {
		$("#imgcodeerr").show();
	}else{
		$("#imgcodeerr").hide();
	}
}

function validatePwd(ele){
	if (ele.val()=="") {
		$("#passerr").show();
	}else{
		$("#passerr").hide();
	}
}

function validatePwdAgain(ele){
	if (ele.val()=="") {
		$("#secpasserr").show();
	}else{
		$("#secpasserr").hide();
	}
}