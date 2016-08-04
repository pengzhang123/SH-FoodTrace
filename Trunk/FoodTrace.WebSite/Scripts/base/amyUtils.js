var Utils = function () { };

//设置cooike
Utils.setCookie = function (key, val, expiresDay)
{
    if (typeof val == "undefined") return;
    if (typeof key == "string")
        $.cookie(key, val, { expires: expiresDay, path: '/' });
}

//读取cookie
Utils.getCookie = function (key)
{
    return $.cookie(key);
}
//销毁cookie
Utils.disposeCookie = function (key, val)
{
    return $.cookie(key, '', { expires: -1 });
}

//数组转字符串
Utils.arrToStr = function (arr)
{
    if (!$.isArray(arr)) throw "arr";
    return arr.join(',');
}


/// <summary>
/// 借助jquery.validate对form进行有效性验证
/// </summary>
/// <param name="form">form对象</param>
//Utils.validateForm = function (form) {
//    //$('form')
    
//    if (typeof form == "undefined")
//        return null;
//    var validate= form.validate({
//        type: {
//            isChecked: function (value, errorMsg, el) {
//                var i = 0;
//                var $collection = $(el).find('input:checked');
//                if (!$collection.length) {
//                    return errorMsg;
//                }
//            }
//        },
//        onFocus: function () {
//            this.parent().addClass('active');
//            return false;
//        },
//        onBlur: function () {
//            var $parent = this.parent();
//            var _status = parseInt(this.attr('data-status'));
//            $parent.removeClass('active');
//            if (!_status) {
//                $parent.addClass('error');
//            }
//            return false;
//        }
//    });

//    return validate;
//}

Utils.validateForm = function (formObj, submitFn) {
    //$('form')
    formObj.validate({
        submitHandler: function(form) {
            if ($.isFunction(submitFn))
                submitFn();
        }
    });
}

Utils.resetForm=function(formObj) {
    formObj[0].reset();
    var hidenObj = formObj.find('input[type="hidden"]');
    if (hidenObj.length > 0) {
        hidenObj.each(function () {
            $(this).val('');
        });
    }
}
//字符串转换
Utils.formatBoolean = function (val) {
    if (typeof val == "boolean") {
        if (val) return "是";
        else return "否";
    }
    else if (typeof val == "string") {
        if (val.toLowerCase() == "true")
            return "是";
        else return "否";
    }
    return "";


};

//日期格式转换
Utils.formatJsonDateTime = function (d) {
    var date = new Date(parseInt(d.replace("/Date(", "").replace(")/", ""), 10));
    var month = padLeft(date.getMonth() + 1, 10);
    var currentDate = padLeft(date.getDate(), 10);
    var hour = padLeft(date.getHours(), 10);
    var minute = padLeft(date.getMinutes(), 10);
    return date.getFullYear() + "-" + month + "-" + currentDate + " " + hour + ":" + minute;
}

function padLeft(str, min) {
    if (str >= min)
        return str;
    else
        return "0" + str;
}

Utils.ajaxGet = function (ajaxUrl, ajaxData, dataType, success,beforeSend,error, complete) {
    $.ajax({
        async: true,//默认为true异步，如果需要发送同步请求，请将此选项设置为 false。注意，同步请求将锁住浏览器，用户其它操作必须等待请求完成才可以执行。 
        url: ajaxUrl,
        type: "GET",
        data: ajaxData,
        cache: false,
        dataType: dataType,
        success: function (data, textStatus, jqXHr) {
            if ($.isFunction(success)) success(data, textStatus, jqXHr);
        },
        beforeSend: function (data, textStatus, jqXHr) {
            if ($.isFunction(beforeSend)) beforeSend(data, textStatus, jqXHr);
        },
        error: function (jqXHr, textStatus, errorMsg) {
            if ($.isFunction(error)) error(jqXHr, textStatus, errorMsg);
        },
        complete: function (jqXHr, textStatus) {
            if ($.isFunction(complete)) complete(jqXHr, textStatus);
        }

    });
}

Utils.ajaxPost = function (ajaxUrl, ajaxData, dataType, success,beforeSend, error, complete) {
    $.ajax({
        async: true,
        url: ajaxUrl,
        type: "POST",
        data: ajaxData,
        cache: false,
        dataType: dataType,
        success: function (data, textStatus, jqXHr) {
            if ($.isFunction(success)) success(data, textStatus, jqXHr);
        },
        beforeSend: function (data, textStatus, jqXHr) {
            if ($.isFunction(beforeSend)) beforeSend(data, textStatus, jqXHr);
        },
        error: function (jqXHr, textStatus, errorMsg) {
            if ($.isFunction(error)) error(jqXHR, textStatus, errorMsg);
        },
        complete: function (jqXHr, textStatus) {
            if ($.isFunction(complete)) complete(jqXHR, textStatus);
        }
    });
};

