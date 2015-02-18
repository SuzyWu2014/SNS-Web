<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alogin.aspx.cs" Inherits="Suzy.Outside.Web.Admin.Alogin1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resource/Styles/skin.css" rel="stylesheet" type="text/css" />
    <script  type="text/javascript" language="javascript" >
        function correctPNG() {
            var arVersion = navigator.appVersion.split("MSIE")
            var version = parseFloat(arVersion[1])
            if ((version >= 5.5) && (document.body.filters)) {
                for (var j = 0; j < document.images.length; j++) {
                    var img = document.images[j]
                    var imgName = img.src.toUpperCase()
                    if (imgName.substring(imgName.length - 3, imgName.length) == "PNG") {
                        var imgID = (img.id) ? "id='" + img.id + "' " : ""
                        var imgClass = (img.className) ? "class='" + img.className + "' " : ""
                        var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
                        var imgStyle = "display:inline-block;" + img.style.cssText
                        if (img.align == "left") imgStyle = "float:left;" + imgStyle
                        if (img.align == "right") imgStyle = "float:right;" + imgStyle
                        if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
                        var strNewHTML = "<span " + imgID + imgClass + imgTitle
             + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
             + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
             + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
                        img.outerHTML = strNewHTML
                        j = j - 1
                    }
                }
            }
        }
        window.attachEvent("onload", correctPNG);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="42" valign="top">
                <table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
                    <tr>
                        <td width="1%" height="21">
                            &nbsp;
                        </td>
                        <td height="42">
                            &nbsp; 
                        </td>
                        <td width="17%">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg">
                    <tr>
                        <td width="49%" align="right">
                            <table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
                                <tr>
                                    <td height="138" valign="top">
                                        <table width="89%" height="427" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="149">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="80" align="right" valign="top">
                                                    <img  width="450" alt="" src="/Admin/Resource/Styles/images/admin.jpg" />
                                                </td>
                                            </tr>
                                             
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="1%">
                            &nbsp;
                        </td>
                        <td width="50%" valign="bottom">
                            <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="4%">
                                        &nbsp;
                                    </td>
                                    <td width="96%" height="38">
                                        <span class="login_txt_bt"><h1>登陆后台管理系统</h1></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td height="21">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="table211" height="328">
                                            <tr>
                                                <td height="164" colspan="2" align="middle"> 
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="143" id="table212">
                                                        <tr>
                                                            <td width="13%" height="38" class="top_hui_text">
                                                                <span class="login_txt">管理员：&nbsp;&nbsp; </span>
                                                            </td>
                                                            <td height="38" colspan="2" class="top_hui_text">
                                                               <asp:TextBox class="editbox4" ID="txtName" runat="server"></asp:TextBox> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="13%" height="35" class="top_hui_text">
                                                                <span class="login_txt">密 码： &nbsp;&nbsp; </span>
                                                            </td>
                                                            <td height="35" colspan="2" class="top_hui_text">
                                                               <asp:TextBox ID="txtPwd" class="editbox4" TextMode="Password" runat="server"></asp:TextBox> 
                                                                <img src="Resource/Styles/luck.gif" width="19" height="18" />
                                                            </td>
                                                        </tr>
                                         
                                                        <tr>
                                                            <td height="35">
                                                                &nbsp;
                                                            </td>
                                                            <td width="20%" height="35">
                                                             <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click"  CssClass="Submit" />
                                                            </td>
                                                            <td width="67%" class="top_hui_text">
                                                                <input name="cs" type="button" CssClass="Submit"   id="cs" value="取 消"  onclick="showConfirmMsg1()">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br/>
                                                    </form>
                                                </td>
                                            </tr>
                                            <tr> 
                                                <td width="433" height="164" align="right" valign="bottom">
                                                    <img src="Resource/Styles/login-wel.gif" width="242" height="138">
                                                </td>
                                                <td width="57" align="right" valign="bottom">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="20">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
                    <tr>
                        <td align="center">
                            <span class="login-buttom-txt">Copyright(C) 2012-2013 Suzy All Rights Reserved.</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form> 
</body>
</html>
