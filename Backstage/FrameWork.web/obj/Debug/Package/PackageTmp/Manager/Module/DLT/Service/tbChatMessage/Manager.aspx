<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbChatMessage.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="tbChatMessage">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="tbChatMessage" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加tbChatMessage">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_UserID_Input" title="请输入UserID~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        UID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_UID_Input" title="请输入UID~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_UID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        NickName</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_NickName_Input" title="请输入NickName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_NickName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        IconIndex</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_IconIndex_Input" title="请输入IconIndex~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_IconIndex_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        ChatType</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_ChatType_Input" title="请输入ChatType~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_ChatType_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        TargetID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_TargetID_Input" title="请输入TargetID~10:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_TargetID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Comment</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_Comment_Input" title="请输入Comment~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_Comment_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_CreateDate_Input" title="请输入CreateDate~datetime!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        BeginTime</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbChatMessage_BeginTime_Input" title="请输入BeginTime~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbChatMessage_BeginTime_Disp" runat="server"></asp:Label></td>
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
