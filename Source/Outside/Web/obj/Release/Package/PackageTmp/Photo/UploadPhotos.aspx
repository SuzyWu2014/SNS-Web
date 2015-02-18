<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="UploadPhotos.aspx.cs" Inherits="Suzy.Outside.Web.Photo.UploadPhotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Resource/CSS/multiUpload.css" rel="stylesheet" type="text/css" />
    <script src="../Resource/SWFUpload_v250/swfupload.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/multi/swfupload.queue.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/multi/fileprogress.js" type="text/javascript"></script>
    <script src="../Resource/SWFUpload_v250/multi/handlers.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/GetActivities.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/Album.js" type="text/javascript"></script>
    <script src="../Resource/Scripts/MyJs/create-album-div.js" type="text/javascript"></script>
    <link href="../Resource/CSS/upPto.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main">
        <div class="title">
            批量上传照片</div>
        <div id="multi">
            <div class="lnk">
                <a href="/Photo/SelfPhotoWall.aspx">返回相册列表 > </a>
            </div>
                <div>
                    <span>请选择照片所属活动</span>
                    <select id="act">
                        <option value="none">不选择</option>
                    </select>
                    <span>请选择相册 </span>
                    <select id="album">
                    </select>
                    <button id="createNewAlbum">
                        新建相册</button>
                </div>
            <div>
                <span id="spanButtonPlaceHolder"></span>
                <input id="btnCancel" type="button" value="取消全部上传" onclick="swfu.cancelQueue();"
                    disabled="disabled" style="margin-left: 2px; font-size: 8pt; height: 22px;" />
            
            </div>
            <p>
                &nbsp;</p>
            <div class="fieldset flash" id="fsUploadProgress">
                <span class="legend">Upload Queue</span>
            </div>
            <div id="divStatus">
                0 个文件已经上传</div>
        </div>
    </div>
    <div id="dialog-form" title="新建相册">
        <p class="validateTips" style="height: 20px;">
        </p>
        <fieldset>
            <table>
                <tr>
                    <td>
                        <label for="name">
                            相册名：</label>
                    </td>
                    <td>
                        <input type="text" name="name" id="name" class="text ui-widget-content ui-corner-all" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label for="des">
                            描述：</label>
                    </td>
                    <td>
                        <textarea rows="5" cols="30" id="des" class="text ui-widget-content ui-corner-all">content</textarea>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            var settings = {
                flash_url: "/Resource/SWFUpload_v250/swfupload.swf",
                upload_url: "/Handlers/UploadPhotos.ashx?album=" + $("#album").val() + "&actId=" + $("#act").val(),
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },
                file_size_limit: "100 MB",
                file_types: "*.jpg;*.gif;*.png;jepg",
                file_types_description: "JPG Images",
                file_upload_limit: 100,
                file_queue_limit: 0,
                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    cancelButtonId: "btnCancel"
                },
                debug: false,

                // Button settings
                button_image_url: "/Resource/SWFUpload_v250/images/XPButtonNoText_160x22.png",
                button_placeholder_id: "spanButtonPlaceHolder",
                button_width: 160,
                button_height: 22,
                button_text: '<span class="button">&nbsp;选择文件并上传<span class="buttonSmall">(2 MB Max)</span></span>',
                button_text_style: '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
                button_text_top_padding: 1,
                button_text_left_padding: 5,

                // The event handler functions are defined in handlers.js
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,
                queue_complete_handler: queueComplete	// Queue plugin event
            };

            swfu = new SWFUpload(settings);
        };

        $(function () {
            var uid = "<%= Page.User.Identity.Name %>";
            getJoinedActs(uid, "act");
            GetAlbumList(uid, "album");
            //弹出层设置
            setting();

            $("#createNewAlbum").button().click(function () {
                $("#dialog-form").dialog("open");
            });



            $("#act").change(function () {
                swfu.setUploadURL("/Handlers/UploadPhotos.ashx?album=" + $("#album").val() + "&actId=" + $("#act").val());
            });

            $("#album").change(function () {
                swfu.setUploadURL("/Handlers/UploadPhotos.ashx?album=" + $("#album").val() + "&actId=" + $("#act").val());
            });
        });
         
    </script>
</asp:Content>
