<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbAppointArbitration.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="指定客服介入列表" HeadTitleTxt="指定客服介入">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="false" ButtonName="指定客服介入"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="指定客服介入列表">
          <div style="margin:5px 0;">客服ID：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              (只能写一个)&nbsp; <span style="color:Red;">规则外客服ID：</span><asp:TextBox ID="TextBox3" runat="server" Width="579px"></asp:TextBox>
              <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="修改" />
            </div>
          <div>上家ID：<asp:TextBox ID="TextBox2"
            runat="server" Width="400"></asp:TextBox>
              （以英文逗号分隔，最后一个不要加逗号，例如：USR201314151617,USR201314151618）</div>
            <div><asp:Button ID="Button3" runat="server" Text="添加" onclick="Button3_Click" /></div>
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="处理客服ID">
                     <ItemTemplate> <%#DealCustomerID(Eval("CustomerID").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="上家列表">
                     <ItemTemplate> <%#UserIDList(Eval("UserID").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作客服">
                     <ItemTemplate> <%#DealCustomerID(Eval("OpCustomerID").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="添加日期" DataField="CreateDate" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询" Visible="false">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        CustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CustomerID_Input" title="请输入CustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UserID_Input" title="请输入UserID~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateDate_Input" title="请输入CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        Comment</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入Comment~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        OpCustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OpCustomerID_Input" title="请输入OpCustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
