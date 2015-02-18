
function setting() {
    var name = $("#name"),
      des = $("#des"),

      allFields = $([]).add(name).add(des),
      tips = $(".validateTips");


    function updateTips(t) {
        tips
        .text(t)
        .addClass("ui-state-highlight");
        setTimeout(function () {
            tips.removeClass("ui-state-highlight", 1500);
        }, 500);
    }

    function checkLength(o, n, min, max) {
        if (o.val().length > max || o.val().length < min) {
            o.addClass("ui-state-error");
            updateTips(n + " 长度必须在" +
          min + " 和 " + max + "之间.");
            return false;
        } else {
            return true;
        }
    }

    $("#dialog-form").dialog({
        autoOpen: false,
        height: 300,
        width: 350,
        modal: true,
        buttons: {
            "创建": function () {
                var bValid = true;
                allFields.removeClass("ui-state-error");

                bValid = bValid && checkLength(name, "相册名", 1, 16);
                if (bValid) {
                    $.ajax({
                        url: "/Handlers/AlbumHandler.ashx",
                        data: { type: "0", title: name.val(), des: des.val() },
                        dataType: "text",
                        success: function (data) {
                            if (data != "-1") { 
                                $("#album").append(' <option value="'+data+'">'+name.val()+'</option>'); 
                                $("#dialog-form").dialog("close");
                            }
                        }
                    });

                }
            },
            Cancel: function () {
                $("#dialog-form").dialog("close");
            }
        },
        取消: function () {
            allFields.val("").removeClass("ui-state-error");
        }
    });
}
