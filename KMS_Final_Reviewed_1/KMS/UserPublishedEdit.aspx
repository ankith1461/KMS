<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPublishedEdit.aspx.cs" Inherits="KMS.UserPublishedEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <!-- <script type="text/javascript">
          var counter = 0;
          function AddFileUpload() {
              var div = document.createElement('DIV');
              div.innerHTML = '<input id="file' + counter + '" name = "file' + counter + '" type="file" /><input id="Button' + counter + '" type="button" value="Remove" onclick = "RemoveFileUpload(this)" />';
              document.getElementById("FileUploadContainer").appendChild(div);
              counter++;
              if (counter == 3) {
                  document.getElementById("Button1").style.visibility = "hidden";
                  alert('u upload max 3 file');
              }
              if (counter < 3) {
                  document.getElementById("Button1").style.visibility = "visible";

              }
          }
          function RemoveFileUpload(div) {
              document.getElementById("FileUploadContainer").removeChild(div.parentNode);
              counter--;
              if (counter == 3) {
                  document.getElementById("Button1").style.visibility = "hidden";
                  alert('u upload max 3 file');
              }
              if (counter < 3) {
                  document.getElementById("Button1").style.visibility = "visible";

              }
          }</script>
          -->
   
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 45px;
        }
    </style><script type="text/javascript" src="Scripts/fileupload.js"></script>
   <script type="text/javascript" src="_http://code.jquery.com/jquery-1.9.1.js"></script>

    <script src="Scripts/validation.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table cellpadding="2" cellspacing="3" class="style1">
            <tr>
                <td>
                    Title:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtTitle" ErrorMessage="Title Should not be Blank"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtTitle" 
                        ErrorMessage="Maximum 500 Character Should be There" 
                        ValidationExpression="^[\d\W\w]{1,500}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Application Name:</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlApplicationName" runat="server" Height="24px" 
                        Width="130px">
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    Collection Name:</td>
                <td class="style2">
                    <asp:TextBox ID="txtCollectionName" runat="server"></asp:TextBox>
                </td>
                <td class="style2" colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCollectionName" 
                        ErrorMessage="Required Should not be Blank"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Tag Name:</td>
                <td>
                    <asp:TextBox ID="txtTagName" runat="server"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtTagName" ErrorMessage="Tag Name Should not be Blank"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Priority:</td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlPriority" runat="server" Height="16px" Width="126px">                   
                    <asp:ListItem Text="High" Value="High"></asp:ListItem>
                    <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                    <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td>
                    Details:</td>
                <td colspan="3">
                  
                    <cc1:Editor ID="editorDetails" runat="server" />
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="editorDetails" 
                        ErrorMessage="Maximum 3000 Character Should be there" 
                        ValidationExpression="^[\d\W\w]{1,3000}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Prevoius Attachments:</td>
                <td colspan="3">
                    <asp:GridView ID="gvAttachment" runat="server" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" onrowcommand="gvAttachment_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Document Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server"  Text='<%#Eval("DocName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Oparations">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkbtnDownload" runat="server"  CommandArgument='<%#Eval("DocId")%>' >Download</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    Upload
                    Attachment:</td>
                <td colspan="3">
                    <input id="Button1" type="button" value="add" onclick = "AddFileUpload()"  />
        <br /><br />
        <div id = "FileUploadContainer">
            <!--FileUpload Controls will be added here -->

                        
        </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUserPreviousPage" runat="server" Height="33px" Text="Cancel" 
                        Width="75px" onclick="btnUserPublishedEdit_Click" CssClass="btn" 
                        CausesValidation="False" />
                </td>
                <td colspan="3">
                    <asp:Button ID="btnUserPublishedUpdate" runat="server" Text="Submit" 
                        onclick="btnUserPublishedUpdate_Click" CssClass="btn-primary" />
                </td>
            </tr>
        </table>
</asp:Content>
