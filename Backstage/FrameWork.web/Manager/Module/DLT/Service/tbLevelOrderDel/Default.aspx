<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DaiLianTong.Web.Module.DaiLianTong.tbLevelOrderDel.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
  <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="已删除订单列表" HeadTitleTxt="已删除订单管理"> </FrameWorkWebControls:HeadMenuWebControls>
  <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="已删除订单列表">
      <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnRowCreated="GridView1_RowCreated">
        <Columns>
        <asp:TemplateField HeaderText="序号">
          <ItemTemplate>
          <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
          </ItemTemplate>
          <ItemStyle Wrap="True" />
          <HeaderStyle Wrap="False" />
        </asp:TemplateField>
        <asp:BoundField HeaderText="订单号" DataField="SerialNo" />
        <asp:BoundField HeaderText="角色名" DataField="Actor" />
        <asp:BoundField HeaderText="发布者" DataField="PostNickName" />
        <asp:BoundField HeaderText="接单者" DataField="AcceptUserID" />
        <asp:BoundField HeaderText="标题" DataField="Title" />
        <asp:BoundField HeaderText="金额" DataField="Price" />
        <asp:BoundField HeaderText="保证金" DataField="Ensure" />
        <asp:BoundField HeaderText="公共单" DataField="IsPub" />
        <asp:TemplateField SortExpression="DelCustomerID" HeaderText="删除客服">
          <ItemTemplate><%#GetOPLoginID(Eval("DelCustomerID").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="删除时间" DataField="DelDate" />
        <asp:TemplateField HeaderText="操作" ShowHeader="False">
          <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("SerialNo") %>' CommandName="OrderDetail"
                                Text="订单详情"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
      <div style="display:none"><asp:Button ID="Button3" Visible="false" CssClass="button_bak" runat="server" Text="还原" OnClientClick="return deleteop();" OnClick="Button3_Click" /> 
        <asp:CheckBox ID="cbSetRightLock" runat="server" />同时打开用户发单权限记录</div>
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
              <asp:ListItem Value="发布者ID">发布者ID</asp:ListItem>
              <asp:ListItem Value="角色名">角色名</asp:ListItem>
              <asp:ListItem Value="删除客服">删除客服</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="SearchText_Input" title="请输入搜索内容~256:" runat="server" CssClass="text_input" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
          <td class="table_body">删除类别</td>
          <td class="table_none"><asp:DropDownList ID="ddlDelType" runat="server">
              <asp:ListItem Value="客服删除">客服删除</asp:ListItem>
              <asp:ListItem Value="用户自己删除">用户自己删除</asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="display:none">
          <td class="table_body">订单状态</td>
          <td class="table_none"><asp:DropDownList ID="E_Status" runat="server">
              <asp:ListItem Text="不限" Value="-1"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        <tr style="display:none;">
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
          <td colspan="4" align="right" style="height: 26px"><asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="订单详情">
      <div style="margin-top:10px;">
        <div style="float:left;">
          <asp:Label ID="lb_Title2" runat="server" CssClass="menubar_readme_text_top"></asp:Label>
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
          <td class="table_none table_body_NoWidth" style="height: 30px">发布者ID</td>
          <td class="table_none table_none_NoWidth" style="height: 30px">
              <asp:Label ID="lblPostID" runat="server" Text="" Font-Bold="true" ForeColor="Blue"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单标题</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="U_Title_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单金额</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Bal_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
          <td class="table_body table_body_NoWidth"></td>
          <td class="table_none table_none_NoWidth"></td>
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
          <td class="table_body table_body_NoWidth"></td>
          <td class="table_none table_none_NoWidth"></td>
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
            <asp:Label ID="U_PubOrderInfo_Txt" runat="server"></asp:Label>
            <asp:Label
                        ID="lblRightLock" runat="server" Text=""></asp:Label></td>
          <td class="table_body table_body_NoWidth">联系方式</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_PubContactway_Txt" runat="server"></asp:Label></td>
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
