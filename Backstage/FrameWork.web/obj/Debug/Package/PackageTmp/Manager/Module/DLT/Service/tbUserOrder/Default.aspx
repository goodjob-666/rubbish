<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DaiLianTong.Web.Module.DaiLianTong.tbUserOrder.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
  <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单列表" HeadTitleTxt="订单管理"> </FrameWorkWebControls:HeadMenuWebControls>
  <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单列表">
    <div>客服登录ID：<asp:TextBox ID="txtServiceLoginID" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;日期范围：<asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox> 至
            <asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></div>
      <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
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
        <asp:TemplateField SortExpression="AcceptUserID" HeaderText="接单者">
          <ItemTemplate>
          <%#AcceptUserID(Eval("AcceptUserID").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="标题" DataField="Title" />
        <asp:BoundField HeaderText="金额" DataField="Price" />
        <asp:BoundField HeaderText="保证金" DataField="Ensure" />
        <asp:TemplateField HeaderText="订单状态">
          <ItemTemplate> <%#Status(Eval("Status").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="撤销状态">
          <ItemTemplate> <%#CancelStatus(Eval("CancelStatus").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="接单时间" DataField="StartDate" />
        <asp:BoundField HeaderText="剩余时间(小时)" DataField="LeaveTime" />
        <asp:BoundField HeaderText="公共单" DataField="IsPub" />
        <asp:TemplateField HeaderText="首查">
          <ItemTemplate>
           <%#GetOPLoginID(Eval("FirstCustomerID").ToString())%> 
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="标记客服">
          <ItemTemplate>
           <%#GetOPLoginID(Eval("CustomerID").ToString())%> 
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="完单客服" DataField="E_U_LoginName" />
        </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
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
