<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbPostReport.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="举报用户列表" HeadTitleTxt="举报用户列表">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="举报用户列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="订单号" DataField="SerialNo" />
                    <asp:TemplateField HeaderText="用户ID">
                     <ItemTemplate> <%#UID(Eval("UserID").ToString())%> <%#IsDown(Eval("Remark").ToString())%></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("UserID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="举报客服ID">
                     <ItemTemplate> <%#DealCustomerID(Eval("ReportCustomerID").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="举报日期" DataField="CreateDate" />
                    <asp:TemplateField HeaderText="是否处理">
                     <ItemTemplate> 
                         <asp:CheckBox ID="cbIsDeal" runat="server" OnCheckedChanged="cbIsDeal_CheckedChanged" AutoPostBack="true" ValidationGroup='<%#Eval("SerialNo")%>' />（勾选即生效）
                         <asp:HiddenField ID="hfIsDeal" runat="server" Value='<%#Eval("Status")%>' />
                     </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="处理客服ID">
                     <ItemTemplate> <%#DealCustomerID(Eval("DealCustomerID").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="处理日期" DataField="DealDate" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false"  PostBackUrl='<%# Eval("SerialNo","../../service/tbLevelOrder/default.aspx?SerialNo={0}")%>' Text="订单详情">
                            </asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("UserID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <div><asp:Label ID="lblReportCount" runat="server" Text=""></asp:Label></div>
            <div style="display:none;"><asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" /></div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SerialNo_Input" title="请输入SerialNo~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入UserID~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        举报客服</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ReportCustomerID_Input" title="请输入ReportCustomerID~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        举报日期</td>
                    <td class="table_none">
                        <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
            ~
            <asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        处理客服ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DealCustomerID_Input" title="请输入DealCustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        DealDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DealDate_Input" title="请输入DealDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        Status</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Status_Input" title="请输入Status~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        Remark</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入Remark~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script language="javascript" type="text/javascript">
<!--

function SelectAll()
{
   var e=document.getElementsByTagName("input");
   var IsTrue;
   if(document.getElementById("CheckboxAll").value=="0")
　 {
　　 IsTrue=true;
　　 document.getElementById("CheckboxAll").value="1"
　 }
　 else
　 {
　　IsTrue=false;
　　document.getElementById("CheckboxAll").value="0"
　　}
　　
　for(var i=0;i<e.length;i++)
　{
　　if (e[i].type=="checkbox")
　　{
　　   e[i].checked=IsTrue;
　　}
　}
}
function deleteop()
{
    var checkok = false;
    var e=document.getElementsByTagName("input");
    for(var i=0;i<e.length;i++)
　  {
　     if (e[i].type=="checkbox")
　　     {
　　         if (e[i].checked==true)
　　         {
　　             checkok = true;
　　             break;　　             
　　         }
　　     }  
　  }
　  if (checkok) 
        return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
    else
    {
        
        alert("请选择要删除的记录!");
        return false;
    }
}
// -->
    </script>

</asp:Content>
