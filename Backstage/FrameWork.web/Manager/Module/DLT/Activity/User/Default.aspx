<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.User.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .bg_radius {
            border-radius:100px;
        }
    </style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls2" runat="server"
         HeadOPTxt="用户列表" HeadTitleTxt="用户" HeadTitleIcon="default.gif">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>


    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="用户列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" onrowcancelingedit="GridView1_RowCancelingEdit" onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                       <%-- <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>--%>
                       <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="用户ID" DataField="ID" ReadOnly="true" />
                     <asp:TemplateField HeaderText="头像">
                        <EditItemTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server"  />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("AvatarUrl")%>' Width="100" CssClass="bg_radius" />
                        </ItemTemplate>
                     </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="昵称">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEditNickName" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                           <%# FrameWork.Common.Base64Decode(Eval("Nickname").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField> 

                     <asp:BoundField HeaderText="国籍" DataField="Country" ReadOnly="true" />
                     <asp:BoundField HeaderText="省份" DataField="Province" ReadOnly="true" />
                     <asp:BoundField HeaderText="城市" DataField="City" ReadOnly="true" />
                    
                     <asp:TemplateField HeaderText="性别" >
                        <ItemTemplate>
                            <%#Eval("Gender").ToString()=="1"?"男":"女"%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" ReadOnly="true" />

                    <asp:TemplateField HeaderText="会员">
                        <ItemTemplate>
                              <asp:Label ID="lblMember" runat="server" Text='<%#Eval("MemberID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlMember" runat="server">
                                <asp:ListItem Value="0">普通用户</asp:ListItem>
                                <asp:ListItem Value="1">终身永久VIP</asp:ListItem>
                                <asp:ListItem Value="2">包年VIP</asp:ListItem>
                                <asp:ListItem Value="3">包月VIP</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                     </asp:TemplateField> 

                     <asp:TemplateField HeaderText="会员到期时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                             <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("EndDate") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="状态">
                         <EditItemTemplate>
                             <asp:DropDownList ID="ddlStatus" runat="server">
                                 <asp:ListItem Value="0">禁用</asp:ListItem>
                                 <asp:ListItem Value="1">正常</asp:ListItem>
                             </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# XQStatus(Eval("Status").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtComment" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblComment" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                             <a target="_blank" href='../../Log/tlOperate/Default.aspx?ID=<%#Eval("ID")%>'>操作日志</a>
                        </ItemTemplate>
                    </asp:TemplateField>  

                    <asp:CommandField HeaderText="操作" ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
           
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                        <asp:TextBox ID="UID_Input" title="请输入用户ID~24:" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Nickname_Input" title="请输入昵称~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        省份</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Province_Input" title="请输入省份~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>
               
                <tr>
                    <td class="table_body">
                        城市</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="City_Input" title="请输入城市~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>

                 <tr>
                  <td class="table_body">日期范围</td>
                  <td class="table_none">
                  <asp:TextBox ID="S_dtDate_Input" title="请输入开始日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                 
                    ~
                  <asp:TextBox ID="E_dtDate_Input" title="请输入结束日期~:date" onfocus="javascript:HS_setDate(this);"  Columns="10" runat="server" CssClass="text_input"></asp:TextBox>
                    
                  </td>
                </tr>
               
                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="dllUserStatus" runat="server">
                        <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                    </td>
                </tr>

                 <tr>
                    <td class="table_body">
                        会员</td>
                    <td class="table_none">

                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    
                    </td>
                </tr>
               
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
       
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
