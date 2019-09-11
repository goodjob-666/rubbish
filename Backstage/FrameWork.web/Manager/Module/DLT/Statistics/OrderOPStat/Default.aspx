<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.OrderOPStat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单处理统计" HeadTitleTxt="订单处理统计">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单处理统计">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            查询方式<asp:DropDownList ID="DropDownList2" runat="server" style="font-size:12px;">
            <asp:ListItem Text="所有客服" Value="-1"></asp:ListItem>
            <asp:ListItem Text="分组查询" Value="0"></asp:ListItem>
            </asp:DropDownList> 
            <!--游戏<asp:DropDownList ID="ddlGLGameID" runat="server" style="font-size:12px;">
                <asp:ListItem Text="无限制" Value="-1"></asp:ListItem>
            </asp:DropDownList>
            -->
            日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>
            ~<asp:TextBox ID="E_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>
             操作员ID<asp:TextBox ID="tbOPName" runat="server" Columns="10" CssClass="text_input"></asp:TextBox>
            
                           <asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />
            <br />
            
            <asp:GridView ID="GridView1" runat="server" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="日期" DataField="StatDate" />
                    <asp:BoundField HeaderText="操作员ID" DataField="E_U_LoginName" />
                    <asp:BoundField HeaderText="处理订单数" DataField="StatCount" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            &nbsp;<br />
            <asp:Button ID="Button2" Visible="true" CssClass="button_bak" runat="server" Text="刷新" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="客服分组设置">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body table_body_NoWidth" style="width:8%">
                        用户角色
                    </td>
                    <td class="table_none table_none_NoWidth" style="width:92%">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;待分配用户&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;组名：<asp:DropDownList 
                            Font-Size="12px" ID="DropDownList1" runat="server" DataTextField="S_Name" 
                            DataValueField="S_ID" AutoPostBack="True" 
                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        <table width="" cellspacing="1" cellpadding="0" border="0">
	<tbody><tr>
		<td width="45%">
		<asp:ListBox ID="ListBox1" style="width:140px; height:320px;" runat="server" 
                DataTextField="U_LoginName" DataValueField="UserID" SelectionMode="Multiple"></asp:ListBox>
		</td>
		<td width="10%" align="center">
		<div>
			<p><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Manager/images/1.gif" onclick="ImageButton1_Click" /></p>
			<p><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Manager/images/2.gif" onclick="ImageButton2_Click" /></p>
			<p><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Manager/images/3.gif" onclick="ImageButton3_Click" /></p>
			<p><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Manager/images/4.gif"  onclick="ImageButton4_Click" /></p>
		</div>
		</td>
		<td width="45%">
        <asp:ListBox ID="ListBox2" style="width:140px; height:320px;" runat="server" 
                DataTextField="U_LoginName" DataValueField="UserID" SelectionMode="Multiple"></asp:ListBox>
		</td>
	</tr>
</tbody></table>
                        <asp:Label ID="Roles_Value" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
           <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center" id="PostButton"
        runat="server">
        <tr>
            <td align="right">
                <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="确定" OnClick="Button3_Click" />
            </td>
        </tr>
    </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

    
    
    
    
</asp:Content>
