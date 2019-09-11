<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Manager1.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.Manager1" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <style type="text/css">
        .img,.data{ display:none;}
    </style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="参数" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="参数" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加参数">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        参数名称</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtTitle"  title="请输入名称~512:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                </tr>

                <tr class="word">
                    <td class="table_body">
                        	前缀</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtPreValue"  title="请输入名称~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblPreValue" runat="server"></asp:Label></td>
                </tr>

                <tr class="word">
                    <td class="table_body">
                        	默认值</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtDefault"  title="请输入默认值~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblDefault" runat="server"></asp:Label></td>
                </tr>

                <tr class="img">
                    <td class="table_body">
                        	图片路径</td>
                    <td class="table_none">
                         <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" />
                    
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="return xmTanUploadImg(this,1)" />
                       <div id="xmTanDiv"></div>
                       <asp:Label ID="lblDefault1" runat="server"></asp:Label></td>
                </tr>

                <tr class="word">
                    <td class="table_body">
                        	后缀</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtSuffixValue"  title="请输入后缀~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblSuffixValue" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlType" runat="server" onchange="fnHandle()">
                            <asp:ListItem Text="字符" Value="String" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="整数" Value="Number"></asp:ListItem>
                            <asp:ListItem Text="小数" Value="Digit"></asp:ListItem>
                            <asp:ListItem Text="日期" Value="Date"></asp:ListItem>
                            <asp:ListItem Text="时间：时分" Value="Time"></asp:ListItem>
                            <asp:ListItem Text="数组" Value="Array"></asp:ListItem>
                            <asp:ListItem Text="图片" Value="Image"></asp:ListItem>
                            
                        </asp:DropDownList>
                        <asp:Label ID="lblType" runat="server"></asp:Label></td>
                </tr>

                <tr class="data">
                    <td class="table_body">
                        	数组选项（多个选项用,隔开）</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtData"  title="请输入数组选项~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblData" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        	X坐标(如果图片或文字居中，请填入-1)</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtX"  title="请输入X坐标~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblX" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        	Y坐标(如果图片或文字居中，请填入-1)</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtY"  title="请输入Y坐标~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblY" runat="server"></asp:Label></td>
                </tr>

                <tr class="word">
                    <td class="table_body">
                        	字体大小</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtFontSize"  title="请输入数组选项~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblFontSize" runat="server"></asp:Label></td>
                </tr>

                <tr class="word">
                    <td class="table_body">
                        	字体</td>
                    <td class="table_none">
                           <asp:DropDownList ID="ddlFontFamily" runat="server" >
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
                           </asp:DropDownList>
                       <asp:Label ID="lblFontFamily" runat="server"></asp:Label></td>
                </tr>

                 <tr class="word">
                    <td class="table_body">
                        	字体颜色</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtFontColor"  title="请输入字体颜色~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblFontColor" runat="server"></asp:Label></td>
                </tr>

                 <tr class="word">
                    <td class="table_body">
                        	字体样式</td>
                    <td class="table_none">
                       <asp:DropDownList ID="ddlFontStyle" runat="server">
                            <asp:ListItem Text="常规" Value="Regular" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="加粗" Value="Bold"></asp:ListItem>
                       </asp:DropDownList>
                       <asp:Label ID="lblFontStyle" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        	宽度</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtWidth"  title="请输入宽度~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblWidth" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        	高度</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtHeight"  title="请输入高度~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblHeight" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        	边框大小</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtBorderSize"  title="请输入边框大小~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblBorderSize" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        	边框颜色</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtBorderColor"  title="请输入边框颜色~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblBorderColor" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        	旋转</td>
                    <td class="table_none">
                       <asp:TextBox ID="txtRotate"  title="请输入旋转~512:" runat="server" CssClass="text_input"></asp:TextBox>
                       <asp:Label ID="lblRotate" runat="server"></asp:Label></td>
                </tr>

                <tr class="img">
                    <td class="table_body">
                        	是否圆角</td>
                    <td class="table_none">
                       <asp:DropDownList ID="ddlIsCircle" runat="server">
                            <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                       </asp:DropDownList>
                       <asp:Label ID="lblIsCircle" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        	是否随机</td>
                    <td class="table_none">
                       <asp:DropDownList ID="ddlIsRandom" runat="server">
                            <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            <asp:ListItem Text="是水印" Value="2"></asp:ListItem>
                       </asp:DropDownList>
                       <asp:Label ID="lblIsRandom" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        	排序</td>
                    <td class="table_none">
                      <asp:TextBox ID="txtOrderBy"  title="请输入排序~512:" runat="server" CssClass="text_input"></asp:TextBox>
                      <asp:Label ID="lblOrderBy" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
     <script type="text/javascript" src="../../../../../js/jquery-1.8.3.min.js"></script>
     <script type="text/javascript">
         $(function () {
             var id = getQueryString("ImgID");
             $("#button_0").attr("onclick", "JavaScript:window.location.href='Parameter.aspx?ID=" + id + "';");

             var _type = getQueryString("Type");
             if (_type == "Image") {
                 $(".word").hide();
                 $(".img").show();
                 $(".data").hide();
             } else if (_type == "Array") {
                 $(".word").show();
                 $(".img").hide();
                 $(".data").show();
             } else {
                 $(".word").show();
                 $(".img").hide();
                 $(".data").hide();
             }
         });

         //判断浏览器是否支持FileReader接口
         if (typeof FileReader == 'undefined') {
             document.getElementById("xmTanDiv").InnerHTML = "<h1>当前浏览器不支持FileReader接口</h1>";
             //使选择控件不可操作
             document.getElementById("<%=FileUpload1.ClientID%>").setAttribute("disabled", "disabled");
         }

         function getQueryString(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
             var r = window.location.search.substr(1).match(reg);
             if (r != null) return unescape(r[2]);
             return null;
         }

         //选择参数，马上预览
         function xmTanUploadImg(obj) {
             var filename = obj.value.toLowerCase();
             if (filename != "") {
                 var size = obj.files[0].size;
                 size = size / 1024;
                 if (size > 300) {
                     alert("上传文件尺寸不超出300KB限制！");
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
                             var img = document.getElementById("<%=Image1.ClientID%>");
                             img.src = e.target.result;
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

         function fnHandle() {
             var _type = $("#<%=ddlType.ClientID%>").val();
             console.log(_type);
             if (_type == "Image") {
                 $(".word").hide();
                 $(".img").show();
                 $(".data").hide();
             } else if (_type == "Array") {
                 $(".word").show();
                 $(".img").hide();
                 $(".data").show();
             } else {
                 $(".word").show();
                 $(".img").hide();
                 $(".data").hide();
             }
         }

        
        </script>
</asp:Content>