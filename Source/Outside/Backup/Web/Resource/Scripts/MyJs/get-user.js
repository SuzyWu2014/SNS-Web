function getUser(id, type, cid) {
    $.ajax({
        url: "/Handlers/GetUser.ashx",
        data: { id: id, type: type },
        dataType: "json",
        success: function (jsonStr) {
            if (jsonStr.length > 0) {
                for (var i = 0; i < jsonStr.length; i++) {
                    var html = "<div class=\"user\" ><div> <a href=\"/Account/Member.aspx?uid=" + jsonStr[i].ID + "\" ><img     src=\"" + jsonStr[i].HeadPortraitPath + "\" alt=\""+jsonStr[i].Nickname +"\" /></a> </div><div class=\"name\" >" + (jsonStr[i].Nickname == "" ? jsonStr[i].UserName : jsonStr[i].Nickname) + "</div> </div>"; 
                    $("#" + cid).append(html);
                }
            }
            else {
                $("#" + cid).append("TA还没有粉丝哦~~来关注他吧~~");
            }

        }
    });

}


