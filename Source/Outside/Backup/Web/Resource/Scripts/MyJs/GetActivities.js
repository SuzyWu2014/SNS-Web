
//活动select列表 
function getJoinedActs(uid,controlId) {
    $.ajax({
        url: "/Handlers/GetActByUid.ashx",
        data: { uid: uid, type: "1" },
        dataType: "json",
        success: function (jsonStr) {
            if (jsonStr.length > 0) {
                for (var i = 0; i < jsonStr.length; i++) {
                    $("#" + controlId).append(' <option value="' + jsonStr[i].ID + '">' + jsonStr[i].Topic + '</option>');
                } 
            }
            else { 
            }
        }
    });
}

 

function ShowInfo(jsonStr) {
    if (jsonStr.length > 0)
    { }
    else {
        $("#Joined").append("TA还没有参加活动哦~~来推荐一个吧~~<a href='#'>推荐</a>");
    }
}