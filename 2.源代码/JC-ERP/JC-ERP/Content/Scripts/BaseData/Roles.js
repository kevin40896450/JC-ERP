$(document).ready(function () {
   var oTable = new InitTable();
    oTable.Init();
});

var srvUrl = "/BaseData/Roles/Get";

//初始化表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {
        $('#tb_role').bootstrapTable({
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
            idField: "roleID",
            onLoadSuccess: function () {
                
            },
            columns: [{
                checkbox: true
            }, {
                field: 'roleID',
                title: '角色编号'
            }, {
                field: 'roleName',
                title: '角色名称'
            },{
                title: '操作',
                formatter: function (val, row, index) {
                    return '<a  href="javascript:;" class="btn btn-primary truck" val=' + index + '><i class="fa fa-truck"></i>&nbsp;&nbsp;发货</a>';
                }
            }]
        });
    }
    return oInitTable;
}