<%@ Page Title="" Language="C#" MasterPageFile="~/Mater4Self.master" AutoEventWireup="true"
    CodeBehind="SelfPhotoWall.aspx.cs" Inherits="Suzy.Outside.Web.Photo.SelfPhotoWall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Resource/Scripts/MyJs/photoWall.js" type="text/javascript"></script>
    <script src="/Resource/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/Album.js" type="text/javascript"></script>
    <link href="/Resource/CSS/pto.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            var uid = "<%=Page.User.Identity.Name %>";
            GetAllPto("container", uid);
            GetAlbumList(uid, "albumList");
            $("#btnSearch").button().click(function () {
                $("#container").empty();
                getAlbumlPto("container", uid, $("#albumList").val());
                $('#container').masonry('reload');
            }); ;
            $("#btnUpload").button().click(function () {
                window.location.href = "/Photo/UploadPhotos.aspx";
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="options">
        相片集&nbsp;&nbsp;<select id="albumList">
            <option value="all">所有相片</option>
        </select>
        <button id="btnSearch">
            确定</button>&nbsp;&nbsp;
        <button id="btnUpload">
            上传照片</button>
    </div>
    <div>
        <div id="container">
        </div>
    </div>
</asp:Content>
