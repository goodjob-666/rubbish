<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.GoodAccept.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="优质下家" HeadTitleTxt="优质下家">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="优质下家申请">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <span>申请时间:</span>
                        <asp:TextBox ID="S_dtDate_Input" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>
                        ~<asp:TextBox ID="E_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox>下家ID:<asp:TextBox ID="txtUID" 
                            runat="server"></asp:TextBox>
                        段位:
                        <asp:DropDownList ID="ddlTier" runat="server">
                            <asp:ListItem Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:CheckBox ID="chkUpTier" runat="server" Text="二次申请" />
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" OnClick="Button1_Click"
                            Text="查询" />
                        <br /><br />
                        下家ID:<asp:TextBox ID="txtUID0" 
                            runat="server"></asp:TextBox>申请段位:
                        <asp:DropDownList ID="ddlTierApply" runat="server">
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>冻结金额:<asp:DropDownList ID="ddlFreezeBal" runat="server">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem Value="200">200</asp:ListItem>
                            <asp:ListItem Value="300">300</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button5" runat="server" 
                            CssClass="button_bak" Text="添加" onclick="Button5_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" onrowcreated="GridView1_RowCreated" 
                            onsorting="GridView1_Sorting" onrowcommand="GridView1_RowCommand" 
                            onrowcancelingedit="GridView1_RowCancelingEdit" 
                            onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="下家ID" />
                                <asp:BoundField DataField="SettleCountRate" ReadOnly="true" HeaderText="近15天内公共频道订单结算量/结算率" SortExpression="SettleRate" />
                                <asp:TemplateField HeaderText="查询" ShowHeader="False">
                                    <ItemTemplate>
                                        <a href='javascript:showPopWin("近15天内符合条件的订单","OrderList.aspx?ID=<%# Eval("ID") %>",1080, 550, null,false)'>
                                        查询</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Tier" ReadOnly="true" HeaderText="申请段位" />
                                <asp:BoundField DataField="UpTier" ReadOnly="true" HeaderText="二次申请" />
                                <asp:BoundField DataField="EnsureMoney" ReadOnly="true" HeaderText="缴纳认证金" />
                                <asp:BoundField DataField="ApplyDate" ReadOnly="true" HeaderText="申请时间" 
                                    SortExpression="ApplyDate" />
                                <asp:BoundField DataField="LockStatus" ReadOnly="true" HeaderText="用户状态" />
                                <asp:TemplateField HeaderText="备注">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>' CommandName="refresh" Text="刷新">
                                        </asp:LinkButton>&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要通过优质下家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="Pass" Text="通过">
                                        </asp:LinkButton>
                                        <!--&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要不通过优质下家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="NoPass" Text="不通过">
                                        </asp:LinkButton>
                                        -->
                                        <a href='javascript:showPopWin("不通过优质下家","GoodPast.aspx?Flag=0&ID=<%# Eval("ID") %>",600, 100, AlertMessageBox1,false)'>
                                        不通过</a>
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
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="未通过下家">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>
                        下家ID:<asp:TextBox ID="txtUID1" runat="server"></asp:TextBox>
                        申请段位:
                        <asp:DropDownList ID="ddlTier1" runat="server">
                            <asp:ListItem Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" 
                            onrowcancelingedit="GridView2_RowCancelingEdit" 
                            onrowcommand="GridView2_RowCommand" onrowcreated="GridView2_RowCreated" 
                            onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" 
                            onsorting="GridView2_Sorting">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="下家ID" />
                                <asp:BoundField SortExpression="ApplyDate" DataField="ApplyDate" ReadOnly="true" HeaderText="申请时间" />
                                <asp:BoundField SortExpression="SettleRate" DataField="SettleCountRate" ReadOnly="true" HeaderText="近15天内公共频道订单结算量/结算率" />
                                <asp:BoundField DataField="Tier" ReadOnly="true" HeaderText="申请段位" />
                                <asp:BoundField DataField="EnsureMoney" ReadOnly="true" HeaderText="缴纳认证金" />
                                <asp:BoundField SortExpression="ChangeDate" DataField="ChangeDate" ReadOnly="true" HeaderText="未通过时间" />
                                <asp:TemplateField HeaderText="备注">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirm('确定要删除优质下家吗？');"  Text="删除">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" 
                            onpagechanged="AspNetPager2_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                        <asp:Button ID="Button8" Visible="false" CssClass="button_bak" runat="server" 
                            Text="删除" OnClientClick="return deleteop();" onclick="Button8_Click"/>
                    </td>
                </tr>
            </table>  
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="优质下家">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td><span>通过时间:</span>
                        <asp:TextBox ID="S_dtDate_Input1" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>
                        ~<asp:TextBox ID="E_dtDate_Input1" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox>
                        下家ID:<asp:TextBox ID="txtUID2" runat="server"></asp:TextBox>
                        优质段位:
                        <asp:DropDownList ID="ddlTier2" runat="server">
                            <asp:ListItem Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button3_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView3" runat="server" 
                            onrowcancelingedit="GridView3_RowCancelingEdit" 
                            onrowcommand="GridView3_RowCommand" onrowcreated="GridView3_RowCreated" 
                            onrowediting="GridView3_RowEditing" onrowupdating="GridView3_RowUpdating" 
                            onsorting="GridView3_Sorting">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="下家ID" />
                                <asp:BoundField SortExpression="ChangeDate" DataField="ChangeDate" ReadOnly="true" HeaderText="通过时间" />
                                <asp:TemplateField HeaderText="优质段位">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlTier4" runat="server" SelectedValue='<%# Bind("TierID") %>'>
                                            <asp:ListItem Value="10">青铜</asp:ListItem>
                                            <asp:ListItem Value="11">白银</asp:ListItem>
                                            <asp:ListItem Value="12">黄金</asp:ListItem>
                                            <asp:ListItem Value="13">白金</asp:ListItem>
                                            <asp:ListItem Value="14">钻石</asp:ListItem>
                                            <asp:ListItem Value="15">大师</asp:ListItem>
                                            <asp:ListItem Value="16">王者</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Tier") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="优质保证金">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlEnsureMoney" runat="server" SelectedValue='<%# Bind("EnsureMoney") %>'>
                                            <asp:ListItem Value="0.0000">0</asp:ListItem>
                                            <asp:ListItem Value="200.0000">200</asp:ListItem>
                                            <asp:ListItem Value="300.0000">300</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("EnsureMoney") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField SortExpression="GoodAcceptCount" DataField="GoodAcceptCount" ReadOnly="true" HeaderText="优质区接单数" />
                                <asp:BoundField SortExpression="GoodSettleRate" DataField="GoodSettleRate" ReadOnly="true" HeaderText="优质区结算率" />
                                <asp:BoundField SortExpression="AllAcceptCount" DataField="AllAcceptCount" ReadOnly="true" HeaderText="总接单数" />
                                <asp:BoundField SortExpression="AllSettleRate" DataField="AllSettleRate" ReadOnly="true" HeaderText="总结算率" />
                                <asp:BoundField SortExpression="CheckDate" DataField="CheckDate" ReadOnly="true" HeaderText="考核时间" />
                                <asp:BoundField DataField="LockStatus" ReadOnly="true" HeaderText="用户状态" />
                                <asp:TemplateField HeaderText="备注">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要考核优质下家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="Check" Text="考核">
                                        </asp:LinkButton>
                                        <!--&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要踢出优质下家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="KickOut" Text="踢出">
                                        </asp:LinkButton>
                                        -->
                                        &nbsp;&nbsp;
                                        <a href='javascript:showPopWin("踢出优质下家","GoodPast.aspx?Flag=3&ID=<%# Eval("ID") %>",600, 100, AlertMessageBox3,false)'>
                                        踢出</a>
                                        &nbsp;&nbsp;
                                        <a href='javascript:showPopWin("赔付优质保证金","Reparation.aspx?ID=<%# Eval("ID") %>",730, 200, AlertMessageBox3,false)'>
                                        判赔</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager3" runat="server" 
                            onpagechanged="AspNetPager3_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                    </td>
                </tr>
            </table>  
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="已踢出下家">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td>下家ID:<asp:TextBox ID="txtUID3" runat="server"></asp:TextBox>
                        优质段位:
                        <asp:DropDownList ID="ddlTier3" runat="server">
                            <asp:ListItem Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button4" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button4_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView4" runat="server" 
                            onrowcancelingedit="GridView4_RowCancelingEdit" 
                            onrowcommand="GridView4_RowCommand" onrowcreated="GridView4_RowCreated" 
                            onrowediting="GridView4_RowEditing" onrowupdating="GridView4_RowUpdating" 
                            onsorting="GridView4_Sorting">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="下家ID" />
                                <asp:BoundField SortExpression="ChangeDate" DataField="ChangeDate" ReadOnly="true" HeaderText="通过时间" />
                                <asp:BoundField DataField="Tier" ReadOnly="true" HeaderText="优质段位" />
                                <asp:BoundField DataField="EnsureMoney" ReadOnly="true" HeaderText="优质保证金" />
                                <asp:BoundField SortExpression="GoodAcceptCount" DataField="GoodAcceptCount" ReadOnly="true" HeaderText="优质区接单数" />
                                <asp:BoundField SortExpression="GoodSettleRate" DataField="GoodSettleRate" ReadOnly="true" HeaderText="优质区结算率" />
                                <asp:BoundField SortExpression="KickOutDate" DataField="KickOutDate" ReadOnly="true" HeaderText="踢出时间" />
                                <asp:TemplateField HeaderText="备注">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="return confirm('确定要删除优质下家吗？');"  Text="删除">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager4" runat="server" 
                            onpagechanged="AspNetPager4_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                        <asp:Button ID="Button9" runat="server" CssClass="button_bak" 
                            OnClientClick="return deleteop();" Text="删除" Visible="false" 
                            onclick="Button9_Click" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="优质下家申请退出">
            <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
                <tr>
                    <td><span>申请时间:</span>
                        <asp:TextBox ID="S_dtDate_Input2" runat="server" Columns="10" CssClass="text_input"
                            onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>
                        ~<asp:TextBox ID="E_dtDate_Input2" runat="server" Columns="10" 
                            CssClass="text_input" onfocus="javascript:HS_setDate(this);"
                                title="请输入结束日期~:date"></asp:TextBox>
                        下家ID:<asp:TextBox ID="txtUID9" runat="server"></asp:TextBox>
                        优质段位:
                        <asp:DropDownList ID="ddlTier4" runat="server">
                            <asp:ListItem Value="0">所有</asp:ListItem>
                            <asp:ListItem Value="10">青铜</asp:ListItem>
                            <asp:ListItem Value="11">白银</asp:ListItem>
                            <asp:ListItem Value="12">黄金</asp:ListItem>
                            <asp:ListItem Value="13">白金</asp:ListItem>
                            <asp:ListItem Value="14">钻石</asp:ListItem>
                            <asp:ListItem Value="15">大师</asp:ListItem>
                            <asp:ListItem Value="16">王者</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="Button7" runat="server" CssClass="button_bak"
                            Text="查询" onclick="Button7_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView6" runat="server" 
                            onrowcancelingedit="GridView6_RowCancelingEdit" 
                            onrowcommand="GridView6_RowCommand" onrowcreated="GridView6_RowCreated" 
                            onrowediting="GridView6_RowEditing" onrowupdating="GridView6_RowUpdating" 
                            onsorting="GridView6_Sorting">
                            <Columns>
                                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                                    <ItemTemplate>
                                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <ItemStyle Wrap="True" />  
                                    <HeaderStyle Wrap="False" />    
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID"/>
                                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="下家ID" />
                                <asp:BoundField SortExpression="ChangeDate" DataField="ChangeDate" ReadOnly="true" HeaderText="通过时间" />
                                <asp:BoundField DataField="Tier" ReadOnly="true" HeaderText="优质段位" />
                                <asp:BoundField DataField="EnsureMoney" ReadOnly="true" HeaderText="优质保证金" />
                                <asp:BoundField SortExpression="GoodAcceptCount" DataField="GoodAcceptCount" ReadOnly="true" HeaderText="优质区接单数" />
                                <asp:BoundField SortExpression="GoodSettleRate" DataField="GoodSettleRate" ReadOnly="true" HeaderText="优质区结算率" />
                                <asp:BoundField SortExpression="ApplyDate" DataField="ApplyDate" ReadOnly="true" HeaderText="申请退出时间" />
                                <asp:TemplateField HeaderText="备注">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要同意优质下家申请退出吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="Quit" Text="同意">
                                        </asp:LinkButton>
                                        <!--&nbsp;&nbsp;
                                        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要踢出优质下家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="KickOut" Text="踢出">
                                        </asp:LinkButton>
                                        -->
                                        &nbsp;&nbsp;
                                        <a href='javascript:showPopWin("不同意优质下家申请退出","GoodPast.aspx?Flag=6&ID=<%# Eval("ID") %>",600, 100, AlertMessageBox4,false)'>
                                        不同意</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <FrameWorkWebControls:AspNetPager ID="AspNetPager6" runat="server" 
                            onpagechanged="AspNetPager6_PageChanged">
                        </FrameWorkWebControls:AspNetPager>
                    </td>
                </tr>
            </table>  
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="优质区日志查询">
          <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
            <tr>
              <td>用户ID:
                <asp:TextBox ID="txtUID8" runat="server"></asp:TextBox>
                <asp:Button ID="Button6" runat="server" CssClass="button_bak" Text="查询" 
                      onclick="Button6_Click"/></td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="GridView5" runat="server">
                  <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                            <%# (this.AspNetPager5.CurrentPageIndex - 1) * this.AspNetPager5.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField ReadOnly="true" DataField="UID" HeaderText="用户ID" />
                    <asp:BoundField ReadOnly="true" DataField="ApplyType" HeaderText="优质类别" />
                    <asp:BoundField ReadOnly="true" DataField="ChangeDate" HeaderText="变动时间" />
                    <asp:BoundField ReadOnly="true" DataField="Comment" HeaderText="日志内容" />
                    <asp:BoundField ReadOnly="true" DataField="CustName" HeaderText="客服" />
                    </Columns>
                  </asp:GridView>
                <FrameWorkWebControls:AspNetPager ID="AspNetPager5" runat="server" 
                      onpagechanged="AspNetPager5_PageChanged"></FrameWorkWebControls:AspNetPager>
              </td>
            </tr>
          </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="JavaScript" type="text/javascript">
    
        function SelectAll() {
            var e = document.getElementsByTagName("input");
            var IsTrue;
            if (document.getElementById("CheckboxAll").value == "0") {
                IsTrue = true;
                document.getElementById("CheckboxAll").value = "1"
            }
            else {
                IsTrue = false;
                document.getElementById("CheckboxAll").value = "0"
            }
            
            for(var i=0;i<e.length;i++)
            {
                if (e[i].type=="checkbox")
                {
                    if (e[i].id == "ctl00_PageBody_chkUpTier") {
                        continue;
                    }
                    else {
                        e[i].checked = IsTrue;
                    }
                }
            }   
        }
        
        function deleteop() {
            var checkok = false;
            var e = document.getElementsByTagName("input");
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    if (e[i].checked == true) {
                        checkok = true;
                        break;
                    }
                }
            }
            if (checkok)
                return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
            else {

                alert("请选择要删除的记录!");
                return false;
            }
        }
    
        function AlertMessageBox1(Messages)
        {
            DispClose = false; 
            //alert(Messages);
            setTimeout("reload1()",100)            
        } 
        function reload1()
        {
            document.getElementById("<%=Button1.ClientID %>").click();
        }
        
        function AlertMessageBox3(Messages)
        {
            DispClose = false; 
            //alert(Messages);
            setTimeout("reload3()",100)            
        }
        function reload3()
        {
            document.getElementById("<%=Button3.ClientID %>").click();
        }
        
        function AlertMessageBox4(Messages)
        {
            DispClose = false; 
            //alert(Messages);
            setTimeout("reload4()",100)            
        }
        function reload4()
        {
            document.getElementById("<%=Button7.ClientID %>").click();
        }
        
    </script>
</asp:Content>
