var Common = {
    LoadJson: function (filePath,callback,errCallBack,completeFun) {//读取json文件，返回json对象并调用回调函数
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
    getQueryString: function (name)//根据参数获取url参数值
    {
        var reg = new RegExp("(^|&)" + name.toLocaleLowerCase() + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
}