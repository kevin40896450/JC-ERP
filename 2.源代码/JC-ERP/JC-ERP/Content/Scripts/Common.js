var Common = {
    PageSize: 10,//每页显示数量
    PageList: [10, 25, 50, 100],//可选择的每页显示数量集合
    LoadJson: function (filePath, callback, errCallBack, completeFun) {//读取json文件，返回json对象并调用回调函数
        $.getJSON(filePath, function (data) {
            if (callback) {
                callback(data);
            }
        }).fail(function () {
            if (errCallBack) errCallBack();
        })
          .always(function () {
              if (completeFun) completeFun();
          });
    },
    UserStatus:["1","2"],//1 正常  2 离职
    getQueryString: function (name)//根据参数获取url参数值
    {
        var reg = new RegExp("(^|&)" + name.toLocaleLowerCase() + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null)
        { return unescape(r[2]) + window.location.hash; return null; }
    },
    formatDataTime: function (model, formatStr) {//格式化数据，默认格式化为yyyy-MM-dd HH:mm:ss
        if (model == null) return "";
        var t = new Date(model);
        if (isNaN(t))//兼容手机端，IE浏览器
        {
            t = new Date(Date.parse(model.replace(/-/g, "/")));
        }
        if (!formatStr) {
            formatStr = "yyyy-MM-dd HH:mm:ss";
        }
        var o = {
            "yyyy": t.getFullYear(), //年 
            "MM": p(t.getMonth() + 1), //月 
            "dd": p(t.getDate()), //日
            "HH": p(t.getHours()), //小时
            "mm": p(t.getMinutes()), //分钟
            "ss": p(t.getSeconds())//秒
        };
        for (var k in o) {
            formatStr = formatStr.replace(k, o[k]);
        }
        return formatStr;
    }
}

function p(s) {
    return s < 10 ? '0' + s : s;
}