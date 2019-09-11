<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="SendInSideMail.aspx.cs" 
Inherits="DLT.Web.Module.DLT.pubSelect.SendInSideMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
	    <tr>
		    <td class="table_body">
                站内信
            </td>
		    <td class="table_none" >
                <asp:TextBox runat="server" ID="tbMailBody" 
                    Width="450px" Height="153px" TextMode="MultiLine"></asp:TextBox>
                <asp:HiddenField ID="hiddenUID" runat="server" />
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