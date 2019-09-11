/*
Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    config.toolbar = [
        ["Source", "-", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock"],
        ["Bold", "Italic", "-", "NumberedList", "BulletedList", "-", "Link", "Unlink", "Image"],
        ["Cut", "Copy", "Paste", "PasteText", "PasteFromWord"],
        ["TextColor", "BGColor","Styles", "Format", "Font", "FontSize"]
    ];
   
    config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html'; //上传文件时浏览服务文件夹
    config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?Type=Images'; //上传图片时浏览服务文件夹
    config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?Type=Flash';  //上传Flash时浏览服务文件夹
    config.filebrowserUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files'; //上传文件按钮(标签)
    config.filebrowserImageUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images'; //上传图片按钮(标签)
    config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'; //上传Flash按钮(标签)
};
