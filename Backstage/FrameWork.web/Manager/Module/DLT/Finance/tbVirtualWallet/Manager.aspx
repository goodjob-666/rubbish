<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbVirtualWallet.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="虚拟账户">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="虚拟账户列表" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加虚拟账户">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        财务人员ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbVirtualWallet_OPID_Input" title="请输入财务人员ID~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbVirtualWallet_OPID_Disp" runat="server"></asp:Label></td>
                </tr>
                
                
                <tr>
                    <td class="table_body">
                        剩余金额</td>
                    <td class="table_none">
                    
                        <asp:Label ID="Label1" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        新增金额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbVirtualWallet_MONEY_Input" title="请输入MONEY~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbVirtualWallet_MONEY_Disp" runat="server"></asp:Label></td>
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
