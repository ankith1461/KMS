<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="KMS.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
       

<script type="text/javascript">
    //this code is used for loading the tabs as well as to retain the state after the page refresh .
    $(document).ready(function () {
        var currentTabIndex = "0";

        $tab = $("#tabs").tabs({
            activate: function (e, ui) {
                currentTabIndex = ui.newTab.index().toString();
                sessionStorage.setItem('tab-index', currentTabIndex);
            }
        });

        if (sessionStorage.getItem('tab-index') != null) {
            currentTabIndex = sessionStorage.getItem('tab-index');
            // console.log(currentTabIndex);
            $tab.tabs('option', 'active', currentTabIndex);
        }

    });
    
  </script>

  
  <link type="text/css" rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css"/>
  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div id="tabs">
<ul>
    <li><a href="#tabs-1">Users</a></li>
    <li><a href="#tabs-2">Applications</a></li>
    <li><a href="#tabs-3">Articles</a></li>
    <li><a href="#tabs-4">Collections</a></li>
    <li><a href="#tabs-5">Tags</a></li>
  </ul>
        

  <div id="tabs-1"><!-- -----------------code by avinash------------------------>

    <asp:Label ID="LblPagesizeUsers" runat="server" Text="Records per page"></asp:Label>


      <asp:DropDownList ID="DllPageSizeUsers" runat="server" AutoPostBack="True" 
          onselectedindexchanged="DllPageSizeUsers_SelectedIndexChanged">
      <asp:ListItem>10</asp:ListItem>
      <asp:ListItem>20</asp:ListItem>
      <asp:ListItem>30</asp:ListItem>
      <asp:ListItem>40</asp:ListItem>
      <asp:ListItem>50</asp:ListItem>      
      </asp:DropDownList>

   <asp:GridView ID="ManageUsersView" runat="server" Width="500px" CellPadding="6"
             AutoGenerateColumns="False" onRowCancelingEdit="ManageUsersView_RowCancelingEdit"
                     OnRowEditing="ManageUsersView_RowEditing" OnRowUpdating="ManageUsersView_RowUpdating" 
                     onrowdeleting="ManageUsersView_RowDeleting" 
                    DataKeyNames="CognizantId" ForeColor="#333333" GridLines="None" align = "center"
        ShowFooter="True" AllowPaging="True" CellSpacing="6"
        onpageindexchanging="ManageUsersView_PageIndexChanging" PageSize="10" AllowSorting="true">
                    

                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
        
        <asp:TemplateField HeaderText="Username">
            <ItemTemplate>
              <asp:Label runat="server" ID="ID" Text='<%#Eval("CognizantId") %>' />
            </ItemTemplate>                                              
         </asp:TemplateField>        

         <asp:TemplateField HeaderText="Role">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblAccess" Text='<%#Eval("Access") %>' />
            </ItemTemplate>
 
            <EditItemTemplate>
            <asp:DropDownList ID="ddlAccess" runat="server" Text='<%#Eval("Access") %>'>
             <asp:ListItem>Select a role</asp:ListItem>
             <asp:ListItem>Admin</asp:ListItem>
             <asp:ListItem>User</asp:ListItem>
             <asp:ListItem>Author</asp:ListItem>
             </asp:DropDownList>            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccess"
             runat="server"  Text="*" ForeColor="Red" ValidationGroup="EDIT" ControlToValidate="ddlAccess" InitialValue="Select a role"
             ErrorMessage="Enter the role you want to change">
             </asp:RequiredFieldValidator>
            </EditItemTemplate>                                                   
         </asp:TemplateField>              

     <asp:TemplateField>
 
      <ItemTemplate>
       <asp:ImageButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" ImageUrl="~/images/edit.png" CssClass="icon" ToolTip="Edit"/>
      <br />
      <asp:ImageButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are You sure to delete this record')" ImageUrl="~/images/delete.png" CssClass="icon" ToolTip="Delete" />
      </ItemTemplate>
 
      <EditItemTemplate>
      <asp:ImageButton ID="btnUpdate" Text="Update" runat="server" ValidationGroup="EDIT" CommandName="Update"  ImageUrl="~/images/update.png" CssClass="icon" ToolTip="Update"/>
      <asp:ImageButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel"  CausesValidation="false"  ImageUrl="~/images/cancel.png" CssClass="icon" ToolTip="Cancel"/>
      </EditItemTemplate>                                 
      </asp:TemplateField>                        
            
        
      </Columns>
                   <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:ValidationSummary ID="ValidationSummary4"  ValidationGroup = "EDIT" align = "center" runat="server" ForeColor="Red"/>      
  </div>



  <div id="tabs-2"><!-- -----------------code by swathi------------------------>

  <asp:Label ID="LblApps" runat="server" Text="Records per page"></asp:Label>
  
  <asp:DropDownList ID="DllPageSizeApps" runat="server" AutoPostBack="True" 
          onselectedindexchanged="DllPageSizeApps_SelectedIndexChanged">
      <asp:ListItem>10</asp:ListItem>
      <asp:ListItem>20</asp:ListItem>
      <asp:ListItem>30</asp:ListItem>
      <asp:ListItem>40</asp:ListItem>
      <asp:ListItem>50</asp:ListItem>      
      </asp:DropDownList>

    <asp:GridView ID="ApplicationData" runat="server" CellPadding="6" Width="500px"
             AutoGenerateColumns="False" onRowCancelingEdit="ApplicationData_RowCancelingEdit"
                     OnRowEditing="ApplicationData_RowEditing" OnRowUpdating="ApplicationData_RowUpdating" 
                     onrowdeleting="ApplicationData_RowDeleting"   CellSpacing="6"
                    DataKeyNames="ID" ForeColor="#333333" GridLines="None" align = "center"
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="ApplicationData_PageIndexChanging" AllowSorting="true">
                    

                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
        
        <asp:TemplateField HeaderText="ID" Visible="false" >
            <ItemTemplate>
              <asp:Label runat="server" ID="ID" Text='<%#Eval("ID") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>
         <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
              <asp:Label runat="server" ID="AppId" Text='<%#Eval("AppId") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblName" Text='<%#Eval("AppName") %>' />
            </ItemTemplate>
 
            <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtName" Text='<%#Eval("AppName") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorApplicationName"
             runat="server"  Text="*" ForeColor="Red" ValidationGroup="EDIT" ControlToValidate="txtName" ErrorMessage="Enter Application Name">
             </asp:RequiredFieldValidator>
            </EditItemTemplate>                          
            <FooterTemplate>
            <asp:TextBox ID="TxtAppName" runat="server">
             </asp:TextBox>   
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorApplicationName1" ValidationGroup="INSERTAPP"
             runat="server"  Text="*" ForeColor="Red" ControlToValidate="TxtAppName" ErrorMessage="Insert Application Name"> 
             </asp:RequiredFieldValidator>         
            </FooterTemplate>
         </asp:TemplateField>  
      <%-- <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblAppStatus" Text='<%#Eval("Sname") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>--%>              

     <asp:TemplateField>
 
      <ItemTemplate>
       <asp:ImageButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit"  ImageUrl="~/images/edit.png" CssClass="icon" ToolTip="Edit"/>
      <br />
      <asp:ImageButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are You sure to delete this record')"  ImageUrl="~/images/delete.png" CssClass="icon" ToolTip="Delete"/>
      </ItemTemplate>
 
      <EditItemTemplate>
      <asp:ImageButton ID="btnUpdate" Text="Update" runat="server" ValidationGroup="EDITAPP" CommandName="Update" ImageUrl="~/images/update.png" CssClass="icon" ToolTip="Update" />
      <asp:ImageButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel"  CausesValidation="false" ImageUrl="~/images/cancel.png" CssClass="icon" ToolTip="Cancel"/>
      </EditItemTemplate> 
      <FooterTemplate>
                <asp:ImageButton ID="LinkInsert" runat="server" ValidationGroup="INSERTAPP" OnClick="lb_Click" ImageUrl="~/images/add.png" ToolTip="Insert" CssClass="icon"/>

      </FooterTemplate>                      
      </asp:TemplateField>                        
            
        
      </Columns>
                   <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>        

        <asp:ValidationSummary ID="ValidationSummary1"  ValidationGroup = "EDITAPP" runat="server" ForeColor="Red" align="center"/>
        <asp:ValidationSummary ID="ValidationSummary2"  ValidationGroup="INSERTAPP" runat="server"  ForeColor="Red" align="center"/>
  </div>



  <div id="tabs-3"><!-----------------------code by avinash------------------------>

  <asp:Label ID="LblArt" runat="server" Text="Records per page"></asp:Label>

  <asp:DropDownList ID="DllPageSizeArticles" runat="server" AutoPostBack="True" 
          onselectedindexchanged="DllPageSizeArticles_SelectedIndexChanged">
      <asp:ListItem>10</asp:ListItem>
      <asp:ListItem>20</asp:ListItem>
      <asp:ListItem>30</asp:ListItem>
      <asp:ListItem>40</asp:ListItem>
      <asp:ListItem>50</asp:ListItem>      
      </asp:DropDownList>

     <asp:GridView ID="ManageArticleView" runat="server" CellPadding="6" AutoGenerateColumns="False" Width="500px"                  
                     onrowdeleting="ManageArticleView_RowDeleting" 
                    DataKeyNames="ID" ForeColor="#333333" GridLines="None" align = "center"
                    ShowFooter="True" AllowPaging="True" CellSpacing="6" 
                    onpageindexchanging="ManageArticleView_PageIndexChanging" 
          PageSize="10" AllowSorting="true">
                        
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
        
        <asp:TemplateField HeaderText="ID" Visible="false" >
            <ItemTemplate>
              <asp:Label runat="server" ID="ID" Text='<%#Eval("ID") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>
         <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblArtId" Text='<%#Eval("ArtId") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Type">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblArtType" Text='<%#Eval("ArtType") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Title">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblTitle" Text='<%#Eval("Title") %>' />
            </ItemTemplate>
                                                
         </asp:TemplateField>  
        <%--<asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblArtStatus" Text='<%#Eval("Sname") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>   --%>         

     <asp:TemplateField>
 
      <ItemTemplate>            
      <asp:ImageButton ID="btnDelete" Text="Delete" runat="server" OnClientClick="return confirm('Are You sure to delete this article')" CommandName="Delete"  ImageUrl="~/images/delete.png" CssClass="icon" ToolTip="Delete"/>
      </ItemTemplate>                            
      </asp:TemplateField>                        
            
        
      </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    
  </div>

  <div id="tabs-4"><!-----------------------code by avinash------------------------>

  <asp:Label ID="LblColl" runat="server" Text="Records per page"></asp:Label>
  
  <asp:DropDownList ID="DllPageSizeCollections" runat="server" AutoPostBack="True" 
          onselectedindexchanged="DllPageSizeCollections_SelectedIndexChanged">
      <asp:ListItem>10</asp:ListItem>
      <asp:ListItem>20</asp:ListItem>
      <asp:ListItem>30</asp:ListItem>
      <asp:ListItem>40</asp:ListItem>
      <asp:ListItem>50</asp:ListItem>      
      </asp:DropDownList>
 
   <asp:GridView ID="CollectionData" runat="server" BackColor="White" Width="500px"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="6"
             AutoGenerateColumns="False" onRowCancelingEdit="CollectionData_RowCancelingEdit"
                     OnRowEditing="CollectionData_RowEditing" OnRowUpdating="CollectionData_RowUpdating" 
                     onrowdeleting="CollectionData_RowDeleting" 
                    DataKeyNames="ID" ForeColor="#333333" GridLines="None" align = "center"
        ShowFooter="True" AllowPaging="True" CellSpacing="6"
        onpageindexchanging="CollectionData_PageIndexChanging" PageSize="10" AllowSorting="true">
                    

                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
        
        <asp:TemplateField HeaderText="ID" Visible="false" >
            <ItemTemplate>
              <asp:Label runat="server" ID="ID" Text='<%#Eval("ID") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>
         <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
              <asp:Label runat="server" ID="ColId" Text='<%#Eval("ColId") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblName" Text='<%#Eval("ColName") %>' />
            </ItemTemplate>
 
            <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtName" Text='<%#Eval("ColName") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCollectionName"
             runat="server"  Text="*" ForeColor="Red" ValidationGroup="EDIT" ControlToValidate="txtName" ErrorMessage="Enter Collection Name">
             </asp:RequiredFieldValidator>
            </EditItemTemplate>                          
            <FooterTemplate>
            <asp:TextBox ID="TxtColName" runat="server">
             </asp:TextBox>   
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorCollectionName1" ValidationGroup="INSERTCOLL"
             runat="server"  Text="*" ForeColor="Red" ControlToValidate="TxtColName" ErrorMessage="Insert Collection Name"> 
             </asp:RequiredFieldValidator>         
            </FooterTemplate>
         </asp:TemplateField>           
         <asp:TemplateField HeaderText="Status">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblSname" Text='<%#Eval("Sname") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>            

     <asp:TemplateField>
 
      <ItemTemplate>
       <asp:ImageButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" ImageUrl="~/images/edit.png" CssClass="icon" ToolTip="Edit" />
      <br />
      <asp:ImageButton ID="btnDelete" Text="Delete" runat="server" OnClientClick="return confirm('Are You sure to delete this record')" CommandName="Delete" ImageUrl="~/images/delete.png" CssClass="icon" ToolTip="Delete" />
      </ItemTemplate>
 
      <EditItemTemplate>
      <asp:ImageButton ID="btnUpdate" Text="Update" runat="server" ValidationGroup="EDITCOLL" CommandName="Update" ImageUrl="~/images/update.png" CssClass="icon" ToolTip="Update" />
      <asp:ImageButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel"  CausesValidation="false" ImageUrl="~/images/cancel.png" CssClass="icon" ToolTip="Cancel"/>
      </EditItemTemplate> 
      <FooterTemplate>
                <asp:ImageButton ID="LinkInsert" runat="server" ValidationGroup="INSERT" OnClick="lb_InsertCollections" ImageUrl="~/images/add.png" CssClass="icon" ToolTip="Insert"/>

      </FooterTemplate>                      
      </asp:TemplateField>                        
            
        
      </Columns>
           <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>        

        <asp:ValidationSummary ID="ValidationSummary5"  ValidationGroup = "EDITCOLL" align = "center" runat="server" ForeColor="Red"/>
        <asp:ValidationSummary ID="ValidationSummary6"  ValidationGroup="INSERTCOLL" align="center" runat="server" ForeColor="Red"/>
  
  </div>
 
  <div id="tabs-5"><!-----------------------code by Mervin------------------------>

  <asp:Label ID="LblTag" runat="server" Text="Records per page"></asp:Label>

  <asp:DropDownList ID="DllPageSizeTag" runat="server" AutoPostBack="True" 
          onselectedindexchanged="DllPageSizeTag_SelectedIndexChanged">
      <asp:ListItem>10</asp:ListItem>
      <asp:ListItem>20</asp:ListItem>
      <asp:ListItem>30</asp:ListItem>
      <asp:ListItem>40</asp:ListItem>
      <asp:ListItem>50</asp:ListItem>      
  </asp:DropDownList>

     <asp:GridView ID="TagData" runat="server" BackColor="White" Width="500px"
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="6"
             AutoGenerateColumns="False" onRowCancelingEdit="TagData_RowCancelingEdit"
                     OnRowEditing="TagData_RowEditing" OnRowUpdating="TagData_RowUpdating" 
                     onrowdeleting="TagData_RowDeleting" CellSpacing="6"
                     align="center"
                     
                    DataKeyNames="ID" ForeColor="#333333" GridLines="None" 
                    
        ShowFooter="True" AllowPaging="True" 
        onpageindexchanging="TagData_PageIndexChanging" PageSize="10" AllowSorting="true">
                    

                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
        
        <asp:TemplateField HeaderText="ID" Visible="false" >
            <ItemTemplate>
              <asp:Label runat="server" ID="ID" Text='<%#Eval("ID") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>
         <asp:TemplateField HeaderText="ID">
            <ItemTemplate>
              <asp:Label runat="server" ID="TId" Text='<%#Eval("TId") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>

         <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
              <asp:Label runat="server" ID="LblName" Text='<%#Eval("TName") %>' />
            </ItemTemplate>
 
            <EditItemTemplate>
            <asp:TextBox runat="server" ID="txtName" Text='<%#Eval("TName") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTagName"
             runat="server"  Text="*" ForeColor="Red" ValidationGroup="EDIT" ControlToValidate="txtName" ErrorMessage="Enter Tag Name">
             </asp:RequiredFieldValidator>
            </EditItemTemplate>                          
            <%--<FooterTemplate>
            <asp:TextBox ID="TxtTName" runat="server">
             </asp:TextBox>   
             <asp:RequiredFieldValidator ID="RequiredFieldValidatorTagName1" ValidationGroup="INSERT"
             runat="server"  Text="*" ForeColor="Red" ControlToValidate="TxtTName" ErrorMessage="Insert Tag Name"> 
             </asp:RequiredFieldValidator>         
            </FooterTemplate>--%>
         </asp:TemplateField>   
         <asp:TemplateField HeaderText="Collection Name">
            <ItemTemplate>
              <asp:Label runat="server" ID="ColName" Text='<%#Eval("ColName") %>' />
            </ItemTemplate>                                   
         </asp:TemplateField>             

     <asp:TemplateField>
 
      <ItemTemplate>
       <asp:ImageButton ID="btnEdit" Text="Edit" runat="server" CommandName="Edit" ImageUrl="~/images/edit.png" CssClass="icon" ToolTip="Edit" />
      <br />
      <asp:ImageButton ID="btnDelete" Text="Delete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are You sure to delete this record')" ImageUrl="~/images/delete.png" CssClass="icon" ToolTip="Delete" />
      </ItemTemplate>
 
      <EditItemTemplate>
      <asp:ImageButton ID="btnUpdate" Text="Update" runat="server" ValidationGroup="EDIT" CommandName="Update" ImageUrl="~/images/update.png" CssClass="icon" ToolTip="Update" />
      <asp:ImageButton ID="btnCancel" Text="Cancel" runat="server" CommandName="Cancel"  CausesValidation="false" ImageUrl="~/images/cancel.png" CssClass="icon" ToolTip="Cancel"/>
      </EditItemTemplate> 
     <%-- <FooterTemplate>
                <asp:LinkButton ID="LinkInsert" runat="server" ValidationGroup="INSERT" OnClick="lb_Click">Insert</asp:LinkButton>

      </FooterTemplate>  --%>                    
      </asp:TemplateField>                        
            
        
      </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle ForeColor="#333333" BackColor="#F7F6F3" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>        

        <asp:ValidationSummary ID="ValidationSummary3"  ValidationGroup = "EDIT" runat="server" ForeColor="Red" align="center"/>
  </div>
</div>
</asp:Content>
