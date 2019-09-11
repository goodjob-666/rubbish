<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Parameter.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.Parameter"
    Title="参数设置" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="参数设置" HeadTitleTxt="参数">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
         <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="参数列表">
              
             <table style="width:100%;">
                 <tr>
                     <td>
                        <asp:Label ID="Label1" runat="server" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" Text="参数个数不能超过12个"></asp:Label><br /><br /></td>
                     <td style="float:right;"><asp:LinkButton ID="LinkButton1" runat="server" CssClass="button_bak" style="text-decoration: none;text-align: center;line-height: 20px;display: block;">新增参数</asp:LinkButton></td>
                 </tr>
             </table>

              <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="参数编号"> 
                        <ItemTemplate>
                        <a href="Manager1.aspx?IDX=<%#Eval("ID")%>&CMD=List&ImgID=<%#Eval("ImgID")%>&Type=<%#Eval("Type") %>"><%#Eval("ID")%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="参数名称" DataField="Title" />
                    <asp:BoundField HeaderText="前缀" DataField="PreValue" />
                    <asp:TemplateField HeaderText="默认值"> 
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="100"  />
                            <asp:Label ID="Label4" runat="server" ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="后缀" DataField="SuffixValue" />
                    <asp:BoundField HeaderText="参数类型" DataField="Type" />
                    <asp:BoundField HeaderText="X坐标" DataField="X" />
                    <asp:BoundField HeaderText="Y坐标" DataField="Y" />
                    <asp:TemplateField HeaderText="是否随机"> 
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    

                     <asp:TemplateField HeaderText="编辑随机数"> 
                        <ItemTemplate>
                           <a href='RandomSet.aspx?ID=<%# Eval("ID") %>' target="_blank" style='display:<%# Eval("IsRandom").ToString()=="0"?"none":"block" %>'>编辑</a>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </FrameWorkWebControls:TabOptionItem>
    
    
       
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
