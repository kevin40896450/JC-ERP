$(document).ready(function () {
    var oForm = new InitForm();
    oForm.Init();

    var oTable = new InitTable();
    oTable.Init();
});

var srvUrl = "/Group/Get";

//初始化产品类型表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {
        $('#tb_group').bootstrapTable({
            toolbar: '#toolbar',                //工具按钮用哪个容器
            url: srvUrl,//请求后台的URL（*）
            method: 'get',
            striped: false,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: true,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式                
            sidePagination: "server",           //分页方式：client客户端分页，server服务端分页（*）
            pageNumber: 1,                       //初始化加载第一页，默认第一页
            pageSize: Common.PageSize,                       //每页的记录行数（*）
            pageList: Common.PageList,        //可供选择的每页的行数（*）
            search: false,                       //是否显示表格搜索
            strictSearch: false,
            showColumns: false,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            clickToSelect: false,                //是否启用点击选中行
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表     
            idField: "groupID",
            onLoadSuccess: function () {                
                $(".edit").click(function () {
                    var idx = $(this).attr("val");
                    var order = $("#tb_group").bootstrapTable('getData')[idx];
                    if (order == null) {
                        return;
                    }

                    $('#myModal').modal({ backdrop: 'static' });
                });
            },
            columns: [{
                checkbox: true
            }, {
                field: 'groupID',
                title: '班组编号'
            }, {
                field: 'groupName',
                title: '班组名称'
            }, {
                field: 'users',
                title: '班组成员'
            }, {
                title: '操作',
                formatter: function (val, row, index) {
                    return '<a  href="javascript:;" class="btn btn-primary edit" val=' + index + '><i class="fa fa-edit"></i>编辑</a>';
                }
            }]
        });
    }
    return oInitTable;
}

//初始化表单数据
var InitForm = function () {
    var oInitForm = new Object();
    oInitForm.Init = function () {
        var srvUrl = "/SimpleUsers";
        //加载用户下拉菜单
        $.ajax({
            type: "get",
            url: srvUrl,
            dataType: "json",
            success: function (d) {
                var arrs = [];
                arrs.push({
                    id: 0,
                    text: "全部"
                });
                arrs = arrs.concat(d);
                $("#selUser").select2({
                    data: arrs
                });

                $("#selMember").select2({
                    data: arrs
                });
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });
    }
    return oInitForm;
}

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};
    var srvSubmitUrl = "";
    oInit.Init = function () {
        $("#btnSearch").click(function () {
            srvUrl = "/Order/Get";
            var buyer = $('#buyer').val();
            var proName = $('#proName').val();
            var selUsers = $('#selUsers').val();
            srvUrl += "?t=" + new Date().getTime();
            var parms = "";
            if (buyer != "") {
                parms += "&buyer=" + buyer;
            }
            if (proName != "") {
                parms += "&p=" + proName;
            }
            if (selUsers != "0") {
                parms += "&u=" + selUsers;
            }
            srvUrl += parms;
            $("#tb_order").bootstrapTable('refresh', { 'url': srvUrl });
        });
    };

    return oInit;
};