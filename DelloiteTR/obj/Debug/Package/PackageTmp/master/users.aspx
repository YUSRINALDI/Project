<%@ Page Title="Users | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="DelloiteTR.master.users" %>
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
                                    <div class="panel panel-flat">
		                                <div class="panel-heading">
			                                <h5 class="panel-title">Users</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal" class="btn btn-primary" data-toggle="modal" data-target="#users"><i class="icon-plus3 position-left"></i>
					                                Add
                                                </button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Username</th>
						                                <th>Fullname</th>
						                                <th>Email</th>
						                                <th>Role</th>
						                                <th>Visible</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>
					                                <asp:Literal ID="dataTable" runat="server"></asp:Literal>
				                                </tbody>
			                                </table>
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

    <div id="users" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton4">&times;</asp:LinkButton>
					<h5 class="modal-title">User</h5>
				</div>
				<div class="modal-body">
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Username</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="username" name="username" class="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req1" 
                                controltovalidate="username" errormessage="Username is required!" 
                                ValidationGroup="input" />
						</div>
					</div>
					<div runat="server" id="divpass" class="form-group form-group-padding">
						<label class="control-label col-sm-3">Password</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" id="password" name="password" class="form-control" TextMode="Password"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req2" 
                                controltovalidate="password" errormessage="Password is required!" 
                                ValidationGroup="input" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Fullname</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="fullname" name="fullname" class="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req3" 
                                controltovalidate="fullname" errormessage="Fullname is required!" 
                                ValidationGroup="input" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Email</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="email" name="email" class="form-control" TextMode="Email"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req4" controltovalidate="email" 
                                errormessage="Email is required!" ValidationGroup="input" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Role</label>
						<div class="col-sm-9">
                            <asp:DropDownList class="select" ID="role" runat="server">
                                <asp:ListItem Text="Admin" Value="1" />
                                <asp:ListItem Text="User" Value="2" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req5" controltovalidate="role" 
                                errormessage="Role is required!" ValidationGroup="input" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Visible</label>
						<div class="col-sm-9">
							<asp:DropDownList class="select" ID="suspended" runat="server">
                                <asp:ListItem Text="True" Value="0" />
                                <asp:ListItem Text="False" Value="1" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req6" 
                                controltovalidate="suspended" errormessage="Visible is required!" 
                                ValidationGroup="input" />
						</div>
					</div>
				</div>
				<div class="modal-footer">
                    <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="Cancel">Cancel</asp:LinkButton>
                    <asp:LinkButton runat="server" onclick="LBSave_Click" class="btn btn-primary" 
                        id="LBSave" ValidationGroup="input">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
				</div>
			</div>
		</div>
	</div>

    <div id="useredit" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<h5 class="modal-title">User</h5>
				</div>
				<div class="modal-body">
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Username</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="username2" name="username" 
                                class="form-control" ReadOnly="True"></asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator1" 
                                controltovalidate="username2" errormessage="Username is required!" 
                                ValidationGroup="edit" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Fullname</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="fullname2" name="fullname" class="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator3" 
                                controltovalidate="fullname2" errormessage="Fullname is required!" 
                                ValidationGroup="edit" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Email</label>
						<div class="col-sm-9">
							<asp:TextBox runat="server" type="text" id="email2" name="email" class="form-control" TextMode="Email"> </asp:TextBox>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator4" 
                                controltovalidate="email2" errormessage="Email is required!" 
                                ValidationGroup="edit" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Role</label>
						<div class="col-sm-9">
                            <asp:DropDownList class="select" ID="role2" runat="server">
                                <asp:ListItem Text="Admin" Value="1" />
                                <asp:ListItem Text="User" Value="2" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator5" 
                                controltovalidate="role2" errormessage="Role is required!" 
                                ValidationGroup="edit" />
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Visible</label>
						<div class="col-sm-9">
							<asp:DropDownList class="select" ID="suspended2" runat="server">
                                <asp:ListItem Text="True" Value="0" />
                                <asp:ListItem Text="False" Value="1" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator6" 
                                controltovalidate="suspended2" errormessage="Visible is required!" 
                                ValidationGroup="edit" />
						</div>
					</div>
				</div>
				<div class="modal-footer">
                    <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton1">Cancel</asp:LinkButton>
                    <asp:LinkButton runat="server" onclick="LBEdit_Click" class="btn btn-primary" 
                        id="LBEdit" ValidationGroup="edit">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
				</div>
			</div>
		</div>
	</div>
    <script type="text/javascript">
        function ShowPopup() {
            $("#useredit").modal();
        }
        function SuccessPopup() {
            alert('Data has been saved');
            window.location.href = "users.aspx";
        }
    </script> 

</asp:Content>
