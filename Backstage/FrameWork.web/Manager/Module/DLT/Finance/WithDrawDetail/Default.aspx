<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.WithDrawDetail.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="财务汇款明细查询" HeadTitleTxt="财务汇款明细查询">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="财务汇款明细查询统计">
<div>财务帐号：<asp:TextBox ID="txtUserID" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;提现状态：<asp:DropDownList
    ID="ddlType" runat="server">
    <asp:ListItem Value="-1" Selected>无限制</asp:ListItem>
    <asp:ListItem Value="11">提现完成</asp:ListItem>
    <asp:ListItem Value="12">提现撤销</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:CheckBox ID="cbGood" runat="server" />是否优质用户
                           <asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="导出" CssClass="button_bak" />
            </div>

            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="提现流水号" DataField="SerialNo" />
                    <asp:BoundField HeaderText="客户编号" DataField="UID" />
                    <asp:BoundField HeaderText="登陆ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="提现金额" DataField="Bal" />
                    <asp:BoundField HeaderText="提现手续费" DataField="Fee" />
                    <asp:TemplateField SortExpression="BankID" HeaderText="银行类别">
                        <ItemTemplate>
                            <%#BankType((Eval("BankID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="提现日期" DataField="ApplyDate" />
                    <asp:BoundField HeaderText="汇款日期" DataField="RemitDate" />
                    <asp:TemplateField SortExpression="Status" HeaderText="状态">
                        <ItemTemplate>
                            <%#Status((Eval("Status").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <label id="lbStatistics" runat="server" style="color:Teal; margin-left:5px;"></label>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
