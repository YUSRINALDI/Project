<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DelloiteTR.login.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Login | Deloitte GATe</title>
	<link rel="shortcut icon" href="../assets/delloite/assets/images/favicon_1.ico">

	<link href="https://fonts.googleapis.com/css?family=Roboto:400,300,100,500,700,900" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/css/icons/icomoon/styles.css" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/css/bootstrap.css" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/css/core.css" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/css/components.css" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/css/colors.css" rel="stylesheet" type="text/css">
	<link href="../assets/delloite/assets/js/plugins/timepicker/bootstrap-datepicker.min.css" rel="stylesheet">

	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/loaders/pace.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/core/libraries/jquery-3.2.1.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/core/libraries/bootstrap.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/loaders/blockui.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/ui/nicescroll.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/ui/drilldown.js"></script>

	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/tables/datatables/datatables.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/tables/datatables/extensions/responsive.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/forms/selects/select2.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/pages/datatables_responsive.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/forms/wizards/steps.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/pages/wizard_steps.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/forms/styling/uniform.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/core/libraries/jasny_bootstrap.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/forms/validation/validate.min.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/extensions/cookie.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/plugins/timepicker/bootstrap-datepicker.js"></script>
	<script type="text/javascript" src="../assets/delloite/assets/js/pages/login_validation.js"></script>

</head>

<body class="login-container">
    <form runat="server">
        <div class="navbar navbar-inverse">
		    <div class="navbar-header">
			    <a class="navbar-brand" href="login.aspx"><img src="../assets/delloite/assets/images/logo_deloitte.png" alt=""></a>
		    </div>
	    </div>

	    <div class="page-container">
		    <div class="page-content">
			    <div class="content-wrapper">
					<div class="panel panel-body login-form">
						<div class="text-center">
							<h5 class="content-group">Deloitte GATe | Login</h5>
						</div>

                        <div id="divError" runat="server" class="alert alert-warning" role="alert">
                            <asp:Label ID="labelError" runat="server" Text=""></asp:Label>
                        </div>

                        <div id="timeout" runat="server" class="alert alert-warning" role="alert">
                            <asp:Label ID="label1" runat="server" Text="Your session is timeout. Please login again!"></asp:Label>
                        </div>

						<div class="form-group has-feedback has-feedback-left">
							<asp:TextBox type="text" Text="" runat="server" ID="txtUsername" class="form-control" placeholder="Username" />
							<div class="form-control-feedback">
								<i class="icon-user text-muted"></i>
							</div>
						</div>

						<div class="form-group has-feedback has-feedback-left">
							<asp:TextBox type="password" Text="" runat="server" ID="txtPassword" class="form-control" placeholder="Password" />
							<div class="form-control-feedback">
								<i class="icon-lock2 text-muted"></i>
							</div>
						</div>

						<div class="form-group">
							<asp:Button runat="server" class="btn btn-primary btn-block" text="Sign in" 
                                onclick="ButtonLogin_Click" ID="ButtonLogin" />
						</div>

						<div style="display:none;" class="text-center">
							<a href="#">Forgot password?</a>
						</div>
					</div>
			    </div>
		    </div>
	    </div>

	    <div class="footer text-muted text-center">
		    &copy; 2018. <a href="#">Deloitte</a>
	    </div>

	    <script type="text/javascript" src="../assets/delloite/assets/js/core/app.js"></script>
	    <script type="text/javascript" src="../assets/delloite/assets/js/custom.js"></script>
    </form>
</body>

</html>
