<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"  AutoEventWireup="true" CodeBehind="OrderProgress.aspx.cs" Inherits="FrameWork.web.Manager.Module.DaiLianTong.BizManager.Order.OrderProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" 
        onitemcommand="Repeater1_ItemCommand" onitemdatabound="Repeater1_ItemDataBound">
    <ItemTemplate>
        <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("Source") %>' />
    <%#Source(Eval("Source").ToString())%>
    <span>第 <%#Container.ItemIndex + 1%> 张： <%#Eval("Comment") %> <%#Eval("CreateDate") %> [<%#Eval("Fromer")%>] <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('确定删除客服上传的图片吗？');"/></span>
    </div>
    <br>
    <div style="text-align:center">
    <a href='<%#Eval("Img") %>'>
    <img width="800px" height="600px" src='<%#Eval("Img") %>'>
    </a>
    &nbsp;<br>
    <hr>
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
