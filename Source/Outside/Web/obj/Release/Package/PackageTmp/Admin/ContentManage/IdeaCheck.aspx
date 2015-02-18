<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/ContentManage/ContentManage.master" AutoEventWireup="true" CodeBehind="IdeaCheck.aspx.cs" Inherits="Suzy.Outside.Web.Admin.ContentManage.IdeaCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
        DataSourceID="SqlDataSource1" EnableModelValidation="True">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                </td>
                <td>
                    <asp:Label ID="ActivityTypeLabel" runat="server" 
                        Text='<%# Eval("ActivityType") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsRealizedCheckBox" runat="server" 
                        Checked='<%# Eval("IsRealized") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="TagLabel" runat="server" Text='<%# Eval("Tag") %>' />
                </td>
                <td>
                    <asp:Label ID="UniversityLabel" runat="server" 
                        Text='<%# Eval("University") %>' />
                </td>
                <td>
                    <asp:Label ID="ScopeLabel" runat="server" Text='<%# Eval("Scope") %>' />
                </td>
                <td>
                    <asp:Label ID="RemarkLabel" runat="server" Text='<%# Eval("Remark") %>' />
                </td>
                <td>
                    <asp:Label ID="CountInterestedLabel" runat="server" 
                        Text='<%# Eval("CountInterested") %>' />
                </td>
                <td>
                    <asp:Label ID="Creator_IDLabel" runat="server" 
                        Text='<%# Eval("Creator_ID") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                </td>
                <td>
                    <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DesTextBox" runat="server" Text='<%# Bind("Des") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ActivityTypeTextBox" runat="server" 
                        Text='<%# Bind("ActivityType") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsRealizedCheckBox" runat="server" 
                        Checked='<%# Bind("IsRealized") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TagTextBox" runat="server" Text='<%# Bind("Tag") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UniversityTextBox" runat="server" 
                        Text='<%# Bind("University") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ScopeTextBox" runat="server" Text='<%# Bind("Scope") %>' />
                </td>
                <td>
                    <asp:TextBox ID="RemarkTextBox" runat="server" Text='<%# Bind("Remark") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CountInterestedTextBox" runat="server" 
                        Text='<%# Bind("CountInterested") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Creator_IDTextBox" runat="server" 
                        Text='<%# Bind("Creator_ID") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>
                        未返回数据。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                </td>
                <td>
                    <asp:TextBox ID="IDTextBox" runat="server" Text='<%# Bind("ID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server" Text='<%# Bind("Title") %>' />
                </td>
                <td>
                    <asp:TextBox ID="DesTextBox" runat="server" Text='<%# Bind("Des") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ActivityTypeTextBox" runat="server" 
                        Text='<%# Bind("ActivityType") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsRealizedCheckBox" runat="server" 
                        Checked='<%# Bind("IsRealized") %>' />
                </td>
                <td>
                    <asp:TextBox ID="TagTextBox" runat="server" Text='<%# Bind("Tag") %>' />
                </td>
                <td>
                    <asp:TextBox ID="UniversityTextBox" runat="server" 
                        Text='<%# Bind("University") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ScopeTextBox" runat="server" Text='<%# Bind("Scope") %>' />
                </td>
                <td>
                    <asp:TextBox ID="RemarkTextBox" runat="server" Text='<%# Bind("Remark") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CountInterestedTextBox" runat="server" 
                        Text='<%# Bind("CountInterested") %>' />
                </td>
                <td>
                    <asp:TextBox ID="Creator_IDTextBox" runat="server" 
                        Text='<%# Bind("Creator_ID") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                </td>
                <td>
                    <asp:Label ID="ActivityTypeLabel" runat="server" 
                        Text='<%# Eval("ActivityType") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsRealizedCheckBox" runat="server" 
                        Checked='<%# Eval("IsRealized") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="TagLabel" runat="server" Text='<%# Eval("Tag") %>' />
                </td>
                <td>
                    <asp:Label ID="UniversityLabel" runat="server" 
                        Text='<%# Eval("University") %>' />
                </td>
                <td>
                    <asp:Label ID="ScopeLabel" runat="server" Text='<%# Eval("Scope") %>' />
                </td>
                <td>
                    <asp:Label ID="RemarkLabel" runat="server" Text='<%# Eval("Remark") %>' />
                </td>
                <td>
                    <asp:Label ID="CountInterestedLabel" runat="server" 
                        Text='<%# Eval("CountInterested") %>' />
                </td>
                <td>
                    <asp:Label ID="Creator_IDLabel" runat="server" 
                        Text='<%# Eval("Creator_ID") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">
                                    ID</th>
                                <th runat="server">
                                    Title</th>
                                <th runat="server">
                                    Des</th>
                                <th runat="server">
                                    ActivityType</th>
                                <th runat="server">
                                    IsRealized</th>
                                <th runat="server">
                                    Tag</th>
                                <th runat="server">
                                    University</th>
                                <th runat="server">
                                    Scope</th>
                                <th runat="server">
                                    Remark</th>
                                <th runat="server">
                                    CountInterested</th>
                                <th runat="server">
                                    Creator_ID</th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                    ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                </td>
                <td>
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                </td>
                <td>
                    <asp:Label ID="DesLabel" runat="server" Text='<%# Eval("Des") %>' />
                </td>
                <td>
                    <asp:Label ID="ActivityTypeLabel" runat="server" 
                        Text='<%# Eval("ActivityType") %>' />
                </td>
                <td>
                    <asp:CheckBox ID="IsRealizedCheckBox" runat="server" 
                        Checked='<%# Eval("IsRealized") %>' Enabled="false" />
                </td>
                <td>
                    <asp:Label ID="TagLabel" runat="server" Text='<%# Eval("Tag") %>' />
                </td>
                <td>
                    <asp:Label ID="UniversityLabel" runat="server" 
                        Text='<%# Eval("University") %>' />
                </td>
                <td>
                    <asp:Label ID="ScopeLabel" runat="server" Text='<%# Eval("Scope") %>' />
                </td>
                <td>
                    <asp:Label ID="RemarkLabel" runat="server" Text='<%# Eval("Remark") %>' />
                </td>
                <td>
                    <asp:Label ID="CountInterestedLabel" runat="server" 
                        Text='<%# Eval("CountInterested") %>' />
                </td>
                <td>
                    <asp:Label ID="Creator_IDLabel" runat="server" 
                        Text='<%# Eval("Creator_ID") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="Data Source=SUZYWU-PC\SUZY;Initial Catalog=OUTSIDE;Persist Security Info=True;User ID=sa;Password=12321" 
        ProviderName="System.Data.SqlClient" 
        SelectCommand="SELECT * FROM [ActivityIdeasSet]"></asp:SqlDataSource>

</asp:Content>
