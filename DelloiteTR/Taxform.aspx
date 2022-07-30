<%@ Page Title="Tax Form | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="Taxform.aspx.cs" Inherits="DelloiteTR.Taxform" %>
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
			                                <h5 class="panel-title">Tax Form</h5>
                                            
		                                </div>
		                                <div class="panel-body">
			                                <div class="row">
				                                <div class="col-md-12">
					                                <div class="row">
						                                <div class="col-md-6">
							                                <div class="form-group">
								                                <label>Company</label>
								                                <input type="text" runat="server" id="txtCompany" class="form-control border-info text-info" readonly="readonly">
							                                </div>

							                                <div class="form-group">
								                                <label>Tax Payer Name</label>
								                                <input type="text" runat="server" id="txtPlayerName" class="form-control border-info text-info" readonly="readonly">
							                                </div>

							                                <div class="form-group">
								                                <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#add-form"><i class="icon-plus3"></i>
									                                Create New</a>
							                                </div>
						                                </div>
						                                <div class="col-md-6">
							                                <div class="panel panel-flat">
								                                <div class="panel-body">
									                                <table class="table table-striped datatable-responsive">
										                                <thead>
											                                <tr>
												                                <th>No</th>
												                                <th>Year</th>
												                                <th>Form Type</th>
												                                <th>Amendment</th>
												                                <th>Action</th>
											                                </tr>
										                                </thead>
										                                <tbody>
                                                                            <asp:Label ID="dataTable" runat="server" Text=""></asp:Label>
										                                </tbody>
									                                </table>
								                                </div>
							                                </div>
						                                </div>
					                                </div>
				                                </div>
			                                </div>
		                                </div>

                                        <div id="add-form" class="modal fade">
		                                    <div class="modal-dialog">
			                                    <div class="modal-content">
				                                    <div class="modal-header bg-primary">
					                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
					                                    <h5 class="modal-title">Tax Form</h5>
				                                    </div>

				                                    <form action="#" class="form-horizontal">
					                                    <div class="modal-body">
						                                    <div class="form-group form-group-padding">
							                                    <label class="control-label col-sm-3">Tax Year</label>
							                                    <div class="col-sm-9">
								                                    <select runat="server" id="txtYear" name="" data-placeholder="Choose Year" class="select-simple" required>
									                                    <option></option>
								                                    </select>
                                                                    <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator1" controltovalidate="txtYear" errormessage="Tax Year is required!" ValidationGroup="createnew" />
							                                    </div>
						                                    </div>

						                                    <div class="form-group form-group-padding">
							                                    <label class="control-label col-sm-3">Form</label>
							                                    <div class="col-sm-9">
								                                    <select runat="server" id="cbForm" name="" data-placeholder="Choose Form" class="select-simple" required>
									                                    <option></option>
									                                    <option value="form1770">Form 1770</option>
									                                    <option value="formNonUs">Form Non US</option>
									                                    <option value="formUs">Form US</option>
									                                    <option value="formJapan">Form Japan</option>
								                                    </select>
                                                                    <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator2" controltovalidate="cbForm" errormessage="Form is required!" ValidationGroup="createnew" />
							                                    </div>
						                                    </div>
					                                    </div>

					                                    <div class="modal-footer">
						                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
						                                    <asp:LinkButton runat="server" id="btnSave" type="submit" 
                                                                class="btn btn-primary" onclick="btnSave_Click" ValidationGroup="createnew">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
					                                    </div>
				                                    </form>
			                                    </div>
		                                    </div>
	                                    </div>

                                    </section>

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

</asp:Content>
