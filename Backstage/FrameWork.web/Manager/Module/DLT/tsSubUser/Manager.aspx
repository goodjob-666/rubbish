<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsSubUser.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="子用户">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="子用户" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加子用户">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登录ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_LoginID_Input" title="请输入登录ID~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_LoginID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        姓名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_SubUserName_Input" title="请输入姓名~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_SubUserName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登录密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_Pass_Input" title="请输入登录密码~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_Pass_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_CreateDate_Input" title="请输入创建时间~datetime!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_Comment_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        令牌</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_Token_Input" title="请输入令牌~64:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_Token_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        活动时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsSubUser_LiveTime_Input" title="请输入活动时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsSubUser_LiveTime_Disp" runat="server"></asp:Label></td>
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
