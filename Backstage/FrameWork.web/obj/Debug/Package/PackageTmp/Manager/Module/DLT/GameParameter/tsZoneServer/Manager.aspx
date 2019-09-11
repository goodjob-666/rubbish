<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsZoneServer.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="区服汇总">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="区服汇总" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加区服汇总">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        编码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_Code_Input" title="请输入编码~18:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_Code_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        游戏ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_GameID_Input" title="请输入游戏ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_GameID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_Game_Input" title="请输入游戏~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_Game_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        大区ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_ZoneID_Input" title="请输入大区ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_ZoneID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        大区</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_Zone_Input" title="请输入大区~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_Zone_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        服务器ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_ServerID_Input" title="请输入服务器ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_ServerID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        服务器</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_Server_Input" title="请输入服务器~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_Server_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        阵营ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_FactionID_Input" title="请输入阵营ID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_FactionID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        阵营</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_Faction_Input" title="请输入阵营~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_Faction_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        拼音全称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_SpellFull_Input" title="请输入拼音全称~250:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_SpellFull_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        拼音简称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsZoneServer_SpellShort_Input" title="请输入拼音简称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsZoneServer_SpellShort_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        运营状态</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsZoneServer_IsOnline_Input" runat="server">
                            <asp:ListItem Text="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="False" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsZoneServer_IsOnline_Disp" runat="server"></asp:Label></td>
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
