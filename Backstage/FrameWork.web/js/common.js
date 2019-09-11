/* 调用后台数据  */
function post(url, postData, succssCallback, type, dataType) {
    var type = type || "post";
    var dataType = dataType || "json";
    var path = url;     //移植到APP可以修改为绝对路径
    $.ajax({
        type: type,
        url: path,
        data: postData,
        dataType: dataType,
        beforeSend: function () {  //开始loading
            $(".wrap").css("height", $(window).height() + "px");
            var html = '<div class="loading"><div class="loadingbg"><div class="loading-container loadingcontainer1"><div class="circle1"></div><div class="circle2"></div><div class="circle3"></div><div class="circle4"></div></div><div class="loading-container loadingcontainer2"><div class="circle1"></div><div class="circle2"></div><div class="circle3"></div><div class="circle4"></div></div><div class="loading-container loadingcontainer3"><div class="circle1"></div><div class="circle2"></div><div class="circle3"></div><div class="circle4"></div></div></div></div>';
            if ($(".loading") && $(".loading").length > 0) { }
            else { $(".wrap").append(html); }
            $(".loading").show();
        },
        success: function (res) {
            if (succssCallback) {
                $('.wrap').css('height', '100%');
                $(".loading").hide();
                succssCallback(res);
            }
        },
        complete: function () {
        }
    });
}


/* 调用后台数据 仅用于上拉加载下拉刷新  */
function ajax(url, postData, succssCallback, type, dataType,errorCallback) {
    var type = type || "post";
    var dataType = dataType || "json";
    var path = url;     //移植到APP可以修改为绝对路径
    $.ajax({
        type: type,
        url: path,
        data: postData,
        dataType: dataType,
        success: function (res) {
            if (succssCallback) {
                succssCallback(res);
            }
        },
        error: function (res) {
            if (errorCallback) {
                errorCallback(res);
            }
        },
        complete: function () {
        }
    });
}

/*   获取地址栏的参数    */
function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


/* 返回指定长度的字符串  */
function GetString(s, n) {
    if (s.length > n) {
        return s.substring(0, n);
    }
    return s;
}


/*  弹出提示信息  */
function Alert(content, url,btnName) {
    url = url ? url : "0";
    btnName = btnName ? btnName : "朕知道了";

    $(".wrap").css("height", $(window).height() + "px");
    if ($(".alert") && $(".alert").length > 0) {
        $(".alert").find(".content").html(content);
        $(".alert").attr("url",url).fadeIn();
    } else {
        var html = "<div class=\"alert\"><div class=\"alertbg\"></div><div class=\"alertbody\"><div class=\"top\" onclick=\" CloseAlert() \"><a href=\"javascript:void(0)\" class=\"close\" ></a></div><div class=\"content\">" + content + "</div><div class=\"bottom\"><a href=\"javascript:void(0)\" class=\"btn\" onclick=\" CloseAlert() \">" + btnName + "</a></div></div></div>";
        $(".wrap").append(html);
        $(".alert").attr("url", url);
    }
    window.setTimeout(function () {
        var top = ($(window).height() - $(".alertbody").height()) / 2;
        var scrollTop = $(document).scrollTop();
        $(".alertbody").css({ position: 'absolute', 'top': top + scrollTop });
    }, 0);
}

function CloseAlert() {
    $('.alert').fadeOut('normal', function () {
        $('.wrap').css('height', '100%');
        var url=$(".alert").attr("url");
        if (url != "0") {
            window.location.href = url;
        }
    });
}
/*  弹出提示信息  */


