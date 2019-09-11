<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tsUser.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="用户列表" HeadTitleTxt="用户">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" OnRowCommand="GridView1_RowCommand" >
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
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
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
                            <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandArgument='<%# Eval("UID") %>' CommandName="SubSet" Text="子号设置">
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
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UID_Input" title="请输入字符串ID~24:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Nickname_Input" title="请输入昵称~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        登录ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="LoginID_Input" title="请输入登录ID~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        登录密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Pass_Input" title="请输入登录密码~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        邮箱</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Email_Input" title="请输入邮箱~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        联系QQ</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="QQ_Input" title="请输入联系QQ~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        联系电话</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Mobile_Input" title="请输入联系电话~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        安全问题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Question_Input" title="请输入安全问题~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        安全答案</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Answer_Input" title="请输入安全答案~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        绑定手机</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BindMobile_Input" title="请输入绑定手机~128:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        支付密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PayPass_Input" title="请输入支付密码~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        登录模式</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="LoginMode_Input" title="请输入登录模式~32767:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        在线状态</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IsOnline_Input" title="请输入在线状态~32767:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        子帐号权限</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="HaveSubUser_Input" runat="server">
                            <asp:ListItem Text="不限" Value=""></asp:ListItem>
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        图标序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IconIndex_Input" title="请输入图标序号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateDate_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        登录时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="LoginDate_Input" title="请输入登录时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="dllUserStatus" runat="server">
                        <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        签名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sign_Input" title="请输入签名~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="子账号权限设置">
            <asp:Label ID="lb_Title1" runat="server" CssClass="menubar_readme_text"></asp:Label><br />
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:Label ID="subUserID" runat="server"></asp:Label>
                    
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        子帐号权限</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlSubAccount" runat="server">
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="2" align="right" style="height: 26px">
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak"  OnClick="Button3_Click" Text="保存"/></td>
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
