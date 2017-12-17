//当前产品列表数量
var tempNum = 0;
$(document).ready(function () {
    var oForm = new InitForm();
    oForm.Init();
   
    var oButtonInit = new ButtonInit();
   // oButtonInit.Init();

    $('#myForm').bootstrapValidator({
        //        live: 'disabled',
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            groupName: {
                validators: {
                    notEmpty: {
                        message: '组名称不能为空'
                    }
                }
            }
        }
    });

    $('#btnAdd').click(function () {
        var $form = $('#myForm');
        var data = $form.data('bootstrapValidator');
        if (data) {
            // 修复记忆的组件不验证
            data.validate();

            if (data.isValid()) {
                var action = $form.attr("action");
                var postdata = $form.serializeArray();
                
                $.post(action, postdata
                    ).done(function (doc) {
                        if (doc.statusCode == 200) {
                            $("#myAlertLabel").html("添加成功！");
                            $('#myAlert').modal();
                            window.location.href = "/group/List";
                        }
                        else {
                            $("#myAlertLabel").html("添加失败！" + doc.message);
                            $('#myAlert').modal();
                        }
                    }).fail(function (ex) {
                    }).always(function () {

                    });
            }
        }
    });

});

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
                $("#selUser").select2({
                    data: d
                });

                $("#selMember").select2({
                    data: d
                });
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });
    }
    return oInitForm;
}