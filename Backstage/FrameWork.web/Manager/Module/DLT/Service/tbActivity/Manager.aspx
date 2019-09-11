<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.tbActivity.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="新增平台活动">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加平台活动">
           <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        活动名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_Title_Input" title="请输入Title~256:!" runat="server" 
                            CssClass="text_input" Width="274px"></asp:TextBox>
                    
                        <asp:Label ID="tbActivity_Title_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlUserType" runat="server">
                        <asp:ListItem Value="10">下家</asp:ListItem>
                        <asp:ListItem Value="11">上家</asp:ListItem>
                        </asp:DropDownList>
                    
                        <asp:Label ID="tbActivity_UserType_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        游戏</td>
                    <td class="table_none">
                        <asp:CheckBoxList ID="cbGame" runat="server" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>           
                        <asp:Label ID="tbActivity_GameID_Disp" runat="server"></asp:Label></td>
                </tr>
                
                
                <tr>
                    <td class="table_body">
                        活动频道</td>
                    <td class="table_none">      
                        <asp:CheckBoxList ID="cbChannel" runat="server" RepeatDirection="Horizontal" onclick="DisPrice()">
                        <asp:ListItem Value="10">内部频道</asp:ListItem>
                        <asp:ListItem Value="11">公共频道</asp:ListItem>
                        <asp:ListItem Value="13">优质频道</asp:ListItem>
                        </asp:CheckBoxList>
                     
                        
                    
                        <asp:Label ID="tbActivity_Channel_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        红包金额</td>
                    <td class="table_none">
                    
                     
                        <asp:TextBox ID="tbActivity_Price_Input" title="请输入Price~float" runat="server" CssClass="text_input"></asp:TextBox><span id="s1"></span>
                        
                        <asp:TextBox ID="tbActivity_Price1_Input" title="请输入Price~float" runat="server" CssClass="text_input"></asp:TextBox><span id="s2"></span>
                        
                        <asp:TextBox ID="tbActivity_Price2_Input" title="请输入Price~float" runat="server" CssClass="text_input"></asp:TextBox><span id="s3"></span>
                        
                        <asp:Label ID="tbActivity_Price_Disp" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="tbActivity_Pirce2_Disp" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="tbActivity_Pirce3_Disp" runat="server" Visible="false"></asp:Label>
                        
                                            <script type="text/javascript">

                                                function DisPrice() {

                                                    if (document.getElementById("ctl00_PageBody_cbChannel_0").checked && 
                                                        document.getElementById("ctl00_PageBody_cbChannel_1").checked &&
                                                        document.getElementById("ctl00_PageBody_cbChannel_2").checked == false) {
                                                        document.getElementById("s1").innerHTML = "内部红包价格";
                                                        document.getElementById("s2").innerHTML = "公共红包价格";
                                                        document.getElementById("s3").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "none";
                                                    }
                                                    else if (document.getElementById("ctl00_PageBody_cbChannel_0").checked && 
                                                        document.getElementById("ctl00_PageBody_cbChannel_2").checked &&
                                                        document.getElementById("ctl00_PageBody_cbChannel_1").checked == false) {
                                                        document.getElementById("s1").innerHTML = "内部红包价格";
                                                        document.getElementById("s3").innerHTML = "优质红包价格";
                                                        document.getElementById("s2").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "none";
                                                    }
                                                    else if (document.getElementById("ctl00_PageBody_cbChannel_1").checked && 
                                                        document.getElementById("ctl00_PageBody_cbChannel_2").checked &&
                                                        document.getElementById("ctl00_PageBody_cbChannel_0").checked == false) {
                                                        document.getElementById("s2").innerHTML = "公共红包价格";
                                                        document.getElementById("s3").innerHTML = "优质红包价格";
                                                        document.getElementById("s1").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "none";
                                                    }
                                                    else if (document.getElementById("ctl00_PageBody_cbChannel_0").checked && 
                                                        document.getElementById("ctl00_PageBody_cbChannel_1").checked &&
                                                        document.getElementById("ctl00_PageBody_cbChannel_2").checked) {
                                                        document.getElementById("s1").innerHTML = "内部红包价格";
                                                        document.getElementById("s2").innerHTML = "公共红包价格";
                                                        document.getElementById("s3").innerHTML = "优质红包价格";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "";
                                                    }
                                                    else if (document.getElementById("ctl00_PageBody_cbChannel_0").checked) {
                                                        document.getElementById("s1").innerHTML = "内部红包价格";
                                                        document.getElementById("s2").innerHTML = "";
                                                        document.getElementById("s3").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "none";
                                                    }
                                                    else if (document.getElementById("ctl00_PageBody_cbChannel_1").checked) {
                                                        document.getElementById("s1").innerHTML = "";
                                                        document.getElementById("s2").innerHTML = "公共红包价格";
                                                        document.getElementById("s3").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "none";
                                                    } else if (document.getElementById("ctl00_PageBody_cbChannel_2").checked) {
                                                        document.getElementById("s1").innerHTML = "";
                                                        document.getElementById("s2").innerHTML = "";
                                                        document.getElementById("s3").innerHTML = "优质红包价格";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "";
                                                    } else {
                                                        document.getElementById("s1").innerHTML = "请至少选择一个活动频道";
                                                        document.getElementById("s2").innerHTML = "";
                                                        document.getElementById("s3").innerHTML = "";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price1_Input").style.display = "none";
                                                        document.getElementById("ctl00_PageBody_tbActivity_Price2_Input").style.display = "none";
                                                    }
                                                }

                                                DisPrice();
                    
                                            </script>
                        
                        </td>
                </tr>
                
                


                <tr>
                    <td class="table_body">
                        活动时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_StartDate_Input" title="请输入StartDate~datetime" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px"></asp:TextBox>
                        <asp:Label ID="tbActivity_StartDate_Disp" runat="server"></asp:Label>
                        至
                        <asp:TextBox ID="tbActivity_EndDate_Input" title="请输入EndDate~datetime" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px"></asp:TextBox>
                        <asp:Label ID="tbActivity_EndDate_Disp" runat="server"></asp:Label>
                        </td>
                </tr>




                <tr style="display:none">
                    <td class="table_body">
                        发送时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_SendDate_Input" title="请输入SendDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbActivity_SendDate_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none">
                    <td class="table_body">
                        活动状态</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_Status_Input" title="请输入Status~2147483648:int" runat="server" CssClass="text_input" Text="10"></asp:TextBox>
                    
                        <asp:Label ID="tbActivity_Status_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_Comment_Input" title="请输入Comment~2048:" runat="server" CssClass="text_input" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox>
                    
                        <asp:Label ID="tbActivity_Comment_Disp" runat="server"></asp:Label></td>
                </tr>
                                <tr style="display:none">
                    <td class="table_body">
                        CreateDate</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="tbActivity_CreateDate_Input" title="请输入CreateDate~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="tbActivity_CreateDate_Disp" runat="server"></asp:Label></td>
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
