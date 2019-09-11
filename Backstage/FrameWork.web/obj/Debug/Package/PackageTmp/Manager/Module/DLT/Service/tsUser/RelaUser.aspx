<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="RelaUser.aspx.cs" Inherits="DLT.Web.Module.DLT.tsUser.RelaUser"
    Title="关联用户" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="关联用户列表" HeadTitleTxt="用户">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
         <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="总览">
            <asp:GridView ID="GridView6" runat="server" 
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager6" runat="server" 
                onpagechanged="AspNetPager6_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
        </FrameWorkWebControls:TabOptionItem>
    
    
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="根据MAC">
            <asp:GridView ID="GridView1" runat="server" 
                onrowdatabound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" 
                onpagechanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:HiddenField ID="hidID" runat="server" />
            <asp:HiddenField ID="hidUID" runat="server" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="根据QQ">
            <asp:GridView ID="GridView2" runat="server" 
                onrowdatabound="GridView2_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager2.CurrentPageIndex - 1) * this.AspNetPager2.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager2" runat="server" 
                onpagechanged="AspNetPager2_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="根据电话">
            <asp:GridView ID="GridView3" runat="server" 
                onrowdatabound="GridView3_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager3.CurrentPageIndex - 1) * this.AspNetPager3.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager3" runat="server" 
                onpagechanged="AspNetPager3_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem4" runat="server" Tab_Name="根据提现账号">
            <asp:GridView ID="GridView4" runat="server" 
                onrowdatabound="GridView4_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager4.CurrentPageIndex - 1) * this.AspNetPager4.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager4" runat="server" 
                onpagechanged="AspNetPager4_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem5" runat="server" Tab_Name="根据登录IP">
            <asp:GridView ID="GridView5" runat="server" 
                onrowdatabound="GridView5_RowDataBound" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager5.CurrentPageIndex - 1) * this.AspNetPager5.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="用户ID">
                        <ItemTemplate>
                            <asp:Label ID="lblUID" runat="server" Text='<%#Eval("UID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="登录ID" DataField="LoginID" />
                    <asp:BoundField HeaderText="联系QQ" DataField="QQ" />
                    <asp:BoundField HeaderText="联系电话" DataField="Mobile" />
                    <asp:BoundField HeaderText="绑定手机" DataField="BindMobile" />
                    <asp:TemplateField HeaderText="用户类型">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#IsGoodUser((Eval("ID").ToString()))%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:BoundField HeaderText="创建时间" DataField="CreateDate" />
                    <asp:BoundField HeaderText="发单" DataField="PostCount" />
                    <asp:BoundField HeaderText="接单" DataField="RecCount" />
                    <asp:TemplateField HeaderText="总资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("SumBal").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="冻结资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreezeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="可操作资金">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("FreeBal").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="提现中">
                        <ItemTemplate>
                            <%#SaveTwoDec((Eval("withdraw").ToString()))%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="员工" DataField="member" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#XQStatus((Eval("ID").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlLogin/Default.aspx?ID={0}")%>' CausesValidation="false" Text="登录日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl='<%# Eval("ID","../../Log/tlOperate/Default.aspx?ID={0}")%>' CausesValidation="false" Text="操作日志">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","../tsRightLock/Manager.aspx?ID={0}")%>' Text="权限设置">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="false" PostBackUrl='<%# Eval("ID","SetUserInfo.aspx?ID={0}")%>' Text="手密修改">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager5" runat="server" 
                onpagechanged="AspNetPager5_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
