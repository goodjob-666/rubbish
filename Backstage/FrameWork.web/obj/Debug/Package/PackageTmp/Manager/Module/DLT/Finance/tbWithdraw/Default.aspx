<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbWithdraw.Default"
    Title="无标题页" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="提现汇款列表" HeadTitleTxt="提现汇款管理">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="提现汇款列表">
        <div>
            <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="提现流水号" DataField="SerialNo" ReadOnly="true" />
                    <asp:BoundField HeaderText="用户编号" DataField="UserID" ReadOnly="true" />
                     <asp:TemplateField HeaderText="昵称">
                        <ItemTemplate>
                           <%# FrameWork.Common.Base64Decode(Eval("NickName").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="Bal" HeaderText="金额">
                      <ItemTemplate> <%#SaveTwoPointer(Eval("Bal").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="Fee" HeaderText="手续费">
                      <ItemTemplate> <%#SaveTwoPointer(Eval("Fee").ToString())%> </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="提现日期" DataField="ApplyDate" ReadOnly="true" />
                    <asp:BoundField HeaderText="汇款日期" DataField="RemitDate" ReadOnly="true" />
                    <asp:BoundField HeaderText="外部流水号" DataField="BankSerialNo" ReadOnly="true" />
                    <asp:TemplateField SortExpression="Status" HeaderText="状态">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlStatus" runat="server">
                                 <asp:ListItem Value="10">提现处理中</asp:ListItem>
                                 <asp:ListItem Value="12">提现已撤消</asp:ListItem>
                                 <asp:ListItem Value="13">提现审核中</asp:ListItem>
                                 <asp:ListItem Value="14">撤销退回余额</asp:ListItem>
                             </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%#Status((Eval("Status").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="备注" DataField="Comment" ReadOnly="true" />

                    <asp:CommandField HeaderText="操作" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <label id="lbStatistics" runat="server" style="color:Teal; margin-left:5px;"></label>
            </div>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        提现状态</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlStatus" runat="server">
                            <asp:ListItem Value="0" Selected>无限制</asp:ListItem>
                            
                        </asp:DropDownList>
                    </td>
                </tr>
               
                <tr>
                    <td class="table_body">
                        申请日期范围</td>
                    <td class="table_none">

                        <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                        </td>
                </tr>
                
                    <tr style="display:none">
                    <td class="table_body">
                        汇款日期范围</td>
                    <td class="table_none">

                        <asp:TextBox ID="SRemit_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="ERemit_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                     </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        提现流水号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SerialNo_Input" title="请输入提现流水号~100:" runat="server" CssClass="text_input" ></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        用户编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UID_Input" title="请输入用户编号~100:" runat="server" CssClass="text_input" ></asp:TextBox>
                    
                        </td>
                </tr>

                
                <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="NickName_Input" title="请输入昵称~100:" runat="server" CssClass="text_input" ></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        外部流水号</td>
                    <td class="table_none">
                        <asp:TextBox ID="BankSerialNo_Input" title="请输入外部流水号~100:" runat="server" CssClass="text_input" Width="250"></asp:TextBox>
                        </td>
                </tr>
                
                <tr style="display:none">
                    <td class="table_body">
                        银行帐号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BankAcc_Input" title="请输入银行帐号~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr style="display:none">
                    <td class="table_body">
                        银行地址</td>
                    <td class="table_none">
                        <asp:TextBox ID="BankAddr_Input" title="请输入银行地址~100:" runat="server" CssClass="text_input"></asp:TextBox>
                        </td>
                </tr>
                
                <tr style="display:none">
                    <td class="table_body">
                        优质用户</td>
                    <td class="table_none">
                        <asp:CheckBox ID="cbGood" runat="server" />是
                        </td>
                </tr>
                
                
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="导出" OnClick="Button2_Click" />
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="JavaScript" type="text/javascript">


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
        alert(Messages);
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
    
    function reload()
    {
        document.getElementById("<%=Button1.ClientID %>").click();
    }
</script>
</asp:Content>
