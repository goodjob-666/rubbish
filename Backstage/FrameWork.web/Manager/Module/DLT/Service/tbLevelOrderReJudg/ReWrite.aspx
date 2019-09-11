<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="ReWrite.aspx.cs" Inherits="FrameWork.web.Manager.Module.DLT.Service.tbLevelOrderReJudg.ReWrite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		    <tr>
			    <td class="table_body">
                    仲裁ID</td>
			    <td class="table_none" >
                    <asp:Label ID="lblCustomerID" runat="server" Text=""></asp:Label>
                    </td></tr><tr>
			    <td class="table_body">
                    接单者愿意赔偿保证金</td>
			    <td class="table_none" >
                    <asp:TextBox ID="tbPayout" runat="server" Text="0" Width="32"></asp:TextBox>
                    元</td></tr><tr>
			    <td class="table_body">
                    发单者需要支付代练费</td><td class="table_none" >
                        <asp:TextBox ID="tbInCome" runat="server" Text="0" Width="32"></asp:TextBox>
                        元</td></tr><tr>
                <td class="table_body">
                    判决理由</td><td class="table_none">
                    <asp:TextBox ID="txtJudgReason" title="请输入判决理由~1024:" runat="server" TextMode="MultiLine" CssClass="text_input" Height="60px" Width="400px"></asp:TextBox></td></tr><tr>
                <td align="right" colspan="2" style="height: 27px">
                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确认修改" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtClose" CssClass="button_bak" runat="server" Text="关闭" 
                        onclick="BtClose_Click" />
                    </td>
            </tr>
		</table>
</asp:Content>
