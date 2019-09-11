<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Orderby.aspx.cs" Inherits="FrameWork.web.Manager.Module.FrameWork.SystemApp.AppManager.Orderby" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" ButtonList-Capacity="4" HeadOPTxt="调整应用显示顺序" HeadTitleTxt="应用排序">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonIcon="back.gif" ButtonName="返回" ButtonPopedom="List"
            ButtonUrl="list.aspx" ButtonUrlType="Href" ButtonVisible="True" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="应用排序>
                  <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center" >
          <tr class="table_title">
            <td>
                &nbsp;应用排序</td>
          </tr>
          <tr class="table_none">
            <td align="center">
                <table >
                <tr>
                    <td><asp:ListBox ID="OrderByListItems" runat="server" SelectionMode="Multiple"></asp:ListBox></td>
                    <td>
                       	<img border="0" src="<%=Page.ResolveUrl("~/") %>Manager/images/up01.gif" OnClick="javascript:moveUpDown('up','<%=OrderByListItems_UniqueID %>');" style="cursor:pointer;">
    			        <p><img border="0" src="<%=Page.ResolveUrl("~/") %>Manager/images/down01.gif" OnClick="javascript:moveUpDown('down','<%=OrderByListItems_UniqueID %>');" style="cursor:pointer;">
                    </td>
                </tr>
                </table>
                
            </td>
          </tr>
          <tr><td align="right">
          <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="确定" OnClick="Button2_Click" />
          </td></tr>
          </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
