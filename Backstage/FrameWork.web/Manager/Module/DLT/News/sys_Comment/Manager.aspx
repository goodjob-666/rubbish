<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_Comment.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="新闻评论">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="新闻评论" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加新闻评论">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        C_NewsID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_Comment_C_NewsID_Input" title="请输入C_NewsID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_Comment_C_NewsID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        C_PostID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_Comment_C_PostID_Input" title="请输入C_PostID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_Comment_C_PostID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        C_Content</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_Comment_C_Content_Input" title="请输入C_Content~2147483647:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_Comment_C_Content_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        C_Remarks</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_Comment_C_Remarks_Input" title="请输入C_Remarks~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_Comment_C_Remarks_Disp" runat="server"></asp:Label></td>
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
