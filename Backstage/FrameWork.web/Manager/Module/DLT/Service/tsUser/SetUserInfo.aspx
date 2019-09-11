<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="SetUserInfo.aspx.cs" Inherits="DLT.Web.Module.DLT.tsUser.SetUserInfo" ValidateRequest="false"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="用户">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="用户" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="修改用户信息">
        <script src="../../../../js/ckeditor/ckeditor.js" type="text/javascript"></script>
        <script type="text/javascript" src="../../../../js/ckfinder/ckfinder.js"></script>
        <div style="margin:0 0 20px 0;">
        <div style="font-weight:bold;color:Blue;font-size:14px;margin-bottom:10px; ">

             当前用户ID：<asp:Label ID="tsUser_UID_Input" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; 当前登录ID：<asp:Label ID="tsUser_LoginID_Input" runat="server" Text=""></asp:Label>
             <BR /><BR />当前操作备注：<asp:TextBox ID="txtCurComment" CssClass="text_input" runat="server" Width="400px"></asp:TextBox> 
            &nbsp;<asp:Button ID="btnSave" runat="server" Text="保存" CssClass="button_bak" 
                 onclick="btnSave_Click" />
        </div>
        <div style="padding:5px 0; color:red;font-weight:bold;">置空用户绑定手机号码</div>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body" style="width: 140px">
                        绑定手机</td>
                    <td class="table_none1">
                        <asp:HiddenField ID="hdBindMobile" runat="server" />
                        <asp:TextBox ID="tsUser_BindMobile_Input" title="请输入绑定手机" runat="server" CssClass="text_input" Width="300px"></asp:TextBox>
                    
                        </td>
                </tr>          
                <tr id="ButtonOption" runat="server">
                    <td align="left" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="保存" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
            </div>
            <div style="margin:20px 0;">
        <div style="padding:5px 0;color:red;font-weight:bold;">修改用户密保问题答案</div>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body" style="width: 140px">
                        安全问题</td>
                    <td class="table_none1">
                     <asp:HiddenField ID="hdQuestion" runat="server" />
                        <asp:TextBox ID="tsUser_Question_Input" title="请输入安全问题" runat="server" CssClass="text_input" Width="300px"></asp:TextBox>
                    
                        </td>
                </tr>

                <tr>
                    <td class="table_body" style="width: 140px">
                        安全答案</td>
                    <td class="table_none1">
                     <asp:HiddenField ID="hdAnswer" runat="server" />
                        <asp:TextBox ID="tsUser_Answer_Input" title="请输入安全答案" runat="server" CssClass="text_input" Width="300px"></asp:TextBox>
                    
                        </td>
                </tr>      
                <tr id="Tr1" runat="server">
                    <td align="left" colspan="2">
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="保存" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
            </div>
            <div style="margin:0 0 20px 0;">
            <div style="padding:5px 0;color:red;font-weight:bold;">修改用户登录密码</div>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body" style="width: 140px">
                        新登录密码</td>
                    <td class="table_none1">
                     
                        <asp:TextBox ID="tsUser_Pass_Input" title="请输入登录密码" runat="server" CssClass="text_input" Width="300px"></asp:TextBox>
                    
                        </td>
                </tr>    
                <tr id="Tr2" runat="server">
                    <td align="left" colspan="2">
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="保存" OnClick="Button3_Click" />
                    </td>
                </tr>
            </table>
            <div style="margin:0 0 20px 0;">
            <div runat="server" id="divAccountProvedContent" style="display:none;">
            
            </div>
            <div style="padding:5px 0;color:red;font-weight:bold;" >保存账户证明材料及操作备注【可直接QQ截图复制粘贴在以下内容框-仅支持火狐浏览器)】 <a href="javascript:HisDeal()" id="aHisDeal" runat="server" style="display:none">历史处理情况</a> <a href="javascript:Edit()" id="aEdit" runat="server">增加证明资料</a></div>
            
            <div style="display:none;" runat="server" id="divdivAccountProvedEdit">
            
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body" style="width:140px">
                        证明材料及备注</td>
                    <td class="table_none1">
                     
                       <asp:TextBox ID="txtAccountProved" TextMode="MultiLine" runat="server" Width="900px" ></asp:TextBox>
                    
                    
                                                <script type="text/javascript"><!--
                                                    // This call can be placed at any point after the    
                                                    // <textarea>, or inside a <head><script> in a    
                                                    // window.onload event handler.    

                                                    // Replace the <textareaid="editor"> with an CKEditor
                                                    // instance, using default configurations.


                                                    CKEDITOR.replace('<%= txtAccountProved.ClientID %>',
                  {
                      filebrowserBrowseUrl: '../../../../js/ckfinder/ckfinder.html',
                      filebrowserImageBrowseUrl: '../../../../js/ckfinder/ckfinder.html?Type=Images',
                      filebrowserFlashBrowseUrl: '../../../../js/ckfinder/ckfinder.html?Type=Flash',
                      filebrowserUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files',
                      filebrowserImageUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images',
                      filebrowserFlashUploadUrl: '../../../../js/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash'
                  }
                );
                                                    // -->

                                                    function Edit() {
                                                        document.getElementById("ctl00_PageBody_divdivAccountProvedEdit").style.display = "";
                                                        document.getElementById("ctl00_PageBody_aEdit").style.display = "none";
                                                    }

                                                    function HisDeal() {
                                                        document.getElementById("ctl00_PageBody_divAccountProvedContent").style.display = "";
                                                        document.getElementById("ctl00_PageBody_aHisDeal").style.display = "none";
                                                    }
</script> 
                    
                        </td>
                </tr>  
                 <tr>
                    <td class="table_body" style="width:140px">
                        是否处理完成</td>
                    <td class="table_none1">
                     
                    <asp:CheckBox ID="cbDeal" runat="server" Text="处理完成" />
                    
                        </td>
                </tr>  
                <tr id="Tr3" runat="server">
                    <td align="left" colspan="2">
                        <asp:Button ID="btnAccountProved" runat="server" CssClass="button_bak" 
                            Text="保存" onclick="btnAccountProved_Click" />
                    </td>
                </tr>
            </table>
            </div>
            </div>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
