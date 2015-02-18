
//
function getAct(uid, containerId, type, word) {
    var count = 0;
    $.ajax({
        url: "/Handlers/GetActByUid.ashx",
        data: { uid: uid, type: type },
        dataType: "json",
        async: false,
        success: function (jsonStr) {
            if (jsonStr.length > 0) {
                count = jsonStr.length;
                for (var i = 0; i < jsonStr.length; i++) {
                    $("#" + containerId).append(' <div class="scroll-content-item ui-widget-header" >  <a href="/Activity/DetailActivity.aspx?id=' + jsonStr[i].ID + '"  target="_blank" >   <img src="/Handlers/CreateThumbNail.ashx?wdh=200&url=' + jsonStr[i].PosterPath + '" alt=" " /></a><div class="name" ><a  target="_blank" href="/Activity/DetailActivity.aspx?id=' + jsonStr[i].ID + '" >' + jsonStr[i].Topic + ' </a></div></div>');
                }
            }
            else {
                $("#" + containerId).append("TA还没有" + word + "活动哦~~来推荐一个吧~~<a href='#'>推荐</a>");
                $("#" + containerId).next().hide();
            }

        }
    });

    return count;
}
