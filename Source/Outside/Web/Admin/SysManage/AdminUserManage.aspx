﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SysManage/SysManage.master" AutoEventWireup="true" CodeBehind="AdminUserManage.aspx.cs" Inherits="Suzy.Outside.Web.Admin.SysManage.AdminUserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div data-options="region:'center',title:'管理员管理',iconCls:'icon-ok'">
        <asp:ListView ID="lv_admin" EnableViewState="false" runat="server" DataKeyNames="ID"
            OnItemInserting="LVadmin_OnItemInserting"   
            DataSourceID="odsAdmin" InsertItemPosition="LastItem">
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:TextBox ID="AdminTextBox" runat="server" Text='<%# Bind("Admin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="RealNameTextBox" runat="server" Text='<%# Bind("RealName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TelTextBox" runat="server" Text='<%# Bind("Tel") %>' />
                    </td>
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table id="Table1" runat="server" style="">
                    <tr>
                        <td>
                            未返回数据。
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:TextBox ID="AdminTextBox" runat="server" Text='<%# Bind("Admin") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="RealNameTextBox" runat="server" Text='<%# Bind("RealName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="TelTextBox" runat="server" Text='<%# Bind("Tel") %>' />
                    </td>
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="AdminLabel" runat="server" Text='<%# Eval("Admin") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RealNameLabel" runat="server" Text='<%# Eval("RealName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TelLabel" runat="server" Text='<%# Eval("Tel") %>' />
                    </td>
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer" runat="server" border="0" style="" class="datatable">
                    <tr id="Tr1" runat="server" style="">
                        <th id="Th1" runat="server">
                            登录名
                        </th>
                        <th id="Th2" runat="server">
                            密码
                        </th>
                        <th id="Th3" runat="server">
                            真实姓名
                        </th>
                        <th id="Th4" runat="server">
                            Email
                        </th>
                        <th id="Th5" runat="server">
                            Tel
                        </th>
                        <th id="Th6" runat="server">
                            操作
                        </th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="odsAdmin" runat="server" DataObjectTypeName="Suzy.Outside.Model.Administrator"
            DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetAllList" TypeName="Suzy.Outside.BLL.AdministratorBLL"
            UpdateMethod="Update"></asp:ObjectDataSource>
    </div>
</asp:Content>
