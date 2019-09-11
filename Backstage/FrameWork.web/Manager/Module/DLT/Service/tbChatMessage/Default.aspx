<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbChatMessage.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="双排聊天内容列表" HeadTitleTxt="双排聊天内容">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="双排聊天内容列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户ID" SortExpression="UID" DataField="UID" />
                    <asp:BoundField HeaderText="昵称" SortExpression="NickName" DataField="NickName" />
                    <asp:BoundField HeaderText="聊天内容" SortExpression="Comment" DataField="Comment" />
                    <asp:BoundField HeaderText="聊天用户ID" SortExpression="Comment" DataField="TargetID" />
                    <asp:BoundField HeaderText="生成聊天时间" SortExpression="CreateDate" DataField="CreateDate" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <div style="display:none"><asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" /></div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr style="display:none">
                    <td class="table_body">
                        UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入UserID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UID_Input" title="请输入UID~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="NickName_Input" title="请输入NickName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        IconIndex</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IconIndex_Input" title="请输入IconIndex~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        ChatType</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ChatType_Input" title="请输入ChatType~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        TargetID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TargetID_Input" title="请输入TargetID~10:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        聊天内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入Comment~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        生成聊天内容时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox> 至
                        <asp:TextBox ID="EndCreateDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);" Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        BeginTime</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BeginTime_Input" title="请输入BeginTime~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
