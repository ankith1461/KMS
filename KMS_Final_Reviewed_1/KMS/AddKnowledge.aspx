<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddKnowledge.aspx.cs" Inherits="KMS.AddKnowledge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/jquery-1.7.min.js" type="text/javascript"></script>
<script src="Scripts/dynamicFileUpload.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            width: 92%;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 26px;
        }
        .style5
        {
            height: 23px;
            width: 541px;
        }
        .style7
        {
            width: 541px;
        }
        .style8
        {
            height: 26px;
            width: 541px;
        }
        .style9
        {
            height: 40px;
        }
        .style10
        {
            width: 173px;
        }
        .style11
        {
            width: 1016px;
        }
        .style12
        {
            height: 26px;
            width: 89px;
        }
        .style13
        {
        }
        .style14
        {
            height: 40px;
            width: 89px;
        }
        .style15
        {
            height: 23px;
            width: 89px;
        }
        .style16
        {
            width: 173px;
            height: 30px;
        }
        .style17
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<table class="style1">
            <tr>
                <td class="style11">
                   
                        <table class="style1">
                            <tr>
                                <td class="style16">

                                    <asp:Button ID="btnKbArticle" runat="server" onclick="kbButton_Click" 
                                        Text="KB Article" style="width: 180px" CssClass="btn-primary" />

                                </td>
                                <td class="style17">
                                    <asp:Button ID="btnExceptionKnowledge" runat="server" onclick="exceptionButton_Click" 
                                        Text="Exception Knowledge" style="width: 180px; margin-left: 21px" 
                                        CssClass="btn-primary" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style10">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                   
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Panel ID="panKbArticle" runat="server">
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:Label ID="lblApplicationName" runat="server" Text="Application *"></asp:Label>
                                </td>
                                <td class="style7">
                                    <asp:DropDownList ID="ddlApplicationName" runat="server" 
                                        onselectedindexchanged="ddlApplicationName_SelectedIndexChanged" 
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblCollectionName" runat="server" Text="Collection *"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtCollectionName" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="txtCollectionName_AutoCompleteExtender" 
                                        runat="server" Enabled="True" ServicePath="~/WebServ1.asmx" 
                                        TargetControlID="txtCollectionName" DelimiterCharacters=";, "
                                        ShowOnlyCurrentWordInCompletionListItem="true"
                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" 
                                        CompletionInterval="100" ServiceMethod="Collections">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style3" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCollection" runat="server" 
                                        ErrorMessage="Collection Name Should not be blank" 
                                        ControlToValidate="txtCollectionName" ondatabinding="btnSubmit_Click"></asp:RequiredFieldValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblTagName" runat="server" Text="Tag *"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtTagName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="txtTagName_AutoCompleteExtender" runat="server" 
                                        DelimiterCharacters=";, " Enabled="True" ServicePath="~/WebServ1.asmx"
                                        TargetControlID="txtTagName" ServiceMethod="Tags" CompletionInterval="100"
                                        CompletionSetCount="1" ShowOnlyCurrentWordInCompletionListItem="true"
                                        MinimumPrefixLength="1" EnableCaching="true">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style3" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTag" runat="server" 
                                        ErrorMessage="Tag Name Should not be blank" ControlToValidate="txtTagName" 
                                        ondatabinding="btnSubmit_Click"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lblPriority" runat="server" Text="Priority"></asp:Label>
                                </td>
                                <td class="style5">
                                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control">
                                        <asp:ListItem>High</asp:ListItem>
                                        <asp:ListItem>Medium</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style2" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblTitle" runat="server" Text="Title*"></asp:Label>
                                </td>
                                <td class="style8">
                                    <asp:TextBox ID="txtTitle" runat="server" Width="250px" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style3">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" 
                                        ErrorMessage="Title Should not be blank" ControlToValidate="txtTitle" 
                                        ondatabinding="btnSubmit_Click"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style3">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server" 
                                        ControlToValidate="txtTitle" 
                                        ErrorMessage="Maximum 500 Character  Should be there" 
                                        ValidationExpression="^[\d\W\w]{1,500}$" ondatabinding="btnSubmit_Click"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblDetails" runat="server" Text="Details*"></asp:Label>
                                </td>
                                <td class="style8">
                                    
                                    <cc1:Editor ID="edtDetails" runat="server" Width="500px" Height="500px" 
                                        AutoFocus="False" />
                                </td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style3">
                                    &nbsp;</td>
                                <td class="style3">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDetails" runat="server" 
                                        ControlToValidate="edtDetails" 
                                        ErrorMessage="Minimum 1 Maximum 3000 Character Should be there" 
                                        ValidationExpression="^[\d\W\w]{1,3000}$" ondatabinding="btnSubmit_Click"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAttachment" runat="server" Text="Attachment"></asp:Label>
                                </td>
                               <!-- <td class="style7">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </td>-->
                                <td>
                                                <input id="btnAdd" type="button" value="add" onclick = "AddFileUpload()"  />
                                    <br /><br />
                                    <div id = "FileUploadContainer">
                                        <!--FileUpload Controls will be added here -->

                                    </div>
                               </td>



                                <td>
                                    <asp:Label ID="lblFileFormat2" runat="server" 
                                        Text="File formats supported are pdf,rtf,doc,docx,xls,xlsx,zip,jpeg"></asp:Label>
                                </td>



                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style7">
                                    &nbsp;</td>
                                <td class="style7">
                                    <asp:Label ID="lblFileSize2" runat="server" Text="Max file size is 10MB"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            <td class="style7">
                                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                                    Text="Submit" CssClass="btn" />
                            </td>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" Text="Reset" 
                                     onclick="btnCancel_Click" CssClass="btn" CausesValidation="False" />&nbsp;
                                     <asp:Button ID="btnBackKb" runat="server" onclick="btnBackKb_Click" 
                                        Text="Back" CssClass="btn" CausesValidation="False" />
                                </td>
                                <td>
                                    
                                    <asp:Label ID="lblFileNumber" runat="server" 
                                        Text="Atmost three files can be uploaded"></asp:Label>
                                    
                                </td>
                                </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Panel ID="panExceptionKnowledge" runat="server" Width="914px">
                        <table class="style1">
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblApplicationName2" runat="server" Text="Application *" 
                                        Width="120px"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlApplicationName2" runat="server" 
                                        CssClass="form-control">
                                    </asp:DropDownList>
                                </td>
                                <td class="style12" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblCollectionName2" runat="server" Text="Collection *"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtCollectionName2" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="txtCollectionName2_AutoCompleteExtender" 
                                        runat="server" Enabled="True" 
                                        TargetControlID="txtCollectionName2"
                                         ServicePath="~/WebServ1.asmx" 
                                         DelimiterCharacters=";, "
                                        ShowOnlyCurrentWordInCompletionListItem="true"
                                        MinimumPrefixLength="1" EnableCaching="true" CompletionSetCount="1" 
                                        CompletionInterval="100" ServiceMethod="Collections">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td class="style12" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorCollection1" runat="server" 
                                        ErrorMessage="Collection name should not be blank" 
                                        ControlToValidate="txtCollectionName2" ondatabinding="btnSubmit2_Click"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblTagName2" runat="server" Text="Tag *"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtTagName2" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="txtTagName2_AutoCompleteExtender" runat="server" 
                                        TargetControlID="txtTagName2"
                                         DelimiterCharacters=";, " Enabled="True" ServicePath="~/WebServ1.asmx"
                                         ServiceMethod="Tags" CompletionInterval="100"
                                        CompletionSetCount="1" ShowOnlyCurrentWordInCompletionListItem="true"
                                        MinimumPrefixLength="1" EnableCaching="true">
                                    </asp:AutoCompleteExtender>
                                </td>
                                <td class="style12" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTag1" runat="server" 
                                        ErrorMessage="Tag name should not be blank" 
                                        ControlToValidate="txtTagName2" ondatabinding="btnSubmit2_Click"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblPriority2" runat="server" Text="Priority"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:DropDownList ID="ddlPriority2" runat="server" CssClass="form-control">
                                        <asp:ListItem>High</asp:ListItem>
                                        <asp:ListItem>Medium</asp:ListItem>
                                        <asp:ListItem>Low</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style12" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    <asp:Label ID="lblTitle2" runat="server" Text="Title*"></asp:Label>
                                </td>
                                <td class="style3">
                                    <asp:TextBox ID="txtTitle2" runat="server" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td class="style12" colspan="2">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle2" runat="server" 
                                        ControlToValidate="txtTitle2" ErrorMessage="Title cannot be empty" 
                                        ondatabinding="btnSubmit2_Click"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblProblemStatement" runat="server" Text="Problem Statement*"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProblemStatement" runat="server" Height="200px" 
                                        TextMode="MultiLine" Width="500px"></asp:TextBox>
                                </td>
                                <td class="style13">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorProblemStatement" 
                                        runat="server" ControlToValidate="txtProblemStatement" 
                                        ErrorMessage="Problem Statement cannot be empty"></asp:RequiredFieldValidator>
                                </td>
                                <td class="style13">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorProblemStatement" runat="server" 
                                        ControlToValidate="txtProblemStatement" 
                                        ErrorMessage=" Atmost 500 characters  can be entered" 
                                        ValidationExpression="^[\d\w\W]{1,500}$" ondatabinding="btnSubmit2_Click"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="RegularExpressionValidatorProblemStatement_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" 
                                        TargetControlID="RegularExpressionValidatorProblemStatement"
                                 >
                                    </asp:ValidatorCalloutExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    <asp:Label ID="lblResolution" runat="server" Text="Resolution*"></asp:Label>
                                </td>
                                <td class="style9">
                                    
                                    <cc1:Editor ID="edtResolution" runat="server" Width="500px" Height="500px" />

                                </td>
                                <td class="style14">
                                    &nbsp;</td>
                                <td class="style14">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorResolution" runat="server" 
                                        ControlToValidate="edtResolution" 
                                        ErrorMessage=" Atmost 2000 characterc can be there" 
                                        ValidationExpression="^[\d\w\W]{1,2000}$" ondatabinding="btnSubmit2_Click"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAdditionalInformation" runat="server" 
                                        Text="Additional Information"></asp:Label>
                                </td>
                                <td>
                                    
                                    <cc1:Editor ID="edtAdditionalInformation" runat="server" Width="500px" Height="300px" />
                                </td>
                                <td class="style13" colspan="2">
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorAdditionalInformation" 
                                        runat="server" ControlToValidate="edtAdditionalInformation" 
                                        ErrorMessage="Maximum 100 Character Should be there" 
                                        ValidationExpression="^[\d\w\W]{0,100}$" ondatabinding="btnSubmit2_Click"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Label ID="lblAttachment2" runat="server" Text="Attachment"></asp:Label>
                                </td>
                                <td>
                                    <input id="btnAdd1" type="button" value="add" onclick = "AddFileUpload1()"  />
                                    <br /><br />
                                    <div id = "FileUploadContainer1">
                                        <!--FileUpload Controls will be added here -->

                                    </div>
                                </td>
                                <td class="style15" colspan="2">
                                    <asp:Label ID="lblFileFormat" runat="server" 
                                        Text="File formats supported are pdf,rtf,doc,docx,xls,xlsx,zip,jpeg"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Button ID="btnSubmit2" runat="server" onclick="btnSubmit2_Click" 
                                        Text="Submit" CssClass="btn" />
                                </td>
                                <td class="style2">
                                    
                                    <asp:Button ID="btnCancel2" runat="server" onclick="btnCancel2_Click" 
                                        Text="Reset" CssClass="btn" CausesValidation="False" />
                                    &nbsp;
                                    <asp:Button ID="btnBackEx" runat="server" onclick="btnBackEx_Click" 
                                        Text="Back" CssClass="btn" CausesValidation="False" />
                                    
                                </td>
                                <td class="style15" colspan="2">
                                    <asp:Label ID="lblFileSize" runat="server" 
                                        Text="Max File Size 10MB and atmost three files can be attached"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        
</asp:Content>
