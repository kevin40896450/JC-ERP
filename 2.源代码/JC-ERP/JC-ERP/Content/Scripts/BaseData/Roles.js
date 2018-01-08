$(document).ready(function () {
   var oTable = new InitTable();
   oTable.Init();

   $('#myModalForm').bootstrapValidator({
       message: 'This value is not valid',
       feedbackIcons: {
           valid: 'glyphicon glyphicon-ok',
           invalid: 'glyphicon glyphicon-remove',
           validating: 'glyphicon glyphicon-refresh'
       },
       fields: {
           rolename: {
               validators: {
                   notEmpty: {
                       message: '角色名称不能为空'
                   }
               }
           }
       }
   });
});

var srvUrl = "/BaseData/Roles/Get";

//初始化表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {
        $('#tb_role').bootstrapTable({
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
            idField: "roleID",
            onLoadSuccess: function () {
                $(".edit").click(function () {
                    var idx = $(this).attr("val");
                    var role = $("#tb_role").bootstrapTable('getData')[idx];
                    if (role == null) {
                        return;
                    }
                    var oModalInit = new ModalInit(role);
                    oModalInit.init();
                    $('#myModal').modal({ backdrop: 'static' });
                });
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
                    return '<a  href="javascript:;" class="btn btn-primary edit" val=' + index + '><i class="fa fa-edit"></i>&nbsp;&nbsp;编辑</a>';
                }
            }]
        });
    }
    return oInitTable;
}

var ModalInit = function (model) {
    var oModal = new Object();
    oModal.model = model;
    oModal.treeObj = null;
    oModal.init = function () {
        $("#rolename").val(this.model.roleName);
        $.jstree.destroy();
        $.ajax({
            type: "get",
            url: "/MenuList",
            dataType: "json",
            success: function (d) {
                var roles = [];
                $.each(d, function (idx, item) {
                    var IsChecked = false;                       
                    if (("," + oModal.model.menuList + ",").indexOf(("," + item.id + ",")) >= 0) {
                        IsChecked = true;
                    }
                    if (item.children.length == 0) {
                        roles.push({
                            text: item.title,
                            id: item.id,
                            state: { "selected": IsChecked }
                        });
                    }
                    else {
                        var child = CreateChildNode(item.children);
                        roles.push({
                            text: item.title,
                            id: item.id,
                            state: { "selected": IsChecked },
                            icon: "fa fa-folder icon-state-warning icon-lg",
                            children: child
                        });
                    }
                });
                oModal.treeObj = $("#roleTree").jstree(
                        {
                            plugins: ["wholerow", "checkbox", "types"],
                            core: {
                                themes: {
                                    responsive: !1
                                },
                                data: roles
                            },
                            types: {
                                "default": {
                                    icon: "fa fa-file-word-o icon-lg"
                                }
                            }
                        });

                function CreateChildNode(childs) {
                    var child = [];                    
                    $.each(childs, function (idx, item) {
                        var IsChecked = false;
                        if (("," + oModal.model.menuList + ",").indexOf("," + item.id + ",") >= 0) {
                            IsChecked = true;
                        }
                        if (item.children.length == 0) {
                            child.push({
                                text: item.title,
                                state: { "selected": IsChecked },
                                id: item.id
                            });
                        }
                        else {
                            var newchild = CreateChildNode(item.children);
                            child.push({
                                text: item.name,
                                id: item.id,
                                state: { "selected": IsChecked },
                                icon: "fa fa-folder icon-state-warning icon-lg",
                                children: newchild
                            });
                        }
                    });
                    return child;
                }
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });
        
        $("#myModal").find(".btn-primary").unbind("click").bind("click", function () {
            var $form = $('#myModalForm');
            var data = $form.data('bootstrapValidator');
            if (data) {
                // 修复记忆的组件不验证
                data.validate();

                if (data.isValid()) {                    
                    var nodes = $("#roleTree").jstree("get_checked");
                    var input = [];
                    $.each(nodes, function (idx, node) {
                        var nodeObj = $("#roleTree").jstree('get_node', node);
                        input.push(nodeObj.id);
                    });
                    var postdata = {
                        rid: oModal.model.roleID,
                        name: $("#rolename").val(),
                        ids: input.join(",")
                    };
                    var action = $("#myModalForm").attr("action");
                    $.post(action, postdata
                    ).done(function (doc) {
                        if (doc.statusCode == 200) {
                            $('#myModal').modal('hide');
                            $("#myAlertLabel").html("修改成功!");
                            $('#myAlert').modal();
                            $("#tb_role").bootstrapTable('refresh', { 'url': srvUrl });
                        }
                        else {
                            $("#myAlertLabel").html("修改失败！" + doc.message);
                            $('#myAlert').modal();
                        }
                    }).fail(function (ex) {
                    }).always(function () {

                    });                 
                }
            }
        });
    };
    return oModal;
}