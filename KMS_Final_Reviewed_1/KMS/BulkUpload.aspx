<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BulkUpload.aspx.cs" Inherits="KMS.BulkUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
        <div>
            <table style="background: #545454; width: 100%; height: 65px;">
                <tr>
                    <td align="center" class="style3">
                        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="rbGroup" Text="Add Exception"
                            Font-Bold="True" Font-Size="Large" ForeColor="White" AutoPostBack="true" 
                            oncheckedchanged="RadioButton1_CheckedChanged" />
                    </td>
                    <td align="center" class="style3">
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="rbGroup" Text="Add Article"
                            Font-Bold="True" ForeColor="White" Font-Size="Large" AutoPostBack="true" 
                            oncheckedchanged="RadioButton2_CheckedChanged"/>
                    </td>
                </tr>
            </table>
        </div>
        

        
            <div ID="div1" runat="server" style="width: auto; height: auto; padding: 5px; top: 200px;
                left: 200px; background-color:#c8ffc8;">
                <asp:Label ID="Label1" runat="server" Text="Instructions to follow::" Font-Bold="True"
                    Font-Size="Large" Font-Names="Verdana"></asp:Label>
                <table style="width: 100%">
                    <tr>
                        <td class="style1" colspan="2">
                            <p style="font-family: Verdana; font-size:small;">
                                1. To Upload The Bulk Data Properly Please Download The Excel Template From Here
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="38px" ImageUrl="~/Images/rsz_excelimg.png"
                            Width="41px" OnClick="BtnImgTemplateExcp_Click" CausesValidation="False" />
                            <br />
                            <br />
                                2. For Further Information Please Refer To The Third Sheet Of The Excel Template.
                            <br />
                            <br />


                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2" align="center" colspan="2">
                            <asp:FileUpload ID="FileUploadExcp" runat="server" Width="505px" Height="55px" Style="margin-right: 7px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This Field Cannot Be Left Blank..."
                                ControlToValidate="FileUploadExcp" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11" align="center" colspan="2">
                            <asp:Button ID="BtnUploadExcp" runat="server" Text="Upload" OnClientClick="return validateFileType()"
                                OnClick="BtnUploadExcp_Click" />
                        </td>
                    </tr>
                </table>
                <div ID="divGridViewExcp" runat="server">
                    <asp:Label ID="LblExcpGridHeader" runat="server" Text="Status of your uploaded files::"
                    Font-Bold="true"></asp:Label>
                <asp:GridView ID="GridViewExcp" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="10" 
                        onpageindexchanging="GridViewExcp_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Article Type" HeaderText="Article Type" />
                        <asp:BoundField DataField="Application" HeaderText="Application Name" />
                        <asp:BoundField DataField="Priority" HeaderText="Priority" />
                        <asp:TemplateField HeaderText="Upload Status">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="20" Width="20" />
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

                </div>
            </div>
            
        
            <div ID="div2" runat="server" style="width: auto; height: auto; padding: 5px; top: 200px;
                left: 200px; background-color:#fcffe8;">
                <asp:Label ID="Label2" runat="server" Text="Instructions to follow::" Font-Bold="True"
                    Font-Size="Large" Font-Names="Verdana"></asp:Label>
                <table style="width: 100%; margin-right: 0px">
                    <tr>
                        <td class="style1" colspan="2">
                            <p style="font-family: Verdana; font-size: small;">
                                 1. To Upload The Bulk Data Properly Please Download The Excel Template From Here
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="38px" ImageUrl="~/Images/rsz_excelimg.png"
                            Width="41px" OnClick="BtnImgTemplateKB_Click" CausesValidation="False" />
                            <br />
                            <br />
                                2. For Further Information Please Refer To The Third Sheet Of The Excel Template.
                            <br />
                            <br />

                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" align="center" colspan="2">
                            <asp:FileUpload ID="FileUploadKB" runat="server" Width="506px" Height="55px" Style="margin-right: 7px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This Field Cannot Be Left Blank..."
                                ControlToValidate="FileUploadKB" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11" align="center" colspan="2">
                            <asp:Button ID="BtnUploadKB" runat="server" Text="Upload" OnClientClick="return validateFileType1()"
                                OnClick="BtnUploadKB_Click" />
                        </td>
                    </tr>
                </table>
                <div ID="divGridViewKB" runat="server">
                    <asp:Label ID="LblKBGridHeader" runat="server" Text="Status of your uploaded files::"
                    Font-Bold="true"></asp:Label>
                <asp:GridView ID="GridViewKB" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" AllowPaging="true" PageSize="10" 
                        onpageindexchanging="GridViewKB_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Article Type" HeaderText="Article Type" />
                        <asp:BoundField DataField="Application" HeaderText="Application Name" />
                        <asp:BoundField DataField="Priority" HeaderText="Priority" />
                        <asp:TemplateField HeaderText="Upload Status">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Width="20" Height="20" />
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

                </div>
            </div>
            
        
    </div>
</asp:Content>
