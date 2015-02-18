
function GetAlbumList(uid, controlId) {
    $.ajax({
        url: "/Handlers/GetAlbums.ashx",
        data: { uid: uid },
        dataType: "json",
        success: function (jsonStr) {
            if (jsonStr.length > 0) {
                for (var i = 0; i < jsonStr.length; i++) {
                    $("#" + controlId).append(' <option value="' + jsonStr[i].ID + '">' + jsonStr[i].Title + '</option>');
                }
            }
            else {
            }
        }
    });
}

