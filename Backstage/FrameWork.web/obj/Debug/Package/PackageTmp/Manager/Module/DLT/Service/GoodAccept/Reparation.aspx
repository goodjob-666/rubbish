<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Reparation.aspx.cs" 
Inherits="DLT.Web.Module.DLT.GoodAccept.Reparation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		    <tr>
			    <td class="table_body">
                    优质下家</td>
			    <td class="table_none" >
                    <asp:Label ID="lbGoodAccept" runat="server"></asp:Label>
                    <asp:HiddenField ID="hiddenID" runat="server" />
                                </td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    保证金</td>
			    <td class="table_none" >
                    <asp:Label ID="lbEnsureMoney" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    优质上家</td>
			    <td class="table_none" >
                    <asp:TextBox runat="server" ID="txtGoodPublish" 
                        Width="156px"></asp:TextBox>
                </td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    相关订单</td>
			    <td class="table_none" >
                    <asp:TextBox runat="server" ID="txtODSerialNo" 
                        Width="156px"></asp:TextBox>
                </td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    判赔理由</td>
			    <td class="table_none" >
                    <asp:TextBox runat="server" ID="txtReson" 
                        Width="624px"></asp:TextBox>
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