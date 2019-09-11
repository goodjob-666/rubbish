<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="图片列表" HeadTitleTxt="图片" HeadTitleIcon="default.gif">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="图片" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="图片列表">
            <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="图片">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Substr(Eval("ImageUrl").ToString()) %>' Width="100"  />
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:BoundField HeaderText="图片名称" DataField="ImageName" />
                    <asp:TemplateField HeaderText="相册">
                        <ItemTemplate>
                            <asp:Label ID="lblAlbumID" runat="server" Text='<%#Eval("AlbumID")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="图片分类">
                        <ItemTemplate>
                            <asp:Label ID="lblImageType" runat="server" Text='<%#Eval("ImageType")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="是否最热">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("IsHot").ToString()=="1"?"../../../../images/right.gif":"../../../../images/wrong.gif" %>'   />
                        </ItemTemplate>
                    </asp:TemplateField> 
                    
                   <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                             <a href='Design.aspx?BgImageUrl=<%# Eval("BgImageUrl") %>&ID=<%# Eval("ID") %>' target="_blank">设计</a>&nbsp;&nbsp;

                             <a href='Parameter.aspx?ID=<%# Eval("ID") %>' target="_blank">设置参数</a>&nbsp;&nbsp;

                             <a href='Preview.aspx?ID=<%# Eval("ID") %>' target="_blank">预览</a>
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
                        图片名称</td>
                    <td class="table_none">
                        <asp:TextBox ID="txtKind" title="请输入图片名称~" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        图片分类</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlAlbum" runat="server">
                            <asp:ListItem Value="">所有</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                 <tr>
                    <td class="table_body">
                        图片类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ddlImageType" runat="server">
                            <asp:ListItem Text="普通图片" Value="0"></asp:ListItem>
                            <asp:ListItem Text="GIF图片" Value="1"></asp:ListItem>
                            <asp:ListItem Text="字体" Value="2"></asp:ListItem>
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
