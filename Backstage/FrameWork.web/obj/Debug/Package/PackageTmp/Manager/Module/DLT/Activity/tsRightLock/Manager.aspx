<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.tsRightLock.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="权限锁定">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="权限锁定" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server"  >
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="更新权限锁定" >
        
        <style type="text/css">
            .table1{ width:100%;}
           .table1 tr td{  padding-right:15px; }
        </style>
        
        <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/js/My97DatePicker/WdatePicker.js"></script>
        <script type="text/javascript">
             function curDateTime(Type, Num) {
                 var d = new Date();
                 var year = d.getFullYear();
                 var month = d.getMonth() + 1;
                 var date = d.getDate();
                 var day = d.getDay();
                 var hours = d.getHours();
                 var minutes = d.getMinutes();
                 var seconds = d.getSeconds();
                 var ms = d.getMilliseconds();

                 if (Type == "Y") {
                     year = year + Num;
                 }
                 if (Type == "M") {
                     month = month + Num;
                 }

                 if (month > 12) {
                     year = year + 1;
                     month = month - 12;
                 }

                 if (Type == "D") {
                     var d1 = new Date();
                     var date1 = d1.getDate();
                     d1.setDate(date1 + Num);
                     date = d1.getDate();
                     month = d1.getMonth() + 1;
                     year = d1.getFullYear();
                 }

                 var curDateTime = year;



                 if (month > 9)
                     curDateTime = curDateTime + "-" + month;
                 else
                     curDateTime = curDateTime + "-0" + month;
                 if (date > 9)
                     curDateTime = curDateTime + "-" + date;
                 else
                     curDateTime = curDateTime + "-0" + date;
                 if (hours > 9)
                     curDateTime = curDateTime + " " + hours;
                 else
                     curDateTime = curDateTime + " 0" + hours;
                 if (minutes > 9)
                     curDateTime = curDateTime + ":" + minutes;
                 else
                     curDateTime = curDateTime + ":0" + minutes;
                 if (seconds > 9)
                     curDateTime = curDateTime + ":" + seconds;
                 else
                     curDateTime = curDateTime + ":0" + seconds;
                 return curDateTime;
             }
             function SetDate(dt1, dt2, dt3) {
                 var startDate = "PageBody_" + dt1;
                 var endDate = "PageBody_" + dt2;
                 var selectDate = "PageBody_" + dt3;
                 var val = document.getElementById(selectDate).value;
                 switch (val) {
                     case "1":
                         document.getElementById(startDate).value = curDateTime("X", 0);
                         document.getElementById(endDate).value = curDateTime("D", 3);
                         break;
                     case "2":
                         document.getElementById(startDate).value = curDateTime("X", 0);
                         document.getElementById(endDate).value = curDateTime("D", 7);
                         break;
                     case "3":
                         document.getElementById(startDate).value = curDateTime("X", 0);
                         document.getElementById(endDate).value = curDateTime("M", 1);
                         break;
                     case "4":
                         document.getElementById(startDate).value = curDateTime("X", 0);
                         document.getElementById(endDate).value = curDateTime("Y", 3);
                         break;
                     case "5":
                         document.getElementById(startDate).value = "";
                         document.getElementById(endDate).value = "";
                         break;
                 }
             }
            
        </script>
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
        <tr><td class="table_body">用户ID</td><td class="table_none"><asp:Label ID="vcUserID_Disp" runat="server"></asp:Label></td></tr>
       <!--  禁止登录  -->
      <tr>
        <td class="table_body">禁止登录</td>
        <td class="table_none"><asp:DropDownList ID="ddlDisRemit" runat="server"><asp:ListItem Value="0" Selected="True">否</asp:ListItem><asp:ListItem Value="1">是</asp:ListItem></asp:DropDownList> 备注： <asp:TextBox ID="tbDisRemitReason" runat="server" title="在此输入禁止打款的原因" Width="462px"></asp:TextBox></td>
      </tr>
      <tr>
            <td class="table_body">时间范围</td>
            <td class="table_none"><asp:TextBox ID="S_DisRemit_dtDate_Input" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                            onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入开始时间~:datetime"></asp:TextBox>~<asp:TextBox
                                ID="E_DisRemit_dtDate_Input" runat="server" class="Wdate" Columns="10" onclick="WdatePicker()"
                                onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Style="width: 150px" title="请输入结束时间~:datetime"></asp:TextBox>
                                快速设置：
                                <asp:DropDownList ID="ddlDisRemitSelectDate" runat="server" onchange="SetDate('S_DisRemit_dtDate_Input','E_DisRemit_dtDate_Input','ddlDisRemitSelectDate')">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">3天</asp:ListItem>
                                    <asp:ListItem Value="2">7天</asp:ListItem>
                                    <asp:ListItem Value="3">1月</asp:ListItem>
                                    <asp:ListItem Value="4">3年</asp:ListItem>
                                    <asp:ListItem Value="5">清空</asp:ListItem>
                                </asp:DropDownList> </td>
      </tr>
      <!--  禁止登录  -->
      <tr><td class="table_body">禁止下注</td><td class="table_none"><asp:DropDownList ID="ddlPubDis" runat="server"><asp:ListItem Value="0" Selected>否</asp:ListItem><asp:ListItem Value="1">是</asp:ListItem></asp:DropDownList> 备注： <asp:TextBox ID="txtPubDisReason" runat="server" title="在此输入禁止打款的原因" Width="462px"></asp:TextBox></td></tr><tr><td class="table_body">时间范围</td><td class="table_none"><asp:TextBox ID="S_PubDis_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px"  Columns="10" runat="server"></asp:TextBox>~<asp:TextBox ID="E_PubDis_dtDate_Input" title="请输入结束时间~:datetime" class="Wdate" onclick="WdatePicker()"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" Columns="10" runat="server"></asp:TextBox>
                                快速设置：
                                <asp:DropDownList ID="ddlPubDisSelectDate" runat="server" onchange="SetDate('S_PubDis_dtDate_Input','E_PubDis_dtDate_Input','ddlPubDisSelectDate')">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">3天</asp:ListItem>
                                    <asp:ListItem Value="2">7天</asp:ListItem>
                                    <asp:ListItem Value="3">1月</asp:ListItem>
                                    <asp:ListItem Value="4">3年</asp:ListItem>
                                    <asp:ListItem Value="5">清空</asp:ListItem>
                                </asp:DropDownList> 
                                
                                </td></tr>
                                <tr><td class="table_body">限定赢的次数</td><td class="table_none">
                                <%--项目：<asp:ListBox runat="server" ID="ddlActivity"  style=" width:200px;height:200px" ></asp:ListBox>
                                次数：<asp:TextBox ID="txtNum" runat="server" Width="100px"></asp:TextBox>--%>
                                <table id="Table1"  border="0" class="table1" runat="server"></table>
                                
                                
                                </td></tr>
                                
                                <tr><td class="table_body">限定报名金额</td><td class="table_none">
                              
                               <table id="Table2"  border="0" class="table1" runat="server"></table>
                                </td></tr>
                                
                                <tr><td class="table_body">禁止兑换</td><td class="table_none">
                                 <asp:DropDownList ID="ddlExchange" runat="server"><asp:ListItem Value="0" Selected>否</asp:ListItem><asp:ListItem Value="1">是</asp:ListItem></asp:DropDownList>
                                  备注： <asp:TextBox ID="txtExchange" runat="server" title="在此输入禁止打款的原因" Width="462px"></asp:TextBox>
                                
                                </td></tr>
                                <tr><td class="table_body">时间范围</td><td class="table_none"><asp:TextBox ID="S_Exchange_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px"  Columns="10" runat="server"></asp:TextBox>~<asp:TextBox ID="E_Exchange_dtDate_Input" title="请输入结束时间~:datetime" class="Wdate" onclick="WdatePicker()"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" Columns="10" runat="server"></asp:TextBox>
                                快速设置： <asp:DropDownList ID="ddlExchangeSelectDate" runat="server" onchange="SetDate('S_Exchange_dtDate_Input','E_Exchange_dtDate_Input','ddlExchangeSelectDate')">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">3天</asp:ListItem>
                                    <asp:ListItem Value="2">7天</asp:ListItem>
                                    <asp:ListItem Value="3">1月</asp:ListItem>
                                    <asp:ListItem Value="4">3年</asp:ListItem>
                                    <asp:ListItem Value="5">清空</asp:ListItem>
                                </asp:DropDownList> 
                                
                                </td></tr>

                                 <tr><td class="table_body">禁止赠送</td><td class="table_none">
                                 <asp:DropDownList ID="ddlGive" runat="server"><asp:ListItem Value="0" Selected>否</asp:ListItem><asp:ListItem Value="1">是</asp:ListItem></asp:DropDownList>
                                  备注： <asp:TextBox ID="txtGive" runat="server" title="在此输入禁止打款的原因" Width="462px"></asp:TextBox>
                                
                                </td></tr>
                                <tr><td class="table_body">时间范围</td><td class="table_none"><asp:TextBox ID="S_Give_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px"  Columns="10" runat="server"></asp:TextBox>~<asp:TextBox ID="E_Give_dtDate_Input" title="请输入结束时间~:datetime" class="Wdate" onclick="WdatePicker()"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" Columns="10" runat="server"></asp:TextBox>
                                快速设置： <asp:DropDownList ID="ddlGiveSelectDate" runat="server" onchange="SetDate('S_Give_dtDate_Input','E_Give_dtDate_Input','ddlGiveSelectDate')">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">3天</asp:ListItem>
                                    <asp:ListItem Value="2">7天</asp:ListItem>
                                    <asp:ListItem Value="3">1月</asp:ListItem>
                                    <asp:ListItem Value="4">3年</asp:ListItem>
                                    <asp:ListItem Value="5">清空</asp:ListItem>
                                </asp:DropDownList> 
                                
                                </td></tr>

                                <tr><td class="table_body">禁止获赠</td><td class="table_none">
                                 <asp:DropDownList ID="ddlAccept" runat="server"><asp:ListItem Value="0" Selected>否</asp:ListItem><asp:ListItem Value="1">是</asp:ListItem></asp:DropDownList>
                                  备注： <asp:TextBox ID="txtAccept" runat="server" title="在此输入禁止打款的原因" Width="462px"></asp:TextBox>
                                
                                </td></tr>
                                <tr><td class="table_body">时间范围</td><td class="table_none"><asp:TextBox ID="S_Accept_dtDate_Input" title="请输入开始时间~:datetime" class="Wdate" onclick="WdatePicker()" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px"  Columns="10" runat="server"></asp:TextBox>~<asp:TextBox ID="E_Accept_dtDate_Input" title="请输入结束时间~:datetime" class="Wdate" onclick="WdatePicker()"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" style="width:150px" Columns="10" runat="server"></asp:TextBox>
                                快速设置： <asp:DropDownList ID="ddlAcceptSelectDate" runat="server" onchange="SetDate('S_Accept_dtDate_Input','E_Accept_dtDate_Input','ddlAcceptSelectDate')">
                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">3天</asp:ListItem>
                                    <asp:ListItem Value="2">7天</asp:ListItem>
                                    <asp:ListItem Value="3">1月</asp:ListItem>
                                    <asp:ListItem Value="4">3年</asp:ListItem>
                                    <asp:ListItem Value="5">清空</asp:ListItem>
                                </asp:DropDownList> 
                                
                                </td></tr>
                                
                                
                                <tr><td class="table_body">最近操作客服</td><td class="table_none"><asp:Label
                ID="lblLastOpID" runat="server" Text=""></asp:Label></td></tr><tr><td class="table_body">用户备注</td>
                <td class="table_none">
                    <asp:TextBox ID="txtUserComment1" TextMode="MultiLine" Height="150px" runat="server" Width="502px" ></asp:TextBox>
                   
                </td>
                </tr>
                <tr><td colspan="2" align="right" style="height: 26px"><asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="保存" OnClick="Button1_Click"/></td></tr></table></FrameWorkWebControls:TabOptionItem>


        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="自动权限锁定时间区间" >
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
             <tr>
                 <td class="table_body">时间段限制</td>
                 <td class="table_none">
                        <table id="Table3"  border="0" class="table1" runat="server"></table>   
                 </td>
             </tr>           
            <tr><td colspan="2" align="right" style="height: 26px">
            <asp:Button ID="Button4" runat="server" CssClass="button_bak" Text="删除" OnClick="Button4_Click"/>&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="增加" OnClick="Button2_Click"/>&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="保存" OnClick="Button3_Click"/></td></tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>


    <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="自动权限锁定" >
            <asp:GridView ID="GridView1" runat="server" >
            <Columns>
            <asp:TemplateField HeaderText="序号"> 
                            <ItemTemplate>
                            <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Wrap="True" />  
                            <HeaderStyle Wrap="False" />    
                        </asp:TemplateField>
            <asp:BoundField HeaderText="项目名" DataField="name" />
            <asp:BoundField HeaderText="开始时间" DataField="StartDate" />
            <asp:BoundField HeaderText="结束时间" DataField="EndDate" />
           

            <asp:BoundField HeaderText="限定字数" DataField="Nums" />
            <asp:BoundField HeaderText="限定金额" DataField="Moneys" />
            
             <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
            <%--<asp:TemplateField HeaderText="操作" ShowHeader="False">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandArgument='<%# Eval("SerialNo") %>' CommandName="OrderDetail"
                                    Text="订单详情"></asp:LinkButton>
              </ItemTemplate>
            </asp:TemplateField>--%>
            </Columns>
      </asp:GridView>
      <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged"></FrameWorkWebControls:AspNetPager>
    </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
