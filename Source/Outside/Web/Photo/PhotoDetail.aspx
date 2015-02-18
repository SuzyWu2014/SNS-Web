<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="PhotoDetail.aspx.cs" Inherits="Suzy.Outside.Web.Photo.PhotoDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Resource/CSS/ptoDetail.css" rel="stylesheet" type="text/css" />
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
                        arr[0] = 1;
                        arr[1] = "<%=Page.User.Identity.Name %>";
                        arr[2] = "<%=pto.ID %>";
                        arr[3] = content;
                        arr[4] = "cmt";
                        arr[5] = "cmtContainer";

                        addCmt(arr);
                    }
                }

            });
            //-------------加载评论--------------------------------
            getCmt(1, "<%=pto.ID %>", "cmtContainer");
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="left">
            <div class="img">
                &nbsp;&nbsp; <a class="lnk" href="javascript:history.go(-1);">&lt;&nbsp;返回</a><br />
                <br />
                <img src="/Handlers/CreateThumbNail.ashx?wdh=500&url=<%=pto.ImageBigPath%>" alt="Alternate Text" /><br />
                上传时间：
                <%=pto.UploadTime %>
                &nbsp;&nbsp; &nbsp;&nbsp; 上传 By:<a href="/Account/Member.aspx?uid=<%=pto.Uploader.ID %>"><%=pto.Uploader.UserName %></a>
                <br />
            </div>
        </div>
        <div class="right">
            <div class="info">
                标题：
                <%=pto.Title %></div>
            <div class="info">
                <%=pto.Activity != null ? (" 所属活动： " + "<a href=\"/Activity/DetailActivity.aspx?id=" + pto.Activity.ID + " \" >" + pto.Activity.Topic + "</a><br/>") : ""%></div>
            <div class="info">
                相册：
                <%=pto.Album!=null?pto.Album.Title:"unKonwn" %></div>
            <div class="info">
                描述：<%=pto.Des %></div>
            <div>
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
        </div>
    </div>
    <div>
    </div>
</asp:Content>
