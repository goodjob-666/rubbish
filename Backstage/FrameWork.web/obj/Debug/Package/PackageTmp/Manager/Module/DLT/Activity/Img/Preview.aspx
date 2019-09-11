<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Activity.Img.Preview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>预览图片</title>
     <style type="text/css">
        html, body, div, h1, h2, h3, h4, h5, h6, ul, ol, dl, li, dt, dd, p, blockquote, pre, form, fieldset, table, th, td, span, input, textarea {margin:0;padding:0;}
        body{ font-family:"Microsoft Yahei",Verdana,Arial,Helvetica,sans-serif; font-size: 14px;} 
        li, ol { list-style:none; }
        ins { text-decoration:none; }
        i, em { font-style:normal; }
        a { text-decoration:none;font-family:"Microsoft Yahei";}
        a:hover { cursor:pointer; text-decoration:none;}
        a:active{star:expression(this.onFocus=this.blur());}
        :focus{outline:0;}
        .clear { clear:both; line-height:0px; overflow:hidden; zoom:1; font-size:0px; content:'.';}
        .clearfix:after {visibility: hidden;display: block;font-size: 0;content: " ";clear: both;height: 0;}
        img{ padding:0; margin:0;}
        a img { border:none; }
        input,textarea{ border:none;font-family:"Microsoft Yahei"; }
        h1, h2, h3, h4, h5, h6{ font-weight:normal; font-size: 14px; }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Image ID="Image1" runat="server" />
    </form>
</body>
   
</html>
