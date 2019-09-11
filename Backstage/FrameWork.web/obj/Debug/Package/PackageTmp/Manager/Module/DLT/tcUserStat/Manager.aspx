<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tcUserStat.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="用户统计数据">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户统计数据" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加用户统计数据">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发单总数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_PubCount_Input" title="请输入发单总数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_PubCount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发单介入撤单数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_PubCancel_Input" title="请输入发单介入撤单数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_PubCancel_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发单协商撤单数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_PubConsultCancel_Input" title="请输入发单协商撤单数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_PubConsultCancel_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        接单介入总数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_AcceptCount_Input" title="请输入接单介入总数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_AcceptCount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        接单撤单数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_AcceptCancel_Input" title="请输入接单撤单数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_AcceptCancel_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        接单协商撤单数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_AcceptConsultCancel_Input" title="请输入接单协商撤单数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_AcceptConsultCancel_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        在线时长</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tcUserStat_OnlineMin_Input" title="请输入在线时长~9223372036854775807:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tcUserStat_OnlineMin_Disp" runat="server"></asp:Label></td>
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
