<%@ Page Title="" Language="C#" MasterPageFile="~/Mater4Self.master" AutoEventWireup="true"
    CodeBehind="EditInfo.aspx.cs" Inherits="Suzy.Outside.Web.Account.EditInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Resource/Scripts/MyJs/University.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/swfupload.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/handlers.js" type="text/javascript"></script>
    <link href="../Resource/CSS/Info.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="left">
        <div id="editor">
            <div class="title">
                完善个人信息：</div>
            <form runat="server" id="form1">
            <div>
                <table>
                    <tr>
                        <td>
                            登录名：
                        </td>
                        <td>
                            <%=cmr.UserName %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            * 昵称：
                        </td>
                        <td>
                            <input type="text" name="txtNickname" id="txtNickname" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            真实姓名：
                        </td>
                        <td>
                            <input type="text" name="txtRealname" id="txtRealname" value="" />
                            <input type="checkbox" name="ckRealname" id="ckRealname" /><label for="ckRealname">公开</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            *性别：
                        </td>
                        <td>
                            <input type="radio" value="男" name="sex" id="male" /><label for="male">男</label>
                            <input type="radio" value="女" name="sex" id="female" /><label for="female">女</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="proc">
                                所属学校
                            </label>
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
                            学院：
                        </td>
                        <td>
                            <input type="text" name="txtCollege" value="" id="txtCollege" />
                            <input type="checkbox" name="ckCollege" id="ckCollege" /><label for="ckCollege">公开</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            专业：
                        </td>
                        <td>
                            <input type="text" name="txtmajor" value=" " id="txtmajor" />
                            <input type="checkbox" name="ckMajor" id="ckMajor" /><label for="ckMajor">公开</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            入学年份：
                        </td>
                        <td>
                            <input type="text" name="txtEntranceYear" id="txtEntranceYear" maxlength="4" />
                            <input type="checkbox" name="ckYear" id="ckYear" /><label for="ckYear">公开</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtDetail">
                                个人简介：
                            </label>
                        </td>
                        <td>
                            <textarea id="txtDetail" cols="60" rows="8" runat="server"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email：
                        </td>
                        <td>
                            <input type="text" name="txtEmail" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <button id="save">
                                保存</button>
                        </td>
                    </tr>
                </table>
            </div>
            </form>
        </div>
        <div id="portraitEditor">
            <div id="content">
                <div id="swfu_container" style="margin: 0px 10px;">
                    <div>
                        <span id="spanButtonPlaceholder"></span>
                    </div>
                    <div id="divFileProgressContainer" style="height: 75px;">
                    </div>
                </div>
                <div id="Contenter" style="width: 300px;">
                    <div id="div1" style="width: 180px; height: 180px; border: 1px solid white; color: White;">
                        拖动截取</div>
                </div>
                <input type="button" value="截取并保存" id="btnCut" />
            </div>
            <div id="cutted">
                <img id="imgUrl" alt="" src="" />
                <br />
                <br />
                <br />
                <br />
                <label id="msg">
                </label>
            </div>
        </div>
    </div>
    <div class="right">
        <a href="javascript:showInfo();" id="btnInfo" class="lnk">&lt; 个人信息</a>
        <br />
        <br />
        <a href="javascript:showPortrait();" id="btnPortrait" class="lnk">&lt; 上传头像 </a>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/Handlers/PortraitHandler.ashx?action=up",
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
                button_text: '<span class="button">选择上传的图片 <span class="buttonSmall">(2 MB Max)</span></span>',
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

        var d;
        function ShowImg(file, serverData) {
            d = serverData.split(":");
            if (d[0] == "ok") {
                var width = d[2]; //图片的宽带
                var height = d[3]; //高度
                $("#Contenter").css("backgroundImage", "url(" + d[1] + ")").css("width", width + "px").css("height", height + "px");

                //   document.getElementById("imgSrc").src=d[1];
            } else {
                alert("出现异常!");
            }

        }
        function showInfo() {
            $("#editor").show();
            $("#portraitEditor").hide();
        }
        function showPortrait() {
            $("#editor").hide();
            $("#portraitEditor").show();
        }
        $(function () {
            $("#editor").show();
            $("#portraitEditor").hide();


            //获得学校信息
            GetSchool("proc", "city", "utc");
            $("#save").button();
            if ("<%=cmr.Sex %>" == "女") {
                $("#female")[0].checked = true;
            }
            else {
                $("#male")[0].checked = true;
            }
            $("#ckCollege").attr("checked", "<%=cmr.IsCollegePrivate %>".toLowerCase() == "false" ? false : true);
            $("#ckMajor").attr("checked", "<%=cmr.IsMajorPrivate %>".toLowerCase() == "false" ? false : true);
            $("#ckYear").attr("checked", "<%=cmr.IsEntraceYearPrivate %>".toLowerCase() == "false" ? false : true);
            $("#ckRealname").attr("checked", "<%=cmr.IsRealNamePrivate %>".toLowerCase() == "false" ? false : true);

            $("#txtNickname").val("<%=cmr.Nickname%>");
            $("#txtRealname").val("<%=cmr.RealName %>");
            $("#txtCollege").val("<%=cmr.College %> ");
            $("#txtMajor").val("<%=cmr.Major %>");
            $("#txtEntranceYear").val("<%=cmr.EntranceYear %>");
            $("#txtEmail").val("<%=cmr.Email %>");
            $("#txtDetail").val("<%=cmr.IntroSelf %> ");
            $("#div1").resizable({
                containment: 'parent', aspectRatio: 1 / 1
            }).draggable({ containment: 'parent' });

            //$("#div1").draggable();
            $("#btnCut").button().click(function (event) {

                //offset():获取某个元素的绝对坐标.
                var relTop = $("#div1").offset().top - $("#Contenter").offset().top; //获取纵坐标.
                var relLeft = $("#div1").offset().left - $("#Contenter").offset().left;
                var width = $("#div1").width(); //宽带
                var height = $("#div1").height(); //高度.
                $.post("/Handlers/PortraitHandler.ashx", { "action": "cut", "top": relTop, "left": relLeft, "width": width, "height": height, "url": d[1] }, function (data) {

                    $("#imgUrl").attr("src", "/Handlers/CreateThumbNail.ashx?wdh=" + width + "&url=" + data);
                    $("#msg").text("已保存");
                }, "text");

            });


        });
    </script>
</asp:Content>
