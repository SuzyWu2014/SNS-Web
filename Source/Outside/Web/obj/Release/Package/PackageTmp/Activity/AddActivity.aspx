<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="AddActivity.aspx.cs" Inherits="Suzy.Outside.Web.Activity.AddActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>发布活动</title> 
    <script src="../Resource/Scripts/jquery.mousewheel.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/globalize.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/globalize.culture.de-DE.js" type="text/javascript"></script> 
    <script src="../Resource/Scripts/jquery.ui.spinner.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/swfupload.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/handlers.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/University.js" type="text/javascript"></script> 
    <script src="../Resource/Scripts/MyJs/get-act-type.js" type="text/javascript"></script>
    <link href="../Resource/CSS/create.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainContent">
        <h1>
            活动发布</h1>
        <h3>
            1. 填写活动信息 > 2. 上传活动海报 > 3. 提交活动</h3>
        <form id="form1" runat="server">
        <input type="hidden" id="actID" runat="server" />
        <div id="tep1">
            <div class="ui-widget">
                <div id="errorDiv" class="ui-state-error ui-corner-all" style="padding: 0 .7em ; width: 400px; margin :auto auto 10px auto;">
                    <p>
                        <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span>
                        <strong>Alert:</strong>
                        <label id="errorMsg" style="color: #ff0084;">
                            请认真填写以下表单，所有信息都是必须的</label></p>
                </div>
            </div>
            <table>
                <tr>
                    <td>
                        <label for="activityType">
                            活动分类
                        </label>
                    </td>
                    <td>
                        <select name="activityType" id="activityType" runat="server" class="txt">
                            <option value="none" runat="server">请选择</option>
                        </select>
                        <select id="subType" style="visibility: hidden" runat="server" class="txt">
                            <option value="none">请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtTiTle">
                            活动标题
                        </label>
                    </td>
                    <td>
                        <input type="text" id="txtTitle" runat="server" class="txt_2" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="Cycle">
                            活动时间
                        </label>
                    </td>
                    <td>
                        <select id="Cycle" runat="server" class="txt">
                            <option value="当天结束">当天结束</option>
                            <option value="连续多天">连续多天</option>
                            <option value="每周举行">每周举行</option>
                            <%-- <option value="自定义">自定义</option>--%>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div id="oneday" class="time">
                            <input type="text" id="date" class="date txt" value="活动日期" runat="server" />
                            <input type="text" id="timeBegin" value="开始时间" class="time1 txt" runat="server" readonly="readonly"
                                title="也可以使用page up/down 调整小时，↑↓调整分钟" />
                            至
                            <input type="text" id="timeEnd" value="结束时间" class="time2 txt" runat="server" readonly="readonly"
                                title="也可以使用page up/down 调整小时，↑↓调整分钟" />
                        </div>
                        <div id="manyday" class="time">
                            <table>
                                <tr>
                                    <td>
                                        起止日期
                                    </td>
                                    <td>
                                        <input type="text" id="date01" class="date txt " runat="server" />至
                                        <input type="text" id="date02" class="date txt" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        活动时间
                                    </td>
                                    <td>
                                        <input type="text" id="time01" value="开始时间" class="time1 txt" runat="server" readonly="readonly"
                                            title="也可以使用page up/down 调整小时，↑↓调整分钟" />至
                                        <input type="text" id="time02" value="结束时间" class="time2 txt" runat="server" readonly="readonly"
                                            title="也可以使用page up/down 调整小时，↑↓调整分钟" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        活动描述
                                    </td>
                                    <td id="timeDes1">
                                        <label id='d1'>
                                        </label>
                                        <label id='d2'>
                                        </label>
                                        <label id='t1'>
                                        </label>
                                        <label id='t2'>
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="week" class="time">
                            <table>
                                <tr>
                                    <td>
                                        活动频率
                                    </td>
                                    <td>
                                        一
                                    </td>
                                    <td>
                                        二
                                    </td>
                                    <td>
                                        三
                                    </td>
                                    <td>
                                        四
                                    </td>
                                    <td>
                                        五
                                    </td>
                                    <td>
                                        六
                                    </td>
                                    <td>
                                        日
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <input id="c1" type="checkbox" name="wk" value="一" />
                                    </td>
                                    <td>
                                        <input id="c2" type="checkbox" name="wk" value="二" />
                                    </td>
                                    <td>
                                        <input id="c3" type="checkbox" name="wk" value="三" />
                                    </td>
                                    <td>
                                        <input id="c4" type="checkbox" name="wk" value="四" />
                                    </td>
                                    <td>
                                        <input id="c5" type="checkbox" name="wk" value="五" />
                                    </td>
                                    <td>
                                        <input id="c6" type="checkbox" name="wk" value="六" />
                                    </td>
                                    <td>
                                        <input id="c7" type="checkbox" name="wk" value="日" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        起止日期
                                    </td>
                                    <td colspan="7">
                                        <input type="text" id="date11" class="date txt" runat="server" />至
                                        <input type="text" id="date12" class="date txt" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        活动时间
                                    </td>
                                    <td colspan="7">
                                        <input type="text" id="time11" value="开始时间" class="time1 txt" runat="server" readonly="readonly"
                                            title="也可以使用page up/down 调整小时，↑↓调整分钟" />至
                                        <input type="text" id="time12" value="结束时间" class="time2 txt" runat="server" readonly="readonly"
                                            title="也可以使用page up/down 调整小时，↑↓调整分钟" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        活动描述
                                    </td>
                                    <td colspan="7" id="timeDes2">
                                        <label id="d11">
                                        </label>
                                        <label id="d12">
                                        </label>
                                        <label id="w" runat="server">
                                        </label>
                                        <label id="t11">
                                        </label>
                                        <label id="t12">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <%--<div id="custom">
                        <table>
                            <tr>
                                <td>
                                    举办时间
                                </td>
                                <td>
                                    <input type="text" id="date21" class="date" value="活动日期" runat="server" />
                                    <input type="text" id="time21" value="开始时间" class="time1" runat="server" readonly="readonly" />
                                    至
                                    <input type="text" id="time22" value="结束时间" class="time2" runat="server" readonly="readonly" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <input type="text" id="date22" class="date" value="活动日期" runat="server" />
                                    <input type="text" id="time31" value="开始时间" class="time1" runat="server" readonly="readonly" />
                                    至
                                    <input type="text" id="time32" value="结束时间" class="time2" runat="server" readonly="readonly" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    活动描述
                                </td>
                                <td id="timeDes3">
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="place">
                            所属学校
                        </label>
                    </td>
                    <td>
                        <select id="proc" runat="server" class="txt">
                            <option value="none">请选择</option>
                        </select>
                        <select id="city" runat="server" class="txt">
                            <option value="none">请选择</option>
                        </select>
                        <select id="utc" runat="server" class="txt" style=" width:120px;" >
                            <option value="none">请选择</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="pType">
                            活动地点
                        </label>
                    </td>
                    <td>
                        <select runat="server" id="pType" class="txt">
                            <option value="校内">校内</option>
                            <option value="校外">校外</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input type="text" id="place" runat="server" class="txt_2" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtDetail">
                            活动详情
                        </label>
                    </td>
                    <td>
                        <textarea id="txtDetail" cols="60" rows="8" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtfee">
                            活动费用
                        </label>
                    </td>
                    <td>
                        <input id="rdFree" type="radio" name="fee" checked="true" runat="server" /><label
                            for="<%=rdFree.ClientID %>">
                            免费
                        </label>
                        <input id="rdFee" type="radio" name="fee" runat="server" /><label for="<%=rdFee.ClientID %>">
                            收费</label>
                        <span id="divFee">
                            <input id="txtFee" type="text" runat="server" title="请输入数字" class="txt" />&nbsp;元</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="Txtpermission">
                            参加权限
                        </label>
                    </td>
                    <td>
                        <input id="rdAll" type="radio" name="pmt" checked="true" runat="server" /><label
                            for="<%=rdAll.ClientID %>">
                            没有限制</label>
                        <input id="rd" type="radio" name="pmt" runat="server" /><label for="<%=rd.ClientID %>">
                            需要提交联系方式（Email+Tel）</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="txtTag">
                            活动标签
                        </label>
                    </td>
                    <td>
                        <input type="text" id="txtTag" runat="server"  class="txt_2" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="tep2">
            <label for="poster">
                上传活动海报
            </label>
            <div id="swfu_container" style="margin: 10px 10px;">
                <div>
                    <span id="spanButtonPlaceholder"></span>
                </div>
                <div id="divFileProgressContainer"  class="ui-icon-folder-open"  style="height: 50px;" >
                </div>
            </div>
            <input type="hidden" id="img" name="img" />
            <img id="imgSrc" runat="server" src="" alt="" width="400" />
        </div>
        <div  id="bts">
            <button id="next">
                下一步，上传活动海报</button>
            <input type="submit" id="ok" value="提交活动" />
            <button id="cancel">
                取消</button>
        </div>
        </form>
    </div>
    <div id="right">
        <h2>
            什么是合适的校园活动？</h2>
        <ol class="pl">
            <li>有能最终确定的活动起止日期</li>
            <li>具备现实中能集体参与的活动地点</li>
            <li>是多人在现实中能碰面的活动</li>
        </ol>
        <p class="pl">
        </p>
        <br />
        <h2>
            如何才能让你的活动更吸引人？</h2>
        <ol class="pl">
            <li>标题简单明了 </li>
            <li>活动内容和特点介绍详细 </li>
            <li>活动海报吸引人眼球 </li>
        </ol>
        <p class="pl">
            更重要的是，邀请好友们都来参与！
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">


        //---------------------------------------------------图片上传---------------------------------------
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/Handlers/Upload.ashx?actId=" + $("#" + "<%=actID.ClientID %>").val(),
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },

                // File Upload Settings
                file_size_limit: "2 MB",
                file_types: "*.jpg;*.gif;*.png;jepg",
                file_types_description: "JPG Images",
                file_upload_limit: 0,    // Zero means unlimited

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler: preLoad,
                swfupload_load_failed_handler: loadFailed,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: ShowImg,
                upload_complete_handler: uploadComplete,

                // Button settings   
                button_image_url: "/Resource/SWFUpload_v250/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">选择图片 <span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 12pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // Flash Settings
                flash_url: "/Resource/SWFUpload_v250/swfupload.swf", // Relative to this file
                flash9_url: "/Resource/SWFUpload_v250/swfupload_FP9.swf", // Relative to this file

                custom_settings: {
                    upload_target: "divFileProgressContainer"
                },

                // Debug Settings
                debug: false
            });
        }

        $(function () {
            $("#" + "<%=actID.ClientID %>").val("<%=Maticsoft.Common.Assistant.GetID() %>");

            //-----------活动类别设定---------------------------------------------
            setActType("<%=activityType.ClientID %>", "<%=subType.ClientID %>", "errorMsg"); 
            //------------活动地点---------- 
            GetSchool('<%=proc.ClientID %>', '<%=city.ClientID %>', '<%=utc.ClientID %>');  
            //--------------------活动时间设定---------------------------------- 
            $("#oneday").show();
            $("#manyday").hide();
            $("#week").hide();
            $("#custom").hide();
            $("#" + '<%=Cycle.ClientID%>').change(function () {
                var cycle = $("#" + '<%=Cycle.ClientID%>').val();
                switch (cycle) {
                    case "当天结束":
                        $("#oneday").show();
                        $("#manyday").hide();
                        $("#week").hide();
                        // $("#custom").hide();
                        break;
                    case "连续多天":
                        $("#oneday").hide();
                        $("#manyday").show();
                        $("#week").hide();
                        //$("#custom").hide();
                        break;
                    case "每周举行":
                        $("#oneday").hide();
                        $("#manyday").hide();
                        $("#week").show();
                        // $("#custom").hide();
                        break;
                    default:
                        $("#oneday").hide();
                        $("#manyday").hide();
                        $("#week").hide();
                        // $("#custom").show();
                        break;

                }
            });

            Globalize.culture("de-DE");
            $(".time1").timespinner();
            $(".time1").val("开始时间").focusin(clearText).tooltip({
                show: null,
                position: {
                    my: "left top",
                    at: "left bottom"
                },
                open: function (event, ui) {
                    ui.tooltip.animate({ top: ui.tooltip.position().top + 10 }, "fast");
                }
            });
            $(".time2").timespinner();
            $(".time2").val("结束时间").focusin(clearText).tooltip({
                show: null,
                position: {
                    my: "left top",
                    at: "left bottom"
                },
                open: function (event, ui) {
                    ui.tooltip.animate({ top: ui.tooltip.position().top + 10 }, "fast");
                }
            });
            $(".date").datepicker();
            $(".date").datepicker("option", "dateFormat", "mm/dd/yy");
            $("#" + '<%=date.ClientID %>').val("活动日期").focusin(clearText);
            //   $("#" + ' ').val("活动日期").focusin(clearText);=date21.ClientID 
            //   $("#" + '').val("活动日期").focusin(clearText);=date22.ClientID 

            function clearText() { $(this).val(" "); }
            //-------------------------------------生成活动时间描述--------------------------------- 

            //---------------连续多天----------------------------------------
            $("#" + '<%=date01.ClientID %>').change(function () {
                $("#d1").text($("#" + '<%=date01.ClientID %>').val() + " 至 ");
            });
            $("#" + '<%=date02.ClientID %>').change(function () {
                $("#d2").text($("#" + '<%=date02.ClientID %>').val() + " 每天 ");
            });
            $("#" + '<%=time01.ClientID %>').blur(function () {
                $("#t1").text($("#" + '<%=time01.ClientID %>').val() + " 至 ");
            });
            $("#" + '<%=time02.ClientID %>').blur(function () {
                $("#t2").text($("#" + '<%=time02.ClientID %>').val());
            });

            //------------------每周举行---------------------------------
            $("#" + '<%=w.ClientID %>').hide();
            $("#" + '<%=date11.ClientID %>').change(function () {
                $("#d11").text($("#" + '<%=date11.ClientID %>').val() + " 至 ");
            });
            $("#" + '<%=date12.ClientID %>').change(function () {
                $("#d12").text($("#" + '<%=date12.ClientID %>').val() + " 每周 ");
                $("#" + '<%=w.ClientID %>').show();
            });
            $("input[name=wk]").click(function () {
                $("#" + '<%=w.ClientID %>').text(getCheckedWk());
            });
            $("#" + '<%=time11.ClientID %>').blur(function () {
                $("#t11").text($("#" + '<%=time11.ClientID %>').val() + " 至 ");
            });
            $("#" + '<%=time12.ClientID %>').blur(function () {
                $("#t12").text($("#" + '<%=time12.ClientID %>').val());
            });
            //----------------自定义----------------------------------------------



            $("#tep2").hide();
            $("#ok").button().hide();
            $("#next").button().click(function (event) {
                event.preventDefault();
                if (checkAType() && checkDate() && checkOther()) {
                    $("#tep1").hide();
                    $("#tep2").show();
                    $("#next").hide();
                    $("#ok").show();
                }

            });

            $("#cancel").button().click(function (event) {
                event.preventDefault();
                $("#tep1").show();
                $("#tep2").hide();
                $("#next").show();
                $("#ok").hide();
            });
            //------------------------点击收费--------------------------------------------------------------
            $("#divFee").hide();
            $("#" + "<%=rdFee.ClientID %>").click(function () {
                if ($("#" + "<%=rdFee.ClientID %>")[0].checked) {
                    $("#divFee").show();
                }
                else {
                    $("#divFee").hide();
                }
            });
            $("#" + "<%=rdFree.ClientID %>").click(function () {
                if ($("#" + "<%=rdFee.ClientID %>")[0].checked) {
                    $("#divFee").show();
                }
                else {
                    $("#divFee").hide();
                }
            });

            //表单验证
            function checkAType() {
                if ($("#" + "<%=activityType.ClientID %>").val() == "none") {
                    $("#errorMsg").text("请选择活动类型！");
                    return false;
                }
                else if ($("#" + "<%=subType.ClientID %>")[0].childElementCount > 1 && $("#" + "<%=subType.ClientID %>").val() == "none") {
                    $("#errorMsg").text("请选择活动子类型！");
                    return false;
                }
                else {
                    return true;
                }

            }
            function checkDate() {
                switch ($("#" + "<%=Cycle.ClientID %>").val()) {
                    case "当天结束":
                        var t_1 = $("#" + "<%=timeBegin.ClientID %>").val();
                        var t_2 = $("#" + "<%=timeEnd.ClientID %>").val();
                        var _d = $("#" + "<%=date.ClientID %>").val();
                        if (_d == "" || t_1 == "" || t_2 == "" || _d == "活动日期" || t_1 == "开始时间" || t_2 == "结束时间") {
                            $("#errorMsg").text("请认真填写，所有信息都是必需的！");
                            return false;
                        }
                        else {
                            if ((Date.parse(_d + " " + t_2) - Date.parse(_d + " " + t_1)) > 0) {
                                return true;
                            }
                            else {
                                $("#errorMsg").text("结束时间必须晚于开始时间！");
                                return false;
                            }
                        }
                        break;
                    case "连续多天":
                        var md1 = $("#" + "<%=date01.ClientID %>").val();
                        var md2 = $("#" + "<%=date02.ClientID %>").val();
                        var mt1 = $("#" + "<%=time01.ClientID %>").val();
                        var mt2 = $("#" + "<%=time02.ClientID %>").val();
                        if (md1 == "" || md2 == "" || mt1 == "" || mt2 == "" || mt1 == "开始时间" || mt2 == "结束时间") {
                            $("#errorMsg").text("请认真填写，所有信息都是必需的！");
                            return false;
                        }
                        else {
                            if ((Date.parse(md1 + " " + mt2) - Date.parse(md1 + " " + mt1)) > 0 && (Date.parse(md2) - Date.parse(md1)) > 0) {
                                return true;
                            }
                            else {
                                $("#errorMsg").text("结束日期/时间必须晚于开始日期/时间！");
                                return false;
                            }
                        }
                        break;
                    case "每周举行":
                        var wd1 = $("#" + "<%=date11.ClientID %>").val();
                        var wd2 = $("#" + "<%=date12.ClientID %>").val();
                        var wt1 = $("#" + "<%=time11.ClientID %>").val();
                        var wt2 = $("#" + "<%=time12.ClientID %>").val();

                        if ($("#" + "<%=w.ClientID %>")[0].innerText == "") {
                            $("#errorMsg").text("请选择星期！");
                            return false;
                        }
                        else
                            if (wd1 == "" || wd2 == "" || wt1 == "" || wt2 == "" || wt1 == "开始时间" || wt2 == "结束时间") {
                                $("#errorMsg").text("请认真填写，所有信息都是必需的！");
                                return false;
                            }
                            else {
                                if ((Date.parse(wd1 + " " + wt2) - Date.parse(wd1 + " " + wt1)) > 0 && (Date.parse(wd2) - Date.parse(wd1)) > 0) {
                                    return true;
                                }
                                else {
                                    $("#errorMsg").text("结束日期/时间必须晚于开始日期/时间！");
                                    return false;
                                }
                            }
                        break;
                    default: break;

                }
            }


        })

        function checkOther() {
            if ($("#" + "<%=txtTitle.ClientID %>").val() != "" && $("#" + "<%=utc.ClientID %>").val() != "none" && $("#" + "<%=txtDetail.ClientID %>").val() != "" && $("#" + "<%=place.ClientID %>").val() != "") {
                if ($("#" + "<%=rdFee.ClientID %>")[0].checked) {
                    if (isNaN($("#" + "<%=txtFee.ClientID %>").val())) {
                        $("#errorMsg").text("费用必须为数字！");
                        return false;
                    }
                    else {
                        return true;
                    }
                }
                else {
                    return true;
                }
            }
            else {
                $("#errorMsg").text("请认真填写，所有信息都是必需的！");
                return false;
            }
        }

        function getCheckedWk() {
            var str = "";
            $("input[name=wk]").each(function () {
                if ($(this)[0].checked) {
                    str += $(this).val() + "、";
                }

            });
            return str.substr(0, str.length - 1);
        }

        $.widget("ui.timespinner", $.ui.spinner, {
            options: {
                // seconds
                step: 600 * 1000,
                // hours
                page: 6
            },

            _parse: function (value) {
                if (typeof value === "string") {
                    // already a timestamp
                    if (Number(value) == value) {
                        return Number(value);
                    }
                    return +Globalize.parseDate(value);
                }
                return value;
            },

            _format: function (value) {
                return Globalize.format(new Date(value), "t");
            }
        });

        function ShowImg(file, serverData) {
            //alert(serverData);
            var d = serverData.split(":");
            if (d[0] == "ok") {
                document.getElementById("<%=imgSrc.ClientID %>").src = d[1];
                $("#img").val(d[1]);
            } else {
                alert("出现异常!");
            }

        }

  
    </script>
</asp:Content>
