<%@ Page Title="" Language="C#" MasterPageFile="/Admin/ContentManage/ContentManage.master"
    AutoEventWireup="true" CodeBehind="CheckActivity.aspx.cs" Inherits="Suzy.Outside.Web.Admin.ContentManage.CheckActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div data-options="region:'center',title:'活动审核',iconCls:'icon-ok'">
        <div class="easyui-layout" data-options="fit:true">
            <asp:ListView ID="lv_activityCheck" runat="server" DataKeyNames="ID" EnableViewState="False"
                OnItemCommand="lv_activityCheck_OnItemCommand" DataSourceID="obsActivity" EnableModelValidation="True">
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>
                                没有待审核的活动~
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <input type="checkbox" name="ckb" value='<%# Eval("ID")  %>' id='<%# Eval("ID") %>' />
                        </td>
                        <td>
                            <img src="/Handlers/CreateThumbNail.ashx?wdh=100&url=<%# Eval("PosterPath") %>" alt="Alternate Text" />
                        </td>
                        <td>
                            <asp:Label ID="TopicLabel" runat="server" Text='<%# Eval("Topic") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ActivityTypeLabel" runat="server" Text='<%# Eval("ActivityType") %>' />
                        </td>
                        <td>
                            <%# Eval("University") %>
                            <%# Eval("PlaceType") %><%# Eval("Place") %>
                        </td>
                        <td>
                            <asp:Label ID="AdminAttitudeLabel" runat="server" Text='<%# Eval("AdminAttitude") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DetailLabel" runat="server" Text='<%# Eval("Detail") %>' />
                        </td>
                        <td>
                            <asp:Label ID="TagLabel" runat="server" Text='<%# Eval("Tag") %>' />
                        </td>
                        <td>
                            <a href="/Admin/?uid=<%# Eval("Sponsor_ID") %>">发起人</a>
                        </td>
                        <td>
                            <asp:LinkButton ID="btnPass" CommandName="pass" CommandArgument='<%# Eval("ID")  %>'
                                runat="server">【通过】</asp:LinkButton>
                            <asp:LinkButton ID="btnRefuse" CommandName="refuse" CommandArgument='<%# Eval("ID")  %>'
                                runat="server">【拒绝】</asp:LinkButton>
                            <asp:LinkButton ID="btnRecommended" CommandName="recommend" CommandArgument='<%# Eval("ID")  %>'
                                runat="server">【推荐】</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="0" style="" class="datatable">
                                    <tr runat="server" style="">
                                        <th runat="server">
                                        </th>
                                        <th id="Th1" runat="server">
                                            活动海报
                                        </th>
                                        <th runat="server">
                                            主题
                                        </th>
                                        <th runat="server">
                                            活动类型
                                        </th>
                                        <th runat="server">
                                            活动地点
                                        </th>
                                        <th runat="server">
                                            管理员意见
                                        </th>
                                        <th runat="server">
                                            活动介绍
                                        </th>
                                        <th runat="server">
                                            标签
                                        </th>
                                        <th runat="server">
                                            发起人
                                        </th>
                                        <th id="Th2" runat="server">
                                            操作
                                        </th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:Button ID="btnChecked" runat="server" Text="批量审核" OnClick="btnChecked_Click" />
                                <asp:Button ID="btnRecommend" runat="server" Text="批量推荐" OnClick="btnRecommend_Click" />
                                <asp:Button ID="btnRefuse" runat="server" Text="批量拒绝" OnClick="btnRefuse_Click" />
                                <asp:DataPager ID="dp" runat="server" PageSize="5" PagedControlID="lv_activityCheck"
                                    Visible="true">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <asp:ObjectDataSource ID="obsActivity" runat="server" DataObjectTypeName="Suzy.Outside.Model.Activity"
            EnablePaging="true" MaximumRowsParameterName="pageSize" StartRowIndexParameterName="pageIndex"
            SelectCountMethod="GetUncheckedCount" SelectMethod="GetUnchekedListByPage" TypeName="Suzy.Outside.BLL.ActivityBLL">
        </asp:ObjectDataSource>
    </div>
</asp:Content>
