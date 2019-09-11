<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.UserStat.Default"
    Title="无标题页" %>

<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="用户情况统计" HeadTitleTxt="用户情况统计">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户情况统计">
            <div id="divTotal" style="font-weight:bold; font-size:14px;" runat="server">当前总注册用户：<span style="color:Red;"><asp:Label
                ID="lblAll" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;当前在线人数：<span style="color:Red;"><asp:Label
                ID="lblOnline" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;当前已充值过用户：<span style="color:Red;"><asp:Label
                ID="lblCZCount" runat="server" Text=""></asp:Label></span>
                <br />
                当前禁止发单用户：<span style="color:Red;"><asp:Label
                ID="Label1" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                当前禁止接单用户：<span style="color:Red;"><asp:Label
                ID="Label2" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                当前禁止提现用户：<span style="color:Red;"><asp:Label
                ID="Label3" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                当前禁止解绑用户：<span style="color:Red;"><asp:Label
                ID="Label4" runat="server" Text=""></asp:Label></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                当前禁止接发单用户：<span style="color:Red;"><asp:Label
                ID="Label5" runat="server" Text=""></asp:Label></span>
                <br />
                </div>
           <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td>
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
                                <asp:TemplateField SortExpression="StatDate" HeaderText="日期">
                                <ItemTemplate>
                                    <%#StatDate((Eval("StatDate").ToString()))%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="注册用户" DataField="RegCount" />
                                <asp:BoundField HeaderText="注册用户充值" DataField="RegReCount" />
                                <asp:BoundField HeaderText="PC登录用户" DataField="LoginCount" />
                                <asp:BoundField HeaderText="APP登录用户" DataField="APPLoginCount" />
                                <asp:BoundField HeaderText="发单用户" DataField="PubCount" />
                                <asp:BoundField HeaderText="接单用户" DataField="AccCount" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
		    </table>
		    <div>
    </div>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
