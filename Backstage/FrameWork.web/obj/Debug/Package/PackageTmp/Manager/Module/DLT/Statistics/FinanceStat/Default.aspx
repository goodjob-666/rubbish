<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Finance.Default"
    Title="无标题页" %>
    
<%@ Register Assembly="dotnetCHARTING" Namespace="dotnetCHARTING" TagPrefix="dotnetCHARTING" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="财务情况统计" HeadTitleTxt="财务情况统计">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="财务情况统计">
           <div style="font-weight:bold; margin:5px 0;">账户资金总览</div>
           <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
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
                                <asp:BoundField HeaderText="总充值金额" DataField="RechargeBal" />
                                <asp:BoundField HeaderText="实际总提现金额" DataField="WithdrawBal" />
                                <asp:BoundField HeaderText="总提现手续费" DataField="WithdrawFee" />
                                <asp:BoundField HeaderText="总申请提现金额" DataField="WithdrawIngFee" />
                                <asp:BoundField HeaderText="总提现撤销金额" DataField="WithdrawCancelFee" />
                                <asp:BoundField HeaderText="总提现失败金额" DataField="WithdrawFailBal" />
                                <asp:BoundField HeaderText="总发出金额" DataField="SendBal" />
                                <asp:BoundField HeaderText="总收到金额" DataField="ReceiveBal" />
                                <asp:BoundField HeaderText="总退回金额" DataField="ReturnBal" />
                                <asp:BoundField HeaderText="用户应有总余额" DataField="CalcUserBal" />
                                <asp:BoundField HeaderText="用户总余额" DataField="UserBal" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
		    </table>
		     <div style="font-weight:bold; margin:5px 0;">财务详细统计</div>
		     <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td>
                        日期范围<asp:TextBox ID="S_dtDate_Input_1" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input1" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                           <asp:Button ID="btn" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号"> 
                                    <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:TemplateField SortExpression="WDStatDate" HeaderText="日期">
                                <ItemTemplate>
                                    <%#StatDate((Eval("WDStatDate").ToString()))%>
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="总充值笔数" DataField="RCCount" />
                                <asp:TemplateField SortExpression="RCPrice" HeaderText="总充值金额">
                                <ItemTemplate>
                                    <%#SaveTwoDec((Eval("RCPrice").ToString()))%>
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="实际提现笔数" DataField="WDActualCount" />
                                <asp:TemplateField SortExpression="WDActualPrice" HeaderText="实际提现金额">
                                <ItemTemplate>
                                    <%#SaveTwoDec((Eval("WDActualPrice").ToString()))%>
                                </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField SortExpression="WDFee" HeaderText="总提现手续费">
                                    <ItemTemplate>
                                        <%#SaveTwoDec((Eval("WDFee").ToString()))%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="申请提现笔数" DataField="WDApplyCount" SortExpression="WDApplyCount" />
                                <asp:TemplateField SortExpression="WDApplyPrice" HeaderText="申请提现金额">
                                    <ItemTemplate>
                                        <%#SaveTwoDec((Eval("WDApplyPrice").ToString()))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
		    </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
