var common = new Object();
common.ShowCommonDialog = function () {
    var dialogWidth = $(this).attr("dialogWidth");
    var dialogHeight = $(this).attr("dialogHeight");
    var dialogTitle = $(this).attr("dialogTitle");
    var _dialogCallback = $(this).attr("dialogCallback");
    
    $("body").append("<div id='dialog' title=" + dialogTitle + "><div id='dialogContent'></div></div>");
    var showDialogContent = function (data) {
        var div = $("#dialogContent");
        div.html(data);
    }
    var showDialogResult = function (data) {
        var div = $("#dialogContent");
        if (data == 'OK') {
            if (_dialogCallback) {
                var js = _dialogCallback + '();';
                eval(js);
            }
            $("#dialog").dialog("close");
        }
        else if(data.length>=3 && data.substr(0,3)=="OK:"){
            if (_dialogCallback) {
                var js = _dialogCallback + '('+data.substr(3,data.length-3)+');';
                eval(js);
            }
            $("#dialog").dialog("close");
        }
        else {
            div.html(data);
        }
    }
    
    $("#dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 300
        },
        hide: {
            effect: "Clip",
            duration: 300
        },
        modal: true,
        height: dialogHeight,
        width: dialogWidth,
        buttons: {
            "Submit": function () {
                var frm = $("div#dialogContent form");
                $.post(frm.attr("action"), frm.serialize(), showDialogResult);
                var div = $("#dialogContent");
                div.html('<img src="/Images/loading01.gif" />正在提交，请稍后...');
            },
            "Cancel": function () { $(this).dialog("close"); }
        },
        close: function () {
            $("#dialog").dialog("destroy");
            $("#dialog").remove();
        }
    });

    var div = $("#dialogContent");
    div.html('<img src="/Images/loading01.gif" />Loading...');
    $("#dialog").dialog("open");
    $.get($(this).attr("href"), '', showDialogContent);
    return false;
}

common.ShowModelDialog = function () {
    var _dialogWidth = $(this).attr("dialogWidth");
    var _dialogHeight = $(this).attr("dialogHeight");
    var _dialogTitle = $(this).attr("dialogTitle");
    var _dialogCallback = $(this).attr("dialogCallback");
    $("body").append("<div id='dialog' title=" + _dialogTitle + "><div id='dialogContent'></div></div>");
    var showDialogContent = function (data) {
        var div = $("#dialogContent");
        div.html(data);
        $("#dialogContent a.selectbutton").click(
            function () {
                var js = _dialogCallback + '("' + $(this).attr("callbackDate") + '");';
                eval(js);
                $("#dialog").dialog("close");
            });
    }
    var showDialogResult = function (data) {
        var div = $("#dialogContent");
        if (data == 'OK') {
            alert("OK");
            $("#dialog").dialog("close");
        }
        else {
            div.html(data);
        }
    }
    $("#dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 300
        },
        hide: {
            effect: "Clip",
            duration: 300
        },
        modal: true,
        height: _dialogHeight,
        width: _dialogWidth,
        close: function () {
            $("#dialog").dialog("destroy");
            $("#dialog").remove();
        }
    });
    var div = $("#dialogContent");
    div.html('<img src="/Images/loading01.gif" />Loading...');
    $("#dialog").dialog("open");
    $.get($(this).attr("href"), '', showDialogContent);
    return false;
}

// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2013-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2013-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}
//用于Json时间日期数据格式化
String.prototype.Format = function (fmt) {
    return (new Date(parseInt(this.replace("/Date(", "").replace(")/", ""), 10))).Format(fmt);
}