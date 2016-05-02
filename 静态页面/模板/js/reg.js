define(function (require, exports, module) {
    require('jdf/1.0.0/ui/placeholder/1.0.0/placeholder.js');
    require('/misc2016/js/validation.js');
    require('/misc2016/js/suggest');
    require('jdf/1.0.0/ui/dialog/1.0.0/dialog');
    var capslock = require('/misc2016/js/capslock');
    // input
    var form = $("#register-form");
    var form_account = $("#form-account");
    var form_email = $("#form-email");
    //密码
    var form_pwd = $("#form-pwd");
    //手机
    var form_phone = $("#form-phone");
    //获取手机验证码
    var btn_getcode = $("#getPhoneCode");
    var auth_code = $("#authCode");
    //图片验证码
    var imgAuthCode = $("#imgAuthCode");
    //手机验证码
    var phone_code = $("#phoneCode");
    //手机绑定状态
    var state = $("#state");
    var uuid = $("#uuid").val();
    //选择手机号码国家
    var selectCountry = $("#select-country");
    var icons = {
        def: '<i class="i-def"></i>',
        error: '<i class="i-error"></i>',
        weak: '<i class="i-pwd-weak"></i>',
        medium: '<i class="i-pwd-medium"></i>',
        strong: '<i class="i-pwd-strong"></i>'
    };
    //默认手机注册
    var registerType = 'phone';
    var phoneNoWithCountryCode='';
    var ishidden=$("#authcodeDiv").is(":hidden");
    suggestsList = {};

    function init() {
        initPlaceholer();
        setAuthcode();
        checkAcount();
        //海外手机注册
        // phoneCountry();
        checkEmail();
        checkPwd();
        //getPhoneCode();
        validate();
        //注册协议
        agreen();
        bindEvent();
    }
    function getStringLength(str){
        if(!str){
            return;
        }
        var bytesCount=0;
        for (var i = 0; i < str.length; i++)
        {
            var c = str.charAt(i);
            if (/^[\u0000-\u00ff]$/.test(c))
            {
                bytesCount += 1;
            }
            else
            {
                bytesCount += 2;
            }
        }
        return bytesCount;
    }
    function resetStringLength(length,_id){
        _id='#'+_id;
        while(getStringLength($(_id).val())>length){
            $(_id).val($(_id).val().substring(0,$(_id).val().length-1))
        }
    }
    function bindEvent(){
        $('input').bind('input',function(){
            var _id=$(this).attr('id');
            switch(_id){
                //case 'form-account':
                //    resetStringLength(20,_id);
                //    break;
                case 'form-equalTopwd':
                case 'form-pwd':
                    resetStringLength(20,_id);
                    break;
                case 'form-email':
                    resetStringLength(50,_id);
                    break;
                case 'form-phone':
                    resetStringLength(11,_id);
                    break;
                case 'authCode':
                case'phoneCode':
                    resetStringLength(6,_id);
                    break;
            }
        })

        btn_getcode.bind('click', function(){
            if(!ishidden){
                validateAuthCode();
            }else{
                getPhoneCode();
            }
        });
    }
    //表单验证
    var validator;

    function validate() {
        addrules();
        validator = form.validate({
            //忽略
            ignore: '.ignore',
            submitHandler: function (form) {
                //提交表单
                formSubmit(form);
                //阻止表单提交
                return false;
            },
            onkeyup: false,
            rules: {
                //用户名
                regName: {
                    required: true,
                    user: true,
                    rangelength: [4, 20],
                    fullNumber: true,

                    remote: {
                        //url:'user.action',
                        url: '../validateuser/isPinEngaged',
                        contentType: "application/x-www-form-urlencoded; charset=utf-8",
                        type:"post",
                        cache:false,
                        data: {
                            pin: function () {
                                return form_account.val();
                            }
                        },
                        callback: userCallback
                    }
                },
                //密码
                pwd: {
                    required: true,
                    rangelength: [6, 20],
                    strength: true,
                    same: '#form-account'
                },
                pwdRepeat: {
                    required: true,
                    equalTo: '#form-pwd'
                },
                email: {
                    required: true,
                    maxlength:50,
                    email: true,
                    remote: {
                        cache:false,
                        url: '../validateuser/isEmailEngaged',
                        callback: emailCallback
                    }
                },
                phone: {
                    required: true,
                    phone: true,
                    remote: {
                        url: '../validateuser/isMobileEngaged',
                        cache:false,
                        //url:'phone.action',
                        data: {
                            mobile: function () {
                                return form_phone.val();
                            }
                        },
                        callback: phoneCallback
                    }
                },
                authCode: {
                    required: true
                },
                mobileCode: {
                    required: true
                },
                agreen: {
                    required: true
                }
            },
            messages: {
                regName: {
                    required: icons.error + '请输入用户名',
                    rangelength: icons.error + '长度只能在{0}-{1}个字符之间'
                },
                pwd: {
                    required: icons.error + '请输入密码',
                    rangelength: icons.error +
                    '长度只能在{0}-{1}个字符之间'
                },
                pwdRepeat: {
                    required: icons.error + '请再次输入密码',
                    equalTo: icons.error + '两次密码输入不一致'
                },
                email: {
                    required: icons.error + '请输入邮箱',
                    email: icons.error + '格式错误'
                },
                phone: {
                    required: icons.error + '请输入手机号'
                },
                authCode: {
                    required: icons.error + '请输入图片验证码'
                },
                mobileCode: {
                    required: icons.error + '请输入短信验证码'
                },
                agreen: {
                    required: icons.error + '请同意协议并勾选'
                }
            }
        });
    }
    //提交表单
    function formSubmit(form) {
        $btnRegister = $("#form-register");
        //海外手机注册
        //phoneNoWithCountryCode=selectCountry.attr('country_id')+form_phone.val();
        //var param = $(form).serialize().replace(/phone=\d+/,'phone='+phoneNoWithCountryCode);
        var param = $(form).serialize();
        var ajaxurl = '../register/regService?';
        if (registerType == 'email') {
            ajaxurl = '../register/sendRegEmail?'
        }
        $.ajax({
            type: 'post',
            url: ajaxurl + location.search.substring(1),
            contentType: "application/x-www-form-urlencoded; charset=utf-8",
            data: param,
            cache:false,
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
                        if(obj.dispatchUrl.indexOf("jdpay.com")!=-1){
                            jQuery.getJSON("//sso.jd.com/setCookie?t=sso.jdpay.com&callback=?",function(){
                                successRedirectURL(obj.dispatchUrl);
                            });
                        }else{
                            successRedirectURL(obj.dispatchUrl);
                        }
                    }
                }
                $btnRegister.text('立即注册');
            }
        });
    }

    function phonecodeCallback(element, validator, response) {
        var valid = false;
        var errors = {};
        var data = response.data;
        if (element.value == data) {
            valid = true;
        } else {
            errors[element.name] = icons.error + '验证码错误';
        }
        validator.showErrors(errors);
        return valid;
    }
    //验证规则
    function addrules() {
        //用户名
        $.validator.addMethod('user', function (value, element) {
            return this.optional(element) ||
                /^[A-Za-z0-9_\-\u4e00-\u9fa5]+$/.test(value);
        }, icons.error + '格式错误，仅支持汉字、字母、数字、“-”“_”的组合');
        $.validator.addMethod('fullNumber', function (value, element) {
            return this.optional(element) || !/^[0-9]+$/.test(
                    value);
        }, icons.error + '用户名不能是纯数字，请重新输入！');
        //手机
        $.validator.addMethod('phone', function (value, element) {
            var country_id = selectCountry.attr("country_id");
            var reg = {
                //海外手机注册
                "86": "^(13|15|18|14|17)[0-9]{9}$", //中国
                //"0086": "^(13|15|18|14|17)[0-9]{9}$", //中国
                "0055": "^[0-9]{11}$",
                "0049": "^[0-9]{11}$",
                "0058": "^[0-9]{11}$",
                "0062": "^[0-9]{11}$",
                "0081": "^[0-9]{10}$",
                "0082": "^[0-9]{10}$",
                "0001": "^[0-9]{10}$",
                "0064": "^[0-9]{10}$",
                "0007": "^[0-9]{10}$",
                "0063": "^[0-9]{10}$",
                "0039": "^[0-9]{10}$",
                "0091": "^[0-9]{10}$",
                "0044": "^[0-9]{10}$",
                "0084": "^[0-9]{10}$",
                "0886": "^[0-9]{9}$",
                "0060": "^[0-9]{9}$",
                "0061": "^[0-9]{9}$",
                "0791": "^[0-9]{9}$",
                "0244": "^[0-9]{9}$",
                "0358": "^[0-9]{9}$",
                "0031": "^[0-9]{9}$",
                "0420": "^[0-9]{9}$",
                "0041": "^[0-9]{9}$",
                "0046": "^[0-9]{9}$",
                "0066": "^[0-9]{9}$",
                "0034": "^[0-9]{9}$",
                "0852": "^[0-9]{8}$",
                "0065": "^[0-9]{8}$",
                "0853": "^[0-9]{8}$",
                "0045": "^[0-9]{8}$"
            }
            return this.optional(element) || new RegExp(reg[
                country_id]).test(value);
        }, icons.error + '格式有误');
        //密码
        $.validator.addMethod('strength', function (value, element) {
            return this.optional(element) || pwdStrengthRule($(
                    element), value);
        }, icons.weak + '有被盗风险,建议使用字母、数字和符号两种及以上组合');
        $.validator.addMethod('same', function (value, element, param) {
            var target = $(param);
            return value !== target.val();
        }, icons.error + '密码与用户名相似，有被盗风险，请更换密码');
    }
    // checkpwd
    var weakPwds = ["123456", "123456789", "111111", "5201314",
        "12345678", "123123", "password", "1314520", "123321",
        "7758521", "1234567", "5211314", "666666", "520520",
        "woaini", "520131", "11111111", "888888", "hotmail.com",
        "112233", "123654", "654321", "1234567890", "a123456",
        "88888888", "163.com", "000000", "yahoo.com.cn", "sohu.com",
        "yahoo.cn", "111222tianya", "163.COM", "tom.com", "139.com",
        "wangyut2", "pp.com", "yahoo.com", "147258369", "123123123",
        "147258", "987654321", "100200", "zxcvbnm", "123456a",
        "521521", "7758258", "111222", "110110", "1314521",
        "11111111", "12345678", "a321654", "111111", "123123",
        "5201314", "00000000", "q123456", "123123123", "aaaaaa",
        "a123456789", "qq123456", "11112222", "woaini1314",
        "a123123", "a111111", "123321", "a5201314", "z123456",
        "liuchang", "a000000", "1314520", "asd123", "88888888",
        "1234567890", "7758521", "1234567", "woaini520",
        "147258369", "123456789a", "woaini123", "q1q1q1q1",
        "a12345678", "qwe123", "123456q", "121212", "asdasd",
        "999999", "1111111", "123698745", "137900", "159357",
        "iloveyou", "222222", "31415926", "123456", "111111",
        "123456789", "123123", "9958123", "woaini521", "5201314",
        "18n28n24a5", "abc123", "password", "123qwe", "123456789",
        "12345678", "11111111", "dearbook", "00000000", "123123123",
        "1234567890", "88888888", "111111111", "147258369",
        "987654321", "aaaaaaaa", "1111111111", "66666666",
        "a123456789", "11223344", "1qaz2wsx", "xiazhili",
        "789456123", "password", "87654321", "qqqqqqqq",
        "000000000", "qwertyuiop", "qq123456", "iloveyou",
        "31415926", "12344321", "0000000000", "asdfghjkl",
        "1q2w3e4r", "123456abc", "0123456789", "123654789",
        "12121212", "qazwsxedc", "abcd1234", "12341234",
        "110110110", "asdasdasd", "123456", "22222222", "123321123",
        "abc123456", "a12345678", "123456123", "a1234567",
        "1234qwer", "qwertyui", "123456789a", "qq.com", "369369",
        "163.com", "ohwe1zvq", "xiekai1121", "19860210", "1984130",
        "81251310", "502058", "162534", "690929", "601445",
        "1814325", "as1230", "zz123456", "280213676", "198773",
        "4861111", "328658", "19890608", "198428", "880126",
        "6516415", "111213", "195561", "780525", "6586123",
        "caonima99", "168816", "123654987", "qq776491",
        "hahabaobao", "198541", "540707", "leqing123", "5403693",
        "123456", "123456789", "111111", "5201314", "123123",
        "12345678", "1314520", "123321", "7758521", "1234567",
        "5211314", "520520", "woaini", "520131", "666666",
        "RAND#a#8", "hotmail.com", "112233", "123654", "888888",
        "654321", "1234567890", "a123456"
    ];
    var pwdStrength = {
        1: {
            reg: /^.*([\W_])+.*$/i,
            msg: icons.weak + '有被盗风险,建议使用字母、数字和符号两种及以上组合'
        },
        2: {
            reg: /^.*([a-zA-Z])+.*$/i,
            msg: icons.medium + '安全强度适中，可以使用三种以上的组合来提高安全强度'
        },
        3: {
            reg: /^.*([0-9])+.*$/i,
            msg: icons.strong + '你的密码很安全'
        }
    };

    function pwdStrengthRule(element, value) {
        var level = 0;
        var typeCount=0;
        var flag = true;
        var valueLength=getStringLength(value);
        if (valueLength < 6) {
            element.parent().removeClass('form-item-valid').removeClass(
                'form-item-error');
            element.parent().next().find('span').removeClass('error').html(
                $(element).attr('default'));
            return;
        }

        for (key in pwdStrength) {
            if (pwdStrength[key].reg.test(value)) {
                typeCount++;
            }
        }
        if(typeCount==1){
            if(valueLength>10){
                level=2;
            }else{
                level=1;
            }
        }else if(typeCount==2){
            if(valueLength<11&&valueLength>5){
                level=2;
            }
            if(valueLength>10){
                level=3;
            }
        }else if(typeCount==3){
            if(valueLength>6){
                level=3;
            }
        }

        if ($.inArray(value, weakPwds) !== -1) {
            flag = false;
        }
        if (flag && level > 0) {
            element.parent().removeClass('form-item-error').addClass(
                'form-item-valid');
        } else {
            element.parent().addClass('form-item-error').removeClass(
                'form-item-valid');
        }
        if (pwdStrength[level] !== undefined) {
            pwdStrength[level]>3?pwdStrength[level]=3:pwdStrength[level];
            element.parent().next().html('<span>' + pwdStrength[level].msg +
                '</span>')
        }
        return flag;
    }
    //邮箱
    function checkEmail() {
        var wrap = form_email.parents(".item-email-wrap");
        // 或者邮箱验证
        var orEmail = $(".orEmail");
        var orPhone = $(".orPhone");
        // fix placeholder style
        wrap.find('txt').css('line-height', "52px");
        orEmail.click(function () {
            wrap.show();
            orEmail.hide();
            //删除忽略验证
            form_email.removeClass("ignore");
            registerType = 'email';
        });
        orPhone.click(function () {
            wrap.hide();
            orEmail.show();
            form_email.addClass("ignore");
            registerType = 'phone';
        });
        emailSuggest();
    }

    function emailSuggest() {
        var emailDomain = ['@qq.com', '@163.com', '@126.com',
            '@Sina.com', '@Sohu.com', '@Gmail.com'
        ]
        var emailSuggest = form_email.suggest({
            type: 'email',
            items: emailDomain,
            customerClass: 'email-suggest',
            onshow: function () {
                hideError(form_email);
            }
        })
    }

    function checkAcount() {
        //输入过程中需要
        //判断是否有特殊字符
        //关闭重名提醒提示面板
        var item = form_account.parent();
        var reg = /^[A-Za-z0-9_\-\u4e00-\u9fa5]+$/;
        var errormsg = icons.error +
            '格式错误，仅支持汉字、字母、数字、“-”“_”的组合';
        form_account.on('keyup', function (e) {
            if (filterKey(e)) {
                return;
            }
            var value = $(this).val();
            hideError(form_account);
            if (value != '' && !reg.test(value)) {
                onKeyupHandler(form_account, errormsg);
            }
            //如果提示面板存在则隐藏
            if (suggestsList['username']) {
                suggestsList['username'].hide();
            }
        })
        $("#form-phone,#form-email").on('keyup', function (e) {
            if (filterKey(e)) {
                return;
            }
            var value = $(this).val();
            if(value==''){
                hideError($(e.target));
            }
        })
    }

    function filterKey(e) {
        var excludedKeys = [13, 9, 16, 17, 18, 20, 35, 36, 37, 38,
            39,
            40, 45, 144, 225
        ];
        return $.inArray(e.keyCode, excludedKeys) !== -1;
    }

    function checkPwd() {
        form_pwd.on('keyup', function (e) {
            var value = $(this).val();
            pwdStrengthRule(form_pwd, value);
        })
    }
    /*
     * 用户名验证错误回调
     * @element  input元素
     * @repsonse 服务器返回的数据
     */
    function userCallback(element, validator, response) {
        var valid = false;
        var errors = {};
        var data = response.morePin
        if (response.success == 0) {
            valid = true;
        }
        if (response.success == 2) {
            valid = false;
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '用户名包含了非法词';
        }
        if(response.success == 1 && getStringLength(element.value)>15){
            valid = false;
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '该用户名已被使用，请重新输入';
        }
        function create() {
            var input = $(element);
            return input.suggest({
                items: data,
                customerClass: 'user-suggest'
            })
        }
        //推荐用户名
        if (data && data.length) {
            valid = false;
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '该用户名已被使用，请重新输入';
            var wrap = $(element).parent();
            data.unshift({
                value: '<i class="i-error1"></i><span>已注册，推荐您选择</span>',
                disable: true
            });
            if (suggestsList['username']) {
                suggestsList['username'].render(data).show();
                $('.suggest-container').closest('.form-item').css('z-index',15);
            } else {
                suggestsList['username'] = create();
                $('.suggest-container').closest('.form-item').css('z-index',15);
            }
            //输入内容相同取缓存信息
             validator.settings.messages[element.name].remote = function () {
                 $(element).focus();
                 if (suggestsList['username']) {
                     suggestsList['username'].show();
                     $('.form-item-account').addClass('form-item-error');
                 }

             }
        }
        if (!valid) {
            $(element).focus();
            validator.showErrors(errors);
            $('.form-item-account').addClass('form-item-error');
        }
        return valid;
    }
    // remote callback
    function phoneCallback(element, validator, response) {
        var valid = false,
            errors = {};
        if (response.success == 0) {
            $(element).data('isbind', "");
            state.val('');
            $(element).parent().removeClass('phone-binded');
            $(element).parent().next().removeClass('phone-bind-tip').html(
                '<span></span>');
            valid = true;
        }
        //手机号被注册，继续注册解绑
        if (response.success == 1) {
            valid = true;
            $(element).data('isbind', "unbind");
            state.val('unbind');
            $(element).parent().addClass('phone-binded');
            $(element).parent().next().addClass('phone-bind-tip').html(
                '<span><i class="i-info"></i>手机号已注册，继续注册将与原账号解绑</span>'
            );
        }
        if (response.success == 2) {
            valid = false;
            $(element).data('isbind', "");
            state.val('');
            $(element).parent().removeClass('phone-binded');
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '该手机号已重新注册并绑定，' +
                response.ub + '天内不可改绑';
        }
        if (!valid) {
            $(element).focus();
            validator.showErrors(errors);
        }
        return valid;
    }

    function emailCallback(element, validator, repsonse) {
        var valid = false,
            errors = {};
        if (repsonse.success == 0) {
            valid = true;
        }
        if (repsonse.success == 1) {
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '该邮箱已被使用，请更换其它邮箱';
        }
        if (repsonse.success == 2) {
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '格式错误';
        }
        if (repsonse.success == 3) {
            validator.settings.messages[element.name].remote = errors[
                element.name] = icons.error + '请更换其它邮箱';
        }
        if (!valid) {
            $(element).focus();
            validator.showErrors(errors);
        }
        return valid;
    }
    //验证码
    //function ahthcodeCallback(element, validator, response) {
    //    var valid = false,
    //        errors = {};
    //    if (response.success == 0) {
    //        valid = true;
    //    }
    //    if (response.success == 1) {
    //        validator.settings.messages[element.name].remote = errors[
    //            element.name] = icons.error + '验证码不正确或已过期，请重新获取';
    //        console.log('success1');
    //        $('#imgAuthCode').trigger('click');
    //
    //    }
    //    if (!valid) {
    //        $(element).focus();
    //        validator.showErrors(errors);
    //    }
    //    return valid;
    //}
    /**选择手机下拉**/
    function phoneCountry() {
        selectCountry.suggest({
            items: [{
                rule:11,
                //海外手机注册
                id: '86',
                //id: '0086',
                value: '中国 + 86'
            }, {
                rule:9,
                id: '0886',
                value: '台湾 + 886'
            }, {
                rule:8,
                id: '0852',
                value: '香港 +852'
            }, {
                rule:9,
                id: '0060',
                value: '马来西亚 +60'
            }, {
                rule:8,
                id: '0065',
                value: '新加波 +65'
            }, {
                rule:10,
                id: '0081',
                value: '日本 +81'
            }, {
                rule:10,
                id: '0082',
                value: '韩国 +82'
            }, {
                rule:10,
                id: '0001',
                value: '美国 +1'
            }, {
                rule:10,
                id: '0001',
                value: '加拿大 +1'
            }, {
                rule:9,
                id: '0061',
                value: '澳大利亚 +61'
            }, {
                rule:10,
                id: '0064',
                value: '新西兰 +64'
            }, {
                rule:9,
                id: '0791',
                value: '阿联酋 +791'
            }, {
                rule:9,
                id: '0244',
                value: '安哥拉 +244'
            }, {
                rule:8,
                id: '0852',
                value: '澳门 +853'
            }, {
                rule:11,
                id: '0055',
                value: '巴西 +55'
            }, {
                rule:8,
                id: '0045',
                value: '丹麦 +45'
            }, {
                rule:11,
                id: '0049',
                value: '德国 +49'
            }, {
                rule:10,
                id: '0007',
                value: '俄罗斯 +7'
            }, {
                rule:9,
                id: '0033',
                value: '法国 +33'
            }, {
                rule:10,
                id: '0063',
                value: '菲律宾 +63'
            }, {
                rule:9,
                id: '0358',
                value: '芬兰 +358'
            }, {
                rule:9,
                id: '0031',
                value: '荷兰 +31'
            }, {
                rule:9,
                id: '0420',
                value: '捷克 +420'
            }, {
                rule:9,
                id: '0041',
                value: '瑞士 +41'
            }, {
                rule:9,
                id: '0046',
                value: '瑞典 +46'
            }, {
                rule:9,
                id: '0066',
                value: '泰国 +66'
            }, {
                rule:11,
                id: '0058',
                value: '委内瑞拉 +58'
            }, {
                rule:9,
                id: '0034',
                value: '西班牙 +34'
            }, {
                rule:10,
                id: '0039',
                value: '意大利 +39'
            }, {
                rule:10,
                id: '0091',
                value: '印度 +91'
            }, {
                rule:10,
                id: '0062',
                value: '印度尼西亚 +62'
            }, {
                rule:10,
                id: '0044',
                value: '英国 +44'
            }, {
                rule:10,
                id: '0084',
                value: '越南 +84'
            }],
            wrapper:'<div id="scrollbar1">' +
        ' <div class="scrollbar disable"><div class="track"><div class="thumb"><div class="end"></div></div></div></div>' +
        '        <div class="viewport">' +
            '            <div class="overview">' +

            '            </div>' +
            '            </div>' +
            '            </div>',
            customerClass: 'phone-suggest',
            onSelected: function (item) {
                selectCountry.attr("country_id", item.attr(
                    "item_id"));
            }
        });
    }

    function showMobileCodeError() {
        var errors = {};
        validator.settings.messages['mobileCode'] = errors['mobileCode'] =
            icons.error + '验证码不正确或已过期，请重新获取';
        setAuthcode();
        validator.showErrors(errors);
    }
    function validateAuthCode(){
        if (!form_phone.valid() || (!auth_code.valid()&&ishidden!=true)) {
            return;
        }

        if(auth_code.val()==''){
            imgAuthCode.parent().addClass('form-item-error');
            imgAuthCode.parent().next().find(
                'span').addClass('error').show().html(icons.error +
                '请输入图片验证码'
            );
            return;
        }

        var data={
            uuid: uuid,
            authCode:auth_code.val()
        };

        $.ajax( {url: '../validate/validateAuthCode?r='+Math.random(),
            type: 'post',
            dataType: 'json',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: data,
            success:function(response){
                var valid = false,
                    errors = {};
                if (response.success == 0) {
                    valid = true;
                    $('#authCode').parent().addClass('form-item-valid');
                    getPhoneCode();
                }
                if (response.success == 1) {
                    imgAuthCode.parent().addClass('form-item-error');
                    imgAuthCode.parent().next().find(
                        'span').addClass('error').show().html(icons.error +
                        '验证码不正确或已过期'
                    );
                }
                if (!valid) {
                    //auth_code.val('');
                    //auth_code.focus();
                    imgAuthCode.trigger('click');
                    return;
                }

            }
        })
    }
    //验证手机号
    function getPhoneCode() {
        if (!form_phone.valid() || (!auth_code.valid() && ishidden !=true)) {
            return;
        }

        var sendUrl = '../notifyuser/mobileCode';
        //var sendUrl = 'sendphonecode.action';
        $('#getPhoneCode').attr('disabled',true);

        $.ajax({
            url: sendUrl,
            cache:false,
            data: {
                state: form_phone.data('isbind'),
                mobile: form_phone.val()
            },
            success: function (response) {
                $('#getPhoneCode').removeAttr('disabled');
                //imgAuthCode.trigger('click');
                var response = eval(response);
                hideError(phone_code);
                if (response.rs == 1 || response.remain) {
                    btn_getcode.parent().next().find(
                        'span').show().html(icons.def +
                        (response.remain||'验证码已发送，120s内输入有效。')
                    );
                    countdown();
                }

                if (response.rs == -1 || response.rs ==
                    -2) {
                    btn_getcode.parent().next().find(
                        'span').show().html(icons.def +
                        '网络繁忙，请稍后重新获取验证码');
                }
                if (response.info) {
                    btn_getcode.parent().next().find(
                        'span').show().html(icons.def +
                        response.info);
                }

            }

        })
        function countdown() {
            var time = 120;
            var timer;
            btn_getcode.html(time + 's后重新获取').addClass(
                'btn-code-disable');
            timer = setInterval(function () {
                time--;
                btn_getcode.html(time + 's后重新获取');
                if (time == 0) {
                    clearInterval(timer);
                    btn_getcode.html('获取验证码').removeClass(
                        'btn-code-disable');
                    //btn_getcode.bind('click.phonecode', get);
                }
            }, 1000);
            //取消点击事件
            //btn_getcode.off('click.phonecode');
        }
    }




    function setAuthcode() {
        imgAuthCode.trigger('click');
        imgAuthCode.click(function () {
            auth_code.val('');
            auth_code.focus();
        })
    }

    function hideError(input, msg) {
        var item = input.parent();
        var msg = msg || input.attr('default');
        item.removeClass('form-item-error form-item-valid');
        item.next().find('span').removeClass('error').html(msg).show();
        item.next().removeClass('phone-bind-tip');
        item.removeClass('phone-binded');
    }
    /**输入过程中处理标签的状态**/
    function onKeyupHandler(input, msg) {
        var item = input.parent();
        if (!item.hasClass('form-item-error')) {
            item.addClass('form-item-error')
        }
        item.removeClass('form-item-valid');
        item.next().find('span').addClass('error').html(msg).show();
    }

    function initPlaceholer() {
        $('input[placeholder]').placeholder({
            isValue: true,
            topDiff: 1
        });
    }
    //京东用户注册协议
    function agreen(){
        $('#protocol').click(function(){
            $('body').dialog({
                fixed: true,
                width: 947,
                height:517,
                title:'京东用户注册协议',
                maskClose: true,
                type: 'html',
                source:'<div class="protocol">'+$("#protocoldiv").html()+'</div>',
                onReady: function () {
                    this.content.find('.protocol-button').click(function () {
                        $.closeDialog();
                    })
                }
            })
            return false;
        });
        $('#payProtocol').click(function(){
            $('body').dialog({
                fixed: true,
                width: 947,
                height:517,
                title:'京东钱包服务协议',
                maskClose: true,
                type: 'html',
                source:'<div class="protocol">'+$("#payProtocoldiv").html()+'</div>',
                onReady: function () {
                    this.content.find('.protocol-button').click(function () {
                        $.closeDialog();
                    })
                }
            })
            return false;
        });
    }
    function showDialog(content) {
        $('body').dialog({
            title: '提示',
            fixed: true,
            width: 380,
            //height: 150,
            maskClose: true,
            type: 'html',
            source: '<div class="registerDialog">\
                        <div class="ico"></div>\
                        <div class="con">\
                        ' +
            content +
            '\
                    </div></div>'
        })
    }
    exports.init = init;
})
function successRedirectURL(url){
    var isIE = !-[1,];
    if(isIE){
        var link = document.createElement("a");
        link.href = url;
        link.style.display = 'none';
        document.body.appendChild(link);
        link.target = "_top";
        link.click();
    }else{
        window.top.location = url;
    }
}
