<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.PubSelect.Default" Title="无标题页" %>
  
  
  <asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
  
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadOPTxt="上家记录查询" HeadTitleTxt="上家记录"></FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="角色名出现频率">
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>日期范围
              <asp:TextBox ID="S_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
              <asp:TextBox ID="E_dtDate_Input" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>
              <asp:Button ID="Button1" runat="server" CssClass="button_bak" OnClick="Button1_Click" Text="查询" /></td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="Game" HeaderText="游戏" />
                  <asp:BoundField DataField="Zone" HeaderText="大区" />
                  <asp:BoundField DataField="Server" HeaderText="服务器" />
                  <asp:BoundField DataField="Actor" HeaderText="角色名" />
                  <asp:BoundField DataField="Scount" HeaderText="数量" />
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="260" runat="server"></asp:TextBox>
                      <asp:HiddenField ID="hfActor" Value='<%# Eval("Actor") %>' runat="server" />
                      <asp:Button ID="btnUpdate" runat="server" Text="修改" CommandName="UpdateUserRoleComment" CommandArgument='<%# Eval("Code")%>' /></ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </FrameWorkWebControls:TabOptionItem>
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="发单撤单比例">
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>日期范围
              <asp:TextBox ID="S_dtDate_Input1" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
              <asp:TextBox ID="E_dtDate_Input1" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>发单数量
              <asp:DropDownList ID="ddlPubCount1" runat="server">
                <asp:ListItem>不限</asp:ListItem>
                <asp:ListItem Value="&gt;">大于</asp:ListItem>
                <asp:ListItem Value="&lt;">小于</asp:ListItem>
                <asp:ListItem Value="=">等于</asp:ListItem>
                <asp:ListItem Value="==">二者之间(-隔开)</asp:ListItem></asp:DropDownList>
              <asp:TextBox ID="tbPubCount2" runat="server" Width="79px"></asp:TextBox>用户ID
              <asp:TextBox ID="tbUserID" runat="server" Width="139px"></asp:TextBox>
              <asp:Button ID="Button2" runat="server" CssClass="button_bak" OnClick="Button2_Click" Text="查询" Height="18px" /></td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="GridView2" runat="server" OnRowCommand="GridView1_RowCommand" onrowcreated="GridView2_RowCreated" onsorting="GridView2_Sorting">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="UID" HeaderText="用户ID" />
                  <asp:BoundField DataField="LoginID" HeaderText="登录名" />
                  <asp:BoundField DataField="NickName" HeaderText="昵称" />
                  <asp:BoundField DataField="PScount" HeaderText="发单数量" />
                  <asp:BoundField DataField="CScount" HeaderText="撤单数量" />
                  <asp:BoundField DataField="Rate" HeaderText="撤单比例" SortExpression="Rate" />
                  <asp:BoundField DataField="Spaybal" HeaderText="发单支付代练费" />
                  <asp:BoundField DataField="Srepbal" HeaderText="发单获赔保证金" />
                  <asp:BoundField DataField="Rate1" HeaderText="获赔与支付比例" SortExpression="Rate1" />
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox ID="txtComment" runat="server" Text='<%# Eval("Comment") %>' Width="260"></asp:TextBox>
                      <asp:Button ID="btnUpdate" runat="server" CommandArgument='<%# Eval("UID")%>' CommandName="UpdateUserComment" Text="修改" />
                      <a href='javascript:showPopWin("发送站内信","SendInSideMail.aspx?UID=<%# Eval("UID") %>",530, 230, null,false)'>内部信</a></ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#XQStatus((Eval("UID").ToString()))%>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </FrameWorkWebControls:TabOptionItem>
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="客服介入比例">
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>日期范围
              <asp:TextBox ID="S_dtDate_Input2" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
              <asp:TextBox ID="E_dtDate_Input2" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>发单数量
              <asp:DropDownList ID="ddlPubCount2" runat="server">
                <asp:ListItem>不限</asp:ListItem>
                <asp:ListItem Value="&gt;">大于</asp:ListItem>
                <asp:ListItem Value="&lt;">小于</asp:ListItem>
                <asp:ListItem Value="=">等于</asp:ListItem>
                <asp:ListItem Value="==">二者之间(-隔开)</asp:ListItem></asp:DropDownList>
              <asp:TextBox ID="tbPubCount3" runat="server" Width="79px"></asp:TextBox>
              <asp:Button ID="Button3" runat="server" CssClass="button_bak" OnClick="Button3_Click" Text="查询" /></td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="GridView3" runat="server" OnRowCommand="GridView1_RowCommand">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="UID" HeaderText="用户ID" />
                  <asp:BoundField DataField="LoginID" HeaderText="登录名" />
                  <asp:BoundField DataField="NickName" HeaderText="昵称" />
                  <asp:BoundField DataField="PubCount" HeaderText="发单数量" />
                  <asp:BoundField DataField="PubCancel" HeaderText="介入数量" />
                  <asp:BoundField DataField="Rate" HeaderText="介入比例" />
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="260" runat="server"></asp:TextBox>
                      <asp:Button ID="btnUpdate" runat="server" Text="修改" CommandName="UpdateUserComment" CommandArgument='<%# Eval("UID")%>' />
                      <a href='javascript:showPopWin("发送站内信","SendInSideMail.aspx?UID=<%# Eval("UID") %>",530, 230, null,false)'>内部信</a></ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#XQStatus((Eval("UID").ToString()))%>
                    </ItemTemplate>
                 </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </FrameWorkWebControls:TabOptionItem>
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="上家发单趋势统计">
        <div>游戏：
          <asp:DropDownList ID="ddlGame" runat="server" style="font-size:12px;">
            <asp:ListItem Text="无限制" Value="-1"></asp:ListItem></asp:DropDownList>
            
          &nbsp;&nbsp;日期范围：<asp:TextBox ID="txtStartDate" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~date" runat="server" CssClass="text_input"></asp:TextBox> ~  
          <asp:TextBox ID="txtEndDate" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~date" runat="server" CssClass="text_input"></asp:TextBox>
          <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="查询" /></div>
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>
              <asp:GridView ID="GridView4" runat="server" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView4_OnRowDataBound">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="UID" HeaderText="用户ID" />
                  <asp:BoundField DataField="NickName" HeaderText="上家昵称" />
                  <asp:BoundField DataField="Scount" HeaderText="总发单量" />
                  <asp:TemplateField HeaderText="发单变化">
                    <ItemTemplate>
                      <asp:Label ID="lblWeek" runat="server" Text="Label"></asp:Label>
                      <asp:HiddenField ID="hf" runat="server" Value='<%# Eval("UserID") %>' /></ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="260" runat="server"></asp:TextBox>
                      <asp:Button ID="btnUpdate" runat="server" Text="修改" CommandName="UpdateUserComment" CommandArgument='<%# Eval("UID")%>' /></ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </FrameWorkWebControls:TabOptionItem>
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="新下家接单介入查询">
        <div>新下家接单数在
          <asp:TextBox ID="txtNewAccept" runat="server" Width="55px" Text="3"></asp:TextBox>个及以下（建议数字不要太大，否则很卡） 日期范围
          <asp:TextBox ID="txtNewAcceptStart" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
          <asp:TextBox ID="txtNewAcceptEnd" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>
          <asp:Button ID="Button5" runat="server" Text="查询" onclick="Button5_Click" /></div>
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>
              <asp:GridView ID="GridView5" runat="server" OnRowCommand="GridView5_RowCommand">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="UID" HeaderText="用户ID" />
                  <asp:BoundField DataField="NickName" HeaderText="昵称" />
                  <asp:BoundField DataField="AcceptCount" HeaderText="总接单数" />
                  <asp:BoundField DataField="AcceptCancel" HeaderText="总介入数" />
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtComment" Width="260" runat="server"></asp:TextBox>
                      <asp:Button ID="btnUpdate" runat="server" Text="修改" CommandName="UpdateUserComment" CommandArgument='<%# Eval("UID")%>' /></ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
        <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
      </FrameWorkWebControls:TabOptionItem>
      <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="用户归类" Visible="false">
        <div>游戏：
          <asp:DropDownList ID="ddlGLGameID" runat="server" style="font-size:12px;">
            <asp:ListItem Text="无限制" Value="-1"></asp:ListItem></asp:DropDownList>，接单数大于
          <asp:TextBox ID="txtGLNumStart" runat="server" Width="55px" Text="0"></asp:TextBox>小于
          <asp:TextBox ID="txtGLNumEnd" runat="server" Text="5"></asp:TextBox>，日期范围
          <asp:TextBox ID="TextBox2" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入开始日期~:date"></asp:TextBox>~
          <asp:TextBox ID="TextBox3" runat="server" Columns="10" CssClass="text_input" onfocus="javascript:HS_setDate(this);" title="请输入结束日期~:date"></asp:TextBox>排序方式
          <asp:DropDownList ID="ddlOrderType" runat="server" AutoPostBack="True" onselectedindexchanged="ddlOrderType_SelectedIndexChanged">
            <asp:ListItem Value="-1">无限制</asp:ListItem>
            <asp:ListItem Value="10">总接单数</asp:ListItem>
            <asp:ListItem Value="11">总接单金额</asp:ListItem>
            <asp:ListItem Value="13">未接单时间</asp:ListItem></asp:DropDownList>
          <asp:Button ID="btnGL" runat="server" Text="查询" onclick="btnGL_Click" />|
          <asp:Button ID="Button6" runat="server" Text="导出EXCEL" onclick="Button6_Click" /></div>
        <table align="center" border="0" cellpadding="3" cellspacing="1" width="100%">
          <tr>
            <td>
              <asp:GridView ID="GridView6" runat="server" OnRowCommand="GridView6_RowCommand" onrowdatabound="GridView6_RowDataBound">
                <Columns>
                  <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                  <asp:BoundField DataField="UID" HeaderText="用户ID" />
                  <asp:BoundField DataField="BindMobile" HeaderText="绑定手机" />
                  <asp:BoundField DataField="ZJD" HeaderText="接单数" />
                  <asp:TemplateField HeaderText="有效接单数">
                    <ItemTemplate>
                      <asp:Label ID="lblYXJDS" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="ZJE" HeaderText="接单金额" />
                  <asp:TemplateField HeaderText="收入金额">
                    <ItemTemplate>
                      <asp:Label ID="lblSRPrice" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="未接单时间">
                    <ItemTemplate>
                      <asp:Label ID="lblZHJ" runat="server" Text='<%# Eval("ZHJ") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="未登录时间">
                    <ItemTemplate>
                      <asp:Label ID="lblZHD" runat="server" Text='<%# Eval("ZHD") %>'></asp:Label>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                      <asp:TextBox Text='<%# Eval("Comment") %>' ID="txtGLComment" Width="260" runat="server"></asp:TextBox>
                      <asp:Button ID="btnGLUpdate" runat="server" Text="修改" CommandName="UpdateGLUserComment" CommandArgument='<%# Eval("UID")%>' /></ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="状态">
                    <ItemTemplate>
                        <%#XQStatus((Eval("UID").ToString()))%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="操作" ShowHeader="False">
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("UserID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置"></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
        <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged"></FrameWorkWebControls:AspNetPager>
      </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
  </asp:Content>