<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivityOrder.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbActivity.ActivityOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title></title>
    <link rel="stylesheet" href="../../../../css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../../inc/FineMessBox/css/subModal.css" />
    <link rel="stylesheet" type="text/css" href="../../../../css/table/default/Css.css" />
    <style>
    
.table_title{
    background-color: #7898a8;
    color: #ffffff;
    font: bold 14px Tahoma,Verdana;
    height: 30px;
    padding-left: 5px;
    padding-right: 5px;
}
#AspNetPager2{
    font-size:14px;
}
#AspNetPager2 span{
    font-size:14px;
    padding-right:5px;
}
#AspNetPager2 a{
    font-size:14px;
    padding-right:5px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        游戏：<asp:DropDownList ID="ddlGame" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlGame_SelectedIndexChanged">
        <asp:ListItem Value="-1">无限制</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton ID="LinkButton1" runat="server" style="float:right;" 
            onclick="LinkButton1_Click">刷新</asp:LinkButton></div>
    <div>
      <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="活动ID" DataField="AID" />
                <asp:TemplateField HeaderText="订单号">
          <ItemTemplate><asp:Label ID="lblSerialNo" runat="server" Text='<%# Eval("SerialNo")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="发布者" DataField="PostNickName" />
        <asp:BoundField HeaderText="角色名" DataField="Actor" />
        <asp:TemplateField HeaderText="接单者">
          <ItemTemplate>
         <%#AcceptUserID(Eval("AcceptUserID").ToString())%>
         <asp:HiddenField ID="hfActivityID"  runat="server"  Value='<%# Eval("ActivityID")%>'/>
         <asp:HiddenField ID="hfAcceptUserID" runat="server" Value='<%# Eval("AcceptUserID")%>'/>
         <asp:HiddenField ID="hfUserID" runat="server" Value='<%# Eval("UserID")%>'/>
              <asp:Label ID="lblOrderSum" runat="server" Text=""></asp:Label>
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
        <asp:TemplateField HeaderText="帐号关联">
          <ItemTemplate><%#AccountRela(Eval("SerialNo").ToString())%> </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                        <a href='<%# Eval("SerialNo","../../service/tbLevelOrder/default.aspx?SerialNo={0}")%>' target="_blank">订单详情</a>
                    </ItemTemplate>
                    </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager1" Visible="false" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
      <asp:Button ID="Button3" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button3_Click" /> 
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
                return confirm('确认要批量删除选中记录吗？');
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
    </div>
    </form>
</body>
</html>
