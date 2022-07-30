<%@ Page Title="Relationship | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="relationship.aspx.cs" Inherits="DelloiteTR.Relationship" %>
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
			                                <h5 class="panel-title">Relationship</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal" class="btn btn-primary" data-toggle="modal" data-target="#relationship"><i class="icon-plus3 position-left"></i>
					                                Add</button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
                                            
                                            <asp:Panel ID="errorBox" runat="server" style="opacity:100;" 
                                                class="alert alert-warning alert-dismissible fade show" role="alert" 
                                                Enabled="True">
                                                <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>
                                            <asp:Panel ID="successBox" runat="server" style="opacity:100;" 
                                                class="alert alert-success alert-dismissible fade show" role="alert" 
                                                Enabled="True" ClientIDMode="Static">
                                                <asp:Label ID="successMsg" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>

			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Relationship</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>
					                                <asp:Literal ID="dataTableRelation" runat="server"></asp:Literal>
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

    <div id="relationship" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton4">&times;</asp:LinkButton>
					<h5 class="modal-title">Relationship</h5>
				</div>
				<div class="modal-body">
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-3">Relationship</label>
						<div class="col-sm-9">
                        <asp:HiddenField ID="relationid" runat="server" />
							<asp:TextBox runat="server" ValidationGroup="btsave" type="text" id="relationship" name="relationship" class="form-control"> </asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="btsave" class="validator" runat="server" id="req1" controltovalidate="relationship" errormessage="Relationship is required!" />
						</div>
					</div>
				</div>
				<div class="modal-footer">
                    <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="Cancel">Cancel</asp:LinkButton>
                    <asp:LinkButton runat="server" onclick="btnSaveRelation_Click" 
                        class="btn btn-primary" id="SaveRelation" ValidationGroup="btsave">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
				</div>
			</div>
		</div>
	</div>
    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowModal").click();
        }
        function SuccessPopup() {
            alert('Data has been saved');
            window.location.href = "relationship.aspx";
        }
        function SuccessPopup2() {
            alert('Data has been updated');
            window.location.href = "relationship.aspx";
        }
    </script> 
</asp:Content>
