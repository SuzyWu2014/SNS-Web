<%@ Page Title="" Language="C#" MasterPageFile="~/ContentManager.master" AutoEventWireup="true"
    CodeBehind="CheckActivity.aspx.cs" Inherits="Admin.Outside.ContentManage.CheckActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
  <div data-options="region:'center',title:'活动审核',iconCls:'icon-ok'">
   <div class="easyui-layout" data-options="fit:true">  
            <div data-options="region:'west',split:true" style="width:700px;padding:10px">  
              <asp:ListView ID="lv_activityCheck" runat="server" DataKeyNames="ID"  EnableViewState="false" 
          DataSourceID="obsActivity" GroupItemCount="2">
          
          <EditItemTemplate>
              <td id="Td1" runat="server" style="">
                  ID:
                  <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                  <br />Topic:
                  <asp:TextBox ID="TopicTextBox" runat="server" Text='<%# Bind("Topic") %>' />
                  <br />CreateTime:
                  <asp:TextBox ID="CreateTimeTextBox" runat="server" 
                      Text='<%# Bind("CreateTime") %>' />
                  <br />ActivityType:
                  <asp:TextBox ID="ActivityTypeTextBox" runat="server" 
                      Text='<%# Bind("ActivityType") %>' />
                  <br />TimeDes:
                  <asp:TextBox ID="TimeDesTextBox" runat="server" Text='<%# Bind("TimeDes") %>' />
                  <br />TimeCycle:
                  <asp:TextBox ID="TimeCycleTextBox" runat="server" 
                      Text='<%# Bind("TimeCycle") %>' />
                  <br />PosterPath:
                  <asp:TextBox ID="PosterPathTextBox" runat="server" 
                      Text='<%# Bind("PosterPath") %>' />
                  <br />PlaceType:
                  <asp:TextBox ID="PlaceTypeTextBox" runat="server" 
                      Text='<%# Bind("PlaceType") %>' />
                  <br />University:
                  <asp:TextBox ID="UniversityTextBox" runat="server" 
                      Text='<%# Bind("University") %>' />
                  <br />Place:
                  <asp:TextBox ID="PlaceTextBox" runat="server" Text='<%# Bind("Place") %>' />
                  <br />CountJoin:
                  <asp:TextBox ID="CountJoinTextBox" runat="server" 
                      Text='<%# Bind("CountJoin") %>' />
                  <br />CountRecommend:
                  <asp:TextBox ID="CountRecommendTextBox" runat="server" 
                      Text='<%# Bind("CountRecommend") %>' />
                  <br />CountCollect:
                  <asp:TextBox ID="CountCollectTextBox" runat="server" 
                      Text='<%# Bind("CountCollect") %>' />
                  <br />ActivityStatus:
                  <asp:TextBox ID="ActivityStatusTextBox" runat="server" 
                      Text='<%# Bind("ActivityStatus") %>' />
                  <br />AdminAttitude:
                  <asp:TextBox ID="AdminAttitudeTextBox" runat="server" 
                      Text='<%# Bind("AdminAttitude") %>' />
                  <br />fee:
                  <asp:TextBox ID="feeTextBox" runat="server" Text='<%# Bind("fee") %>' />
                  <br />Detail:
                  <asp:TextBox ID="DetailTextBox" runat="server" Text='<%# Bind("Detail") %>' />
                  <br />Tag:
                  <asp:TextBox ID="TagTextBox" runat="server" Text='<%# Bind("Tag") %>' />
                  <br />ActivityIdeasID:
                  <asp:TextBox ID="ActivityIdeasIDTextBox" runat="server" 
                      Text='<%# Bind("ActivityIdeasID") %>' />
                  <br />Sponsor_ID:
                  <asp:TextBox ID="Sponsor_IDTextBox" runat="server" 
                      Text='<%# Bind("Sponsor_ID") %>' />
                  <br />
                  <asp:CheckBox ID="IsNeedContactCheckBox" runat="server" 
                      Checked='<%# Bind("IsNeedContact") %>' Text="IsNeedContact" />
                  <br />
                  <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                  <br />
                  <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                  <br />
              </td>
          </EditItemTemplate>
          <EmptyDataTemplate>
              <table id="Table1" runat="server" style="">
                  <tr>
                      <td>
                          未返回数据。</td>
                  </tr>
              </table>
          </EmptyDataTemplate>
          <EmptyItemTemplate>
