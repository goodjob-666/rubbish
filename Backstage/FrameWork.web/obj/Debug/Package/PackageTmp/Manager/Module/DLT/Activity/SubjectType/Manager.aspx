<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.SubjectType.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="题库分类" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="题库分类"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加题库分类">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                
                <tr>
                    <td class="table_body">
                        类别</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtKind_Input" title="请输入类别" runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblKind_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        排序</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtOrderBy_Input" title="请输入排序" runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblOrderBy_Input" runat="server"></asp:Label></td>
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
