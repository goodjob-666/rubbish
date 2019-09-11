<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_PendingMatters.Manager" ValidateRequest="False" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="增加待办事项">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="增加待办事项">
        <script src="../../../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
        <script type="text/javascript" src="../../../../js/ckfinder/ckfinder.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        事项类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlPendingMattersType" runat="server">
                        <asp:ListItem Value="1">客服部</asp:ListItem>
                        <asp:ListItem Value="2">介入部</asp:ListItem>
                        <asp:ListItem Value="3">投诉</asp:ListItem>
                        <asp:ListItem Value="5">盗号纠纷单</asp:ListItem>
                        <asp:ListItem Value="4">其它</asp:ListItem>
                        </asp:DropDownList>
                        
                    
                        <asp:Label ID="sys_PendingMatters_P_Type_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_UserID_Input" title="请输入P_UserID~50:" runat="server" CssClass="text_input" Width="450"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        联系方式</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Contact_Input" title="请输入P_Contact~300:" runat="server" CssClass="text_input" Width="450"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Contact_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        订单编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_OrderNum_Input" title="请输入P_OrderNum~250:" runat="server" CssClass="text_input" Width="450"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_OrderNum_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        待办内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Content_Input" TextMode="MultiLine" runat="server" Width="500px" Height="250"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Content_Disp" runat="server"></asp:Label>
                        <script type="text/javascript"><!--
                            // This call can be placed at any point after the    
                            // <textarea>, or inside a <head><script> in a    
                            // window.onload event handler.    

                            // Replace the <textareaid="editor"> with an CKEditor    
                            // instance, using default configurations.
                            CKEDITOR.replace('<%= sys_PendingMatters_P_Content_Input.ClientID %>',
                  {
                      filebrowserBrowseUrl: '../../../../js/ckfinder/ckfinder.html',
                      filebrowserImageBrowseUrl: '../../../../js/ckfinder/ckfinder.html?Type=Images',
                      filebrowserFlashBrowseUrl: '../../../../js/ckfinder/ckfinder.html?Type=Flash',
                      filebrowserUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                      filebrowserImageUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                      filebrowserFlashUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                  }
                );    
// --></script>
                        
                        </td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        P_CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_CreateDate_Input" title="请输入P_CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        P_ReplyDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_ReplyDate_Input" title="请输入P_ReplyDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_ReplyDate_Disp" runat="server"></asp:Label></td>
                </tr>


                <tr  style="display:none">
                    <td class="table_body">
                        P_PostID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_PostID_Input" title="请输入P_PostID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_PostID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        P_ReplyID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_ReplyID_Input" title="请输入P_ReplyID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_ReplyID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        P_ReContent</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_ReContent_Input" title="请输入P_ReContent~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_ReContent_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        P_IsDeal</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_IsDeal_Input" title="请输入P_IsDeal~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_IsDeal_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        P_Pre1</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre1_Input" title="请输入P_Pre1~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre1_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        P_Pre2</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre2_Input" title="请输入P_Pre2~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre2_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        P_Pre3</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre3_Input" title="请输入P_Pre3~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre3_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        P_Pre4</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre4_Input" title="请输入P_Pre4~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre4_Disp" runat="server"></asp:Label></td>
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
