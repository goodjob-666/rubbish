<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.sys_News.Manager" ValidateRequest="False" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="新闻公告">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="新闻公告" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加新闻公告">
        <script src="../../../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
        <script type="text/javascript" src="../../../../js/ckfinder/ckfinder.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        新闻类别</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlNewsType" runat="server">
                        </asp:DropDownList>
                        
                    
                        <asp:Label ID="sys_News_N_TypeID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        标题</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_Title_Input" title="请输入N_Title~100:" runat="server" CssClass="text_input" style="Width:450px;"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_Title_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        作者</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_Author_Input" title="请输入N_Author~30:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_Author_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_CreateDate_Input" title="请输入N_CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        点击</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_Click_Input" title="请输入N_Click~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_Click_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        内容</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_Content_Input" TextMode="MultiLine" runat="server" Width="500px" Height="250"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_Content_Disp" runat="server"></asp:Label></td>
                        <script type="text/javascript"><!--
                            // This call can be placed at any point after the    
                            // <textarea>, or inside a <head><script> in a    
                            // window.onload event handler.    

                            // Replace the <textareaid="editor"> with an CKEditor    
                            // instance, using default configurations.
                            CKEDITOR.replace('<%= sys_News_N_Content_Input.ClientID %>',
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
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_News_N_Remarks_Input" title="请输入N_Remarks~200:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_News_N_Remarks_Disp" runat="server"></asp:Label></td>
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