<td id="Td2" runat="server" />
          </EmptyItemTemplate>
          <GroupTemplate>
              <tr ID="itemPlaceholderContainer" runat="server">
                  <td ID="itemPlaceholder" runat="server">
                  </td>
              </tr>
          </GroupTemplate>
           
          <ItemTemplate>
          <div>
              <img   src="<%# Eval("PosterPath") %>" alt="Alternate Text" />
          </div>
              <td id="Td3" runat="server" style="">
                  ID:
                  <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                  <br />Topic:
                  <asp:Label ID="TopicLabel" runat="server" Text='<%# Eval("Topic") %>' />
                  <br />CreateTime:
                  <asp:Label ID="CreateTimeLabel" runat="server" 
                      Text='<%# Eval("CreateTime") %>' />
                  <br />ActivityType:
                  <asp:Label ID="ActivityTypeLabel" runat="server" 
                      Text='<%# Eval("ActivityType") %>' />
                  <br />TimeDes:
                  <asp:Label ID="TimeDesLabel" runat="server" Text='<%# Eval("TimeDes") %>' />
                  <br />TimeCycle:
                  <asp:Label ID="TimeCycleLabel" runat="server" Text='<%# Eval("TimeCycle") %>' />
                  <br />PosterPath:
                  <asp:Label ID="PosterPathLabel" runat="server" 
                      Text= />
                  <br />PlaceType:
                  <asp:Label ID="PlaceTypeLabel" runat="server" Text='<%# Eval("PlaceType") %>' />
                  <br />University:
                  <asp:Label ID="UniversityLabel" runat="server" 
                      Text='<%# Eval("University") %>' />
                  <br />Place:
                  <asp:Label ID="PlaceLabel" runat="server" Text='<%# Eval("Place") %>' />
                  <br />CountJoin:
                  <asp:Label ID="CountJoinLabel" runat="server" Text='<%# Eval("CountJoin") %>' />
                  <br />CountRecommend:
                  <asp:Label ID="CountRecommendLabel" runat="server" 
                      Text='<%# Eval("CountRecommend") %>' />
                  <br />CountCollect:
                  <asp:Label ID="CountCollectLabel" runat="server" 
                      Text='<%# Eval("CountCollect") %>' />
                  <br />ActivityStatus:
                  <asp:Label ID="ActivityStatusLabel" runat="server" 
                      Text='<%# Eval("ActivityStatus") %>' />
                  <br />AdminAttitude:
                  <asp:Label ID="AdminAttitudeLabel" runat="server" 
                      Text='<%# Eval("AdminAttitude") %>' />
                  <br />fee:
                  <asp:Label ID="feeLabel" runat="server" Text='<%# Eval("fee") %>' />
                  <br />Detail:
                  <asp:Label ID="DetailLabel" runat="server" Text='<%# Eval("Detail") %>' />
                  <br />Tag:
                  <asp:Label ID="TagLabel" runat="server" Text='<%# Eval("Tag") %>' />
                  <br />ActivityIdeasID:
                  <asp:Label ID="ActivityIdeasIDLabel" runat="server" 
                      Text='<%# Eval("ActivityIdeasID") %>' />
                  <br />Sponsor_ID:
                  <asp:Label ID="Sponsor_IDLabel" runat="server" 
                      Text='<%# Eval("Sponsor_ID") %>' />
                  <br />
                  <asp:CheckBox ID="IsNeedContactCheckBox" runat="server" 
                      Checked='<%# Eval("IsNeedContact") %>' Enabled="false" Text="IsNeedContact" />
                  <br />
                  <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                  <br />
              </td>
          </ItemTemplate>
          <LayoutTemplate>
              <table id="Table2" runat="server">
                  <tr id="Tr1" runat="server">
                      <td id="Td4" runat="server">
                          <table ID="groupPlaceholderContainer" runat="server" border="0" style="">
                              <tr ID="groupPlaceholder" runat="server">
                              </tr>
                          </table>
                      </td>
                  </tr>
                  <tr id="Tr2" runat="server">
                      <td id="Td5" runat="server" style="">
                          <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                              <Fields>
                                  <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                      ShowLastPageButton="True" />
                              </Fields>
                          </asp:DataPager>
                      </td>
                  </tr>
              </table>
          </LayoutTemplate>
           
      </asp:ListView>
            </div>  
            <div data-options="region:'center'" style="padding:10px">  
                Right Content  
            </div>  
        </div>  
      
      <asp:ObjectDataSource ID="obsActivity" runat="server" 
          DataObjectTypeName="Suzy.Outside.Model.Activity" 
          SelectMethod="GetUncheckedActivity" TypeName="Suzy.Outside.BLL.ActivityBLL" 
          UpdateMethod="Update"></asp:ObjectDataSource>
  </div>
</asp:Content>
