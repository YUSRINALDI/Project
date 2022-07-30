<%@ Page Title="" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DelloiteTR.Profile" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-container">
		<div class="page-content">
			<div class="content-wrapper">
				<div class="panel panel-flat">
					<div class="panel-body">
						<div class="row">
							<div class="col-md-12">
								<div class="row">

                                    <section class="content">

                                        <div class="panel-heading">
		                                    <h5 class="panel-title">My Profile</h5>
                                            <div class="heading-elements">
				                                <button type="button" id="btnShowModal" class="btn btn-primary" data-toggle="modal" data-target="#passwordchange"><i class="icon-key position-left"></i>
					                                Change Password</button>
			                                </div>
	                                    </div>
	                                    <div class="panel-body">
		                                    <div class="form-group form-group-padding">
						                        <label class="control-label col-sm-2">Username</label>
						                        <div class="col-sm-4">
							                        <asp:TextBox runat="server" type="text" id="username" name="username" class="form-control" ReadOnly="True"> </asp:TextBox>
						                        </div>
					                        </div>
		                                    <div class="form-group form-group-padding">
						                        <label class="control-label col-sm-2">Fullname</label>
						                        <div class="col-sm-4">
							                        <asp:TextBox runat="server" type="text" id="fullname" name="fullname" class="form-control" ReadOnly="True"> </asp:TextBox>
						                        </div>
					                        </div>
		                                    <div class="form-group form-group-padding">
						                        <label class="control-label col-sm-2">Email</label>
						                        <div class="col-sm-4">
							                        <asp:TextBox runat="server" type="text" id="email" name="email" class="form-control" ReadOnly="True"> </asp:TextBox>
						                        </div>
					                        </div>
		                                    <div class="form-group form-group-padding">
						                        <label class="control-label col-sm-2">Role</label>
						                        <div class="col-sm-4">
							                        <asp:TextBox runat="server" type="text" id="role" name="role" class="form-control" ReadOnly="True"> </asp:TextBox>
						                        </div>
					                        </div>
	                                    </div>

                                    </section>

                                    

                                    <div id="passwordchange" class="modal fade">
		                                <div class="modal-dialog">
			                                <div class="modal-content">
				                                <div class="modal-header bg-primary">
					                                <button type="button" class="close" data-dismiss="modal">&times;</button>
					                                <h5 class="modal-title">Change Password</h5>
				                                </div>
				                                <div class="modal-body">
					                                <div class="form-group form-group-padding">
						                                <label class="control-label col-sm-3">Current Password</label>
						                                <div class="col-sm-9">
							                                <asp:TextBox runat="server" type="text" id="currentpassword" name="currentpassword" class="form-control" TextMode="Password"> </asp:TextBox>
                                                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator1" controltovalidate="currentpassword" errormessage="Current Password is required!" />
						                                </div>
					                                </div>
					                                <div class="form-group form-group-padding">
						                                <label class="control-label col-sm-3">New Password</label>
						                                <div class="col-sm-9">
							                                <asp:TextBox runat="server" type="text" id="newpassword" name="newpassword" class="form-control" TextMode="Password"> </asp:TextBox>
                                                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator2" controltovalidate="newpassword" errormessage="New Password is required!" />
						                                </div>
					                                </div>
					                                <div class="form-group form-group-padding">
						                                <label class="control-label col-sm-3">Confirm New Password</label>
						                                <div class="col-sm-9">
							                                <asp:TextBox runat="server" type="text" id="confirmnewpassword" name="confirmnewpassword" class="form-control" TextMode="Password"> </asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="confirmnewpassword" CssClass="ValidationError" ControlToCompare="newpassword" ErrorMessage="No Match" ToolTip="Password must be the same" />
                                                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator3" controltovalidate="confirmnewpassword" errormessage="Confirm New Password is required!" />
						                                </div>
					                                </div>
				                                </div>
				                                <div class="modal-footer">
					                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                    <asp:LinkButton runat="server" class="btn btn-primary" id="Save" 
                                                        onclick="Save_Click">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
				                                </div>
			                                </div>
		                                </div>
	                                </div>

                                    <div class="clear">
                                    </div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
    <!-- /.content -->
</asp:Content>
