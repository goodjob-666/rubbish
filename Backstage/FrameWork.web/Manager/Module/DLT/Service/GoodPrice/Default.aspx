<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.GoodPrice.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="优质区基准价" HeadTitleTxt="优质区基准价">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="基准价">
       <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>类别
              <span>:</span>
              <asp:DropDownList ID="ddlGameType" runat="server">
                <asp:ListItem Value="0">排位赛</asp:ListItem>
                <asp:ListItem Value="1">晋级赛</asp:ListItem>
                <asp:ListItem Value="2">定位赛</asp:ListItem></asp:DropDownList>服务器:
              <asp:DropDownList ID="ddlServerType" runat="server">
                <asp:ListItem Value="PT">普通</asp:ListItem>
                <asp:ListItem Value="D1">电一</asp:ListItem>
                <asp:ListItem Value="W1">网一</asp:ListItem></asp:DropDownList>开始段位:
              <asp:DropDownList ID="ddlSTier" runat="server">
                <asp:ListItem Value="">不限</asp:ListItem>
                <asp:ListItem Value="B">青铜</asp:ListItem>
                <asp:ListItem Value="S">白银</asp:ListItem>
                <asp:ListItem Value="G">黄金</asp:ListItem>
                <asp:ListItem Value="P">铂金</asp:ListItem>
                <asp:ListItem Value="D">钻石</asp:ListItem></asp:DropDownList>结束段位:
              <asp:DropDownList ID="ddlETier" runat="server">
                <asp:ListItem Value="">不限</asp:ListItem>
                <asp:ListItem Value="B">青铜</asp:ListItem>
                <asp:ListItem Value="S">白银</asp:ListItem>
                <asp:ListItem Value="G">黄金</asp:ListItem>
                <asp:ListItem Value="P">铂金</asp:ListItem>
                <asp:ListItem Value="D">钻石</asp:ListItem></asp:DropDownList>
              <asp:Button ID="btnSelect" runat="server" CssClass="button_bak" Text="查询" 
                    onclick="btnSelect_Click" />&nbsp; 对当前搜索结果调价，比例(可正可负):<asp:TextBox ID="tbUpRate" 
                    runat="server" Width="39px">1</asp:TextBox>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="修改" />
              </td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="GridView1" runat="server" 
                    onrowcancelingedit="GridView1_RowCancelingEdit" 
                    onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                <Columns>
                  <asp:TemplateField HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                  <asp:BoundField ReadOnly="true" DataField="ID" HeaderText="ID" />
                  <asp:BoundField ReadOnly="true" DataField="GameType" HeaderText="类别" />
                  <asp:BoundField ReadOnly="true" DataField="ServerType" HeaderText="服务器" />
                  <asp:BoundField ReadOnly="true" DataField="STier" HeaderText="开始段位" />
                  <asp:BoundField ReadOnly="true" DataField="ETier" HeaderText="结束段位" />
                    <asp:TemplateField HeaderText="基准价">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("BasePrice") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("BasePrice") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:CommandField HeaderText="操作" ShowEditButton="True" /></Columns>
              </asp:GridView>
              <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" onpagechanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
            </td>
          </tr>
        </table>
       </FrameWorkWebControls:TabOptionItem>   
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
