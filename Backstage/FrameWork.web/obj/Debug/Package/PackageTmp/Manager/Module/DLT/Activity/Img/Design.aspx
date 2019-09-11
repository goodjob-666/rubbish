<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Design.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Activity.Img.Design" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>设计图片</title>
    <link rel="stylesheet" href="../../../../../css/colpick.css" type="text/css" />
    <style type="text/css">
        html, body, div, h1, h2, h3, h4, h5, h6, ul, ol, dl, li, dt, dd, p, blockquote, pre, form, fieldset, table, th, td, span, input, textarea {margin:0;padding:0;}
        body{ font-family:"Microsoft Yahei",Verdana,Arial,Helvetica,sans-serif; font-size: 14px;} 
        li, ol { list-style:none; }
        ins { text-decoration:none; }
        i, em { font-style:normal; }
        .fl { float:left; }
        .fr { float:right; }
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
        table td{ line-height:40px;}
        .left{float:left;}
        .text1{ border:solid 1px #808080; width:200px;height:30px;}
        .l-top,.l-bottom{margin-left:60px;}
        .word{ position:absolute; top:0px; left:0px;overflow:hidden;cursor:pointer;  }
        .image{ position:absolute; top:300px; left:200px;cursor:pointer; width:0; height:0; border-radius:128px; }
        .btn1 { border:1px solid #808080; width:80px; height:25px; }
        .btn2 { border:1px solid #808080; padding:2px 10px; }
        #img1{ border:1px solid #808080;}
      
 @font-face{font-family: 'simkai';src : url('/fonts/simkai.ttf');}
 @font-face{font-family: 'SIMLI';src : url('/fonts/SIMLI.ttf');}
 @font-face{font-family: 'simfang';src : url('/fonts/simfang.ttf');}
 @font-face{font-family: 'simhei';src : url('/fonts/simhei.ttf');}
 @font-face{font-family: 'SIMYOU';src : url('/fonts/SIMYOU.ttf');}
 @font-face{font-family: 'STXINWEI';src : url('/fonts/STXINWEI.ttf');}
 @font-face{font-family: 'STXINGKA';src : url('/fonts/STXINGKA.ttf');}
 @font-face{font-family: 'STLITI';src : url('/fonts/STLITI.ttf');}
 @font-face{font-family: 'STHUPO';src : url('/fonts/STHUPO.ttf');}
 @font-face{font-family: 'stcaiyun';src : url('/fonts/stcaiyun.ttf');}
 @font-face{font-family: 'STFANGSO';src : url('/fonts/STFANGSO.ttf');}
 @font-face{font-family: 'STZHONGS';src : url('/fonts/STZHONGS.ttf');}
 @font-face{font-family: 'STSONG';src : url('/fonts/STSONG.ttf');}
 @font-face{font-family: 'STKAITI';src : url('/fonts/STKAITI.ttf');}
 @font-face{font-family: 'STXIHEI';src : url('/fonts/STXIHEI.ttf');}
 @font-face{font-family: '手写大象体';src : url('/fonts/手写大象体.ttf');}
 @font-face{font-family: 'DFPShaoNvW5-GB';src : url('/fonts/DFPShaoNvW5-GB.ttf');}
 @font-face{font-family: '华康雅宋体W9';src : url('/fonts/华康雅宋体W9.ttf');}
 @font-face{font-family: '华康娃娃体W5';src : url('/fonts/华康娃娃体W5.ttf');}
 @font-face{font-family: '华康少女体';src : url('/fonts/华康少女体.ttf');}
 @font-face{font-family: '陈晓江哈哈手写简体';src : url('/fonts/陈晓江哈哈手写简体.ttf');}
 @font-face{font-family: '我的情人';src : url('/fonts/我的情人.ttf');}
 @font-face{font-family: '汉真广标';src : url('/fonts/汉真广标.ttf');}
 @font-face{font-family: '简剪纸';src : url('/fonts/简剪纸.ttf');}
 @font-face{font-family: '简启体';src : url('/fonts/简启体.ttf');}
 @font-face{font-family: '迷你简菱心';src : url('/fonts/迷你简菱心.ttf');}
 @font-face{font-family: '颜简体';src : url('/fonts/颜简体.ttf');}
 @font-face{font-family: '生日快乐';src : url('/fonts/生日快乐.ttf');}
 @font-face{font-family: 'FZLSJW';src : url('/fonts/FZLSJW.ttf');}
 @font-face{font-family: '方正隶书_GBK';src : url('/fonts/方正隶书_GBK.ttf');}
 @font-face{font-family: 'FZFSJW';src : url('/fonts/FZFSJW.ttf');}
 @font-face{font-family: 'FZHPJW';src : url('/fonts/FZHPJW.ttf');}
 @font-face{font-family: 'FZXBSJW';src : url('/fonts/FZXBSJW.ttf');}
 @font-face{font-family: '方正大标宋简体';src : url('/fonts/方正大标宋简体.ttf');}
 @font-face{font-family: 'FZXKJW';src : url('/fonts/FZXKJW.ttf');}
 @font-face{font-family: '方正楷体简体';src : url('/fonts/方正楷体简体.ttf');}
 @font-face{font-family: 'FZZDXJW';src : url('/fonts/FZZDXJW.ttf');}
 @font-face{font-family: '方正中等线_GBK';src : url('/fonts/方正中等线_GBK.ttf');}
 @font-face{font-family: '方正黑体简体';src : url('/fonts/方正黑体简体.ttf');}
 @font-face{font-family: 'FZBSJW';src : url('/fonts/FZBSJW.ttf');}
 @font-face{font-family: 'FZDHTJW';src : url('/fonts/FZDHTJW.ttf');}
 @font-face{font-family: 'FZLBJW';src : url('/fonts/FZLBJW.ttf');}
 @font-face{font-family: 'FZMHJW';src : url('/fonts/FZMHJW.ttf');}
 @font-face{font-family: 'FZS3JW';src : url('/fonts/FZS3JW.ttf');}
 @font-face{font-family: 'FZSHJW';src : url('/fonts/FZSHJW.ttf');}
 @font-face{font-family: 'FZSSJW';src : url('/fonts/FZSSJW.ttf');}
 @font-face{font-family: 'FZSTJW';src : url('/fonts/FZSTJW.ttf');}
 @font-face{font-family: 'FZSZJW';src : url('/fonts/FZSZJW.ttf');}
 @font-face{font-family: 'FZWBJW';src : url('/fonts/FZWBJW.ttf');}
 @font-face{font-family: 'FZXH1JW';src : url('/fonts/FZXH1JW.ttf');}
 @font-face{font-family: 'FZY1JW';src : url('/fonts/FZY1JW.ttf');}
 @font-face{font-family: 'FZYTJW';src : url('/fonts/FZYTJW.ttf');}
 @font-face{font-family: '方正超粗黑简体';src : url('/fonts/方正超粗黑简体.ttf');}
 @font-face{font-family: '方正粗活意简体';src : url('/fonts/方正粗活意简体.ttf');}
 @font-face{font-family: '方正粗倩简体';src : url('/fonts/方正粗倩简体.ttf');}
 @font-face{font-family: '方正粗宋简体';src : url('/fonts/方正粗宋简体.ttf');}
 @font-face{font-family: '方正粗谭黑简体';src : url('/fonts/方正粗谭黑简体.ttf');}
 @font-face{font-family: '方正粗圆简体';src : url('/fonts/方正粗圆简体.ttf');}
 @font-face{font-family: '方正方魅简体';src : url('/fonts/方正方魅简体.ttf');}
 @font-face{font-family: '方正黄草简体';src : url('/fonts/方正黄草简体.ttf');}
 @font-face{font-family: '方正卡通简体';src : url('/fonts/方正卡通简体.ttf');}
 @font-face{font-family: '方正康体简体';src : url('/fonts/方正康体简体.ttf');}
 @font-face{font-family: '方正流行体简体';src : url('/fonts/方正流行体简体.ttf');}
 @font-face{font-family: '方正胖娃简体';src : url('/fonts/方正胖娃简体.ttf');}
 @font-face{font-family: '方正咆哮体';src : url('/fonts/方正咆哮体.ttf');}
 @font-face{font-family: '方正启体简体';src : url('/fonts/方正启体简体.ttf');}
 @font-face{font-family: '方正清刻本悦宋简体';src : url('/fonts/方正清刻本悦宋简体.ttf');}
 @font-face{font-family: '方正尚酷简体';src : url('/fonts/方正尚酷简体.ttf');}
 @font-face{font-family: '方正宋刻本秀楷简';src : url('/fonts/方正宋刻本秀楷简.ttf');}
 @font-face{font-family: '方正细等线简体';src : url('/fonts/方正细等线简体.ttf');}
 @font-face{font-family: '方正细珊瑚简体';src : url('/fonts/方正细珊瑚简体.ttf');}
 @font-face{font-family: '方正小篆体';src : url('/fonts/方正小篆体.ttf');}
 @font-face{font-family: '方正硬笔行书简体';src : url('/fonts/方正硬笔行书简体.ttf');}
 @font-face{font-family: '方正毡笔黑简体';src : url('/fonts/方正毡笔黑简体.ttf');}
 @font-face{font-family: '方正正大黑简体';src : url('/fonts/方正正大黑简体.ttf');}
 @font-face{font-family: '方正准圆简体';src : url('/fonts/方正准圆简体.ttf');}
 @font-face{font-family: '方正字迹-曾正国楷体';src : url('/fonts/方正字迹-曾正国楷体.ttf');}
 @font-face{font-family: '方正综艺简体';src : url('/fonts/方正综艺简体.ttf');}
 @font-face{font-family: '汉仪白棋体简';src : url('/fonts/汉仪白棋体简.ttf');}
 @font-face{font-family: '汉仪柏青体简';src : url('/fonts/汉仪柏青体简.ttf');}
 @font-face{font-family: '汉仪超粗黑简';src : url('/fonts/汉仪超粗黑简.ttf');}
 @font-face{font-family: '汉仪大黑简';src : url('/fonts/汉仪大黑简.ttf');}
 @font-face{font-family: '汉仪楷体简';src : url('/fonts/汉仪楷体简.ttf');}
 @font-face{font-family: '汉仪力量黑简';src : url('/fonts/汉仪力量黑简.ttf');}
 @font-face{font-family: '汉仪菱心体简';src : url('/fonts/汉仪菱心体简.ttf');}
 @font-face{font-family: '汉仪娃娃篆简';src : url('/fonts/汉仪娃娃篆简.ttf');}
 @font-face{font-family: '汉仪细等线简';src : url('/fonts/汉仪细等线简.ttf');}
 @font-face{font-family: '汉仪秀英体简';src : url('/fonts/汉仪秀英体简.ttf');}
 @font-face{font-family: '汉仪中等线简';src : url('/fonts/汉仪中等线简.ttf');}
 @font-face{font-family: 'HYDaiYuTiJ';src : url('/fonts/HYDaiYuTiJ.ttf');}
 @font-face{font-family: 'HYHaiWenTiJ';src : url('/fonts/HYHaiWenTiJ.ttf');}
 @font-face{font-family: 'HYLiuZiHeiJ';src : url('/fonts/HYLiuZiHeiJ.ttf');}
 @font-face{font-family: 'HYRuiYiSongW';src : url('/fonts/HYRuiYiSongW.ttf');}
 @font-face{font-family: 'HYShiGuangTiW';src : url('/fonts/HYShiGuangTiW.ttf');}
 @font-face{font-family: 'HYTangTangTiJ';src : url('/fonts/HYTangTangTiJ.ttf');}
 @font-face{font-family: 'HYXiaoBoMeiYanTiW';src : url('/fonts/HYXiaoBoMeiYanTiW.ttf');}
 @font-face{font-family: 'HYXiaoMaiTiJ';src : url('/fonts/HYXiaoMaiTiJ.ttf');}
 @font-face{font-family: 'HYZhuZiMeiXinTiW';src : url('/fonts/HYZhuZiMeiXinTiW.ttf');}
 @font-face{font-family: '叶根友奥运字体';src : url('/fonts/叶根友奥运字体.ttf');}
 @font-face{font-family: '叶根友蚕燕隶书';src : url('/fonts/叶根友蚕燕隶书.ttf');}
 @font-face{font-family: '叶根友蚕燕隶书';src : url('/fonts/叶根友蚕燕隶书.ttf');}
 @font-face{font-family: '叶根友刀锋黑草';src : url('/fonts/叶根友刀锋黑草.ttf');}
 @font-face{font-family: '叶根友非主流手写';src : url('/fonts/叶根友非主流手写.ttf');}
 @font-face{font-family: '叶根友风帆特色';src : url('/fonts/叶根友风帆特色.ttf');}
 @font-face{font-family: '叶根友钢笔行书简体';src : url('/fonts/叶根友钢笔行书简体.ttf');}
 @font-face{font-family: '叶根友疾风草书';src : url('/fonts/叶根友疾风草书.ttf');}
 @font-face{font-family: '叶根友空心简体';src : url('/fonts/叶根友空心简体.ttf');}
 @font-face{font-family: '叶根友毛笔行书';src : url('/fonts/叶根友毛笔行书.ttf');}
 @font-face{font-family: '叶根友签名体';src : url('/fonts/叶根友签名体.ttf');}
 @font-face{font-family: '叶根友神工体';src : url('/fonts/叶根友神工体.ttf');}
 @font-face{font-family: '叶根友特楷简体';src : url('/fonts/叶根友特楷简体.ttf');}
 @font-face{font-family: '叶根友特隶简体';src : url('/fonts/叶根友特隶简体.ttf');}
 @font-face{font-family: '叶根友特色简体';src : url('/fonts/叶根友特色简体.ttf');}
 @font-face{font-family: '叶根友特色空心简体终极版';src : url('/fonts/叶根友特色空心简体终极版.ttf');}
 @font-face{font-family: '叶根友圆趣卡通体';src : url('/fonts/叶根友圆趣卡通体.ttf');}
 @font-face{font-family: '兰亭粗黑简';src : url('/fonts/兰亭粗黑简.ttf');}
 @font-face{font-family: '兰亭黑简';src : url('/fonts/兰亭黑简.ttf');}
 @font-face{font-family: '兰亭特黑扁简';src : url('/fonts/兰亭特黑扁简.ttf');}
 @font-face{font-family: '兰亭特黑简';src : url('/fonts/兰亭特黑简.ttf');}
 @font-face{font-family: '兰亭特黑长简';src : url('/fonts/兰亭特黑长简.ttf');}
 @font-face{font-family: '兰亭细黑 GBK Mobil';src : url('/fonts/兰亭细黑 GBK Mobil.ttf');}
 @font-face{font-family: '兰亭细黑 GBK';src : url('/fonts/兰亭细黑 GBK.ttf');}
 @font-face{font-family: '兰亭纤黑 GBK';src : url('/fonts/兰亭纤黑 GBK.ttf');}
 @font-face{font-family: '造字工坊悦黑常规体';src : url('/fonts/造字工坊悦黑常规体.ttf');}
 @font-face{font-family: '造字工坊悦黑超细长';src : url('/fonts/造字工坊悦黑超细长.ttf');}
 @font-face{font-family: '造字工坊悦黑特细体';src : url('/fonts/造字工坊悦黑特细体.ttf');}
 @font-face{font-family: '造字工坊悦黑特细长体';src : url('/fonts/造字工坊悦黑特细长体.ttf');}
 @font-face{font-family: '造字工坊悦黑细体';src : url('/fonts/造字工坊悦黑细体.ttf');}
 @font-face{font-family: '造字工坊悦黑细长体';src : url('/fonts/造字工坊悦黑细长体.ttf');}
 @font-face{font-family: '造字工坊悦黑纤细体';src : url('/fonts/造字工坊悦黑纤细体.ttf');}
 @font-face{font-family: '造字工坊悦黑纤细长';src : url('/fonts/造字工坊悦黑纤细长.ttf');}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="left" id="edit">
        <img id="img1" />
        <div id="word" class="word"></div>
        <div id="image" class="image"><img id="img2"  /></div>
    </div>
    <div class="left">
        <div class="l-top">
            <table>
                <caption>文字</caption>
                <tr><td>参数：<input type="text" id="txtTitle" class="text1" placeholder="请输入参数名称"  runat="server" /></td></tr>
                <tr><td>内容：<input type="text" id="txtDefault" class="text1" placeholder="请输入默认值" onchange="fnWord()" runat="server" /> &nbsp;&nbsp;<input type="text" id="txtPreValue" class="text1" placeholder="请输入前缀" onchange="fnWord()" runat="server" />&nbsp;&nbsp;<input type="text" id="txtSuffixValue" class="text1" placeholder="请输入后缀" onchange="fnWord()" runat="server" /></td></tr>
                <tr><td>字体：<asp:DropDownList ID="ddlFontFamily" runat="server" CssClass="text1" onchange="fnWord()" >
                    <asp:ListItem Value="微软雅黑" Text="微软雅黑"></asp:ListItem>
                    <asp:ListItem Value="simkai" Text="楷体"></asp:ListItem>
                    <asp:ListItem Value="SIMLI" Text="隶书"></asp:ListItem>
                    <asp:ListItem Value="simfang" Text="仿宋"></asp:ListItem>
                    <asp:ListItem Value="宋体" Text="宋体"></asp:ListItem>
                    <asp:ListItem Value="simhei" Text="黑体"></asp:ListItem>
                    <asp:ListItem Value="SIMYOU" Text="幼圆"></asp:ListItem>
                    <asp:ListItem Value="STXINWEI" Text="华文新魏"></asp:ListItem>
                    <asp:ListItem Value="STXINGKA" Text="华文行楷"></asp:ListItem>
                    <asp:ListItem Value="STLITI" Text="华文隶书"></asp:ListItem>
                    <asp:ListItem Value="STHUPO" Text="华文琥珀"></asp:ListItem>
                    <asp:ListItem Value="stcaiyun" Text="华文彩云"></asp:ListItem>
                    <asp:ListItem Value="STFANGSO" Text="华文仿宋"></asp:ListItem>
                    <asp:ListItem Value="STZHONGS" Text="华文中宋"></asp:ListItem>
                    <asp:ListItem Value="STSONG" Text="华文宋体"></asp:ListItem>
                    <asp:ListItem Value="STKAITI" Text="华文楷体"></asp:ListItem>
                    <asp:ListItem Value="STXIHEI" Text="华文细黑"></asp:ListItem>
                    <asp:ListItem Value="手写大象体" Text="手写大象体"></asp:ListItem>
                    <asp:ListItem Value="DFPShaoNvW5-GB" Text="少女字体"></asp:ListItem>
                    <asp:ListItem Value="华康雅宋体W9" Text="华康雅宋体W9"></asp:ListItem>
                    <asp:ListItem Value="华康娃娃体W5" Text="华康娃娃体W5"></asp:ListItem>
                    <asp:ListItem Value="华康少女体" Text="华康少女体 "></asp:ListItem>
                    <asp:ListItem Value="陈晓江哈哈手写简体" Text="陈晓江哈哈手写简体"></asp:ListItem>
                    <asp:ListItem Value="我的情人" Text="我的情人"></asp:ListItem>
                    <asp:ListItem Value="汉真广标" Text="汉真广标"></asp:ListItem>
                    <asp:ListItem Value="简剪纸" Text="简剪纸"></asp:ListItem>
                    <asp:ListItem Value="简启体" Text="简启体"></asp:ListItem>
                    <asp:ListItem Value="迷你简菱心" Text="迷你简菱心"></asp:ListItem>
                    <asp:ListItem Value="颜简体" Text="颜简体"></asp:ListItem>
                    <asp:ListItem Value="生日快乐" Text="生日快乐"></asp:ListItem>

                     <asp:ListItem Value="FZLSJW" Text="方正隶书简体"></asp:ListItem>
                    <asp:ListItem Value="方正隶书_GBK" Text="方正隶书_GBK"></asp:ListItem>
                    <asp:ListItem Value="FZFSJW" Text="方正仿宋简体"></asp:ListItem>
                    <asp:ListItem Value="FZHPJW" Text="方正琥珀简体"></asp:ListItem>
                    <asp:ListItem Value="FZXBSJW" Text="方正小标宋简体"></asp:ListItem>
                    <asp:ListItem Value="方正大标宋简体" Text="方正大标宋简体"></asp:ListItem>
                    <asp:ListItem Value="FZXKJW" Text="方正行楷简体"></asp:ListItem>
                    <asp:ListItem Value="方正楷体简体" Text="方正楷体简体"></asp:ListItem>
                    <asp:ListItem Value="FZZDXJW" Text="方正中等线简体"></asp:ListItem>
                    <asp:ListItem Value="方正中等线_GBK" Text="方正中等线_GBK"></asp:ListItem>
                    <asp:ListItem Value="方正黑体简体" Text="方正黑体简体"></asp:ListItem>
                    <asp:ListItem Value="FZBSJW" Text="方正报宋简体"></asp:ListItem>
                    <asp:ListItem Value="FZDHTJW" Text="方正大黑简体"></asp:ListItem>
                    <asp:ListItem Value="FZLBJW" Text="方正隶变简体"></asp:ListItem>
                    <asp:ListItem Value="FZMHJW" Text="方正美黑简体"></asp:ListItem>
                    <asp:ListItem Value="FZS3JW" Text="方正宋三简体"></asp:ListItem>
                    <asp:ListItem Value="FZSHJW" Text="方正宋黑简体"></asp:ListItem>
                    <asp:ListItem Value="FZSSJW" Text="方正书宋简体"></asp:ListItem>
                    <asp:ListItem Value="FZSTJW" Text="方正舒体简体"></asp:ListItem>
                    <asp:ListItem Value="FZSZJW" Text="方正水柱简体"></asp:ListItem>
                    <asp:ListItem Value="FZWBJW" Text="方正魏碑简体"></asp:ListItem>
                    <asp:ListItem Value="FZXH1JW" Text="方正细黑一简体"></asp:ListItem>
                    <asp:ListItem Value="FZY1JW" Text="方正细圆简体"></asp:ListItem>
                    <asp:ListItem Value="FZYTJW" Text="方正姚体简体"></asp:ListItem>
                    <asp:ListItem Value="方正超粗黑简体" Text="方正超粗黑简体"></asp:ListItem>
                    <asp:ListItem Value="方正粗活意简体" Text="方正粗活意简体"></asp:ListItem>
                    <asp:ListItem Value="方正粗倩简体" Text="方正粗倩简体"></asp:ListItem>
                    <asp:ListItem Value="方正粗宋简体" Text="方正粗宋简体"></asp:ListItem>
                    <asp:ListItem Value="方正粗谭黑简体" Text="方正粗谭黑简体"></asp:ListItem>
                    <asp:ListItem Value="方正粗圆简体" Text="方正粗圆简体"></asp:ListItem>
                    <asp:ListItem Value="方正方魅简体" Text="方正方魅简体"></asp:ListItem>
                    <asp:ListItem Value="方正黄草简体" Text="方正黄草简体"></asp:ListItem>
                    <asp:ListItem Value="方正卡通简体" Text="方正卡通简体"></asp:ListItem>
                    <asp:ListItem Value="方正康体简体" Text="方正康体简体"></asp:ListItem>
                    <asp:ListItem Value="方正流行体简体" Text="方正流行体简体"></asp:ListItem>
                    <asp:ListItem Value="方正胖娃简体" Text="方正胖娃简体"></asp:ListItem>
                    <asp:ListItem Value="方正咆哮体" Text="方正咆哮体"></asp:ListItem>
                    <asp:ListItem Value="方正启体简体" Text="方正启体简体"></asp:ListItem>
                    <asp:ListItem Value="方正清刻本悦宋简体" Text="方正清刻本悦宋简体"></asp:ListItem>
                    <asp:ListItem Value="方正尚酷简体" Text="方正尚酷简体"></asp:ListItem>
                    <asp:ListItem Value="方正宋刻本秀楷简" Text="方正宋刻本秀楷简"></asp:ListItem>
                    <asp:ListItem Value="方正细等线简体" Text="方正细等线简体"></asp:ListItem>
                    <asp:ListItem Value="方正细珊瑚简体" Text="方正细珊瑚简体"></asp:ListItem>
                    <asp:ListItem Value="方正小篆体" Text="方正小篆体"></asp:ListItem>
                    <asp:ListItem Value="方正硬笔行书简体" Text="方正硬笔行书简体"></asp:ListItem>
                    <asp:ListItem Value="方正毡笔黑简体" Text="方正毡笔黑简体"></asp:ListItem>
                    <asp:ListItem Value="方正正大黑简体" Text="方正正大黑简体"></asp:ListItem>
                    <asp:ListItem Value="方正准圆简体" Text="方正准圆简体"></asp:ListItem>
                    <asp:ListItem Value="方正字迹-曾正国楷体" Text="方正字迹-曾正国楷体"></asp:ListItem>
                    <asp:ListItem Value="方正综艺简体" Text="方正综艺简体"></asp:ListItem>

                    <asp:ListItem Value="汉仪白棋体简" Text="汉仪白棋体简"></asp:ListItem>
                    <asp:ListItem Value="汉仪柏青体简" Text="汉仪柏青体简"></asp:ListItem>
                    <asp:ListItem Value="汉仪超粗黑简" Text="汉仪超粗黑简"></asp:ListItem>
                    <asp:ListItem Value="汉仪大黑简" Text="汉仪大黑简"></asp:ListItem>
                    <asp:ListItem Value="汉仪楷体简" Text="汉仪楷体简"></asp:ListItem>
                    <asp:ListItem Value="汉仪力量黑简" Text="汉仪力量黑简"></asp:ListItem>
                    <asp:ListItem Value="汉仪菱心体简" Text="汉仪菱心体简"></asp:ListItem>
                    <asp:ListItem Value="汉仪娃娃篆简" Text="汉仪娃娃篆简"></asp:ListItem>
                    <asp:ListItem Value="汉仪细等线简" Text="汉仪细等线简"></asp:ListItem>
                    <asp:ListItem Value="汉仪秀英体简" Text="汉仪秀英体简"></asp:ListItem>
                    <asp:ListItem Value="汉仪中等线简" Text="汉仪中等线简"></asp:ListItem>
                    <asp:ListItem Value="HYDaiYuTiJ" Text="汉仪黛玉体简"></asp:ListItem>
                    <asp:ListItem Value="HYHaiWenTiJ" Text="汉仪海纹体简"></asp:ListItem>
                    <asp:ListItem Value="HYLiuZiHeiJ" Text="汉仪六字黑简"></asp:ListItem>
                    <asp:ListItem Value="HYRuiYiSongW" Text="汉仪瑞意宋"></asp:ListItem>
                    <asp:ListItem Value="HYShiGuangTiW" Text="汉仪时光体"></asp:ListItem>
                    <asp:ListItem Value="HYTangTangTiJ" Text="汉仪糖糖体简"></asp:ListItem>
                    <asp:ListItem Value="HYXiaoBoMeiYanTiW" Text="汉仪晓波美研体"></asp:ListItem>
                    <asp:ListItem Value="HYXiaoMaiTiJ" Text="汉仪小麦体简"></asp:ListItem>
                    <asp:ListItem Value="HYZhuZiMeiXinTiW" Text="汉仪竹子眉心体"></asp:ListItem>

                    <asp:ListItem Value="叶根友奥运字体" Text="叶根友奥运字体"></asp:ListItem>
                    <asp:ListItem Value="叶根友蚕燕隶书" Text="叶根友蚕燕隶书"></asp:ListItem>
                    <asp:ListItem Value="叶根友蚕燕隶书" Text="叶根友蚕燕隶书"></asp:ListItem>
                    <asp:ListItem Value="叶根友刀锋黑草" Text="叶根友刀锋黑草"></asp:ListItem>
                    <asp:ListItem Value="叶根友非主流手写" Text="叶根友非主流手写"></asp:ListItem>
                    <asp:ListItem Value="叶根友风帆特色" Text="叶根友风帆特色"></asp:ListItem>
                    <asp:ListItem Value="叶根友钢笔行书简体" Text="叶根友钢笔行书简体"></asp:ListItem>
                    <asp:ListItem Value="叶根友疾风草书" Text="叶根友疾风草书"></asp:ListItem>
                    <asp:ListItem Value="叶根友空心简体" Text="叶根友空心简体"></asp:ListItem>
                    <asp:ListItem Value="叶根友毛笔行书" Text="叶根友毛笔行书"></asp:ListItem>
                    <asp:ListItem Value="叶根友签名体" Text="叶根友签名体"></asp:ListItem>
                    <asp:ListItem Value="叶根友神工体" Text="叶根友神工体"></asp:ListItem>
                    <asp:ListItem Value="叶根友特楷简体" Text="叶根友特楷简体"></asp:ListItem>
                    <asp:ListItem Value="叶根友特隶简体" Text="叶根友特隶简体"></asp:ListItem>
                    <asp:ListItem Value="叶根友特色简体" Text="叶根友特色简体"></asp:ListItem>
                    <asp:ListItem Value="叶根友特色空心简体终极版" Text="叶根友特色空心简体终极版"></asp:ListItem>
                    <asp:ListItem Value="叶根友圆趣卡通体" Text="叶根友圆趣卡通体"></asp:ListItem>

                    <asp:ListItem Value="兰亭粗黑简" Text="兰亭粗黑简"></asp:ListItem>
                    <asp:ListItem Value="兰亭黑简" Text="兰亭黑简"></asp:ListItem>
                    <asp:ListItem Value="兰亭特黑扁简" Text="兰亭特黑扁简"></asp:ListItem>
                    <asp:ListItem Value="兰亭特黑简" Text="兰亭特黑简"></asp:ListItem>
                    <asp:ListItem Value="兰亭特黑长简" Text="兰亭特黑长简"></asp:ListItem>
                    <asp:ListItem Value="兰亭细黑 GBK Mobil" Text="兰亭细黑 GBK Mobil"></asp:ListItem>
                    <asp:ListItem Value="兰亭细黑 GBK" Text="兰亭细黑 GBK"></asp:ListItem>
                    <asp:ListItem Value="兰亭纤黑 GBK" Text="兰亭纤黑 GBK"></asp:ListItem>

                    <asp:ListItem Value="造字工坊悦黑常规体" Text="造字工坊悦黑常规体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑超细长" Text="造字工坊悦黑超细长"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑特细体" Text="造字工坊悦黑特细体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑特细长体" Text="造字工坊悦黑特细长体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑细体" Text="造字工坊悦黑细体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑细长体" Text="造字工坊悦黑细长体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑纤细体" Text="造字工坊悦黑纤细体"></asp:ListItem>
                    <asp:ListItem Value="造字工坊悦黑纤细长" Text="造字工坊悦黑纤细长"></asp:ListItem>
                           </asp:DropDownList></td></tr>
                <tr><td>大小：<input type="text" id="txtFontSize" class="text1" onchange="fnWord()" value="20" runat="server" /></td></tr>
                <tr><td>颜色：<input type="text" id="txtColor" class="text1" onchange="fnWord()" value="00,00,00" runat="server" /><div id="picker" class="fr"></div></td></tr>
                <tr><td>粗细：<select id="ddlFontStyle" class="text1" onchange="fnWord()" runat="server"><option value="Regular">常规</option><option value="Bold">加粗</option></select></td></tr>
                
                <tr><td>边框大小：<input type="text" id="txtBorderSize" class="text1" onchange="fnWord()" value="0" runat="server" /></td></tr>
                <tr><td>边框颜色：<input type="text" id="txtBorderColor" class="text1" onchange="fnWord()" value="255,255,255" runat="server" /><div id="picker1" class="fr"></div></td></tr>
                
                <tr><td>旋转：<input type="text" id="txtRotate" class="text1" onchange="fnWord()" value="0" runat="server" /></td></tr>
                <tr><td>限宽：<input type="text" id="txtWidth" class="text1" onchange="fnWord()" value="0" runat="server" /></td></tr>
                <tr><td>限高：<input type="text" id="txtHeight" class="text1" onchange="fnWord()" value="0" runat="server" /></td></tr>
                <tr style="display:none;"><td>排序：<input type="text" id="txtOrderBy" class="text1"  value="1" runat="server" /></td></tr>
                <tr><td>水印：<select id="ddlShuiYin1" class="text1" runat="server" onchange="fnshuiyin1()">
                    <option value="0">不是</option><option value="1">是</option></select></td></tr>
                <tr><td>X：<asp:Label ID="lblX" runat="server" ></asp:Label><asp:HiddenField ID="hidX" runat="server" /> <input class="btn2" type="button" value="居中" onclick="juzhongX()" /> </td></tr>
                <tr ><td>Y：<asp:Label ID="lblY" runat="server" ></asp:Label><asp:HiddenField ID="hidY" runat="server" /> <input class="btn2" type="button" value="居中" onclick="juzhongY()" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="保存" CssClass="btn1" OnClick="Button1_Click" OnClientClick="return CheckValidate()" />
                    </td></tr>
               
            </table>

            ------------------------------------------------------------------------------------------------------------------------------------
        </div>
        <div class="l-bottom">
            <table>
                <caption>图像</caption>
                <tr><td>参数：<input type="text" id="txtTitle1" class="text1" placeholder="请输入参数名称" value="头像"  runat="server" /></td></tr>
                <tr><td>图像上传： <asp:FileUpload ID="FileUpload1" runat="server" onchange="return xmTanUploadImg(this)" /></td></tr>
                <tr><td>宽度：<input type="text" id="txtWidth1" runat="server" class="text1" value="0"  onchange="fnImg()" /></td></tr>
                <tr><td>高度：<input type="text" id="txtHeight1" runat="server" class="text1" value="0"  onchange="fnImg()" /></td></tr>
                <tr><td>旋转：<input type="text" id="txtRotate1" class="text1" onchange="fnImg()" value="0" runat="server" /></td></tr>
                <tr><td>是否圆形：<select id="ddlCircle" class="text1" runat="server" onchange="fnImg()"><option value="0" >否</option><option value="1">是</option></select></td></tr>
                <tr><td>水印：<select id="ddlShuiYin" class="text1" runat="server" onchange="fnshuiyin()">
                    <option value="">不是</option>
                    <option value="/Upload1/ewm0.jpg">超小</option>
                    <option value="/Upload1/ewm1.jpg">小</option>
                    <option value="/Upload1/ewm2.jpg" >中小</option>
                    <option value="/Upload1/ewm3.jpg" >中</option>
                    <option value="/Upload1/ewm4.jpg" >大</option>
                    <option value="/Upload1/ewm5.jpg" >最大</option>
                            </select></td></tr>
                <tr style="display:none;"><td>排序：<input type="text" id="txtOrderBy1" class="text1"  value="1" runat="server" /></td></tr>
                <tr><td>X：<span id="lblX1"></span><asp:HiddenField ID="hidX1" runat="server" /> <input class="btn2" type="button" value="居中" onclick="juzhongX1()" />
                </td></tr>
                <tr ><td>Y：<span id="lblY1"></span> <asp:HiddenField ID="hidY1" runat="server" /> <input class="btn2" type="button" value="居中" onclick="juzhongY1()" />  
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="保存" CssClass="btn1" OnClick="Button2_Click" OnClientClick="return CheckValidate1()"  /></td></tr>
            </table>
        </div>
    </div> 
    </form>
</body>
    <script type="text/javascript" src="../../../../../js/jquery-1.8.3.min.js"></script>
    <script src="../../../../../js/Tdrag.js"></script>
    <script src="../../../../../js/colpick.js"></script>
    <script type="text/javascript">
        $(function () {
            var bg = getQueryString("BgImageUrl");
            $("#img1").attr("src", bg);

            $("#word").Tdrag({
                cbMove: function () {
                    var x = $('#word').offset().top;
                    var y = $('#word').offset().left;
                    y = parseInt(y) - 8;
                    $("#lblX").html(y);
                    $("#lblY").html(x);

                    $("#hidX").val(y);
                    $("#hidY").val(x);
                }
            });

            //图像
            $("#image").Tdrag({
                cbMove: function () {
                    var x = $('#image').offset().top;
                    var y = $('#image').offset().left;
                    $("#lblX1").html(y);
                    $("#lblY1").html(x);

                    $("#hidX1").val(y);
                    $("#hidY1").val(x);
                }
            });

            $('#picker').colpick({
                flat: true,
                layout: 'rgbhex',
                color: 'ff8800',
                onSubmit: function (hsb, hex, rgb, el) {
                    $("#txtColor").val('#' + hex);
                    fnWord();
                    //$(el).css('background-color', '#' + hex);
                    //$(el).colpickHide();
                }
            });

            $('#picker1').colpick({
                flat: true,
                layout: 'rgbhex',
                color: 'ff8800',
                onSubmit: function (hsb, hex, rgb, el) {
                    $("#txtBorderColor").val('#' + hex);
                    fnWord();
                }
            });
        });

        function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]);
            return null;
        }

        function fnWord() {
            var content = $("#txtPreValue").val() + $("#txtDefault").val() + $("#txtSuffixValue").val();
            var fontFamily = $("#ddlFontFamily").val();
            var fontSize = $("#txtFontSize").val();
            var color = $("#txtColor").val();
            var fontStyle = $("#ddlFontStyle").val();
            var width = $("#txtWidth").val();
            var height = $("#txtHeight").val();
            var rotate = $("#txtRotate").val();
            var x = $('#word').offset().top;
            var y = $('#word').offset().left;

            var borderColor = $("#txtBorderColor").val();
            var borderSize = $("#txtBorderSize").val();
            
            if (x <= 0) {
                x = 200;
            }

            if (y <= 0) {
                y = 100;
            }

            var style = 'top:' + x + 'px;left:' + y + 'px;font-size:' + fontSize + 'px;color:' + color + ';font-weight:' + fontStyle + ';font-family:' + fontFamily + ';';
            if (width > 0) {
                style = style + 'width:' + width + 'px;';
            }
            if (height > 0) {
                style = style + 'height:' + height + 'px;';
            }

            //if (fontFamily != "微软雅黑" && fontFamily != "宋体") {
            //    var fontFace = " @font-face{font-family: '" + fontFamily + "';src : url('/fonts/" + fontFamily + ".ttf');}";
            //    $("style").append(fontFace);
            //}

            if (rotate > 0) {
                style = style + 'transform:rotate(' + rotate + 'deg);-ms-transform:rotate(' + rotate + 'deg);-moz-transform:rotate(' + rotate + 'deg);-webkit-transform:rotate(' + rotate + 'deg);-o-transform:rotate(' + rotate + 'deg);  ';
            }

            if (borderSize > 0) {
                style = style + '-webkit-text-stroke: ' + borderSize + 'px ' + borderColor + ';';
            }

            //var div = '<div style="'+style+'">' + content + '</div>';
            
            $("#word").attr("style", style);
            $("#word").html(content);
        }

        function fnshuiyin1() {
            var ddlshuiyin = $("#ddlShuiYin1").val();
            if (ddlshuiyin == 1) {
                $("#txtTitle").val("水印");
                $("#txtDefault").val("小程序微P图");
                $("#txtColor").val("#000000");
                $("#ddlFontFamily").val("simkai");
                $("#txtFontSize").val(20);
                fnWord();
            }
        }

        function fnImg() {
            var width = $("#txtWidth1").val();
            var height = $("#txtHeight1").val();
            var isCircle = $("#ddlCircle").val();

            var x = $('#image').offset().top;
            var y = $('#image').offset().left;
            var rotate = $("#txtRotate1").val();
            if (x <= 0) {
                x = 200;
            }

            if (y <= 0) {
                y = 100;
            }

            if (width <= 0) {
                width = 200;
            }

            if (height <= 0) {
                height = 200;
            }

            var style = 'top:' + x + 'px;left:' + y + 'px;width:' + width + 'px;height:' + height + 'px;';
            if (rotate > 0) {
                style = style + 'transform:rotate(' + rotate + 'deg);-ms-transform:rotate(' + rotate + 'deg);-moz-transform:rotate(' + rotate + 'deg);-webkit-transform:rotate(' + rotate + 'deg);-o-transform:rotate(' + rotate + 'deg);  ';
            }
            $("#image").attr("style", style);
            if (isCircle == 1) {
                $("#img2").attr("style", 'width:' + width + 'px;height:' + height + 'px;border-radius:'+width+'px');
            } else {
                $("#img2").attr("style", 'width:' + width + 'px;height:' + height + 'px;');
            }
        }

        function fnshuiyin() {
            var ddlshuiyin = $("#ddlShuiYin").val();
            if (ddlshuiyin.indexOf("ewm0") != -1) {
                $("#txtWidth1").val(129);
                $("#txtHeight1").val(129);
            }
            else if (ddlshuiyin.indexOf("ewm1") != -1) {
                $("#txtWidth1").val(258);
                $("#txtHeight1").val(258);
            } else if (ddlshuiyin.indexOf("ewm2") != -1) {
                $("#txtWidth1").val(344);
                $("#txtHeight1").val(344);
            } else if (ddlshuiyin.indexOf("ewm3") != -1) {
                $("#txtWidth1").val(430);
                $("#txtHeight1").val(430);
            } else if (ddlshuiyin.indexOf("ewm4") != -1) {
                $("#txtWidth1").val(860);
                $("#txtHeight1").val(860);
            } else if (ddlshuiyin.indexOf("ewm5") != -1) {
                $("#txtWidth1").val(1280);
                $("#txtHeight1").val(1280);
            }
            $("#txtTitle1").val("水印");
            var img = document.getElementById("img2");
            img.src = ddlshuiyin;
            fnImg();
        }


        //选择图片，马上预览
        function xmTanUploadImg(obj) {
            var filename = obj.value.toLowerCase();
            if (filename != "") {
                var size = obj.files[0].size;
                size = size / 1024 / 1024;
                if (size > 5) {
                    alert("上传文件尺寸不超出5MB限制！");
                    obj.value = "";
                    return false;
                } else {
                    if (filename.indexOf(".jpg") != -1 || filename.indexOf(".jpeg") != -1 || filename.indexOf(".png") != -1 || filename.indexOf(".gif") != -1) {
                        var file = obj.files[0];
                        console.log("file.size = " + file.size);  //file.size 单位为byte

                        var reader = new FileReader();
                        //读取文件过程方法
                        reader.onloadstart = function (e) {
                            console.log("开始读取....");
                        }
                        reader.onprogress = function (e) {
                            console.log("正在读取中....");
                        }
                        reader.onabort = function (e) {
                            console.log("中断读取....");
                        }
                        reader.onerror = function (e) {
                            console.log("读取异常....");
                        }
                        reader.onload = function (e) {
                            console.log("成功读取....");
                            var img = document.getElementById("img2");
                            img.src = e.target.result;
                            fnImg();
                         }
                         reader.readAsDataURL(file)
                         return true;
                     } else {
                         alert("只能选择.jpg格式、.png格式、.jpeg格式、.gif格式!");
                         obj.value = "";
                         return false;
                     }
                 }
             }
             return true;
         }

        function CheckValidate() {
            var title = $("#txtTitle").val();
            var preValue=$("#txtPreValue").val();
            var Default=$("#txtDefault").val();
            var SuffixValue=$("#txtSuffixValue").val();
            if (title == "") {
                alert("请输入参数名称");
                return false;
            } else if (preValue == "" && Default == "" && SuffixValue == "") {
                alert("请输入内容");
                return false;
            }
            return true;
        }

        function CheckValidate1() {
            var w = $("#txtWidth1").val();
            var h = $("#txtHeight1").val();

            if (w == "" || w == 0) {
                alert("请输入宽度");
                return false;
            } else if (h == "" || h == 0) {
                alert("请输入高度");
                return false;
            }
            return true;
        }

        function juzhongX() {
            var width = $("#img1").width();
            var wordW = $("#word").width();
            $("#word").css({ "left": (width - wordW) / 2 + "px" });
            $("#lblX").text("-1");
            $("#hidX").val("-1");
        }


        function juzhongY() {
            var height = $("#img1").height();
            var wordH = $("#word").height();
            $("#word").css({"top": (height - wordH) / 2 + "px" });
            $("#lblY").text("-1");
            $("#hidY").val("-1");
        }

        function juzhongX1() {
            var width = $("#img1").width();
            var wordW = $("#img2").width();
            $("#image").css({ "left": (width - wordW) / 2 + "px" });
            $("#lblX1").text("-1");
            $("#hidX1").val("-1");
        }


        function juzhongY1() {
            var height = $("#img1").height();
            var wordH = $("#img2").height();
            $("#image").css({ "top": (height - wordH) / 2 + "px" });
            $("#lblY1").text("-1");
            $("#hidY1").val("-1");
        }

        // 1.判断select选项中 是否存在Value="paraValue"的Item 
        function jsSelectIsExitItem() {
            var str = "";
            var objSelect = document.getElementById("ddlFontFamily");
            for (var i = 0; i < objSelect.options.length; i++) {
                //str = str + " @font-face{font-family: '" + objSelect.options[i].value + "';src : url('/fonts/" + objSelect.options[i].value + ".ttf');}\r\n";
                str = str + "\""+ objSelect.options[i].value + ".ttf\",";
            }
            console.log(str);
        }


    </script>
</html>
