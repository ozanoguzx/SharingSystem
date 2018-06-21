<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="BilgeAdamSharing.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>Bilge Adam Dosya Paylaşım Giriş Ekranı</title>
	<meta name="author" content="" />
	<meta name="description" content="" />
	<meta name="google-site-verification" content="" />
	<meta name="Copyright" content="" />
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link href="assets/css/alertify.css" rel="stylesheet" />
	<script src="assets/js/Bilgilendirme.js"></script>
    <script src="assets/js/jquery.alertify.min.js"></script>
	<link rel="stylesheet" href="assets/css/style.css" />
	<link rel="stylesheet" href="assets/css/dark.css" />
	<link rel="stylesheet" href="assets/css/bootstrap.css" />
	<link rel="stylesheet" href="assets/css/animate.min.css" />
	<link rel="stylesheet" href="assets/css/sliders.css" />
	<link rel="stylesheet" href="assets/css/magnific-popup.css" />
	<link rel="stylesheet" href="assets/css/icon-fonts.css" />
	<link rel="Favicon Icon" href="KP.ICO" />
	
	<link href='http://fonts.googleapis.com/css?family=Oswald:400,700,300' rel='stylesheet' type='text/css'>
	<link href='http://fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css'>
	<link href='http://fonts.googleapis.com/css?family=Kalam:700,400' rel='stylesheet' type='text/css'>
	<script src="js/modernizr.js"></script>

	<!-- Windows 8: see http://msdn.microsoft.com/en-us/library/ie/dn255024%28v=vs.85%29.aspx for details -->
        

</head>

<body runat="server" class="preloader2 dark_sup_menu light_header">
 <div class="container">
     <form runat="server">
        <section class="content_section bg5">
          
            
		<div class="content row_spacer centered clearfix">
              <div class="main_title upper">
							<br />
							<img height="190" width="350" src="assets/images/icons/bilgeadamlogo.png" />
						</div>
			<div class="main_title side_line centered upper">
				<h2 style="font-family:Arial"><span class="line"></span>GİRİŞ YAP</h2>
			</div>
			
			<div class="my_col_half on_the_center centered clearfix">
				<form class="login_form_colored shadow1 login_flip flip_top">
					<div class="lfc_user_row">
						
					</div>
					<div class="lfc_user_row">
						<label for="login_user_name">
							<span class="label_space">
								<span class="hm_field_name">E Mail veya kullanıcı adı</span>
								<span class="hm_requires_star">*</span>
							</span>
                            <br />
						<asp:TextBox CssClass="input_no_icon" Width="386.85px"  placeholder="Mail veya Kullanıcı Adı" onfocus="isBlurred=true;" onblur="isBlurred=false;" ID="TextboxUserNameEmail" runat="server" />
								<br />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Kullanıcı adı veya email giriniz!" ControlToValidate="TextboxUserNameEmail" SetFocusOnError="true" Display="Dynamic" CssClass="myError" ValidationGroup="login"></asp:RequiredFieldValidator>
						</label>
					</div>
					<div class="lfc_user_row">
						<label for="login_password">
							<span class="label_space">
								<span class="hm_field_name">Şifre</span>
								<span class="hm_requires_star">*</span>
							</span>
                            <br />
							<asp:TextBox Width="386.85px" TextMode="Password" CssClass="input_no_icon"  placeholder="Şifre" ID="TextBoxSifre" runat="server" />
								<br />
								<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Şifre giriniz!" ControlToValidate="TextboxSifre" SetFocusOnError="true" Display="Dynamic" CssClass="myError" ValidationGroup="login"></asp:RequiredFieldValidator>
						</label>	
					</div>
					<div class="lfc_user_row clearfix">
						<div class="my_col_third">
							<label for="rememberme">
								<span class="remember-box">
							
									
								</span>
							</label>
						</div>
						<div class="clearfix">
							<asp:Button ValidationGroup="login" Text="GİRİŞ YAP" ID="ButtonGirisYap" OnClick="ButtonGirisYap_Click" CssClass="send_button upper centered" Width="200px" runat="server" />
						
						</div>
					</div>
					<b class="lfc_forget_pass" href="#">Bilge Adam 2015</b>
				</form>
				
			</div>
		</div>
	</section>
         </form>
    </div>
    </body>
    <script type="text/javascript" src="assets/js/functions.js"></script>
</html>
