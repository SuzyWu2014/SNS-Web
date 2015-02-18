<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="AddIdea.aspx.cs" Inherits="Suzy.Outside.Web.Idea.AddIdea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Resource/Scripts/MyJs/University.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/get-act-type.js" type="text/javascript"></script>
    <link href="../Resource/CSS/create.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            setActType("main_t", "sub_t", null);
            GetSchool("proc", "city", "utc");
            $("#submit").button().click(function (event) {

                if ($.trim($("#topic").val()) == "") {
                    $("#errorMsg").text("主题不能为空！");
                    event.preventDefault();
                }
                else if ($.trim($("#des").val()) == "") {
                    $("#errorMsg").text("描述不能为空！");
                    event.preventDefault();
                }
            });
        });
       
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContent">
        <form id="form1" runat="server">
        <h2>
            添加你的想法：</h2>
        <div class="ui-widget">
            <div id="errorDiv" class="ui-state-error ui-corner-all" style="padding: 0 .7em; width: 400px;
                margin: auto auto 10px auto;">
                <p>
                    <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
                    <strong>Alert:</strong>
                    <label id="errorMsg" style="color: #ff0084;">
                        想法描述的越详细，实现的几率也就越大哦~</label></p>
            </div>
        </div>
        <table>
            <tr>
                <td>
                    <label for="topic">
                        主题</label>
                </td>
                <td>
                    <input type="text" name="topic" id="topic" value="" class="txt_2“" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="main_t">
                        类型</label>
                </td>
                <td>
                    <select id="main_t" name="main_t">
                        <option value="none">请选择</option>
                    </select>
                    <select id="sub_t" name="main_t">
                        <option value="none">请选择</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="proc">
                        学校</label>
                </td>
                <td>
                    <select id="proc" name="proc" class="txt">
                        <option value="none">请选择</option>
                    </select>
                    <select id="city" name="city" class="txt">
                        <option value="none">请选择</option>
                    </select>
                    <select id="utc" name="utc" class="txt" style="width: 120px;">
                        <option value="none">请选择</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="scope">
                        范围：</label>
                </td>
                <td>
                    <select id="scope" name="scope">
                        <option value="in">校内</option>
                        <option value="out">校外</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="des">
                        描述</label>
                </td>
                <td>
                    <textarea id="des" name="des" cols="50" rows="10"> </textarea>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="tag">
                        标签</label>
                </td>
                <td>
                    <input type="text" name="tag" id="tag" value="" />
                </td>
            </tr>
            <tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <button id="submit">
                            提交</button>
                    </td>
                </tr>
            </tr>
        </table>
        </form>
    </div>
    <div id="right">
        <h2>
            如何让你的想法得以实现？</h2>
        <ol class="pl">
            <li>具备比较完善具体的构思</li>
            <li>缩小范围以便被邻近的校友看到</li>
            <li>可实现性比较强，指出提供帮助的候选人选</li>
        </ol>
        <p class="pl">
        </p>
        <br />
        <h2>
            如何才能让你的想法更吸引人？</h2>
        <ol class="pl">
            <li>标题简单明了 </li>
            <li>活动内容和特点介绍详细 </li>
        </ol>
        <p class="pl">
            更重要的是，邀请好友们都来参与讨论！
        </p>
    </div>
</asp:Content>
