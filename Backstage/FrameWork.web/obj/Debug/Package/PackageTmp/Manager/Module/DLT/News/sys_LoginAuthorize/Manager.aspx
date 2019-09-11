<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_LoginAuthorize.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="登录授权">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="登录授权" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加登录授权">
        
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
        
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        IP地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_MAC_Input" title="请输入L_MAC~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_MAC_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                    
                    <asp:DropDownList ID="sys_LoginAuthorize_L_Status_Input" runat="server">
                        <asp:ListItem Value="1">启用</asp:ListItem>
                        <asp:ListItem Value="0">禁止</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:Label ID="sys_LoginAuthorize_L_Status_Disp" runat="server"></asp:Label>
                        </td>
                </tr>

                <tr>
                    <td class="table_body">
                        时间范围</td>
                    <td class="table_none">
                     
                     <asp:TextBox ID="sys_LoginAuthorize_L_StartDate_Input" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入开始时间~:datetime"></asp:TextBox> ~ 
                     
                        
                    <asp:TextBox
                                ID="sys_LoginAuthorize_L_EndDate_Input" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                                onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入结束时间~:datetime"></asp:TextBox>
                        </td>
                </tr>



                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_Remark_Input" style="width:700px;" title="请输入L_Remark~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_Remark_Disp" runat="server"></asp:Label></td>
                </tr>
                
                                <tr style="display:none;">
                    <td class="table_body">
                        最后更新日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_CreateDate_Input" title="请输入L_CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        L_IP</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_IP_Input" title="请输入L_IP~40:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_IP_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        L_BC1</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_BC1_Input" title="请输入L_BC1~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_BC1_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        L_BC2</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_BC2_Input" title="请输入L_BC2~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_BC2_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        L_BC3</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_LoginAuthorize_L_BC3_Input" title="请输入L_BC3~512:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_LoginAuthorize_L_BC3_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
