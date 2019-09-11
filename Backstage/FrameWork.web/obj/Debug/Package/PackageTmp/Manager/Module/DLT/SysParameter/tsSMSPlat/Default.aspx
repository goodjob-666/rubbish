<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tsSMSPlat.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="短信平台列表" HeadTitleTxt="短信平台">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="短信平台" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="短信平台列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="平台名称" SortExpression="PlatName" DataField="PlatName" />
                    <asp:BoundField HeaderText="提交地址" SortExpression="PostUrl" DataField="PostUrl" />
                    <asp:BoundField HeaderText="用户名" SortExpression="UserName" DataField="UserName" />
                    <asp:BoundField HeaderText="密码" SortExpression="Password" DataField="Password" />
                    <asp:BoundField HeaderText="应用ID" SortExpression="AppID" DataField="AppID" />
                    <asp:BoundField HeaderText="成功关键字" SortExpression="SuccessKey" DataField="SuccessKey" />
                    <asp:TemplateField SortExpression="SmsStyle" HeaderText="发送方式">
                        <ItemTemplate>
                            <%#SMSStyle((Eval("SmsStyle").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField SortExpression="IsEnable" HeaderText="是否使用">
                        <ItemTemplate>
                            <%#SMSIsEnable(Convert.ToBoolean(Eval("IsEnable")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <div style="display:none"><asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" /></div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        平台名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PlatName_Input" title="请输入平台名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        提交地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PostUrl_Input" title="请输入提交地址~250:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserName_Input" title="请输入用户名~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Password_Input" title="请输入密码~150:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        应用ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AppID_Input" title="请输入应用ID~150:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        成功关键字</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SuccessKey_Input" title="请输入成功关键字~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发送方式</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlSendType" runat="server">
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        是否使用</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsEnable_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
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
