<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Album.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="相册列表" HeadTitleTxt="相册" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="相册" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="相册列表">
            <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="封面">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Substr(Eval("AlbumUrl").ToString()) %>' Width="100"  />
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:BoundField HeaderText="相册名称" DataField="AlbumName" />
                    <asp:TemplateField HeaderText="相册分类">
                        <ItemTemplate>
                            <asp:Label ID="lblAlbumType" runat="server" Text='<%#Eval("AlbumType")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                   
                    <asp:TemplateField HeaderText="是否最热">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("IsHot").ToString()=="1"?"../../../../images/right.gif":"../../../../images/wrong.gif" %>'   />
                        </ItemTemplate>
                    </asp:TemplateField> 
                  
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
           
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        相册名称</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtKind" title="请输入相册名称~" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        相册分类</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlAlbumType" runat="server">
                            <asp:ListItem Value="">所有</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否最热</td>
                    <td class="table_none">
                        <asp:CheckBox ID="chkIsHot" runat="server" />
                    </td>
                </tr>

                 <tr>
                    <td class="table_body">
                        是否最新</td>
                    <td class="table_none">
                        <asp:CheckBox ID="chkIsNew" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td class="table_body">
                        是否可用</td>
                    <td class="table_none">
                         <asp:CheckBox ID="chkIsEnable" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>


</asp:Content>
