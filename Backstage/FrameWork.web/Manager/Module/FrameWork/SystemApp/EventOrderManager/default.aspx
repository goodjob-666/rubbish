<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" CodeBehind="default.aspx.cs" Inherits="FrameWork.web.Module.FrameWork.EventOrderManager._default"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadOPTxt="订单查询记录" HeadTitleTxt="订单查询记录" ButtonList-Capacity="4">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonIcon="list.gif" ButtonName="导出日志"
            ButtonPopedom="List" ButtonUrl="?CMD=DownLoad" ButtonUrlType="Href" ButtonVisible="True" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单查询记录">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                <asp:TemplateField HeaderText = "用户名">
                    <ItemTemplate>
                        <span title="访问地址:<%#Eval("E_From") %>"><%#Eval("E_U_LoginName")%></span>
                    </ItemTemplate>
                </asp:TemplateField>
                                <asp:TemplateField HeaderText="订单号">
                        <ItemTemplate>
                            <%#FomartContent((Eval("E_Record").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText = "客户端IP">
                    <ItemTemplate>
                        <%#FrameWork.Common.GetIPLookUrl((string)Eval("E_IP")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "介入时间">
                    <ItemTemplate>
                        <%#JRDate((Eval("E_Record").ToString()))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText = "首查时间">
                    <ItemTemplate>
                        <%#SCDate((Eval("E_Record").ToString()))%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="判决时间" DataField="E_DateTime" />                
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="Pager_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		<tr style="display:none">
			<td class="table_body table_body_NoWidth" >
                用户名</td>
			<td class="table_none table_none_NoWidth" >
                <asp:DropDownList ID="E_UserID" runat="server">
                </asp:DropDownList></td>
			<td class="table_body table_body_NoWidth" >
                日志类型</td>
			<td class="table_none table_none_NoWidth" >
                <asp:DropDownList ID="E_Type" runat="server">
                    <asp:ListItem Value="">不限</asp:ListItem>
                    <asp:ListItem Value="1">操作日志</asp:ListItem>
                    <asp:ListItem Value="2">安全日志</asp:ListItem>
                    <asp:ListItem Value="3">访问日志</asp:ListItem>
                </asp:DropDownList></td>            
		</tr>
            <tr>
                <td class="table_body table_body_NoWidth" style="height: 28px">
                   搜索条件</td>
                <td class="table_none table_none_NoWidth" style="height: 28px">
                    <asp:DropDownList ID="ddlSearch" runat="server">
                    <asp:ListItem Value="订单号">订单号</asp:ListItem>
                    <asp:ListItem Value="客户ID">客户ID</asp:ListItem>
                    <asp:ListItem Value="客服ID">客服ID</asp:ListItem>
                    </asp:DropDownList>
                <asp:TextBox ID="E_Record" runat="server" CssClass="text_input" style="width:180px"></asp:TextBox><br />
                查客服ID时支持多个查询，以英文逗号隔开，如：jim,jack,lily 最后一个不要加逗号
                    </td>
                <td class="table_body table_body_NoWidth" style="height: 28px">
                    时间</td>
                <td class="table_none table_none_NoWidth" style="height: 28px">
                    <asp:TextBox ID="S_E_DateTime" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);" Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox
                        ID="E_E_DateTime" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);" Columns="10" runat="server" CssClass="text_input"></asp:TextBox></td>
            </tr>
            <tr style="display:none">
                <td class="table_body table_body_NoWidth" style="height: 28px">
                    应用/模块</td>
                <td class="table_none table_none_NoWidth" colspan="3" style="height: 28px">
                <asp:DropDownList ID="E_ApplicationID" AutoPostBack="true" runat="server" OnSelectedIndexChanged="E_ApplicationID_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="E_M_PageCode" runat="server">
                    </asp:DropDownList>
                    </td>
            </tr>
				<tr><td colspan="4" align="right">
            <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td></tr>
		</table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>  
    <script type="text/javascript">
        function ClearData()
	    {
	        if (confirm("是否确认要清空日志数据?"))
	        {
		        if (confirm("注意:删除日志后不能恢复!\n\n是否需要导出日志导到本地文件?"))
		        {
			        window.location.href = "?cmd=DownLoadAndClearData";
		        }
		        else
		        {
		            window.location.href="?cmd=ClearData";
		        }
		    }
	    }
    </script>
</asp:Content>
