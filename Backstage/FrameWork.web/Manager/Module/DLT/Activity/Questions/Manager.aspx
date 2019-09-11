<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Questions.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="题库" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="题库"  />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加题库">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                 <tr>
                    <td class="table_body">
                        难易程度</td>
                    <td class="table_none">
                     
                       <asp:DropDownList ID="ddlDifficulty" runat="server"> </asp:DropDownList>
                    
                       <asp:Label ID="lblDifficulty_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtTitle_Input" title="请输入标题" runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblTitle_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        A</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtA_Input"  runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblA_Disp" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        B</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtB_Input"  runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblB_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        C</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtC_Input"  runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblC_Disp" runat="server"></asp:Label></td>
                </tr>

                 <tr>
                    <td class="table_body">
                        D</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txtD_Input"  runat="server" CssClass="text_input" Width="400"></asp:TextBox>
                    
                        <asp:Label ID="lblD_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        类别</td>
                    <td class="table_none">
                     
                       <asp:DropDownList ID="ddlSubject" runat="server">
                             <asp:ListItem Text="不限" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="lblSubject_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        答案</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ddlAnswer" runat="server">
                             <asp:ListItem Text="A" Value="A"></asp:ListItem>
                             <asp:ListItem Text="B" Value="B"></asp:ListItem>
                             <asp:ListItem Text="C" Value="C"></asp:ListItem>
                             <asp:ListItem Text="D" Value="D"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="lblAnswer_Disp" runat="server"></asp:Label></td>
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
