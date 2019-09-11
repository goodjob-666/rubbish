<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderMessage.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbLevelOrderHis.OrderMessage" %>

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
    <div style="margin-top:10px;">
        <div style="float:left;">
          交互留言
        </div>
        <div style="margin-right: 5px;float:right;">
          <asp:LinkButton ID="LinkButton5" runat="server" BackColor="White" BorderColor="Red"
                ForeColor="DarkGreen" OnClick="LinkButton5_Click">刷新</asp:LinkButton>
        </div>
      </div>
      <br />
    <asp:GridView ID="GridView3" runat="server" OnRowDataBound="GridView3_RowDataBound" style="word-break:break-all;">
        <Columns>
        <asp:TemplateField HeaderText="序号">
          <ItemTemplate><%# (this.AspNetPager2.CurrentPageIndex - 1) * this.AspNetPager2.PageSize + Container.DataItemIndex + 1%></ItemTemplate>
          <ItemStyle Wrap="True" />
          <HeaderStyle Wrap="False" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="用户ID">
          <ItemTemplate> <%#UIDPost(Eval("UID").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="发表时间" DataField="CreateDate" />
        <asp:TemplateField HeaderText="消息内容">
          <ItemTemplate>
              <asp:HiddenField ID="hdMsgType" runat="server" Value='<%#Eval("MsgType")%>' />
              <asp:Label ID="lblMsg" runat="server" Text='<%#Eval("Msg")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" 
            OnPageChanged="AspNetPager2_PageChanged" PageSize="10"></FrameWorkWebControls:AspNetPager>
    </div>
    </form>
</body>
</html>
