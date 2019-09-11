<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.BankTransferDetail.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="网银汇款明细查询" HeadTitleTxt="网银汇款明细查询">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="网银汇款明细查询统计">
<div>查询类别：<asp:DropDownList
    ID="ddlType" runat="server">
    <asp:ListItem Value="关联流水号">关联流水号</asp:ListItem>
    <asp:ListItem Value="收款用户">收款用户</asp:ListItem>
    <asp:ListItem Value="收款账号">收款账号</asp:ListItem>
    <asp:ListItem Value="出款网银卡号">出款网银卡号</asp:ListItem>
    <asp:ListItem Value="出款网银ID">出款网银ID</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtTypeKeywords" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;查询结果：<asp:DropDownList
    ID="ddlResult" runat="server">
    <asp:ListItem Value="所有">所有</asp:ListItem>
    <asp:ListItem Value="汇款成功">汇款成功[银行反馈真实成功]</asp:ListItem>
    <asp:ListItem Value="汇款提交成功">汇款提交成功[银行返回结果未知]</asp:ListItem>
    <asp:ListItem Value="汇款失败">汇款失败</asp:ListItem>
    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                    <asp:BoundField HeaderText="银行名称" DataField="BankName" />
                    <asp:BoundField HeaderText="银行姓名" DataField="BankUser" />
                    <asp:BoundField HeaderText="银行帐号" DataField="BankAcc" />
                    <asp:BoundField HeaderText="汇款金额" DataField="PayBal" />
                    <asp:BoundField HeaderText="银行流水号" DataField="BankSerialNo" />
                    <asp:BoundField HeaderText="处理日期" DataField="ProcessDate" />
                    <asp:BoundField HeaderText="结果" DataField="Result" />
                    <asp:BoundField HeaderText="关联流水号" DataField="RelaSerialNo" />
                    <asp:BoundField HeaderText="打款银行帐号" DataField="RemitBankAcc" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <label id="lbStatistics" runat="server" style="color:Teal; margin-left:5px;"></label>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
