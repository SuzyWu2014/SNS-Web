<%@ Page Title="" Language="C#" MasterPageFile="~/Master4Other.master" AutoEventWireup="true"
    CodeBehind="Member.aspx.cs" Inherits="Suzy.Outside.Web.Account.Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <link href="/Resource/CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../Resource/CSS/demos.css" rel="stylesheet" type="text/css" />
    <script src="../Resource/Scripts/MyJs/show-activity.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/Scroll.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/get-user.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <div id="mContent">
        <div id="left">
            <div id="selfIntro">
                <div class="section">
                    TA说</div>
                <div class="container">
                    <%=string.IsNullOrEmpty(cmr.IntroSelf) ? "这家伙有点懒，还没填写任何介绍~~╮(╯▽╰)╭~~" : cmr.IntroSelf%></div>
            </div>
            <div>
                <div class="section">
                    TA发起的</div>
                <div id="actLaunch" class="scroll-pane ui-widget ui-widget-header ui-corner-all">
                    <div id="Launch" class="scroll-content">
                    </div>
                    <div class="scroll-bar-wrap ui-widget-content ui-corner-bottom">
                        <div class="scroll-bar">
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="section">
                    TA参加的活动</div>
                <div id="actJoined" class="scroll-pane ui-widget ui-widget-header ui-corner-all">
                    <div id="Joined" class="scroll-content">
                    </div>
                    <div class="scroll-bar-wrap ui-widget-content ui-corner-bottom">
                        <div class="scroll-bar">
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <div class="section">
                    TA感兴趣的</div>
                <div id="actInsterest" class="scroll-pane ui-widget ui-widget-header ui-corner-all">
                    <div id="Insterest" class="scroll-content">
                    </div>
                    <div class="scroll-bar-wrap ui-widget-content ui-corner-bottom">
                        <div class="scroll-bar">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="right">
            <div id="selfFastInfo">
                <div class="section">
                    个人简介</div>
                <img class="portrait" src="<%=string.IsNullOrEmpty(cmr.HeadPortraitPath)?"/Resource/Images/Project/defaultPortrait.JPG":cmr.HeadPortraitPath %>"
                    alt="Alternate Text" />
                    <br /><br />
                <%=string.IsNullOrEmpty(cmr.Nickname) ? "" : "昵称：" + cmr.Nickname + "<br />"%>
                <%=!cmr.IsRealNamePrivate && !string.IsNullOrEmpty(cmr.RealName) ? "真实姓名：" + cmr.RealName  + "<br />":""  %>
                <%="性别："+cmr.Sex +"<br/>" %>
                <%=string.IsNullOrEmpty(cmr.University) ?"": "学校：" + cmr.University + "<br />" %> 
                <%=!cmr.IsCollegePrivate && !string.IsNullOrEmpty(cmr.College) ? "学院：" + cmr.College + "<br />":"" %> 
                <%=!cmr.IsMajorPrivate && !string.IsNullOrEmpty(cmr.Major.Trim()) ? "专业：" + cmr.Major  + "<br />": ""%> 
                <%=!cmr.IsEntraceYearPrivate && !string.IsNullOrEmpty(cmr.EntranceYear) ?"入学年份：" + cmr.EntranceYear + "<br />": "" %> 
                <br />
                <button id="FansIt">
                    关注他</button>
                <button id="UnFans">
                    取消关注</button>
            </div>
            <div id="fans">
                <div class="section">
                    关注TA的</div>
                <div id="fansList" class="Scontainer">
                </div>
            </div>
            <div id="idols">
                <div class="section">
                    TA关注的</div>
                <div id="idolsList" class="Scontainer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            var uid = "<%=cmr.ID %>";
            $("#uid").val(uid);
            //他发起的活动 
            getAct(uid, "Launch", "2", "发起");
            setScroll("actLaunch");
            //他感兴趣的活动
            getAct(uid, "Insterest", "0", "感兴趣的");
            setScroll("actInsterest");
            //他参加的活动 
            getAct(uid, "Joined", "1", "参加任何");
            setScroll("actJoined");
            //他关注的人/ 关注他的人
            getUser(uid, "0", "fansList");
            getUser(uid, "1", "idolsList");
            var ifLogin = "<%=Page.User.Identity.IsAuthenticated %>";
            var fid;
            if (ifLogin.toLowerCase() == "false") {
                $("#UnFans").button().hide();
                $("#FansIt").button().show();
            }
            else {
                fid = "<%=Page.User.Identity.Name %>";
                $.ajax({
                    url: "/Handlers/FansHandler.ashx",
                    data: { idolId: uid, type: "2", fansId: fid },
                    dataType: "text",
                    async: false,
                    success: function (str) {
                        switch (str) {//0:已 1：未
                            case "0":
                                $("#FansIt").button().hide();
                                $("#UnFans").button().show();
                                break;
                            case "1":
                                $("#UnFans").button().hide();
                                $("#FansIt").button().show();
                                break;
                            default: break;
                        }
                    }
                });
            }
            //加关注 
            $("#FansIt").click(function () {
                if (ifLogin.toLowerCase() == "false") {
                    window.location.href = "/Account/Login.aspx?ReturnUrl=" + window.location.href;
                }
                else {
                    $.ajax({
                        url: "/Handlers/FansHandler.ashx",
                        data: { idolId: uid, type: "0", fansId: fid },
                        dataType: "text",
                        success: function (str) {
                            switch (str) {//0:已 1：未
                                case "0":
                                    $("#FansIt").button().hide();
                                    $("#UnFans").button().show();
                                    break;
                                case "1":
                                    $("#UnFans").button().hide();
                                    $("#FansIt").button().show();
                                    break;
                                default: break;
                            }
                        }
                    });
                }
            });

            //取消关注
            $("#UnFans").click(function () {
                $.ajax({
                    url: "/Handlers/FansHandler.ashx",
                    data: { idolId: uid, type: "1", fansId: fid },
                    dataType: "text",
                    success: function (str) {
                        switch (str) {//0:已 1：未
                            case "0":
                                $("#UnFans").button().hide();
                                $("#FansIt").button().show();
                                break;
                            case "1":
                                $("#FansIt").button().hide();
                                $("#UnFans").button().show();
                                break;
                            default: break;
                        }
                    }
                });
            });

        });
    </script>
</asp:Content>
