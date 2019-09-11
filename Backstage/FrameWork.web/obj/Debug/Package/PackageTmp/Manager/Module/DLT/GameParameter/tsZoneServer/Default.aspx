<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tsZoneServer.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="区服汇总列表" HeadTitleTxt="区服汇总">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="区服汇总" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="区服汇总列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="编码" SortExpression="Code" DataField="Code" />
                    <asp:BoundField HeaderText="游戏ID" SortExpression="GameID" DataField="GameID" />
                    <asp:BoundField HeaderText="游戏" SortExpression="Game" DataField="Game" />
                    <asp:BoundField HeaderText="大区ID" SortExpression="ZoneID" DataField="ZoneID" />
                    <asp:BoundField HeaderText="大区" SortExpression="Zone" DataField="Zone" />
                    <asp:BoundField HeaderText="服务器ID" SortExpression="ServerID" DataField="ServerID" />
                    <asp:BoundField HeaderText="服务器" SortExpression="Server" DataField="Server" />
                    <asp:BoundField HeaderText="阵营ID" SortExpression="FactionID" DataField="FactionID" />
                    <asp:BoundField HeaderText="阵营" SortExpression="Faction" DataField="Faction" />
                    <asp:BoundField HeaderText="拼音全称" SortExpression="SpellFull" DataField="SpellFull" />
                    <asp:BoundField HeaderText="拼音简称" SortExpression="SpellShort" DataField="SpellShort" />
                    <asp:TemplateField SortExpression="IsOnline" HeaderText="运营状态">
                        <ItemTemplate>
                            <%#IsOnline((Eval("IsOnline").ToString()))%>
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
                        编码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Code_Input" title="请输入编码~18:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        游戏ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="GameID_Input" title="请输入游戏ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Game_Input" title="请输入游戏~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        大区ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ZoneID_Input" title="请输入大区ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        大区</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Zone_Input" title="请输入大区~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        服务器ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ServerID_Input" title="请输入服务器ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        服务器</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Server_Input" title="请输入服务器~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        阵营ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FactionID_Input" title="请输入阵营ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        阵营</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Faction_Input" title="请输入阵营~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        拼音全称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SpellFull_Input" title="请输入拼音全称~250:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        拼音简称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SpellShort_Input" title="请输入拼音简称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        运营状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsOnline_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
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
