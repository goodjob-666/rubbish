<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.userData.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="用户数据分析" HeadTitleTxt="用户数据分析">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户归类">
        <div>游戏：<asp:DropDownList ID="ddlGLGameID" runat="server" style="font-size:12px;">
            <asp:ListItem Text="无限制" Value="-1"></asp:ListItem>
            </asp:DropDownList>，接单数大于<asp:TextBox ID="txtGLNumStart" runat="server" Width="55px" Text="0"></asp:TextBox>小于<asp:TextBox
            ID="txtGLNumEnd" runat="server" Text="5"></asp:TextBox>，日期范围<asp:TextBox ID="TextBox2" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~<asp:TextBox
                                ID="TextBox3" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox> 排序方式<asp:DropDownList 
                ID="ddlOrderType" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlOrderType_SelectedIndexChanged">
                                <asp:ListItem Value="-1">无限制</asp:ListItem>
                                <asp:ListItem Value="10">总接单数</asp:ListItem>
                                <asp:ListItem Value="11">总接单金额</asp:ListItem>
                                <asp:ListItem Value="13">未接单时间</asp:ListItem>
            </asp:DropDownList>
                         <asp:Button ID="btnGL" runat="server" Text="查询" 
                onclick="btnGL_Click" /> | 
            <asp:Button ID="Button6" runat="server" Text="导出EXCEL" 
                onclick="Button6_Click" />
            </div>
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView6" runat="server" OnRowCommand="GridView6_RowCommand" 
                            onrowdatabound="GridView6_RowDataBound" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="UID" HeaderText="用户ID" />
                                <asp:BoundField DataField="BindMobile" HeaderText="绑定手机" />
                                <asp:BoundField DataField="ZJD" HeaderText="接单数" />
                                <asp:BoundField DataField="ZYXJD" HeaderText="有效接单数" />
                                
                                <asp:BoundField DataField="ZJE" HeaderText="接单金额" />
                                <asp:TemplateField HeaderText="收入金额">
          <ItemTemplate><asp:Label ID="lblSRPrice" runat="server" Text='<%# Eval("UserID") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="未接单时间">
          <ItemTemplate><asp:Label ID="lblZHJ" runat="server" Text='<%# Eval("ZHJ") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
   <asp:TemplateField HeaderText="未活跃时间">
          <ItemTemplate><asp:Label ID="lblZHD" runat="server" Text='<%# Eval("ZHD") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
                                        
                                <asp:TemplateField HeaderText="备注">
                                    <ItemTemplate>
                                        <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtGLComment" Width="260" runat="server"></asp:TextBox><asp:Button ID="btnGLUpdate"
                                            runat="server" Text="修改" CommandName="UpdateGLUserComment" CommandArgument='<%# Eval("UID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("UID").ToString()))%>
                        </ItemTemplate>
                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("UserID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged"></FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="用户流失统计">
        <div>日期范围<asp:TextBox ID="txtLSStart" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~<asp:TextBox
                                ID="txtLSEnd" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox> 
            &nbsp;<asp:Button ID="btnLSSearch" runat="server" Text="查询" 
                onclick="btnLSSearch_Click" />
            </div>
            <div style="margin-top:10px;">
                                    <asp:GridView ID="GridView1" runat="server" 
                                        onrowdatabound="GridView1_RowDataBound" 
                                        onrowcommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />
                                    <HeaderStyle Wrap="False" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="日期">
          <ItemTemplate><asp:Label ID="lblStatDate" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
                                <asp:TemplateField HeaderText="活跃用户">
          <ItemTemplate><asp:Label ID="lblHYYH" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="新增用户">
          <ItemTemplate><asp:Label ID="lblXZYH" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="半活跃用户">
          <ItemTemplate><asp:Label ID="lblBHYYH" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
<asp:TemplateField HeaderText="流失用户">
          <ItemTemplate><asp:Label ID="lblLSYH" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="流失率">
          <ItemTemplate><asp:Label ID="lblLSL" runat="server" Text='<%# Eval("StatDate") %>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button3"
                                            runat="server" Text="导出新增" CommandName="XZ" CommandArgument='<%# Eval("StatDate")%>' /> 
                                            <asp:Button ID="Button1"
                                            runat="server" Text="导出半活跃" CommandName="BHY" CommandArgument='<%# Eval("StatDate")%>' /> 
                                            <asp:Button ID="Button2"
                                            runat="server" Text="导出流失" CommandName="LS" CommandArgument='<%# Eval("StatDate")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        </FrameWorkWebControls:TabOptionItem>
     </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
