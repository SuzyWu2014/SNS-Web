
function setBanner() {
    var url = window.location.href;
    $("#banner").html('<div>您好，请 <a id="Login"  href="/Account/Login.aspx?ReturnUrl=' + url + '" >登录</a></div>');
}

function setLoginedBanner() {
    var str = document.cookie;
    var start = str.indexOf("name");
    var end = str.indexOf("&pwd");
    var name = str.substring(start + 5, end);
    $("#banner").html('<div><ul><li><a>&nbsp;您好 &nbsp;' + name+ '</a></li><li> <a href="/Home.aspx"><span class="ui-icon ui-icon-home"></span> 我的主页 </a></li><li><a href="/Account/EditInfo.aspx"><span class="ui-icon ui-icon-gear"></span>账号设置</a></li><li> <a href="javascript:signOut()"><span class="ui-icon ui-icon-person"></span>退出</a></li></ul>');
}

function clearBanner() {
    $("#banner").html(""); 
}


function signOut() {

    document.cookie = "";
    $.ajax({
        url: "/Handlers/Login.ashx?type=3",
        ascny: false,
        success: function () {
            window.location.href = "/Account/Login.aspx";
        }
    });
}