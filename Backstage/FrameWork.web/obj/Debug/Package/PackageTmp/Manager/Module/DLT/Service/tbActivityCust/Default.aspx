<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbActivityCust.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="平台活动列表" HeadTitleTxt="平台活动查询">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="平台活动" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="活动订单列表">
            <asp:GridView ID="GridView2" runat="server" OnRowDataBound="GridView2_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager2.CurrentPageIndex - 1) * this.AspNetPager2.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
        <asp:BoundField HeaderText="订单号" DataField="ID" Visible="false" />
        <asp:BoundField HeaderText="活动名称" DataField="Title" />
        <asp:BoundField HeaderText="订单号" DataField="SerialNo" />
        <asp:BoundField HeaderText="发布者" DataField="PostNickName" />
        <asp:BoundField HeaderText="角色名" DataField="Actor" />
        <asp:TemplateField HeaderText="接单者">
          <ItemTemplate>
         <%#AcceptUserID(Eval("AcceptUserID").ToString())%>
         <asp:HiddenField ID="hfActivityID"  runat="server"  Value='<%# Eval("ActivityID")%>'/>
         <asp:HiddenField ID="hfAcceptUserID" runat="server" Value='<%# Eval("AcceptUserID")%>'/>
              <asp:Label ID="lblOrderSum" runat="server" Text=""></asp:Label>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="标题" DataField="OrderTitle" />
        <asp:TemplateField HeaderText="金额">
          <ItemTemplate> <%#SaveTwoPointer(Eval("Price").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="保证金" DataField="Ensure" />
        <asp:TemplateField HeaderText="订单状态">
          <ItemTemplate> <%#Status(Eval("Status").ToString())%> </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="撤销状态">
          <ItemTemplate> <%#CancelStatus(Eval("CancelStatus").ToString())%> </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="接单时间">
          <ItemTemplate>
              <asp:Label ID="lblOrderStartDate" runat="server" Text='<%# Eval("OrderStartDate")%>'></asp:Label> 
              <asp:HiddenField ID="hfDate" runat="server" Value='<%# Eval("IsDate")%>'/>
              </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="公共单">
          <ItemTemplate> 
              <asp:Label ID="lblOrderIsPub" runat="server" Text='<%# Eval("IsPub")%>'></asp:Label> 
              <asp:HiddenField ID="hfChannel" runat="server" Value='<%# Eval("Channel")%>'/>
              </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="发送红包日期">
          <ItemTemplate> <asp:Label ID="lblSendDate1" runat="server" Text='<%# Eval("SendDate")%>'></asp:Label> 
              <asp:HiddenField ID="hfFlag" runat="server" Value='<%# Eval("Flag")%>' />
          </ItemTemplate>
        </asp:TemplateField>
           <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                    <a href='<%# Eval("SerialNo","../../service/tbLevelOrder/default.aspx?SerialNo={0}")%>' target="_blank">
                        订单详情</a>
                     </ItemTemplate>
           </asp:TemplateField>
        </Columns>
      </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button3" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="活动订单查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtSerialNo" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户编码</td>
                    <td class="table_none">
                        <asp:TextBox ID="gtxtAcceptUserID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>

                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发布者ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtUserID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        活动序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="gtxtActivityID" title="请输入Title~256:" runat="server" 
                            CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button4" runat="server" CssClass="button_bak" Text="查询" OnClick="Button4_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script language="javascript" type="text/javascript">
<!--

    function ld(i) {
        document.getElementById("ctl00_PageBody_framelist").src = "ActivityOrder.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;
        document.getElementById("ctl00_PageBody_framelist1").src = "ActivityOrderDel.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;

    }

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

    rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
    
    function reload()
    {
        document.getElementById("ctl00_PageBody_framelist").src = "ActivityOrder.aspx?ActivityID=" + document.getElementById("ctl00_PageBody_hfID").value;
    }

    </script>

</asp:Content>
