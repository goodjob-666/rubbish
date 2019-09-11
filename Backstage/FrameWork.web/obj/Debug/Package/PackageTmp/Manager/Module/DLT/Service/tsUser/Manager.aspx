<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsUser.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="用户">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加用户">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">


                <tr>
                    <td class="table_body">
                        数字ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox Enabled="false" ID="tsUser_ID_Input" title="请输入字符串ID~24:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_ID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_UID_Input" Enabled="false" title="请输入字符串ID~24:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_UID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        昵称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Nickname_Input" title="请输入昵称~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Nickname_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登录ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_LoginID_Input" Enabled="false" title="请输入登录ID~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_LoginID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        登录密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Pass_Input" Enabled="false" title="请输入登录密码~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Pass_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        邮箱</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Email_Input" Enabled="false" title="请输入邮箱~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Email_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        联系QQ</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_QQ_Input" Enabled="false" title="请输入联系QQ~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_QQ_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        联系电话</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Mobile_Input" Enabled="false" title="请输入联系电话~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Mobile_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        安全问题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Question_Input" Enabled="false" title="请输入安全问题~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Question_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        安全答案</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Answer_Input" Enabled="false" title="请输入安全答案~256:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Answer_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        绑定手机</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_BindMobile_Input" Enabled="false" title="请输入绑定手机~128:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_BindMobile_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        支付密码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_PayPass_Input" Enabled="false" title="请输入支付密码~256:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_PayPass_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        登录模式</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlLoginModel" runat="server">
                        
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsUser_LoginMode_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        在线状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlIsOnline" runat="server">
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsUser_IsOnline_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        子帐号权限</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsUser_HaveSubUser_Input" runat="server">
                            <asp:ListItem Text="启用" Value="1"></asp:ListItem>
                            <asp:ListItem Text="禁用" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsUser_HaveSubUser_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        图标序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_IconIndex_Input" title="请输入图标序号~2147483648:int!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_IconIndex_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_CreateDate_Input" title="请输入创建时间~datetime!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        登录时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_LoginDate_Input" title="请输入登录时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_LoginDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlStatus" runat="server">
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsUser_Status_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        签名</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Sign_Input" title="请输入签名~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Sign_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr  style="display:none">
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsUser_Comment_Input" title="请输入备注~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsUser_Comment_Disp" runat="server"></asp:Label></td>
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
