<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" 
Inherits="DLT.Web.Module.DLT.Activity.Orders.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
   
   <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
   <asp:GridView ID="GridView1" runat="server" onsorting="GridView1_Sorting">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                             <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单号">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lblSeriaNo" PostBackUrl='<%#"Manager.aspx?CMD=List&IDX="+Eval("SeriaNo") %>' runat="server"><%#Eval("SeriaNo")%></asp:LinkButton>--%>
                            <%#Eval("SeriaNo")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="获得者编号" DataField="UserID"  />
                     <asp:TemplateField HeaderText="获得者">
                        <ItemTemplate>
                           <%# FrameWork.Common.Base64Decode(Eval("NickName").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField> 
                  
                    <asp:TemplateField HeaderText="获得奖励" SortExpression="Rewards">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("Rewards").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:BoundField HeaderText="答对题数" DataField="RightCount"  />

                    <asp:BoundField HeaderText="时间" DataField="CreateDate" SortExpression="CreateDate" />
                   
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>

    <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center" style=" display:none;">
	    <tr>
		    <td class="table_body" colspan="2" align="right">
            
                <asp:Button ID="BtClose" runat="server" CssClass="button_bak" Text="关闭" 
                    onclick="BtClose_Click" />
            </td>
	    </tr>
    </table>
</asp:Content>
