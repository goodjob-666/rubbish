<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tsNotice.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="系统公告">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="系统公告" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加系统公告">
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_Title_Input" title="请输入标题~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_Title_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        正文</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_Body_Input" title="请输入正文~4000:!" runat="server" CssClass="text_input" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_Body_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        链接</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_Url_Input" title="请输入链接~100:" runat="server" 
                            CssClass="text_input" Width="281px"></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_Url_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        发布日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_PubDate_Input" title="请输入发布日期~:datetime" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" ></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_PubDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        开始日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_StartDate_Input" title="请输入开始日期~:datetime" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" ></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_StartDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        结束日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tsNotice_EndDate_Input" title="请输入结束日期~:datetime" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" ></asp:TextBox>
                    
                        <asp:Label ID="tsNotice_EndDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否启用</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="tsNotice_Enable_Input" runat="server">
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tsNotice_Enable_Disp" runat="server"></asp:Label></td>
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
