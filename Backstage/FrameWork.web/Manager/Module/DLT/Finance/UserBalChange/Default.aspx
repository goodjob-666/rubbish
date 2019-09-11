<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.UserBalChange.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="用户资金调整" HeadTitleTxt="用户资金调整">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户资金调整">
            
            <table width="60%" border="0">
  <tr>
    <td>用户ID：</td>
    <td><asp:TextBox ID="txtUserID" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox></td>
  </tr>
  <tr>
    <td>变动金额：</td>
    <td><asp:TextBox ID="txtChangeBal" title="请输入充值金额~20:" runat="server" CssClass="text_input"></asp:TextBox>（加钱则直接写金额，减钱在金额前加个&quot;-&quot;，如： -50）</td>
  </tr>
  <tr>
    <td>关联流水号：</td>
    <td><asp:TextBox ID="txtRealSerialno" runat="server" CssClass="text_input"></asp:TextBox>（如果有则填写，如无可以不填写）</td>
  </tr>
  <tr>
    <td>备注：</td>
    <td><asp:TextBox ID="txtComent" runat="server" CssClass="text_input" Width="500"></asp:TextBox>（资金变动原因，建议填写）</td>
  </tr>
  <tr>
    <td colspan="2"><asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="保存" OnClientClick="return confirm('是否确定执行资金调整？');" OnClick="Button1_Click" /></td>
  </tr>
</table>
        </FrameWorkWebControls:TabOptionItem>
        
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="用户资金调整列表">
            
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td>用户ID：<asp:TextBox ID="txtUserID1" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                           <asp:Button ID="Button2" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号"> 
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                 <asp:BoundField HeaderText="用户编号" DataField="UserID" />
                                 <asp:BoundField HeaderText="资金变动流水" DataField="SerialNo" />
                                <asp:BoundField HeaderText="资金变动类别" DataField="value" />
                                <asp:BoundField HeaderText="变动前余额" DataField="PreBal" />
                                <asp:BoundField HeaderText="变动金额" DataField="ChangeBal" />
                                <asp:BoundField HeaderText="变动后余额" DataField="CurBal" />
                                <asp:BoundField HeaderText="变动日期" DataField="ChangeDate" />
                                <asp:BoundField HeaderText="关联流水" DataField="RelaSerialNo" />
                                <asp:BoundField HeaderText="备注" DataField="Comment" />
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
                </FrameWorkWebControls:AspNetPager> 
                    </td>
                </tr>
		    </table>
            
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
