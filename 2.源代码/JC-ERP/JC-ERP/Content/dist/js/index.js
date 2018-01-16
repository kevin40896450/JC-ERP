$(document).ready(function () {
    $('#myPwdModalForm').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            oldPwd: {
                validators: {
                    notEmpty: {
                        message: '原始密码不能为空'
                    }
                }
            },
            newPwd: {
                message: '密码无效',
                validators: {
                    notEmpty: {
                        message: '密码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 30,
                        message: '用户名长度必须在6到30之间'
                    }                   
                }
            },
            confirmPwd: {
                message: '密码无效',
                validators: {
                    notEmpty: {
                        message: '确认密码不能为空'
                    },
                    stringLength: {
                        min: 6,
                        max: 30,
                        message: '用户名长度必须在6到30之间'
                    },
                    identical: {//相同
                        field: 'newPwd',
                        message: '两次密码不一致'
                    }
                }
            },
        }
    });

    $("#changePwd").click(function () {
        $('#myPwdModal').modal({ backdrop: 'static' });
    });

    $("#myPwdModalForm").find(".btn-primary").click(function () {
        var $form = $('#myPwdModalForm');
        var data = $form.data('bootstrapValidator');
        if (data) {
            // 修复记忆的组件不验证
            data.validate();

            if (data.isValid()) {
                var postdata = $form.serializeArray();
                var action = $("#myPwdModalForm").attr("action");
                $.post(action, postdata
                    ).done(function (doc) {
                        if (doc.statusCode == 200) {
                            $('#myPwdModal').modal('hide');
                            $("#myPwdMsg").html("修改成功！密码：" + $("#newPwd").val() + "，请牢记!");
                            $('#myPwdAlert').modal();
                        }
                        else {
                            $("#myPwdMsg").html("修改失败！" + doc.message);
                            $('#myPwdAlert').modal();
                        }
                    }).fail(function (ex) {
                    }).always(function () {

                    });
            }
        }
    });
});