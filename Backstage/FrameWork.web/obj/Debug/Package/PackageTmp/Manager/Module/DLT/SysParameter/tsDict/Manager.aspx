<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsDict.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="数据字典">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="数据字典" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加数据字典">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        大类</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsDict_Key_Input" title="请输入大类~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsDict_Key_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsDict_Name_Input" title="请输入名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsDict_Name_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        小类</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsDict_Kind_Input" title="请输入小类~32767:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsDict_Kind_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        值</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsDict_Value_Input" title="请输入值~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsDict_Value_Disp" runat="server"></asp:Label></td>
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
