<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.Manager" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="图片" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="图片"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加图片">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">相册</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlAlbum" runat="server" ></asp:DropDownList>
                        <asp:Label ID="lblAlbum" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        图片名称</td>
                    <td class="table_none">
                      
                        <asp:TextBox ID="txtImageName"  title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lblImageName" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        图片路径</td>
                    <td class="table_none">
                     
                        <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" />
                    
                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="return xmTanUploadImg(this,1)" />
                         <div id="xmTanDiv"></div>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        图片背景</td>
                    <td class="table_none">
                     
                        <asp:Image ID="Image2" runat="server" Width="100px" Height="100px" />
                    
                         <asp:FileUpload ID="FileUpload2" runat="server" onchange="return xmTanUploadImg(this,2)" />
                         <div id="xmTanDiv1"></div>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        图片类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlImageType" runat="server">
                            <asp:ListItem Text="普通图片" Value="0"></asp:ListItem>
                            <asp:ListItem Text="GIF图片" Value="1"></asp:ListItem>
                            <asp:ListItem Text="字体" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="lblImageType" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        每帧时间</td>
                    <td class="table_none">
                      
                        <asp:TextBox ID="txtDelay"  title="请输入每帧时间~512:" runat="server" CssClass="text_input" Text="100"></asp:TextBox>
                    
                        <asp:Label ID="lblDelay" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否最热</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlIsHot" runat="server">
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="lblIsHot" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否可用</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlEnable" runat="server">
                            <asp:ListItem Text="可用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="lblEnable" runat="server"></asp:Label></td>
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

     <script type="text/javascript">
         //判断浏览器是否支持FileReader接口
         if (typeof FileReader == 'undefined') {
             document.getElementById("xmTanDiv").InnerHTML = "<h1>当前浏览器不支持FileReader接口</h1>";
             //使选择控件不可操作
             document.getElementById("<%=FileUpload1.ClientID%>").setAttribute("disabled", "disabled");

             document.getElementById("xmTanDiv1").InnerHTML = "<h1>当前浏览器不支持FileReader接口</h1>";
             document.getElementById("<%=FileUpload2.ClientID%>").setAttribute("disabled", "disabled");
         }

         //选择图片，马上预览
         function xmTanUploadImg(obj,type) {
             var filename = obj.value.toLowerCase();
             if (filename != "") {
                 var size = obj.files[0].size;
                 size = size / 1024;
                 if (size > 1000) {
                     alert("上传文件尺寸不超出1000KB限制！");
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
                             if (type == 1) {
                                 var img = document.getElementById("<%=Image1.ClientID%>");
                                 img.src = e.target.result;
                             } else {
                                 var img = document.getElementById("<%=Image2.ClientID%>");
                                 img.src = e.target.result;
                             }
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