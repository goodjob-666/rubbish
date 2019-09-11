<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Act.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="活动列表" HeadTitleTxt="活动" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="活动" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="活动列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>

                     <asp:TemplateField  HeaderText="游戏"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List&ModuleID=<%#Eval("ModuleID")%>"><%# Eval("Game")%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Upload/"+Eval("ImageUrl") %>' Width="100px" Height="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="标题"  DataField="name" />
                  
                   <%-- <asp:BoundField HeaderText="游戏" SortExpression="Game" DataField="Game" />--%>
                    <asp:BoundField HeaderText="描述" DataField="Content" />

                     <asp:BoundField HeaderText="奖励（倍数）" DataField="Reward" />

                    <asp:BoundField HeaderText="时限（小时）" DataField="TimeLimit" />

                    <asp:BoundField HeaderText="排序" DataField="Sort" />
                    <asp:TemplateField  HeaderText="状态">
                        <ItemTemplate>
                            <%#GameIsOnline(Convert.ToBoolean(Eval("Enable")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <div style=" display:none;"><asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" /></div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <%--<tr>
                    <td class="table_body">
                        厂商ID</td>
                    <td class="table_none">
                     
                     <asp:DropDownList ID="ddlCompany" runat="server">
                     <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>--%>
                <tr>
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                     
                       <asp:DropDownList ID="ddlGame" runat="server"  >
                        <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                    
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        模式</td>
                    <td class="table_none">
                     
                       <asp:DropDownList ID="ddlModule" runat="server"  >
                        <asp:ListItem Value="">不限</asp:ListItem>
                        </asp:DropDownList>
                    
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Comment_Input" title="请输入标题~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        运营状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="IsOnline_Input" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Text="可用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
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
// -->
    </script>

</asp:Content>
