<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startpage.aspx.cs" Inherits="KMS.startpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Signin for Knowledge Management System</title>


<!-- designed by Vamsee-------------------------------->

     <!-- Bootstrap core CSS -->
  <link href="../css/bootstrap.css" rel="stylesheet"/>
  
    <!-- Custom styles for this template -->
    <link href="../css/Style.css" rel="stylesheet"/>
        <link href="../css/carousel.css" rel="stylesheet"/>

    <!-- Just for debugging purposes. Don't actually copy this line! -->
    <!--[if lt IE 9]><script src="../../docs-assets/js/ie8-responsive-file-warning.js"></script><![endif]-->

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!--
      <script type="text/javascript" src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script type="text/javascript" src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    -->

    <script type="text/javascript" src="https://code.jquery.com/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/holder.js"></script>
   <script type="text/javascript" src="../js/modal.js"></script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 228px;
        }
        .style3
        {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
     <div class="container">    
 <div id="myCarousel" class="carousel slide" data-ride="carousel">
      
      <!-- Indicators -->
      <ol class="carousel-indicators">
        <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
        <li data-target="#myCarousel" data-slide-to="1"></li>
        <li data-target="#myCarousel" data-slide-to="2"></li>
      </ol>
      <div class="carousel-inner">
        <div class="item active">
          <img data-src="holder.js/900x500/auto/#777:#7a7a7a/text:First slide" alt="First slide">
          <div class="container">
            <div class="carousel-caption">
              <h1>Cognizant Technology Solutions</h1>
              <p>Cognizant technologies proudly presents Knowledge Management System.</p>
              
</button></p>
            </div>
          </div>
        </div>
        <div class="item">
          <img data-src="holder.js/900x500/auto/#666:#6a6a6a/text:Second slide" alt="Second slide">
          <div class="container">
            <div class="carousel-caption">
              <h1>Knowledge Management System</h1>
              <p>A Cognizant portal where issues that are solved for different applications can be found.</p>
              <p>New issues can be uploaded to the knowledge base by a registered user.</p>
             
            </div>
          </div>
        </div>
        <div class="item">
          <img data-src="holder.js/900x500/auto/#555:#5a5a5a/text:Third slide" alt="Third slide">
          <div class="container">
            <div class="carousel-caption">
              <h1>Upload your solutions to any issues, defects and bug fixes.</h1>
              <p>Every article is posted only after a peer review. This ensures quality solutions.</p>
              
            </div>
          </div>
        </div>
      </div>
      <a class="left carousel-control" href="#myCarousel" data-slide="prev"><span class="glyphicon glyphicon-chevron-left"></span></a>
      <a class="right carousel-control" href="#myCarousel" data-slide="next"><span class="glyphicon glyphicon-chevron-right"></span></a>
    </div><!-- /.carousel -->


    
   


    <!-- This is the sign in form controls-->
<form class="form-signin">
    
 <table class="style1">
     <tr>
         <td class="style3" colspan="2">
             <h3><span class="label label-default">KMS Sign in </span></h3>&nbsp;</td>
         <td>
             &nbsp;</td>
     </tr>
     <tr>
         <td class="style3">
             <asp:Label ID="lblUname" runat="server" Text="Username"></asp:Label>&nbsp;</td>
         <td class="style2">
             <asp:TextBox ID="TxtUsername" runat="server" class="form-control"></asp:TextBox>&nbsp;</td>
         <td>
             <asp:RequiredFieldValidator ID="RFV1" runat="server" 
                 ErrorMessage="Please give Username" ControlToValidate="TxtUsername" 
                 ForeColor="Red" ></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:RegularExpressionValidator
                     ID="REV1" runat="server" 
                 ErrorMessage="Username is 6 digit Cognizant ID" ForeColor="Red" 
                 ValidationExpression="^[0-9]{6}$" ControlToValidate="TxtUsername"></asp:RegularExpressionValidator></td>
     </tr>
     <tr>
         <td class="style3">
             <asp:Label ID="lblPwd" runat="server" Text="Password"></asp:Label>&nbsp;</td>
         <td class="style2">
            <asp:TextBox ID="TxtPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>&nbsp;</td>
         <td>
             <asp:RequiredFieldValidator ID="RFV2" runat="server" 
                 ErrorMessage="Please give Password" ControlToValidate="TxtPassword" 
                 ForeColor="Red"></asp:RequiredFieldValidator>&nbsp;&nbsp;<asp:RegularExpressionValidator
                     ID="REV2" runat="server" 
                 ErrorMessage="Password should have 1 upper case, 1 number and 1 special character" 
                 ControlToValidate="TxtPassword" ForeColor="Red" 
                 
                 ValidationExpression="^.*(?=.{8,})(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$@%&amp;? &quot;]).*$"></asp:RegularExpressionValidator></td>
     </tr>
     <tr>
         <td class="style3">
             &nbsp;</td>
         <td class="style2">
             <asp:Button ID="BtnSubmit" runat="server" 
            class="btn btn-lg btn-primary btn-block" Text="Sign in" type="submit" 
            Width="101px" onclick="BtnSubmit_Click" />&nbsp;</td>
         <td>
             <asp:Label ID="lblMsg" runat="server" Text="!Login Failed...please try again" class="alert alert-danger" Visible="false"></asp:Label>&nbsp;</td>
     </tr>
     <tr>
         <td class="style3">
             &nbsp;</td>
         <td class="style2">
              &nbsp; <asp:LinkButton ID="LinkButton2" runat="server" data-toggle="modal" data-target="#Forgot">Forgot Password?</asp:LinkButton></td>
         <td>
             &nbsp;</td>
     </tr>
     <tr>
         <td class="style3">
             &nbsp;</td>
         <td class="style2">
             &nbsp;</td>
         <td>
             &nbsp;</td>
     </tr>
 </table>
    
    
</form>
</div>
<!--this is for the registration form displayed as a modal-->
<div class="modal fade" id="Forgot" style="border:2px solid;
border-radius:20px; box-shadow: 10px 10px 5px black;"   data-backdrop="static" data-show="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title">Forgot Password!</h4>
      </div>
<div class="modal-body">
        
<form class="form-signin" name="ForgotPassword" action="">
<asp:Label ID="Label1" runat="server" Text="Give your Email Id"></asp:Label>
 
<asp:TextBox ID="txtForgot" runat="server" class="form-control"></asp:TextBox>
<br/>
   <asp:Button ID="btnForgot" runat="server" Text="Send Email"  class="btn btn-primary btn-lg"/>               
</form>
  <asp:Label ID="lblForgotMsg" runat="server" Text="Password will be sent to your Cognizant mail ID"></asp:Label>        
    </div><!-- modal body -->
    <div class="modal-footer">
       
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

      </div>
      
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->     

    </form>
    <footer>
        
        <p>&copy; 2013 Cognizant Technologies, Inc. &middot; <a href="#">Privacy</a> &middot; <a href="#">Terms</a></p>
      </footer>

        
</body>
</html>
