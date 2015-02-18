var utcs; //学校信息，json格式
//获得省份
function GetSchool(procId, cityId, schoolId) {
    $.ajax({
        url: "/Handlers/GetUniversity.ashx",
        data: "",
        success: function (jsonStr) {
            utcs = jsonStr;
            for (var i = 0; i < utcs.length; i++) {
                $("#" + procId).append(" <option value='" + utcs[i].Province + "' >" + utcs[i].Province + "</option>");
            }
        },
        dataType: "json"
    });
    //获得城市 
    $("#" + procId).change(function () {
        $("#" + cityId).html("<option value='none' selected='selected'>请选择</option>");
        var p = $("#" + procId).val();
        if (p != "none") {
            for (var i = 0; i < utcs.length; i++) {
                if (utcs[i].Province == p && utcs[i].Cu.length > 0) {
                    for (var j = 0; j < utcs[i].Cu.length; j++) {

                        $("#" + cityId).append(" <option value='" + utcs[i].Cu[j].City + "' >" + utcs[i].Cu[j].City + "</option>");
                    }
                    break;
                }
            }
        }
        else {
            $("#" + cityId).html("<option value='none' selected='selected'>请选择</option>");
            $("#" + schoolId).html("<option value='none' selected='selected'>请选择</option>");
        }

    });
    //学校信息
    $("#" + cityId).change(function () {
        $("#" + schoolId).html("<option value='none' selected='selected'>请选择</option>");
        var pr = $("#" + procId).val();
        var ct = $("#" + cityId).val();
        if (pr != "none" && ct != "none") {
            for (var i = 0; i < utcs.length; i++) {
                if (utcs[i].Province == pr && utcs[i].Cu.length > 0) {
                    for (var j = 0; j < utcs[i].Cu.length; j++) {
                        if (utcs[i].Cu[j].City == ct) {
                            for (var t = 0; t < utcs[i].Cu[j].Unt.length; t++) {
                                $("#" + schoolId).append(" <option value='" + utcs[i].Cu[j].Unt[t] + "' >" + utcs[i].Cu[j].Unt[t] + "</option>");
                            }
                        }
                    }
                    break;
                }
            }
        }
        else {
            $("#" + cityId).html("<option value='none' selected='selected'>请选择</option>");
            $("#" + schoolId).html("<option value='none' selected='selected'>请选择</option>");
        }

    });
}

