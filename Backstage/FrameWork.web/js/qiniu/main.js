/*global Qiniu */
/*global plupload */
/*global FileProgress */
/*global hljs */


$(function () {
    var Uptoken;
    var paramInfo = {
        Bucket: 'dailiantong-file',
        Domain: 'http://file02.dailiantong.com/'
    };

    getqiniuuptoken = function (paramInfo, callback) {
        callback = callback || mui.noop;
        var action = "GetQiniuUpToken";
        var params = 'Bucket=' + paramInfo.Bucket;

        var onSuccess = arguments[2] ? arguments[2] : function () { };
        var onError = arguments[3] ? arguments[3] : function () { };
        var retry = arguments[4] ? arguments[4] : 3;
        var func_url = 'http://Server.dailiantong.com:80/API/AppService.ashx?Action=' + action;

        if (params.indexOf("TimeStamp=") == -1) {
            if (params != "") { params += '&'; }
            params += 'TimeStamp=' + Math.round(new Date().getTime() / 1000);
        }
        //版本号
        if (params.indexOf("&Ver=") == -1) {
            params += '&Ver=1.0';
        }

        $.ajax({
            url: func_url,
            type: 'get',
            dataType: 'jsonp',
            jsonp: "callback",
            data: params,
            timeout: 15000,
            jsonpCallback: "callback",
            cache: true,
            beforeSend: function () {

            },
            success: function (data) {
                callback(data);
            },
            error: function (xhr, type, errorThrown) {

            }
        })


    }

    getqiniuuptoken(paramInfo, function (data) {

        Uptoken = data.uptoken;

        var uploader = Qiniu.uploader({
            runtimes: 'html5,flash,html4',
            browse_button: 'pickfiles',
            container: 'container',
            drop_element: 'container',
            max_file_size: '10mb',
            flash_swf_url: 'Moxie.swf',
            dragdrop: true,
            chunk_size: '4mb',
            multi_selection: false, //是否允许同时选择多文件
            filters: {
                mime_types: [
                    { title: "Image files", extensions: "jpg,jpeg,gif,png" }
                  ]
            },
            uptoken: Uptoken,
            // uptoken_func: function(){
            //     var ajax = new XMLHttpRequest();
            //     ajax.open('GET', $('#uptoken_url').val(), false);
            //     ajax.setRequestHeader("If-Modified-Since", "0");
            //     ajax.send();
            //     if (ajax.status === 200) {
            //         var res = JSON.parse(ajax.responseText);
            //         console.log('custom uptoken_func:' + res.uptoken);
            //         return res.uptoken;
            //     } else {
            //         console.log('custom uptoken_func err');
            //         return '';
            //     }
            // },
            domain: paramInfo.Domain,
            get_new_uptoken: false,
            // downtoken_url: '/downtoken',
            unique_names: false,
            save_key: false,
            // x_vars: {
            //     'id': '1234',
            //     'time': function(up, file) {
            //         var time = (new Date()).getTime();
            //         // do something with 'time'
            //         return time;
            //     },
            // },
            auto_start: true,
            log_level: 5,
            init: {
                'FilesAdded': function (up, files) {

                },
                'BeforeUpload': function (up, file) {

                },
                'UploadProgress': function (up, file) {

                },
                'UploadComplete': function () {

                },
                'FileUploaded': function (up, file, info) {
                    var res = eval('(' + info + ')');
                    var fileName = paramInfo.Domain + res.key;
                    $('#iconhead').attr('src', paramInfo.Domain + res.key);
                    var url = "MyAjax.ashx?action=updatefigureurl&t=" + Math.random();
                    post(url, { "FileName": fileName }, function (json) {
                        if (json != "" && json.length > 0) {
                            //Alert(json[0].Err);
                        } else {
                            window.location.href = "login.aspx";

                        }
                    });
                },
                'Error': function (up, err, errTip) {
                    Alert("目前只支持图片格式：jpg,jpeg,gif,png");
                    //上传出错时,处理相关的事情
                 },
                'Key': function (up, file) {
                    //当save_key和unique_names设为false时，该方法将被调用
                    var key = "";
                    var url = "../../MyAjax.ashx?action=filename_random&t=" + Math.random();
                    $.ajax({
                        url: url,
                        type: 'GET',
                        async: false, //这里应设置为同步的方式
                        success: function (data) {
                            var ext = Qiniu.getFileExtension(file.name);
                            key = data + '.' + ext;
                        },
                        cache: false
                    });
                    return key;
                }
            }
        });

        uploader.bind('FileUploaded', function () {

        });
        $('#container').on(
        'dragenter',
        function (e) {
            e.preventDefault();
            $('#container').addClass('draging');
            e.stopPropagation();
        }
    ).on('drop', function (e) {
        e.preventDefault();
        $('#container').removeClass('draging');
        e.stopPropagation();
    }).on('dragleave', function (e) {
        e.preventDefault();
        $('#container').removeClass('draging');
        e.stopPropagation();
    }).on('dragover', function (e) {
        e.preventDefault();
        $('#container').addClass('draging');
        e.stopPropagation();
    });



        $('#show_code').on('click', function () {
            $('#myModal-code').modal();
            $('pre code').each(function (i, e) {
                hljs.highlightBlock(e);
            });
        });


        $('body').on('click', 'table button.btn', function () {
            $(this).parents('tr').next().toggle();
        });


        var getRotate = function (url) {
            if (!url) {
                return 0;
            }
            var arr = url.split('/');
            for (var i = 0, len = arr.length; i < len; i++) {
                if (arr[i] === 'rotate') {
                    return parseInt(arr[i + 1], 10);
                }
            }
            return 0;
        };

        $('#myModal-img .modal-body-footer').find('a').on('click', function () {
            var img = $('#myModal-img').find('.modal-body img');
            var key = img.data('key');
            var oldUrl = img.attr('src');
            var originHeight = parseInt(img.data('h'), 10);
            var fopArr = [];
            var rotate = getRotate(oldUrl);
            if (!$(this).hasClass('no-disable-click')) {
                $(this).addClass('disabled').siblings().removeClass('disabled');
                if ($(this).data('imagemogr') !== 'no-rotate') {
                    fopArr.push({
                        'fop': 'imageMogr2',
                        'auto-orient': true,
                        'strip': true,
                        'rotate': rotate,
                        'format': 'png'
                    });
                }
            } else {
                $(this).siblings().removeClass('disabled');
                var imageMogr = $(this).data('imagemogr');
                if (imageMogr === 'left') {
                    rotate = rotate - 90 < 0 ? rotate + 270 : rotate - 90;
                } else if (imageMogr === 'right') {
                    rotate = rotate + 90 > 360 ? rotate - 270 : rotate + 90;
                }
                fopArr.push({
                    'fop': 'imageMogr2',
                    'auto-orient': true,
                    'strip': true,
                    'rotate': rotate,
                    'format': 'png'
                });
            }

            $('#myModal-img .modal-body-footer').find('a.disabled').each(function () {

                var watermark = $(this).data('watermark');
                var imageView = $(this).data('imageview');
                var imageMogr = $(this).data('imagemogr');

                if (watermark) {
                    fopArr.push({
                        fop: 'watermark',
                        mode: 1,
                        image: 'http://www.b1.qiniudn.com/images/logo-2.png',
                        dissolve: 100,
                        gravity: watermark,
                        dx: 100,
                        dy: 100
                    });
                }

                if (imageView) {
                    var height;
                    switch (imageView) {
                        case 'large':
                            height = originHeight;
                            break;
                        case 'middle':
                            height = originHeight * 0.5;
                            break;
                        case 'small':
                            height = originHeight * 0.1;
                            break;
                        default:
                            height = originHeight;
                            break;
                    }
                    fopArr.push({
                        fop: 'imageView2',
                        mode: 3,
                        h: parseInt(height, 10),
                        q: 100,
                        format: 'png'
                    });
                }

                if (imageMogr === 'no-rotate') {
                    fopArr.push({
                        'fop': 'imageMogr2',
                        'auto-orient': true,
                        'strip': true,
                        'rotate': 0,
                        'format': 'png'
                    });
                }
            });

            var newUrl = Qiniu.pipeline(fopArr, key);

            var newImg = new Image();
            img.attr('src', 'images/loading.gif');
            newImg.onload = function () {
                img.attr('src', newUrl);
                img.parent('a').attr('href', newUrl);
            };
            newImg.src = newUrl;
            return false;
        });



    });
});