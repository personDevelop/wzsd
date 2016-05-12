function GetUserStauts()
{

    $.ajax({
        type: 'get',
        url: "/",
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        data: param,
        cache: false,
        beforeSend: function () {
            $btnRegister.text('正在注册..');
        },
        error: function () {
            showDialog('网络繁忙，请稍后再试');
        },
        success: function (response) {
            if (response) {
                var obj = eval(response);
                if (obj.info) {
                    if (obj.info == '短信验证码不正确或已过期!') {
                        console.log('showerror');
                        showMobileCodeError()
                    } else {
                        showDialog(obj.info);
                    }
                }
                if (obj.noAuth) {
                    window.location = obj.noAuth;
                }
                if (obj.success == true) {
                    if (obj.dispatchUrl.indexOf("jdpay.com") != -1) {
                        jQuery.getJSON("//sso.jd.com/setCookie?t=sso.jdpay.com&callback=?", function () {
                            successRedirectURL(obj.dispatchUrl);
                        });
                    } else {
                        successRedirectURL(obj.dispatchUrl);
                    }
                }
            }
            $btnRegister.text('立即注册');
        }
    });
   


}