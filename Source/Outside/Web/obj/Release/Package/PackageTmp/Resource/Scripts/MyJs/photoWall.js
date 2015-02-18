
function GetAllPto(cid,uid) {

    $.ajax({
        url: "/Handlers/GetPhotos.ashx?type=4&uid="+uid,
        dataType: "json",
        async: false,
        success: function (jsonData) {
            for (var i = 0; i < jsonData.length; i++) {
                var item = '<div class="box" ><a href="/Photo/PhotoDetail.aspx?id=' + jsonData[i].ID + '"> <img src="/Handlers/CreateThumbNail.ashx?wdh=250&url=' + jsonData[i].ImageBigPath + '" alt="' + jsonData[i].Title + '" /></a></div>';
                $("#" + cid).append(item);
            }
        }
    });

    var $container = $("#container");

    $container.imagesLoaded(function () {
        $container.masonry({
            itemSelector: '.box',
            resizeable: true,
            singleMode: true
        });
    });
}

function getAlbumlPto(cid, uid, aid) {

    $.ajax({
        url: "/Handlers/GetPhotos.ashx?type=3&uid=" + uid + "&albumId=" + aid,
        dataType: "json",
        async: false,
        success: function (jsonData) {
            for (var i = 0; i < jsonData.length; i++) {
                var item = '<div class="box" ><a href="/Photo/PhotoDetail.aspx?id=' + jsonData[i].ID + '"> <img src="/Handlers/CreateThumbNail.ashx?wdh=250&url=' + jsonData[i].ImageBigPath + '" alt="' + jsonData[i].Title + '" /></a></div>';
              //  $("#" + cid).append(item);
                var $item = $(item);
                $("#container").append($item).masonry('appended', $item,true); 
            }
        }
    });

    var $container = $("#container");
    $container.imagesLoaded(function () {
        $container.masonry({
            itemSelector: '.box',
            resizeable: true,
            singleMode: true
        });
    });
    $container.reload();
}
function getActPto(cid,actid) {

    $.ajax({
        url: "/Handlers/GetPhotos.ashx",
        data: { type: "1", actId: actid },
        dataType: "json",
        success: function (jsonStr) {
            if (jsonStr.length == 0) {
                $("#"+cid).append("<div>还没有活动照片上传哦~~~</div>");
            }
            else {
                for (var i = 0; i < jsonStr.length; i++) {
                    var item = '<div class="item" ><a href="/Photo/PhotoDetail.aspx?id=' + jsonStr[i].ID + '"> <img src="/Handlers/CreateThumbNail.ashx?hgt=80&url=' + jsonStr[i].ImageBigPath + '" alt="' + jsonStr[i].Title + '" /></a></div>';
                    $("#" + cid).append(item);
                }
            }
        }
    });
    
}