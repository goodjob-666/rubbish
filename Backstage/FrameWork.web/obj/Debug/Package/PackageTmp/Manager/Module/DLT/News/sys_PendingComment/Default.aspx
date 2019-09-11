<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_PendingComment.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="待办留言列表" HeadTitleTxt="待办留言列表">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="待办留言列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="P_CommentID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="客服ID">
                        <ItemTemplate>
                            <%#GetLoginName((Eval("P_CommentPostID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="待办内容">
                        <ItemTemplate>
                            <%#PendingTitle((Eval("P_PendingID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="留言内容">
                        <ItemTemplate>
                            <%#FomartContent((Eval("P_CommentContent").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="留言时间" DataField="P_Pre" />
                    <asp:TemplateField HeaderText="事项状态">
                        <ItemTemplate>
                            <%#PendingStatus((Eval("P_CommentStauts").ToString()))%>
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
                <tr style="display:none">
                    <td class="table_body">
                        P_PendingID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_PendingID_Input" title="请输入P_PendingID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        客服ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_CommentPostID_Input" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        事项状态</td>
                    <td class="table_none">
                        <asp:DropDownList ID="P_CommentStauts_Input" runat="server">
                        <asp:ListItem Value="">不限</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">处理中</asp:ListItem>
                        <asp:ListItem Value="2">待确定</asp:ListItem>
                        <asp:ListItem Value="3">已处理</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        留言内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_CommentContent_Input" title="请输入P_CommentContent~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none">
                    <td class="table_body">
                        P_CommentRemarks</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_CommentRemarks_Input" title="请输入P_CommentRemarks~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none">
                    <td class="table_body">
                        P_Pre</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="P_Pre_Input" title="请输入P_Pre~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
