<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.UserAnalysis.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="封停用户跟踪" HeadTitleTxt="封停用户跟踪">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="封停用户跟踪列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="子号权限">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#HaveSubUser((Eval("HaveSubUser").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
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
                        锁定类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlLockType" runat="server">
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
