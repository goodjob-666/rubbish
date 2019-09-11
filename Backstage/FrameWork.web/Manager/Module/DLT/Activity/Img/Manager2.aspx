<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Manager2.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.Manager2" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="随机数" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="随机数"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加随机数">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        随机值（文字）</td>
                    <td class="table_none">
                      
                        <asp:TextBox ID="txtValue"  title="请输入随机值~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lblValue" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        随机值（图片）</td>
                    <td class="table_none">
                     
                        <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" />
                    
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="return xmTanUploadImg(this,1)" />
                         <div id="xmTanDiv"></div>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        X坐标</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtX" title="请输入X坐标~4:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="lblX" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        Y坐标</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtY" title="请输入Y坐标~4:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="lblY" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        关联ID
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="txtRelaID" title="请输入关联ID~512:" runat="server" CssClass="text_input" Text="0"></asp:TextBox>
                        <asp:Label ID="lblRelaID" runat="server"></asp:Label></td>
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
             var id = getQueryString("FieldsID");
             $("#button_0").attr("onclick", "JavaScript:window.location.href='RandomSet.aspx?ID=" + id + "';");
         });

         function getQueryString(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
             var r = window.location.search.substr(1).match(reg);
             if (r != null) return unescape(r[2]);
             return null;
         }
         //判断浏览器是否支持FileReader接口
         if (typeof FileReader == 'undefined') {
             document.getElementById("xmTanDiv").InnerHTML = "<h1>当前浏览器不支持FileReader接口</h1>";
             //使选择控件不可操作
             document.getElementById("<%=FileUpload1.ClientID%>").setAttribute("disabled", "disabled");
         }

         //选择随机数，马上预览
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
        </script>
</asp:Content>