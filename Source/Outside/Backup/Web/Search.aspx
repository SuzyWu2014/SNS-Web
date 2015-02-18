<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Search.aspx.cs" Inherits="Suzy.Outside.Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Resource/CSS/List.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            $("#txtSearch").val("<%=key %>");
        });
      
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class="title" >搜索结果：</div>
    <asp:Repeater ID="rptAct" runat="server" EnableViewState="false">
        <ItemTemplate>
            <div class="item">
                <div class="title">
                    <a href="/Activity/DetailActivity.aspx?id=<%#Eval("ID") %>">
                        <%#Eval("Topic") %></a></div>
                <div class="detail">
                    <%#Eval("Detail")  %></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater runat="server" ID="rptUser" EnableViewState="false">
        <ItemTemplate>
            <div class="item">
                <div class="title">
                    <a href="/Account/Member.aspx?uid=<%#Eval("ID") %>">
                        <%#Eval("UserName") %></a>
                </div>
                <div class="detail">
                    <%#Eval("IntroSelf") + "<br />"%><%#Eval("University")%></div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
