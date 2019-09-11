<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsCategory.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="商品分类">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="商品分类" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加商品分类">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        分类</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCategory_Category_Input" title="请输入分类~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCategory_Category_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        父分类</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCategory_ParentID_Input" title="请输入父分类~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCategory_ParentID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        深度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCategory_Depth_Input" title="请输入深度~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCategory_Depth_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        拼音</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCategory_Spell_Input" title="请输入拼音~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCategory_Spell_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        排序</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsCategory_Order_Input" title="请输入排序~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsCategory_Order_Disp" runat="server"></asp:Label></td>
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
