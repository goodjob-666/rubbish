<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbLevelOrderInfo.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="代练订单角色资料">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="代练订单角色资料" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加代练订单角色资料">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        订单流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_ODSerialNo_Input" title="请输入订单流水号~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_ODSerialNo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        帐号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_GameAcc_Input" title="请输入帐号~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_GameAcc_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_GamePass_Input" title="请输入密码~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_GamePass_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        角色</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_Actor_Input" title="请输入角色~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_Actor_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        代练前角色信息</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_CurrInfo_Input" title="请输入代练前角色信息~512:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_CurrInfo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        代练最终要求</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_Require_Input" title="请输入代练最终要求~1024:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_Require_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        密保图片</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_SecPic_Input"  runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_SecPic_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        描述</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_Comment_Input" title="请输入描述~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_Comment_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        改密次数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbLevelOrderInfo_ChangePassCount_Input" title="请输入改密次数~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbLevelOrderInfo_ChangePassCount_Disp" runat="server"></asp:Label></td>
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
