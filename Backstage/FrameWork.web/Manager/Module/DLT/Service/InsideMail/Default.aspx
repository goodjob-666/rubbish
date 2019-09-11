<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.InsideMail.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="站内信" HeadTitleTxt="站内信">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="发送站内信列表">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <span>发送时间:</span>
                        <asp:TextBox ID="S_dtDate_Input" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>
                        ~<asp:TextBox ID="E_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date">
                         </asp:TextBox><asp:Button ID="Button2" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button3_Click" />
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" onrowcommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID"/>
                                <asp:BoundField DataField="SendDate" HeaderText="时间"/>
                                <asp:BoundField DataField="Title" HeaderText="主题"/>
                                <asp:BoundField DataField="SendType" HeaderText="发送用户"/>
                                <asp:BoundField DataField="SendReadCount" HeaderText="发送人数/查看人数"/>
                                <asp:BoundField DataField="Comment" HeaderText="备注"/>
                                <asp:BoundField DataField="SendCustomerID" HeaderText="发送人"/>
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <a href='javascript:showPopWin("查看详情","MailDetail.aspx?ID=<%# Eval("ID") %>",700, 420, null,false)'>
                                        查看详情</a>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>' OnClientClick="return confirm('确定要撤回这条站内信吗？');"  CommandName="Cancel" Text="撤回">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" 
                            onpagechanged="AspNetPager1_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                    </td>
                </tr>
            </table>             
        </FrameWorkWebControls:TabOptionItem>   
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="新增站内信">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td class="table_body">
                        主题
                    </td>
                    <td class="table_none">
                        <asp:TextBox runat="server" ID="txtTitle" Width="586px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        正文
                    </td>
                    <td class="table_none">
                        <asp:TextBox runat="server" ID="txtBody" Height="148px" TextMode="MultiLine" 
                            Width="598px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户选择
                    </td>
                    <td class="table_none">
                        
                        <asp:DropDownList ID="ddlSendType" runat="server">
                            <asp:ListItem Value="11">指定用户</asp:ListItem>
                            <asp:ListItem Value="10">所有用户</asp:ListItem>
                        </asp:DropDownList>注意：3个月内的所有用户超过30万，谨慎使用。
                        <br />
                        <asp:TextBox ID="txtUIDList" runat="server" Height="148px" TextMode="MultiLine" 
                            Width="301px"></asp:TextBox>USR开头的用户ID，一行一个
                        
                    </td>
                </tr>
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" 
                            onclick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="查询站内信">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        用户ID:<asp:TextBox ID="txtUID" runat="server"></asp:TextBox>
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button3_Click1" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager2.CurrentPageIndex - 1) * this.AspNetPager2.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="UID" HeaderText="用户ID" />
                                <asp:BoundField DataField="SendType" HeaderText="发送用户"/>
                                <asp:BoundField DataField="Title" HeaderText="发送主题"/>
                                <asp:BoundField DataField="SendDate" HeaderText="发送时间"/>
                                <asp:BoundField DataField="IsRead" HeaderText="阅读"/>
                                <asp:BoundField DataField="SendCustomerID" HeaderText="发送人"/>
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <a href='javascript:showPopWin("查看详情","MailDetail.aspx?ID=<%# Eval("ID") %>",700, 420, null,false)'>
                                        查看详情</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server">
                        </FrameWorkWebControls:AspNetPager>
                    </td>
                </tr>
            </table>  
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
