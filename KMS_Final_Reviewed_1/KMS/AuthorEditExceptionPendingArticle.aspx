<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AuthorEditExceptionPendingArticle.aspx.cs" Inherits="KMS.AuthorEditExceptionPendingArticle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
        .style1
        {
            width: 61%;
        }
        .style2
        {
        }
        .style3
        {
        }
        .style4
        {
            width: 310px;
        }
        .style5
        {
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<table class="style1" align="center" cellpadding="5" cellspacing="0">
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleProblemStatement" runat="server" 
                    Text="Problem Statement"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleProblemStatement" runat="server" Text="Label" 
                    BackColor="#FFFFCC" BorderColor="White"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleApplication" runat="server" Text="Application"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleApplication" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                Collection</td>
            <td class="style4">
                <asp:Label ID="lblArticleCollection" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleTag" runat="server" Text="Tags"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleTag" runat="server" Text="Label" BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleAdditionalDetail" runat="server" 
                    Text="Additional Details"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleAdditionalDetail" runat="server" Text="Label" 
                    BackColor="#FFFFCC" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleResolution" runat="server" Text="Resolution" Style = "overflow-y:scroll"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleResolution" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticlePriority" runat="server" Text="Priority"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticlePriority" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleDateOfReg" runat="server" 
                    Text="Uploaded Date"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleDateOfReg" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                <asp:Label ID="lblExceptionArticleDateOfLastAccess" runat="server" 
                    Text=" Last Edited Date"></asp:Label>
            </td>
            <td class="style4">
                <asp:Label ID="lblArticleDateOfLastAccess" runat="server" Text="Label" 
                    BackColor="#FFFFCC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style5">
                
                <asp:Label ID="lblExceptionAttachment" runat="server" Text="Attachments"></asp:Label>
            </td>
            <td class="style4">
                <asp:Panel ID="Panel1" runat="server">
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
            <td class="style4">
                <asp:Panel ID="pnlExceptionRejectReason" runat="server">
                    <asp:TextBox ID="txtRejectReason" runat="server" Height="50px" 
    Width="291px"></asp:TextBox>
                    <asp:Button ID="btnSubmitReason" runat="server" onclick="btnSubmitReason_Click" 
                    Text="Submit" CssClass="btn-primary" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style2" align="justify" colspan="2">
                <asp:Button ID="btnArticleAccept" runat="server" 
                    onclick="btnArticleAccept_Click" Text="Approve" CssClass="btn" />
                <asp:Button ID="btnArticleReject" runat="server" 
                    onclick="btnArticleReject_Click" Text="Reject" CssClass="btn" />
                <asp:Button ID="btnPreviousPage" runat="server" onclick="btnPreviousPage_Click" 
                    Text="cancel" CssClass="btn" />
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
    
        <asp:Label ID="lblArticleStatus" runat="server"></asp:Label>
    
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    <div style="height: 19px">
    
    </div>
</asp:Content>
