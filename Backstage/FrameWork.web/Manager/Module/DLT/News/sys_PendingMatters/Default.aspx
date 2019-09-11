<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_PendingMatters.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="客服待办事项列表" HeadTitleTxt="客服待办事项">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="客服待办事项列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="P_ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("P_ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="待办事项类型">
                        <ItemTemplate>
                            <%#PendingType((Eval("P_Type").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="待办事项内容">
                        <ItemTemplate>
                            <%#FomartContent((Eval("P_Content").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户ID" DataField="P_UserID" />
                    <asp:BoundField HeaderText="联系方式" DataField="P_Contact" />
                    <asp:BoundField HeaderText="电话号码" DataField="P_OrderNum" />
                    <asp:BoundField HeaderText="记录时间" DataField="P_CreateDate" />
                    <asp:BoundField HeaderText="回复时间" DataField="P_ReplyDate" />
                    <asp:TemplateField HeaderText="记录客服">
                        <ItemTemplate>
                            <%#GetOpLoginID((Eval("P_PostID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderText="备注客服">
                        <ItemTemplate>
                            <%#GetOpLoginID((Eval("P_ReplyID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField SortExpression="P_IsDeal" HeaderText="是否处理">
                        <ItemTemplate>
                            <%#DealType((Eval("P_IsDeal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        事项类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlPendingMattersType" runat="server">
                        <asp:ListItem Value="">不限</asp:ListItem>
                        <asp:ListItem Value="1">客服部</asp:ListItem>
                        <asp:ListItem Value="2">介入部</asp:ListItem>
                        <asp:ListItem Value="3">投诉</asp:ListItem>
                        <asp:ListItem Value="4">其它</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        P_UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_UserID_Input" title="请输入P_UserID~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr style="display:none;">
                    <td class="table_body">
                        P_Contact</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Contact_Input" title="请输入P_Contact~300:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_OrderNum</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_OrderNum_Input" title="请输入P_OrderNum~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        记录时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_CreateDate_Input" title="请输入记录开始时间~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
            ~
            <asp:TextBox ID="P_CreateDate_Input_E" title="请输入记录结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
 
                <tr style="display:none;">
                    <td class="table_body">
                        P_ReplyDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_ReplyDate_Input" title="请输入P_ReplyDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none;">
                    <td class="table_body">
                        P_Content</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Content_Input" title="请输入P_Content~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        记录客服ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_PostID_Input" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        完结客服ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_ReplyID_Input" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_ReContent</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_ReContent_Input" title="请输入P_ReContent~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        是否处理</td>
                    <td class="table_none">
                        <asp:DropDownList ID="P_IsDeal_Input" runat="server">
                        <asp:ListItem Value="">不限</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">处理中</asp:ListItem>
                        <asp:ListItem Value="2">待确定</asp:ListItem>
                        <asp:ListItem Value="3">已处理</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre1</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Pre1_Input" title="请输入P_Pre1~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre2</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Pre2_Input" title="请输入P_Pre2~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre3</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Pre3_Input" title="请输入P_Pre3~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre4</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Pre4_Input" title="请输入P_Pre4~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
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
