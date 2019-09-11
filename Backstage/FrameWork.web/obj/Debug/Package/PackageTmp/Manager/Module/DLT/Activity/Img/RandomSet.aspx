<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="RandomSet.aspx.cs" Inherits="DLT.Web.Module.DLT.Activity.Img.RandomSet"
    Title="随机数设置" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="随机数设置" HeadTitleTxt="随机数">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
         <FrameWorkWebControls:TabOptionItem ID="TabOptionItem6" runat="server" Tab_Name="随机数列表">
              
             <table style="width:100%;">
                 <tr>
                     <td style="float:right;"><asp:LinkButton ID="LinkButton1" runat="server" CssClass="button_bak" style="text-decoration: none;text-align: center;line-height: 20px;display: block;">新增</asp:LinkButton></td>
                 </tr>
             </table>

              <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="随机数编号"> 
                        <ItemTemplate>
                             <a href="Manager2.aspx?IDX=<%#Eval("ID")%>&CMD=List&FieldsID=<%#Eval("FieldsID") %>"><%#Eval("ID")%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="随机值" DataField="Value" />
                    <asp:BoundField HeaderText="X坐标" DataField="X" />
                    <asp:BoundField HeaderText="Y坐标" DataField="Y" />
                    <asp:BoundField HeaderText="关联ID" DataField="RelaID" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
