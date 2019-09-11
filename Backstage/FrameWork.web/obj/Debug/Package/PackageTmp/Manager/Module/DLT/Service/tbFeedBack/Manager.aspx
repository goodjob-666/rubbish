<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbFeedBack.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="tbFeedBack">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="tbFeedBack" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加tbFeedBack">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFeedBack_UserID_Input" title="请输入用户ID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFeedBack_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        提交来源</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFeedBack_Source_Input" title="请输入提交来源~10:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFeedBack_Source_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        反馈内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFeedBack_Feedback_Input" title="请输入反馈内容~2048:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFeedBack_Feedback_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        提交时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFeedBack_CreateDate_Input" title="请输入提交时间~datetime!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFeedBack_CreateDate_Disp" runat="server"></asp:Label></td>
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
