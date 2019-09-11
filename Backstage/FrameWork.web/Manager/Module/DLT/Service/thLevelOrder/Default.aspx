<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DaiLianTong.Web.Module.DaiLianTong.OrderHis.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单列表" HeadTitleTxt="订单管理"> </FrameWorkWebControls:HeadMenuWebControls>
  <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单列表">
      <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
        <asp:BoundField HeaderText="订单号" DataField="SerialNo" />
        <asp:BoundField HeaderText="发布者" DataField="PostNickName" />
        <asp:BoundField HeaderText="角色名" DataField="Actor" />
        <asp:TemplateField HeaderText="接单者">
          <ItemTemplate>
         <%#AcceptUserID(Eval("AcceptUserID").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="标题" DataField="Title" />
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
        <asp:BoundField HeaderText="接单时间" DataField="StartDate" />
        <asp:BoundField HeaderText="公共单" DataField="IsPub" />
        <asp:TemplateField HeaderText="首查">
          <ItemTemplate><%#GetOPLoginID(Eval("FirstCustomerID").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="客服">
          <ItemTemplate><%#GetOPLoginID(Eval("CustomerID").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ShowHeader="False">
          <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("SerialNo") %>' CommandName="OrderDetail"
                                Text="订单详情"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
      <script type="text/javascript">
          document.getElementById("CheckboxAll").style.display = "none";
      </script>
      <div style="margin-bottom:5px;">
          <asp:Label ID="lblJRCount" runat="server" Text=""></asp:Label></div>
          <div style="display:none">
      <asp:Button ID="Button3" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button3_Click" /> 
        <asp:CheckBox ID="cbSetRightLock" runat="server" />同时封禁用户发单权限记录 从<asp:TextBox ID="txtLockStart" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>至<asp:TextBox ID="txtLockEnd" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox></div>
        <br />
        <br />
        <br />
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
      <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr>
          <td class="table_body">游戏</td>
          <td class="table_none">
          <asp:DropDownList ID="ddlGame" runat="server">
              <asp:ListItem Text="英雄联盟" Value="100" Selected></asp:ListItem>
              <asp:ListItem Text="其他" Value="999"></asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
        <tr>
          <td class="table_body">日期范围</td>
          <td class="table_none"><asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
            ~
            <asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="table_body">关键字</td>
          <td class="table_none"><asp:DropDownList ID="ddlKeyword" runat="server">
              <asp:ListItem Value="订单号">订单号</asp:ListItem>
              <asp:ListItem Value="订单标题">订单标题</asp:ListItem>
              <asp:ListItem Value="用户编码">用户编码</asp:ListItem>
              <asp:ListItem Value="发布者ID">发布者ID</asp:ListItem>
              <asp:ListItem Value="角色名">角色名</asp:ListItem>
              <asp:ListItem Value="首查">首查</asp:ListItem>
              <asp:ListItem Value="客服">客服</asp:ListItem>
			  <asp:ListItem Value="订单金额等于">订单金额等于</asp:ListItem>
              <asp:ListItem Value="订单金额大于等于">订单金额大于等于</asp:ListItem>
              <asp:ListItem Value="QQ号">QQ号</asp:ListItem>
              <asp:ListItem Value="发单数小于">发单数小于</asp:ListItem>
              <asp:ListItem Value="总保证金大于">总保证金大于</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="SearchText_Input" title="请输入搜索内容~256:" runat="server" CssClass="text_input" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="table_body">订单状态</td>
          <td class="table_none"><asp:DropDownList ID="E_Status" runat="server">
              <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr>
          <td class="table_body">撤销状态</td>
          <td class="table_none"><asp:DropDownList ID="ddlCancelStatus" runat="server">
              <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="display:none">
          <td class="table_body">历史订单</td>
          <td class="table_none"><asp:CheckBox ID="cbHisOrder" runat="server" Text="是" /></td>
        </tr>
        <tr>
          <td colspan="2" align="right" style="height: 26px"><asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="订单详情">
      <div style="margin-top:10px;">
        <div style="float:left;">
          <asp:Label ID="lb_Title2" runat="server" CssClass="menubar_readme_text_top"></asp:Label>
        </div>
        <div style="margin-right: 5px;float:right;display:none;">
          <asp:LinkButton ID="LinkButton6" runat="server" BackColor="White" BorderColor="Red"
                ForeColor="DarkGreen" OnClick="LinkButton6_Click" Height="13px">刷新</asp:LinkButton>
        </div>
      </div>
      <br />
      <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr>
          <td class="table_body table_body_NoWidth" style="height: 30px">订单号</td>
          <td class="table_none table_none_NoWidth" style="height: 30px"><asp:Label ID="U_SerialNo_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth" style="height: 30px">发布时间</td>
          <td class="table_none table_none_NoWidth" style="height: 30px"><asp:Label ID="U_CreateDate_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">游戏区服</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_GameServer_Txt" runat="server"></asp:Label></td>
          <td class="table_none table_body_NoWidth" style="height: 30px">首查人：
            <asp:Label ID="U_FirstOPName_Txt" runat="server" ForeColor="Red"></asp:Label></td>
          <td class="table_none table_none_NoWidth" style="height: 30px">首查时间：
            <asp:Label ID="U_TrackTime_Txt" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单标题</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="U_Title_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单金额</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Bal_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
          <td class="table_body table_body_NoWidth">转单下家</td>
          <td class="table_none table_none_NoWidth"><asp:Label ForeColor="DarkGreen" ID="lblZD" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">安全保证金</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Ensure1_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">效率保证金</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Ensure2_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">代练时限</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_TimeLimit_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
          <td class="table_body table_body_NoWidth">剩余时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_LeaveTime_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">接单时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_BeginTime_Txt" runat="server" ForeColor="Blue"></asp:Label></td>
          <td class="table_body table_body_NoWidth">完单时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_EndTime_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">角色名</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_ActorName_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <asp:Label ID="U_ActorCount" runat="server" ForeColor="Blue"></asp:Label></td>
          <td class="table_body table_body_NoWidth"></td>
          <td class="table_none table_none_NoWidth"></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">当前游戏信息</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="U_CurrInfo_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth" style="height: 30px">代练要求</td>
          <td class="table_none table_none_NoWidth" colspan="3" style="height: 30px"><asp:Label ID="U_Require_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">发布联系人</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_PublishUser_Txt" runat="server"></asp:Label>
            <asp:Label ID="U_PubOrderInfo_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">联系方式</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_PubContactway_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">接单联系人</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_AcceptUser_Txt" runat="server"></asp:Label>
            <asp:Label ID="U_AccOrderInfo_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">联系方式</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_AccContactway_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">后台备注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:TextBox ID="tbComment" runat="server" Columns="10" CssClass="text_input" Width="418px" Height="118px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" CssClass="button_bak" Text="修改备注" OnClick="Button5_Click" />
            <asp:HiddenField
                                ID="hfCancelStatus" runat="server" />
            <asp:TextBox ID="tbTransTag" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbCreateOpID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbAcceptOpID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbUserID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbAcceptUserID" runat="server" Visible="False">0</asp:TextBox></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">标记关注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:CheckBox Enabled="false" ID="cbLook" runat="server" AutoPostBack="True" OnCheckedChanged="cbLook_CheckedChanged"
                            Text="已关注(勾选即生效)" /></td>
        </tr>
      </table>
      <asp:Label ID="lb_Title3" runat="server" Visible="False" CssClass="menubar_readme_text_top"></asp:Label>
      <br />
      <div style="margin-bottom:8px; padding-bottom:10px;">
        <asp:Panel ID="Panel1" runat="server" Visible="false">
          <div>
            <div style="float:left; width:716px;">
              <div id="div1" runat="server">
                <asp:Label ID="lbMes1" runat="server"></asp:Label>
                <asp:TextBox ID="tbPayout" runat="server" Width="32px"></asp:TextBox>
                <asp:Label ID="lbMes2" runat="server"></asp:Label>
              </div>
              <div id="div2" runat="server">
                <asp:Label ID="lbMes3" runat="server"></asp:Label>
                <asp:TextBox ID="tbInCome" runat="server" Width="32px"></asp:TextBox>
                <asp:Label ID="lbMes4" runat="server"></asp:Label>
              </div>
            </div>
            <div style="float:right; display:none; margin-right:90px;">
              <asp:Button ID="Button2" runat="server" Text="强制完单" Width="75" Height="35" OnClick="Button2_Click" />
            </div>
          </div>
        </asp:Panel>
      </div>
      <br />
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
      <table width="100%" border="0" cellspacing="1" cellpadding="4" align="center">
        <tr>
          <td class="table_body" style="height: 30px">留言内容</td>
          <td class="table_none" style="height: 30px"><asp:TextBox ID="tbMessage" Columns="10" runat="server" CssClass="text_input" Height="79px" TextMode="MultiLine" Width="331px"></asp:TextBox>
            <span><asp:Button ID="Button4" runat="server" CssClass="button_bak" Text="添加" OnClick="Button4_Click" /></span>
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" BackColor="White" BorderColor="Red" style="font-size:18px;color:Red; margin-left:300px;" ForeColor="DarkGreen">显示截图</asp:LinkButton></td>
        </tr>
      </table>
      <br />
      <br />
      <asp:Label ID="lb_Title6" runat="server" CssClass="menubar_readme_text_top">用户跟踪</asp:Label>
      <br />
      <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr style="display:none;">
          <td style="width: 50%">发单者
            <asp:LinkButton ID="LinkButton3" runat="server" BackColor="White" BorderColor="DarkGreen" ForeColor="DarkGreen" OnClick="LinkButton3_Click">刷新</asp:LinkButton></td>
          <td>接单者
            <asp:LinkButton ID="LinkButton4" runat="server" BackColor="White" BorderColor="DarkGreen" ForeColor="DarkGreen" OnClick="LinkButton4_Click">刷新</asp:LinkButton></td>
        </tr>
        <tr>
          <td style="width: 50%">
          
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
          
