<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsGame.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="游戏">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="游戏" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加游戏">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

               <%-- <tr>
                    <td class="table_body">
                        厂商</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlCompany" runat="server">
                        </asp:DropDownList>
                     
                        
                    
                        <asp:Label ID="tsGame_CompID_Disp" runat="server"></asp:Label></td>
                </tr>--%>

                <tr>
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsGame_Game_Input" title="请输入游戏~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsGame_Game_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        描述</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsGame_Comment_Input" title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsGame_Comment_Disp" runat="server"></asp:Label></td>
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
</asp:Content>
