<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbPostReport.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="tbPostReport">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="tbPostReport" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加tbPostReport">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        SerialNo</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_SerialNo_Input" title="请输入SerialNo~20:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_SerialNo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_UserID_Input" title="请输入UserID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        ReportCustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_ReportCustomerID_Input" title="请输入ReportCustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_ReportCustomerID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_CreateDate_Input" title="请输入CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        DealCustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_DealCustomerID_Input" title="请输入DealCustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_DealCustomerID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        DealDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_DealDate_Input" title="请输入DealDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_DealDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Status</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_Status_Input" title="请输入Status~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_Status_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Remark</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbPostReport_Remark_Input" title="请输入Remark~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbPostReport_Remark_Disp" runat="server"></asp:Label></td>
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
