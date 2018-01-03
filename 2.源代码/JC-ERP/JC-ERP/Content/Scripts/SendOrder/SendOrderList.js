$(document).ready(function () {
    var oForm = new InitForm();
    oForm.Init();

    var oTable = new InitTable();
    oTable.Init();

    var oButtonInit = new ButtonInit();
    oButtonInit.Init();
});

//初始化表单数据
var InitForm = function () {
    var oInitForm = new Object();
    oInitForm.Init = function () {
        var usersUrl = "/SimpleUsers";
        //加载用户下拉菜单
        $.ajax({
            type: "get",
            url: usersUrl,
            dataType: "json",
            success: function (d) {
                var arrs = [];
                arrs.push({
                    id: 0,
                    text: "全部"
                });
                arrs = arrs.concat(d);
                $("#selUsers").select2({
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
    }
    return oInitForm;
}

var srvUrl = "/SendOrder/Get";

//初始化产品类型表格
var InitTable = function () {
    var oInitTable = new Object();
    oInitTable.Init = function () {
        $('#tb_order').bootstrapTable({
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
            detailView: true,                   //是否显示父子表     
            idField: "orderID",
            onLoadSuccess: function () {
                var oSendTable = new SendTable();
                oSendTable.Init();               
                $(".truck").click(function () {
                    var idx = $(this).attr("val");
                    var order = $("#tb_order").bootstrapTable('getData')[idx];
                    if (order == null) {
                        return;
                    }
                    oSendTable.Reset(order.orderID);

                    $('#myModal').modal({ backdrop: 'static' });
                });
            },
            columns: [{
                field: 'buyer',
                title: '甲方名称'
            }, {
                field: 'proName',
                title: '项目名称'
            }, {
                field: 'OrderId',
                title: '施工地点',
                formatter: function (val, row, idx) {
                    return row.province + row.city + row.area + row.address;
                }
            }, {
                field: 'remarks1',
                title: '备注'
            }, {
                field: 'orderDate',
                title: '合同时间',
                formatter: function (val, row, idx) {
                    return Common.formatDataTime(val, "yyyy-MM-dd");
                }
            }, {
                title: '操作',
                formatter: function (val, row, index) {
                    return '<a  href="javascript:;" class="btn btn-primary truck" val=' + index + '><i class="fa fa-truck"></i>&nbsp;&nbsp;发货</a>';
                }
            }],
            onExpandRow: function (index, row, $detail) {
                var childUrl = "/SendOrder/GetSendList/" + row.orderID;
                LoadChild($detail, childUrl, row.orderID);
            }
        });

        function LoadChild($detail, childUrl, id) {
            var tid = "childTD" + id;
            var $childTd = $detail.html('<table id="' + tid + '"></table>').find('table');
            $childTd.bootstrapTable({
                tableID: tid,//表格容器ID
                url: childUrl,//请求后台的URL（*）
                method: 'get',
                striped: true,                      //是否显示行间隔色
                cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
                sortable: false,                     //是否启用排序
                sortOrder: "asc",                   //排序方式
                sidePagination: "client",           //分页方式：client客户端分页，server服务端分页（*）
                uniqueId: "name",                     //每一行的唯一标识，一般为主键列
                idField: "orderID",                
                columns: [{
                    field: "typeName",
                    title: "业务类型"
                }, {
                    field: "proName",
                    title: "产品类型"
                }, {
                    field: "planNum",
                    title: "合同面积"
                }, {
                    field: "sendArea",
                    title: "已发货面积"
                }]
            });
        }
    }
    return oInitTable;
}

var SendTable = function () {
    var oSend = new Object();
    oSend.Init = function () {
        $('#tb_Send').bootstrapTable({
            data: [],
            striped: false,                      //是否显示行间隔色
            cache: false,                       //是否使用缓存，默认为true，所以一般情况下需要设置一下这个属性（*）
            pagination: false,                   //是否显示分页（*）
            sortable: true,                     //是否启用排序
            sortOrder: "asc",                   //排序方式                
            sidePagination: "client",           //分页方式：client客户端分页，server服务端分页（*）
            search: false,                       //是否显示表格搜索
            strictSearch: false,
            showColumns: false,                  //是否显示所有的列
            showRefresh: false,                  //是否显示刷新按钮
            clickToSelect: false,                //是否启用点击选中行
            showToggle: false,                    //是否显示详细视图和列表视图的切换按钮
            cardView: false,                    //是否显示详细视图
            detailView: false,                   //是否显示父子表     
            idField: "orderDetailID",           
            width: "600",
            columns: [{
                checkbox: true
            }, {
                field: 'typeName',
                title: '业务类型'
            }, {
                field: 'proName',
                title: '产品类型'
            }, {
                field: 'spec',
                title: '规格'
            }, {
                field: 'planNum',
                title: '合同数量'
            }, {
                field: 'sendArea',
                title: '已发货数量'
            }, {
                field: 'orderDetailID',
                title: '发货数量',
                width: "50",
                formatter: function (val, row, idx) {
                    return "<input type='text' id='txtnum" + row.orderDetailID + "'/>";
                }
            }]
        });
    };

    oSend.LoadGroup = function () {
        var groupUrl = "/Group/All";
        //加载用户下拉菜单
        $.ajax({
            type: "get",
            url: groupUrl,
            dataType: "json",
            success: function (d) {
                var arrs = [];
                $.each(d.rows, function (idx, item) {
                    arrs.push({
                        id: item.groupID,
                        text: item.groupName
                    });
                });
                $("#selGroup").select2({
                    data: arrs
                });
            }
        }).fail(function (err) {
            // alert("error");
        }).always(function () {

        });
    };
    oSend.Reset = function (orderId) {
        var sendUrl = "/SendOrder/GetSendList/" + orderId;
        $.ajax({
            type: "get",
            url: sendUrl,
            dataType: "json",
            success: function (d) {
                $('#tb_Send').bootstrapTable('load', d);

                oSend.LoadGroup();
            },
            error: function (err) {

            },
            complete: function () {

            }
        });
    };
    return oSend;
};

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

        $("#myModalForm").find(".btn-primary").click(function () {
            var arrselections = $("#tb_Send").bootstrapTable('getSelections');
            var ids = [];
            if (arrselections.length <= 0)
            {
                alert("请至少选择一项");
                return;
            }

            $.each(arrselections, function (idx, arr) {
                var num = $("#txtnum" + arr.orderDetailID).val();
                ids.push({
                    OrderDetailID: arr.orderDetailID,
                    SendNum: num
                });
            });
            var sendUrl = "/SendOrder/SendOrderAdd";
            var postdata = {
                groupId: $("#selGroup").val(),
                data: JSON.stringify(ids)
            };

            $.ajax({
                type: "post",
                url: sendUrl,
                data: postdata,
                dataType: "json",
                success: function (d) {
                    if (d.statusCode == 200) {
                        $('#myModal').modal('hide');
                        $("#myAlertLabel").html("添加成功!");
                        $('#myAlert').modal();

                        $("#tb_order").bootstrapTable('refresh', { 'url': srvUrl });
                    }
                    else {
                        $("#myAlertLabel").html("添加失败！" + d.message);
                        $('#myAlert').modal();
                    }
                },
                error: function (err) {

                },
                complete: function () {

                }
            });
        });
    };

    return oInit;
};