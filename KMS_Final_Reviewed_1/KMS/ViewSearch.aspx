<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSearch.aspx.cs" Inherits="KMS.ViewSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <style type="text/css">
        .style4
        {
            width: 355px;
        }
        .style9
        {
            width: 163px;
            height: 45px;
        }
        .style10
        {
            width: 355px;
            height: 45px;
        }
        .style16
        {
            width: 163px;
            height: 78px;
        }
        .style17
        {
            width: 355px;
            height: 78px;
        }
        .style18
        {
        }
        .style19
        {
            width: 287px;
            height: 78px;
        }
        .style22
        {
            width: 287px;
            height: 45px;
        }
        .style23
        {
            width: 287px;
        }
        .style24
        {
            height: 129px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="pnlView" runat="server" Height="875px">
        <h2 align="center">
            <asp:Label ID="lblHead" runat="server" Text="Label"></asp:Label></h2>
            <br />
            <br />


            <table style="height: 455px; width: 942px" cellpadding="7" cellspacing="7" >
                <tr>
                    <td class="style16">
                        <asp:Label ID="lblArtId" runat="server" Text="Article ID"  Font-Bold="true"></asp:Label>
                        <br />
                       
                        <asp:Label ID="lblViewId" runat="server" Font-Size="Large" Text="Label"></asp:Label>
                       </td>
                    <td class="style19">
                       
                        <asp:Label ID="lblArtName0" runat="server" Font-Bold="true" Text="Article"></asp:Label>
                        <br />
                       
                        <asp:Label ID="lblViewArtName" runat="server" Font-Size="Large" Text="Label"></asp:Label>
                        </td>
                    <td class="style17">
                       
                        <asp:Label ID="lblTags" runat="server" Font-Bold="True" Text="Tags"></asp:Label>
                        <br />
                        <asp:Panel ID="pnlTag" runat="server" Height="36px" Width="249px">
                        </asp:Panel>
                    </td>
                </tr>
                <asp:Panel ID="pnlDetail" runat="server">
                
                <tr>
                    <td class="style24" colspan="3">
                       
                        <asp:Label ID="lblDetail" runat="server" Font-Bold="true" Text="Details"></asp:Label>
                        <br />
                        <asp:Label ID="lblDisplayDetail" runat="server" BackColor="#E1F0F5" 
                            BorderColor="LightBlue" BorderWidth="1" Text="Label"></asp:Label>
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="pnlProblemSolution" runat="server">
              
                <tr>
                    <td class="style18" colspan="3">
                       
                        <asp:Label ID="lblArtProblem" runat="server" Font-Bold="true" 
                            Text="Problem Statment"></asp:Label>
                        <br />
                        <asp:Label ID="lblDisplayProblem" runat="server" BackColor="#E1F0F5" 
                            BorderColor="LightBlue" BorderWidth="1" Text="Label"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style18" colspan="3">
                       
                        <br />
                       
                        <asp:Label ID="lblSolution" runat="server" Font-Bold="true" Text="Solution"></asp:Label>
                        <br />
                        <asp:Label ID="lblDisplaySolution" runat="server" Text="Label"
                         BorderColor="LightBlue" BorderWidth="1" BackColor="#E1F0F5"></asp:Label>
                    </td>
                </tr>
                  </asp:Panel>
                <tr>
                    <td class="style18" colspan="3">
                        <asp:Label ID="lblAttachments" runat="server" Font-Bold="true" 
                            Text="Attachments"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListView ID="ListView3" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload1" runat="server" 
                                    CommandArgument='<%# Eval("DocId") %>' OnCommand="DownloadFile" 
                                    Text='<%# Eval("DocName") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
                <tr>
                    <td class="style9">
                        
                        &nbsp;</td>
                    <td class="style22">
                        <br />
                        <asp:Button ID="btnSearchAgain" runat="server" Text="Search Again" 
                            onclick="btnSearchAgain_Click" />
                    </td>
                    <td class="style10">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style18">
                        &nbsp;</td>
                    <td class="style23">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                </tr>
            </table>


        </asp:Panel>
</asp:Content>
