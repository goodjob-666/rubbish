<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Orders.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
   
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>



    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls2" runat="server"
         HeadOPTxt="订单列表" HeadTitleTxt="订单" HeadTitleIcon="default.gif">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>


    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单列表">
           
           <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_RowDataBound" onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                             <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="订单号">
                        <ItemTemplate>
                            <%--<asp:LinkButton ID="lblSeriaNo" PostBackUrl='<%#"Manager.aspx?CMD=List&IDX="+Eval("SeriaNo") %>' runat="server"><%#Eval("SeriaNo")%></asp:LinkButton>--%>
                            
                             <asp:Label ID="lblSeriaNo" runat="server" Text='<%# Bind("SeriaNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="发起人编号" DataField="ID" ReadOnly="true"  />
                   
                    <asp:TemplateField HeaderText="发起人">
                        <ItemTemplate>
                           <%# FrameWork.Common.Base64Decode(Eval("Nickname").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:BoundField HeaderText="难度" DataField="DifficultyName" SortExpression="Level" ReadOnly="true" />
                   
                    <asp:TemplateField HeaderText="赏金" SortExpression="Amounts">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("Amounts").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:BoundField HeaderText="数量" DataField="Num" SortExpression="Num" ReadOnly="true" />

                    <asp:BoundField HeaderText="时间" DataField="CreateDate" SortExpression="CreateDate" ReadOnly="true" />

                    <asp:TemplateField HeaderText="类别">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlSubject" runat="server"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSubject" runat="server" Text='<%# Bind("Kind") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:CommandField HeaderText="编辑" ShowEditButton="True" />

                     <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                           <%-- <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ewm" CommandArgument='<%# Bind("SeriaNo") %>'>生成二维码</asp:LinkButton>--%>
                            <a href='ewm.aspx?SeriaNo=<%# Eval("SeriaNo") %>' target="_blank">生成二维码</a>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="查看" ShowHeader="False">
                        <ItemTemplate>
                            <a href='Detail.aspx?SeriaNo=<%# Eval("SeriaNo") %>&Amounts=<%# SaveTwoDec(Eval("Amounts").ToString()) %>' target="_blank">订单详情</a>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>

           
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SeriaNo_Input" title="请输入订单号~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        发起人编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ID_Input" title="请输入发起人编号~24:" runat="server" CssClass="text_input"></asp:TextBox>
                       
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发起人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="NickName_Input" title="请输入昵称~24:" runat="server" CssClass="text_input"></asp:TextBox>
                       
                    </td>
                </tr>

             
               <tr>
                    <td class="table_body">
                        难度</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="dllDifficultyLevel" runat="server">
                        <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                        </td>
                </tr>
              
                <tr>
                    <td class="table_body">
                        时间</td>
                    <td class="table_none">
                     
                       <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>~<asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>
               
                <tr>
                    <td colspan="4" align="right"><asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
       
    </FrameWorkWebControls:TabOptionWebControls>


</asp:Content>
