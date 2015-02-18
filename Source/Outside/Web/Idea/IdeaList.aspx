<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="IdeaList.aspx.cs" Inherits="Suzy.Outside.Web.Idea.IdeaList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Resource/CSS/List.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" EnableViewState="false" ID="rptIdea">
        <ItemTemplate>
            <div class="item">
                <a class="title" href="/Idea/IdeaDetail.aspx?id=<%#Eval("ID") %>">
                    <%#Eval("Title") %></a>
                <div class="detail">
                    <%#Eval("Des") %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
