<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu3.aspx.cs" Inherits="FrameWork.web.Manager.menu3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
<link type="text/css" rel="stylesheet" href="js/tree/resources/css/lTREE.default.css" charset="utf-8"/>
<script type="text/javascript" src="js/tree/js/lTREE.js" charset="utf-8"></script>
</head>
<body bgcolor="#9aadcd"  style="margin-left:8px;">
<br/>
<div class="lTREEMenu lTREENormal" id="lTREEMenuDEMO">
<span id="TreeHeader">管理菜单</span>
<asp:Literal ID="Treehtml" runat="server"></asp:Literal>
</div>
</body>
<script  type="text/javascript">
var lTree = new lTREE();
lTree.build("lTREEMenuDEMO");
lTree.changAll(0);
</script>
</html>
