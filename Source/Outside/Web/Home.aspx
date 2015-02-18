<%@ Page Title="" Language="C#" MasterPageFile="~/Mater4Self.master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="Suzy.Outside.Web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Resource/CSS/common.css" rel="stylesheet" type="text/css" />
    <script src="Resource/Scripts/MyJs/show-activity.js" type="text/javascript"></script>
    <script src="Resource/Scripts/MyJs/Scroll.js" type="text/javascript"></script>
    <script src="Resource/Scripts/MyJs/get-user.js" type="text/javascript"></script>
    <link href="Resource/CSS/demos.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server"> 
    <div id="mContent">
        <div id="left">
            <div id="selfIntro">
                <div class="section">
                    Wo说</div>
                <div class="container">
                    <%=string.IsNullOrEmpty(cmr.IntroSelf) ? "来写点什么吧~~╮(╯▽╰)╭~~" : cmr.IntroSelf%></div>
            </div>
            <div>
                <div class="section">
                    Wo发起的</div>
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
                    Wo参加的活动</div>
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
                    Wo感兴趣的</div>
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
                    alt="portrait" /><br /><br />
                <%=string.IsNullOrEmpty(cmr.Nickname) ? "" : "昵称：" + cmr.Nickname + "<br />"%>
                <%=string.IsNullOrEmpty(cmr.RealName) ? "" : "真实姓名：" + cmr.RealName + (cmr.IsRealNamePrivate ? "   仅自己可见" : "所有人可见") + "<br />"%>
                <%="性别："+cmr.Sex +"<br/>" %>
                <%=string.IsNullOrEmpty(cmr.University) ? "" : "学校：" + cmr.University + "<br />"%> 
                <%=string.IsNullOrEmpty(cmr.College) ? "" : "学院：" + cmr.College + (cmr.IsCollegePrivate ? "   仅自己可见" : "所有人可见") + "<br />"%> 
                <%=string.IsNullOrEmpty(cmr.Major) ? "" : "专业：" + cmr.Major + (cmr.IsMajorPrivate ? "   仅自己可见" : "所有人可见") + "<br />"%> 
                <%=string.IsNullOrEmpty(cmr.EntranceYear) ? "" : "入学年份：" + cmr.EntranceYear + (cmr.IsEntraceYearPrivate ? "   仅自己可见" : "所有人可见") + "<br />"%> 
            </div>
            <div class="section" >
                <a   href="/Activity/AddActivity.aspx">发布新活动 ></a><br /><br />
                <a   href="/Idea/AddIdea.aspx">提出新想法 ></a><br /><br />
                 <a   href="/Idea/IdeaList.aspx">看看大家的构想 ></a>
            </div>
            <div id="fans">
                <div class="section">
                    关注Wo的</div>
                <div id="fansList" class="Scontainer">
                </div>
            </div>
            <div id="idols">
                <div class="section">
                    Wo关注的</div>
                <div id="idolsList" class="Scontainer">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            var uid = "<%=Page.User.Identity.Name %>";

            var uid = "<%=cmr.ID %>";
            $("#uName").val("<%=cmr.UserName %>");
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


        });
    
    </script>
</asp:Content>
