<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.GoodLog.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="优质区日志查询" HeadTitleTxt="优质区日志查询">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="优质区日志查询">
          <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
            <tr>
              <td>用户ID:
                <asp:TextBox ID="txtUID8" runat="server"></asp:TextBox>
                <asp:Button ID="Button6" runat="server" CssClass="button_bak" Text="查询" 
                      onclick="Button6_Click"/></td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="GridView5" runat="server">
                  <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                            <%# (this.AspNetPager5.CurrentPageIndex - 1) * this.AspNetPager5.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="true" DataField="UID" HeaderText="用户ID" />
                    <asp:BoundField ReadOnly="true" DataField="ApplyType" HeaderText="优质类别" />
                    <asp:BoundField ReadOnly="true" DataField="ChangeDate" HeaderText="变动时间" />
                    <asp:BoundField ReadOnly="true" DataField="Comment" HeaderText="日志内容" />
                    <asp:BoundField ReadOnly="true" DataField="CustName" HeaderText="客服" />
                    </Columns>
                  </asp:GridView>
                <FrameWorkWebControls:AspNetPager ID="AspNetPager5" runat="server" 
                      onpagechanged="AspNetPager5_PageChanged"></FrameWorkWebControls:AspNetPager>
              </td>
            </tr>
          </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>