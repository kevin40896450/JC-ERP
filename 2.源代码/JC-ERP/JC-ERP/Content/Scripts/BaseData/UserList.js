$(document).ready(function () {    
    var oTable = new InitTable();
    oTable.Init();

    var oBtn = new Btn();
    oBtn.Init();

    $('#myModal').on('hidden.bs.modal', function () {
        $("#myModalForm").bootstrapValidator('resetForm');
    });

    $('#myModalForm').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            userName: {
                validators: {
                    notEmpty: {
                        message: '用户名称不能为空'
                    }
                }
            },
            realName: {
                validators: {
                    notEmpty: {
                        message: '真实名称不能为空'
                    }
                }
            },
            tel: {
                validators: {
                    notEmpty: {
                        message: '联系电话不能为空'
                    },
                    stringLength: {
                        min: 11,
                        max: 11,
                        message: '请输入11位手机号码'
                    }
                }
            }
        }
    });

});

var srvUrl = "/BaseData/UserList/Get";

//初始化表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {
        $('#tb_user').bootstrapTable({
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
            idField: "userID",
            onLoadSuccess: function () {
                $(".edit").click(function () {
                    var idx = $(this).attr("val");
                    var usr = $("#tb_user").bootstrapTable('getData')[idx];
                    if (usr == null) {
                        return;
                    }
                    var oModalInit = new ModalInit("编辑用户", usr);
                    oModalInit.init();
                    $('#myModal').modal({ backdrop: 'static' });
                });
            },
            columns: [{
                checkbox: true
            }, {
                field: 'userName',
                title: '用户名称'
            }, {
                field: 'realName',
                title: '真实姓名'
            }, {
                field: 'sex',
                title: '性别'
            }, {
                field: 'tel',
                title: '联系电话'
            }, {
                field: 'roleName',
                title: '用户角色'
            }, {
                field: 'intoTimeStr',
                title: '入职时间'
            }, {
                title: '操作',
                formatter: function (val, row, index) {
                    return '<a  href="javascript:;" class="btn btn-primary edit" val=' + index + '><i class="fa fa-edit"></i>&nbsp;&nbsp;编辑</a>';
                }
            }]
        });
    }
    return oInitTable;
}

var Btn = function () {
    var oBtn = new Object();

    oBtn.Init = function () {
        $.ajax({
            type: "get",
            url: "/BaseData/Roles/SimpleGet",
            dataType: "json",
            success: function (d) {
                var arrs = [];
                $.each(d, function (idx, item) {
                    arrs.push({
                        id: item.roleID,
                        text: item.roleName
                    });
                });
                $("#selRole").select2({
                    data: arrs
                });
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });
        
        $('.mydate').datepicker({
            autoclose: true,
            format: "yyyy-mm-dd",
            language: "zh-CN"
        });

        $("#btn_add").click(function () {
            var oModalInit = new ModalInit("添加用户");
            oModalInit.init();
            $('#myModal').modal({ backdrop: 'static' });
        });

        $("#btn_del").click(function () {
            var arrselections = $("#tb_user").bootstrapTable('getSelections');
            var ids = [];
            if (arrselections.length <= 0) {
                alert("请至少选择一项");
                return;
            }
            if (!confirm("是否确认删除所选角色？"))
                return;

            var u = "/BaseData/UserList/Del";
            $.each(arrselections, function (idx, arr) {
                ids.push(arr.roleID);
            });
            var postdata = {
                data: ids.join(",")
            };
            $.post(u, postdata
               ).done(function (doc) {
                   if (doc.statusCode == 200) {
                       $("#myAlertLabel").html("删除成功！");
                       $('#myAlert').modal();
                       $('#myModal').modal('hide');
                       $("#tb_user").bootstrapTable('refresh', { 'url': srvUrl });
                   }
                   else {
                       $("#myAlertLabel").html("删除失败！" + doc.message);
                       $('#myAlert').modal();
                   }
               }).fail(function (ex) {
               }).always(function () {

               });
        });
    };
    return oBtn;
};

var ModalInit = function (title, model) {
    var oModal = new Object();
    oModal.model = model;
    oModal.title = title;
    oModal.treeObj = null;
    oModal.init = function () {
        $("#modelTitle").html(oModal.title);
        if (this.model) {
            $("#userName").val(this.model.userName);
            $("#userName").attr("disabled", "disabled");
            $("#realName").val(this.model.realName);
            $("#tel").val(this.model.tel);
            $("#selRole").val(this.model.roleID).trigger("change");
            if (this.model.sex == "女") {                
                $("#sexFeMale").attr('checked', 'true');
            }
            else {
                $("#sexMale").attr('checked', 'true');                
            }
            $("#intodate").val(this.model.intodate);
        }
        else {
            $("#userName").removeAttr("disabled");
            $("#sexMale").attr('checked', 'true');
            $("#userName").val("");
            $("#realName").val("");
            $("#tel").val("");
        }       

        $("#myModal").find(".btn-primary").unbind("click").bind("click", function () {
            var $form = $('#myModalForm');
            var data = $form.data('bootstrapValidator');
            if (data) {
                // 修复记忆的组件不验证
                data.validate();

                if (data.isValid()) {
                    //var postdata2 = $form.serializeArray();
                    var userID = -1;
                    if (oModal.model) {
                        userID = oModal.model.userID;
                    }
                    var postdata = {
                        uid: userID,
                        userName: $("#userName").val(),
                        roleId: $("#selRole").val(),
                        realName: $("#realName").val(),
                        sex: $("input[name='sex']:checked").val(),
                        tel: $("#tel").val(),
                        intoDate: $("#intodate").val()
                    };
                    
                    var action = $("#myModalForm").attr("action");
                    $.post(action, postdata
                    ).done(function (doc) {
                        if (doc.statusCode == 200) {
                            $('#myModal').modal('hide');
                            if (userID > 0) {
                                $("#myAlertLabel").html("修改成功!");
                            }
                            else {
                                $("#myAlertLabel").html("添加成功!");
                            }
                            $('#myAlert').modal();
                            $("#tb_user").bootstrapTable('refresh', { 'url': srvUrl });
                        }
                        else {
                            if (userID > 0) {
                                $("#myAlertLabel").html("修改失败！" + doc.message);
                            }
                            else {
                                $("#myAlertLabel").html("添加失败！" + doc.message);
                            }
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