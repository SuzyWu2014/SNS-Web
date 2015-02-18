<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="IdeaDetail.aspx.cs" Inherits="Suzy.Outside.Web.Idea.IdeaDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Resource/CSS/idea.css" rel="stylesheet" type="text/css" />
    <link href="../Resource/CSS/cmt.css" rel="stylesheet" type="text/css" />
    <script src="../Resource/Scripts/MyJs/cmt.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            //------------添加评论---------------------------------
            var ifLogin = "<%=Page.User.Identity.IsAuthenticated %>";
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
                        arr[0] = 2;
                        arr[1] = "<%=Page.User.Identity.Name %>";
                        arr[2] = "<%=idea.ID %>";
                        arr[3] = content;
                        arr[4] = "cmt";
                        arr[5] = "cmtContainer";

                        addCmt(arr);
                    }
                }

            });
            //-------------加载评论--------------------------------
            getCmt(2, "<%=idea.ID %>", "cmtContainer");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="left">
        <div class="title">
            Idea 详情
        </div>
        <div>
            <a class="info lnk " href="/Idea/IdeaList.aspx">&lt;&nbsp;返回</a><br />
            <br />
        </div>
        <div class="info">
            主题：
            <%=idea.Title %></div>
        <div class="info">
            创建者：<a class="lnk" href="/Account/Member.aspx?uid=<%=idea.Creator.ID %>">
                <%=idea.Creator.UserName %></a></div>
        <div class="info">
            学校归属：
            <%=idea.University %></div>
        <div class="info">
            范围：
            <%=idea.Scope=="in"?"校内":"校外" %></div>
        <div class="info">
            类型：
            <%=idea.ActivityType %></div>
        <div class="info">
            <label class="num">
                <%=idea.CountInterested %></label>
            人感兴趣
            <%=idea.IsRealized?"已实现":"有待实现" %>
            &nbsp;&nbsp; <a class="lnk" href="/Activity/AddActivity.aspx?ideaId=<%=idea.ID %>">我来实现</a>
        </div>
        <div class="info">
            描述：<%=idea.Des %></div>
    </div>
    <div id="right">
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
</asp:Content>
