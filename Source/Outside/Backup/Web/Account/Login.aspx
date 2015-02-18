<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Suzy.Outside.Web.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>登录</title> 
    <link href="../Resource/CSS/login.css" rel="stylesheet" type="text/css" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div id="Tlogin">
        <table>
            <tr>
                <td colspan="2">
                    <span class="Ttitle">请登录：</span>
                    <label id="error">
                    </label>
                </td>
            </tr>
            <tr>
                <td style="width: 80px;">
                    <label for="txtUserName">
                        用户名：</label>
                </td>
                <td>
                    <input id="txtUserName" type="text" class="txt" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="txtPwd">
                        密码：</label>
                </td>
                <td>
                    <input id="txtPwd" type="password" class="txt" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="validateCode">
                        验证码：</label>
                </td>
                <td>
                    <input id="validateCode" type="text" class="txt" style="width: 50%;" />
                    <img alt="" title="点击更换" id="vc" src="/Handlers/ValidateCode.aspx" onclick="changeCode()" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <button id="login">
                        登录</button>&nbsp;&nbsp;
                    <button id="reg">
                        快速注册</button>
                </td>
            </tr>
        </table>
    </div>
    <div id="dialog-form" title="快速注册">
        <p class="validateTips" style=" height:25px;" >
        </p>
        <fieldset>
            <table>
                <tr>
                    <td>
                        <label for="name">
                            用户名：</label>
                    </td>
                    <td>
                        <input type="text" name="name" id="name" class="text ui-widget-content ui-corner-all" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="password">
                            密码：</label>
                    </td>
                    <td>
                        <input type="password" name="password" id="password" class="text ui-widget-content ui-corner-all" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="password2">
                            确认密码：</label>
                    </td>
                    <td>
                        <input type="password" name="password" id="password2" class="text ui-widget-content ui-corner-all" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</asp:Content>
<asp:Content ContentPlaceHolderID="JsCode" runat="server" ID="Content3">
    <script type="text/javascript">
        $(function () {
            clearBanner();
            //登录按钮
            $("#login").button().click(function (event) {
                event.preventDefault();
                var uname = $("#txtUserName").val();
                var pwd = $("#txtPwd").val();
                var code = $("#validateCode").val();

                $.post("/Handlers/Login.ashx", { userName: uname, pwd: pwd, type: 0, Code: code }, function (msg) {
                    // msg -->  0：登录成功  1：用户名不存在  2：密码错误    3：验证码错误
                    switch (msg) {
                        case "0":
                            var url = document.location.href;
                            var host = url.substr(0, url.indexOf("/Account"));
                            if (url.indexOf("ReturnUrl=") > 0) {
                                var returnUrl = url.substr(url.indexOf("ReturnUrl=") + 10);
                                if (returnUrl.search("http://") >= 0) {
                                    document.location.href = returnUrl;
                                }
                                else {
                                    document.location.href = host + decodeURIComponent(returnUrl);
                                }
                            }
                            else {
                                document.location.href = host;
                            }

                            break;
                        case "1":
                            $("#error").text("用户名不存在~");
                            $("#txtPwd").val("");
                            $("#validateCode").val("");
                            changeCode();
                            break;
                        case "2":
                            $("#error").text("密码错误~");
                            $("#txtPwd").val("");
                            $("#validateCode").val("");
                            changeCode();
                            break;
                        case "3":
                            $("#error").text("验证码错误~");
                            $("#txtPwd").val("");
                            $("#validateCode").val("");
                            changeCode();
                            break;
                        default:
                            break;

                    }

                });


            });

            //快速注册
            var name = $("#name"),
      password = $("#password"),
      allFields = $([]).add(name).add(password),
      tips = $(".validateTips");

            function updateTips(t) {
                tips
        .text(t)
        .addClass("ui-state-highlight");
                setTimeout(function () {
                    tips.removeClass("ui-state-highlight", 1500);
                }, 500);
            }
            //验证长度
            function checkLength(o, n, min, max) {
                if (o.val().length > max || o.val().length < min) {
                    o.addClass("ui-state-error");
                    updateTips(n + " 长度必须在" +
          min + " 和 " + max + "之间.");
                    return false;
                } else {
                    return true;
                }
            }
            //验证正则
            function checkRegexp(o, regexp, n) {
                if (!(regexp.test(o.val()))) {
                    o.addClass("ui-state-error");
                    updateTips(n);
                    return false;
                } else {
                    return true;
                }
            }
            //验证用户名是否存在
            function checkUser() {
                var res = false;
                $.get("/Handlers/Login.ashx?type=1&userName=" + name.val(), null, function (msg) {
                    if (msg = "0") {
                        updateTips("用户名可以使用~");
                        res = true;
                    }
                    else {
                        updateTips("用户名已经存在！！");
                        res = false;
                    }

                });
                return res;
            }

            $("#dialog-form").dialog({
                autoOpen: false,
                height: 300,
                width: 400,
                modal: true,
                buttons: {
                    "注册": function () {
                        var bValid = true;
                        allFields.removeClass("ui-state-error");

                        bValid = bValid && checkLength(name, "用户名", 3, 16);
                        bValid = bValid && checkLength(password, "密码", 5, 16);

                        bValid = bValid && checkRegexp(name, /^[a-z]([0-9a-z_ ])+$/i, "用户名必须由字母数字组成，且由字母开头");
                        bValid = bValid && checkRegexp(password, /^([0-9a-zA-Z])+$/, "密码只允许a-z 0-9");

                        // bValid = bValid && checkUser();

                        if (bValid) {
                            //验证通过,注册 
                            var IsSucceed = false;
                            $.ajax({
                                url: "/Handlers/Login.ashx",
                                data: { userName: name.val(), pwd: password.val(), type: 2 },
                                async: false,
                                type: "POST",
                                success: function (msg) {
                                    //    -0：注册成功  1：注册失败  
                                    switch (msg) {
                                        case "0":
                                            IsSucceed = true;
                                            //  $(this).dialog("close");
                                            break;
                                        case "1":
                                            updateTips("注册失败~");
                                            break;
                                        default: break;
                                    }
                                }
                            });

                            if (IsSucceed) {
                                $(this).dialog("close");
                            }
                        }
                    },
                    取消: function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    allFields.val("").removeClass("ui-state-error");
                }
            });

            $("#reg")
         .button()
       .click(function (event) {
           event.preventDefault();
           $("#dialog-form").dialog("open");
       });
        });

        //更换验证码
        function changeCode() {
            var img = $("#vc").attr("src", "/Handlers/ValidateCode.aspx?_=" + Math.random());
        }
    </script>
</asp:Content>
