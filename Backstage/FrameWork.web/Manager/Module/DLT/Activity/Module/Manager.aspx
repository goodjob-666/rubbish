<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Module.Manager" ValidateRequest="false" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="活动" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="活动"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加活动">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtTitle"  title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        描述</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsModule_Description_Input" TextMode="MultiLine" title="请输入描述~512:" Width="250px" Height="80px" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsModule_Description_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsModule_Comment_Input" TextMode="MultiLine" title="请输入描述~512:" Width="250px" Height="80px" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsModule_Comment_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        排序</td>
                    <td class="table_none">
                         <asp:DropDownList ID="ddlSort" runat="server">
                            <asp:ListItem Value="0">不限</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem>
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>

                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem>
                            <asp:ListItem Value="13">13</asp:ListItem>
                            <asp:ListItem Value="14">14</asp:ListItem>
                            <asp:ListItem Value="15">15</asp:ListItem>
                            <asp:ListItem Value="16">16</asp:ListItem>
                            <asp:ListItem Value="17">17</asp:ListItem>
                            <asp:ListItem Value="18">18</asp:ListItem>
                            <asp:ListItem Value="19">19</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>

                            <asp:ListItem Value="21">21</asp:ListItem>
                            <asp:ListItem Value="22">22</asp:ListItem>
                            <asp:ListItem Value="23">23</asp:ListItem>
                            <asp:ListItem Value="24">24</asp:ListItem>
                            <asp:ListItem Value="25">25</asp:ListItem>
                            <asp:ListItem Value="26">26</asp:ListItem>
                            <asp:ListItem Value="27">27</asp:ListItem>
                            <asp:ListItem Value="28">28</asp:ListItem>
                            <asp:ListItem Value="29">29</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>

                            <asp:ListItem Value="31">31</asp:ListItem>
                            <asp:ListItem Value="32">32</asp:ListItem>
                            <asp:ListItem Value="33">33</asp:ListItem>
                            <asp:ListItem Value="34">34</asp:ListItem>
                            <asp:ListItem Value="35">35</asp:ListItem>
                            <asp:ListItem Value="36">36</asp:ListItem>
                            <asp:ListItem Value="37">37</asp:ListItem>
                            <asp:ListItem Value="38">38</asp:ListItem>
                            <asp:ListItem Value="39">39</asp:ListItem>
                            <asp:ListItem Value="40">40</asp:ListItem>

                            <asp:ListItem Value="41">41</asp:ListItem>
                            <asp:ListItem Value="42">42</asp:ListItem>
                            <asp:ListItem Value="43">43</asp:ListItem>
                            <asp:ListItem Value="44">44</asp:ListItem>
                            <asp:ListItem Value="45">45</asp:ListItem>
                            <asp:ListItem Value="46">46</asp:ListItem>
                            <asp:ListItem Value="47">47</asp:ListItem>
                            <asp:ListItem Value="48">48</asp:ListItem>
                            <asp:ListItem Value="49">49</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                        </asp:DropDownList>
                     
                      
                    
                        <asp:Label ID="lblSort" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        运营状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsGame_IsOnline_Input" runat="server">
                            <asp:ListItem Text="可用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsGame_IsOnline_Disp" runat="server"></asp:Label></td>
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