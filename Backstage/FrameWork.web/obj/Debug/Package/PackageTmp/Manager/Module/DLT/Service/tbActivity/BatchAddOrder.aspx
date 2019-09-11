<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BatchAddOrder.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbActivity.BatchAddOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div style="width:700px; text-align:center; color:red; font-weight:bold;">注意：订单号每行一个，不要掺有其它无关字符，添加后先检测，再添加！<asp:Button ID="BtClose" CssClass="button_bak" style="float:right" runat="server" Text="关闭" 
                        onclick="BtClose_Click" /></div>
    <table width="700" border="1">
     <tr>
    <td style="width:100px;"></td>
    <td style="width:300px;">
        待添加订单列表</td>
        <td style="width:300px;">不符合条件订单</td>
  </tr>
  <tr>
    <td style="width:100px;">订单列表</td>
    <td style="width:300px;">
        <asp:TextBox ID="txtOrderList" runat="server" TextMode="MultiLine" Width="300" Height="650"></asp:TextBox></td>
        <td style="width:300px;">
            <asp:Label ID="lblNoValidate" runat="server" Text=""></asp:Label><asp:HiddenField
                ID="hfFlag" runat="server" />
            </td>
  </tr>
   <tr>
    <td style="width:100px;"></td>
    <td style="width:300px;" align="right">
        
        </td>
        <td style="width:300px;" align="right">
        <asp:Button ID="btnCheck" runat="server" Text="检测订单" onclick="btnCheck_Click" /> &nbsp;&nbsp;
            <asp:Button ID="btnAdd" runat="server" Text="批量添加" Enabled="false" 
                onclick="btnAdd_Click" /></td>
  </tr>
 
</table>
    </div>
    </form>
</body>
</html>
