<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.GoodPublish.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

   <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

  <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadOPTxt="优质上家" HeadTitleTxt="优质上家"></FrameWorkWebControls:HeadMenuWebControls>
  <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="优质上家试用">
      <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
          <td>
            <span>申请时间:</span>
            <asp:TextBox ID="S_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
            <asp:TextBox ID="E_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>上家ID:
            <asp:TextBox ID="txtUID0" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="button_bak" OnClick="Button1_Click" Text="查询" />上家ID:
            <asp:TextBox ID="txtUID3" runat="server"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" CssClass="button_bak" OnClick="Button5_Click" Text="添加" /></td>
        </tr>
        <tr>
          <td>
            <asp:GridView ID="GridView1" runat="server" onrowcreated="GridView1_RowCreated" DataKeyNames="ID" onsorting="GridView1_Sorting" onrowcommand="GridView1_RowCommand" onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
              <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" />
                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="上家ID" />
                <asp:BoundField SortExpression="GoodPubCount" ReadOnly="true" DataField="GoodPubCount" HeaderText="优质发单数" />
                <asp:BoundField SortExpression="GoodPubCancelRate" ReadOnly="true" DataField="GoodPubCancelRate" HeaderText="优质发单撤单率" />
                <asp:BoundField SortExpression="GoodPubJudgeCancelRate" ReadOnly="true" DataField="GoodPubJudgeCancelRate" HeaderText="优质发单介入率" />
                <asp:BoundField SortExpression="GoodSettleHour" ReadOnly="true" DataField="GoodSettleHour" HeaderText="优质区均单验收时间" />
                <asp:BoundField DataField="FreeBal" ReadOnly="true" HeaderText="账号资金" />
                <asp:BoundField SortExpression="ApplyDate" ReadOnly="true" DataField="ApplyDate" HeaderText="申请时间" />
                <asp:BoundField SortExpression="DateDiff(hh,a.ApplyDate,getdate())" ReadOnly="true" DataField="CheckDateCount" HeaderText="审核天数" />
                <asp:BoundField DataField="LockStatus" ReadOnly="true" HeaderText="用户状态" />
                <asp:TemplateField HeaderText="备注">
                  <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要通过优质上家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="Pass" Text="通过"></asp:LinkButton>&nbsp;&nbsp;
                    <!--<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要不通过优质上家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="NoPass" Text="不通过"></asp:LinkButton>-->
                    <a href='javascript:showPopWin("不通过优质上家","GoodPast.aspx?Flag=0&ID=<%# Eval("ID") %>",600, 100, AlertMessageBox1,false)'>不通过</a>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" onpagechanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
          </td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="未通过上家">
      <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
          <td>上家ID:
            <asp:TextBox ID="txtUID" runat="server"></asp:TextBox>
            <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="查询" onclick="Button2_Click" /></td>
        </tr>
        <tr>
          <td>
            <asp:GridView ID="GridView2" runat="server" onrowcreated="GridView2_RowCreated" onsorting="GridView2_Sorting" onrowcommand="GridView2_RowCommand" onrowcancelingedit="GridView2_RowCancelingEdit" onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating">
              <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager2.CurrentPageIndex - 1) * this.AspNetPager2.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" />
                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="上家ID" />
                <asp:BoundField SortExpression="ApplyDate" ReadOnly="true" DataField="ApplyDate" HeaderText="申请时间" />
                <asp:BoundField SortExpression="GoodPubCount" ReadOnly="true" DataField="GoodPubCount" HeaderText="优质发单数" />
                <asp:BoundField SortExpression="GoodPubCancelRate" ReadOnly="true" DataField="GoodPubCancelRate" HeaderText="优质发单撤单率" />
                <asp:BoundField SortExpression="GoodPubJudgeCancelRate" ReadOnly="true" DataField="GoodPubJudgeCancelRate" HeaderText="优质发单介入率" />
                <asp:BoundField SortExpression="GoodSettleHour" ReadOnly="true" DataField="GoodSettleHour" HeaderText="优质区均单验收时间" />
                <asp:BoundField SortExpression="a.ChangeDate" ReadOnly="true" DataField="ChangeDate" HeaderText="未通过时间" />
                <asp:TemplateField HeaderText="备注">
                  <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClientClick="return confirm('确定要删除优质上家吗？');" Text="删除"></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" onpagechanged="AspNetPager2_PageChanged"></FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button8" runat="server" CssClass="button_bak" 
                            OnClientClick="return deleteop();" Text="删除" Visible="false" 
                  onclick="Button8_Click" />
          </td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="优质上家">
      <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
          <td>
            <span>通过时间:</span>
            <asp:TextBox ID="S_dtDate_Input1" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
            <asp:TextBox ID="E_dtDate_Input1" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>上家ID:
            <asp:TextBox ID="txtUID1" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="查询" onclick="Button3_Click" /></td>
        </tr>
        <tr>
          <td>
            <asp:GridView ID="GridView3" runat="server" onrowcreated="GridView3_RowCreated" onsorting="GridView3_Sorting" onrowcommand="GridView3_RowCommand" onrowcancelingedit="GridView3_RowCancelingEdit" onrowediting="GridView3_RowEditing" onrowupdating="GridView3_RowUpdating">
              <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager3.CurrentPageIndex - 1) * this.AspNetPager3.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" />
                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="上家ID" />
                <asp:BoundField SortExpression="a.ChangeDate" ReadOnly="true" DataField="ChangeDate" HeaderText="通过时间" />
                <asp:BoundField SortExpression="GoodPubCount" ReadOnly="true" DataField="GoodPubCount" HeaderText="优质发单数" />
                <asp:BoundField SortExpression="GoodPubCancelRate" ReadOnly="true" DataField="GoodPubCancelRate" HeaderText="优质发单撤单率" />
                <asp:BoundField SortExpression="GoodPubJudgeCancelRate" ReadOnly="true" DataField="GoodPubJudgeCancelRate" HeaderText="优质发单介入率" />
                <asp:BoundField SortExpression="GoodSettleHour" ReadOnly="true" DataField="GoodSettleHour" HeaderText="优质区均单验收时间" />
                <asp:BoundField SortExpression="CheckDate" ReadOnly="true" DataField="CheckDate" HeaderText="考核时间" />
                <asp:BoundField DataField="LockStatus" ReadOnly="true" HeaderText="用户状态" />
                <asp:TemplateField HeaderText="备注">
                  <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要考核优质上家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="Check" Text="考核"></asp:LinkButton>&nbsp;&nbsp;
                    <!--<asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" OnClientClick="return confirm('确定要踢出优质上家吗？');" CommandArgument='<%# Eval("ID") %>' CommandName="KickOut" Text="踢出"></asp:LinkButton>-->
                    <a href='javascript:showPopWin("踢出优质上家","GoodPast.aspx?Flag=3&ID=<%# Eval("ID") %>",600, 100, AlertMessageBox3,false)'>踢出</a>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager3" runat="server" onpagechanged="AspNetPager3_PageChanged"></FrameWorkWebControls:AspNetPager>
          </td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="已踢出上家">
      <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
          <td>上家ID:
            <asp:TextBox ID="txtUID2" runat="server"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" CssClass="button_bak" Text="查询" onclick="Button4_Click" /></td>
        </tr>
        <tr>
          <td>
            <asp:GridView ID="GridView4" runat="server" onrowcreated="GridView4_RowCreated" onsorting="GridView4_Sorting" onrowcommand="GridView4_RowCommand" onrowcancelingedit="GridView4_RowCancelingEdit" onrowediting="GridView4_RowEditing" onrowupdating="GridView4_RowUpdating">
              <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager4.CurrentPageIndex - 1) * this.AspNetPager4.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                <asp:BoundField DataField="ID" ReadOnly="true" HeaderText="ID" />
                <asp:BoundField DataField="UID" ReadOnly="true" HeaderText="上家ID" />
                <asp:BoundField SortExpression="a.ChangeDate" ReadOnly="true" DataField="ChangeDate" HeaderText="通过时间" />
                <asp:BoundField SortExpression="GoodPubCount" ReadOnly="true" DataField="GoodPubCount" HeaderText="优质发单数" />
                <asp:BoundField SortExpression="GoodPubCancelRate" ReadOnly="true" DataField="GoodPubCancelRate" HeaderText="优质发单撤单率" />
                <asp:BoundField SortExpression="GoodPubJudgeCancelRate" ReadOnly="true" DataField="GoodPubJudgeCancelRate" HeaderText="优质发单介入率" />
                <asp:BoundField SortExpression="GoodSettleHour" ReadOnly="true" DataField="GoodSettleHour" HeaderText="优质区均单验收时间" />
                <asp:BoundField SortExpression="KickOutDate" ReadOnly="true" DataField="KickOutDate" HeaderText="踢出时间" />
                <asp:TemplateField HeaderText="备注">
                  <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                  </EditItemTemplate>
                  <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                  </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="编辑备注" ShowEditButton="True" />
                <asp:TemplateField HeaderText="操作" ShowHeader="False">
                  <ItemTemplate>
                    <asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="return confirm('确定要删除优质上家吗？');" Text="删除"></asp:LinkButton>
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager4" runat="server" onpagechanged="AspNetPager4_PageChanged"></FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button9" runat="server" CssClass="button_bak" 
                            OnClientClick="return deleteop();" Text="删除" Visible="false" 
                  onclick="Button9_Click" />
          </td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="优质区日志查询">
      <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
        <tr>
          <td>用户ID:
            <asp:TextBox ID="txtUID8" runat="server"></asp:TextBox>
            <asp:Button ID="Button6" runat="server" CssClass="button_bak" Text="查询" 
                  onclick="Button6_Click"/></td>
        </tr>
        <tr>
          <td>
            <asp:GridView ID="GridView5" runat="server">
              <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                    <ItemTemplate>
                        <%# (this.AspNetPager5.CurrentPageIndex - 1) * this.AspNetPager5.PageSize + Container.DataItemIndex + 1%>
                    </ItemTemplate>
                    <ItemStyle Wrap="True" />  
                    <HeaderStyle Wrap="False" />    
                </asp:TemplateField>
                <asp:BoundField ReadOnly="true" DataField="UID" HeaderText="用户ID" />
                <asp:BoundField ReadOnly="true" DataField="ApplyType" HeaderText="优质类别" />
                <asp:BoundField ReadOnly="true" DataField="ChangeDate" HeaderText="变动时间" />
                <asp:BoundField ReadOnly="true" DataField="Comment" HeaderText="日志内容" />
                <asp:BoundField ReadOnly="true" DataField="CustName" HeaderText="客服" />
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager5" runat="server" 
                  onpagechanged="AspNetPager5_PageChanged"></FrameWorkWebControls:AspNetPager>
          </td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
  </FrameWorkWebControls:TabOptionWebControls>
  <script language="JavaScript" type="text/javascript">
        
        function SelectAll() {
            var e = document.getElementsByTagName("input");
            var IsTrue;
            if (document.getElementById("CheckboxAll").value == "0") {
                IsTrue = true;
                document.getElementById("CheckboxAll").value = "1"
            }
            else {
                IsTrue = false;
                document.getElementById("CheckboxAll").value = "0"
            }
            
            for(var i=0;i<e.length;i++)
            {
                if (e[i].type=="checkbox")
                {
                    if (e[i].id == "ctl00_PageBody_chkUpTier") {
                        continue;
                    }
                    else {
                        e[i].checked = IsTrue;
                    }
                }
            }   
        }
        
        function deleteop() {
            var checkok = false;
            var e = document.getElementsByTagName("input");
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    if (e[i].checked == true) {
                        checkok = true;
                        break;
                    }
                }
            }
            if (checkok)
                return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
            else {

                alert("请选择要删除的记录!");
                return false;
            }
        }
  
        function AlertMessageBox1(Messages)
        {
            DispClose = false; 
            //alert(Messages);
            setTimeout("reload1()",100)            
        } 
        function reload1()
        {
            document.getElementById("<%=Button1.ClientID %>").click();
        }
        
        function AlertMessageBox3(Messages)
        {
            DispClose = false; 
            //alert(Messages);
            setTimeout("reload3()",100)            
        }
        function reload3()
        {
            document.getElementById("<%=Button3.ClientID %>").click();
        }
        
    </script>
</asp:Content>
