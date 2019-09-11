<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.tbLevelOrderReJudg.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="订单重判列表" HeadTitleTxt="订单重判列表">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="订单重判列表列表">
<div runat="server" id="divAddOrder" visible="false">请输入需要重判的订单号：<asp:TextBox ID="txtOrder" runat="server"></asp:TextBox> <asp:Button
                ID="btnAddOrder" runat="server" Text="增加" 
        onclick="btnAddOrder_Click" /></div>
            <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="订单编号" DataField="SerialNo" />
                    <asp:TemplateField HeaderText="订单标题" ShowHeader="False">
          <ItemTemplate>
              <%#OrderTitle((Eval("SerialNo").ToString()))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:TemplateField HeaderText="已判客服数量" ShowHeader="False">
          <ItemTemplate>
              <%#ReJudgCount((Eval("SerialNo").ToString()))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="我的状态" ShowHeader="False">
          <ItemTemplate>
          <%#MyJudgStatus((Eval("SerialNo").ToString()))%>
          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="标记红色" ShowHeader="False">
          <ItemTemplate>
          <asp:CheckBox ID="cbIsDeal" runat="server" OnCheckedChanged="cbIsDeal_CheckedChanged" AutoPostBack="true" ValidationGroup='<%#Eval("ID")%>' />（勾选即生效）
          <asp:HiddenField ID="hfIsDeal" runat="server" Value='<%#Eval("MarkColor")%>' />
          </ItemTemplate>
        </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
          <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("SerialNo") %>' CommandName="OrderDetail"
                                Text="订单详情"></asp:LinkButton>
          </ItemTemplate>
        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        订单号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ODSerialNo_Input" title="请输入ODSerialNo~20:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        CustomerID</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CustomerID_Input" title="请输入CustomerID~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr style="display:none;">
                    <td class="table_body">
                        Reason</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Reason_Input" title="请输入Reason~1024:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="订单详情">
      <div style="margin-top:10px;">
        <div style="float:left;">
          <asp:Label ID="lb_Title2" runat="server" CssClass="menubar_readme_text_top"></asp:Label>
        </div>
        <div style="margin-right: 5px;float:right;">
          <asp:LinkButton ID="LinkButton6" runat="server" BackColor="White" BorderColor="Red" Visible="false"
                ForeColor="DarkGreen" OnClick="LinkButton6_Click" Height="13px">刷新</asp:LinkButton>
        </div>
      </div>
      <br />
      <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr>
          <td class="table_body table_body_NoWidth" style="height: 30px">订单号 </td>
          <td class="table_none table_none_NoWidth" style="height: 30px"><asp:Label ID="U_SerialNo_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth" style="height: 30px">发布时间</td>
          <td class="table_none table_none_NoWidth" style="height: 30px"><asp:Label ID="U_CreateDate_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">游戏区服</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_GameServer_Txt" runat="server"></asp:Label></td>
          <td class="table_none table_body_NoWidth" style="height: 30px">首查人：
            <asp:Label ID="U_FirstOPName_Txt" runat="server" ForeColor="Red"></asp:Label></td>
          <td class="table_none table_none_NoWidth" style="height: 30px">首查时间： 
            <asp:Label ID="U_TrackTime_Txt" runat="server" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单标题</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="U_Title_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">订单金额</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Bal_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
          <td class="table_body table_body_NoWidth">转单下家</td>
          <td class="table_none table_none_NoWidth"><asp:Label ForeColor="DarkGreen" ID="lblZD" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">安全保证金</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Ensure1_Txt" runat="server"></asp:Label></td>
          <td class="table_body table_body_NoWidth">效率保证金</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_Ensure2_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">代练时限</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_TimeLimit_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label></td>
          <td class="table_body table_body_NoWidth">剩余时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_LeaveTime_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">接单时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_BeginTime_Txt" runat="server" ForeColor="Blue"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;超时时间：<asp:Label ID="lblOverTime" runat="server" Text=""></asp:Label></td>
          <td class="table_body table_body_NoWidth">完单时间</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_EndTime_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">角色名</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_ActorName_Txt" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <asp:Label ID="U_ActorCount" runat="server" ForeColor="Blue"></asp:Label> | 
            <a target="_blank" href='../../Service/tbLevelOrder/Default.aspx?Actor=<%=SActor()%>'>【查询发布记录】</a></td>
                    <td class="table_body table_body_NoWidth">游戏帐号</td>
          <td class="table_none table_none_NoWidth">
              <asp:Label ID="lblGameAcc" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">当前游戏信息</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:Label ID="U_CurrInfo_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth" style="height: 30px">代练要求</td>
          <td class="table_none table_none_NoWidth" colspan="3" style="height: 30px"><asp:Label ID="U_Require_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">发布联系人</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_PublishUser_Txt" runat="server"></asp:Label>
            <asp:Label ID="U_PubOrderInfo_Txt" runat="server"></asp:Label>&nbsp;
              <asp:Label ID="lblPostUserList" runat="server" Text="相关用户列表"></asp:Label></td>
          <td class="table_body table_body_NoWidth">联系方式</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_PubContactway_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">接单联系人</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_AcceptUser_Txt" runat="server"></asp:Label>
            <asp:Label ID="U_AccOrderInfo_Txt" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblAcceptUserList" runat="server" Text="相关用户列表"></asp:Label></td>
          <td class="table_body table_body_NoWidth">联系方式</td>
          <td class="table_none table_none_NoWidth"><asp:Label ID="U_AccContactway_Txt" runat="server"></asp:Label></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">后台备注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><div style="float:left"><asp:TextBox Enabled="false" ID="tbComment" runat="server" Columns="10" CssClass="text_input" Width="418px" Height="118px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" CssClass="button_bak" Text="修改备注" OnClick="Button5_Click" Visible="false" /></div>
              <div style="float:left;" >
              <script type="text/javascript">
                  function ChangeServiceHelp() {
                      switch (document.getElementById("ctl00_PageBody_ddlServiceHelp").value) {
                          case "1":
                              document.getElementById("ctl00_PageBody_txtServiceHelp").value = "通知上家补全证据";
                              break;
                          case "2":
                              document.getElementById("ctl00_PageBody_txtServiceHelp").value = "通知下家补全证据";
                              break;
                          case "3":
                              document.getElementById("ctl00_PageBody_txtServiceHelp").value = "";
                              break;
                      }
                  }
              </script> <asp:CheckBox ID="cbServiceHelp" runat="server" Enabled="false" /> 需要客服协助 
              <select id="ddlServiceHelp" disabled="disabled" runat="server" onchange="ChangeServiceHelp()">
                  
                  <option value="1">上家补</option>
                  <option value="2">下家补</option>
                  <option value="3">自定义</option>
                  </select></div> <div style="float:left; margin-left:10px;"><asp:TextBox Enabled="false" ID="txtServiceHelp" Width="200px" Height="60px" style="font-size:14px;" TextMode="MultiLine" runat="server" Text="通知上家补全证据"></asp:TextBox> </div>
                  <div style="float:left; margin-left:10px;"><asp:Button
                  ID="Button8" runat="server" Text="确定" onclick="Button8_Click" Visible="false" /> </div>
                  <asp:Label ID="lblServiceHelpStatus" runat="server" Text="" Visible="false"></asp:Label>
            <asp:HiddenField ID="hfCancelStatus" runat="server" />
            <asp:TextBox ID="tbTransTag" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbCreateOpID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbAcceptOpID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbUserID" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbDataActorName" runat="server" Visible="False">0</asp:TextBox>
            <asp:TextBox ID="tbAcceptUserID" runat="server" Visible="False">0</asp:TextBox></td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">分析备注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><div style="float:left"><asp:TextBox Enabled="false" ID="tbReJudgComment" runat="server" Columns="10" CssClass="text_input" Width="418px" Height="118px" TextMode="MultiLine"></asp:TextBox>
            <asp:Button ID="btnReJudgComment" runat="server" CssClass="button_bak" Text="修改备注" OnClick="btnReJudgComment_Click" Visible="false" /></div>
            </td>
        </tr>
        <tr>
          <td class="table_body table_body_NoWidth">标记关注</td>
          <td class="table_none table_none_NoWidth" colspan="3"><asp:CheckBox ID="cbLook" Enabled="false" runat="server" AutoPostBack="True" OnCheckedChanged="cbLook_CheckedChanged"
                            Text="已关注(勾选即生效)" /> &nbsp;&nbsp;|&nbsp;&nbsp; 禁止取消撤销 <asp:CheckBox ID="cbCancel" Enabled="false" runat="server" AutoPostBack="True" OnCheckedChanged="cbCancel_CheckedChanged" /> 已禁止(勾选即生效)</td>
        </tr>
      </table>
      <asp:Label ID="lb_Title3" runat="server" Visible="False" CssClass="menubar_readme_text_top"></asp:Label>
      <br />
      <div style="margin-bottom:8px; padding-bottom:10px;">
        <asp:Panel ID="Panel1" runat="server" Visible="false">
          <div>
            <div style="float:left; width:716px;">
              <div id="div1" runat="server">
                <asp:Label ID="lbMes1" runat="server"></asp:Label>
                <asp:TextBox ID="tbPayout" runat="server" Width="32px"></asp:TextBox>
                <asp:Label ID="lbMes2" runat="server"></asp:Label>
              </div>
              <div id="div2" runat="server">
                <asp:Label ID="lbMes3" runat="server"></asp:Label>
                <asp:TextBox ID="tbInCome" runat="server" Width="32px"></asp:TextBox>
                <asp:Label ID="lbMes4" runat="server"></asp:Label>
              </div>
            </div>
            <div style="float:left; margin-left:45px;">
                判决理由:
                <asp:TextBox ID="txtJudgReason" runat="server" Width="330px" Height="60px" TextMode="MultiLine"></asp:TextBox>
              </div>
            <div style="float:right; margin-right:90px;">
              <asp:Button ID="Button3" runat="server" Text="发表判决意见" Width="100" Height="35" OnClick="Button3_Click" />
            </div>
          </div>
        </asp:Panel>
      </div>
      <br />
      <div style="margin:10px 0;" runat="server" visible="false" id="divReJudgList">
      <div>查询方式<asp:DropDownList ID="DropDownList2" AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" runat="server" style="font-size:12px;">
            <asp:ListItem Text="所有客服" Value="-1"></asp:ListItem>
            <asp:ListItem Text="其它客服" Value="0"></asp:ListItem>
            </asp:DropDownList> </div>
              <asp:Repeater ID="Repeater2" runat="server" 
                  onitemdatabound="Repeater2_ItemDataBound">
        <ItemTemplate>
        <div id="row" runat="server">
        <div style="float:left; width:30px;padding-top: 20px"><%# Container.ItemIndex + 1%></div>
        <div style="margin:5px 0; padding:5px;border:1px solid #ededed; float:left; width:96%;">
            <asp:Panel ID="Panel2" runat="server">
            <span style="float:right;margin-left:10px;">
            <asp:CheckBox ID="cbColor" runat="server" AutoPostBack="true" OnCheckedChanged="cbColor_CheckedChanged" ValidationGroup='<%#Eval("ID")%>' Text="标记" /> 
            <asp:HiddenField ID="hfColor" runat="server" Value='<%#Eval("MarkColor")%>' />
            </span>
            <span style="float:right;margin-left:10px;">
            <a href='javascript:showPopWin("判决修改","ReWrite.aspx?ID=<%# Eval("ID") %>",600, 200, AlertMessageBox,false)'>[编辑]</a>
            </span>
            </asp:Panel>
            <span style="float:right;margin-left:10px;">时间：<%# Eval("CreateDate") %></span>
            <span style="float:right;margin-left:10px;">客服：<%#GetOpLoginName(Eval("CustomerID").ToString())%></span>
            <%#Eval("Reason") %> 
        </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
        <FrameWorkWebControls:AspNetPager ID="AspNetPager10" runat="server" 
                PageSize="50"></FrameWorkWebControls:AspNetPager>
        </div>
      <br />
      <iframe id="framelist" name="framelist" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe() {
              var iframe = document.getElementById("ctl00_PageBody_framelist");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe()", 200);
</script> <table width="100%" border="0" cellspacing="1" cellpadding="4" align="center">
        <tr>
          <td class="table_body" style="height: 30px">留言内容</td>
          <td class="table_none" style="height: 30px"><div style="float:left;"><asp:TextBox ID="tbMessage" Enabled="false" Columns="10" runat="server" CssClass="text_input" Height="79px" TextMode="MultiLine" Width="331px"></asp:TextBox>
            <asp:Button ID="Button4" runat="server" CssClass="button_bak" Visible="false" Text="添加" OnClick="Button4_Click" /></div>
            <div style="float:left; margin-left:10px;">
                <asp:Button ID="Button9" runat="server" Visible="false" Text="提醒上家补全信息"
                    Width="130px" onclick="Button9_Click" /></div>
                   <div style="float:left; margin-left:10px;">
                       <asp:Label ID="lblInfoList" runat="server" Text=""></asp:Label></div> 
            <a href="###" id="DisScreen" runat="server" style="font-size:18px;color:Red; margin-left:300px;">显示截图</a></td>
            
        </tr>
      </table>
      <br />
      <br />
      <asp:Label ID="lb_Title6" runat="server" CssClass="menubar_readme_text_top">用户跟踪</asp:Label>
      <br />
      <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr>
          <td style="width: 50%">发单者
            <asp:LinkButton ID="LinkButton3" Visible="false" runat="server" BackColor="White" BorderColor="DarkGreen" ForeColor="DarkGreen" OnClick="LinkButton3_Click">刷新</asp:LinkButton></td>
          <td>接单者
            <asp:LinkButton ID="LinkButton4" Visible="false" runat="server" BackColor="White" BorderColor="DarkGreen" ForeColor="DarkGreen" OnClick="LinkButton4_Click">刷新</asp:LinkButton></td>
        </tr>
        <tr>
          <td style="width: 50%">
          
          <iframe id="framelist1" name="framelist1" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe1() {
              var iframe = document.getElementById("ctl00_PageBody_framelist1");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe1()", 200);
</script> </td>
          <td>
          
          <iframe id="framelist2" name="framelist2" width="97%" runat="server" scrolling="no" marginheight="0" marginwidth="0" frameborder="0"></iframe>
      <script type="text/javascript">
          function reinitIframe2() {
              var iframe = document.getElementById("ctl00_PageBody_framelist2");
              try {
                  var bHeight = iframe.contentWindow.document.body.scrollHeight;
                  var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                  var height = Math.max(bHeight, dHeight);
                  iframe.height = height;
              } catch (ex) { }
          }
          window.setInterval("reinitIframe2()", 200);
</script> </td>
        </tr>
        <tr style="display:none;">
          <td style="width: 50%"><table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
              <tr>
                <td class="table_body" style="height: 30px">用户</td>
                <td class="table_none" style="height: 30px"><asp:Label ID="lbUserID" runat="server"></asp:Label>
                  <asp:Label ID="lbUserDesc" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">计分</td>
                <td class="table_none" style="height: 30px"><asp:DropDownList ID="ddlScore" runat="server">
                    <asp:ListItem>-1</asp:ListItem>
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                  </asp:DropDownList>
                  分</td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">跟踪记录</td>
                <td class="table_none" style="height: 30px"><asp:TextBox ID="tbTrackInfo" runat="server" Columns="10" CssClass="text_input" Height="79px"
                            TextMode="MultiLine" Width="331px"></asp:TextBox>
                  <asp:Button ID="Button6" runat="server" CssClass="button_bak" Text="添加" OnClick="Button6_Click" /></td>
              </tr>
            </table></td>
          <td><table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
              <tr>
                <td class="table_body" style="height: 30px">用户</td>
                <td class="table_none" style="height: 30px"><asp:Label ID="lbUserID1" runat="server"></asp:Label>
                  <asp:Label ID="lbUserDesc1" runat="server"></asp:Label></td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">计分</td>
                <td class="table_none" style="height: 30px"><asp:DropDownList ID="ddlScore1" runat="server">
                    <asp:ListItem>-1</asp:ListItem>
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                  </asp:DropDownList>
                  分</td>
              </tr>
              <tr>
                <td class="table_body" style="height: 30px">跟踪记录</td>
                <td class="table_none" style="height: 30px"><asp:TextBox ID="tbTrackInfo1" runat="server" Columns="10" CssClass="text_input" Height="79px"
                            TextMode="MultiLine" Width="331px"></asp:TextBox>
                  <asp:Button ID="Button7" runat="server" CssClass="button_bak" Text="添加" OnClick="Button7_Click" /></td>
              </tr>
            </table></td>
        </tr>
      </table>
    </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script language="javascript" type="text/javascript">
<!--

    function SelectAll() {
        var e = document.getElementsByTagName("input");
        var IsTrue;
        if (document.getElementById("CheckboxAll").value == "0") {
            IsTrue = true;
            document.getElementById("CheckboxAll").value = "1"
        }
        else {
            IsTrue = false;
            document.getElementById("CheckboxAll").value = "0"
        }
        for (var i = 0; i < e.length; i++) {
            if (e[i].type == "checkbox") {
                e[i].checked = IsTrue;
            }
        }
    }
    function deleteop() {
        var checkok = false;
        var e = document.getElementsByTagName("input");
        for (var i = 0; i < e.length; i++) {
            if (e[i].type == "checkbox") {
                if (e[i].checked == true) {
                    checkok = true;
                    break;
                }
            }
        }
        if (checkok)
            return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
        else {

            alert("请选择要删除的记录!");
            return false;
        }
    }
// -->


    rnd.today = new Date();

    rnd.seed = rnd.today.getTime();

    function rnd() {
        rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
        return rnd.seed / (233280.0);

    };

    function rand(number) {
        return Math.ceil(rnd() * number);

    };
    function AlertMessageBox(Messages) {
        DispClose = false;
        alert(Messages);
        setTimeout("reload()", 100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);

    }

    function reload() {
        document.getElementById("<%=Button1.ClientID %>").click();
    }
    </script>

</asp:Content>
