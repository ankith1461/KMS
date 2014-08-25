<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorView.aspx.cs" Inherits="KMS.Author" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>

   
  <link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"/>
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
  <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style5
        {
            width: 596px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
    
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblPendingArticles" runat="server" Text="Pending Articles" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
    
        <asp:GridView ID="gvPendingArticleAuthor" runat="server" AutoGenerateColumns="false" align="center"
                        OnRowCommand="gv_OnRowCommand" style="margin-left: 0px" CellPadding="6" 
                        ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="10" 
                        OnPageIndexChanging="gv_PendingArticle_Paging" AllowSorting="true" 
                        OnSorting="gvPendingArticleAuthor_OnSorting" CellSpacing="6">
        <%--<asp:GridView ID="gvPendingArticleAuthor" runat="server" AutoGenerateColumns="False" >--%>
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        
        <Columns>
        <asp:BoundField DataField = "ArtId" HeaderText="ArtId" Visible="false"  />
        <asp:TemplateField HeaderText ="Title" SortExpression="Title">
        <ItemTemplate>
        
        <asp:Label ID="lblArtileTitle"  Text='<%# Eval("Title").ToString().Length > 20 ? Eval("Title").ToString().Substring(0,20) :Eval("Title") %>' runat="server" >
        </asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField DataField = "Title" HeaderText="Title" ReadOnly="true" SortExpression="Title"/>--%>
        <asp:BoundField DataField = "ArtType" HeaderText = "Article Type" ReadOnly="true" SortExpression="ArtType" />
        <asp:BoundField DataField = "AppName" HeaderText = "Application" ReadOnly="true" SortExpression="AppName"/>
        <%--<asp:BoundField DataField = "DateOfRegistration" HeaderText = "Uploaded Date" ReadOnly="true" />--%>
        <asp:TemplateField HeaderText ="Uploaded Date">
        <ItemTemplate>
        
        <asp:Label ID="lblUploadedDate"  Text='<%#Eval("DateOfRegistration") == " " ? "Empty" : Eval("DateOfRegistration").ToString().Substring(0,9)%> ' runat="server" >
        </asp:Label>
        </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:BoundField DataField = "DateOfRegistration" HeaderText = "Date Of Registration" ReadOnly="true" />--%>
        <asp:TemplateField>
        <ItemTemplate>
        
        <asp:ImageButton ID="lnkKBpendingArticleAuthorShow" Text="Show" CommandName='<%#Eval("ArtType") %>' CommandArgument='<%#Eval("ArtId") %>' runat="server" ImageUrl="~/images/show.png" CssClass="icon"/>
        
        
        </ItemTemplate>
        
        
        </asp:TemplateField>
        
        </Columns>


            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />


        </asp:GridView>
    
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblPendingTags" runat="server" Text="Pending Tags" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblPendingCollections" runat="server" Text="Pending Collections" 
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:GridView ID="gvPendingTag" runat="server" AutoGenerateColumns="False" align="center"
                        OnRowCommand="Accept_Reject_Tag" CellPadding="6" ForeColor="#333333" 
                        GridLines="None" AllowPaging="true" 
                        OnPageIndexChanging="gvPendingTag_OnPageIndexChanging" PageSize="10"
                        OnSorting ="gvPendingTag_OnSorting" AllowSorting="true" CellSpacing="6" 
                        Width="361px">
                    
                    
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    
                    
                    <Columns>
                    <asp:BoundField DataField="Tid" Visible="false"/>
                    <asp:BoundField DataField="Tname" HeaderText ="Tag"  SortExpression="Tname"/>
                    <asp:BoundField DataField="ColId" Visible="false" />
                    <asp:BoundField DataField="ColName" HeaderText ="Collection" SortExpression="ColName"/>
                    <asp:BoundField DataField="CognizantId" HeaderText="Cognizant Id" SortExpression="CognizantId"/>
                    
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:ImageButton  ID="lnkBtnAccept" Text ="Accept" runat="server" CommandName ="accept" CommandArgument='<%# Eval("Tid") %>'  ImageUrl="~/images/update.png" CssClass="icon"  ToolTip="Accept"/>
                   
                    <asp:ImageButton ID="lnkBtnReject" Text ="Reject" runat="server" CommandName ="reject" CommandArgument='<%# Eval("Tid") %>'  ImageUrl="~/images/cancel.png" CssClass="icon"  ToolTip="Reject"/>
                   
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    </Columns>
                    
                    
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    
                    
                    </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="gvPendingCollection" runat="server" align="center"
                        AutoGenerateColumns="False" OnRowCommand="Accept_Reject_Collection" 
                        CellPadding="6" ForeColor="#333333" GridLines="None" AllowPaging="true" 
                        OnPageIndexChanging="gvPendingCollection_OnPageIndexChanging" PageSize="10"
                        AllowSorting="true" OnSorting="gvPendingCollection_OnSorting" 
                        CellSpacing="6" Width="379px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                    <asp:BoundField DataField="ColId" Visible="false" />
                    <asp:BoundField DataField="ColName" HeaderText ="Collection" SortExpression="ColName" />
                    <asp:BoundField DataField="CognizantId" HeaderText="Cognizant Id"  SortExpression="CognizantId"/>
                    
                    
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:ImageButton  ID="lnkBtnAccept" Text ="Accept" runat="server" CommandName ="accept" CommandArgument='<%# Eval("ColId") %>'  ImageUrl="~/images/update.png" CssClass="icon" ToolTip="Accept"/>
                    
                    <asp:ImageButton ID="lnkBtnReject" Text ="Reject" runat="server" CommandName ="reject" CommandArgument='<%# Eval("ColId") %>'  ImageUrl="~/images/cancel.png" CssClass="icon"  ToolTip="Reject"/>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    </Columns>

                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                    </asp:GridView>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
</asp:Content>
