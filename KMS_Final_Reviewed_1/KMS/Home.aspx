<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="KMS._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>


</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<!-- By vamsee--------------------------->
    <div ID="panel">
     <h3 style="font-size: large; font-weight: bold">Recently Published Articles</h3>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="ArticlesSource">
        <Columns>
           <asp:TemplateField HeaderText ="Title">
        <ItemTemplate>
        
        <asp:Label ID="lblAccessDate"  Text='<%#Eval("Title") == " " ? "Empty" : Eval("Title").ToString().Length < 20? Eval("Title").ToString():Eval("Title").ToString().Substring(0,20)%>' runat="server" >
        </asp:Label>
		
        </ItemTemplate>
        </asp:TemplateField>
              <asp:BoundField DataField="PublishedBy" HeaderText="User"
                SortExpression="PublishedBy" />
            <asp:BoundField DataField="LastAccessDate" HeaderText="Date Uploaded" SortExpression="LastAccessDate" ItemStyle-Width="20%"/> 
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="ArticlesSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DB_KMS_DevelopmentConnectionString %>" 
        SelectCommand="SELECT  * FROM LatestArticles">
    </asp:SqlDataSource>
    </div>
    <h2>
        Welcome to Knowledge Management system</h2>
        <div class="leftCol">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Book_Happy.png" Width="180px" Height="200px"/>
        </div>

        <div class="rightColumn">
        
    <p class="para">
        KM System is an Experience Management System meant to provide support groups with a means to manage, 
        capture, process and retrieve the knowledge that is relevant to their work.
        
   </p>

    </div>
    
    
</asp:Content>
