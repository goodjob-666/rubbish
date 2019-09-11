<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsBank.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="银行账户">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="银行账户" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加银行账户">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        银行ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_BankID_Input" title="请输入银行ID~32767:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_BankID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        银行户名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_BankUser_Input" title="请输入银行户名~100:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_BankUser_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        银行账号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_BankAcc_Input" title="请输入银行账号~100:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_BankAcc_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        开户地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_BankAddr_Input" title="请输入开户地址~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_BankAddr_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否缺省</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsBank_IsDefault_Input" runat="server">
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsBank_IsDefault_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsBank_Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsBank_Comment_Disp" runat="server"></asp:Label></td>
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
