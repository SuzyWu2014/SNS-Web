<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Suzy.Outside.Web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Resource/CSS/index.css" rel="stylesheet" type="text/css" />
    <script src="Resource/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
    <script src="Resource/Scripts/Infinite-Scroll.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div id="optWrap">
        <div id="options">
            <select id="activityType" name="activityType">
                <option value="all">所有类别</option>
            </select>
            <select id="activityTime" name="activityTime">
                <option value="all">所有时间</option>
                <option value="today">今天</option>
                <option value="weekend">周末</option>
                <option value="week">最近一周</option>
                <option value="month">最近一月</option>
            </select>
            <select id="people" name="people">
                <option value="all">所有人</option>
                <option value="interested">我关注的</option>
            </select>
            <select id="ReqType" name="ReqType">
                <option value="acts">活动</option>
                <option value="ptos">时景</option>
            </select>
            <input type="submit" value="搜索" id="search" class="btn" />
        </div>
    </div>
    </form>
    <div id="container">
        <asp:Repeater ID="rptAct" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="Act">
                    <a href="/Activity/DetailActivity.aspx?id=<%#Eval("ID") %>">
                        <div class='Simg'>
                            <img src='/Handlers/CreateThumbNail.ashx?url=<%#Eval("PosterPath") %> &wdh=240' alt='' />
                        </div>
                    </a>
                    <div class='intro'>
                        <a href="/Activity/DetailActivity.aspx?id=<%#Eval("ID") %>">
                            <%#Eval("Topic") %></a>
                        <%#Eval("ActivityType") %>
                        <br />
                        <%#Eval("TimeDes") %>
                        <br />
                        <a href="/Search.aspx?key=<%#Eval("University") %>"><%#Eval("University") %></a>
                        
                        <%#Eval("PlaceType") %>
                        <br>
                        发起人： <a class="lnk" href="/Account/Member.aspx?uid=<%#Eval("Sponsor.ID") %>">
                            <%#string.IsNullOrEmpty(Eval("Sponsor.NickName").ToString()) ? Eval("Sponsor.UserName") : Eval("Sponsor.NickName")%></a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptPto" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="Act">
                    <a href="/Photo/PhotoDetail.aspx?id=<%#Eval("ID")  %>">
                        <img src='/Handlers/CreateThumbNail.ashx?url=<%#Eval("ImageBigPath") %> &wdh=240'
                            alt='' /></a>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>
        <button id="more">
            More</button></div>
    <div class="msg">
        <asp:Label ID="msg" runat="server" Text=""></asp:Label></div>
    <input type="hidden" id="page" value="0" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JsCode" runat="server">
    <script type="text/javascript">
        $(function () {
            var $container = $('#container');
            $container.imagesLoaded(function () {
                $container.masonry({
                    singleMode: true,
                    itemSelector: '.Act',
                    columnWidth: 3,
                    resizeable: true

                });
            });

            //活动类别设定
            $.ajax({
                url: "/Handlers/GetActivityType.ashx",
                data: "",
                success: function (jsonStr) {
                    types = jsonStr;
                    for (var i = 0; i < types.length; i++) {
                        $("#activityType").append(' <option  value="' + types[i].MainType + '" >' + types[i].MainType + '</option>');
                    }
                    $("#activityType").val("<%=type %>");
                    $("#activityTime").val("<%=time %>");
                    $("#people").val("<%=people %>");
                    $("#ReqType").val("<%=repType %>");
                },
                dataType: "json"
            });
            $("#search").button().click(function (event) {

            });
            //无限滚动
            $container.infinitescroll({
                loadingText: "Loading new posts..."
            }, function (newElements) {
                var $newElems = $(newElements).css({ opacity: 0 });
                $newElems.imagesLoaded(function () {
                    $newElems.animate({ opacity: 1 });
                    $container.masonry('appended', $newElems, true);
                });
            });
            $("#more").button().click(function (event) {
                event.preventDefault();
                $("#page").val(parseInt($("#page").val()) + 1);
                // var boxes = [];
                $.ajax({
                    url: "/Handlers/GetActivities.ashx",
                    data: { activityType: $("#activityType").val(), activityTime: $("#activityTime").val(), people: $("#people").val(), ReqType: $("#ReqType").val(), page: $("#page").val() },
                    success: function (jsonData) {
                        if ($("#ReqType").val() == "acts") {

                            if (jsonData.length == 0) {
                                $("#" + "<%=msg.ClientID %>").text("没有活动了~╮(╯▽╰)╭~");
                            }
                            else {

                                for (var t = 0; t < jsonData.length; t++) {
                                    var imgPath = "/Handlers/CreateThumbNail.ashx?url=" + jsonData[t].PosterPath + "&wdh=240";
                                    var lnk = "/Activity/DetailActivity.aspx?id=" + jsonData[t].Id;

                                    var $box = $("<div class='Act'> <a href='" + lnk + "' ><div class='Simg'> <img src='" + imgPath + "' alt='' /> </div></a> <div class='intro' >" + jsonData[t].Topic + " " + jsonData[t].ActivityType + "<br/>" + jsonData[t].TimeDes + "<br/> " + jsonData[t].University + "  " + jsonData[t].PlaceType + " <br>发起人：<a class='lnk' href='/Account/Member.aspx?uid=" + jsonData[t].SponsorId + "' >" + jsonData[t].SponsorName + "</a></div></div>");
                                    //    boxes.push($box[0]);
                                    $("#container").append($box).masonry('appended', $box, true); 
                                
                                }

                                $container.imagesLoaded(function () {

                                    $container.masonry();
                                });
                            }
                        }
                        else {
                            if (jsonData.ds.length == 0) {
                                $("#" + "<%=msg.ClientID %>").text("没有照片了~╮(╯▽╰)╭~");
                            }
                            else {
                                for (var k = 0; k < jsonData.ds.length; k++) {
                                    var $box = $('<div class="Act"><a href="/Photo/PhotoDetail.aspx?id=' + jsonData.ds[k].ID + '"><img src="/Handlers/CreateThumbNail.ashx?wdh=240&url=' + jsonData.ds[k].ImageBigPath + '" alt="" /></a> </div>');
                                    $("#container").append($box).masonry('appended', $box, true);
                                    // boxes.push($box[0]);
                                }

                                $container.imagesLoaded(function () { 
                                    $container.masonry();
                                });

                            }
                        }

                    },
                    dataType: "json",
                    async: false
                });
                //  var $boxes = $(boxes);
                //     $container.imagesLoaded(function () {
                //$container.append($boxes).masonry('appended', $boxes);

                //                    $container.masonry();
                //                });

            });

        });
    </script>
</asp:Content>