Utils.ajaxPostObj = function (ajaxUrl, ajaxData, dataType, success, beforeSend, error, complete) {
    $.ajax({
        async: true,
        url: ajaxUrl,
        type: "POST",
        data: ajaxData,
        cache: false,
        dataType: dataType,
        contentType: 'application/json; charset=utf-8',
        success: function (data, textStatus, jqXHr) {
            if ($.isFunction(success)) success(data, textStatus, jqXHr);
        },
        beforeSend: function (data, textStatus, jqXHr) {
            if ($.isFunction(beforeSend)) beforeSend(data, textStatus, jqXHr);
        },
        error: function (jqXHr, textStatus, errorMsg) {
            if ($.isFunction(error)) error(jqXHR, textStatus, errorMsg);
        },
        complete: function (jqXHr, textStatus) {
            if ($.isFunction(complete)) complete(jqXHR, textStatus);
        }
    });
};

Utils.ajaxDownLoadFile = function ajaxDownload(url, data, method) {
    if (url && data) {
        // data 是 string 或者 array/object
        data = typeof data == 'string' ? data : jQuery.param(data);
        var inputs = '';
        jQuery.each(data.split('&'), function () {
            var pair = this.split('=');
            inputs += '<input type="hidden" name="' + pair[0] + '" value="' + pair[1] + '"/>';
        });
        jQuery('<form action="' + url + '" method="' + (method || 'post') + '">' + inputs + '</form>').appendTo('body').submit().remove();
    }
}

//控件、表单
Utils.loadFormData = function (form, data) {
    if (form == null || typeof data == "undefined")
        return;
    for (var name in data) {
        var val = data[name];
        //!_checkField(name, val&& !_npCombotreeField(name, val)
        if (!_checkField(name, val)) {
            form.find("input[name=\"" + name + "\"]").val(val);
            form.find("textarea[name=\"" + name + "\"]").val(val);
            form.find("select[name=\"" + name + "\"]").val(val);
        }
    }

    function _checkField(pName, pValue) {
        var cc = $(form).find("input[name=\"" + pName + "\"][type=radio], input[name=\"" + pName + "\"][type=checkbox]");
        if (cc.length) {
            //cc._propAttr('checked', false);            
            cc.each(function () {
                var f = $(this);
                f.prop("checked", false);
                if (f.val() === String(pValue) || $.inArray(f.val(), $.isArray(pValue) ? pValue : [pValue]) >= 0) {
                    f.prop("checked", true);
                }
            });
            return true;
        }
        return false;
    }

    //function _npCombotreeField(pName, pValue) {
    //    //npCombotree_target_hidden
    //    //$(form).find("input#Name.npCombotree_target_hidden")
    //    var cc = $(form).find("input#" + pName + ".npCombotree_target_hidden");
    //    if (cc.length) {
    //        try {
    //            //var target = $(cc[0]);
    //            $("#" + pName).npCombotree("setValue", pValue);
    //        } catch (e) {
    //            consoleEx(e);
    //        }
    //        return true;
    //    }
    //    return false;
    //}
};

/*
*（1）在数据集之中，选择一个元素作为"基准"（pivot）。
*（2）所有小于"基准"的元素，都放置于"基准"的"小值区域"（左边）；所有大于"基准"的元素，都被置于"基准"的"大值区域"（右边）。
*（3）对以"基准"为分割线的两个子集，不断重复第一步和第二步，直到所有子集只剩下一个元素为止。
*/
//实例
//var arr = [89, 28, 743, 18, 93, 58, 84, 65];
//console.log("数组元素的原始排列：" + arr.join(","));
//console.log("排序后，数组元素的排列：" + quickSort(arr).join(","));
Utils.arrayQuickSort = function(arr) {
    //返回（如果当前数组不再需要排序时）
    if (arr.length <= 1) return arr;
    //声明两个数组分别用来防止"小值"和"大值"
    var less = [];
    var greater = [];
    //选取被排序数组中的任一元素作为"基准"（这里我们就选取数组中间的元素）
    var pivotIndex = Math.floor(arr.length / 2);
    var pivot = arr.splice(pivotIndex, 1)[0];
    //遍历数组，进行区分操作
    for (var i = 0, len = arr.length; i < len; i++) {
        if (arr[i] < pivot) {
            less.push(arr[i]);
        } else {
            greater.push(arr[i]);
        }
    }
    //最后使用递归不断重复这个过程，直到获得排序后的数组
    return arrayQuickSort(less).concat([pivot], arrayQuickSort(greater));
};

//表格上的全选框事件
Utils.tbCheckToArray = function (chkSelector, childViewSelector, array) {
    if (!$.isArray(array)) {
        return;
    }
    $(chkSelector).change(function () {
        var chooseStatus = $(this).is(":checked");
        $(childViewSelector).find('.chk').each(function () {
            var id = $(this).val();
            var index = array.indexOf(id);
            if (chooseStatus) {
                $(this).prop("checked", true);
                if (index < 0) {
                    array.push(id);
                }

            } else {
                $(this).prop("checked", false);
                if (index > -1) {
                    array.splice(index, 1);
                }
            }
        });
        console.log(array);
    });
}

