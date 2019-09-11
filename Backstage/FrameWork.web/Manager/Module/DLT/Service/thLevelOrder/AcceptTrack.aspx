<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcceptTrack.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbLevelOrderHis.AcceptTrack" %>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="GridView5" runat="server">
              <Columns>
              <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                        <%# (this.AspNetPager4.CurrentPageIndex - 1) * this.AspNetPager4.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                <ItemStyle Wrap="True" />
                <HeaderStyle Wrap="False" />
              </asp:TemplateField>
              <asp:BoundField HeaderText="用户ID" DataField="UID" />
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
            <FrameWorkWebControls:AspNetPager ID="AspNetPager4" runat="server" OnPageChanged="AspNetPager4_PageChanged"></FrameWorkWebControls:AspNetPager>
    </div>
    </form>
</body>
</html>
