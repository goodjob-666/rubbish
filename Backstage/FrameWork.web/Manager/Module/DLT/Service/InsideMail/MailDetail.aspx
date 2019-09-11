<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="MailDetail.aspx.cs" 
Inherits="DLT.Web.Module.DLT.InsideMail.MailDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		    <tr>
			    <td class="table_body">
                    主题</td>
			    <td class="table_none" >
                    <asp:Label ID="lbTitle" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body" style="height: 343px">
                        正文
                </td>
                <td class="table_none" style="height: 343px">
                    <asp:TextBox runat="server" ID="txtBody" Height="331px" TextMode="MultiLine" 
                        Width="518px"></asp:TextBox>
                </td>
		    </tr>
		    <tr>
			    <td class="table_body" colspan="2" align="right">
                        <asp:Button ID="BtClose" runat="server" CssClass="button_bak" 
                            onclick="BtClose_Click" Text="关闭" />
                </td>
		    </tr>
	    </table>
</asp:Content>