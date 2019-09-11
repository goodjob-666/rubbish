<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsCreditEval.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="信用评价">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="信用评价" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加信用评价">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_UserID_Input" title="请输入用户ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        评价方向</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_EvalDirect_Input" title="请输入评价方向~32767:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_EvalDirect_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        非常满意</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Beautifully_Input" title="请输入非常满意~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Beautifully_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        满意</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Good_Input" title="请输入满意~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Good_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        一般</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Normal_Input" title="请输入一般~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Normal_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        很差</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Poor_Input" title="请输入很差~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Poor_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        信用总分</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Score_Input" title="请输入信用总分~9223372036854775807:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Score_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        信用等级</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCreditEval_Level_Input" title="请输入信用等级~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCreditEval_Level_Disp" runat="server"></asp:Label></td>
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
