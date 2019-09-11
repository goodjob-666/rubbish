<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.FinanceAccount.Default"
    Title="无标题页" %>

<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单情况统计" HeadTitleTxt="订单情况统计">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单情况统计">
            
           <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td>游戏：<asp:DropDownList ID="ddlGame" runat="server" style="font-size:12px;">
            <asp:ListItem Text="无限制" Value="-1"></asp:ListItem>
            </asp:DropDownList> 
                        日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                        ~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                           <asp:CheckBox ID="cbGood" runat="server" Text="优质订单" />
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
                                 <asp:TemplateField SortExpression="PubStatCount" HeaderText="发布笔数">
                                <ItemTemplate>
                                <%#Eval("PubStatCount").ToString() + " （公共：" + Eval("PubPubStatCount").ToString() + "）"%>
                                </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField SortExpression="PubStatBal" HeaderText="发布金额">
                                <ItemTemplate>
                                    <%#SaveTwoDec((Eval("PubStatBal").ToString()))%>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="接手笔数">
                                <ItemTemplate>
                                <%#Eval("AccStatCount").ToString() + " （APP：" + Eval("APPStatCount").ToString() + "）"%>
                                </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField SortExpression="AccStatBal" HeaderText="接手金额">
                                <ItemTemplate>
                                    <%#SaveTwoDec((Eval("AccStatBal").ToString())) + ShowFee((Eval("SettleBal").ToString())) %>
                                </ItemTemplate>
                                </asp:TemplateField> 
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
		    </table>
		    <!--<div>
                <dotnetCHARTING:Chart ID="Chart1" runat="server">
                </dotnetCHARTING:Chart></div>
                <div>
                <dotnetCHARTING:Chart ID="Chart2" runat="server">
                </dotnetCHARTING:Chart>
    </div>-->
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
