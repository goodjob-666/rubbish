<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Finance.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
     
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls2" runat="server"
         HeadOPTxt="用户报表" HeadTitleTxt="用户" HeadTitleIcon="default.gif">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>


    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户列表">
            <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <asp:GridView ID="GridView1" runat="server" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1%> 
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  

                    <asp:BoundField HeaderText="角色名次数" DataField="RoleNameCount" />

                    <asp:BoundField HeaderText="总报名次数" DataField="TotalNum" />

                    <asp:BoundField HeaderText="赢次数" DataField="TotalWinNum" />

                    <asp:BoundField HeaderText="胜率" DataField="lv" />
                    
                    <asp:BoundField HeaderText="报名金额" DataField="BaomingBal" />
                   
                    <asp:BoundField HeaderText="结算金额" DataField="ResultBal" />

                    <asp:BoundField HeaderText="结果金额" DataField="TotalBal" />

                    <asp:BoundField HeaderText="收益比" DataField="Profit" />

                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>

            <asp:Panel ID="Panel1" runat="server" Visible="false" style=" float:right; color:Red; font-size:18px;">
                总角色名次数合计：<asp:Label ID="lblRoleNameCount" runat="server" ></asp:Label>

                总报名次数合计：<asp:Label ID="lblTotalNum" runat="server" ></asp:Label>

                赢次数合计：<asp:Label ID="lblTotalWinNum" runat="server" ></asp:Label>

                胜率：<asp:Label ID="lblLv" runat="server" ></asp:Label>

                总报名金额：<asp:Label ID="lblBaoMing" runat="server" ></asp:Label>

                总结算金额：<asp:Label ID="lblJieSuan" runat="server" ></asp:Label>

                用户总盈亏：<asp:Label ID="lblTotalMoney" runat="server" ></asp:Label>

                收益比合计：<asp:Label ID="lblProfit" runat="server" ></asp:Label>
            </asp:Panel>
           
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UID_Input" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox>
                        <font color="red">例如：用户ID为1234567</font>
                    </td>
                </tr>
               
               
                <tr>
                    <td class="table_body">
                        活动类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlActivity" runat="server">
                        <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>

                <tr>
                  <td class="table_body">日期范围</td>
                    <td class="table_none">
                  <%--<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>--%>
                  <asp:TextBox ID="S_dtDate_Input" runat="server" class="Wdate" Columns="20" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入开始时间~:datetime"></asp:TextBox>
                    ~
                    <%--<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    <asp:TextBox ID="E_dtDate_Input" runat="server" class="Wdate" Columns="20" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入结束日期~:datetime"></asp:TextBox>
                </td>
                </tr>
               
              
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
       
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
