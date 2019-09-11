<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="More.aspx.cs" Inherits="DLT.Web.Module.DLT.PubSelect.More"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="上家记录查询" HeadTitleTxt="上家记录">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
         <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="总览">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">


                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="txt_Uid_Input" title="请输入字符串ID~24:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                    </td>
                </tr>
                
                <tr>
                    <td class="table_body">发单变化</td>
                    <td class="table_none">
                        <asp:TextBox TextMode="MultiLine" ID="txt_Changed" title="请输入字符串ID~24:!" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>  
                </tr>
                              
                <tr>
                    <td align="right" colspan="2">
                       
                        <input id="Reset1" class="button_bak" type="reset" value="关闭" />
                    </td>
                </tr>
            </table>
          
            
        </FrameWorkWebControls:TabOptionItem>
    
    
       
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
