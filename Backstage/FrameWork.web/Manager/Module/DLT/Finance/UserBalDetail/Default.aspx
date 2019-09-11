<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.UserBalDetail.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="用户资金明细查询" HeadTitleTxt="用户资金明细查询">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单情况统计">
            
           <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td>用户ID：<asp:TextBox ID="txtUserID" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        昵称：<asp:TextBox ID="txtNickName" title="请输入昵称~24:" runat="server" CssClass="text_input"></asp:TextBox>
                        变动类别：<asp:DropDownList ID="ddlChangeType" runat="server">
                        <asp:ListItem Value="0" Selected>无限制</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                           <asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />
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
                                <asp:TemplateField HeaderText="昵称">
                                    <ItemTemplate>
                                        <%# FrameWork.Common.Base64Decode(Eval("NickName").ToString()) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                <asp:Label ID="lblTotalRecharge" runat="server" style="color:Teal; margin-left:5px;" Text=""></asp:Label>  
                    </td>
                </tr>
		    </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
