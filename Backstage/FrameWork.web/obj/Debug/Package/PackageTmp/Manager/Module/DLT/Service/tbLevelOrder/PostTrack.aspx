<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostTrack.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbLevelOrder.PostTrack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
              <asp:GridView ID="GridView4" runat="server" OnRowCreated="GridView4_RowCreated">
              <Columns>
              <asp:TemplateField HeaderText="序号">
                <ItemTemplate>                       
                        <%# (this.AspNetPager3.CurrentPageIndex - 1) * this.AspNetPager3.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                <ItemStyle Wrap="True" />
                <HeaderStyle Wrap="False" />
              </asp:TemplateField>
              <asp:BoundField HeaderText="流水号" DataField="SerialNo" Visible="false" />
              <asp:BoundField HeaderText="关联订单" DataField="ODSerialNo" />
              <asp:BoundField HeaderText="跟踪记录" DataField="TrackInfo" />
              <asp:BoundField HeaderText="计分" DataField="Score" />
              <asp:BoundField HeaderText="记录时间" DataField="CreateDate" />
              <asp:TemplateField HeaderText="操作客服">
                <ItemTemplate>
                <%#GetOPLoginID(Eval("CustomerID").ToString())%>
                </ItemTemplate>
              </asp:TemplateField>
              </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager3" runat="server" OnPageChanged="AspNetPager3_PageChanged"></FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
    </div>
    
    <script language="javascript" type="text/javascript">
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
    </script>
    
    </form>
</body>
</html>
