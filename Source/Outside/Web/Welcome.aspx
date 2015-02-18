<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Welcome.aspx.cs" Inherits="Suzy.Outside.Web.Welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Resource/CSS/welcome.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headTitle">
        在这里，你可以...</div>
    <div class="main">
        <div class="item">
            <div class="img">
                <a href="/index.aspx">
                    <img src="/Resource/Images/Project/activity.jpg" alt="找活动" /></a></div>
            <div>
                <div class="title">
                    <a href="/index.aspx">Find  A Activity</a></div>
                <div class="des">
                    &nbsp;  &nbsp;  &nbsp;  &nbsp;来看看同学们都在参加什么活动吧~总有一款适合你 ^_^
                </div>
            </div>
        </div>
        <div class="item">
            <div class="img">
                <a href="/Activity/AddActivity.aspx" >
                    <img src="/Resource/Images/Project/sponsor.jpg" alt="创建活动" /></a></div>
            <div>
                <div class="title">
                    <a href="/Activity/AddActivity.aspx" >Create A Activity</a></div>
                <div class="des">
                      &nbsp;  &nbsp;   &nbsp;  &nbsp;想找活动盟友？想为你活动宣传造势？来创建你的活动吧~
                </div>
            </div>
        </div>
        <div class="item">
            <div class="img">
                <a href="/Idea/IdeaList.aspx">
                    <img src="/Resource/Images/Project/advise.jpg" alt="说说你的 活动创意" /></a></div>
            <div>
                <div class="title">
                    <a href="/Idea/IdeaList.aspx">Advise A Activity</a></div>
                <div class="des">
                      &nbsp;  &nbsp;   &nbsp;  &nbsp;想了很久的活动却因为势单力薄难以实现？来这里说出你的想法，寻求帮助吧~
                </div>
            </div>
        </div>
    </div>
</asp:Content>
