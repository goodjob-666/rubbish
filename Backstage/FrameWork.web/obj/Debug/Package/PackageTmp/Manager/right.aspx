<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" CodeBehind="right.aspx.cs" Inherits="FrameWork.web.right"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadOPTxt="查看信息" HeadTitleTxt="系统信息">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
    
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="新闻公告">
        <div style="width:800px;">
        <div style=" margin-bottom:10px;padding-bottom:10px; border-bottom:1px dashed #999;">新闻公告类别：<asp:DropDownList 
                ID="ddlNewsType" runat="server" >
                                    <asp:ListItem Value="">不限</asp:ListItem>
            </asp:DropDownList>
             <asp:Button ID="Button5" runat="server" Text="查询" onclick="Button5_Click" />
        </div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_RowCommand">
        <ItemTemplate>
        <div style="line-height:26px;"><span style="float:right"><%#Eval("N_CreateDate")%></span>[<%#NewsType((Eval("N_TypeID").ToString()))%>] <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Detail" CausesValidation="false" CommandArgument='<%# Eval("N_ID") %>' Text='<%#Eval("N_Title") %>'></asp:LinkButton></div>
        </ItemTemplate>
        </asp:Repeater>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" 
                OnPageChanged="AspNetPager1_PageChanged" PageSize="15"></FrameWorkWebControls:AspNetPager></div>
                
                <div  style="margin-top:20px; display:none;">
                <table width="60%" border="0" cellspacing="1" cellpadding="3" align="center"><tr><td class="table_body">系统名称</td><td class="table_none"><asp:Label ID="SystemName" runat="server"></asp:Label></td></tr><tr><td class="table_body">框架版本</td><td class="table_none"><asp:Label ID="FrameWorkVer" runat="server"></asp:Label></td></tr><tr><td class="table_body">官方网站</td><td class="table_none"><asp:HyperLink ID="FrameWorkWeb" runat="server" Target="_blank"></asp:HyperLink></td></tr></table></div></FrameWorkWebControls:TabOptionItem>
        
        
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="新闻详情">
        
        <div style="width:800px;">
        
        <div style="font-size:12px;font-weight:bold;">[<asp:Label ID="sys_News_N_TypeID_Disp" runat="server" Text=""></asp:Label>]<asp:HiddenField ID="hfID" runat="server" /></div><div style="text-align:center; font-size:26px; font-weight:bold;"><asp:Label ID="sys_News_N_Title_Disp" runat="server"></asp:Label></div>
        
        <div style="text-align:center;  margin:10px 0 0 15px;">发布时间：<asp:Label ID="sys_News_N_CreateDate_Disp" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发布人： <asp:Label ID="sys_News_N_Author_Disp" runat="server"></asp:Label><asp:Label ID="sys_News_N_Click_Disp" runat="server" Visible="false"></asp:Label></div>
        
        <div style="margin-top:15px; line-height:24px;font-size:14px;">
        
        <asp:Label ID="sys_News_N_Content_Disp" runat="server"></asp:Label></div>
        
        <div style="border:1px solid red; width:800px; margin-bottom:10px; background-color:Red; height:1px;"></div>
        
        <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>
        <div style="margin:5px 0; padding:5px;border:1px solid #ededed;">
            <span style="float:right;margin-left:10px;">评论人：<%#GetOpLoginName(Eval("C_PostID").ToString())%> 时间：<%#Eval("C_CreateDate") %></span>[<%#Eval("C_Content") %>] 
        </div>
        </ItemTemplate>
        </asp:Repeater>
        
                    <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" 
                PageSize="15"></FrameWorkWebControls:AspNetPager>
                
                <div style="margin-top:15px;">
                
                <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                <td class="table_body">评论内容</td>
                <td class="table_none"><asp:TextBox ID="sys_Comment_C_Content_Input" runat="server" CssClass="text_input" TextMode="MultiLine" Width="600" Height="200"></asp:TextBox>
                </td>
                </tr>
                </table>
                </div>
                <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="回复" OnClick="Button1_Click" />
                </div>
                </FrameWorkWebControls:TabOptionItem>
        
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="待办事项">
        <div style="width:800px;">
                <div style=" margin-bottom:10px;padding-bottom:10px; border-bottom:1px dashed #999;">事件所属部门：<asp:DropDownList 
                ID="DropDownList2" runat="server">
                                    <asp:ListItem Value="">不限</asp:ListItem>
                        <asp:ListItem Value="1">客服部</asp:ListItem>
                        <asp:ListItem Value="2">介入部</asp:ListItem>
                        <asp:ListItem Value="3">投诉</asp:ListItem>
                        <asp:ListItem Value="5">盗号纠纷单</asp:ListItem>
                        <asp:ListItem Value="4">其它</asp:ListItem>
            </asp:DropDownList>
             状态：
            <asp:DropDownList 
                ID="DropDownList3" runat="server">
                                    <asp:ListItem Value="">不限</asp:ListItem>
                        <asp:ListItem Value="0">未处理</asp:ListItem>
                        <asp:ListItem Value="1">处理中</asp:ListItem>
                        <asp:ListItem Value="2">待确定</asp:ListItem>
                        <asp:ListItem Value="3">已处理</asp:ListItem>
            </asp:DropDownList> 关键字：<asp:DropDownList ID="ddlSKeyType" runat="server">
                    <asp:ListItem Value="">不限</asp:ListItem>
                    <asp:ListItem Value="用户ID">用户ID</asp:ListItem>
                    <asp:ListItem Value="用户联系方式">用户联系方式</asp:ListItem>
                    <asp:ListItem Value="订单编号">订单编号</asp:ListItem>
                    <asp:ListItem Value="提交客服ID">提交客服ID</asp:ListItem>
                    </asp:DropDownList> 
                    <asp:TextBox ID="txtKeyWords" runat="server"></asp:TextBox> <asp:Button ID="Button4" runat="server" Text="搜索" onclick="Button4_Click" />
        </div>
        <asp:Repeater ID="Repeater3" runat="server" OnItemCommand="Repeater3_RowCommand" onitemdatabound="Repeater3_ItemDataBound">
        <ItemTemplate>
        <div style="line-height:26px;"><asp:HiddenField ID="hdPendingID" runat="server" Value='<%#Eval("P_ID")%>' /><span style="float:right"><asp:Label ID="lblLastOPID" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;<%#Eval("P_CreateDate")%></span>[<%#PendingType((Eval("P_Type").ToString()))%>]-[<%#DealType((Eval("P_IsDeal").ToString()))%>]<font style="color:Red"><%#Eval("P_ReContent").ToString() == "" ? "" : "(注:" + Eval("P_ReContent").ToString() + ")"%></font> <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Detail" CausesValidation="false" CommandArgument='<%# Eval("P_ID") %>' Text='<%#FormatContent((Eval("P_Content").ToString()))%>'></asp:LinkButton></div></ItemTemplate></asp:Repeater>
                <FrameWorkWebControls:AspNetPager ID="AspNetPager3" runat="server" 
                    OnPageChanged="AspNetPager3_PageChanged" PageSize="15"></FrameWorkWebControls:AspNetPager></div></FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="待办详情">
        <div style="width:800px;">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        事项类型<asp:HiddenField ID="hdPendingID" runat="server" />
                    </td>
                    <td class="table_none">

                        <asp:Label ID="sys_PendingMatters_P_Type_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户ID</td>
                    <td class="table_none">
                     
                        <asp:Label ID="sys_PendingMatters_P_UserID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        联系方式</td>
                    <td class="table_none">
                        <asp:Label ID="sys_PendingMatters_P_Contact_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        订单编号</td>
                    <td class="table_none">
                        <asp:Label ID="sys_PendingMatters_P_OrderNum_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        记录客服</td>
                    <td class="table_none">
                    
                        <asp:Label ID="sys_PendingMatters_P_PostID_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        记录时间</td>
                    <td class="table_none">
                        <asp:Label ID="sys_PendingMatters_P_CreateDate_Disp" runat="server"></asp:Label></td>
                </tr>


                <tr>
                    <td class="table_body">
                        记录内容</td>
                    <td class="table_none">
                        <div><asp:Label ID="sys_PendingMatters_P_Content_Disp" runat="server"></asp:Label></div></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注客服</td>
                    <td class="table_none">
                    
                        <asp:Label ID="sys_PendingMatters_P_ReplyID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注时间</td>
                    <td class="table_none">
                        <asp:Label ID="sys_PendingMatters_P_ReplyDate_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        简单备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_ReContent_Input" runat="server"></asp:TextBox> <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="确定" OnClick="Button2_Click" />
                        
                        </td>
                </tr>

                <tr>
                    <td class="table_body">
                        事项状态</td>
                    <td class="table_none">
                        <asp:Label ID="sys_PendingMatters_P_IsDeal_Disp" runat="server" Text=""></asp:Label>
                        </td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre1</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre1_Input" title="请输入P_Pre1~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre1_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre2</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre2_Input" title="请输入P_Pre2~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre2_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre3</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre3_Input" title="请输入P_Pre3~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre3_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        P_Pre4</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="sys_PendingMatters_P_Pre4_Input" title="请输入P_Pre4~2147483647:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="sys_PendingMatters_P_Pre4_Disp" runat="server"></asp:Label></td>
                </tr>
                              
            </table>
            <div style="border:1px solid red; width:800px; margin-bottom:10px; background-color:Red; height:1px;"></div>
            <asp:Repeater ID="Repeater4" runat="server">
        <ItemTemplate>
        <div style="margin:5px 0; padding:5px;border:1px solid #ededed;">
            <span style="float:right;margin-left:10px;">客服：<%#GetOpLoginName(Eval("P_CommentPostID").ToString())%> <%#Eval("P_Pre").ToString()%> [<%#DealType((Eval("P_CommentStauts").ToString()))%>]</span>[<%#Eval("P_CommentContent")%>] 
        </div>
        </ItemTemplate>
        </asp:Repeater>
        
        <FrameWorkWebControls:AspNetPager ID="AspNetPager4" runat="server" 
                PageSize="15"></FrameWorkWebControls:AspNetPager>
        
                        <div style="margin-top:15px;" runat="server" id="divInput">
                
                <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                <td class="table_body">事项状态</td>
                <td class="table_none">
                <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">处理中</asp:ListItem>
                        <asp:ListItem Value="2">待确定</asp:ListItem>
                        <asp:ListItem Value="3">已处理</asp:ListItem>
                        </asp:DropDownList>
                <td class="table_none">
                </td>
                </tr>
                <tr>
                <td class="table_body">留言内容</td>
                <td class="table_none"><asp:TextBox ID="sys_PendingComment_P_CommentContent_Input" runat="server" CssClass="text_input" TextMode="MultiLine" Width="700" Height="200"></asp:TextBox>
                </td>
                </tr>
                </table>
                <span style="float:right; margin-right:10px;"><asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="回复" OnClick="Button3_Click" /></span>
                </div>
                
        </div>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
