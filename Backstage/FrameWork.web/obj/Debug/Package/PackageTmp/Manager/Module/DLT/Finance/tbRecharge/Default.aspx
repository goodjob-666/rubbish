<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.btRecharge.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="客户充值管理" HeadTitleTxt="客户充值管理">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="充值记录">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="流水号" DataField="SerialNo" />
                    <asp:BoundField HeaderText="用户ID" DataField="UserID" />
                    
                     <asp:TemplateField HeaderText="昵称">
                        <ItemTemplate>
                           <%# FrameWork.Common.Base64Decode(Eval("NickName").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="金额">
                      <ItemTemplate> <%#SaveTwoPointer(Eval("Bal").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="外部流水号" DataField="ExChargeNo" />
                    <asp:BoundField HeaderText="时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="备注" DataField="Comment" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager> 
            <asp:Label ID="lblTotalRecharge" runat="server" style="color:Teal; margin-left:5px;" Text=""></asp:Label>  
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        日期范围</td>
                    <td class="table_none">

                        <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="vcSerialNo_Input" title="请输入流水号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="vcUserID_Input" title="请输入用户ID~24:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>

                 <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="vcNickName_Input" title="请输入昵称~24:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                              
                <tr>
                    <td class="table_body">
                        金额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="nmBal_Input" title="请输入金额~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        外部流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="vcExChargeNo_Input" title="请输入外部流水号~512:" runat="server" Width="250px" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="查询" OnClick="Button2_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="导出" OnClick="Button3_Click" />
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
       
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
