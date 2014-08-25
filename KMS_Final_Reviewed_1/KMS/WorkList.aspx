<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkList.aspx.cs" Inherits="KMS.WorkList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>

<!-- Designed by ram babu and Haneef---------->
        <asp:Button ID="btnUserPublishedArticles" runat="server" Text="Published Articles"
            OnClick="btnUserPublishedArticles_Click" Height="50px" Width="197px" 
            CssClass="btn-lg-primary" />
        <asp:Button ID="btnPendingArticles" runat="server" OnClick="btnPendingArticles_Click"
            Text="Pending Articles   " Height="50px" Width="181px" 
            CssClass="btn-lg-primary" />
        <asp:Button ID="btnRejectedArticles" runat="server" Height="50px" OnClick="btnRejectedArticles_Click"
            Text="Rejected Articles  " Width="192px" CssClass="btn-lg-primary" />
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="gvUserPublished" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" AllowPaging="True"
            PageSize="10" OnRowCommand="gvUserPublished_RowCommand" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Article Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedArticleId" Text='<%#Eval("ArtId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedApplicationId" Text='<%#Eval("AppId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Article Type">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedArticleType" Text='<%#Eval("ArtType") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application ">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedAppName" Text='<%#Eval("AppName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Collection ">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedCollection" Text='<%#Eval("collectionname") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPublishedPriority" Text='<%#Eval("Priority") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnUerPublishedArticlesEdit" runat="server" AlternateText="edit details"
                            BorderStyle="None" Height="20px" ImageUrl="~/images/edit.png" Style="margin-left: 76px"
                            Width="28px" CommandName="UserPublished Edit Details" 
                            CommandArgument='<%#Eval("ArtId") + ","+Eval("AppId")+","+Eval("ArtStatus") %>' />
                    </ItemTemplate>
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
        <asp:Repeater ID="repeaterUserPublishedPaging" runat="server" ClientIDMode="AutoID">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnUserPublishedPaging" runat="server" Text='<%#Eval("Text") %>'
                    CommandArgument='<%# Eval("Value") %>' CommandName="UserPublished Edit Details"
                    Enabled='<%# Eval("Enabled") %>' OnClick="lnkbtnUserPublished_Click">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
        <asp:GridView ID="gvUserPending" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" AllowPaging="True"
            PageSize="10" OnRowCommand="gvUserPending_RowCommand" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Article Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingArticleId" Text='<%#Eval("ArtId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingApplicationId" Text='<%#Eval("AppId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Article Type">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingArticleType" Text='<%#Eval("ArtType") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingAppName" Text='<%#Eval("AppName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Collection ">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingCollection" Text='<%#Eval("collectionname") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblUserPendingPriority" Text='<%#Eval("Priority") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnUserPendingArticlesEdit" runat="server" AlternateText="edit details"
                            BorderStyle="None" Height="20px" ImageUrl="~/images/edit.png" Style="margin-left: 76px"
                            Width="28px" CommandName="UserPending Edit Details" 
                            CommandArgument='<%#Eval("ArtId") + ","+Eval("AppId")+","+Eval("ArtStatus") %>' />
                    </ItemTemplate>
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

        

        <asp:Repeater ID="repeaterUserPendingPaging" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnUserPendingPaging" runat="server" Text='<%#Eval("Text") %>'
                    CommandArgument='<%# Eval("Value") %>' CommandName="UserPending Edit Details"
                    Enabled='<%# Eval("Enabled") %>' OnClick="lnkbtnUserPending_Click">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>


        <asp:Button ID="UserPendingPopUp" runat="server" style="display:none;" />
        <asp:Panel id="UserPendingPanel" runat="server" Height="700px" Width="600px" style="display:none;">
            <table class="style1">
                <tr>
                    <td class="style3">
                        <asp:Label ID="Label12" runat="server" Text="Title">   </asp:Label>
                    </td>
                    <td class="style3">
                        <asp:TextBox ID="txtPopUpTitle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblArticleType0" runat="server" Text="ArticleType"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpArtType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label13" runat="server" Text="Application"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtPopUpAppName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label14" runat="server" Text="Collection"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpCollection" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label15" runat="server" Text="Priority"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpPriority" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label16" runat="server" Text="Details"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpDetails" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="server" Text="Problem Statement:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpProblemStatement" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <asp:Label ID="Label18" runat="server" Text="DateOfRegistration"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtPopUpDateOfReg" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" Text="DateOfLastAcess"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPopUpDateOfLastAccess" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label20" runat="server" Text="Resolution"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="AddtionalInformation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnPendingPopUp" runat="server" Text="OK"  />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>



        <asp:GridView ID="gvUserRejected" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" AllowPaging="True"
            PageSize="10" OnRowCommand="gvUserRejected_RowCommand" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="Article Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedArticleId" Text='<%#Eval("ArtId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedApplicationId" Text='<%#Eval("AppId") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Article Type">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedArticleType" Text='<%#Eval("ArtType") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Application ">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedAppName" Text='<%#Eval("AppName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Collection ">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedCollection" Text='<%#Eval("collectionname") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Priority">
                    <ItemTemplate>
                        <asp:Label ID="lblUserRejectedPriority" Text='<%#Eval("Priority") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="btnUerRejectedArticlesEdit" runat="server" AlternateText="edit details"
                            BorderStyle="None" Height="20px" ImageUrl="~/images/edit.png" Style="margin-left: 76px"
                            Width="28px" CommandName="UserRejected Edit Details" 
                            CommandArgument='<%#Eval("ArtId") + ","+Eval("AppId")+","+Eval("ArtStatus") %>' />
                    </ItemTemplate>
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
        <asp:Repeater ID="repeaterUserRejectedPaging" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="lnkbtnUserRejectedPaging" runat="server" Text='<%#Eval("Text") %>'
                    CommandArgument='<%# Eval("Value") %>' CommandName="UserRejected Edit Details"
                    Enabled='<%# Eval("Enabled") %>' OnClick="lnkbtnUserRejected_Click">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
