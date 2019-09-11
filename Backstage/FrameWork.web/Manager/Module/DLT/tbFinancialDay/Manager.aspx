<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbFinancialDay.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="财务每日数据">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="财务每日数据" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加财务每日数据">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        总资金</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFinancialDay_TotalBal_Input" title="请输入总资金~float!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFinancialDay_TotalBal_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        总冻结资金</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFinancialDay_TotalFreeze_Input" title="请输入总冻结资金~float!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFinancialDay_TotalFreeze_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        总提现资金</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFinancialDay_TotalWithDraw_Input" title="请输入总提现资金~float!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFinancialDay_TotalWithDraw_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        总可操作资金</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFinancialDay_TotalOperate_Input" title="请输入总可操作资金~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFinancialDay_TotalOperate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbFinancialDay_CreateDate_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbFinancialDay_CreateDate_Disp" runat="server"></asp:Label></td>
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
