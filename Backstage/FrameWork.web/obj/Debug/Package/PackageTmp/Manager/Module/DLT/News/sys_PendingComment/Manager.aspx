<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_PendingComment.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="sys_PendingComment">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="sys_PendingComment" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加sys_PendingComment">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        P_PendingID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_PendingID_Input" title="请输入P_PendingID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_PendingID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        P_CommentPostID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_CommentPostID_Input" title="请输入P_CommentPostID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_CommentPostID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        P_CommentStauts</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_CommentStauts_Input" title="请输入P_CommentStauts~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_CommentStauts_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        P_CommentContent</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_CommentContent_Input" title="请输入P_CommentContent~2147483647:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_CommentContent_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        P_CommentRemarks</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_CommentRemarks_Input" title="请输入P_CommentRemarks~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_CommentRemarks_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        P_Pre</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingComment_P_Pre_Input" title="请输入P_Pre~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingComment_P_Pre_Disp" runat="server"></asp:Label></td>
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
