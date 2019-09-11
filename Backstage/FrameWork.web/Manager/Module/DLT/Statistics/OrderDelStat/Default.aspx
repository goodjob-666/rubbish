<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" 
    CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.OrderDelStat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="删除订单统计" HeadTitleTxt="删除订单统计">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="删除订单统计">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>
            操作员ID<asp:TextBox ID="tbOPName" runat="server" Columns="10" CssClass="text_input"></asp:TextBox>
                           <asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />
            <br />
            
            <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="日期" DataField="StatDate" />
                       <asp:TemplateField HeaderText="操作员ID"> 
                        <ItemTemplate>
                        <%#GetOpLoginName(Eval("DelCustomerID").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="处理订单数" DataField="StatCount" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            &nbsp;<br />
            <asp:Button ID="Button2" Visible="true" CssClass="button_bak" runat="server" Text="刷新" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
