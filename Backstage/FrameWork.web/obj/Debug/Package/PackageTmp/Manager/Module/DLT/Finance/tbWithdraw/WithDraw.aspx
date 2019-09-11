<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="WithDraw.aspx.cs" Inherits="FrameWork.web.WithDraw"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

<script type="text/javascript">
    function copyToClipboard(txt,msg) {
        //IE
        if (window.clipboardData) {
            window.clipboardData.clearData();
            window.clipboardData.setData("Text", txt);
            alert(msg);
        } 
        //Firefox
        else if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            } catch (e) {
                alert("被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将'signed.applets.codebase_principal_support'设置为'true'");
            }
            var clip = Components.classes['@mozilla.org/widget/clipboard;1'].createInstance(Components.interfaces.nsIClipboard);
            if (!clip) {
                return;
            }
            var trans = Components.classes['@mozilla.org/widget/transferable;1'].createInstance(Components.interfaces.nsITransferable);
            if (!trans) {
                return;
            }
            trans.addDataFlavor('text/unicode');
            var str = new Object();
            var len = new Object();
            var str = Components.classes["@mozilla.org/supports-string;1"].createInstance(Components.interfaces.nsISupportsString);
            var copytext = txt;
            str.data = copytext;
            trans.setTransferData("text/unicode", str, copytext.length * 2);
            var clipid = Components.interfaces.nsIClipboard;
            if (!clip) {
                return false;
            }
            clip.setData(trans, null, clipid.kGlobalClipboard);
            alert(msg);
        } 
    }
</script>
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		    <tr>
			    <td class="table_body">
                    提现流水号</td>
			    <td class="table_none" >
                    <asp:Label ID="U_SerialNo_Txt" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    登陆ID</td>
			    <td class="table_none" >
                    <asp:Label ID="U_LoginID_Txt" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    账号类型</td>
			    <td class="table_none" >
                    <asp:Label ID="U_BankID_Txt" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    客户编号</td>
			    <td class="table_none" >
                    <asp:Label ID="U_UID_Txt" runat="server"></asp:Label></td>
		    </tr>
		    <tr>
			    <td class="table_body">
                    手续费</td>
			    <td class="table_none" >
                    <asp:Label ID="U_Fee_Txt" runat="server"></asp:Label></td>
		    </tr>
            <tr>
                <td class="table_body">
                    账号</td>
                <td class="table_none">
                    <asp:TextBox ID="U_BankAcc_Txt" title="请输入账号~50:" runat="server" CssClass="text_input" Enabled="false"></asp:TextBox> <span onclick="copyToClipboard('<%= BankAcc %>','帐号复制成功！');" style="font-weight:bold; cursor:pointer;color:red;">复制</span></td>
            </tr>
            <tr>
                <td class="table_body">
                    户名</td>
                <td class="table_none">
                    <asp:TextBox ID="U_BankUser_Txt" title="请输入户名~50:" runat="server" CssClass="text_input" Enabled="false"></asp:TextBox> <span onclick="copyToClipboard('<%= BankName %>','户名复制成功！');" style="font-weight:bold; cursor:pointer;color:red;">复制</span></td>
            </tr>
            <tr>
                <td class="table_body">
                    提现金额</td>
                <td class="table_none">
                    <asp:Label ID="U_Payout_Txt" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <td class="table_body">
                    实际打款</td>
                <td class="table_none">
                <asp:TextBox ID="tbRealPay" title="请输入实际打款金额~50:" runat="server" CssClass="text_input" Enabled="false"></asp:TextBox>
                     <span onclick="copyToClipboard('<%= RealBal %>','金额复制成功！');" style="font-weight:bold; cursor:pointer;color:red;">复制</span></td>
            </tr>
            <tr>
                <td class="table_body" style="height: 30px">
                    银行流水号</td>
                <td class="table_none" style="height: 30px">
                    <asp:TextBox ID="U_BankSerialNo_Txt" title="请输入银行流水号~50:" runat="server" CssClass="text_input" Width="287px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table_body">
                    备注</td>
                <td class="table_none">
                    <asp:TextBox ID="U_Comment_Txt" title="请输入备注~128:" runat="server" CssClass="text_input" Height="56px" Width="287px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" colspan="2" style="height: 27px">
                    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确认提现" OnClick="Button1_Click" /> &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="Button3" runat="server" Text="解锁" CssClass="button_bak" Visible="false"
                        onclick="Button3_Click"/> &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="BtClose" CssClass="button_bak" runat="server" Text="关闭" 
                        onclick="BtClose_Click" />
                    &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="撤销提现" OnClick="Button2_Click" style="text-align: left" TabIndex="1" /></td>
            </tr>
		</table>
</asp:Content>
