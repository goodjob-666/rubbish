<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tsRightLock.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="权限锁定列表" HeadTitleTxt="权限锁定">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="权限锁定列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" 
                OnRowCreated="GridView1_RowCreated" onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户ID" DataField="UID" />
                    <asp:TemplateField HeaderText="锁定类别">
                        <ItemTemplate>
                            <%#LockType((Eval("LockType").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="MAC关联帐号">
                        <ItemTemplate>
                            <asp:Label ID="lblMAC" runat="server" Text="MAC信息"></asp:Label>
                           <asp:HiddenField ID="hf" runat="server" Value='<%# Eval("UserID") %>' />
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="所有相关用户">
                        <ItemTemplate>
                            <asp:Label ID="lblUserList" runat="server" Text="相关用户列表"></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:BoundField HeaderText="开始日期" DataField="StartDate" />
                    <asp:BoundField HeaderText="结束日期" DataField="EndDate" />
                    <asp:BoundField HeaderText="通知内容" DataField="Notice" />
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("UserID","Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
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
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入用户ID~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        锁定类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlLockType" runat="server">
                        <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        是否永久</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsForever_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        开始日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="S_dtDate_Input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~date" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        结束日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="E_dtDate_Input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~date" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        通知内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Notice_Input" TextMode="MultiLine" Columns="10" Width="418px" Height="118px" title="请输入通知内容~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateDate_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