/*  弹出确认信息  */
function Confirm(content, callback, btnName, btnCloseName) {
    btnName = btnName ? btnName : "确 定";
    btnCloseName = btnCloseName ? btnCloseName : "取 消";
    $(".wrap").css("height", $(window).height() + "px");
    var html = "<div class=\"confirm\"><div class=\"alertbg\"></div><div class=\"alertbody\"><div class=\"top\" onclick=\" CloseConfirm() \"><a href=\"javascript:void(0)\" class=\"close\" ></a></div><div class=\"content\">" + content + "</div><div class=\"bottom\"><a href=\"javascript:void(0)\" class=\"btn btnOk\" \">" + btnName + "</a><a href=\"javascript:void(0)\" class=\"btn btnCancel\" onclick=\" CloseConfirm() \">" + btnCloseName + "</a></div></div></div>";
    $(".wrap").append(html);
    $(".confirm").off("click",".btnOk").on("click", ".btnOk", function () {
        $('.confirm').fadeOut('normal', function () {
            if (callback) {
                callback();
            }
            $('.wrap').css('height', '100%');
            $('.confirm').html("").removeClass("confirm");
        });
    });
}

function CloseConfirm() {
    $('.confirm').fadeOut('normal', function () {
        $('.confirm').html("").removeClass("confirm");
        $('.wrap').css('height', '100%');
    });
}
/*  弹出确认信息  */

 
/*  制保留2位小数，如：2，会在2后面补上00.即2.00    */ 
function toDecimal2(x) {
    var f = parseFloat(x);
    if (isNaN(f)) {
        return false;
    }
    var f = Math.round(x * 100) / 100;
    var s = f.toString();
    var rs = s.indexOf('.');
    if (rs < 0) {
        rs = s.length;
        s += '.';
    }
    while (s.length <= rs + 2) {
        s += '0';
    }
    return s;
}

/*  判断设备  */
function IsPC() {
    var userAgentInfo = navigator.userAgent;
    var Agents = ["Android", "iPhone",
                "SymbianOS", "Windows Phone",
                "iPad", "iPod"];
    var flag = true;
    for (var v = 0; v < Agents.length; v++) {
        if (userAgentInfo.indexOf(Agents[v]) > 0) {
            flag = false;
            break;
        }
    }
    return flag;
}
/*  判断设备  */


/*  客户端操作系统  */
function DetectOS() {
    var sUserAgent = navigator.userAgent.toLowerCase();
    if (sUserAgent.match(/micromessenger/i)) return "WeChat";
    if (sUserAgent.match(/android/i)) return "Android";
    if (sUserAgent.match(/(iphone|ipad|ipod|ios)/i)) return "iOS";
    var isWin = (navigator.platform == "Win32") || (navigator.platform == "Windows");
    var isMac = (navigator.platform == "Mac68K") || (navigator.platform == "MacPPC") || (navigator.platform == "Macintosh") || (navigator.platform == "MacIntel");
    if (isMac) return "Mac";
    var isUnix = (navigator.platform == "X11") && !isWin && !isMac;
    if (isUnix) return "Unix";
    var isLinux = (String(navigator.platform).indexOf("Linux") > -1);
    if (isLinux) return "Linux";
    if (isWin) {
        var isWin2K = sUserAgent.indexOf("windows nt 5.0") > -1 || sUserAgent.indexOf("windows 2000") > -1;
        if (isWin2K) return "Win2000";
        var isWinXP = sUserAgent.indexOf("windows nt 5.1") > -1 || sUserAgent.indexOf("windows xp") > -1;
        if (isWinXP) return "WinXP";
        var isWin2003 = sUserAgent.indexOf("windows nt 5.2") > -1 || sUserAgent.indexOf("windows 2003") > -1;
        if (isWin2003) return "Win2003";
        var isWinVista = sUserAgent.indexOf("windows nt 6.0") > -1 || sUserAgent.indexOf("windows vista") > -1;
        if (isWinVista) return "WinVista";
        var isWin7 = sUserAgent.indexOf("windows nt 6.1") > -1 || sUserAgent.indexOf("windows 7") > -1;
        if (isWin7) return "Win7";
    }
    return "other";
}
/*  客户端操作系统  */