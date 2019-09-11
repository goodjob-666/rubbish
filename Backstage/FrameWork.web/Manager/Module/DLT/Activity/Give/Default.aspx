<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Give.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="赠送列表" HeadTitleTxt="赠送" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="赠送" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="赠送列表">
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

                    <asp:BoundField HeaderText="赠送ID"  DataField="GiveUID" />

                    <asp:BoundField HeaderText="赠送者昵称"  DataField="GiveNickName" />

                    <asp:BoundField HeaderText="获赠ID" DataField="UID" />

                    <asp:BoundField HeaderText="获赠者昵称" DataField="Nickname" />
                   
                    <asp:BoundField HeaderText="赠送乐币" DataField="Money" />

                    <asp:BoundField HeaderText="赠送时间" DataField="CreateDate" />
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
                        赠送类型</td>
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
                            <asp:ListItem Text="已赠送" Value="1"></asp:ListItem>
                            <asp:ListItem Text="未赠送" Value="0"></asp:ListItem>
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
