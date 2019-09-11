<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tlLogin.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="登录日志列表" HeadTitleTxt="登录日志">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="False" ButtonName="登录日志" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="登录日志列表">
            <div runat="server" id="divMacInfo" visible="false">
                当前查询的MAC地址为：<asp:Label ID="lblMAC" runat="server" Text=""></asp:Label>
                ，与此MAC相关的用户数量为：【<asp:Label ID="lblMACCOUNT" runat="server" Text=""></asp:Label>】。
                <a runat="server" style="color:Red;font-weight:bold;" id="AMacToUser" target="_blank">点击查看与此MAC相关的用户</a>
            </div>
            <div runat="server" id="divIPInfo" visible="false">
                当前查询的IP地址为：<asp:Label ID="lblIP" runat="server" Text=""></asp:Label>
                ，与此IP相关的用户数量为：【<asp:Label ID="lblIPCOUNT" runat="server" Text=""></asp:Label>】。
                <a runat="server" style="color:Red;font-weight:bold;" id="AIPToUser" target="_blank">点击查看与此IP相关的用户</a>
            </div>
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <!--<a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>-->
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <%#GetUID((Eval("UserID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("UserID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="子帐号ID" DataField="SubUserID" />--%>
                    <asp:TemplateField HeaderText="登录类别">
                        <ItemTemplate>
                            <%#LoginType((Eval("LoginType").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="国家" DataField="PCName" />
                    <asp:BoundField HeaderText="省份" DataField="HD" />
                    <asp:BoundField HeaderText="市区" DataField="Mac" />
                    <asp:TemplateField HeaderText="IP地址">
                        <ItemTemplate>
                        <a href='http://ip138.com/ips138.asp?ip=<%#Eval("IP") %>&action=2' target="_blank"><%#Eval("IP")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="操作系统" DataField="OS" />
                    <asp:BoundField HeaderText="登录时间" DataField="LoginDate" />
                    <%--<asp:BoundField HeaderText="登出时间" DataField="LogoutDate" />--%>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#Status((Eval("Status").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="备注" DataField="Comment" />
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
                     
                        <asp:TextBox ID="UserID_Input" title="请输入用户ID~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        登录时间</td>
                    <td class="table_none">
                        
                        <asp:TextBox ID="LoginDate_Input" title="请输入登录开始时间~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
            ~
            <asp:TextBox ID="LoginDate_Input_E" title="请输入登录结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none">
                    <td class="table_body">
                        子帐号ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SubUserID_Input" title="请输入子帐号ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        登录类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlLoginType" runat="server">
                         <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr style=" display:none;">
                    <td class="table_body">
                        机器名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PCName_Input" title="请输入机器名~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style=" display:none;">
                    <td class="table_body">
                        硬盘</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="HD_Input" title="请输入硬盘~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style=" display:none;">
                    <td class="table_body">
                        网卡</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Mac_Input" title="请输入网卡~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        IP地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IP_Input" title="请输入IP地址~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        操作系统</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OS_Input" title="请输入操作系统~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>

                <!--<tr>
                    <td class="table_body">
                        登出时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="LogoutDate_Input" onfocus="javascript:HS_setDate(this);" title="请输入登出时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>-->
                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlStatus" runat="server">
                         <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
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
// -->
    </script>

</asp:Content>
