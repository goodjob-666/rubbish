<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsSMSPlat.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="短信平台">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="短信平台" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加短信平台">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        平台名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_PlatName_Input" title="请输入平台名称~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_PlatName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        提交地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_PostUrl_Input" title="请输入提交地址~250:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_PostUrl_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_UserName_Input" title="请输入用户名~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_UserName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_Password_Input" title="请输入密码~150:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_Password_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        应用ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_AppID_Input" title="请输入应用ID~150:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_AppID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        成功关键字</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSMSPlat_SuccessKey_Input" title="请输入成功关键字~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSMSPlat_SuccessKey_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发送方式</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlSendType" runat="server">
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsSMSPlat_SmsStyle_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否使用</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsSMSPlat_IsEnable_Input" runat="server">
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsSMSPlat_IsEnable_Disp" runat="server"></asp:Label></td>
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
