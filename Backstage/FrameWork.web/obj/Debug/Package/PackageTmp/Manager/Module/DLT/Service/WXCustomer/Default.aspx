<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.WXCustomer.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="微信客服" HeadTitleTxt="微信客服">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="微信客服列表">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        游戏：<asp:DropDownList ID="ddlGLGameID" runat="server" 
                             style="font-size:12px;">
                             <asp:ListItem Text="无限制" Value="-1"></asp:ListItem>
                         </asp:DropDownList>
                         <asp:Button ID="Button2" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button3_Click" />
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" 
                            onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" 
                            onrowcommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="Game" ReadOnly="true" HeaderText="游戏"/>
                                <asp:TemplateField HeaderText="客服分类">
                                  <ItemTemplate> <%#GetCustTypeName(Eval("CustType").ToString())%> </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="WXCustomer" ReadOnly="true" HeaderText="微信号"/>
                                <asp:BoundField DataField="TwoDimensionCode" ReadOnly="true" HeaderText="二维码地址"/>
                                <asp:BoundField DataField="SCount" ReadOnly="true" HeaderText="绑定数量"/>
                                <asp:TemplateField HeaderText="是否停用">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlIsClose" runat="server" SelectedValue='<%# Bind("IsClose") %>'>
                                            <asp:ListItem Value="0">启用</asp:ListItem>
                                            <asp:ListItem Value="1">停用</asp:ListItem>
                                            <asp:ListItem Value="2">停用</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#GetIsCloseName(Eval("IsClose").ToString())%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:Button ID="Button3"
                                            runat="server" Text="导出" CommandName="DC" CommandArgument='<%# Eval("ID")%>' /> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" 
                            onpagechanged="AspNetPager1_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                    </td>
                </tr>
            </table>             
        </FrameWorkWebControls:TabOptionItem>   
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
