<%@ Page Title="Exchange Rates | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="exchange.aspx.cs" Inherits="DelloiteTR.Exchange" %>
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
                                    <asp:Panel ID="errorBox" runat="server" style="opacity:100;" 
                                        class="alert alert-warning alert-dismissible fade show" role="alert" 
                                        Enabled="True">
                                        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                                        <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </asp:Panel>
                                    <div class="panel panel-flat">
		                                <div class="panel-heading">
			                                <h5 class="panel-title">Exchange Rates Weekly</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal1" class="btn btn-primary" data-toggle="modal" data-target="#exchange-rates-weekly"><i
						                                class="icon-plus3 position-left"></i>
					                                Add</button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
                                            <asp:Panel ID="successBox1" runat="server" style="opacity:100;" 
                                                class="alert alert-success alert-dismissible fade show" role="alert" 
                                                Enabled="True" ClientIDMode="Static">
                                                <asp:Label ID="successMsg1" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>

			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Country</th>
						                                <th>Currency</th>
						                                <th>Year</th>
						                                <th>Interval</th>
						                                <th>Amount</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>

                                                    <asp:Literal ID="dataTable1" runat="server"></asp:Literal>

				                                </tbody>
			                                </table>
		                                </div>
	                                </div>
	                                <div class="panel panel-flat">
		                                <div class="panel-heading">
			                                <h5 class="panel-title">Exchange Rates Monthly</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal2" class="btn btn-primary" data-toggle="modal" data-target="#exchange-rates-monthly"><i
						                                class="icon-plus3 position-left"></i>
					                                Add</button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
                                            <asp:Panel ID="successBox2" runat="server" style="opacity:100;" 
                                                class="alert alert-success alert-dismissible fade show" role="alert" 
                                                Enabled="True" ClientIDMode="Static">
                                                <asp:Label ID="successMsg2" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>
			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Country</th>
						                                <th>Currency</th>
						                                <th>Year</th>
						                                <th>Interval</th>
						                                <th>Amount</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>

                                                    <asp:Literal ID="dataTable2" runat="server"></asp:Literal>

				                                </tbody>
			                                </table>
		                                </div>
	                                </div>
	                                <div class="panel panel-flat">
		                                <div class="panel-heading">
			                                <h5 class="panel-title">Exchange Rates Yearly</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal3" class="btn btn-primary" data-toggle="modal" data-target="#exchange-rates-yearly"><i
						                                class="icon-plus3 position-left"></i>
					                                Add</button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
                                            <asp:Panel ID="successBox3" runat="server" style="opacity:100;" 
                                                class="alert alert-success alert-dismissible fade show" role="alert" 
                                                Enabled="True" ClientIDMode="Static">
                                                <asp:Label ID="successMsg3" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>
			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Country</th>
						                                <th>Currency</th>
						                                <th>Year</th>
						                                <th>Interval</th>
						                                <th>Amount</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>

                                                    <asp:Literal ID="dataTable3" runat="server"></asp:Literal>

				                                </tbody>
			                                </table>
		                                </div>
	                                </div>
                                    
	                                <div class="panel panel-flat">
		                                <div class="panel-heading">
			                                <h5 class="panel-title">Exchange Rates Broken Year</h5>
			                                <div class="heading-elements">
				                                <button type="button" id="btnShowModal4" class="btn btn-primary" data-toggle="modal" data-target="#exchange-rates-brokenyear"><i
						                                class="icon-plus3 position-left"></i>
					                                Add</button>
			                                </div>
		                                </div>
		                                <div class="panel-body">
                                            <asp:Panel ID="successBox4" runat="server" style="opacity:100;" 
                                                class="alert alert-success alert-dismissible fade show" role="alert" 
                                                Enabled="True" ClientIDMode="Static">
                                                <asp:Label ID="successMsg4" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                                <span aria-hidden="true">&times;</span>
                                                </button>
                                            </asp:Panel>
			                                <table class="table table-striped datatable-responsive">
				                                <thead>
					                                <tr>
						                                <th>No</th>
						                                <th>Country</th>
						                                <th>Currency</th>
						                                <th>Year</th>
						                                <th>Interval</th>
						                                <th>Amount</th>
						                                <th>Action</th>
					                                </tr>
				                                </thead>
				                                <tbody>

                                                    <asp:Literal ID="dataTable4" runat="server"></asp:Literal>

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


    <div id="exchange-rates-weekly" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
                    <asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton4">&times;</asp:LinkButton>
					<h5 class="modal-title">Exchange Rates Weekly</h5>
				</div>
					<div class="modal-body">
						<div class="form-group form-group-padding">
							<label class="col-lg-3 control-label">Country</label>
							<div class="col-lg-9">
                                <asp:HiddenField ID="exchangeweeklyid" runat="server" />
								<select runat="server" id="country" name="country" data-placeholder="Choose an option" class="select" >
									<option></option>
									<option value="Australia">Australia</option>
									<option value="Brunei Darussalam">Brunei Darussalam</option>
									<option value="Canada">Canada</option>
									<option value="China">China</option>
									<option value="Denmark">Denmark</option>
									<option value="Euro">Euro</option>
									<option value="Hong Kong">Hong Kong</option>
									<option value="India">India</option>
									<option value="Japan">Japan</option>
									<option value="Kuwait">Kuwait</option>
									<option value="Korea">Korea</option>
									<option value="Malaysia">Malaysia</option>
									<option value="Myanmar">Myanmar</option>
									<option value="New Zealend">New Zealend</option>
									<option value="Norway">Norway</option>
									<option value="Pakistan">Pakistan</option>
									<option value="Philippines">Philippines</option>
									<option value="Saudi Arabia">Saudi Arabia</option>
									<option value="Singapore">Singapore</option>
									<option value="Sri Lanka">Sri Lanka</option>
									<option value="Sweden">Sweden</option>
									<option value="Switzerland">Switzerland</option>
									<option value="Thailand">Thailand</option>
									<option value="United Kingdom">United Kingdom</option>
									<option value="United States">United States</option>
								</select>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req1" 
                                    controltovalidate="country" errormessage="Country is required!" 
                                    ValidationGroup="weekly" />
							</div>
						</div>
						<div class="form-group  form-group-padding">
							<label class="col-lg-3 control-label">Currency</label>
							<div class="col-lg-9">
								<input  runat="server" id="currency" type="text" name="currency" class="form-control" required/>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req2" controltovalidate="currency" errormessage="Currency is required!" ValidationGroup="weekly" />
							</div>
						</div>
						<div class="form-group  form-group-padding">
							<label class="col-lg-3 control-label">Interval</label>
							<div class="col-lg-9">
								<div class="row">
									<div class="col-sm-6">
										<div class="input-group">
											<input runat="server" id="intervalfrom" type="text" name="intervalfrom" class="form-control datepicker" placeholder="dd/mm/yyyy" readonly="readonly">
											<span class="input-group-addon"><i class="icon-calendar"></i></span>
										</div>
									</div>
									<div class="col-sm-6">
										<div class="input-group">
											<input runat="server" id="intervalto" type="text" name="intervalto" class="form-control datepicker" placeholder="dd/mm/yyyy" readonly="readonly">
											<span class="input-group-addon"><i class="icon-calendar"></i></span>
										</div>
									</div>
                                    <div class="col-sm-12">
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="req3" controltovalidate="intervalfrom" errormessage="Interval is required!" ValidationGroup="weekly" />
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="req4" controltovalidate="intervalto" errormessage="Interval is required!" ValidationGroup="weekly" />
                                    </div>
                                    
								</div>
							</div>
						</div>
						<div class="form-group  form-group-padding">
							<label class="col-lg-3 control-label">Year</label>
							<div class="col-lg-9">
								<input runat="server" id="year" type="text" name="year" class="form-control" required />
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="req5" controltovalidate="year" errormessage="Year is required!" ValidationGroup="weekly" />
							</div>
						</div>
						<div class="form-group form-group-padding">
							<label class="col-lg-3 control-label">Amount</label>
							<div class="col-lg-9 money">
								<input runat="server" id="amount" type="text" name="amount" class="form-control numberOnly2" required />
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="req6" controltovalidate="amount" errormessage="Amount is required!" ValidationGroup="weekly" />
							</div>
						</div>
					</div>
					<div class="modal-footer">
                            <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton1">Cancel</asp:LinkButton>
                        <asp:LinkButton runat="server" class="btn btn-primary" id="LBSaveWeekly" 
                            onclick="LBSaveWeekly_Click" ValidationGroup="weekly">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
					</div>
			</div>
		</div>
	</div>

	<div id="exchange-rates-monthly" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton5">&times;</asp:LinkButton>
					<h5 class="modal-title">Exchange Rates Monthly</h5>
				</div>
				<div class="modal-body">
					<div class="form-group">
						<label class="col-lg-3 control-label">Country</label>
						<div class="col-lg-9">
                            <asp:HiddenField ID="exchangemonthlyid" runat="server" />
							<select runat="server" id="country2" name="country2" data-placeholder="Choose an option" class="select" >
								<option></option>
								<option value="Australia">Australia</option>
								<option value="Brunei Darussalam">Brunei Darussalam</option>
								<option value="Canada">Canada</option>
								<option value="China">China</option>
								<option value="Denmark">Denmark</option>
								<option value="Euro">Euro</option>
								<option value="Hong Kong">Hong Kong</option>
								<option value="India">India</option>
								<option value="Japan">Japan</option>
								<option value="Kuwait">Kuwait</option>
								<option value="Korea">Korea</option>
								<option value="Malaysia">Malaysia</option>
								<option value="Myanmar">Myanmar</option>
								<option value="New Zealend">New Zealend</option>
								<option value="Norway">Norway</option>
								<option value="Pakistan">Pakistan</option>
								<option value="Philippines">Philippines</option>
								<option value="Saudi Arabia">Saudi Arabia</option>
								<option value="Singapore">Singapore</option>
								<option value="Sri Lanka">Sri Lanka</option>
								<option value="Sweden">Sweden</option>
								<option value="Switzerland">Switzerland</option>
								<option value="Thailand">Thailand</option>
								<option value="United Kingdom">United Kingdom</option>
								<option value="United States">United States</option>
							</select>
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req7" controltovalidate="country2" errormessage="Country is required!" ValidationGroup="monthly" />
						</div>
					</div>
					<div class="form-group">
						<label class="col-lg-3 control-label">Currency</label>
						<div class="col-lg-9">
							<input runat="server" id="currency2" type="text" name="currency2" class="form-control" required />
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req8" controltovalidate="currency2" errormessage="Currency is required!" ValidationGroup="monthly" />
						</div>
					</div>
					<div class="form-group">
						<label class="col-lg-3 control-label">Interval</label>
						<div class="col-lg-9">
							<div class="form-group">
								<select runat="server" id="interval2"  name="interval2" data-placeholder="Month" class="select" required>
									<option></option>
									<option value="January">January</option>
									<option value="February">February</option>
									<option value="March">March</option>
									<option value="April">April</option>
									<option value="May">May</option>
									<option value="June">June</option>
									<option value="July">July</option>
									<option value="August">August</option>
									<option value="September">September</option>
									<option value="October">October</option>
									<option value="November">November</option>
									<option value="December">December</option>
								</select>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req9" controltovalidate="interval2" errormessage="Interval is required!" ValidationGroup="monthly" />
							</div>
						</div>
					</div>
					<div class="form-group">
						<label class="col-lg-3 control-label">Year</label>
						<div class="col-lg-9">
							<input runat="server" id="year2" type="text" name="year2" class="form-control" required />
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req10" controltovalidate="year2" errormessage="Year is required!" ValidationGroup="monthly" />
						</div>
					</div>
					<div class="form-group">
						<label class="col-lg-3 control-label">Amount</label>
						<div class="col-lg-9 money">
							<input runat="server" id="amount2"  type="text" name="amount2" class="form-control numberOnly2" required />
                            <asp:RequiredFieldValidator class="validator" runat="server" id="req11" controltovalidate="amount2" errormessage="Amount is required!" ValidationGroup="monthly" />
						</div>
					</div>
				</div>
				<div class="modal-footer">
                            <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton2">Cancel</asp:LinkButton>
					<asp:LinkButton runat="server" class="btn btn-primary" id="LBSaveMonthly" 
                        onclick="LBSaveMonthly_Click"  ValidationGroup="monthly">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
				</div>
			</div>
		</div>
	</div>

	<div id="exchange-rates-yearly" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton6">&times;</asp:LinkButton>
					<h5 class="modal-title">Exchange Rates Yearly</h5>
				</div>
					<div class="modal-body">
						<div class="form-group">
							<label class="col-lg-3 control-label">Country</label>
							<div class="col-lg-9">
                                <asp:HiddenField ID="exchangeyearlyid" runat="server" />
								<select runat="server" id="country3"  name="country3" data-placeholder="Choose an option" class="select" >
									<option></option>
									<option value="Australia">Australia</option>
									<option value="Brunei Darussalam">Brunei Darussalam</option>
									<option value="Canada">Canada</option>
									<option value="China">China</option>
									<option value="Denmark">Denmark</option>
									<option value="Euro">Euro</option>
									<option value="Hong Kong">Hong Kong</option>
									<option value="India">India</option>
									<option value="Japan">Japan</option>
									<option value="Kuwait">Kuwait</option>
									<option value="Korea">Korea</option>
									<option value="Malaysia">Malaysia</option>
									<option value="Myanmar">Myanmar</option>
									<option value="New Zealend">New Zealend</option>
									<option value="Norway">Norway</option>
									<option value="Pakistan">Pakistan</option>
									<option value="Philippines">Philippines</option>
									<option value="Saudi Arabia">Saudi Arabia</option>
									<option value="Singapore">Singapore</option>
									<option value="Sri Lanka">Sri Lanka</option>
									<option value="Sweden">Sweden</option>
									<option value="Switzerland">Switzerland</option>
									<option value="Thailand">Thailand</option>
									<option value="United Kingdom">United Kingdom</option>
									<option value="United States">United States</option>
								</select>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req12" controltovalidate="country3" errormessage="Country is required!" ValidationGroup="yearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Currency</label>
							<div class="col-lg-9">
								<input runat="server" id="currency3"  type="text" name="currency3" class="form-control" required />
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req13" controltovalidate="currency3" errormessage="Currency is required!" ValidationGroup="yearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Interval</label>
							<div class="col-lg-9">
								<div class="form-group">
									<input runat="server" id="interval3" type="text" name="interval3" class="form-control" required>
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="req14" controltovalidate="interval3" errormessage="Interval is required!" ValidationGroup="yearly" />
								</div>
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Year</label>
							<div class="col-lg-9">
								<input runat="server" id="year3" type="text" name="year3" class="form-control" required />
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req15" controltovalidate="year3" errormessage="Year is required!" ValidationGroup="yearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Amount</label>
							<div class="col-lg-9 money">
								<input runat="server" id="amount3" type="text" name="amount3" class="form-control numberOnly2" required/>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="req16" controltovalidate="amount3" errormessage="Amount is required!" ValidationGroup="yearly" />
							</div>
						</div>
					</div>
					<div class="modal-footer">
                            <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton3">Cancel</asp:LinkButton>
						<asp:LinkButton runat="server" class="btn btn-primary" id="LBSaveYearly" 
                            onclick="LBSaveYearly_Click" ValidationGroup="yearly">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
					</div>
			</div>
		</div>
	</div>

	<div id="exchange-rates-brokenyear" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<asp:LinkButton runat="server" onclick="btnCancel_Click" class="close" id="LinkButton7">&times;</asp:LinkButton>
					<h5 class="modal-title">Exchange Rates Broken Year</h5>
				</div>
					<div class="modal-body">
						<div class="form-group">
							<label class="col-lg-3 control-label">Country</label>
							<div class="col-lg-9">
                                <asp:HiddenField ID="exchangebrokenyearlyid" runat="server" />
								<select runat="server" id="country4"  name="country4" data-placeholder="Choose an option" class="select" >
									<option></option>
									<option value="Australia">Australia</option>
									<option value="Brunei Darussalam">Brunei Darussalam</option>
									<option value="Canada">Canada</option>
									<option value="China">China</option>
									<option value="Denmark">Denmark</option>
									<option value="Euro">Euro</option>
									<option value="Hong Kong">Hong Kong</option>
									<option value="India">India</option>
									<option value="Japan">Japan</option>
									<option value="Kuwait">Kuwait</option>
									<option value="Korea">Korea</option>
									<option value="Malaysia">Malaysia</option>
									<option value="Myanmar">Myanmar</option>
									<option value="New Zealend">New Zealend</option>
									<option value="Norway">Norway</option>
									<option value="Pakistan">Pakistan</option>
									<option value="Philippines">Philippines</option>
									<option value="Saudi Arabia">Saudi Arabia</option>
									<option value="Singapore">Singapore</option>
									<option value="Sri Lanka">Sri Lanka</option>
									<option value="Sweden">Sweden</option>
									<option value="Switzerland">Switzerland</option>
									<option value="Thailand">Thailand</option>
									<option value="United Kingdom">United Kingdom</option>
									<option value="United States">United States</option>
								</select>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator1" controltovalidate="country4" errormessage="Country is required!" ValidationGroup="brokenyearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Currency</label>
							<div class="col-lg-9">
								<input runat="server" id="currency4"  type="text" name="currency4" class="form-control" required />
                                <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator2" controltovalidate="currency4" errormessage="Currency is required!" ValidationGroup="brokenyearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Interval</label>
							<div class="col-lg-9">
								<div class="form-group">
								    <select runat="server" id="interval4"  name="interval4" data-placeholder="Choose an option" class="select" required>
									    <option></option>
									    <option value="January - February">January - February</option>
									    <option value="January - March">January - March</option>
									    <option value="January - April">January - April</option>
									    <option value="January - May">January - May</option>
									    <option value="January - June">January - June</option>
									    <option value="January - July">January - July</option>
									    <option value="January - August">January - August</option>
									    <option value="January - September">January - September</option>
									    <option value="January - October">January - October</option>
									    <option value="January - November">January - November</option>

									    <option value="February - March">February - March</option>
									    <option value="February - April">February - April</option>
									    <option value="February - May">February - May</option>
									    <option value="February - June">February - June</option>
									    <option value="February - July">February - July</option>
									    <option value="February - August">February - August</option>
									    <option value="February - September">February - September</option>
									    <option value="February - October">February - October</option>
									    <option value="February - November">February - November</option>
									    <option value="February - December">February - December</option>

									    <option value="March - April">March - April</option>
									    <option value="March - May">March - May</option>
									    <option value="March - June">March - June</option>
									    <option value="March - July">March - July</option>
									    <option value="March - August">March - August</option>
									    <option value="March - September">March - September</option>
									    <option value="March - October">March - October</option>
									    <option value="March - November">March - November</option>
									    <option value="March - December">March - December</option>
                                        
									    <option value="April - May">April - May</option>
									    <option value="April - June">April - June</option>
									    <option value="April - July">April - July</option>
									    <option value="April - August">April - August</option>
									    <option value="April - September">April - September</option>
									    <option value="April - October">April - October</option>
									    <option value="April - November">April - November</option>
									    <option value="April - December">April - December</option>
                                        
									    <option value="May - June">May - June</option>
									    <option value="May - July">May - July</option>
									    <option value="May - August">May - August</option>
									    <option value="May - September">May - September</option>
									    <option value="May - October">May - October</option>
									    <option value="May - November">May - November</option>
									    <option value="May - December">May - December</option>
                                        
									    <option value="June - July">June - July</option>
									    <option value="June - August">June - August</option>
									    <option value="June - September">June - September</option>
									    <option value="June - October">June - October</option>
									    <option value="June - November">June - November</option>
									    <option value="June - December">June - December</option>
                                        
									    <option value="July - August">July - August</option>
									    <option value="July - September">July - September</option>
									    <option value="July - October">July - October</option>
									    <option value="July - November">July - November</option>
									    <option value="July - December">July - December</option>
                                        
									    <option value="August - September">August - September</option>
									    <option value="August - October">August - October</option>
									    <option value="August - November">August - November</option>
									    <option value="August - December">August - December</option>
                                        
									    <option value="September - October">September - October</option>
									    <option value="September - November">September - November</option>
									    <option value="September - December">September - December</option>
                                        
									    <option value="October - November">October - November</option>
									    <option value="October - December">October - December</option>
                                        
									    <option value="November - December">November - December</option>
								    </select>
                                    <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator3" controltovalidate="interval4" errormessage="Interval is required!" ValidationGroup="brokenyearly" />
								</div>
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Year</label>
							<div class="col-lg-9">
								<input runat="server" id="year4" type="text" name="year4" class="form-control" required />
                                <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator4" controltovalidate="year4" errormessage="Year is required!" ValidationGroup="brokenyearly" />
							</div>
						</div>
						<div class="form-group">
							<label class="col-lg-3 control-label">Amount</label>
							<div class="col-lg-9 money">
								<input runat="server" id="amount4" type="text" name="amount4" class="form-control numberOnly2" required/>
                                <asp:RequiredFieldValidator class="validator" runat="server" id="RequiredFieldValidator5" controltovalidate="amount4" errormessage="Amount is required!" ValidationGroup="brokenyearly" />
							</div>
						</div>
					</div>
					<div class="modal-footer">
                            <asp:LinkButton runat="server" onclick="btnCancel_Click" class="btn btn-default" id="LinkButton8">Cancel</asp:LinkButton>
						<asp:LinkButton runat="server" class="btn btn-primary" id="LinkButton9" 
                            onclick="LBSaveBrokenYear_Click" ValidationGroup="brokenyearly">Save <i class="icon-floppy-disk position-right"></i></asp:LinkButton>
					</div>
			</div>
		</div>
	</div>

<script type="text/javascript">
    function ShowPopup1() {
        $("#btnShowModal1").click();
    } 
    function ShowPopup2() {
        $("#btnShowModal2").click();
    } 
    function ShowPopup3() {
        $("#btnShowModal3").click();
    }
    function ShowPopup4() {
        $("#btnShowModal4").click();
    }
    function SuccessPopup() {
        alert('Data has been saved');
        window.location.href = "exchange.aspx";
    }
    function SuccessPopup2() {
        alert('Data has been updated');
        window.location.href = "exchange.aspx";
    }

</script>  

</asp:Content>
