function getCmt(type, oid,cid) {

    $.ajax({
        url: "/Handlers/GetCmt.ashx",
        data: { type: type, oid: oid },
        dataType: "json",
        success: function (data) {
            if (data.length == 0) {
                $("#" + cid).text("还没有人在此发言哦~~~");
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    $("#" + cid).append('<div class="cmtItem"> <div class="cmtLeft" >  <a href="/Account/Member.aspx?uid=' + data[i].Commentator.ID + '">  <img src="/Handlers/CreateThumbNail.ashx?wdh=60&url=' + data[i].Commentator.HeadPortraitPath + '"  alt="" /></a>   </div>  <div class="cmtRight" >   <div class="cmtRup" > ' + data[i].CreateTime + '    ' +  ' <a href="/Account/Member.aspx?uid=' + data[i].Commentator.ID + '">' + data[i].Commentator.UserName + ' </a>  </div>   <div class="cmtCon" > ' + data[i].Content + '  </div>  </div>   </div>');
                }
            }
        }
    });
}

function addCmt(arr) {
    //type,uid,oid,content,cid->文本框，containerId->评论展示区
    $.ajax({
        url: "/Handlers/AddCmt.ashx",
        data: { type: arr[0], oid: arr[2], uid: arr[1], content: arr[3] },
        dataType: "text",
        success: function (data) {
            if (data == 1) {
                //新增成功

                $("#" + arr[4]).val("");
                if ($("#" + arr[5]).text() == "还没有人在此发言哦~~~") {
                    $("#" + arr[5]).text("");
                }
                $("#" + arr[5]).prepend('<div class="cmtItem"> <div class="cmtLeft" >  <a href="/Account/Member.aspx?uid= ' + arr[1] + '">  <img src="/Handlers/CreateThumbNail.ashx?wdh=60&url=/Resource/Images/Upload/portrait/' + arr[1] + '.jpg"  alt="" /></a>   </div>  <div class="cmtRight" >   <div class="cmtRup" > 刚刚：    <a href="/Account/Member.aspx?uid=' + arr[1] + '"> 自己 </a>  </div>   <div class="cmtCon" > ' + arr[3] + '  </div>  </div>   </div>');
            }
            else {
                //失败
            }
        }
    });

}