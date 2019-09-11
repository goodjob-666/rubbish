<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" 
    CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.JROrderStat.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单介入统计" HeadTitleTxt="订单介入统计">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="客服举报统计">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            游戏<asp:DropDownList ID="ddlGLGameID" runat="server" style="font-size:12px;">
            <asp:ListItem Text="无限制" Value="-1"></asp:ListItem>
            </asp:DropDownList> 
            日期范围<asp:TextBox ID="S_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>
            ~<asp:TextBox ID="E_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" runat="server" CssClass="text_input"></asp:TextBox>
            
            上家<asp:TextBox ID="txtPostUserID" runat="server"></asp:TextBox>

            
                           <asp:CheckBox ID="cbGood" runat="server" Text="优质订单" />

            
                           <asp:Button ID="Button1" runat="server" CssClass="button_bak"
                               Text="查询" OnClick="Button1_Click" />
            <br />
            
            <asp:GridView ID="GridView1" runat="server" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="日期" DataField="StatDate" />
                    <asp:BoundField HeaderText="发单数" DataField="PubStatCount" >
                        <ItemStyle Font-Bold="True" ForeColor="Green" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="撤单数" DataField="CancelStatCount" >
                        <ItemStyle Font-Bold="True" ForeColor="Blue" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="介入订单数" DataField="StatCount" >
                        <ItemStyle Font-Bold="True" ForeColor="Red" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </FrameWorkWebControls:TabOptionItem>
        
    </FrameWorkWebControls:TabOptionWebControls> 
</asp:Content>
