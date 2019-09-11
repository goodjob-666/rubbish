<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbEvaluate.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="上家评论修改" HeadTitleTxt="上家评论修改">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="上家评论修改">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        请输入订单编号：<asp:TextBox ID="txtOrder" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" OnClick="Button1_Click"
                            Text="查询" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" 
                            onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ODSerialNo" HeaderText="订单号" />
                                <asp:TemplateField HeaderText="评价内容">
                                    <ItemTemplate>
                                        <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="500" runat="server"></asp:TextBox>
                                        <asp:Label ID="lblDirect" runat="server" Text='<%# Eval("EvalDirect")%>' Visible="false"></asp:Label>
                                        <asp:Button ID="btnUpdate"
                                            runat="server" Text="修改" CommandName="UpdateEvaluateComment" CommandArgument='<%# Eval("ODSerialNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="评价方向">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDirectType" runat="server" Text='<%# Eval("EvalDirect")%>' ></asp:Label>
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
