<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbLevelOrderReJudg.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="tbLevelOrderReJudg">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="tbLevelOrderReJudg" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加tbLevelOrderReJudg">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        ODSerialNo</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderReJudg_ODSerialNo_Input" title="请输入ODSerialNo~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderReJudg_ODSerialNo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        CustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderReJudg_CustomerID_Input" title="请输入CustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderReJudg_CustomerID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Reason</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderReJudg_Reason_Input" title="请输入Reason~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderReJudg_Reason_Disp" runat="server"></asp:Label></td>
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
