var defaultIcon = "fa-circle-o";
$(document).ready(function () {
    
    var srvUrl = "/MenuList";
    //加载menu对象
    $.ajax({
        type: "get",
        url: srvUrl,
        dataType: "json",
        success: function (menutree) {
            var menuHtml = "";
            for (var i = 0; i < menutree.length; i++) {
                var icon = menutree[i].icon ? menutree[i].icon : defaultIcon;
                if (menutree[i].children.length > 0) {
                    var childStr = GetChildStr(menutree[i].children);
                    menuHtml += '<li class="treeview">'
                                    + '<a href="' + menutree[i].url + '">'
                                    + '<i class="fa ' + icon + '"></i>'
                                    + '<span>' + menutree[i].title + '</span>'
                                    + '<span class="pull-right-container">'
                                    + '<i class="fa fa-angle-left pull-right"></i>'
                                    + '</span>'
                                    + '</a>' + childStr + "</li>";
                }
                else {
                    menuHtml += '<li><a href="' + menutree[i].url + '"><i class="fa ' + icon + '"></i><span>' + menutree[i].title + '</span></a></li>';
                }
            }
            $("#menu").html(menuHtml);

            SetMenuActive();
        }
    }).fail(function (err) {
        // alert("error");
    }).always(function () {
                
    });

    //设置菜单高亮状态
    function SetMenuActive() {
        var url = window.location.pathname;        if ($("#tmpUrl").length > 0)        {
            url = $("#tmpUrl").attr("src");        }        $("#menu").find("[href='" + url + "']").parent().addClass("active");
        var parent = $("#menu").find("[href='" + url + "']").parents("li.treeview:eq(0)");
        SetParentActie(parent);

        $("#menu").find("a").click(function (e) {
            var obj = $(this);
            var url = obj.attr("href");
            if (url.indexOf("/static/") >= 0) {//将static文件夹下的链接地址设置为模板文件，通过post方式提交
                document.write("<form action='/Template' method=post name=formx1 style='display:none'>");
                document.write("<input type=hidden name='url' value='" + url + "' />");
                document.write("</form>");
                document.formx1.submit();
                e.preventDefault();
            }
        });
    }

    //设置父节点高亮状态
    function SetParentActie(obj) {
        if (obj.length > 0) {
            obj.addClass("active");
            var parent = obj.parents("li.treeview:eq(0)");
            SetParentActie(parent);
        }
    }

    //获取子菜单
    function GetChildStr(menutree) {
        var menuHtml = '<ul class="treeview-menu">';
        for (var i = 0; i < menutree.length; i++) {
            var icon = menutree[i].icon ? menutree[i].icon : defaultIcon;
            if (menutree[i].children.length > 0) {
                var childStr = GetChildStr(menutree[i].children);
                if (childStr == "") {
                    menuHtml += '<li><a href="' + menutree[i].url + '"><i class="fa ' + icon + '"></i>' + menutree[i].title + '</a></li>';
                }
                else {
                    menuHtml += '<li class="treeview">'
                                + '<a href="#">'
                                + '<i class="fa ' + icon + '"></i>'
                                + '<span>Charts</span>'
                                + '<span class="pull-right-container">'
                                + '<i class="fa fa-angle-left pull-right"></i>'
                                + '</span>'
                                + '</a>' + childStr + "</li>";
                }
            }
            else {
                menuHtml += '<li><a href="' + menutree[i].url + '"><i class="fa ' + icon + '"></i>' + menutree[i].title + '</a></li>';
            }
        }
        menuHtml += '</ul>';
        return menuHtml;
    }
});