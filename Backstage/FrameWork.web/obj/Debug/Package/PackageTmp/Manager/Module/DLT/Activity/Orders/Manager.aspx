<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Orders.Manager" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="订单" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="订单"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="判决订单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                        <asp:Label ID="lblSeriaNo" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        <asp:LinkButton ID="LinkButton1" runat="server" >查看占坑</asp:LinkButton>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        投注者ID</td>
                    <td class="table_none">
                        <asp:Label ID="lblUserID" runat="server"></asp:Label>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        区服</td>
                    <td class="table_none">
                        <asp:Label ID="lblZoneServer" runat="server"></asp:Label></td>
                </tr>

               <tr>
                    <td class="table_body">
                        角色名</td>
                    <td class="table_none">
                        <asp:Label ID="lblRoleName" runat="server"></asp:Label></td>
                </tr>

                
                 <tr>
                    <td class="table_body">
                        投注金额</td>
                    <td class="table_none">
                        <asp:Label ID="lblRegAmount" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        奖励倍数</td>
                    <td class="table_none">
                        <asp:Label ID="lblReward" runat="server"></asp:Label></td>
                </tr>

                 
                <asp:Panel ID="Panel1" runat="server">
                    <tr>
                        <td class="table_body">奇偶数</td>
                        <td class="table_none"><asp:Label ID="lblEvenOdd" runat="server"></asp:Label></td>
                    </tr>
                </asp:Panel>

                <tr>
                    <td class="table_body">
                        投注时间</td>
                    <td class="table_none">
                        <asp:Label ID="lblStartDate" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        判定时间</td>
                    <td class="table_none">
                        <asp:Label ID="lblEndDate" runat="server"></asp:Label></td>
                </tr>


                 <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                       
                        <asp:Label ID="lblStatus" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        结果</td>
                    <td class="table_none">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        疑问备注</td>
                    <td class="table_none">
                        <asp:Label ID="lblComment" runat="server"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td class="table_body">
                        结果金额</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtResAmount" Width="200px" title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        二次判决结果</td>
                    <td class="table_none">
                        <asp:DropDownList runat="server" ID="ddlResult" Width="200px"  OnSelectedIndexChanged="DropDownList_ddlResult"  AutoPostBack="true">
                            <asp:ListItem Value="-1">不限</asp:ListItem>
                            <asp:ListItem Value="0">输</asp:ListItem>
                            <asp:ListItem Value="1">赢</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        反馈备注</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtFeedBack" TextMode="MultiLine" Width="400px" Height="100px" title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="判决" OnClick="Button1_Click" />
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
             document.getElementById("xdaTanFileImg").setAttribute("disabled", "disabled");
         }

         //选择图片，马上预览
         function xmTanUploadImg(obj) {
             var filename = obj.value.toLowerCase();
             if (filename != "") {
                 var size = obj.files[0].size;
                 size = size / 1024 / 1024;
                 if (size > 1) {
                     alert("上传文件尺寸超出限制！");
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

                             var img = document.getElementById("ctl00_PageBody_Image1");
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