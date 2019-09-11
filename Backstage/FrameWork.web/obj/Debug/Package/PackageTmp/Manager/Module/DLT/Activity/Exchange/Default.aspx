<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Exchange.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
 <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="兑换列表" HeadTitleTxt="兑换" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="兑换" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="兑换列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="流水号"  DataField="SerialNo" />

                    <asp:BoundField HeaderText="用户ID"  DataField="UID" />

                    <asp:BoundField HeaderText="昵称"  DataField="NickName" />

                    <asp:BoundField HeaderText="手机号/QQ"  DataField="MobileQQ" />
                    <asp:BoundField HeaderText="区服/运营商"  DataField="ZoneServer" />
                    <asp:BoundField HeaderText="数量"  DataField="Num" />
                    <asp:BoundField HeaderText="乐币"  DataField="SumBal" />

                    <asp:BoundField HeaderText="兑换类型" DataField="Value" />

                    <asp:BoundField HeaderText="时间" DataField="CreateDate" />

                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>   
                            <%#(Eval("Status", "{0}") == "0") ? "未兑换" : "已兑换" %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="备注" DataField="Comment" />

                     <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>   
                            <a href='javascript:showPopWin("确定已兑换？","Exchange.aspx?SerialNo=<%# Eval("SerialNo") %>",600, 100, AlertMessageBox1,false)'>操作</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <div style="display:none"><asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" /></div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtUID" title="请输入标题~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        兑换类型</td>
                    <td class="table_none">
                     
                       <asp:DropDownList ID="ddlDHType" runat="server"  >
                        <asp:ListItem Value="">不限</asp:ListItem>
                       </asp:DropDownList>
                    
                    </td>
                </tr>
               
                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsOnline_Input" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Text="已兑换" Value="1"></asp:ListItem>
                            <asp:ListItem Text="未兑换" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script language="javascript" type="text/javascript">
<!--

    function SelectAll() {
        var e = document.getElementsByTagName("input");
        var IsTrue;
        if (document.getElementById("CheckboxAll").value == "0") {
            IsTrue = true;
            document.getElementById("CheckboxAll").value = "1"
        }
        else {
            IsTrue = false;
            document.getElementById("CheckboxAll").value = "0"
        }
        for (var i = 0; i < e.length; i++) {
            if (e[i].type == "checkbox") {
                e[i].checked = IsTrue;
            }
        }
    }
    function deleteop() {
        var checkok = false;
        var e = document.getElementsByTagName("input");
        for (var i = 0; i < e.length; i++) {
            if (e[i].type == "checkbox") {
                if (e[i].checked == true) {
                    checkok = true;
                    break;
                }
            }
        }
        if (checkok)
            return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
        else {

            alert("请选择要删除的记录!");
            return false;
        }
    }
    function AlertMessageBox1(Messages) {
        DispClose = false;
        //alert(Messages);
        setTimeout("reload1()", 100)
    }
    function reload1() {
        document.getElementById("<%=Button1.ClientID %>").click();
    }
// -->
    </script>

</asp:Content>
