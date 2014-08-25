<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorEditKBPendingArticle.aspx.cs" Inherits="KMS.AuthorEditKBPendingArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

<style type="text/css">
        .style1
        {
            width: 64%;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
        }
        .style5
        {
            width: 157px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="style1" align="center" bgcolor="White" cellpadding="1" 
        cellspacing="5" dir="ltr" frame="void">
        <tr>
            <td class="style5" bgcolor="White" rowspan="1">
                <asp:Label ID="lblKBArticleTitle" runat="server" Text="Title"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticleTitle" runat="server" Text="Label" BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticleApplication" runat="server" Text="Application"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticleApplication" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                Collection</td>
            <td>
                <asp:Label ID="lblArticleCollection" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticleTag" runat="server" Text="Tags"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticleTag" runat="server" Text="Label" BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticleDetails" runat="server" Text="Details"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label" Style = "overflow-y:scroll" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticlePriority" runat="server" Text="Priority"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticlePriority" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticleDateOfReg" runat="server" 
                    Text="Uploaded Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticleDateOfReg" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                <asp:Label ID="lblKBArticleDateOfLastAccess" runat="server" 
                    Text=" Last Edited Date"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblArticleDateOfLastAccess" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5" bgcolor="White">
                
                <asp:Label ID="lblKBPendingArticleAttachments" runat="server" 
                    Text="Attachments"></asp:Label>
            </td>
            <td>
                <asp:Panel ID="Panel1" runat="server" Width="208px">
                    <asp:GridView ID="gvAttachment" runat="server" OnRowCommand="LinkButtonClick" GridLines="None" AutoGenerateColumns="false">

                    <Columns>
                    
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" Text='<%#Eval("DocName") %>' runat="server" CommandArgument='<%#Eval("DocId") %>'>
                    
                    
                    </asp:LinkButton>
                    
                    </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td rowspan="2">
                <asp:Panel ID="pnlRejectReason" runat="server" Height="89px" Width="316px">
                    <asp:TextBox ID="txtRejectReason" runat="server" Height="50px" 
    Width="291px"></asp:TextBox>
                    <asp:Button ID="btnSubmitReason" runat="server" onclick="btnSubmitReason_Click" 
                    Text="Submit" CssClass="btn-primary" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
            </td>
            <td class="style2">
                <asp:Button ID="btnArticleAccept" runat="server" 
                    onclick="btnArticleAccept_Click" Text="Approve" CssClass="btn" />
                <asp:Button ID="btnArticleReject" runat="server" 
                    onclick="btnArticleReject_Click" Text="Reject" CssClass="btn" />
                <asp:Button ID="btnPreviousPage" runat="server" onclick="btnPreviousPage_Click" 
                    Text="Cancel" CssClass="btn" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
    
        <asp:Label ID="lblArticleStatus" runat="server"></asp:Label>
    
    </div>
</asp:Content>
