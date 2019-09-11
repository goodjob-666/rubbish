<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tlLogin.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="登录日志">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="登录日志" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加登录日志">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        子帐号ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_SubUserID_Input" title="请输入子帐号ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_SubUserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登录类别</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_LoginType_Input" title="请输入登录类别~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_LoginType_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        机器名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_PCName_Input" title="请输入机器名~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_PCName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        硬盘</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_HD_Input" title="请输入硬盘~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_HD_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        网卡</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_Mac_Input" title="请输入网卡~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_Mac_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        IP地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_IP_Input" title="请输入IP地址~20:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_IP_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        操作系统</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_OS_Input" title="请输入操作系统~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_OS_Disp" runat="server"></asp:Label></td>
                </tr>

                <!--<tr>
                    <td class="table_body">
                        登录时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_LoginDate_Input" title="请输入登录时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_LoginDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登出时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_LogoutDate_Input" title="请输入登出时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_LogoutDate_Disp" runat="server"></asp:Label></td>
                </tr>-->

                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_Status_Input" title="请输入状态~32767:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_Status_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tlLogin_Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tlLogin_Comment_Disp" runat="server"></asp:Label></td>
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
</asp:Content>
