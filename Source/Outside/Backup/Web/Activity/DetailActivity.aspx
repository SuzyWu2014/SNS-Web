<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="DetailActivity.aspx.cs" Inherits="Suzy.Outside.Web.Activity.DetailActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Resource/CSS/detail4act.css" rel="stylesheet" type="text/css" />
    <link href="../Resource/CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../Resource/CSS/cmt.css" rel="stylesheet" type="text/css" />
    <script src="../Resource/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/get-user.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/photoWall.js" type="text/javascript"></script>
    <link href="../Resource/CSS/pto.css" rel="stylesheet" type="text/css" />
    <script src="../Resource/Scripts/MyJs/cmt.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="left">
            <div class="introWrap">
                <div class="poster">
                    <img src="/Handlers/CreateThumbNail.ashx?url=<%= act.PosterPath%>&wdh=220" alt="<%=act.Topic %>" />
                </div>
                <div class="intro">
                    <div id="topic">
                        <%=act.Topic %></div>
                    <div id="timeDes">
                        <div class="header">
                            时间：</div>
                        <%=act.TimeDes %>
                    </div>
                    <div id="fee">
                        <div class="header">
                            费用：</div>
                        <%=act.fee==0?"免费":act.fee.ToString() %>
                    </div>
                    <div id="sponsor">
                        <div class="header">
                            发起人：</div>
                        <a href="../Account/Member.aspx?uid=<%=act.Sponsor.ID %>">
                            <%=act.Sponsor.UserName %></a>
                    </div>
                    <div id="actType">
                        <div class="header">
                            活动类型：</div>
                        <% =act.ActivityType %>
                    </div>
                    <div id="place">
                        <div class="header">
                            活动地点：</div>
                        <%=act.University %>
                        <%=act.PlaceType %><br />
                    </div>
                    <div id="dp">
                        <div class="header">
                            详细地址：</div>
                        <%=act.Place %></div>
                    <div id="count">
                        <label id="join">
                            <%=act.CountJoin %></label>
                        人参加 &nbsp;
                        <label id="intd">
                            <%=act.CountCollect %></label>
                        人感兴趣
                    </div>
                    <div class="btn">
                        <button id="btnJoined">
                            我要参加</button>
                        <button id="btnUnJoin">
                            不参加了</button>&nbsp;&nbsp;&nbsp;
                        <button id="btnInsterested">
                            我感兴趣</button>
                        <button id="btnUnInsterested">
                            不感兴趣了</button>
                    </div>
                </div>
            </div>
            <div class="detail">
                <div class="section">
                    活动详请
                </div>
                <div class="container">
                    <%=act.Detail %>
                </div>
            </div>
            <div class="ptos">
                <div class="section">
                    活动照片
                </div>
                <div id="ptoContainer" class="container">
                </div>
            </div>
            <div class="cmts">
                <div class="section">
                    评论区
                </div>
                <div id="cmtContainer" class="container">
                </div>
                <div>
                    <textarea cols="60" rows="5" id="cmt"> </textarea>
                    <button id="addCmt">
                        发言</button>
                </div>
            </div>
        </div>
        <div id="right">
            <div id="joined">
                <div class="section">
                    他们参加此活动
                </div>
                <div id="joinUser" class="Scontainer">
                </div>
            </div>
            <div id="insterested">
                <div class="section">
                    他们也对此活动感兴趣
                </div>
                <div id="insUser" class="Scontainer">
                </div>
            </div>
        </div>
        <div id="dialog-form" title="请填写联系方式">
            <p class="validateTips">
            </p>
            <fieldset>
                <table>
                    <tr>
                        <td>
                            <label for="email">
                                Email：</label>
                        </td>
                        <td>
                            <input type="text" name="email" id="email" class="text ui-widget-content ui-corner-all" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="tel">
                                Tel：</label>
                        </td>
                        <td>
                            <input type="text" name="tel" id="tel" class="text ui-widget-content
    ui-corner-all" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="JsCode" runat="server" ID="content3">
    <script type="text/javascript">
        $(function () {
            var ifLogin = "<%=Page.User.Identity.IsAuthenticated %>";
            if (ifLogin.toLowerCase() == "false") {
                $("#btnUnJoin").button().hide();
                $("#btnJoined").button().show();
                $("#btnInsterested").button().show();
                $("#btnUnInsterested").button().hide();
            }
            else {
                $.ajax({
                    url: "/Handlers/CheckJoin.ashx",
                    data: { actId: "<%=act.ID %>" },
                    dataType: "text",
                    async: false,
                    success: function (str) {
                        switch (str) {//0:已 1：未
                            case "00":
                                $("#btnUnJoin").button().show();
                                $("#btnJoined").button().hide();
                                $("#btnInsterested").button().hide();
                                $("#btnUnInsterested").button().show();
                                break;
                            case "01":
                                $("#btnUnJoin").button().show();
                                $("#btnJoined").button().hide();
                                $("#btnInsterested").button().show();
                                $("#btnUnInsterested").button().hide();
                                break;
                            case "10":
                                $("#btnInsterested").button().hide();
                                $("#btnUnInsterested").button().show();
                                $("#btnUnJoin").button().hide();
                                $("#btnJoined").button().show();
                                break;
                            case "11":
                                $("#btnUnJoin").button().hide();
                                $("#btnJoined").button().show();
                                $("#btnInsterested").button().show();
                                $("#btnUnInsterested").button().hide();
                                break;
                            default: break;
                        }
                    }
                });
            }

            var email = $("#email"),
      tel = $("#tel"),
      allFields = $([]).add(email).add(tel),
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
            $("#dialog-form").dialog({
                autoOpen: false,
                height: 300,
                width: 400,
                modal: true,
                buttons: {
                    "提交": function () {
                        var bValid = true;
                        allFields.removeClass("ui-state-error");

                        //  bValid = bValid && checkLength(tel, "电话号码", 11, 12);
                        bValid = bValid && checkLength(email, "email", 6, 80);

                        bValid = bValid && checkRegexp(tel, /^\d{11}|\d{12}$/i, "电话号码必须由数字组成，固话12位（区号+电话号码），手机号11位");

                        bValid = bValid && checkRegexp(email, /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i, "eg. ui@jquery.com");

                        // bValid = bValid && checkUser();

                        if (bValid) {
                            //验证通过,提交
                            $.ajax({
                                url: "/Handlers/UpdateParticipator.ashx",
                                data: { type: "00", actId: "<%=act.ID %>", pId: "<%=act.Sponsor.ID %>", email: email.val(), tel: tel.val() },
                                dataType: "text",
                                success: function (data) {
                                    if (data == "0") {
                                        var num = parseInt($("#join").text()) + 1;
                                        $("#join").text(num);
                                        $("#btnJoined").hide();
                                        $("#btnUnJoin").show();
                                        $("#dialog-form").dialog("close");
                                    } else { }
                                }
                            });
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
            $("#btnJoined").click(function () {
                //1：判断是否登录、需要填写联系方式

                if (ifLogin.toLowerCase() == "false") {
                    window.location.href = "/Account/Login.aspx?ReturnUrl=" + window.location.href;
                }
                var ifContact = "<%=act.IsNeedContact %>";
                if (ifContact.toLowerCase() == "true") {
                    //需要填写联系方式
                    $("#dialog-form").dialog("open");
                }
                else {
                    $.ajax({
                        url: "/Handlers/UpdateParticipator.ashx",
                        data: { type: "00", actId: "<%=act.ID %>" },
                        dataType: "text",
                        success: function (data) {
                            if (data == "0") {
                                var num = parseInt($("#join").text()) + 1;
                                $("#join").text(num);
                                $("#btnJoined").hide();
                                $("#btnUnJoin").show();
                            } else { }
                        }
                    });
                }
            });
            $("#btnUnJoin").click(function () {
                $.ajax({
                    url: "/Handlers/UpdateParticipator.ashx",
                    data: { type: "01", actId: "<%=act.ID %>", pId: "<%=act.Sponsor.ID %>" },
                    dataType: "text",
                    success: function (d) {
                        if (d == "0") {
                            var nj = parseInt($("#join").text()) - 1;
                            $("#join").text(nj);
                            $("#btnJoined").show();
                            $("#btnUnJoin").hide();
                        }
                        else
                        { }
                    }
                });
            });
            $("#btnInsterested").click(function () {
                $.ajax({
                    url: "/Handlers/UpdateParticipator.ashx",
                    data: { type: "10", actId: "<%=act.ID %>", pId: "<%=act.Sponsor.ID %>" },
                    dataType: "text",
                    success: function (data) {
                        if (data == "0") {
                            var num = parseInt($("#intd").text()) + 1;
                            $("#intd").text(num);
                            $("#btnInsterested").hide();
                            $("#btnUnInsterested").show();
                        } else { }
                    }
                });
            });
            $("#btnUnInsterested").click(function () {
                $.ajax({
                    url: "/Handlers/UpdateParticipator.ashx",
                    data: { type: "11", actId: "<%=act.ID %>", pId: "<%=act.Sponsor.ID %>" },
                    dataType: "text",
                    success: function (data) {
                        if (data == "0") {
                            var num = parseInt($("#intd").text()) - 1;
                            $("#intd").text(num);
                            $("#btnInsterested").show();
                            $("#btnUnInsterested").hide();
                        } else { }
                    }
                });
            });


            getActPto("ptoContainer", "<%=act.ID %>");
            getUser("<%=act.ID %>", "2", "joinUser");
            getUser("<%=act.ID %>", "3", "insUser");

            //------------添加评论---------------------------------
            $("#addCmt").button().click(function () {
                if (ifLogin.toLowerCase() == "false") {
                    alert("请登录后评论~~");
                }
                else {
                    var content = $("#cmt").val();
                    if ($.trim(content) == "") {
                        alert("评论内容不能为空哦~~");
                    }
                    else {
                        var arr = new Array();
                        //type,uid,oid,content,cid->文本框，containerId->评论展示区
                        arr[0] = 0;
                        arr[1] = "<%=Page.User.Identity.Name %>";
                        arr[2] = "<%=act.ID %>";
                        arr[3] = content;
                        arr[4] = "cmt";
                        arr[5] = "cmtContainer";

                        addCmt(arr);
                    }
                }

            });
            //-------------加载评论--------------------------------
            getCmt(0, "<%=act.ID %>", "cmtContainer");

        });
    </script>
</asp:Content>
