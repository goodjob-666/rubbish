<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Questions.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="投稿列表" HeadTitleTxt="投稿" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="投稿" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="投稿列表">
            <asp:GridView ID="GridView1" runat="server"  OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                       <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>

                     <asp:BoundField HeaderText="图片编号" DataField="ImgID" />

                     <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("ImageUrl")%>' Width="100" />
                        </ItemTemplate>
                     </asp:TemplateField> 

                     <asp:TemplateField HeaderText="用户昵称">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField> 

                     <asp:BoundField HeaderText="Ip地址" DataField="Ip" />
                   
                     <asp:BoundField HeaderText="投稿时间"  DataField="CreateDate" ><ItemStyle Width="200px" /> </asp:BoundField> 
                   
                     <asp:TemplateField HeaderText="查看大图">
                        <ItemTemplate>
                             <a href='ShowImg.aspx?ImageUrl=<%# Eval("ImageUrl") %>' target="_blank">查看大图</a>
                        </ItemTemplate>
                     </asp:TemplateField> 
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
       
    </FrameWorkWebControls:TabOptionWebControls>


</asp:Content>
