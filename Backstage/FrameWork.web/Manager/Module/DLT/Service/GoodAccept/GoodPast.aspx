<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="GoodPast.aspx.cs" 
Inherits="DLT.Web.Module.DLT.GoodAccept.GoodPast" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
	    <tr>
		    <td class="table_body">
                理由
            </td>
		    <td class="table_none" >
                <asp:TextBox runat="server" ID="txtReson" 
                    Width="450px"></asp:TextBox>
                <asp:HiddenField ID="hiddenID" runat="server" />
                <asp:HiddenField ID="HiddenFlag" runat="server" />
            </td>
	    </tr>
	    <tr>
		    <td class="table_body" colspan="2" align="right">
                <asp:Button ID="BtClose0" runat="server" CssClass="button_bak" Text="确定" 
                    onclick="BtClose0_Click" />
                <asp:Button ID="BtClose" runat="server" CssClass="button_bak" Text="关闭" 
                    onclick="BtClose_Click" />
            </td>
	    </tr>
    </table>
</asp:Content>
