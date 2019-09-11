<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.JudgReseaon.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="客服判决理由查询" HeadTitleTxt="判决理由">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="客服判决理由查询">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        日期范围：<asp:TextBox ID="S_dtDate_Input" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~<asp:TextBox
                                ID="E_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox> 客服登录ID：
                        <asp:TextBox ID="txtServiceID" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" OnClick="Button1_Click"
                            Text="查询" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ODSerialNo" HeaderText="订单号" />
                                <asp:BoundField DataField="CreateDate" HeaderText="判决时间" />
                                <asp:BoundField DataField="Msg" HeaderText="判决理由" />
                                <asp:BoundField DataField="E_U_LoginName" HeaderText="客服ID" />
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
