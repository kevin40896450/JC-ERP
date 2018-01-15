//当前产品列表数量
var tempNum = 0;
$(document).ready(function () {
    var oForm = new InitForm();
    oForm.Init();

    var oTable = new InitTable();
    oTable.Init();

    var oButtonInit = new ButtonInit();
    oButtonInit.Init();

    $('#myForm').bootstrapValidator({
        //        live: 'disabled',
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            buyer: {
                validators: {
                    notEmpty: {
                        message: '甲方名称不能为空'
                    }
                }
            },
            proName: {
                validators: {
                    notEmpty: {
                        message: '项目名称不能为空'
                    }
                }
            },
            orderdate: {
                validators: {
                    notEmpty: {
                        message: '下单日期不能为空'
                    }
                }
            },
            address: {
                validators: {
                    notEmpty: {
                        message: '详细地址不能为空'
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
                if ($("#Province").val() == "") {
                    $("#myAlertLabel").html("请选择省份!");
                    $('#myAlert').modal();
                    $("#btnAdd").removeAttr("disabled");
                    return false;
                }
                if ($("#City").val() == "") {
                    $("#myAlertLabel").html("请选择市!");
                    $('#myAlert').modal();
                    $("#btnAdd").removeAttr("disabled");
                    return false;
                }
                if ($("#Area").val() == "") {
                    $("#myAlertLabel").html("请选择区!");
                    $('#myAlert').modal();
                    $("#btnAdd").removeAttr("disabled");
                    return false;
                }

                var tableData = $("#tb_data").bootstrapTable('getData');
                if (tableData.length == 0)
                {
                    $("#myAlertLabel").html("请录入产品清单!");
                    $('#myAlert').modal();
                    $("#btnAdd").removeAttr("disabled");
                    return false;
                }
                postdata.push({ name: "data", value: JSON.stringify(tableData) });
                $.post(action, postdata
                    ).done(function (doc) {
                        if (doc.statusCode == 200) {
                            $("#myAlertLabel").html("添加成功!");
                            $('#myAlert').modal();
                            window.location.href = "/Order/List";
                        }
                        else
                        {
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
                $("#selUsers").select2({
                    data: d
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

        var path = "/Content/Address.json";
        Common.LoadJson(path, function (d) {
            $('#myAddress').cxSelect({
                selects: ["Province", "City", "Area"],
                jsonValue: 'name',
                jsonName: "name",
                data: d
            });
        });

        var srvUrl2 = "/Order/BizType/List";
        $.ajax({
            type: "get",
            url: srvUrl2,
            dataType: "json",
            success: function (d) {
                var dd = [];
                $.each(d, function (idx, arr) {
                    dd.push({ id: arr.bizTypeName, text: arr.bizTypeName });
                });
                $("#selType").select2({
                    data: dd
                });
                $("#selType").on("select2:select",
                    function (e) {
                        var type = $("#selType").val();
                        var pro = new ProType();
                        pro.Init(type);
                    });
                var p = new ProType();
                p.Init($("#selType").val());
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });

        $('#myModalForm').bootstrapValidator({
            message: 'This value is not valid',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {                
                Total: {
                    validators: {
                        notEmpty: {
                            message: '金额不能为空'
                        },
                        numeric: {
                            required: true,
                            message: '必须是数字'
                        }
                    }
                },
                price: {
                    validators: {
                        notEmpty: {
                            message: '金额不能为空'
                        },
                        numeric: {
                            required: true,
                            message: '必须是数字'
                        }
                    }
                }
            }
        });
    }
    return oInitForm;
}

//初始化产品类型表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {        
        $('#tb_data').bootstrapTable({
            toolbar: '#toolbar',                //工具按钮用哪个容器
            striped: false,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式
            search: false,                       //是否显示表格搜索
            striped: true,                      //是否显示行间隔色
            strictSearch: true,
            showColumns: true,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            minimumCountColumns: 2,             //最少允许的列数
            clickToSelect: true,                //是否启用点击选中行
            uniqueId: "id",                     //每一行的唯一标识，一般为主键列
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表
            columns: [{
                checkbox: true
            }, {
                field: 'ProTypeID',
                title: '',
                visible: false
            }, {
                field: 'TypeName',
                title: '业务类型',
                width: 100
            }, {
                field: 'ProName',
                title: '产品类型',
                width: 150
            }, {
                field: 'Spec',
                title: '规格',
                width: 150
            }, {
                field: 'PlanNum',
                title: '数量',
                width: 100
            }, {
                field: 'Price',
                title: '单价',
                width: 100
            }, {
                field: 'Total',
                title: '金额',
                width: 100
            }, {
                field: 'Remark',
                title: '备注'
            }]
        });
    }
    return oInitTable;
}

var ButtonInit = function () {
    var oInit = new Object();
    var postdata = {};
    var srvSubmitUrl = "";
    oInit.Init = function () {
        $("#btn_Add").click(function () {
            $("#Spec").val("");
            $("#PlanNum").val("");
            $("#price").val("");
            $("#Total").val("");
            $("#remark").val("");
            $('#myModal').modal({ backdrop: 'static' });
        });

        $("#btn_del").click(function () {
            var arrselections = $("#tb_data").bootstrapTable('getSelections');
            if (arrselections.length <= 0) {
                $("#myAlertLabel").html("请选择有效数据!");
                $('#myAlert').modal();
                return;
            }
            var ids = $.map($("#tb_data").bootstrapTable('getSelections'), function (row) {
                return row.id;
            });
            $("#tb_data").bootstrapTable('remove', {
                field: 'id',
                values: ids
            });
            tempNum = tempNum - arrselections.length;
            for (var i = 0; i < tempNum; i++)
            {
                $("#tb_data").bootstrapTable('updateCell', {
                    index: i,
                    field: 'id',
                    values: i + 1
                });
            }            
        });

        $("#PlanNum").bind("blur", function () {
            GetTotal();
        });

        $("#price").bind("blur", function () {
            GetTotal();
        });

        function GetTotal()
        {
            var num = parseFloat($("#PlanNum").val());
            var price = parseFloat($("#price").val());
            if (!isNaN(num) && !isNaN(price)) {
                var total = num * price;
                $("#Total").val(total.toFixed("2"));
            }
        }

        $("#myModal").find(".btn-primary").click(function () {
            var $form = $('#myModalForm');
            var data = $form.data('bootstrapValidator');
            if (data) {
                // 修复记忆的组件不验证
                data.validate();

                if (data.isValid()) {
                    var pid = $("#Spec").attr("gid");
                    var tname = $("#selType").find("option:selected").text();
                    var pname = $("#selProType").find("option:selected").text();
                    var sp = $("#Spec").val();
                    var plannum = $("#PlanNum").val();
                    var price = $("#price").val();
                    var total = $("#Total").val();
                    var remark = $("#remark").val();
                    var newrow = new Object();
                    newrow.id= tempNum + 1;
                    newrow.ProTypeID = pid;
                    newrow.TypeName = tname;
                    newrow.ProName = pname;
                    newrow.Spec = sp;
                    newrow.PlanNum = plannum;
                    newrow.Price = price;
                    newrow.Total = total;
                    newrow.Remark = remark;
                    $("#tb_data").bootstrapTable('insertRow', {
                        index: tempNum,
                        row: newrow
                    });
                    tempNum++;
                    $('#myModal').modal('hide');
                }
            }
        });
    };

    return oInit;
};

var ProType = function()
{
    var oPro = new Object();
    oPro.Init = function (bizType) {
        var srvUrl = "/Order/ProType/List/" + bizType;
        $.ajax({
            type: "get",
            url: srvUrl,
            dataType: "json",
            success: function (d) {
                var dd = [];
                $.each(d, function (idx, arr) {
                    dd.push({ id: arr.proTypeID, text: arr.proName, val: arr.proGroupID });
                });
                $("#selProType").empty();
                $("#selProType").select2({
                    data: dd
                });
                $("#Spec").val("");
                $("#Spec").attr("gid", dd[0].id);
                SetProType(dd[0].val);
                $("#selProType").on("select2:select",
                    function (e) {
                        var obj = e.params.data;
                        var id = obj.id;
                        var groupID = obj.val;
                        $("#Spec").val("");
                        $("#Spec").attr("gid", id);
                        SetProType(groupID);                        
                });
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });

        function SetProType(typeID)
        {
            $("#Spec").attr("disabled", false);
            var IsAuto = false;//是否启用自动计算
            switch(typeID)
            {
                case 1:
                    Inputmask("99K99K99P").mask("#Spec");
                    $("#PlanNum").inputmask("decimal", { "placeholder": "栋" });
                    IsAuto = true;
                    break;
                case 2:
                    Inputmask("长99.9米X宽99.9米").mask("#Spec");
                    $("#PlanNum").inputmask("decimal", { "placeholder": "个" });
                    break;
                case 3:
                    Inputmask("长99.9米X高9米").mask("#Spec");
                    $("#PlanNum").inputmask("decimal", { "placeholder": "米" });
                    break;
                case 4:
                    $("#Spec").attr("disabled", true);
                    $("#PlanNum").inputmask("decimal", { "placeholder": "㎡" });
                    break;
                default:
                    $("#Spec").attr("disabled", true);
                    $("#PlanNum").inputmask("decimal", { "placeholder": "元" });
                    break;
            }
            if (IsAuto)
            {
                $("#Spec").bind("blur", { d: typeID }, function (e) {
                    var id = e.data.d;
                    $("#PlanNum").val(id);
                });
            }
            else
            {
                $("#Spec").unbind("blur");
            }
        }
    }
    return oPro;
}
