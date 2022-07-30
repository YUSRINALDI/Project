<%@ Page Title="Assets & Liabilities | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="assetsliabilities.aspx.cs" Inherits="DelloiteTR.Assetsliabilities" %>
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
			                                <h5 class="panel-title">Description Code</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal" class="btn btn-primary" data-toggle="modal" data-target="#description-code"><i class="icon-plus3 position-left"></i>
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
						                                <th>Form</th>
						                                <th>Group Type</th>
						                                <th>Code</th>
						                                <th>Account</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>
					                                <asp:Literal ID="dataTableAsset" runat="server"></asp:Literal>
				                                </tbody>
			                                </table>
		                                </div>
	                                </div>

                                    <div id="description-code" class="modal fade">
		                                <div class="modal-dialog">
			                                <div class="modal-content">
				                                <div class="modal-header bg-primary">
                                                    <asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton2">&times;</asp:LinkButton>
					                                <h5 class="modal-title">Description Code</h5>
				                                </div>
					                                <div class="modal-body">
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
						                                <div class="form-group form-group-padding">
							                                <label class="control-label col-sm-3">Group Type</label>
							                                <div class="col-sm-9">
								                                <select onchange="CbGroupChange(this.value);" runat="server" id="cbGroup" name="" data-placeholder="Choose Form" class="select-simple" required>
									                                <option></option>
									                                <option value="01">Cash And Cash Equivalent</option>
									                                <option value="02">Account Receivables</option>
									                                <option value="03">Investments</option>
									                                <option value="04">Vehicles</option>
									                                <option value="05">Moveable Assets</option>
									                                <option value="06">Immoveable Assets</option>
									                                <option value="10">Liabilities</option>
								                                </select>
                                                                <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator1" controltovalidate="cbGroup" errormessage="Form is required!" ValidationGroup="createnew" />
							                                </div>
						                                </div>
						                                <div class="form-group form-group-padding">
							                                <label class="control-label col-sm-3">Code</label>
							                                <div class="col-sm-9">
                                                                <asp:HiddenField ID="assetid" runat="server" />
                                                                <asp:TextBox runat="server" ID="tbgroup" ClientIDMode="Static" class="form-control" style="width:29%;display:-webkit-inline-box;" ReadOnly></asp:TextBox>
								                                <asp:TextBox runat="server" ID="code" class="form-control" style="width:70%;display:-webkit-inline-box;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req1" controltovalidate="code" errormessage="Code is required!" />
							                                </div>
						                                </div>
						                                <div class="form-group form-group-padding">
							                                <label class="control-label col-sm-3">Account</label>
							                                <div class="col-sm-9">
								                                <asp:TextBox runat="server" type="text" id="account" name="account" class="form-control"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ValidationGroup="input" class="validator" runat="server" id="req2" controltovalidate="account" errormessage="Account is required!" />
							                                </div>
						                                </div>
					                                </div>
					                                <div class="modal-footer">
                                                        <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton1">Cancel</asp:LinkButton>
                                                        <asp:LinkButton ValidationGroup="input" runat="server" onclick="btnSaveAsset_Click" class="btn btn-primary" id="LBSave">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
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

    <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowModal").click();
        }
        function SuccessPopup() {
            alert('Data has been saved');
            window.location.href = "assetsliabilities.aspx";
        }
        function SuccessPopup2() {
            alert('Data has been updated');
            window.location.href = "assetsliabilities.aspx";
        }
        function CbGroupChange(val) {
            console.log(val);
            $("#tbgroup").val(val);
        }
</script> 
</asp:Content>
