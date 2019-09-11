<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbFeedBack.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="客户反馈列表" HeadTitleTxt="客户反馈">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="客户反馈列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" 
                OnRowCreated="GridView1_RowCreated" onrowcommand="GridView1_RowCommand" 
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                       <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户ID" ItemStyle-Width="100">
                        <ItemTemplate>
                            <%#GetUID((Eval("UserID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="联系QQ" ItemStyle-Width="100">
                      <ItemTemplate>
                     <%#Mobile(Eval("UserID").ToString())%>
                      </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="绑定手机" ItemStyle-Width="100">
                      <ItemTemplate>
                     <%#BindMobile(Eval("UserID").ToString())%>
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="反馈内容" DataField="Feedback" />
                    <asp:BoundField HeaderText="提交时间" DataField="CreateDate" />
                                        <asp:TemplateField HeaderText="是否标记">
                     <ItemTemplate> 
                         <asp:CheckBox ID="cbIsDeal" runat="server" OnCheckedChanged="cbIsDeal_CheckedChanged" AutoPostBack="true" ValidationGroup='<%#Eval("ID")%>' />（勾选即生效）
                         <asp:HiddenField ID="hfIsDeal" runat="server" Value='<%#Eval("Mark")%>' />
                     </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="备注">
                                    <ItemTemplate>
                                        <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="260" runat="server"></asp:TextBox>
                                        <asp:Button ID="btnUpdate"
                                            runat="server" Text="修改" CommandName="UpdateComment" CommandArgument='<%# Eval("ID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <!--<asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />-->
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入用户ID~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        提交来源</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Source_Input" title="请输入提交来源~10:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        反馈内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Feedback_Input" title="请输入反馈内容~2048:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        提交时间</td>
                    <td class="table_none">
                     
                     <asp:TextBox ID="CreateDate_Input" title="请输入登录开始时间~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
            ~
            <asp:TextBox ID="CreateDate_Input_E" title="请输入登录结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                     
                    
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
