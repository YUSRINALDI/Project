<%@ Page Title="Marital Status | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="marital.aspx.cs" Inherits="DelloiteTR.Marital" %>
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
                                <div class="panel panel-flat">
	                                <div class="panel-heading">
		                                <h5 class="panel-title">Marital Status</h5>
		                                <div class="heading-elements">
			                                <button type="button" id="btnShowModal" class="btn btn-primary" data-toggle="modal" data-target="#marital-status"><i class="icon-plus3 position-left"></i>
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
					                                <th>Year</th>
					                                <th>Status</th>
					                                <th>Amount</th>
					                                <th>Dependant</th>
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

    <div id="marital-status" class="modal fade">
		    <div class="modal-dialog">
			    <div class="modal-content">
				        <div class="modal-header bg-primary">
					        <asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton4">&times;</asp:LinkButton>
					        <h5 class="modal-title">Marital Status</h5>
				        </div>
					    <div class="modal-body">
						    <div class="form-group form-group-padding" style="padding:0px">
							    <label class="control-label col-sm-3">Year</label>
							    <div class="col-sm-9">
                                    <asp:HiddenField ID="maritalid" runat="server" />
								    <asp:TextBox runat="server"  type="number" name="year" id="year" class="form-control" />
                                    <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req1" controltovalidate="year" errormessage="Year is required!" />
							    </div>
						    </div>
						    <div class="form-group form-group-padding" style="padding:0px">
							    <label class="control-label col-sm-3">Status</label>
							    <div class="col-sm-9">
                                    <select runat="server" id="status" name="status" data-placeholder="Choose an option" class="select" >
									    <option></option>
									    <option value="Single">Single</option>
									    <option value="Married1">Married</option>
									    <option value="Married2">Married+</option>
								    </select>
                                    <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req2" controltovalidate="status" errormessage="Status is required!" />
							    </div>
						    </div>
						    <div class="form-group form-group-padding" style="padding:0px">
							    <label class="control-label col-sm-3">Amount</label>
							    <div class="col-sm-9 money">
								    <asp:TextBox runat="server" type="text" name="amount" id="amount" class="form-control numberOnly"  />
                                    <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req3" controltovalidate="amount" errormessage="Amount is required!" />

							    </div>
						    </div>
						    <div class="form-group form-group-padding" style="padding:0px">
							    <label class="control-label col-sm-3">Dependant</label>
							    <div class="col-sm-9 money">
								    <asp:TextBox runat="server" type="text" name="dependant" id="dependant" class="form-control numberOnly"  />
                                    <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req4" controltovalidate="dependant" errormessage="Dependant is required!" />

							    </div>
						    </div>
					    </div>
					    <div class="modal-footer">
                            <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton1">Cancel</asp:LinkButton>
                            <asp:LinkButton ValidationGroup="input" runat="server" onclick="LBSave_Click" class="btn btn-primary" id="LBSave">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
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
        //window.location.href = "marital.aspx";
    }
    function SuccessPopup2() {
        alert('Data has been updated');
        //window.location.href = "marital.aspx";
    }
</script>  
</asp:Content>
