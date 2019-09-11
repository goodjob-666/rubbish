<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbLevelOrderCancel.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="代练撤销">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="代练撤销" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加代练撤销">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        订单流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_ODSerialNo_Input" title="请输入订单流水号~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_ODSerialNo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_CreateDate_Input" title="请输入创建时间~datetime!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        支付代练费</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_PayLevelBal_Input" title="请输入支付代练费~float!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_PayLevelBal_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        赔偿保证金</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_RepEnsureBal_Input" title="请输入赔偿保证金~float!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_RepEnsureBal_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_Status_Input" title="请输入状态~32767:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_Status_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_Comment_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        接单方撤销次数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_AcceptCount_Input" title="请输入接单方撤销次数~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_AcceptCount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发单方撤销次数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderCancel_PublishCount_Input" title="请输入发单方撤销次数~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderCancel_PublishCount_Disp" runat="server"></asp:Label></td>
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
