<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbServiceHelp.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="tbServiceHelp">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="tbServiceHelp" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加tbServiceHelp">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        ODSerialNo</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_ODSerialNo_Input" title="请输入ODSerialNo~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_ODSerialNo_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        UserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_UserID_Input" title="请输入UserID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        AcceptUserID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_AcceptUserID_Input" title="请输入AcceptUserID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_AcceptUserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Content</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_Content_Input" title="请输入Content~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_Content_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        IsDeal</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tbServiceHelp_IsDeal_Input" runat="server">
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tbServiceHelp_IsDeal_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        HelpType</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tbServiceHelp_HelpType_Input" runat="server">
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tbServiceHelp_HelpType_Disp" runat="server"></asp:Label></td>
                </tr>
                

                <tr>
                    <td class="table_body">
                        CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_CreateDate_Input" title="请输入CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        DealDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_DealDate_Input" title="请输入DealDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_DealDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        DealCustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_DealCustomerID_Input" title="请输入DealCustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_DealCustomerID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Remark</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbServiceHelp_Remark_Input" title="请输入Remark~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbServiceHelp_Remark_Disp" runat="server"></asp:Label></td>
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
