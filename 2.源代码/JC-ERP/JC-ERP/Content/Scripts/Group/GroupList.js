$(document).ready(function () {
    var oForm = new InitForm();
    oForm.Init();

    var oTable = new InitTable();
    oTable.Init();

    var oButtonInit = new ButtonInit();
    oButtonInit.Init();
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
                    var oModalInit = new ModalInit(order);
                    oModalInit.init();
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

var ModalInit = function (model) {
    var oModal = new Object();
    oModal.model = model;
    oModal.init = function () {
        $("#groupName").val(this.model.groupName);
        $("#selUser").val(this.model.userID).trigger("change");
        var ids = this.model.userIds.split(",");
        $("#selMember").val(ids).trigger("change");
        $("#groupEdit").val(this.model.groupID);
        var m = this.model;
        $("#myModal").find(".btn-primary").unbind("click").bind("click", function () {            
            var gid = $("#groupEdit").val();
            var action = $('#myModalForm').attr("action");
            var postdata = $('#myModalForm').serializeArray();
            postdata.push({ name: "id", value: gid });
            $.post(action, postdata
                ).done(function (doc) {
                    if (doc.statusCode == 200) {
                        $("#myAlertLabel").html("修改成功！");
                        $('#myAlert').modal();
                        $('#myModal').modal('hide');
                        $("#tb_group").bootstrapTable('refresh', { 'url': srvUrl });
                    }
                    else {
                        $("#myAlertLabel").html("修改失败！" + doc.message);
                        $('#myAlert').modal();
                    }
                }).fail(function (ex) {
                }).always(function () {

                });
        });
    };
    return oModal;
}
var ButtonInit = function () {
    var oInit = new Object();
    oInit.Init = function () {
        $("#btn_del").click(function () {
            if (!confirm("是否确认删除所选分组？"))
                return;
            var u = "/Group/Del";
            var arrselections = $("#tb_group").bootstrapTable('getSelections');
            var ids = [];
            if (arrselections.length <= 0) {
                alert("请至少选择一项");
                return;
            }
            $.each(arrselections, function (idx, arr) {
                ids.push({
                    name: "ids",
                    value: arr.groupID
                });
            });
            $.post(u, ids
               ).done(function (doc) {
                   if (doc.statusCode == 200) {
                       $("#myAlertLabel").html("删除成功！");
                       $('#myAlert').modal();
                       $('#myModal').modal('hide');
                       $("#tb_group").bootstrapTable('refresh', { 'url': srvUrl });
                   }
                   else {
                       $("#myAlertLabel").html("删除成功！" + doc.message);
                       $('#myAlert').modal();
                   }
               }).fail(function (ex) {
               }).always(function () {

               });
        });
    };

    return oInit;
};

