 var tarurl = '/settradepass';
        var pubkey = 'BCB3135849A3D3611C9FE728E7EEDAC7627AB56DD120061DB60A41C4A6796EDA2CE93A721E1E31BF98599565349B4F96690A97EF3E7BB9F319EFF004707AAB27E870A27808730CC2D0155A6341D064B3F673235F9C1EC6FE1B90DF3D19AE1C4F258EED2AE0FD7129DEF77000178DB976477BAEFDBA4EC09149048550935D67C3';
        var ssolist = {"qufenqi_account":"\/\/account.qufenqi.com\/union_login","qudian.qufenqi.com":"\/\/qudian.qufenqi.com\/sso\/ssocookie","pay.qufenqi.com":"\/\/pay.qufenqi.com\/sso\/ssocookie","qufenqi.shop":"\/\/www.qufenqi.com\/sso\/ssocookie"};

        var obj = RegistController();
        obj.setTagInfo('error','error');
        obj.setssoinfo(pubkey,ssolist,tarurl);
        obj.loginUrl = "/login?tarurl=http%3A%2F%2Fwww.qufenqi.com";

        $(".send_msg span").on("click",function(){

            var mobile = $("#mobile").val();
            var ismobile = T_isMobileFormatOk(mobile);
    
            if (!ismobile)
            {
                $("#mobileerror").show();
                $("#mobileerror").text('请输入正确的手机号');
                return false;
            }

            obj.checkMobile(mobile);
            $(".send_mbox, .layer_back").fadeIn();
        });

        $(".close, .bt_r").on("click",function(){
            $(".send_mbox, .layer_back").fadeOut();
        });

        $("#submit").removeAttr("disabled");

        $("#refreshimgcode").click(function(){
            var path = '/verify/getimg?type=regiest&r='+Math.random();
            $('#img_code').attr("src",path);
        });

        $("#mobile").blur(function(){
            var mobile = $("#mobile").val();
            obj.checkAccount(mobile,'mobileerror','mobileerror',obj.loginUrl);
        });

        $("#imgcodetext").blur(function(){
            var img_code = $("#imgcodetext").val();
            obj.checkImgCode(img_code,'imgcodeerr','imgcodeerr');
        });

        $("#sendmobilecode").bind("click",function(){
            var img_code = $("#imgcodetext").val();
            var mobile = $("#mobile").val();
            obj.sendRegistMsg(mobile,img_code,'mobilecodeerr','mobilecodeerr');
        });

        $("#btcheckmsg").bind("click",function(){
            var mobile = $("#mobile").val();
            obj.CheckMobileMsg(mobile);
            $("#imgcodetext").val('');
        });

        $("#firstpass").on("input propertychange",function(){   //验证密码强度
            var strongRegex = new RegExp("^(?=.{10,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
            var mediumRegex = new RegExp("^(?=.{9,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))).*$", "g");
            var enoughRegex = new RegExp("(?=.{1,}).*", "g");
            if( false == enoughRegex.test($(this).val()) ){
                $(".passpass, .pwd b.pass_icon").hide();
                $(".passpass i").removeClass("active");
            }
            else if( strongRegex.test($(this).val()) ){
                $(".passpass, .pwd b.pass_icon").show();
                $(".passpass i").addClass("active");
            }else if( mediumRegex.test($(this).val()) ){
                $(".passpass, .pwd b.pass_icon").show();
                $(".passpass i:eq(1)").addClass("active");

            }else{
                $(".passpass").show();
                $(".passpass i").removeClass("active");
                $(".passpass i:eq(0)").addClass("active");
                if(registObj.checkRegistPass($("#firstpass").val())){
                    $(".pwd b.pass_icon").show();
                }else{
                    $(".pwd b.pass_icon").hide();
                }
            }

        })

        $("#secondpass").on("input propertychange",function(){
            var val1 = $("#firstpass").val();
            var val2 = $("#secondpass").val();
            if( val1 !== val2){
                $("#error").show();
                $(".pwd01 b.pass_icon").hide();
                return false;
            }else{
                $("#error").hide();
                $(".pwd01 b.pass_icon").show();
            }
        })

        $(".protocol").click(function(){    //不勾选协议不能提交表单
            var status = $(".protocol input").prop("checked");
            if(status == false){
                $("#submit").css({"background":"#ddd"});
                $("#submit").attr("disabled",true);
            }else{
                $("#submit").css("background","#ff4000");
                $("#submit").removeAttr("disabled");
            }
        })

        $("#submit").click(function(){
            var mobile = $("#mobile").val();
            var mobilecode = $("#mobilecode").val();
            var firstpass = $('#firstpass').val();
            var secondpass = $('#secondpass').val();
            var oriurl = $('#oriurl').val();

            if (false == obj.checkRegiestInfo(mobile,firstpass,secondpass)) return;

            obj.setregistinfo(mobile,mobilecode,firstpass,oriurl);
            obj.regist();
            $(this).attr("disabled",true);
        });

        // 按回车键注册
        $(document).keydown(function(event){
            if(event.keyCode == 13){
                $("#submit").click();
            }
        })