</td>
          <td>
          
          <iframe id="framelist2" name="framelist2" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe2() {
              var iframe = document.getElementById("ctl00_PageBody_framelist2");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe2()", 200);
</script>
 </td>
        </tr>
        <tr>
          <td style="width: 50%"><table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
              <tr>
                <td class="table_body" style="height: 30px">用户</td>
                <td class="table_none" style="height: 30px"><asp:Label ID="lbUserID" runat="server"></asp:Label>
                  <asp:Label ID="lbUserDesc" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">计分</td>
                <td class="table_none" style="height: 30px"><asp:DropDownList ID="ddlScore" runat="server">
                    <asp:ListItem>-1</asp:ListItem>
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                  </asp:DropDownList>
                  分</td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">跟踪记录</td>
                <td class="table_none" style="height: 30px"><asp:TextBox ID="tbTrackInfo" runat="server" Columns="10" CssClass="text_input" Height="79px"
                            TextMode="MultiLine" Width="331px"></asp:TextBox>
                  <asp:Button ID="Button6" runat="server" CssClass="button_bak" Text="添加" OnClick="Button6_Click" /></td>
              </tr>
            </table></td>
          <td><table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
              <tr>
                <td class="table_body" style="height: 30px">用户</td>
                <td class="table_none" style="height: 30px"><asp:Label ID="lbUserID1" runat="server"></asp:Label>
                  <asp:Label ID="lbUserDesc1" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">计分</td>
                <td class="table_none" style="height: 30px"><asp:DropDownList ID="ddlScore1" runat="server">
                    <asp:ListItem>-1</asp:ListItem>
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                  </asp:DropDownList>
                  分</td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">跟踪记录</td>
                <td class="table_none" style="height: 30px"><asp:TextBox ID="tbTrackInfo1" runat="server" Columns="10" CssClass="text_input" Height="79px"
                            TextMode="MultiLine" Width="331px"></asp:TextBox>
                  <asp:Button ID="Button7" runat="server" CssClass="button_bak" Text="添加" OnClick="Button7_Click" /></td>
              </tr>
            </table></td>
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
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    if (e[i].id == "ctl00_PageBody_cbLook" || e[i].id == "ctl00_PageBody_cbHisOrder") {
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

        rnd.today = new Date();

        rnd.seed = rnd.today.getTime();

        function rnd() {
            rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
            return rnd.seed / (233280.0);

        };

        function rand(number) {
            return Math.ceil(rnd() * number);

        };
        function AlertMessageBox(Messages) {
            DispClose = false;
            alert(Messages);
            setTimeout("reload()", 100)
            //window.location.reload();
            //window.location.href = location.href+"?"+rand(1000000);

        }

        function reload() {
            window.location.href = location.href + "?" + rand(1000000);
        }
</script> 
</asp:Content>
