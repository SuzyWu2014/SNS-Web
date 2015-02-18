

function setActType(mainId,SubId,msgId) {

    $.ajax({
        url: "/Handlers/GetActivityType.ashx",
        data: "",
        success: function (jsonStr) {
            types = jsonStr;
            for (var i = 0; i < types.length; i++) {
                $("#" + mainId).append(' <option  value="' + types[i].MainType + '"  runat="server" >' + types[i].MainType + '</option>');
            }
        },
        dataType: "json"
    });
    //获得子类别
    $("#" + mainId).change(function () {
        $("#" + SubId).html("<option value='none' selected='selected'>请选择</option>");


        $("#" + SubId).css("visibility", "hidden");

        var main = $("#" + mainId).val();
        if (main != "none") {
            for (var i = 0; i < types.length; i++) {
                if (types[i].MainType == main && types[i].SubType.length > 1) {
                    for (var j = 0; j < types[i].SubType.length; j++) {
                        $("#" + SubId).append(" <option value='" + types[i].SubType[j] + "' >" + types[i].SubType[j] + "</option>");
                    }
                    $("#" +  SubId).css("visibility", "visible");
                    break;
                }
            }
        }
        else {
            $("#"+msgId).text("请选择活动类别！");
        }

    });

}