<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" 
Inherits="DLT.Web.Module.DLT.GoodAccept.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单列表">
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
        <td>
            <asp:HiddenField ID="hiddenID" runat="server" />
            <asp:GridView ID="GridView1" runat="server">
            <Columns>
            <asp:TemplateField HeaderText="序号"> 
                            <ItemTemplate>
                            <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Wrap="True" />  
                            <HeaderStyle Wrap="False" />    
                        </asp:TemplateField>
            <asp:BoundField HeaderText="发布者" DataField="PubNickName" />
            <asp:TemplateField HeaderText="角色名">
                <ItemTemplate>
                    <%#Unicode2Chinese((Eval("Actor").ToString()))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="接单者" DataField="AcceptNickName" />
            <asp:BoundField HeaderText="标题" DataField="Title" />
            <asp:BoundField HeaderText="金额" DataField="Price" />
            <asp:BoundField HeaderText="保证金" DataField="Ensure" />
            <asp:BoundField HeaderText="订单状态" DataField="StatusName" />
            <asp:BoundField HeaderText="撤销状态" DataField="CancelStatusName" />
            <asp:BoundField HeaderText="接单时间" DataField="StartDate" />
         
            </Columns>
          </asp:GridView>
          <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
         </td>
         </tr>
         <tr>
		    <td class="table_body" colspan="2" align="right">
                    <asp:Button ID="BtClose" runat="server" CssClass="button_bak" Text="关闭" 
                        onclick="BtClose_Click" />
            </td>
	    </tr>
     </table>
    </FrameWorkWebControls:TabOptionItem >
  </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
