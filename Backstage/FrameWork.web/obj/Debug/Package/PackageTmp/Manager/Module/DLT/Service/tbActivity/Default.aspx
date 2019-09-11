<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbActivity.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="平台活动列表" HeadTitleTxt="平台活动管理">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="平台活动" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="平台活动列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" 
                OnRowCreated="GridView1_RowCreated" 
                onrowdatabound="GridView1_RowDataBound" onrowcommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="活动ID" DataField="ID" />
                    <asp:BoundField HeaderText="标题" DataField="Title" />
                     <asp:TemplateField HeaderText="用户类型">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID")%>' />
                                        <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType")%>' ></asp:Label>
                                    </ItemTemplate>
                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="游戏">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGameID" runat="server" Text='<%# Eval("GameID")%>' ></asp:Label>
                                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="开始时间" DataField="StartDate" />
                    <asp:BoundField HeaderText="结束时间" DataField="EndDate" />
                    <asp:TemplateField HeaderText="活动频道">
                                    <ItemTemplate>
                                        <asp:Label ID="lblChannel" runat="server" Text='<%# Eval("Channel")%>' ></asp:Label>
                                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="红包金额">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                        <asp:Label ID="lblPirce2" runat="server" Text='<%# Eval("Pirce2")%>'></asp:Label>
                                        <asp:Label ID="lblPrice3" runat="server" Text='<%# Eval("Price3")%>'></asp:Label>
                                    </ItemTemplate>
                    </asp:TemplateField>
  
                    <asp:BoundField HeaderText="发送日期" DataField="SendDate" />
                     <asp:TemplateField HeaderText="订单数"> 
                        <ItemTemplate>
                        <asp:Label ID="lblOrderCount" runat="server" Text="" ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    
        <asp:TemplateField HeaderText="操作" ShowHeader="False">
          <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("ID") %>' CommandName="ActivityDetail"
                                Text="活动详情"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="修改"> 
                        <ItemTemplate>
                        <a href="Manager1.aspx?IDX=<%#Eval("ID")%>&CMD=Edit">修改</a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="平台活动查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        活动标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Title_Input" title="请输入Title~256:" runat="server" 
                            CssClass="text_input" Width="273px"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="下家" Value="10"></asp:ListItem>
                        <asp:ListItem Text="上家" Value="11"></asp:ListItem>
                        </asp:DropDownList>

                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlGameID" runat="server">
                        <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        活动时间</td>
                    <td class="table_none">
                     
                       <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                        ~
            <asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>

                <tr>
                    <td class="table_body">
                        活动频道</td>
                    <td class="table_none">
                     <asp:DropDownList ID="ddlChannel" runat="server">
                        <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="内部" Value="10"></asp:ListItem>
                        <asp:ListItem Text="公共" Value="11"></asp:ListItem>
                         <asp:ListItem Text="优质" Value="13"></asp:ListItem>
                        <asp:ListItem Text="内部、公共" Value="12"></asp:ListItem>
                         <asp:ListItem Text="内部、优质" Value="14"></asp:ListItem>
                         <asp:ListItem Text="公共、优质" Value="15"></asp:ListItem>
                         <asp:ListItem Text="内部、公共、优质" Value="16"></asp:ListItem>
                        </asp:DropDownList>
                        
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        Price</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Price_Input" title="请输入Price~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none">
                    <td class="table_body">
                        SendDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SendDate_Input" title="请输入SendDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none">
                    <td class="table_body">
                        Status</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Status_Input" title="请输入Status~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr  style="display:none">
                    <td class="table_body">
                        Comment</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入Comment~2048:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="平台活动详情">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr>
          <td class="table_body table_body_NoWidth">活动标题</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="lblTitle" runat="server"></asp:Label><asp:HiddenField ID="hfID"
                  runat="server" />
          </td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">红包金额</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblPrice" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
              <asp:HiddenField ID="hfP1" runat="server" />
              <asp:HiddenField ID="hfP2" runat="server" />
              <asp:HiddenField ID="hfP3" runat="server" />
          </td>
          <td class="table_body table_body_NoWidth">游戏</td>
          <td class="table_none table_none_NoWidth"><asp:Label ForeColor="Red" Font-Bold="True" Font-Size="Medium" ID="lblGameID" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">用户类型</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblUserType" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">活动频道</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblChannel" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">开始时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblStartDate" runat="server"  ForeColor="Blue"></asp:Label></td>
          <td class="table_body table_body_NoWidth">结束时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblEndDate" runat="server" ForeColor="Blue"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">创建时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblCreateDate" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">订单数量</td>
          <td class="table_none table_none_NoWidth">
              <asp:Label ID="lblCount" runat="server" Text=""></asp:Label></td>
        </tr>
                <tr>
          <td class="table_body table_body_NoWidth">发送时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="lblSendDate" runat="server" ForeColor="Blue"></asp:Label></td>
          <td class="table_body table_body_NoWidth"></td>
          <td class="table_none table_none_NoWidth">
              </td>
        </tr>

        <tr>
          <td class="table_body table_body_NoWidth">后台备注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:TextBox ID="txtComment" runat="server" Columns="10" CssClass="text_input" Width="328px" Height="118px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" CssClass="button_bak" Text="修改备注" OnClick="Button5_Click" /><asp:Label
                ID="lblUpdateComment" runat="server" Text=""></asp:Label>
              <asp:TextBox ID="txtOrderComment" runat="server" TextMode="MultiLine" 
                  Width="328px" Height="118px"></asp:TextBox><asp:Button ID="Button6" 
                  runat="server" CssClass="button_bak"
                      Text="一键备注" onclick="Button6_Click" /><asp:Label ID="lblUpdateOrderComment" runat="server" Text=""></asp:Label>
                  </td>
        </tr>
      </table>
      <div id="divInput" runat="server" style="margin:20px 0; background-color:#cadee8; padding:5px;">
          订单号：
          <asp:TextBox ID="txtOrderNum" runat="server" Width="206px"></asp:TextBox> 
          
          <asp:Button ID="btnAddOrder" runat="server" Text="添加订单" 
              onclick="btnAddOrder_Click" /> &nbsp;&nbsp;
              
          <a runat="server" id="batchA" style="font-size:16px; color:Red;">【批量添加订单】</a>
          
          
          
          <asp:Button ID="btnHid" runat="server" OnClick="btnHid_Click" Width="0px" style="display:none;" />
     <asp:HiddenField ID="hid" runat="server" />
          
              <asp:Button ID="btnSendPrice" runat="server" 
              Text="已确认订单，进行充值" 
              style="float:right;background-color:Green;color:#FFF;" 
              onclick="btnSendPrice_Click1"/> <span style="float:right">返利备注：<asp:TextBox ID="txtSendComment" runat="server"></asp:TextBox></span></div>
              <br />
              <div style="font-weight:bold;margin-top:20px;">已添加进活动的订单列表：</div>
      <iframe id="framelist" name="framelist" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe() {
              var iframe = document.getElementById("ctl00_PageBody_framelist");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe()", 200);
</script>
<div style="font-weight:bold;margin-top:20px;">本活动已删除的订单列表：</div>
     <iframe id="framelist1" name="framelist1" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe1() {
              var iframe = document.getElementById("ctl00_PageBody_framelist1");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe1()", 200);
</script>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="活动订单列表">
            <asp:GridView ID="GridView2" runat="server" OnRowDataBound="GridView2_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
        <asp:BoundField HeaderText="订单号" DataField="ID" Visible="false" />
        <asp:BoundField HeaderText="活动名称" DataField="Title" />
        <asp:BoundField HeaderText="订单号" DataField="SerialNo" />
        <asp:BoundField HeaderText="发布者" DataField="PostNickName" />
        <asp:BoundField HeaderText="角色名" DataField="Actor" />
        <asp:TemplateField HeaderText="接单者">
          <ItemTemplate>
         <%#AcceptUserID(Eval("AcceptUserID").ToString())%>
         <asp:HiddenField ID="hfActivityID"  runat="server"  Value='<%# Eval("ActivityID")%>'/>
         <asp:HiddenField ID="hfAcceptUserID" runat="server" Value='<%# Eval("AcceptUserID")%>'/>
              <asp:Label ID="lblOrderSum" runat="server" Text=""></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="标题" DataField="OrderTitle" />
        <asp:TemplateField HeaderText="金额">
          <ItemTemplate> <%#SaveTwoPointer(Eval("Price").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="保证金" DataField="Ensure" />
        <asp:TemplateField HeaderText="订单状态">
          <ItemTemplate> <%#Status(Eval("Status").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="撤销状态">
          <ItemTemplate> <%#CancelStatus(Eval("CancelStatus").ToString())%> </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="接单时间">
          <ItemTemplate>
              <asp:Label ID="lblOrderStartDate" runat="server" Text='<%# Eval("OrderStartDate")%>'></asp:Label> 
              <asp:HiddenField ID="hfDate" runat="server" Value='<%# Eval("IsDate")%>'/>
              </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="公共单">
          <ItemTemplate> 
              <asp:Label ID="lblOrderIsPub" runat="server" Text='<%# Eval("IsPub")%>'></asp:Label> 
              <asp:HiddenField ID="hfChannel" runat="server" Value='<%# Eval("Channel")%>'/>
              </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="发送红包日期">
          <ItemTemplate> <asp:Label ID="lblSendDate1" runat="server" Text='<%# Eval("SendDate")%>'></asp:Label> 
              <asp:HiddenField ID="hfFlag" runat="server" Value='<%# Eval("Flag")%>' />
          </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                    <a href='<%# Eval("SerialNo","../../service/tbLevelOrder/default.aspx?SerialNo={0}")%>' target="_blank">
                        订单详情</a>
                     </ItemTemplate>
           </asp:TemplateField>
        </Columns>
      </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button3" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="活动订单查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtSerialNo" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户编码</td>
                    <td class="table_none">
                        <asp:TextBox ID="gtxtAcceptUserID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>

                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发布者ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtUserID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        活动序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtActivityID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button4" runat="server" CssClass="button_bak" Text="查询" OnClick="Button4_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script language="javascript" type="text/javascript">
<!--

    function ld(i) {
        document.getElementById("ctl00_PageBody_framelist").src = "ActivityOrder.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;
        document.getElementById("ctl00_PageBody_framelist1").src = "ActivityOrderDel.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;

    }

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
        for (var i = 0; i < e.length; i++) {
            if (e[i].type == "checkbox") {
                e[i].checked = IsTrue;
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
// -->

    rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
    
    function reload()
    {
        document.getElementById("ctl00_PageBody_framelist").src = "ActivityOrder.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;
    }

    </script>

</asp:Content>
