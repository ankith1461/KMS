<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListArticles.aspx.cs" Inherits="KMS.ListArticles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>


      <asp:Panel ID="pnlSearch" runat="server" Height="597px"  
            style="margin-top: 0px" DefaultButton="btnSearch">

      <h2 align="center">
       <asp:Label ID="lblSearch" runat="server" Text="
        KMS SEARCH
       " align="Center" Font-Bold="True"></asp:Label>
       </h2>
       <br />
          <br />
       <h2 align="center">   
           <asp:TextBox ID="txtSearch" runat="server" Height="24px" 
               Width="160px"  ></asp:TextBox>

           <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters="*+- /" 
           Enabled="True" ServicePath="~/WebServ1.asmx" 
                                        TargetControlID="txtSearch" 
                                        ShowOnlyCurrentWordInCompletionListItem="true"
                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" 
                                        CompletionInterval="100" ServiceMethod="autocomplete">
           </asp:AutoCompleteExtender>

           
        
       <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" 
               Height="24px" Width="70px" CssClass="btn-primary" />
       </h2>
          <h2 align="center">
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                  ControlToValidate="txtSearch" ErrorMessage="Invalid Characters!" 
                  ForeColor="Red" ValidationExpression="([a-z]|[A-Z]|[0-9]|[ ]|[-]|[_][#])*" 
                  ValidationGroup="val" onload="Page_Load"></asp:RegularExpressionValidator>
          </h2>
          <asp:Label ID="lblNoResult" runat="server" Text="Label" Font-Bold="True" 
              ForeColor="#00CC99" Font-Size="X-Large"></asp:Label>
       <br />
       <br />  

        
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
         
        <asp:GridView ID="gvResult" runat="server" AutoGenerateColumns="False" 
            align="center" AllowPaging="True"
            AllowSorting="True" OnPageIndexChanging="gvResult_PageIndexChanging" 
             Height="254px" Width="666px" CellPadding="4" 
            ForeColor="#333333" GridLines="None" PageSize="3" 
            onsorting="gvResults_Sorting">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
  <Columns>

    <asp:BoundField DataField="article_id" SortExpression="article_id" HeaderText="Article ID"/>
   <asp:BoundField DataField="arttitle" SortExpression="arttitle" HeaderText="Article"/>
    
    <%--<asp:hyperlinkfield  DataTextField="arttitle"
     HeaderText="Title" SortExpression="article_title" 
     datanavigateurlfields="article_id"  datanavigateurlformatstring="/ViewSearch.aspx?ArtId={0} ">
    </asp:hyperlinkfield>--%>
    
    <asp:BoundField DataField="arttype" SortExpression="arttype" HeaderText="Category"/>
    <asp:BoundField DataField="appname" SortExpression="appname" HeaderText="Application"/>
    <asp:BoundField DataField="colname" SortExpression="colname" HeaderText="Collection" />
    <asp:BoundField DataField="CognizantId" SortExpression="CognizantId" HeaderText="Created By" />  
 </Columns>
        <EditRowStyle BackColor="#999999"/>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"/>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"/>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"/>
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"/>
        <SortedAscendingCellStyle BackColor="#E9E7E2"/>
        <SortedAscendingHeaderStyle BackColor="#506C8C"/>
        <SortedDescendingCellStyle BackColor="#FFFDF8"/>
        <SortedDescendingHeaderStyle BackColor="#6F8DAE"/>
   </asp:GridView>
    </ContentTemplate>
   </asp:UpdatePanel>     
 
   <br />
    <br />
          <asp:Panel ID="pnlPageNo" runat="server">
          <div id="PageNo"   style="color: Green; font-weight: bold">
            <br />
            <i>You are viewing page
                <%=gvResult.PageIndex + 1%>
                of
                <%=gvResult.PageCount%>
            </i>
        </div> 
      </asp:Panel>
     </asp:Panel>
  
</asp:Content>
