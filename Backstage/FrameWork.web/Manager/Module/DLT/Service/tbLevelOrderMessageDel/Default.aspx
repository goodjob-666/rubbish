<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbLevelOrderMessageDel.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="删除订单留言" HeadTitleTxt="删除订单留言">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="删除订单留言" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="删除订单留言">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="订单流水号" SortExpression="ODSerialNo" DataField="ODSerialNo" />
                    <asp:BoundField HeaderText="用户ID" SortExpression="UID" DataField="UID" />
                    <asp:TemplateField SortExpression="MsgType" HeaderText="留言类别">
                        <ItemTemplate>
                            <%#MsgType((Eval("MsgType").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="留言内容" SortExpression="Msg" DataField="Msg" />
                    <asp:BoundField HeaderText="创建时间" SortExpression="CreateDate" DataField="CreateDate" />
                    
                    <asp:TemplateField SortExpression="IsRead" HeaderText="发单方">
                        <ItemTemplate>
                            <%#IsRead((Eval("IsRead").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="IsRead2" HeaderText="接单方">
                        <ItemTemplate>
                            <%#IsRead((Eval("IsRead2").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <script type="text/javascript">
          document.getElementById("CheckboxAll").style.display = "none";
      </script>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ODSerialNo_Input" title="请输入订单流水号~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <!--<tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入用户ID~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        留言类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlMessageType" runat="server">
                        <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        留言内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Msg_Input" title="请输入留言内容~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateDate_Input" onfocus="javascript:HS_setDate(this);" title="请输入创建时间~date"  runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发单方</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsRead_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="已读" Value="1"></asp:ListItem>
                            <asp:ListItem Text="未读" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        接单方</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsRead2_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="已读" Value="1"></asp:ListItem>
                            <asp:ListItem Text="未读" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>-->
                <tr style="display:none;">
                    <td class="table_body">
                        V1ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="V1ID_Input" title="请输入V1ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
