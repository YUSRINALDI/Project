<%@ Page Title="Form Japan | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="formJapan.aspx.cs" Inherits="DelloiteTR.formJapan" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
		<div class="page-header-content">
			<div class="page-title">
				<h4><i class="icon-arrow-left52 position-left"></i> <span class="text-semibold">Form Japan</span></h4>

				<ul class="breadcrumb breadcrumb-caret position-right">
					<li><a href="default.aspx">Home</a></li>
					<li>
                        <asp:LinkButton ID="lbForm" runat="server" onclick="lbForm_Click">
                        Tax Form
                        </asp:LinkButton>
                    </li>
					<li class="active">
                        <asp:LinkButton ID="LBBreadcrumb" runat="server" onclick="LBBreadcrumb_Click">
                            <asp:Label ID="lblBreadcrumb" runat="server" Text="Tax Payer Name | Year | Form Type"></asp:Label>
                        </asp:LinkButton>
                    </li>
				</ul>
			</div>
		</div>
	</div>

    <div class="page-container">
		<div class="page-content">
			<div class="content-wrapper">
				<div class="panel panel-flat">
					<div class="panel-heading">
                        <input type="hidden" ID="hdTaxPlayerNumber" runat="server" />
                        <input type="hidden" ID="hdcreatedby" runat="server" />
                        <input type="hidden" ID="hdcreateddate" runat="server" />
                        <input type="hidden" ID="hdtaxformid" runat="server" clientidmode="Static" />
                        <input type="hidden" ID="hdcurrentTab" runat="server" clientidmode="Static" />
                        <input type="hidden" ID="hdisActive" runat="server" clientidmode="Static" />
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
                        <asp:Panel ID="successBox" runat="server" style="opacity:0;" 
                            class="alert alert-success alert-dismissible fade show" role="alert" 
                            Enabled="True" ClientIDMode="Static">
                            <asp:Label ID="successMsg" runat="server" Text=""  ClientIDMode="Static"></asp:Label>
                            <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                            </button>
                        </asp:Panel>

						<div class="tabbable" id="tabs">
							<ul class="nav nav-pills nav-pills-bordered nav-justified">
								<li class="active"><a id="tab1" onclick="TabClick(this.id);" href="#general-information" data-toggle="tab">General Information</a></li>
								<li><a id="tab2" onclick="TabClick(this.id);" href="#overseas-income" data-toggle="tab">Japanese Income</a></li>
								<li><a id="tab3" onclick="TabClick(this.id);" href="#assets-liabilities" data-toggle="tab">Assets & Liabilities</a></li>
							</ul>
							<div class="tab-content" >
								<div class="tab-pane" id="blank">
									<form class="steps-validation" action="#">
										<h6> </h6>
										<fieldset>
										</fieldset>
									</form>
								</div>

								<div class="tab-pane active" id="general-information">
	                                <form class="steps-validation" action="#">
		                                <h6>Step 1</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Tax ID Number</label>
						                                <input type="text" runat="server" id="t1s1f1" class="form-control border-info text-info" readonly="readonly" clientidmode="Static" />
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Tax Payer Name</label>
						                                <input type="text" runat="server" id="t1s1f2" class="form-control border-info text-info" readonly="readonly" clientidmode="Static" />
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Year</label>
                                                        <asp:HiddenField ID="selectedform" runat="server" ClientIDMode="Static" />
						                                <input type="text" runat="server" id="t1s1f3" class="form-control border-info text-info" readonly="readonly" clientidmode="Static" />
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Occupation</label>
						                                <asp:TextBox type="text" runat="server" id="t1s1f5"  
							                                class="form-control" ClientIDMode="Static"></asp:TextBox>
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Fax Number</label>
						                                <div class="input-group">
							                                <asp:TextBox type="text" runat="server" id="t1s1f4"  class="form-control" ClientIDMode="Static"></asp:TextBox>
							                                <span class="input-group-addon"><i class="fa fa-fax"></i></span>
						                                </div>
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Spouse Tax ID</label>
						                                <asp:TextBox type="text" runat="server" id="t1s1f6"  
							                                class="form-control" data-mask="99-999-999-9-999-999" ClientIDMode="Static" />
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Tax Obligation Status <span class="text-danger">*</span></label>
						                                <asp:DropDownList runat="server" id="t1s1f7"  
							                                data-placeholder="Choose an option" class="select-simple required" ClientIDMode="Static">
							                                <asp:ListItem Text="" />
							                                <asp:ListItem Text="KK" />
							                                <asp:ListItem Text="PH" />
							                                <asp:ListItem Text="MT" />
							                                <asp:ListItem Text="HB" />
							                                <asp:ListItem Text="-" />
						                                </asp:DropDownList>
					                                </div>
				                                </div>
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Phone Number <span class="text-danger">*</span></label>
						                                <asp:TextBox type="text" runat="server" id="t1s1f8" 
							                                class="form-control required" ClientIDMode="Static" Text=""></asp:TextBox>
                                                        
                                                    </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 2</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Date of Departure From Indonesia (EPO Date)</label>
						                                <div class="input-group">
							                                <input  type="text" runat="server" id="t1s2f1" class="form-control datepicker" 
                                                                placeholder="dd/mm/yyyy" clientidmode="Static" />
							                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
						                                </div>
					                                </div>
				                                </div>

				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Amended Tax Return No.</label>
						                                <asp:TextBox  type="number" runat="server" id="t1s2f2" class="form-control" 
                                                            readonly="true" ClientIDMode="Static"></asp:TextBox>
					                                </div>
				                                </div>
			                                </div>

			                                <div class="row">
				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Date of PPh 29 Payment</label>
						                                <div class="input-group">
							                                <input  type="text" runat="server" id="t1s2f5" class="form-control datepicker" 
                                                                placeholder="dd/mm/yyyy"  clientidmode="Static" />
							                                <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
						                                </div>
					                                </div>
				                                </div>

				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">PPh 29 Paid via Extension</label>
						                                <asp:TextBox  type="text" runat="server" id="t1s2f4" class="form-control numberOnly" 
                                                            ClientIDMode="Static" Text="0"></asp:TextBox>
					                                </div>
				                                </div>

				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Tax Overpayment</label>
						                                <select  runat="server" id="t1s2f6" data-placeholder="Choose an Option" 
                                                            class="select-simple" clientidmode="Static">
							                                <option value="-"></option>
							                                <option value="Refund">Refund</option>
							                                <option value="Offset Against The Tax Liabilites">Offset Against The Tax Liabilites</option>
							                                <option value="Return With SKPPKP Art. 17 C (obedient Taxpayer)">Return With SKPPKP Art. 17 C (obedient
								                                Taxpayer)</option>
							                                <option value="Return With SKKPP Art. 17 D (certain Taxpayer)">Return With SKKPP Art. 17 D (certain
								                                Taxpayer)</option>
						                                </select>
					                                </div>
					                                <div style="display:none" class="form-group">
						                                <label class="text-semibold">EPO or ERP Tidak Kembali? </label>
						                                <select  runat="server" id="t1s2f3" data-placeholder="Choose an Option" 
                                                            class="select-simple" clientidmode="Static">
							                                <option value="-"></option>
						                                </select>
					                                </div>
				                                </div>

				                                <div class="col-md-6">
					                                <div class="form-group">
						                                <label class="text-semibold">Signatory</label>
						                                <select runat="server" name="t1s2f7" id="t1s2f7" 
                                                            data-placeholder="Choose an Option" class="select-simple" clientidmode="Static">
							                                <option value="Taxpayer">Taxpayer</option>
							                                <option value="Proxy">Proxy</option>
						                                </select>
						                                <div id="proxyChoose" style="display: none;">
							                                <label for="taxname">Name</label>
							                                <input  type="text" runat="server" id="t1s2f8" name="t1s2f8" 
                                                                class="form-control" autofocus clientidmode="Static" />
							                                <label for="taxnumber">Tax ID Number</label>
							                                <input type="text" runat="server" id="t1s2f9" name="t1s2f9" 
                                                                class="form-control" data-mask="99-999-999-9-999-999" clientidmode="Static" />
						                                </div>
					                                </div>
				                                </div>
			                                </div>

			                                <div class="row">
				                                <div class="col-md-6">
					                                <div class="checkbox">
						                                <label for="t1s2f10">
							                                <input  type="checkbox" runat="server" id="t1s2f10" name="t1s2f10" 
                                                            class="styled" clientidmode="Static" />
							                                Monthly Instalment For Next Year, If File Returns For Two Consecutive Years Together, Click This Box
						                                </label>
					                                </div>

					                                <div class="form-group">
						                                <label class="text-semibold">List Of Attachments</label>
						                                <div class="checkbox">
							                                <label for="t1s2f16">
								                                <input type="checkbox" runat="server" id="t1s2f16" class="styled" 
                                                                clientidmode="Static" />
								                                Copy of Forms 1721A1/A2
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f12">
								                                <input  type="checkbox" runat="server" id="t1s2f12" class="styled" 
                                                                clientidmode="Static" />
								                                SSP PPH 29
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f11">
								                                <input type="checkbox" runat="server" id="t1s2f11" class="styled" 
                                                                clientidmode="Static" />
								                                Proxy Letter (Where Relevant)
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f20">
								                                <input type="checkbox" runat="server" id="t1s2f20" class="styled" 
                                                                clientidmode="Static" />
								                                Tax Liabilities Calculation For Taxpayer With Prenuptial Agreement and/or Married File Separately
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f13">
								                                <input onchange="s2other(this);" type="checkbox" runat="server" id="t1s2f13" class="styled" 
                                                                clientidmode="Static" />
								                                Other
							                                </label>
						                                </div>
                                                        <div id="div2other" style="display:none;">
                                                            <label><i>in English</i></label>
						                                    <textarea maxlength="100" class="form-control" runat="server" id="t1s2f18" rows="3" 
                                                                clientidmode="Static"></textarea> <br />
                                                            <textarea maxlength="100" class="form-control" runat="server" id="t1s2f23" rows="3" 
                                                            clientidmode="Static"></textarea>
						                                    <label><i>in Bahasa Indonesia</i></label>
						                                    <textarea maxlength="100" class="form-control" runat="server" id="t1s2f19" rows="3" 
                                                                clientidmode="Static"></textarea><br />					                                
						                                    <textarea maxlength="100" class="form-control" runat="server" id="t1s2f24" rows="3" 
                                                                clientidmode="Static"></textarea>
                                                        </div>
					                                </div>
				                                </div>
				                                <div class="col-md-6" style="display:none;">
					                                <div class="form-group">
						                                <div class="checkbox">
							                                <label for="t1s2f14">
								                                <input type="checkbox" runat="server" id="t1s2f14" class="styled" 
                                                                clientidmode="Static" />
								                                Calculation of Carry Forward Loss
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f15">
								                                <input type="checkbox" runat="server" id="t1s2f15" class="styled" 
                                                                clientidmode="Static" />
								                                Withholding Tax Slip / Collect by Other Parties / Borne and Paid by The Government / Withheld Abroad
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f17">
								                                <input type="checkbox" runat="server" id="t1s2f17" class="styled" 
                                                                clientidmode="Static" />
								                                Calculation of PPh 25 Installment For The Following Year
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f21">
								                                <input type="checkbox" runat="server" id="t1s2f21" class="styled" clientidmode="Static" />
								                                List of Total Income and Payments of PPh 25 (Only Applicable For Certain Entrepreneur)
							                                </label>
						                                </div>
						                                <div class="checkbox">
							                                <label for="t1s2f22">
								                                <input type="checkbox" runat="server" id="t1s2f22" class="styled" 
                                                                clientidmode="Static" />
								                                List of Total Income and Final Income Tax Settlement According GR 46 Year 2013 Per Month and Per
								                                Business Branch
							                                </label>
						                                </div>
						                                
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 3</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="col-md-12">
					                                <div class="row">
						                                <div class="col-md-4">
							                                <div class="form-group">
								                                <label>Marital Status</label>
                                                                <asp:DropDownList ID="t1s3f1" runat="server" data-placeholder="Choose Status" 
                                                                    class="select-simple" onchange="CheckReliefs(true)"  ClientIDMode="Static">
                                                                </asp:DropDownList>
							                                </div>
						                                </div>
						                                <div class="col-md-4">
							                                <div class="form-group">
								                                <label>Dependants</label>
								                                <asp:TextBox runat="server" id="t1s3f2" class="form-control" 
                                                                    onchange="CheckReliefs(true);" TextMode="Number" ClientIDMode="Static" Enabled="True" ReadOnly="True" Text="0">0</asp:TextBox>
							                                </div>
						                                </div>
						                                <div class="col-md-4">
							                                <div class="form-group money">
								                                <label>Personal Reliefs</label>
								                                <asp:TextBox TextMode="SingleLine" runat="server" id="t1s3f3" class="form-control border-info text-info" readonly="true" ClientIDMode="Static" Text="0" />
							                                </div>
						                                </div>
					                                </div>
					                                <div class="row">
						                                <div class="panel panel-flat">
							                                <div class="panel-heading">
								                                <h5 class="panel-title">List of Family</h5>
								                                <div class="heading-elements">
									                                <button type="button" onclick="addfam();"  class="btn btn-primary" data-toggle="modal" data-target="#list-family-form-1770"><i
										                                 class="icon-plus3 position-left"></i> Add
									                                </button>
								                                </div>
							                                </div>
							                                <div class="panel-body">
								                                <table id="familyTable" class="table table-striped datatable-responsive">
									                                <thead>
										                                <tr>
											                                <th style="text-align: center;">No</th>
											                                <th style="text-align: center;">Name</th>
											                                <th style="text-align: center;">Relationship</th>
											                                <th style="text-align: center;">Occupation</th>
											                                <th style="text-align: center;">NIK</th>
											                                <th style="text-align: center;">Action</th>
										                                </tr>
									                                </thead>
									                                <tbody>
										                                
									                                </tbody>
								                                </table>
							                                </div>
						                                </div>
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 4</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="panel panel-flat">
					                                <div class="panel-heading">
						                                <h5 class="panel-title">Self-paid Income Tax</h5>
						                                <div class="heading-elements"></div>
					                                </div>
					                                <div class="panel-body">
						                                <div class="tabbable">
							                                <ul class="nav nav-tabs nav-tabs-highlight">
								                                <li class="active"><a href="#fade-tab1" data-toggle="tab">Monthly Instalment (PPh 25) Payments</a></li>
								                                <li><a href="#fade-tab2" data-toggle="tab">Other</a></li>
							                                </ul>
							                                <div class="tab-content">
								                                <div class="tab-pane fade in active" id="fade-tab1">
									                                <div class="table-responsive">
										                                <table class="table table-bordered table-lg">
											                                <tr>
												                                <th style="text-align: center;">Month</th>
												                                <th style="text-align: center;">Instalment amount</th>
												                                <th style="text-align: center;">Reguler Payments</th>
												                                <th style="text-align: center;">Payments through STP</th>
											                                </tr>
											                                <tr>
												                                <td>January</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f1" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f3" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f4" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>February</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f5" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f7" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f8" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>March</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f9" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f11" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f12" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>April</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f13" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f15" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f16" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>May</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f17" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f19" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static"  />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f20" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>June</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f21" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f23" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f24" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>July</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f25" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f27" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f28" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>August</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f29" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f31" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f32" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>September</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f33" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f35" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static"  />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f36" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>October</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f37" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f39" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static"  />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f40" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>November</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f41" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f43" class="form-control numberOnly" 
                                                                                            placeholder="0.00"  clientidmode="Static"/>
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f44" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>December</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f45" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f47" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static"  />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s4f48" class="form-control numberOnly" 
                                                                                            placeholder="0.00" clientidmode="Static" readonly="readonly" 
                                                                                            disabled="disabled" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tfoot>
												                                <tr class="bg-info-300">
													                                <td class="text-bold">Total PPh 25 Payments</td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f49" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
														                                </div>
													                                </td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f50" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
														                                </div>
													                                </td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f51" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
														                                </div>
													                                </td>
												                                </tr>
												                                <tr class="bg-info-300">
													                                <td class="text-bold">Total PPh 25 Claimed <br><i>(including PPh 29 Paid During Extension)</i></td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f52" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                clientidmode="Static" />
														                                </div>
													                                </td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f53" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                clientidmode="Static" />
														                                </div>
													                                </td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s4f54" 
                                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                                clientidmode="Static" />
														                                </div>
													                                </td>
												                                </tr>
											                                </tfoot>
										                                </table>
                                                                        <div style="display:none;">
                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f2" class="select-simple" clientidmode="Static">
	                                                                            <option value="no">No</option>
	                                                                            <option value="yes">Yes</option>
                                                                            </select>


                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f6" class="select-simple" clientidmode="Static">
	                                                                            <option value="no">No</option>
	                                                                            <option value="yes">Yes</option>
                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f10" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" name="" runat="server" id="t1s4f14" class="select-simple" 
		                                                                            clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f18" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f22" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f26"  class="select-simple" 
		                                                                            clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f30" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f34" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f38"  class="select-simple" 
		                                                                            clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f42" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>


	                                                                            <select onchange="ChangePayment(this);" runat="server" id="t1s4f46" class="select-simple" clientidmode="Static">
		                                                                            <option value="no">No</option>
		                                                                            <option value="yes">Yes</option>
	                                                                            </select>
                                                                            </div>
									                                </div>
								                                </div>
								                                <div class="tab-pane fade" id="fade-tab2">
									                                <div class="row">
										                                <label class="control-label col-sm-4">Total Exit Tax</label>
										                                <div class="col-sm-8">
											                                <div class="form-group money">
												                                <input type="text" runat="server" id="t1s8f1" class="form-control numberOnly" 
                                                                                    placeholder="0.00" clientidmode="Static" />
											                                </div>
										                                </div>
									                                </div>
									                                <div class="row">
										                                <label class="control-label col-sm-4">Refund of PPh 24 Which Has Been Credited</label>
										                                <div class="col-sm-8">
											                                <div class="form-group money">
												                                <input type="text" runat="server" id="t1s4f55" class="form-control numberOnly" 
                                                                                    placeholder="0.00" clientidmode="Static" />
											                                </div>
										                                </div>
									                                </div>
								                                </div>
							                                </div>
						                                </div>
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 5</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="panel panel-flat">
					                                <div class="panel-heading">
						                                <h5 class="panel-title">Indonesian Employment Income (As Stated In The Forms 1721A1/A2)</h5>
						                                <div class="heading-elements">
							                                <button type="button" class="btn btn-danger" data-toggle="modal" data-target="#indonesian-employment-income-1770-total"><i
								                                 class="icon-eye position-left"></i> View Total</button>
							                                <button onclick="addieincome();return false;" type="button" class="btn btn-primary" data-toggle="modal" data-target="#indonesian-employment-income-1770"><i
								                                 class="icon-plus3 position-left"></i> Add</button>
						                                </div>
					                                </div>
					                                <div class="panel-body">
						                                <table id="IEIncomeTable" class="table table-striped datatable-responsive">
							                                <thead>
								                                <tr>
									                                <th style="text-align: center;">Name of Employer</th>
									                                <th style="text-align: center;">Working Period</th>
									                                <th style="text-align: center;">Employer's Tax ID Number</th>
									                                <th style="text-align: center;">Net income </th>
									                                <th style="text-align: center;">Income tax withheld</th>
									                                <th style="text-align: center;">Action</th>
								                                </tr>
							                                </thead>
							                                <tbody>
								                                
							                                </tbody>
						                                </table>
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 6</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="panel panel-flat">
					                                <div class="panel-heading">
						                                <h5 class="panel-title">Other Domestic Net Income</h5>
						                                <div class="heading-elements"></div>
					                                </div>
					                                <div class="panel-body">
						                                <div class="table-responsive">
							                                <table class="table table-bordered table-lg">
								                                <tr>
									                                <th style="text-align: center;"></th>
									                                <th style="text-align: center;">Gross income</th>
									                                <th style="text-align: center;">Expenses</th>
									                                <th style="text-align: center;">Net Income</th>
								                                </tr>
								                                <tr>
									                                <td>Interest</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f1" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f2" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f3" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Royalty</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f4" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f5" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f6" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Rentals</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f7" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f8" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f9" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Prize and awards</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f10" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f11" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f12" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Gains on sales/transfer of assets</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f13" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f14" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f15" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Others</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f16" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f17" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f18" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr class="bg-info-300">
									                                <td class="text-bold">Total</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f19" 
                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f20" 
                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f21" 
                                                                                class="form-control border-info text-info text-bold numberOnly" 
                                                                                readonly="readonly" clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Irregular items</td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f22" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f23" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f24" 
                                                                                class="form-control border-info text-info numberOnly" readonly="readonly" 
                                                                                clientidmode="Static" disabled="disabled" />
										                                </div>
									                                </td>
								                                </tr>
								                                <tr>
									                                <td>Tax on irregular items</td>
									                                <td colspan="2"></td>
									                                <td>
										                                <div class="money">
											                                <input type="text" runat="server" id="t1s6f25" class="form-control numberOnly" 
                                                                                placeholder="0.00" clientidmode="Static" />
										                                </div>
									                                </td>
								                                </tr>
							                                </table>
						                                </div>
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

		                                <h6>Step 7</h6>
		                                <fieldset>
			                                <div class="row">
				                                <div class="panel panel-flat">
					                                <div class="panel-heading">
						                                <h5 class="panel-title">Income Subject To Final Tax, Separately Taxed Income, And Non-assessable Income</h5>
						                                <div class="heading-elements"></div>
					                                </div>
					                                <div class="panel-body">
						                                <div class="tabbable tab-content-bordered">
							                                <ul class="nav nav-tabs nav-tabs-highlight">
								                                <li class="active"><a href="#basic-tab3" data-toggle="tab">Income Subject To Final Tax And/or Final In
										                                Nature</a></li>
								                                <li><a href="#basic-tab4" data-toggle="tab">Non-assessable Income</a></li>
							                                </ul>
							                                <div class="tab-content">
								                                <div class="tab-pane has-padding active" id="basic-tab3">
									                                <div class="table-responsive">
										                                <table class="table table-bordered table-lg">
											                                <tr>
												                                <th style="text-align: center;"></th>
												                                <th style="text-align: center;">Gross income</th>
												                                <th style="text-align: center;">Income Tax</th>
											                                </tr>
											                                <tr>
												                                <td>Interest on time deposits, savings, discount on SBI, state commercial paper</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f1" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f2" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Interest/discounts on bonds traded in stock exchange </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f3" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f4" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Sales value of shares traded in stock exchange</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f5" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f6" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Prizes from lotteries</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f7" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f8" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>One time payment of severance pay, old-age savings and pension benefits</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f9" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f10" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>State budget financed honorarium</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f11" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f12" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Transfer of title of land and/or buildings</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f13" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f14" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Rental of land and or building</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f15" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f16" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>The buildings received under a "BOT" arrangement</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f17" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f18" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Interest paid by Cooperation to Cooperation Member</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f19" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f20" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Dividend</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f21" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f22" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Wife's employment income</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f23" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f24" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Other income which has been subject to final income tax</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f25" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f26" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr style="display:none;">
												                                <td>Construction Services</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f27" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f28" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr style="display:none;">
												                                <td>Supplier / Dealer / Agent of Fuel Product</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f29" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f30" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tfoot>
												                                <tr class="bg-info-300">
													                                <td class="text-bold">Total</td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s7f31" class="form-control border-info text-info text-bold numberOnly" readonly="false" clientidmode="Static" />
														                                </div>
													                                </td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s7f32" class="form-control border-info text-info text-bold numberOnly" readonly="false" clientidmode="Static" />
														                                </div>
													                                </td>
												                                </tr>
											                                </tfoot>
										                                </table>
									                                </div>
								                                </div>
								                                <div class="tab-pane has-padding" id="basic-tab4">
									                                <div class="table-responsive">
										                                <table class="table table-bordered table-lg">
											                                <tr>
												                                <th style="text-align: center;"></th>
												                                <th style="text-align: center;">Gross income</th>
											                                </tr>
											                                <tr>
												                                <td>Donations/Gifts/Grants</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f33" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Inheritance</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f34" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Profit Sharing of Member of the Company Which The Capital Is Not Divided In Share, Partnership
													                                Etc.</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f35" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Claim for health, accident, life, or schoolarship insurance</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f36" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Domestic Scholarship</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f37" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tr>
												                                <td>Other non-assessable income</td>
												                                <td>
													                                <div class="money">
														                                <input type="text" runat="server" id="t1s7f38" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
													                                </div>
												                                </td>
											                                </tr>
											                                <tfoot>
												                                <tr class="bg-info-300">
													                                <td class="text-bold">Total</td>
													                                <td>
														                                <div class="money">
															                                <input type="text" runat="server" id="t1s7f39" class="form-control border-info text-info text-bold numberOnly" readonly="false" clientidmode="Static" />
														                                </div>
													                                </td>
												                                </tr>
											                                </tfoot>
										                                </table>
									                                </div>
								                                </div>
							                                </div>
						                                </div>
					                                </div>
				                                </div>
			                                </div>
		                                </fieldset>

	                                </form>

                                    <div class="row" style="display:none;">
				                        <div class="panel panel-flat">
					                        <div class="panel-body">
						                        <div class="row">
							                        <div class="col-md-6">
								                        <div class="row">
									                        <div class="col-md-6">
										                        <div class="form-group">
											                        <label for="t1s8f34">Trading - Rate (%)</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f34" class="form-control" placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="trading-rate" class="input-group-addon">%</span>
											                        </div>
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group money">
											                        <label for="t1s8f35">Industry - Business TurnOver</label>
											                        <input type="text" runat="server" id="t1s8f35" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group">
											                        <label for="t1s8f36">Industry - Rate (%)</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f36" class="form-control" placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="industry-rate" class="input-group-addon">%</span>
											                        </div>
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group money">
											                        <label for="t1s8f37">Services - Business TurnOver</label>
											                        <input type="text" runat="server" id="t1s8f37" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group">
											                        <label for="t1s8f38">Services - Rate (%)</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f38" class="form-control" placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="services-rate" class="input-group-addon">%</span>
											                        </div>
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group money">
											                        <label for="t1s8f39">Independent Services - Business TurnOver</label>
											                        <input type="text" runat="server" id="t1s8f39" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group">
											                        <label for="t1s8f40">Independent Services - Rate (%)</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f40" class="form-control"
												                            placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="independent-services-rate" class="input-group-addon">%</span>
											                        </div>
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group money">
											                        <label for="t1s8f41">Other business - Business TurnOver</label>
											                        <input type="text" runat="server" id="t1s8f41" class="form-control numberOnly" placeholder="0.00" clientidmode="Static" />
										                        </div>
									                        </div>
									                        <div class="col-md-6">
										                        <div class="form-group">
											                        <label for="t1s8f42">Other business - Rate (%)</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f42" class="form-control" placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="other-business-rate" class="input-group-addon">%</span>
											                        </div>
										                        </div>
										                        <div class="form-group">
											                        <label for="t1s8f43">Spouse Income Taxed Separately</label>
											                        <div class="input-group">
												                        <asp:TextBox type="number" min="0" max="99" runat="server" id="t1s8f43" class="form-control"
												                            placeholder="Enter value in %" ClientIDMode="Static"></asp:TextBox>
												                        <span name="spouse-income-taxed-separately" class="input-group-addon">%</span>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
                                </div>

								<div class="tab-pane" id="overseas-income">
									<form class="steps-validation" action="#">
										<h6>Step 1</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Japan Salary from Certificate of Income (CoI)</h5>
														<div class="heading-elements">
															<a type="button" onclick="Overseas('Japan Salary from Certificate of Income (CoI)', 1)" class="btn btn-primary" data-toggle="modal" data-target="#income-form-1770-s123"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="incomeTable1" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">Date of receipt</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="2">Amount in Original Currency</th>
																	<th style="text-align: center;" rowspan="2">Exchange Rate</th>
																	<th style="text-align: center;" colspan="2">Amount in IDR</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
                                                                
															</tfoot>
														</table>
                                                        <asp:Label ID="tab1total1" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab1total2" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab1total3" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab1total4" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab1total5" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab1total6" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 2</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Japan Salary from Certificate of Income (CoI)</h5>
														<div class="heading-elements">
															<a type="button" onclick="Overseas('Japan Salary from Certificate of Income (CoI)', 2)" class="btn btn-primary" data-toggle="modal" data-target="#income-form-1770-s123"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="incomeTable2" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">Date of receipt</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="2">Amount in Original Currency</th>
																	<th style="text-align: center;" rowspan="2">Exchange Rate</th>
																	<th style="text-align: center;" colspan="2">Amount in IDR</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																
															</tfoot>
														</table>
                                                        <asp:Label ID="tab2total1" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab2total2" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab2total3" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab2total4" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab2total5" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab2total6" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 3</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Other payments/allowances from Certificate of Salary</h5>
														<div class="heading-elements">
															<a type="button" onclick="Overseas('Other payments/allowances from Certificate of Salary', 3)" class="btn btn-primary" data-toggle="modal" data-target="#income-form-1770-s123"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="incomeTable3" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">Date of receipt</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="2">Amount in Original Currency</th>
																	<th style="text-align: center;" rowspan="2">Exchange Rate</th>
																	<th style="text-align: center;" colspan="2">Amount in IDR</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>

															</tfoot>
														</table>
                                                        <asp:Label ID="tab3total1" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab3total2" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab3total3" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab3total4" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab3total5" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="tab3total6" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 4</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Other payments/allowances from Certificate of Salary</h5>
														<div class="heading-elements">
															<a type="button" onclick="Overseas('Other payments/allowances from Certificate of Salary', 4)" class="btn btn-primary" data-toggle="modal" data-target="#income-form-1770-s123"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="incomeTable4" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">Date of receipt</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="2">Amount in Original Currency</th>
																	<th style="text-align: center;" rowspan="2">Exchange Rate</th>
																	<th style="text-align: center;" colspan="2">Amount in IDR</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>

															</tfoot>
														</table>
                                                        <asp:Label ID="Label1" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label3" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label4" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label5" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label6" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 5</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Bonuses</h5>
														<div class="heading-elements">
															<a type="button" onclick="Overseas('Bonuses', 5)" class="btn btn-primary" data-toggle="modal" data-target="#income-form-1770-s123"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="incomeTable5" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">Date of receipt</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="2">Amount in Original Currency</th>
																	<th style="text-align: center;" rowspan="2">Exchange Rate</th>
																	<th style="text-align: center;" colspan="2">Amount in IDR</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																	<th style="text-align: center;">Income</th>
																	<th style="text-align: center;">Tax paid /withheld</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>

															</tfoot>
														</table>
                                                        <asp:Label ID="Label7" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label8" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label9" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label10" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label11" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
                                                        <asp:Label ID="Label12" runat="server" Text="0" ClientIDMode="Static" style="display:none;"></asp:Label>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 6</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Tax allowance</h5>
														<div class="heading-elements"></div>
													</div>
													<div class="panel-body">
														<div class="table-responsive">
															<table class="table table-bordered table-lg">
																<tr>
																	<th style="text-align: center;">No</th>
																	<th style="text-align: center;">Type of taxes</th>
																	<th style="text-align: center;">Period</th>
																	<th style="text-align: center;">Year</th>
																	<th style="text-align: center;">Amount in original currency</th>
																	<th style="text-align: center;">Exchange Rate</th>
																	<th style="text-align: center;">Amount of Income (IDR) </th>
																</tr>
																<tr>
																	<td>1</td>
																	<td>PPh 25</td>
																	<td>December</td>
																	<td><input id="txtyear1" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f2" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate1" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f3" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>2</td>
																	<td>PPh 25</td>
																	<td>January</td>
																	<td><input id="txtyear2" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f4" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate2" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f5" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>3</td>
																	<td>PPh 25</td>
																	<td>February</td>
																	<td><input id="txtyear3" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f6" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate3" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f7" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>4</td>
																	<td>PPh 29 - last year</td>
																	<td>-</td>
																	<td><input id="txtyear4" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f8" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate4" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f9" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>5</td>
																	<td>PPh 25</td>
																	<td>March</td>
																	<td><input id="txtyear5" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f10" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate5" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f11" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>6</td>
																	<td>PPh 25</td>
																	<td>April</td>
																	<td><input id="txtyear6" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f12" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate6" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f13" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>7</td>
																	<td>PPh 25</td>
																	<td>May</td>
																	<td><input id="txtyear7" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f14" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate7" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f15" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>8</td>
																	<td>PPh 25</td>
																	<td>June</td>
																	<td><input id="txtyear8" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f16" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate8" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f17" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>9</td>
																	<td>PPh 25</td>
																	<td>July</td>
																	<td><input id="txtyear9" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f18" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate9" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f19" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>10</td>
																	<td>PPh 25</td>
																	<td>August</td>
																	<td><input id="txtyear10" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f20" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate10" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f21" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>11</td>
																	<td>PPh 25</td>
																	<td>September</td>
																	<td><input id="txtyear11" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f22" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate11" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f23" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>12</td>
																	<td>PPh 25</td>
																	<td>October</td>
																	<td><input id="txtyear12" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f24" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate12" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f25" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>13</td>
																	<td>PPh 25</td>
																	<td>November</td>
																	<td><input id="txtyear13" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f26" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate13" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f27" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>14</td>
																	<td>PPh 25</td>
																	<td>December</td>
																	<td><input id="txtyear14" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f28" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate14" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f29" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr>
																	<td>15</td>
																	<td>PPh 29 - current year</td>
																	<td>-</td>
																	<td><input id="txtyear15" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f30" runat="server" clientidmode="Static" type="text" class="form-control numberOnly" autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td><input style="text-align: right;" id="txtrate15" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly"
																		 placeholder="1" value="1" /></td>
																	<td><input style="text-align: right;" id="t1s8f31" runat="server" clientidmode="Static" type="text" class="form-control border-info text-info" readonly="readonly" /></td>
																</tr>
																<tr class="bg-info-400">
																	<td colspan="4">Total</td>
																	<td>
																		<div class="money">
																			<input id="t1s8f32" runat="server" clientidmode="Static" type="text" class="form-control border-info border-lg text-info numberOnly" readonly="readonly"
																			 autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																	<td></td>
																	<td>
																		<div class="money">
																			<input id="t1s8f33" runat="server" clientidmode="Static" type="text" class="form-control border-info border-lg text-info numberOnly" readonly="readonly"
																			 autocomplete="off" maxlength="6" />
																		</div>
																	</td>
																</tr>
															</table>
														</div>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 7</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Summary of Japan Income</h5>
													</div>
													<div class="panel-body">
														<table id="summarytable" class="table table-bordered datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;">Type of Income - in English</th>
																	<th style="text-align: center;">Type of Income - in Bahasa</th>
																	<th style="text-align: center;">Original Currency</th>
																	<th style="text-align: center;">Amount in Original Currency</th>
																	<th style="text-align: center;">Amount of Income (IDR)</th>
																	<th style="text-align: center;">Tax paid/withheld - original currency</th>
																	<th style="text-align: center;">Tax paid/withheld - (IDR)</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tr>
																<th colspan="4">Sub Total</th>
																<th style="text-align: right;"><asp:Label ID="lbltotalsummary1" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
																<th style="text-align: right;"><asp:Label ID="lbltotalsummary2" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
																<th style="text-align: right;"><asp:Label ID="lbltotalsummary3" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
															</tr>
															<tr>
																<th colspan="5"></th>
																<th>Allowed FTC（Art。24)</th>
																<th style="text-align: right;"><asp:Label ID="totalsummary4" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
															</tr>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 8</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Irregular Overseas Income</h5>
													</div>
													<div class="panel-body">
														<table id="irregulartable" class="table table-bordered datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;">Type of income - in English</th>
																	<th style="text-align: center;">Type of income - in Indonesian</th>
																	<th style="text-align: center;">Name of original Currency</th>
																	<th style="text-align: center;">Amount in original currency</th>
																	<th style="text-align: center;">Amount of Income (IDR)</th>
																	<th style="text-align: center;">Tax paid/withheld (IDR)</th>
																	<th style="text-align: center;">Allowed Art. 24</th>
																	<th style="text-align: center;"></th>
																</tr>
															</thead>
															<tbody>

															</tbody>
															<tr>
																<th colspan="4">Sub Total</th>
																<th style="text-align: right;"><asp:Label ID="tabirregulartotal1" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
																<th style="text-align: right;"><asp:Label ID="tabirregulartotal2" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
																<th style="text-align: right;"><asp:Label ID="tabirregulartotal3" runat="server" Text="0" ClientIDMode="Static"></asp:Label></th>
																<th style="text-align: right;"></th>
															</tr>
														</table>
													</div>
												</div>
											</div>
										</fieldset>
									</form>
								</div>

								<div class="tab-pane" id="assets-liabilities">
									<form class="steps-basic" action="#">
										<h6>Step 1</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Cash And Cash Equivalent</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(1, 'Cash And Cash Equivalent')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable1" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ID="tabasset1" runat="server" Text="0" ClientIDMode="Static"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 2</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Receivables</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(2, 'Receivables')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable2" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset2" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 3</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Investments</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(3, 'Investments')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable3" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset3" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 4</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">MEAN OF TRANSPORTAION</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(4, 'MEAN OF TRANSPORTAION')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i class="icon-plus3 position-left"></i>
																Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable4" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset4" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 5</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">OTHER MOVEABLE PROPERTY</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(5, 'OTHER MOVEABLE PROPERTY')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable5" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset5" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 6</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">REAL PROPERTY</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(6, 'REAL PROPERTY')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable6" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Acquisition Price/Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Acquisition Price/Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset6" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 7</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Liabilities</h5>
														<div class="heading-elements">
															<a onclick="OverseasAsset(10, 'Liabilities')" type="button" class="btn btn-primary" data-toggle="modal" data-target="#asset-form-1770"><i
																 class="icon-plus3 position-left"></i> Add</a>
														</div>
													</div>
													<div class="panel-body">
														<table id="assetTable10" class="table table-bordered table-striped datatable-responsive">
															<thead>
																<tr>
																	<th style="text-align: center;" rowspan="2">No</th>
																	<th style="text-align: center;" rowspan="2">Reference Number</th>
																	<th style="text-align: center;" rowspan="2">Description</th>
																	<th style="text-align: center;" rowspan="2">Details (Bank's Name/Others)</th>
																	<th style="text-align: center;" rowspan="2">Balance Date</th>
																	<th style="text-align: center;" rowspan="2">Currency</th>
																	<th style="text-align: center;" colspan="3">Oustanding Balance</th>
																	<th style="text-align: center;" rowspan="2">Action</th>
																</tr>
																<tr>
																	<th style="text-align: center;">In Original Currency</th>
																	<th style="text-align: center;">Applicable Tax Exchange Rate</th>
																	<th style="text-align: center;">In Rupiah</th>
																</tr>
															</thead>
															<tbody>
																
															</tbody>
															<tfoot>
																<tr class="bg-info-300 text-bold">
																	<th colspan="8">Sub Total</th>
																	<th style="text-align: right;">
                                                                        <asp:Label ClientIDMode="Static" ID="tabasset10" runat="server" Text="0"></asp:Label>
                                                                    </th>
																	<th></th>
																</tr>
															</tfoot>
														</table>
													</div>
												</div>
											</div>
										</fieldset>

										<h6>Step 8</h6>
										<fieldset>
											<div class="row">
												<div class="panel panel-flat">
													<div class="panel-heading">
														<h5 class="panel-title">Net Assets</h5>
													</div>
													<div class="panel-body">
														<div class="table-responsive">
															<table class="table table-bordered table-hover">
																<tr>
																	<td>Total Assets</td>
																	<td>
																		<input style="text-align: right;" runat="server" clientidmode="Static" id="tab3nettotalasset" type="text" class="form-control border-info text-info" readonly="readonly" />
																	</td>
																</tr>
																<tr>
																	<td>Total Liabilities</td>
																	<td>
																		<input style="text-align: right;" runat="server" clientidmode="Static" id="tab3nettotalliabilities" type="text" class="form-control border-info text-info" readonly="readonly" />
																	</td>
																</tr>
																<tr>
																	<td class="text-semibold">Net Assets</td>
																	<td>
																		<input style="text-align: right;" runat="server" clientidmode="Static" id="tab3netasset" type="text" class="form-control border-info text-info" readonly="readonly" />
																	</td>
																</tr>
															</table>
														</div>
													</div>
												</div>
											</div>
										</fieldset>
									</form>
								</div>
                            </div>
	                    </div>
                    </div>
				</div>
			</div>
		</div>
	</div>

	<div id="list-family-form-1770" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="closemodal_general(1)">&times;</button>
					<h5 class="modal-title">List of Family</h5>
				</div>
				<div class="modal-body">
                    
                    <div class="form-group form-group-padding">
                        <input type="hidden" id="familyid" />
						<label class="control-label col-sm-4">Name <span class="text-danger">*</span></label>
						<div class="col-sm-8">
							<input type="text" name="nameFamily" id="nameFamily" 
                                class="form-control required" clientidmode="Static" />
						</div>
                        <div id="lblerrorFamily1" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					    </div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-4">Relationship <span class="text-danger">*</span></label>	
                        <div class="col-sm-8">
                            <select name="relationshipFamily" id="relationshipFamily" data-placeholder="Choose an option" class="select-simple required">
								<option></option>
							</select>
                        </div>
                        <div id="lblerrorFamily2" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					    </div>
					</div>
					<div style="display:none;" class="form-group form-group-padding">
						<label class="control-label col-sm-4">Birthdate </label>
						<div class="col-sm-8">
							<input type="text" name="birthdateFamily" id="birthdateFamily" class="form-control datepicker" placeholder="dd/mm/yyyy" />
                            
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-4">NIK </label>
						<div class="col-sm-8">
							<input type="text" maxlength="16" name="nikFamily" id="nikFamily" class="form-control" />
                            
						</div>
					</div>
					<div class="form-group form-group-padding">
						<label class="control-label col-sm-4">Any Occupation? </label>
						<div class="col-sm-8">
                            <select name="occupationFamily" id="occupationFamily" data-placeholder="Choose an option" class="select-simple">
								<option></option>
								<option value="House Wife">House Wife</option>
								<option value="Employee">Employee</option>
								<option value="Student">Student</option>
								<option value="-">-</option>
							</select>
						</div>
					</div>
				</div>
				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal" onclick="closemodal_general(1)">Cancel</button>
					<button class="btn btn-primary" id="btnSaveFamilyAdd"
                        onclick="SaveFamily(1);return false;">Save and Add Another<i class="icon-floppy-disk position-right"></i></button>
					<button class="btn btn-primary" id="btnSaveFamily"
                        onclick="SaveFamily(0);return false;">Save and Close<i class="icon-floppy-disk position-right"></i></button>
				</div>
			</div>
		</div>
	</div>

	<div id="indonesian-employment-income-1770" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="closemodal_general(2)">&times;</button>
					<h5 class="modal-title">INDONESIAN EMPLOYMENT INCOME (AS STATED IN THE FORMS 1721A1/A2)</h5>
				</div>
				<div class="panel panel-flat">
					<div class="panel-body">
                        
						<div class="tabbable tab-content-bordered">
							<ul class="nav nav-tabs nav-tabs-highlight">
								<li class="active"><a href="#qualitative-info" data-toggle="tab">Qualitative Info</a></li>
								<li><a href="#quantitative-info" data-toggle="tab">Quantitative Info</a></li>
							</ul>
							<div class="tab-content">
								<div class="tab-pane has-padding active" id="qualitative-info">
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6">
												<label>Working Period (From) <span class="text-danger">*</span></label>
												<div class="input-group">
													<input id="iefield1" type="text" name="working-period-from" class="form-control datepicker required" placeholder="dd/mm/yyyy"
														readonly="readonly" onchange="CalculatePeriode(this)" />
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
											<div class="col-sm-6">
												<label>Working Period (To) <span class="text-danger">*</span></label>
												<div class="input-group">
													<input id="iefield2" type="text" name="working-period-to" class="form-control datepicker required" placeholder="dd/mm/yyyy"
														readonly="readonly" onchange="CalculatePeriode(this)" />
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
										</div>
									</div>
                                    <div class="row">
                                        <div class="form-group col-sm-6" >
                                            <label id="lblerrorIEIncome1" class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                    </div>
                                        <div class="form-group col-sm-6" >
                                            <label id="lblerrorIEIncome2" class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                    </div>
                                    </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Number of Period</label>
												<input id="iefield3" type="text" name="" class="form-control border-info text-info" readonly="readonly" />
											</div>
										</div>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Name of Employer <span class="text-danger">*</span></label>
												<input ID="iefield4" type="text" name="name-of-employer" class="form-control required" />
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncome4" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Employer's Tax ID Number <span class="text-danger">*</span></label>
												<div class="form-group">
													<input ID="iefield5" type="text" name="employer's-tax-id-number" class="form-control required" data-mask="99-999-999-9-999-999" />
												</div>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncome5" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Number of Withholding Tax Slip </label>
												<input ID="iefield6" type="text" name="number-of-withholding-tax-slip" class="form-control required" data-mask="9-9-99-99-9999999" />
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncome6" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Date of Withholding Tax Slip  </label>
												<div class="input-group">
													<input ID="iefield7" type="text" name="date-of-withholding-tax-slip" class="form-control datepicker required"
														placeholder="dd/mm/yyyy" readonly="readonly" />
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncome7" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Rounding Down <span class="text-danger">*</span></label>
                                                <select ID="iefield8" data-placeholder="Choose an option" class="select-simple required">
                                                    <option Value=""></option>
                                                    <option Value="Yes">Yes</option>
                                                    <option Value="No">No</option>
                                                </select>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncome8" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
								</div>
								<div class="tab-pane has-padding" id="quantitative-info">
									<div class="row">
										<div class="col-md-6">
											<fieldset>
												<legend class="text-semibold">Gross Income</legend>
												<div class="form-group">
													<label>Salaries/pension payment/old-age savings </label>
													<div class="money">
														<input id="iefield9" type="text" name="salaries" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome9" class="form-group ">
                                                    <label class="control-label col-sm-12"></label>
					                            </div>
												<div class="form-group">
													<label>Income tax allowance </label>
													<div class="money">
														<input id="iefield10" type="text" name="income-tax-allowance" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome10" class="form-group ">
                                                    <label class="control-label col-sm-12"></label>
					                            </div>
												<div class="form-group">
													<label>Other allowances, cash compensation, overtime, etc </label>
													<div class="money">
														<input id="iefield11" type="text" name="other-allowances" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome11" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Honorarium, and other similar remuneration </label>
													<div class="money">
														<input id="iefield12" type="text" name="honorarium" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome12" class="form-group ">
                                                    <label class="control-label col-sm-12"></label>
					                            </div>
												<div class="form-group">
													<label>Employer-provided insurance premiums </label>
													<div class="money">
														<input id="iefield13" type="text" name="insurance" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome13" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Benefits-in-kind which have been subject to PPh 21 </label>
													<div class="money">
														<input id="iefield14" type="text" name="benefits" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome14" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Tantiem,bonuses,gratuities,production comepnsation, THR </label>
													<div class="money">
														<input id="iefield15" type="text" name="tantiem" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome15" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group money">
													<label>Total</label>
                                                    <div class="money">
													    <input id="iefield16" type="text" class="form-control border-info text-info" readonly="readonly" />
												    </div>
                                                </div>
											</fieldset>
                                            <fieldset>
												<legend class="text-semibold">Deductions</legend>
												<div class="form-group">
													<label>Occupational Costs </label>
													<div class="money">
														<input id="iefield17" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome17" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Pension costs </label>
													<div class="money">
														<input id="iefield24" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome24" class="form-group "><label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Pension and old-age saving contributions </label>
													<div class="money">
														<input id="iefield18" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome18" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group money">
													<label>Total</label>
													<input id="iefield19" type="text" class="form-control border-info text-info" readonly="readonly" />
												</div>
												<div class="form-group">
													<label class="text-semibold">NET INCOME</label>
													<div class="money">
														<input id="iefield20" type="text" class="form-control border-info text-info" readonly="readonly" />
													</div>
												</div>
											</fieldset>
										</div>
										<div class="col-md-6">
											<fieldset>
												<legend class="text-semibold">Previous Employer</legend>
												<div class="form-group">
													<label>Net income </label>
													<div class="money">
														<input id="iefield22" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome22" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Income tax withheld </label>
													<div class="money">
														<input id="iefield23" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncome23" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group money">
													<label>TOTAL NET INCOME</label>
													<input id="iefield25" type="text" class="form-control  text-info" />
												</div>
												<div class="form-group money">
													<label>ANNUALIZED NET INCOME</label>
													<input id="iefield26" type="text" class="form-control  numberOnly" />
												</div>
												<div class="form-group money">
													<label>ANNUALIZED INCOME TAX</label>
													<input id="iefield27" value="0" type="text" class="form-control  numberOnly" />
												</div>
												<div class="form-group">
													<label class="text-semibold">INCOME TAX WITHHELD </label>
													<div class="money">
														<input id="iefield21" type="text" class="form-control  numberOnly"/>
													</div>
                                                    <div id="lblerrorIEIncome21" class="form-group ">
                                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                                </div>
												</div>
                                                
											</fieldset>
                                            <fieldset>
												<legend class="text-semibold">Total</legend>
												<div class="form-group money">
													<label>Net income </label>
													<input id="iefield28" type="text" class="form-control  numberOnly" />
												</div>
												<div class="form-group money">
													<label>Income tax withheld </label>
													<input id="iefield29" type="text" class="form-control  numberOnly" />
												</div>
											</fieldset>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>

				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal" onclick="closemodal_general(2)">Cancel</button>
					<button ID="btnSaveIEIncomeAdd" class="btn btn-primary" 
                        onclick="SaveIEIncome(1); return false;">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
					<button ID="btnSaveIEIncome" class="btn btn-primary" 
                        onclick="SaveIEIncome(0); return false;">Save and Close<i class="icon-floppy-disk position-right"></i></button>
				</div>
			</div>
		</div>
	</div>

    <div id="indonesian-employment-income-1770-edit" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="closemodal_general(2)">&times;</button>
					<h5 class="modal-title">INDONESIAN EMPLOYMENT INCOME (AS STATED IN THE FORMS 1721A1/A2)</h5>
				</div>
				<div class="panel panel-flat">
					<div class="panel-body">
						<div class="tabbable tab-content-bordered">
							<ul class="nav nav-tabs nav-tabs-highlight">
								<li class="active"><a href="#qualitative-info-edit" data-toggle="tab">Qualitative Info</a></li>
								<li><a href="#quantitative-info-edit" data-toggle="tab">Quantitative Info</a></li>
							</ul>
							<div class="tab-content">
								<div class="tab-pane has-padding active" id="qualitative-info-edit">
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6">
												<label>Working Period (From) <span class="text-danger">*</span></label>
												<div class="input-group">
													<input type="hidden" id="IEIncomeID" />
													<input ID="iefieldedit1" type="text" name="working-period-from" class="form-control datepicker required" placeholder="dd/mm/yyyy"
														readonly="readonly" onchange="CalculatePeriodeedit(this)" />
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
											<div class="col-sm-6">
												<label>Working Period (To) <span class="text-danger">*</span></label>
												<div class="input-group">
													<input ID="iefieldedit2" type="text" name="working-period-to" class="form-control datepicker required" placeholder="dd/mm/yyyy"
														readonly="readonly" onchange="CalculatePeriodeedit(this)"/>
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
										</div>
									</div>
                                    
                                    <div class="row">
                                        <div class="form-group col-sm-6" >
                                            <label id="lblerrorIEIncomeedit1" class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                    </div>
                                        <div class="form-group col-sm-6" >
                                            <label id="lblerrorIEIncomeedit2" class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                    </div>
                                    </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Number of Period</label>
												<input ID="iefieldedit3" type="number" name="" class="form-control border-info text-info" readonly="readonly" />
											</div>
										</div>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Name of Employer <span class="text-danger">*</span></label>
												<input ID="iefieldedit4" type="text" name="name-of-employer" class="form-control required" />
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncomeedit4" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Employer's Tax ID Number <span class="text-danger">*</span></label>
												<div class="form-group">
													<input ID="iefieldedit5" type="text" name="employer's-tax-id-number" class="form-control required" data-mask="99-999-999-9-999-999" />
												</div>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncomeedit5" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Number of Withholding Tax Slip </label>
												<input ID="iefieldedit6" type="text" name="number-of-withholding-tax-slip" class="form-control required" data-mask="9-9-99-99-9999999" />
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncomeedit6" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Date of Withholding Tax Slip  </label>
												<div class="input-group">
													<input ID="iefieldedit7" type="text" name="date-of-withholding-tax-slip" class="form-control datepicker required"
														placeholder="dd/mm/yyyy" readonly="readonly" />
													<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												</div>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncomeedit7" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-12">
												<label>Rounding Down <span class="text-danger">*</span></label>
                                                <select ID="iefieldedit8" data-placeholder="Choose an option" class="select-simple required">
                                                    <option Value=""></option>
                                                    <option Value="Yes">Yes</option>
                                                    <option Value="No">No</option>
                                                </select>
											</div>
										</div>
									</div>
                                    <div id="lblerrorIEIncomeedit8" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                </div>
								</div>
								<div class="tab-pane has-padding" id="quantitative-info-edit">
									<div class="row">
										<div class="col-md-6">
											<fieldset>
												<legend class="text-semibold">Gross Income</legend>
												<div class="form-group">
													<label>Salaries/pension payment/old-age savings </label>
													<div class="money">
														<input ID="iefieldedit9" type="text" name="salaries" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit9" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Income tax allowance </label>
													<div class="money">
														<input ID="iefieldedit10" type="text" name="income-tax-allowance" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit10" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Other allowances, cash compensation, overtime, etc </label>
													<div class="money">
														<input ID="iefieldedit11" type="text" name="other-allowances" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit11" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Honorarium, and other similar remuneration </label>
													<div class="money">
														<input ID="iefieldedit12" type="text" name="honorarium" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit12" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Employer-provided insurance premiums </label>
													<div class="money">
														<input ID="iefieldedit13" type="text" name="insurance" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit13" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Benefits-in-kind which have been subject to PPh 21 </label>
													<div class="money">
														<input ID="iefieldedit14" type="text" name="benefits" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit14" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Tantiem,bonuses,gratuities,production comepnsation, THR </label>
													<div class="money">
														<input ID="iefieldedit15" type="text" name="tantiem" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit15" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group money">
													<label>Total</label>
													<input ID="iefieldedit16" type="text" class="form-control border-info text-info" readonly="readonly" />
												</div>
											</fieldset>
                                            <fieldset>
												<legend class="text-semibold">Deductions</legend>
												<div class="form-group">
													<label>Occupational Costs </label>
													<div class="money">
														<input ID="iefieldedit17" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
												<div class="form-group">
													<label>Pension costs </label>
													<div class="money">
														<input ID="iefieldedit24" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit24" class="form-group "><label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Pension and old-age saving contributions </label>
													<div class="money">
														<input ID="iefieldedit18" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
												<div class="form-group">
													<label>Total</label>
                                                    <div class="money">
													    <input ID="iefieldedit19" type="text" class="form-control border-info text-info" readonly="readonly" />
                                                    </div>
												</div><div class="form-group">
													<label class="text-semibold">NET INCOME</label>
													<div class="money">
														<input ID="iefieldedit20" type="text" class="form-control border-info text-info" readonly="readonly" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit20" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
											</fieldset>
										</div>
										<div class="col-md-6">
											<fieldset>
												<legend class="text-semibold">Previous Employer</legend>
												<div class="form-group">
													<label>Net income </label>
													<div class="money">
														<input ID="iefieldedit22" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit22" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group">
													<label>Income tax withheld </label>
													<div class="money">
														<input ID="iefieldedit23" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit23" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
												<div class="form-group money">
													<label>TOTAL NET INCOME</label>
													<input ID="iefieldedit25" type="text" class="form-control  numberOnly"  />
												</div>
												<div class="form-group money">
													<label>ANNUALIZED NET INCOME</label>
													<input ID="iefieldedit26" type="text" class="form-control  numberOnly"  />
												</div>
												<div class="form-group money">
													<label>ANNUALIZED INCOME TAX</label>
													<input ID="iefieldedit27" type="text" value="0" class="form-control  numberOnly"  />
												</div>
                                                <div class="form-group">
													<label class="text-semibold">INCOME TAX WITHHELD </label>
													<div class="money">
														<input ID="iefieldedit21" type="text" class="form-control numberOnly" placeholder="0.00" />
													</div>
												</div>
                                                <div id="lblerrorIEIncomeedit21" class="form-group ">
                                                    <label class="control-label col-sm-12"><span class="text-danger">This field is required</span></label>
					                            </div>
											</fieldset>
                                            <fieldset>
												<legend class="text-semibold">Total</legend>
												<div class="form-group money">
													<label>Net income </label>
													<input ID="iefieldedit28" type="text" class="form-control  numberOnly" />
												</div>
												<div class="form-group money">
													<label>Income tax withheld </label>
													<input ID="iefieldedit29" type="text" class="form-control  numberOnly" />
												</div>
											</fieldset>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>

				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal" onclick="closemodal_general(2)">Cancel</button>
					<button ID="Button2" class="btn btn-primary" 
                        onclick="SaveEditIEIncome();return false;">Save <i class="icon-floppy-disk position-right"></i></button>
				</div>
			</div>
		</div>
	</div>

	<div id="indonesian-employment-income-1770-detail" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<h5 class="modal-title">Detail Employee</h5>
				</div>
				<div class="form-horizontal">
					<div class="modal-body">
						<div class="form-group">
							<label class="control-label col-sm-3">Working Period</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil0" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Number of Period</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil3" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Name of Employer</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil4" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Employer's Tax ID Number</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil5" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Number of Withholding Tax Slip</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil6" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Date of Withholding Tax Slip</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil7" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Rounding Down</label>
							<div class="col-sm-9">
								<input type="text" id="iedetil8" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<legend class="text-bold">Gross Income</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Salaries/pension payment/old-age savings</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil9" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Income tax allowance</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil10" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Other allowances, cash compensation, overtime, etc.</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil11" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Honorarium, and other similar remuneration</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil12" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Employer-provided insurance premiumsn</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil13" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Benefits-in-kind which have been subject to PPh 21</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil14" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Tantiem, bonuses, gratuities, production comepnsation, THR</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil15" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">Total</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil16" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<legend class="text-bold">Deductions</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Occupational costs</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil17" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Pension costs</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil24" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Pension and old-age saving contributions</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil18" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">Total</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil19" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">NET INCOME</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil20" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">INCOME TAX WITHHELD</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil21" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<legend class="text-bold">Previous Employer</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Net income</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil22" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Income tax withheld</label>
							<div class="col-sm-9 money">
								<input type="text" id="iedetil23" class="form-control border-info text-info" readonly="readonly">
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
	</div>

	<div id="indonesian-employment-income-1770-total" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<h5 class="modal-title">Total Indonesian Employment Income</h5>
				</div>
				<div class="form-horizontal">
					<div class="modal-body">
						<div class="form-group">
							<label class="control-label col-sm-3">Total Employee</label>
							<div class="col-sm-9">
								<input type="text" clientidmode="Static" runat="server" id="totalemployee" class="form-control border-info text-info" readonly="readonly"  />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Total Number of Period</label>
							<div class="col-sm-9">
								<input type="text" clientidmode="Static" runat="server" id="totalperiod" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<legend class="text-bold">Gross Income</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Salaries/pension payment/old-age savings</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalsalaries" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Income tax allowance</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Other allowances, cash compensation, overtime, etc.</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalother" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Honorarium, and other similar remuneration</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalhonorarium" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Employer-provided insurance premiumsn</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalinsurance" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Benefits-in-kind which have been subject to PPh 21</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalbenefit" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Tantiem, bonuses, gratuities, production comepnsation, THR</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalbonus" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">Total</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalgross" class="form-control border-info text-info" readonly="readonly"/>
							</div>
						</div>
						<legend class="text-bold">Deductions</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Occupational costs</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalcost" class="form-control border-info text-info" readonly="readonly"/>
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Pension costs</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalpensioncost" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Pension and old-age saving contributions</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalpension" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">Total</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totaldeductions" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">NET INCOME</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalnetincome" class="form-control border-info text-info" readonly="readonly"/>
							</div>
						</div>
						<legend class="text-bold">Previous Employer</legend>
						<div class="form-group">
							<label class="control-label col-sm-3">Net income</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalprevnetincome" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Income tax withheld</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalprevincometax" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">TOTAL NET INCOME</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome25" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">ANNUALIZED NET INCOME</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome26" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">ANNUALIZED INCOME TAX</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome27" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3 text-bold">INCOME TAX WITHHELD</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincometax" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
                        <legend class="text-bold">TOTAL</legend>
                        <div class="form-group">
							<label class="control-label col-sm-3">Net income</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome28" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
                        <div class="form-group">
							<label class="control-label col-sm-3">Income tax withheld</label>
							<div class="col-sm-9 money">
								<input type="text" clientidmode="Static" runat="server" id="totalincome29" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
	</div>

	<div id="income-form-1770-s123" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="">&times;</button>
					<h5 ID="lblTitleIncome" ClientIDMode="Static" class="modal-title">
                    </h5>
				</div>
				<div class="panel panel-flat">
					<div class="panel-body">
						<div class="row">
							<div class="col-md-6">
								<fieldset>
									<legend ID="lblLegendIncome" runat="server" ClientIDMode="Static" class="text-semibold">
                                    </legend>
									<input type="hidden" id="typeincome" />
									<input type="hidden" id="overseasincomeid" />
                                    
                                    <div class="form-group">
										<label>Currency <span class="text-danger">*</span></label>
										<select onchange="GetExchRate();" runat="server" clientidmode="Static" id="oi_currency" data-placeholder="Choose an option" class="select">
											<option></option>
										</select>
                                        <input style="display:none;margin-top:5px;" type="text" runat="server" clientidmode="Static" id="oi_currencyother" class="form-control" maxlength="3" />
									</div>
                                    <div id="lblerrorOverseasIncome2" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>

									<div class="form-group">
										<label>Date of Receipt <span class="text-danger">*</span></label>
										<input value="" type="text" runat="server" clientidmode="Static" id="oi_dateofreceipt" class="form-control datepicker" placeholder="dd/mm/yyyy" />
									    <div id="oi_dateofreceiptgroup">
                                            <select onchange="GetExchRate();" runat="server" id="oi_dateofreceipt2_1" clientidmode="Static"  name="oi_dateofreceipt2_1" data-placeholder="Choose an option" class="select">
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
								            </select><br />
                                            <select onchange="GetExchRate();" runat="server" id="oi_dateofreceipt2_2_1" name="" data-placeholder="Choose Year" class="select-simple" clientidmode="Static">
									            <option></option>
								            </select>
                                        </div>
                                    </div>
                                    <div id="lblerrorOverseasIncome3" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group">
										<label>Interval<span class="text-danger">*</span></label>
										<select onchange="GetExchRate();" runat="server" clientidmode="Static" id="oi_interval" data-placeholder="Choose an option" class="select-simple">
											<option></option>
											<option value="1">Weekly</option>
											<option value="2">Monthly</option>
											<option value="3">Yearly</option>
											<option value="4">Broken Year</option>
										</select>
									</div>
                                    <div id="lblerrorOverseasIncome4" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
                                    <div style="display: none;" class="form-group">
										<label>Country of Source <span class="text-danger">*</span></label>
										<select runat="server" clientidmode="Static" id="oi_country" name="" data-placeholder="Choose an option" class="select">
											<option></option>
											<option value="Afganistan">Afghanistan</option>
											<option value="Albania">Albania</option>
											<option value="Algeria">Algeria</option>
											<option value="American Samoa">American Samoa</option>
											<option value="Andorra">Andorra</option>
											<option value="Angola">Angola</option>
											<option value="Anguilla">Anguilla</option>
											<option value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</option>
											<option value="Argentina">Argentina</option>
											<option value="Armenia">Armenia</option>
											<option value="Aruba">Aruba</option>
											<option value="Australia">Australia</option>
											<option value="Austria">Austria</option>
											<option value="Azerbaijan">Azerbaijan</option>
											<option value="Bahamas">Bahamas</option>
											<option value="Bahrain">Bahrain</option>
											<option value="Bangladesh">Bangladesh</option>
											<option value="Barbados">Barbados</option>
											<option value="Belarus">Belarus</option>
											<option value="Belgium">Belgium</option>
											<option value="Belize">Belize</option>
											<option value="Benin">Benin</option>
											<option value="Bermuda">Bermuda</option>
											<option value="Bhutan">Bhutan</option>
											<option value="Bolivia">Bolivia</option>
											<option value="Bonaire">Bonaire</option>
											<option value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</option>
											<option value="Botswana">Botswana</option>
											<option value="Brazil">Brazil</option>
											<option value="British Indian Ocean Ter">British Indian Ocean Ter</option>
											<option value="Brunei">Brunei</option>
											<option value="Bulgaria">Bulgaria</option>
											<option value="Burkina Faso">Burkina Faso</option>
											<option value="Burundi">Burundi</option>
											<option value="Cambodia">Cambodia</option>
											<option value="Cameroon">Cameroon</option>
											<option value="Canada">Canada</option>
											<option value="Canary Islands">Canary Islands</option>
											<option value="Cape Verde">Cape Verde</option>
											<option value="Cayman Islands">Cayman Islands</option>
											<option value="Central African Republic">Central African Republic</option>
											<option value="Chad">Chad</option>
											<option value="Channel Islands">Channel Islands</option>
											<option value="Chile">Chile</option>
											<option value="China">China</option>
											<option value="Christmas Island">Christmas Island</option>
											<option value="Cocos Island">Cocos Island</option>
											<option value="Colombia">Colombia</option>
											<option value="Comoros">Comoros</option>
											<option value="Congo">Congo</option>
											<option value="Cook Islands">Cook Islands</option>
											<option value="Costa Rica">Costa Rica</option>
											<option value="Cote DIvoire">Cote D'Ivoire</option>
											<option value="Croatia">Croatia</option>
											<option value="Cuba">Cuba</option>
											<option value="Curaco">Curacao</option>
											<option value="Cyprus">Cyprus</option>
											<option value="Czech Republic">Czech Republic</option>
											<option value="Denmark">Denmark</option>
											<option value="Djibouti">Djibouti</option>
											<option value="Dominica">Dominica</option>
											<option value="Dominican Republic">Dominican Republic</option>
											<option value="East Timor">East Timor</option>
											<option value="Ecuador">Ecuador</option>
											<option value="Egypt">Egypt</option>
											<option value="El Salvador">El Salvador</option>
											<option value="Equatorial Guinea">Equatorial Guinea</option>
											<option value="Eritrea">Eritrea</option>
											<option value="Estonia">Estonia</option>
											<option value="Ethiopia">Ethiopia</option>
											<option value="Falkland Islands">Falkland Islands</option>
											<option value="Faroe Islands">Faroe Islands</option>
											<option value="Fiji">Fiji</option>
											<option value="Finland">Finland</option>
											<option value="France">France</option>
											<option value="French Guiana">French Guiana</option>
											<option value="French Polynesia">French Polynesia</option>
											<option value="French Southern Ter">French Southern Ter</option>
											<option value="Gabon">Gabon</option>
											<option value="Gambia">Gambia</option>
											<option value="Georgia">Georgia</option>
											<option value="Germany">Germany</option>
											<option value="Ghana">Ghana</option>
											<option value="Gibraltar">Gibraltar</option>
											<option value="Great Britain">Great Britain</option>
											<option value="Greece">Greece</option>
											<option value="Greenland">Greenland</option>
											<option value="Grenada">Grenada</option>
											<option value="Guadeloupe">Guadeloupe</option>
											<option value="Guam">Guam</option>
											<option value="Guatemala">Guatemala</option>
											<option value="Guinea">Guinea</option>
											<option value="Guyana">Guyana</option>
											<option value="Haiti">Haiti</option>
											<option value="Hawaii">Hawaii</option>
											<option value="Honduras">Honduras</option>
											<option value="Hong Kong">Hong Kong</option>
											<option value="Hungary">Hungary</option>
											<option value="Iceland">Iceland</option>
											<option value="India">India</option>
											<option value="Indonesia">Indonesia</option>
											<option value="Iran">Iran</option>
											<option value="Iraq">Iraq</option>
											<option value="Ireland">Ireland</option>
											<option value="Isle of Man">Isle of Man</option>
											<option value="Israel">Israel</option>
											<option value="Italy">Italy</option>
											<option value="Jamaica">Jamaica</option>
											<option value="Japan">Japan</option>
											<option value="Jordan">Jordan</option>
											<option value="Kazakhstan">Kazakhstan</option>
											<option value="Kenya">Kenya</option>
											<option value="Kiribati">Kiribati</option>
											<option value="Korea North">Korea North</option>
											<option value="Korea Sout">Korea South</option>
											<option value="Kuwait">Kuwait</option>
											<option value="Kyrgyzstan">Kyrgyzstan</option>
											<option value="Laos">Laos</option>
											<option value="Latvia">Latvia</option>
											<option value="Lebanon">Lebanon</option>
											<option value="Lesotho">Lesotho</option>
											<option value="Liberia">Liberia</option>
											<option value="Libya">Libya</option>
											<option value="Liechtenstein">Liechtenstein</option>
											<option value="Lithuania">Lithuania</option>
											<option value="Luxembourg">Luxembourg</option>
											<option value="Macau">Macau</option>
											<option value="Macedonia">Macedonia</option>
											<option value="Madagascar">Madagascar</option>
											<option value="Malaysia">Malaysia</option>
											<option value="Malawi">Malawi</option>
											<option value="Maldives">Maldives</option>
											<option value="Mali">Mali</option>
											<option value="Malta">Malta</option>
											<option value="Marshall Islands">Marshall Islands</option>
											<option value="Martinique">Martinique</option>
											<option value="Mauritania">Mauritania</option>
											<option value="Mauritius">Mauritius</option>
											<option value="Mayotte">Mayotte</option>
											<option value="Mexico">Mexico</option>
											<option value="Midway Islands">Midway Islands</option>
											<option value="Moldova">Moldova</option>
											<option value="Monaco">Monaco</option>
											<option value="Mongolia">Mongolia</option>
											<option value="Montserrat">Montserrat</option>
											<option value="Morocco">Morocco</option>
											<option value="Mozambique">Mozambique</option>
											<option value="Myanmar">Myanmar</option>
											<option value="Nambia">Nambia</option>
											<option value="Nauru">Nauru</option>
											<option value="Nepal">Nepal</option>
											<option value="Netherland Antilles">Netherland Antilles</option>
											<option value="Netherlands">Netherlands (Holland, Europe)</option>
											<option value="Nevis">Nevis</option>
											<option value="New Caledonia">New Caledonia</option>
											<option value="New Zealand">New Zealand</option>
											<option value="Nicaragua">Nicaragua</option>
											<option value="Niger">Niger</option>
											<option value="Nigeria">Nigeria</option>
											<option value="Niue">Niue</option>
											<option value="Norfolk Island">Norfolk Island</option>
											<option value="Norway">Norway</option>
											<option value="Oman">Oman</option>
											<option value="Pakistan">Pakistan</option>
											<option value="Palau Island">Palau Island</option>
											<option value="Palestine">Palestine</option>
											<option value="Panama">Panama</option>
											<option value="Papua New Guinea">Papua New Guinea</option>
											<option value="Paraguay">Paraguay</option>
											<option value="Peru">Peru</option>
											<option value="Phillipines">Philippines</option>
											<option value="Pitcairn Island">Pitcairn Island</option>
											<option value="Poland">Poland</option>
											<option value="Portugal">Portugal</option>
											<option value="Puerto Rico">Puerto Rico</option>
											<option value="Qatar">Qatar</option>
											<option value="Republic of Montenegro">Republic of Montenegro</option>
											<option value="Republic of Serbia">Republic of Serbia</option>
											<option value="Reunion">Reunion</option>
											<option value="Romania">Romania</option>
											<option value="Russia">Russia</option>
											<option value="Rwanda">Rwanda</option>
											<option value="St Barthelemy">St Barthelemy</option>
											<option value="St Eustatius">St Eustatius</option>
											<option value="St Helena">St Helena</option>
											<option value="St Kitts-Nevis">St Kitts-Nevis</option>
											<option value="St Lucia">St Lucia</option>
											<option value="St Maarten">St Maarten</option>
											<option value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</option>
											<option value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</option>
											<option value="Saipan">Saipan</option>
											<option value="Samoa">Samoa</option>
											<option value="Samoa American">Samoa American</option>
											<option value="San Marino">San Marino</option>
											<option value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</option>
											<option value="Saudi Arabia">Saudi Arabia</option>
											<option value="Senegal">Senegal</option>
											<option value="Serbia">Serbia</option>
											<option value="Seychelles">Seychelles</option>
											<option value="Sierra Leone">Sierra Leone</option>
											<option value="Singapore">Singapore</option>
											<option value="Slovakia">Slovakia</option>
											<option value="Slovenia">Slovenia</option>
											<option value="Solomon Islands">Solomon Islands</option>
											<option value="Somalia">Somalia</option>
											<option value="South Africa">South Africa</option>
											<option value="Spain">Spain</option>
											<option value="Sri Lanka">Sri Lanka</option>
											<option value="Sudan">Sudan</option>
											<option value="Suriname">Suriname</option>
											<option value="Swaziland">Swaziland</option>
											<option value="Sweden">Sweden</option>
											<option value="Switzerland">Switzerland</option>
											<option value="Syria">Syria</option>
											<option value="Tahiti">Tahiti</option>
											<option value="Taiwan">Taiwan</option>
											<option value="Tajikistan">Tajikistan</option>
											<option value="Tanzania">Tanzania</option>
											<option value="Thailand">Thailand</option>
											<option value="Togo">Togo</option>
											<option value="Tokelau">Tokelau</option>
											<option value="Tonga">Tonga</option>
											<option value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</option>
											<option value="Tunisia">Tunisia</option>
											<option value="Turkey">Turkey</option>
											<option value="Turkmenistan">Turkmenistan</option>
											<option value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</option>
											<option value="Tuvalu">Tuvalu</option>
											<option value="Uganda">Uganda</option>
											<option value="Ukraine">Ukraine</option>
											<option value="United Arab Erimates">United Arab Emirates</option>
											<option value="United Kingdom">United Kingdom</option>
											<option value="United States of America">United States of America</option>
											<option value="Uraguay">Uruguay</option>
											<option value="Uzbekistan">Uzbekistan</option>
											<option value="Vanuatu">Vanuatu</option>
											<option value="Vatican City State">Vatican City State</option>
											<option value="Venezuela">Venezuela</option>
											<option value="Vietnam">Vietnam</option>
											<option value="Virgin Islands (Brit)">Virgin Islands (Brit)</option>
											<option value="Virgin Islands (USA)">Virgin Islands (USA)</option>
											<option value="Wake Island">Wake Island</option>
											<option value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</option>
											<option value="Yemen">Yemen</option>
											<option value="Zaire">Zaire</option>
											<option value="Zambia">Zambia</option>
											<option value="Zimbabwe">Zimbabwe</option>
										</select>
									</div>
                                    <div id="lblerrorOverseasIncome1" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>

									
									<div class="form-group money">
										<label>Appl. Exch. Rate</label>
										<input type="text" runat="server" clientidmode="Static" id="oi_exchrate" class="form-control border-info text-info numberOnly2" readonly="readonly" disabled="disabled" />
									</div>

                                    
								    <div class="form-group" id="oi_irregularincomediv">
									    <label class="text-semibold">Irregular Income <span class="text-danger">*</span></label>
									    <select runat="server" clientidmode="Static" id="oi_irregularincome" data-placeholder="Choose irregular income if any" class="select-simple">
										    <option></option>
										    <option value="yes">Yes</option>
										    <option value="no">No</option>
									    </select>
								    </div>
                                    <div id="lblerrorOverseasIncome6" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>

								</fieldset>
							</div>
							<div class="col-md-6">
								<fieldset>
									<legend class="text-semibold">Amount in Original Currency</legend>
									<div class="form-group">
										<label>Gross Income <span class="text-danger">*</span></label>
										<div class="money">
											<input runat="server" clientidmode="Static" id="oi_incomecurrency" type="text" class="form-control numberOnly2" placeholder="0.00" />
										</div>
									</div>
                                    <div id="lblerrorOverseasIncome5" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group">
										<label>Tax paid /withheld</label>
										<div class="money">
											<input type="text" runat="server" clientidmode="Static" id="oi_taxpaidcurrency" class="form-control numberOnly2" placeholder="0.00" />
										</div>
									</div>
									<legend class="text-semibold">Amount in Rupiah</legend>
									<div class="form-group money">
										<label>Income</label>
										<input type="text" runat="server" clientidmode="Static" id="oi_incomerp" class="form-control border-info text-info" readonly="readonly" disabled="disabled" />
									</div>
									<div class="form-group money">
										<label>Tax paid /withheld</label>
										<input type="text" runat="server" clientidmode="Static" id="oi_taxpaidrp" class="form-control border-info text-info" readonly="readonly" disabled="disabled" />
									</div>
								</fieldset>
							</div>
							<div style="display: none;" class="col-md-6">
								<div class="form-group">
									<label>Treaty Rate (%)</label>
									<div class="input-group">
										<input type="text" runat="server" clientidmode="Static" id="oi_treatyrate" maxlength="2" name="" class="form-control  numberOnly" placeholder="Enter value in %" />
										<span class="input-group-addon">%</span>
									</div>
								</div>
							</div>
							<div class="col-md-6">
								<div style="display: none;" class="form-group">
									<label class="text-semibold">FTC based on treaty</label>
									<input type="text" runat="server" clientidmode="Static" id="oi_ftc" class="form-control border-info text-info" readonly="readonly" disabled="disabled" />
								</div>
								<div style="display: none;" class="form-group">
									<label class="text-semibold">Allowed FTC</label>
									<input type="text" runat="server" clientidmode="Static" id="oi_allowedftc" class="form-control border-info text-info" readonly="readonly" disabled="disabled" />
								</div>
							</div>
						</div>
					</div>
				</div>

				<div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal" onclick="">Cancel</button>
					<button id="btnSaveAddIncome" type="submit" class="btn btn-primary" onclick="SaveOverseasIncome(1); return false;">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
					<button type="submit" class="btn btn-primary" onclick="SaveOverseasIncome(0); return false;">Save and Close<i class="icon-floppy-disk position-right"></i></button>
				</div>
			</div>
		</div>
	</div>

	<div id="asset-form-1770" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="closemodal_asset()">&times;</button>
					<h5 id="astitle" class="modal-title"></h5>
				</div>
				<form action="#">
					<div class="panel panel-flat">
						<div class="panel-body">
							<div class="row">
                                <div id="llberrorasset" class="form-group ">
                                    <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					            </div>
								<div class="col-md-6">
									<fieldset>
										<div class="form-group">
											<label>Description</label>
                                            <input type="hidden" id="astype" />
									        <input type="hidden" id="asid" />
											<select onchange="SetRefNumber(this.value);" id="as_description" data-placeholder="Choose an Option" class="select-simple">
												<option></option>
											</select>
										</div>
										<div class="form-group">
											<label>Reference Number <span class="text-danger">*</span></label>
											<input id="as_refnumber" type="text" class="form-control border-info text-info" readonly="readonly" />
										</div>
                                        <div id="lblerrorasset1" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
										<div class="form-group">
											<label>Details (Bank's Name/Others) <span class="text-danger">*</span></label>
                                            <input id="as_owner" type="text" class="form-control" />
										</div>
                                        <div id="lblerrorasset2" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
										<div class="form-group">
											<label>Currency <span class="text-danger">*</span></label>
											<select onchange="GetExchRateAsset();" id="as_currency" data-placeholder="Choose an Option" class="select">
												<option></option>
											</select>
                                            <input style="display:none;margin-top:5px;" type="text" runat="server" clientidmode="Static" id="as_currencyother" class="form-control" maxlength="3" />
										</div>
                                        <div id="lblerrorasset3" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
										<div class="form-group">
											<label>Acquisition/Balance Date <span class="text-danger">*</span></label>
											<div class="input-group">
												<input onchange="GetExchRateAsset();" type="text" id="as_balancedate" class="form-control datepicker" placeholder="dd/mm/yyyy" readonly />
												<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
											    <div id="as_dateofreceiptgroup">
                                                    <select onchange="GetExchRateAsset();" runat="server" id="as_dateofreceipt2_1" clientidmode="Static"  name="as_dateofreceipt2_1" data-placeholder="Choose an option" class="select">
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
								                    </select><br />
                                                    <select onchange="GetExchRateAsset();" runat="server" id="as_dateofreceipt2_2_1" name="" data-placeholder="Choose Year" class="select-simple" clientidmode="Static">
									                    <option></option>
								                    </select>
                                                </div>
                                            </div>
										</div>
                                        <div id="lblerrorasset4" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
									</fieldset>
								</div>
								<div class="col-md-6">
									<fieldset>
										<div style="display:none;" class="form-group">
											<label>Country of Source</label>
											<select id="as_country" data-placeholder="Choose an option" class="select ">
												<option></option>
												<option value="Afganistan">Afghanistan</option>
												<option value="Albania">Albania</option>
												<option value="Algeria">Algeria</option>
												<option value="American Samoa">American Samoa</option>
												<option value="Andorra">Andorra</option>
												<option value="Angola">Angola</option>
												<option value="Anguilla">Anguilla</option>
												<option value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</option>
												<option value="Argentina">Argentina</option>
												<option value="Armenia">Armenia</option>
												<option value="Aruba">Aruba</option>
												<option value="Australia">Australia</option>
												<option value="Austria">Austria</option>
												<option value="Azerbaijan">Azerbaijan</option>
												<option value="Bahamas">Bahamas</option>
												<option value="Bahrain">Bahrain</option>
												<option value="Bangladesh">Bangladesh</option>
												<option value="Barbados">Barbados</option>
												<option value="Belarus">Belarus</option>
												<option value="Belgium">Belgium</option>
												<option value="Belize">Belize</option>
												<option value="Benin">Benin</option>
												<option value="Bermuda">Bermuda</option>
												<option value="Bhutan">Bhutan</option>
												<option value="Bolivia">Bolivia</option>
												<option value="Bonaire">Bonaire</option>
												<option value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</option>
												<option value="Botswana">Botswana</option>
												<option value="Brazil">Brazil</option>
												<option value="British Indian Ocean Ter">British Indian Ocean Ter</option>
												<option value="Brunei">Brunei</option>
												<option value="Bulgaria">Bulgaria</option>
												<option value="Burkina Faso">Burkina Faso</option>
												<option value="Burundi">Burundi</option>
												<option value="Cambodia">Cambodia</option>
												<option value="Cameroon">Cameroon</option>
												<option value="Canada">Canada</option>
												<option value="Canary Islands">Canary Islands</option>
												<option value="Cape Verde">Cape Verde</option>
												<option value="Cayman Islands">Cayman Islands</option>
												<option value="Central African Republic">Central African Republic</option>
												<option value="Chad">Chad</option>
												<option value="Channel Islands">Channel Islands</option>
												<option value="Chile">Chile</option>
												<option value="China">China</option>
												<option value="Christmas Island">Christmas Island</option>
												<option value="Cocos Island">Cocos Island</option>
												<option value="Colombia">Colombia</option>
												<option value="Comoros">Comoros</option>
												<option value="Congo">Congo</option>
												<option value="Cook Islands">Cook Islands</option>
												<option value="Costa Rica">Costa Rica</option>
												<option value="Cote DIvoire">Cote D'Ivoire</option>
												<option value="Croatia">Croatia</option>
												<option value="Cuba">Cuba</option>
												<option value="Curaco">Curacao</option>
												<option value="Cyprus">Cyprus</option>
												<option value="Czech Republic">Czech Republic</option>
												<option value="Denmark">Denmark</option>
												<option value="Djibouti">Djibouti</option>
												<option value="Dominica">Dominica</option>
												<option value="Dominican Republic">Dominican Republic</option>
												<option value="East Timor">East Timor</option>
												<option value="Ecuador">Ecuador</option>
												<option value="Egypt">Egypt</option>
												<option value="El Salvador">El Salvador</option>
												<option value="Equatorial Guinea">Equatorial Guinea</option>
												<option value="Eritrea">Eritrea</option>
												<option value="Estonia">Estonia</option>
												<option value="Ethiopia">Ethiopia</option>
												<option value="Falkland Islands">Falkland Islands</option>
												<option value="Faroe Islands">Faroe Islands</option>
												<option value="Fiji">Fiji</option>
												<option value="Finland">Finland</option>
												<option value="France">France</option>
												<option value="French Guiana">French Guiana</option>
												<option value="French Polynesia">French Polynesia</option>
												<option value="French Southern Ter">French Southern Ter</option>
												<option value="Gabon">Gabon</option>
												<option value="Gambia">Gambia</option>
												<option value="Georgia">Georgia</option>
												<option value="Germany">Germany</option>
												<option value="Ghana">Ghana</option>
												<option value="Gibraltar">Gibraltar</option>
												<option value="Great Britain">Great Britain</option>
												<option value="Greece">Greece</option>
												<option value="Greenland">Greenland</option>
												<option value="Grenada">Grenada</option>
												<option value="Guadeloupe">Guadeloupe</option>
												<option value="Guam">Guam</option>
												<option value="Guatemala">Guatemala</option>
												<option value="Guinea">Guinea</option>
												<option value="Guyana">Guyana</option>
												<option value="Haiti">Haiti</option>
												<option value="Hawaii">Hawaii</option>
												<option value="Honduras">Honduras</option>
												<option value="Hong Kong">Hong Kong</option>
												<option value="Hungary">Hungary</option>
												<option value="Iceland">Iceland</option>
												<option value="India">India</option>
												<option value="Indonesia">Indonesia</option>
												<option value="Iran">Iran</option>
												<option value="Iraq">Iraq</option>
												<option value="Ireland">Ireland</option>
												<option value="Isle of Man">Isle of Man</option>
												<option value="Israel">Israel</option>
												<option value="Italy">Italy</option>
												<option value="Jamaica">Jamaica</option>
												<option value="Japan">Japan</option>
												<option value="Jordan">Jordan</option>
												<option value="Kazakhstan">Kazakhstan</option>
												<option value="Kenya">Kenya</option>
												<option value="Kiribati">Kiribati</option>
												<option value="Korea North">Korea North</option>
												<option value="Korea Sout">Korea South</option>
												<option value="Kuwait">Kuwait</option>
												<option value="Kyrgyzstan">Kyrgyzstan</option>
												<option value="Laos">Laos</option>
												<option value="Latvia">Latvia</option>
												<option value="Lebanon">Lebanon</option>
												<option value="Lesotho">Lesotho</option>
												<option value="Liberia">Liberia</option>
												<option value="Libya">Libya</option>
												<option value="Liechtenstein">Liechtenstein</option>
												<option value="Lithuania">Lithuania</option>
												<option value="Luxembourg">Luxembourg</option>
												<option value="Macau">Macau</option>
												<option value="Macedonia">Macedonia</option>
												<option value="Madagascar">Madagascar</option>
												<option value="Malaysia">Malaysia</option>
												<option value="Malawi">Malawi</option>
												<option value="Maldives">Maldives</option>
												<option value="Mali">Mali</option>
												<option value="Malta">Malta</option>
												<option value="Marshall Islands">Marshall Islands</option>
												<option value="Martinique">Martinique</option>
												<option value="Mauritania">Mauritania</option>
												<option value="Mauritius">Mauritius</option>
												<option value="Mayotte">Mayotte</option>
												<option value="Mexico">Mexico</option>
												<option value="Midway Islands">Midway Islands</option>
												<option value="Moldova">Moldova</option>
												<option value="Monaco">Monaco</option>
												<option value="Mongolia">Mongolia</option>
												<option value="Montserrat">Montserrat</option>
												<option value="Morocco">Morocco</option>
												<option value="Mozambique">Mozambique</option>
												<option value="Myanmar">Myanmar</option>
												<option value="Nambia">Nambia</option>
												<option value="Nauru">Nauru</option>
												<option value="Nepal">Nepal</option>
												<option value="Netherland Antilles">Netherland Antilles</option>
												<option value="Netherlands">Netherlands (Holland, Europe)</option>
												<option value="Nevis">Nevis</option>
												<option value="New Caledonia">New Caledonia</option>
												<option value="New Zealand">New Zealand</option>
												<option value="Nicaragua">Nicaragua</option>
												<option value="Niger">Niger</option>
												<option value="Nigeria">Nigeria</option>
												<option value="Niue">Niue</option>
												<option value="Norfolk Island">Norfolk Island</option>
												<option value="Norway">Norway</option>
												<option value="Oman">Oman</option>
												<option value="Pakistan">Pakistan</option>
												<option value="Palau Island">Palau Island</option>
												<option value="Palestine">Palestine</option>
												<option value="Panama">Panama</option>
												<option value="Papua New Guinea">Papua New Guinea</option>
												<option value="Paraguay">Paraguay</option>
												<option value="Peru">Peru</option>
												<option value="Phillipines">Philippines</option>
												<option value="Pitcairn Island">Pitcairn Island</option>
												<option value="Poland">Poland</option>
												<option value="Portugal">Portugal</option>
												<option value="Puerto Rico">Puerto Rico</option>
												<option value="Qatar">Qatar</option>
												<option value="Republic of Montenegro">Republic of Montenegro</option>
												<option value="Republic of Serbia">Republic of Serbia</option>
												<option value="Reunion">Reunion</option>
												<option value="Romania">Romania</option>
												<option value="Russia">Russia</option>
												<option value="Rwanda">Rwanda</option>
												<option value="St Barthelemy">St Barthelemy</option>
												<option value="St Eustatius">St Eustatius</option>
												<option value="St Helena">St Helena</option>
												<option value="St Kitts-Nevis">St Kitts-Nevis</option>
												<option value="St Lucia">St Lucia</option>
												<option value="St Maarten">St Maarten</option>
												<option value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</option>
												<option value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</option>
												<option value="Saipan">Saipan</option>
												<option value="Samoa">Samoa</option>
												<option value="Samoa American">Samoa American</option>
												<option value="San Marino">San Marino</option>
												<option value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</option>
												<option value="Saudi Arabia">Saudi Arabia</option>
												<option value="Senegal">Senegal</option>
												<option value="Serbia">Serbia</option>
												<option value="Seychelles">Seychelles</option>
												<option value="Sierra Leone">Sierra Leone</option>
												<option value="Singapore">Singapore</option>
												<option value="Slovakia">Slovakia</option>
												<option value="Slovenia">Slovenia</option>
												<option value="Solomon Islands">Solomon Islands</option>
												<option value="Somalia">Somalia</option>
												<option value="South Africa">South Africa</option>
												<option value="Spain">Spain</option>
												<option value="Sri Lanka">Sri Lanka</option>
												<option value="Sudan">Sudan</option>
												<option value="Suriname">Suriname</option>
												<option value="Swaziland">Swaziland</option>
												<option value="Sweden">Sweden</option>
												<option value="Switzerland">Switzerland</option>
												<option value="Syria">Syria</option>
												<option value="Tahiti">Tahiti</option>
												<option value="Taiwan">Taiwan</option>
												<option value="Tajikistan">Tajikistan</option>
												<option value="Tanzania">Tanzania</option>
												<option value="Thailand">Thailand</option>
												<option value="Togo">Togo</option>
												<option value="Tokelau">Tokelau</option>
												<option value="Tonga">Tonga</option>
												<option value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</option>
												<option value="Tunisia">Tunisia</option>
												<option value="Turkey">Turkey</option>
												<option value="Turkmenistan">Turkmenistan</option>
												<option value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</option>
												<option value="Tuvalu">Tuvalu</option>
												<option value="Uganda">Uganda</option>
												<option value="Ukraine">Ukraine</option>
												<option value="United Arab Erimates">United Arab Emirates</option>
												<option value="United Kingdom">United Kingdom</option>
												<option selected value="United States of America">United States of America</option>
												<option value="Uraguay">Uruguay</option>
												<option value="Uzbekistan">Uzbekistan</option>
												<option value="Vanuatu">Vanuatu</option>
												<option value="Vatican City State">Vatican City State</option>
												<option value="Venezuela">Venezuela</option>
												<option value="Vietnam">Vietnam</option>
												<option value="Virgin Islands (Brit)">Virgin Islands (Brit)</option>
												<option value="Virgin Islands (USA)">Virgin Islands (USA)</option>
												<option value="Wake Island">Wake Island</option>
												<option value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</option>
												<option value="Yemen">Yemen</option>
												<option value="Zaire">Zaire</option>
												<option value="Zambia">Zambia</option>
												<option value="Zimbabwe">Zimbabwe</option>
											</select>
										</div>
										<div class="form-group">
											<label>Interval <span class="text-danger">*</span></label>
											<select onchange="GetExchRateAsset();" id="as_interval" data-placeholder="Choose an option" class="select-simple">
												<option></option>
											    <option value="1">Weekly</option>
											    <option value="2">Monthly</option>
											    <option value="3">Yearly</option>
											    <option value="4">Broken Year</option>
											</select>
										</div>
                                        <div id="lblerrorasset5" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
										<div class="form-group money">
											<label>In Original Currency <span class="text-danger">*</span></label>
											<input id="as_originalcurrency" type="text" class="form-control numberOnly2" placeholder="0.00" >
										</div>
                                        <div id="lblerrorasset6" class="form-group ">
                                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                    </div>
										<div class="form-group money">
											<label>Appl. Exch. Rate</label>
											<input id="as_exchrate" type="text" class="form-control border-info text-info numberOnly2" readonly />
										</div>
										<div class="form-group money">
											<label>In Rupiah</label>
											<input id="as_inrupiah" type="text" class="form-control border-info text-info" readonly="readonly" />
										</div>
										<div style="display:none" class="form-group">
											<label>Address</label>
											<textarea id="as_address" rows="4" cols="3" class="form-control"></textarea>
										</div>
										<div style="display:none" class="form-group">
											<label>Type of Document</label>
											<input id="as_details" type="text" class="form-control" />
										</div>
										<div style="display:none" class="form-group">
											<label>Account Number</label>
											<input id="as_account" type="text" class="form-control" />
										</div>
									</fieldset>
								</div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal" onclick="closemodal_asset()">Cancel</button>
						<button id="btnSaveAnotherAsset" onclick="SaveAsset(1); return false;" type="submit" class="btn btn-primary">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
						<button onclick="SaveAsset(0); return false;" type="submit" class="btn btn-primary">Save and Close <i class="icon-floppy-disk position-right"></i></button>
					</div>
				</form>
			</div>
		</div>
	</div>

	<div id="capital-form-1770" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="">&times;</button>
					<h5 class="modal-title">Capital Gain/loss</h5>
				</div>
				<form action="#">
					<div class="panel panel-flat">
						<div class="panel-body">
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label>Description of Assets</label>
                                        <asp:HiddenField ID="capid" runat="server" ClientIDMode="Static" />
										<input type="text" id="cap_description" class="form-control" />
									</div>
									<div class="form-group" style="display:none;">
										<label>Country of Source <span class="text-danger">*</span></label>
										<select id="cap_country" data-placeholder="Choose an option" class="select" required>
											<option></option>
											<option value="Afganistan">Afghanistan</option>
											<option value="Albania">Albania</option>
											<option value="Algeria">Algeria</option>
											<option value="American Samoa">American Samoa</option>
											<option value="Andorra">Andorra</option>
											<option value="Angola">Angola</option>
											<option value="Anguilla">Anguilla</option>
											<option value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</option>
											<option value="Argentina">Argentina</option>
											<option value="Armenia">Armenia</option>
											<option value="Aruba">Aruba</option>
											<option value="Australia">Australia</option>
											<option value="Austria">Austria</option>
											<option value="Azerbaijan">Azerbaijan</option>
											<option value="Bahamas">Bahamas</option>
											<option value="Bahrain">Bahrain</option>
											<option value="Bangladesh">Bangladesh</option>
											<option value="Barbados">Barbados</option>
											<option value="Belarus">Belarus</option>
											<option value="Belgium">Belgium</option>
											<option value="Belize">Belize</option>
											<option value="Benin">Benin</option>
											<option value="Bermuda">Bermuda</option>
											<option value="Bhutan">Bhutan</option>
											<option value="Bolivia">Bolivia</option>
											<option value="Bonaire">Bonaire</option>
											<option value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</option>
											<option value="Botswana">Botswana</option>
											<option value="Brazil">Brazil</option>
											<option value="British Indian Ocean Ter">British Indian Ocean Ter</option>
											<option value="Brunei">Brunei</option>
											<option value="Bulgaria">Bulgaria</option>
											<option value="Burkina Faso">Burkina Faso</option>
											<option value="Burundi">Burundi</option>
											<option value="Cambodia">Cambodia</option>
											<option value="Cameroon">Cameroon</option>
											<option value="Canada">Canada</option>
											<option value="Canary Islands">Canary Islands</option>
											<option value="Cape Verde">Cape Verde</option>
											<option value="Cayman Islands">Cayman Islands</option>
											<option value="Central African Republic">Central African Republic</option>
											<option value="Chad">Chad</option>
											<option value="Channel Islands">Channel Islands</option>
											<option value="Chile">Chile</option>
											<option value="China">China</option>
											<option value="Christmas Island">Christmas Island</option>
											<option value="Cocos Island">Cocos Island</option>
											<option value="Colombia">Colombia</option>
											<option value="Comoros">Comoros</option>
											<option value="Congo">Congo</option>
											<option value="Cook Islands">Cook Islands</option>
											<option value="Costa Rica">Costa Rica</option>
											<option value="Cote DIvoire">Cote D'Ivoire</option>
											<option value="Croatia">Croatia</option>
											<option value="Cuba">Cuba</option>
											<option value="Curaco">Curacao</option>
											<option value="Cyprus">Cyprus</option>
											<option value="Czech Republic">Czech Republic</option>
											<option value="Denmark">Denmark</option>
											<option value="Djibouti">Djibouti</option>
											<option value="Dominica">Dominica</option>
											<option value="Dominican Republic">Dominican Republic</option>
											<option value="East Timor">East Timor</option>
											<option value="Ecuador">Ecuador</option>
											<option value="Egypt">Egypt</option>
											<option value="El Salvador">El Salvador</option>
											<option value="Equatorial Guinea">Equatorial Guinea</option>
											<option value="Eritrea">Eritrea</option>
											<option value="Estonia">Estonia</option>
											<option value="Ethiopia">Ethiopia</option>
											<option value="Falkland Islands">Falkland Islands</option>
											<option value="Faroe Islands">Faroe Islands</option>
											<option value="Fiji">Fiji</option>
											<option value="Finland">Finland</option>
											<option value="France">France</option>
											<option value="French Guiana">French Guiana</option>
											<option value="French Polynesia">French Polynesia</option>
											<option value="French Southern Ter">French Southern Ter</option>
											<option value="Gabon">Gabon</option>
											<option value="Gambia">Gambia</option>
											<option value="Georgia">Georgia</option>
											<option value="Germany">Germany</option>
											<option value="Ghana">Ghana</option>
											<option value="Gibraltar">Gibraltar</option>
											<option value="Great Britain">Great Britain</option>
											<option value="Greece">Greece</option>
											<option value="Greenland">Greenland</option>
											<option value="Grenada">Grenada</option>
											<option value="Guadeloupe">Guadeloupe</option>
											<option value="Guam">Guam</option>
											<option value="Guatemala">Guatemala</option>
											<option value="Guinea">Guinea</option>
											<option value="Guyana">Guyana</option>
											<option value="Haiti">Haiti</option>
											<option value="Hawaii">Hawaii</option>
											<option value="Honduras">Honduras</option>
											<option value="Hong Kong">Hong Kong</option>
											<option value="Hungary">Hungary</option>
											<option value="Iceland">Iceland</option>
											<option value="India">India</option>
											<option value="Indonesia">Indonesia</option>
											<option value="Iran">Iran</option>
											<option value="Iraq">Iraq</option>
											<option value="Ireland">Ireland</option>
											<option value="Isle of Man">Isle of Man</option>
											<option value="Israel">Israel</option>
											<option value="Italy">Italy</option>
											<option value="Jamaica">Jamaica</option>
											<option value="Japan">Japan</option>
											<option value="Jordan">Jordan</option>
											<option value="Kazakhstan">Kazakhstan</option>
											<option value="Kenya">Kenya</option>
											<option value="Kiribati">Kiribati</option>
											<option value="Korea North">Korea North</option>
											<option value="Korea Sout">Korea South</option>
											<option value="Kuwait">Kuwait</option>
											<option value="Kyrgyzstan">Kyrgyzstan</option>
											<option value="Laos">Laos</option>
											<option value="Latvia">Latvia</option>
											<option value="Lebanon">Lebanon</option>
											<option value="Lesotho">Lesotho</option>
											<option value="Liberia">Liberia</option>
											<option value="Libya">Libya</option>
											<option value="Liechtenstein">Liechtenstein</option>
											<option value="Lithuania">Lithuania</option>
											<option value="Luxembourg">Luxembourg</option>
											<option value="Macau">Macau</option>
											<option value="Macedonia">Macedonia</option>
											<option value="Madagascar">Madagascar</option>
											<option value="Malaysia">Malaysia</option>
											<option value="Malawi">Malawi</option>
											<option value="Maldives">Maldives</option>
											<option value="Mali">Mali</option>
											<option value="Malta">Malta</option>
											<option value="Marshall Islands">Marshall Islands</option>
											<option value="Martinique">Martinique</option>
											<option value="Mauritania">Mauritania</option>
											<option value="Mauritius">Mauritius</option>
											<option value="Mayotte">Mayotte</option>
											<option value="Mexico">Mexico</option>
											<option value="Midway Islands">Midway Islands</option>
											<option value="Moldova">Moldova</option>
											<option value="Monaco">Monaco</option>
											<option value="Mongolia">Mongolia</option>
											<option value="Montserrat">Montserrat</option>
											<option value="Morocco">Morocco</option>
											<option value="Mozambique">Mozambique</option>
											<option value="Myanmar">Myanmar</option>
											<option value="Nambia">Nambia</option>
											<option value="Nauru">Nauru</option>
											<option value="Nepal">Nepal</option>
											<option value="Netherland Antilles">Netherland Antilles</option>
											<option value="Netherlands">Netherlands (Holland, Europe)</option>
											<option value="Nevis">Nevis</option>
											<option value="New Caledonia">New Caledonia</option>
											<option value="New Zealand">New Zealand</option>
											<option value="Nicaragua">Nicaragua</option>
											<option value="Niger">Niger</option>
											<option value="Nigeria">Nigeria</option>
											<option value="Niue">Niue</option>
											<option value="Norfolk Island">Norfolk Island</option>
											<option value="Norway">Norway</option>
											<option value="Oman">Oman</option>
											<option value="Pakistan">Pakistan</option>
											<option value="Palau Island">Palau Island</option>
											<option value="Palestine">Palestine</option>
											<option value="Panama">Panama</option>
											<option value="Papua New Guinea">Papua New Guinea</option>
											<option value="Paraguay">Paraguay</option>
											<option value="Peru">Peru</option>
											<option value="Phillipines">Philippines</option>
											<option value="Pitcairn Island">Pitcairn Island</option>
											<option value="Poland">Poland</option>
											<option value="Portugal">Portugal</option>
											<option value="Puerto Rico">Puerto Rico</option>
											<option value="Qatar">Qatar</option>
											<option value="Republic of Montenegro">Republic of Montenegro</option>
											<option value="Republic of Serbia">Republic of Serbia</option>
											<option value="Reunion">Reunion</option>
											<option value="Romania">Romania</option>
											<option value="Russia">Russia</option>
											<option value="Rwanda">Rwanda</option>
											<option value="St Barthelemy">St Barthelemy</option>
											<option value="St Eustatius">St Eustatius</option>
											<option value="St Helena">St Helena</option>
											<option value="St Kitts-Nevis">St Kitts-Nevis</option>
											<option value="St Lucia">St Lucia</option>
											<option value="St Maarten">St Maarten</option>
											<option value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</option>
											<option value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</option>
											<option value="Saipan">Saipan</option>
											<option value="Samoa">Samoa</option>
											<option value="Samoa American">Samoa American</option>
											<option value="San Marino">San Marino</option>
											<option value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</option>
											<option value="Saudi Arabia">Saudi Arabia</option>
											<option value="Senegal">Senegal</option>
											<option value="Serbia">Serbia</option>
											<option value="Seychelles">Seychelles</option>
											<option value="Sierra Leone">Sierra Leone</option>
											<option value="Singapore">Singapore</option>
											<option value="Slovakia">Slovakia</option>
											<option value="Slovenia">Slovenia</option>
											<option value="Solomon Islands">Solomon Islands</option>
											<option value="Somalia">Somalia</option>
											<option value="South Africa">South Africa</option>
											<option value="Spain">Spain</option>
											<option value="Sri Lanka">Sri Lanka</option>
											<option value="Sudan">Sudan</option>
											<option value="Suriname">Suriname</option>
											<option value="Swaziland">Swaziland</option>
											<option value="Sweden">Sweden</option>
											<option value="Switzerland">Switzerland</option>
											<option value="Syria">Syria</option>
											<option value="Tahiti">Tahiti</option>
											<option value="Taiwan">Taiwan</option>
											<option value="Tajikistan">Tajikistan</option>
											<option value="Tanzania">Tanzania</option>
											<option value="Thailand">Thailand</option>
											<option value="Togo">Togo</option>
											<option value="Tokelau">Tokelau</option>
											<option value="Tonga">Tonga</option>
											<option value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</option>
											<option value="Tunisia">Tunisia</option>
											<option value="Turkey">Turkey</option>
											<option value="Turkmenistan">Turkmenistan</option>
											<option value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</option>
											<option value="Tuvalu">Tuvalu</option>
											<option value="Uganda">Uganda</option>
											<option value="Ukraine">Ukraine</option>
											<option value="United Arab Erimates">United Arab Emirates</option>
											<option value="United Kingdom">United Kingdom</option>
											<option selected value="United States of America">United States of America</option>
											<option value="Uraguay">Uruguay</option>
											<option value="Uzbekistan">Uzbekistan</option>
											<option value="Vanuatu">Vanuatu</option>
											<option value="Vatican City State">Vatican City State</option>
											<option value="Venezuela">Venezuela</option>
											<option value="Vietnam">Vietnam</option>
											<option value="Virgin Islands (Brit)">Virgin Islands (Brit)</option>
											<option value="Virgin Islands (USA)">Virgin Islands (USA)</option>
											<option value="Wake Island">Wake Island</option>
											<option value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</option>
											<option value="Yemen">Yemen</option>
											<option value="Zaire">Zaire</option>
											<option value="Zambia">Zambia</option>
											<option value="Zimbabwe">Zimbabwe</option>
										</select>
									</div>
									<div class="form-group">
										<label>Currency <span class="text-danger">*</span></label>
										<select onchange="GetExchRateCapital();" id="cap_currency" data-placeholder="Choose an option" class="select currency" required>
											<option></option>
										</select>
                                        <input style="display:none;margin-top:5px;" type="text" runat="server" clientidmode="Static" id="cap_currencyother" class="form-control" maxlength="3" />
									</div>
                                    <div id="lblErrorCapital1" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group">
										<label>Selling Date <span class="text-danger">*</span></label>
										<input onchange="GetExchRateCapital();" type="text" id="cap_sellingdate" class="form-control datepicker" placeholder="dd/mm/yyyy" readonly="readonly" />
									    <div id="cap_dateofreceiptgroup">
                                            <select onchange="GetExchRateCapital();" runat="server" id="cap_dateofreceipt2_1" clientidmode="Static"  name="cap_dateofreceipt2_1" data-placeholder="Choose an option" class="select">
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
								            </select><br />
                                            <select onchange="GetExchRateCapital();" runat="server" id="cap_dateofreceipt2_2_1" name="" data-placeholder="Choose Year" class="select-simple" clientidmode="Static">
									            <option></option>
								            </select>
                                        </div>
                                    </div>  
                                    <div id="lblErrorCapital2" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group">
										<label>Interval <span class="text-danger">*</span></label>
										<select onchange="GetExchRateCapital();" id="cap_interval" data-placeholder="Choose an option" class="select-simple" required>
											<option></option>
											<option value="1">Weekly</option>
											<option value="2">Monthly</option>
											<option value="3">Yearly</option>
											<option value="4">Broken Year</option>
										</select>
									</div> 
                                    <div id="lblErrorCapital3" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group money">
										<label>Appl. Exch. Rate</label>
										<input id="cap_exchrate" type="text" class="form-control border-info text-info numberOnly2" readonly="readonly" />
									</div>
									<fieldset>
										<legend class="text-semibold">Amount in Original Currency</legend>
										<div class="form-group money">
											<label>Proceeds</label>
											<input type="text" id="cap_proceeds" class="form-control numberOnly2" placeholder="0.00" />
										</div>
										<div class="form-group money">
											<label>Cost</label>
											<input type="text" id="cap_cost" class="form-control numberOnly2" placeholder="0.00" />
										</div>
									</fieldset>
								</div>
								<div class="col-md-6">
									<div class="form-group money">
										<label>Capital Gain/Loss</label>
										<input type="text" id="cap_gainloss" class="form-control border-info text-info" readonly="readonly" />
									</div>
									<div class="form-group money">
										<label>Foreign Tax Credit</label>
										<input type="text" id="cap_taxpaid" class="form-control border-info text-info" readonly="readonly" />
									</div>
									<fieldset>
										<legend class="text-semibold">Amount in Rupiah</legend>
										<div class="form-group money">
											<label>Capital gain/loss</label>
											<input type="text" id="cap_gainlossrp" class="form-control border-info text-info" readonly="readonly" />
										</div>
										<div class="form-group money">
											<label>Foreign Tax Credit</label>
											<input type="text" id="cap_taxpaidrp" class="form-control border-info text-info" readonly="readonly" />
										</div>
									</fieldset>
									<div class="form-group" id="cap_irregularincomediv">
										<label class="text-semibold">Irregular Income <span class="text-danger">*</span></label>
										<select id="cap_irregularincome" data-placeholder="Choose irregular income if any" class="select-simple" required>
											<option></option>
											<option value="yes">Yes</option>
											<option value="no">No</option>
										</select>
									</div> 
                                    <div id="lblErrorCapital4" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
								</div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal" onclick="">Cancel</button>
						<button id="btnSaveAddCap" onclick="SaveCapital(1); return false;" type="submit" class="btn btn-primary">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
						<button onclick="SaveCapital(0); return false;" type="submit" class="btn btn-primary">Save and Close <i class="icon-floppy-disk position-right"></i></button>
					</div>
				</form>
			</div>
		</div>
	</div>

	<div id="rental-form-1770" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header  bg-primary">
					<button type="button" class="close" data-dismiss="modal" onclick="">&times;</button>
					<h5 id="rentitle" class="modal-title"></h5>
				</div>
				<form action="#" class="form-horizontal">
					<div class="modal-body">
						<div class="form-group">
							<label class="control-label col-sm-3">Information</label>
							<div class="col-sm-9">
                                <input type="hidden" id="rentype" />
								<input type="hidden" id="renid" />
								<input type="text" id="ren_information" class="form-control" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Country of Source <span class="text-danger">*</span></label>
							<div class="col-sm-9">
								<select id="ren_country" data-placeholder="Choose an option" class="select required">
									<option></option>
									<option value="Afganistan">Afghanistan</option>
									<option value="Albania">Albania</option>
									<option value="Algeria">Algeria</option>
									<option value="American Samoa">American Samoa</option>
									<option value="Andorra">Andorra</option>
									<option value="Angola">Angola</option>
									<option value="Anguilla">Anguilla</option>
									<option value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</option>
									<option value="Argentina">Argentina</option>
									<option value="Armenia">Armenia</option>
									<option value="Aruba">Aruba</option>
									<option value="Australia">Australia</option>
									<option value="Austria">Austria</option>
									<option value="Azerbaijan">Azerbaijan</option>
									<option value="Bahamas">Bahamas</option>
									<option value="Bahrain">Bahrain</option>
									<option value="Bangladesh">Bangladesh</option>
									<option value="Barbados">Barbados</option>
									<option value="Belarus">Belarus</option>
									<option value="Belgium">Belgium</option>
									<option value="Belize">Belize</option>
									<option value="Benin">Benin</option>
									<option value="Bermuda">Bermuda</option>
									<option value="Bhutan">Bhutan</option>
									<option value="Bolivia">Bolivia</option>
									<option value="Bonaire">Bonaire</option>
									<option value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</option>
									<option value="Botswana">Botswana</option>
									<option value="Brazil">Brazil</option>
									<option value="British Indian Ocean Ter">British Indian Ocean Ter</option>
									<option value="Brunei">Brunei</option>
									<option value="Bulgaria">Bulgaria</option>
									<option value="Burkina Faso">Burkina Faso</option>
									<option value="Burundi">Burundi</option>
									<option value="Cambodia">Cambodia</option>
									<option value="Cameroon">Cameroon</option>
									<option value="Canada">Canada</option>
									<option value="Canary Islands">Canary Islands</option>
									<option value="Cape Verde">Cape Verde</option>
									<option value="Cayman Islands">Cayman Islands</option>
									<option value="Central African Republic">Central African Republic</option>
									<option value="Chad">Chad</option>
									<option value="Channel Islands">Channel Islands</option>
									<option value="Chile">Chile</option>
									<option value="China">China</option>
									<option value="Christmas Island">Christmas Island</option>
									<option value="Cocos Island">Cocos Island</option>
									<option value="Colombia">Colombia</option>
									<option value="Comoros">Comoros</option>
									<option value="Congo">Congo</option>
									<option value="Cook Islands">Cook Islands</option>
									<option value="Costa Rica">Costa Rica</option>
									<option value="Cote DIvoire">Cote D'Ivoire</option>
									<option value="Croatia">Croatia</option>
									<option value="Cuba">Cuba</option>
									<option value="Curaco">Curacao</option>
									<option value="Cyprus">Cyprus</option>
									<option value="Czech Republic">Czech Republic</option>
									<option value="Denmark">Denmark</option>
									<option value="Djibouti">Djibouti</option>
									<option value="Dominica">Dominica</option>
									<option value="Dominican Republic">Dominican Republic</option>
									<option value="East Timor">East Timor</option>
									<option value="Ecuador">Ecuador</option>
									<option value="Egypt">Egypt</option>
									<option value="El Salvador">El Salvador</option>
									<option value="Equatorial Guinea">Equatorial Guinea</option>
									<option value="Eritrea">Eritrea</option>
									<option value="Estonia">Estonia</option>
									<option value="Ethiopia">Ethiopia</option>
									<option value="Falkland Islands">Falkland Islands</option>
									<option value="Faroe Islands">Faroe Islands</option>
									<option value="Fiji">Fiji</option>
									<option value="Finland">Finland</option>
									<option value="France">France</option>
									<option value="French Guiana">French Guiana</option>
									<option value="French Polynesia">French Polynesia</option>
									<option value="French Southern Ter">French Southern Ter</option>
									<option value="Gabon">Gabon</option>
									<option value="Gambia">Gambia</option>
									<option value="Georgia">Georgia</option>
									<option value="Germany">Germany</option>
									<option value="Ghana">Ghana</option>
									<option value="Gibraltar">Gibraltar</option>
									<option value="Great Britain">Great Britain</option>
									<option value="Greece">Greece</option>
									<option value="Greenland">Greenland</option>
									<option value="Grenada">Grenada</option>
									<option value="Guadeloupe">Guadeloupe</option>
									<option value="Guam">Guam</option>
									<option value="Guatemala">Guatemala</option>
									<option value="Guinea">Guinea</option>
									<option value="Guyana">Guyana</option>
									<option value="Haiti">Haiti</option>
									<option value="Hawaii">Hawaii</option>
									<option value="Honduras">Honduras</option>
									<option value="Hong Kong">Hong Kong</option>
									<option value="Hungary">Hungary</option>
									<option value="Iceland">Iceland</option>
									<option value="India">India</option>
									<option value="Indonesia">Indonesia</option>
									<option value="Iran">Iran</option>
									<option value="Iraq">Iraq</option>
									<option value="Ireland">Ireland</option>
									<option value="Isle of Man">Isle of Man</option>
									<option value="Israel">Israel</option>
									<option value="Italy">Italy</option>
									<option value="Jamaica">Jamaica</option>
									<option value="Japan">Japan</option>
									<option value="Jordan">Jordan</option>
									<option value="Kazakhstan">Kazakhstan</option>
									<option value="Kenya">Kenya</option>
									<option value="Kiribati">Kiribati</option>
									<option value="Korea North">Korea North</option>
									<option value="Korea Sout">Korea South</option>
									<option value="Kuwait">Kuwait</option>
									<option value="Kyrgyzstan">Kyrgyzstan</option>
									<option value="Laos">Laos</option>
									<option value="Latvia">Latvia</option>
									<option value="Lebanon">Lebanon</option>
									<option value="Lesotho">Lesotho</option>
									<option value="Liberia">Liberia</option>
									<option value="Libya">Libya</option>
									<option value="Liechtenstein">Liechtenstein</option>
									<option value="Lithuania">Lithuania</option>
									<option value="Luxembourg">Luxembourg</option>
									<option value="Macau">Macau</option>
									<option value="Macedonia">Macedonia</option>
									<option value="Madagascar">Madagascar</option>
									<option value="Malaysia">Malaysia</option>
									<option value="Malawi">Malawi</option>
									<option value="Maldives">Maldives</option>
									<option value="Mali">Mali</option>
									<option value="Malta">Malta</option>
									<option value="Marshall Islands">Marshall Islands</option>
									<option value="Martinique">Martinique</option>
									<option value="Mauritania">Mauritania</option>
									<option value="Mauritius">Mauritius</option>
									<option value="Mayotte">Mayotte</option>
									<option value="Mexico">Mexico</option>
									<option value="Midway Islands">Midway Islands</option>
									<option value="Moldova">Moldova</option>
									<option value="Monaco">Monaco</option>
									<option value="Mongolia">Mongolia</option>
									<option value="Montserrat">Montserrat</option>
									<option value="Morocco">Morocco</option>
									<option value="Mozambique">Mozambique</option>
									<option value="Myanmar">Myanmar</option>
									<option value="Nambia">Nambia</option>
									<option value="Nauru">Nauru</option>
									<option value="Nepal">Nepal</option>
									<option value="Netherland Antilles">Netherland Antilles</option>
									<option value="Netherlands">Netherlands (Holland, Europe)</option>
									<option value="Nevis">Nevis</option>
									<option value="New Caledonia">New Caledonia</option>
									<option value="New Zealand">New Zealand</option>
									<option value="Nicaragua">Nicaragua</option>
									<option value="Niger">Niger</option>
									<option value="Nigeria">Nigeria</option>
									<option value="Niue">Niue</option>
									<option value="Norfolk Island">Norfolk Island</option>
									<option value="Norway">Norway</option>
									<option value="Oman">Oman</option>
									<option value="Pakistan">Pakistan</option>
									<option value="Palau Island">Palau Island</option>
									<option value="Palestine">Palestine</option>
									<option value="Panama">Panama</option>
									<option value="Papua New Guinea">Papua New Guinea</option>
									<option value="Paraguay">Paraguay</option>
									<option value="Peru">Peru</option>
									<option value="Phillipines">Philippines</option>
									<option value="Pitcairn Island">Pitcairn Island</option>
									<option value="Poland">Poland</option>
									<option value="Portugal">Portugal</option>
									<option value="Puerto Rico">Puerto Rico</option>
									<option value="Qatar">Qatar</option>
									<option value="Republic of Montenegro">Republic of Montenegro</option>
									<option value="Republic of Serbia">Republic of Serbia</option>
									<option value="Reunion">Reunion</option>
									<option value="Romania">Romania</option>
									<option value="Russia">Russia</option>
									<option value="Rwanda">Rwanda</option>
									<option value="St Barthelemy">St Barthelemy</option>
									<option value="St Eustatius">St Eustatius</option>
									<option value="St Helena">St Helena</option>
									<option value="St Kitts-Nevis">St Kitts-Nevis</option>
									<option value="St Lucia">St Lucia</option>
									<option value="St Maarten">St Maarten</option>
									<option value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</option>
									<option value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</option>
									<option value="Saipan">Saipan</option>
									<option value="Samoa">Samoa</option>
									<option value="Samoa American">Samoa American</option>
									<option value="San Marino">San Marino</option>
									<option value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</option>
									<option value="Saudi Arabia">Saudi Arabia</option>
									<option value="Senegal">Senegal</option>
									<option value="Serbia">Serbia</option>
									<option value="Seychelles">Seychelles</option>
									<option value="Sierra Leone">Sierra Leone</option>
									<option value="Singapore">Singapore</option>
									<option value="Slovakia">Slovakia</option>
									<option value="Slovenia">Slovenia</option>
									<option value="Solomon Islands">Solomon Islands</option>
									<option value="Somalia">Somalia</option>
									<option value="South Africa">South Africa</option>
									<option value="Spain">Spain</option>
									<option value="Sri Lanka">Sri Lanka</option>
									<option value="Sudan">Sudan</option>
									<option value="Suriname">Suriname</option>
									<option value="Swaziland">Swaziland</option>
									<option value="Sweden">Sweden</option>
									<option value="Switzerland">Switzerland</option>
									<option value="Syria">Syria</option>
									<option value="Tahiti">Tahiti</option>
									<option value="Taiwan">Taiwan</option>
									<option value="Tajikistan">Tajikistan</option>
									<option value="Tanzania">Tanzania</option>
									<option value="Thailand">Thailand</option>
									<option value="Togo">Togo</option>
									<option value="Tokelau">Tokelau</option>
									<option value="Tonga">Tonga</option>
									<option value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</option>
									<option value="Tunisia">Tunisia</option>
									<option value="Turkey">Turkey</option>
									<option value="Turkmenistan">Turkmenistan</option>
									<option value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</option>
									<option value="Tuvalu">Tuvalu</option>
									<option value="Uganda">Uganda</option>
									<option value="Ukraine">Ukraine</option>
									<option value="United Arab Erimates">United Arab Emirates</option>
									<option value="United Kingdom">United Kingdom</option>
									<option value="United States of America">United States of America</option>
									<option value="Uraguay">Uruguay</option>
									<option value="Uzbekistan">Uzbekistan</option>
									<option value="Vanuatu">Vanuatu</option>
									<option value="Vatican City State">Vatican City State</option>
									<option value="Venezuela">Venezuela</option>
									<option value="Vietnam">Vietnam</option>
									<option value="Virgin Islands (Brit)">Virgin Islands (Brit)</option>
									<option value="Virgin Islands (USA)">Virgin Islands (USA)</option>
									<option value="Wake Island">Wake Island</option>
									<option value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</option>
									<option value="Yemen">Yemen</option>
									<option value="Zaire">Zaire</option>
									<option value="Zambia">Zambia</option>
									<option value="Zimbabwe">Zimbabwe</option>
								</select>
							</div>
						</div>
                        <div id="lblErrorren1" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					    </div>
						<div class="form-group">
							<label class="control-label col-sm-3">Currency <span class="text-danger">*</span></label>
							<div class="col-sm-9">
								<select onchange="GetExchRateRental();" id="ren_currency" data-placeholder="Choose an option" class="select currency">
									<option></option>
								</select>
                                <input style="display:none;margin-top:5px;" type="text" runat="server" clientidmode="Static" id="ren_currencyother" class="form-control" maxlength="3" />
							</div>
						</div>
                        <div id="lblErrorren2" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					    </div>
						<div class="form-group">
							<label class="control-label col-sm-3">Date of receipt <span class="text-danger">*</span></label>
							<div class="col-sm-9">
								<div class="input-group">
									<input onchange="GetExchRateRental();" type="text" id="ren_dateofreceipt" class="form-control datepicker" placeholder="dd/mm/yyyy" readonly />
									<span class="input-group-addon"><i class="fa fa-calendar"></i></span>
								    <div id="ren_dateofreceiptgroup">
                                        <select onchange="GetExchRateRental();" runat="server" id="ren_dateofreceipt2_1" clientidmode="Static"  name="ren_dateofreceipt2_1" data-placeholder="Choose an option" class="select">
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
								        </select><br />
                                        <select onchange="GetExchRateRental();" runat="server" id="ren_dateofreceipt2_2_1" name="" data-placeholder="Choose Year" class="select-simple" clientidmode="Static">
									        <option></option>
								        </select>
                                    </div>
                                </div>
							</div>
						</div>
                        <div id="lblErrorren3" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					    </div>
						<div class="form-group">
							<label class="control-label col-sm-3">Interval <span class="text-danger">*</span></label>
							<div class="col-sm-9">
								<select onchange="GetExchRateRental();" id="ren_interval" data-placeholder="Choose an option" class="select-simple" required>
									<option></option>
									<option value="1">Weekly</option>
									<option value="2">Monthly</option>
									<option value="3">Yearly</option>
									<option value="4">Broken Year</option>
								</select>
							</div>
						</div>
                        <div id="lblErrorren4" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					    </div>
						<div class="form-group">
							<label class="control-label col-sm-3">Appl. Exch. Rate</label>
							<div class="col-sm-9 money">
								<input id="ren_exchrate" type="text" class="form-control border-info text-info numberOnly2" readonly />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Amount in Original Currency</label>
							<div class="col-sm-9 money">
								<input id="ren_amountcurrency" type="text" class="form-control numberOnly2" placeholder="0.00" />
							</div>
						</div>
						<div class="form-group">
							<label class="control-label col-sm-3">Amount in Rupiah</label>
							<div class="col-sm-9 money">
								<input id="ren_amountrp" type="text" class="form-control border-info text-info" readonly="readonly" />
							</div>
						</div>
						<div class="form-group" id="div_ren_irregularincome">
							<label class="control-label col-sm-3 text-semibold">Irregular Income <span class="text-danger">*</span></label>
							<div class="col-sm-9">
								<select id="ren_irregularincome" data-placeholder="Choose irregular income if any" class="select-simple">
									<option></option>
									<option value="yes">Yes</option>
									<option value="no">No</option>
								</select>
							</div>
						</div>
                        <div id="lblErrorren5" class="form-group ">
                            <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					    </div>
					</div>

					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal" onclick="">Cancel</button>
						<button id="btnSaveAddRen" type="submit" onclick="SaveRental(1); return false;" class="btn btn-primary">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
						<button type="submit" onclick="SaveRental(0); return false;" class="btn btn-primary">Save and Close <i class="icon-floppy-disk position-right"></i></button>
					</div>
				</form>
			</div>
		</div>
	</div>

	<div id="irregularform" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header bg-primary">
					<button type="button" class="close" data-dismiss="modal" >&times;</button>
					<h5 class="modal-title">Irregular Income</h5>
				</div>
				<form action="#">
					<div class="panel panel-flat">
						<div class="panel-body">
							<div class="row">  
								<div class="col-md-6">
                                    <asp:HiddenField ID="irregularid" runat="server" ClientIDMode="Static" />
									<div class="form-group" style="display:none;">
										<label>Country of Source <span class="text-danger">*</span></label>
										<select id="country" data-placeholder="Choose an option" class="select" required>
											<option></option>
											<option value="Afganistan">Afghanistan</option>
											<option value="Albania">Albania</option>
											<option value="Algeria">Algeria</option>
											<option value="American Samoa">American Samoa</option>
											<option value="Andorra">Andorra</option>
											<option value="Angola">Angola</option>
											<option value="Anguilla">Anguilla</option>
											<option value="Antigua &amp; Barbuda">Antigua &amp; Barbuda</option>
											<option value="Argentina">Argentina</option>
											<option value="Armenia">Armenia</option>
											<option value="Aruba">Aruba</option>
											<option value="Australia">Australia</option>
											<option value="Austria">Austria</option>
											<option value="Azerbaijan">Azerbaijan</option>
											<option value="Bahamas">Bahamas</option>
											<option value="Bahrain">Bahrain</option>
											<option value="Bangladesh">Bangladesh</option>
											<option value="Barbados">Barbados</option>
											<option value="Belarus">Belarus</option>
											<option value="Belgium">Belgium</option>
											<option value="Belize">Belize</option>
											<option value="Benin">Benin</option>
											<option value="Bermuda">Bermuda</option>
											<option value="Bhutan">Bhutan</option>
											<option value="Bolivia">Bolivia</option>
											<option value="Bonaire">Bonaire</option>
											<option value="Bosnia &amp; Herzegovina">Bosnia &amp; Herzegovina</option>
											<option value="Botswana">Botswana</option>
											<option value="Brazil">Brazil</option>
											<option value="British Indian Ocean Ter">British Indian Ocean Ter</option>
											<option value="Brunei">Brunei</option>
											<option value="Bulgaria">Bulgaria</option>
											<option value="Burkina Faso">Burkina Faso</option>
											<option value="Burundi">Burundi</option>
											<option value="Cambodia">Cambodia</option>
											<option value="Cameroon">Cameroon</option>
											<option value="Canada">Canada</option>
											<option value="Canary Islands">Canary Islands</option>
											<option value="Cape Verde">Cape Verde</option>
											<option value="Cayman Islands">Cayman Islands</option>
											<option value="Central African Republic">Central African Republic</option>
											<option value="Chad">Chad</option>
											<option value="Channel Islands">Channel Islands</option>
											<option value="Chile">Chile</option>
											<option value="China">China</option>
											<option value="Christmas Island">Christmas Island</option>
											<option value="Cocos Island">Cocos Island</option>
											<option value="Colombia">Colombia</option>
											<option value="Comoros">Comoros</option>
											<option value="Congo">Congo</option>
											<option value="Cook Islands">Cook Islands</option>
											<option value="Costa Rica">Costa Rica</option>
											<option value="Cote DIvoire">Cote D'Ivoire</option>
											<option value="Croatia">Croatia</option>
											<option value="Cuba">Cuba</option>
											<option value="Curaco">Curacao</option>
											<option value="Cyprus">Cyprus</option>
											<option value="Czech Republic">Czech Republic</option>
											<option value="Denmark">Denmark</option>
											<option value="Djibouti">Djibouti</option>
											<option value="Dominica">Dominica</option>
											<option value="Dominican Republic">Dominican Republic</option>
											<option value="East Timor">East Timor</option>
											<option value="Ecuador">Ecuador</option>
											<option value="Egypt">Egypt</option>
											<option value="El Salvador">El Salvador</option>
											<option value="Equatorial Guinea">Equatorial Guinea</option>
											<option value="Eritrea">Eritrea</option>
											<option value="Estonia">Estonia</option>
											<option value="Ethiopia">Ethiopia</option>
											<option value="Falkland Islands">Falkland Islands</option>
											<option value="Faroe Islands">Faroe Islands</option>
											<option value="Fiji">Fiji</option>
											<option value="Finland">Finland</option>
											<option value="France">France</option>
											<option value="French Guiana">French Guiana</option>
											<option value="French Polynesia">French Polynesia</option>
											<option value="French Southern Ter">French Southern Ter</option>
											<option value="Gabon">Gabon</option>
											<option value="Gambia">Gambia</option>
											<option value="Georgia">Georgia</option>
											<option value="Germany">Germany</option>
											<option value="Ghana">Ghana</option>
											<option value="Gibraltar">Gibraltar</option>
											<option value="Great Britain">Great Britain</option>
											<option value="Greece">Greece</option>
											<option value="Greenland">Greenland</option>
											<option value="Grenada">Grenada</option>
											<option value="Guadeloupe">Guadeloupe</option>
											<option value="Guam">Guam</option>
											<option value="Guatemala">Guatemala</option>
											<option value="Guinea">Guinea</option>
											<option value="Guyana">Guyana</option>
											<option value="Haiti">Haiti</option>
											<option value="Hawaii">Hawaii</option>
											<option value="Honduras">Honduras</option>
											<option value="Hong Kong">Hong Kong</option>
											<option value="Hungary">Hungary</option>
											<option value="Iceland">Iceland</option>
											<option value="India">India</option>
											<option value="Indonesia">Indonesia</option>
											<option value="Iran">Iran</option>
											<option value="Iraq">Iraq</option>
											<option value="Ireland">Ireland</option>
											<option value="Isle of Man">Isle of Man</option>
											<option value="Israel">Israel</option>
											<option value="Italy">Italy</option>
											<option value="Jamaica">Jamaica</option>
											<option selected value="Japan">Japan</option>
											<option value="Jordan">Jordan</option>
											<option value="Kazakhstan">Kazakhstan</option>
											<option value="Kenya">Kenya</option>
											<option value="Kiribati">Kiribati</option>
											<option value="Korea North">Korea North</option>
											<option value="Korea Sout">Korea South</option>
											<option value="Kuwait">Kuwait</option>
											<option value="Kyrgyzstan">Kyrgyzstan</option>
											<option value="Laos">Laos</option>
											<option value="Latvia">Latvia</option>
											<option value="Lebanon">Lebanon</option>
											<option value="Lesotho">Lesotho</option>
											<option value="Liberia">Liberia</option>
											<option value="Libya">Libya</option>
											<option value="Liechtenstein">Liechtenstein</option>
											<option value="Lithuania">Lithuania</option>
											<option value="Luxembourg">Luxembourg</option>
											<option value="Macau">Macau</option>
											<option value="Macedonia">Macedonia</option>
											<option value="Madagascar">Madagascar</option>
											<option value="Malaysia">Malaysia</option>
											<option value="Malawi">Malawi</option>
											<option value="Maldives">Maldives</option>
											<option value="Mali">Mali</option>
											<option value="Malta">Malta</option>
											<option value="Marshall Islands">Marshall Islands</option>
											<option value="Martinique">Martinique</option>
											<option value="Mauritania">Mauritania</option>
											<option value="Mauritius">Mauritius</option>
											<option value="Mayotte">Mayotte</option>
											<option value="Mexico">Mexico</option>
											<option value="Midway Islands">Midway Islands</option>
											<option value="Moldova">Moldova</option>
											<option value="Monaco">Monaco</option>
											<option value="Mongolia">Mongolia</option>
											<option value="Montserrat">Montserrat</option>
											<option value="Morocco">Morocco</option>
											<option value="Mozambique">Mozambique</option>
											<option value="Myanmar">Myanmar</option>
											<option value="Nambia">Nambia</option>
											<option value="Nauru">Nauru</option>
											<option value="Nepal">Nepal</option>
											<option value="Netherland Antilles">Netherland Antilles</option>
											<option value="Netherlands">Netherlands (Holland, Europe)</option>
											<option value="Nevis">Nevis</option>
											<option value="New Caledonia">New Caledonia</option>
											<option value="New Zealand">New Zealand</option>
											<option value="Nicaragua">Nicaragua</option>
											<option value="Niger">Niger</option>
											<option value="Nigeria">Nigeria</option>
											<option value="Niue">Niue</option>
											<option value="Norfolk Island">Norfolk Island</option>
											<option value="Norway">Norway</option>
											<option value="Oman">Oman</option>
											<option value="Pakistan">Pakistan</option>
											<option value="Palau Island">Palau Island</option>
											<option value="Palestine">Palestine</option>
											<option value="Panama">Panama</option>
											<option value="Papua New Guinea">Papua New Guinea</option>
											<option value="Paraguay">Paraguay</option>
											<option value="Peru">Peru</option>
											<option value="Phillipines">Philippines</option>
											<option value="Pitcairn Island">Pitcairn Island</option>
											<option value="Poland">Poland</option>
											<option value="Portugal">Portugal</option>
											<option value="Puerto Rico">Puerto Rico</option>
											<option value="Qatar">Qatar</option>
											<option value="Republic of Montenegro">Republic of Montenegro</option>
											<option value="Republic of Serbia">Republic of Serbia</option>
											<option value="Reunion">Reunion</option>
											<option value="Romania">Romania</option>
											<option value="Russia">Russia</option>
											<option value="Rwanda">Rwanda</option>
											<option value="St Barthelemy">St Barthelemy</option>
											<option value="St Eustatius">St Eustatius</option>
											<option value="St Helena">St Helena</option>
											<option value="St Kitts-Nevis">St Kitts-Nevis</option>
											<option value="St Lucia">St Lucia</option>
											<option value="St Maarten">St Maarten</option>
											<option value="St Pierre &amp; Miquelon">St Pierre &amp; Miquelon</option>
											<option value="St Vincent &amp; Grenadines">St Vincent &amp; Grenadines</option>
											<option value="Saipan">Saipan</option>
											<option value="Samoa">Samoa</option>
											<option value="Samoa American">Samoa American</option>
											<option value="San Marino">San Marino</option>
											<option value="Sao Tome &amp; Principe">Sao Tome &amp; Principe</option>
											<option value="Saudi Arabia">Saudi Arabia</option>
											<option value="Senegal">Senegal</option>
											<option value="Serbia">Serbia</option>
											<option value="Seychelles">Seychelles</option>
											<option value="Sierra Leone">Sierra Leone</option>
											<option value="Singapore">Singapore</option>
											<option value="Slovakia">Slovakia</option>
											<option value="Slovenia">Slovenia</option>
											<option value="Solomon Islands">Solomon Islands</option>
											<option value="Somalia">Somalia</option>
											<option value="South Africa">South Africa</option>
											<option value="Spain">Spain</option>
											<option value="Sri Lanka">Sri Lanka</option>
											<option value="Sudan">Sudan</option>
											<option value="Suriname">Suriname</option>
											<option value="Swaziland">Swaziland</option>
											<option value="Sweden">Sweden</option>
											<option value="Switzerland">Switzerland</option>
											<option value="Syria">Syria</option>
											<option value="Tahiti">Tahiti</option>
											<option value="Taiwan">Taiwan</option>
											<option value="Tajikistan">Tajikistan</option>
											<option value="Tanzania">Tanzania</option>
											<option value="Thailand">Thailand</option>
											<option value="Togo">Togo</option>
											<option value="Tokelau">Tokelau</option>
											<option value="Tonga">Tonga</option>
											<option value="Trinidad &amp; Tobago">Trinidad &amp; Tobago</option>
											<option value="Tunisia">Tunisia</option>
											<option value="Turkey">Turkey</option>
											<option value="Turkmenistan">Turkmenistan</option>
											<option value="Turks &amp; Caicos Is">Turks &amp; Caicos Is</option>
											<option value="Tuvalu">Tuvalu</option>
											<option value="Uganda">Uganda</option>
											<option value="Ukraine">Ukraine</option>
											<option value="United Arab Erimates">United Arab Emirates</option>
											<option value="United Kingdom">United Kingdom</option>
											<option value="United States of America">United States of America</option>
											<option value="Uraguay">Uruguay</option>
											<option value="Uzbekistan">Uzbekistan</option>
											<option value="Vanuatu">Vanuatu</option>
											<option value="Vatican City State">Vatican City State</option>
											<option value="Venezuela">Venezuela</option>
											<option value="Vietnam">Vietnam</option>
											<option value="Virgin Islands (Brit)">Virgin Islands (Brit)</option>
											<option value="Virgin Islands (USA)">Virgin Islands (USA)</option>
											<option value="Wake Island">Wake Island</option>
											<option value="Wallis &amp; Futana Is">Wallis &amp; Futana Is</option>
											<option value="Yemen">Yemen</option>
											<option value="Zaire">Zaire</option>
											<option value="Zambia">Zambia</option>
											<option value="Zimbabwe">Zimbabwe</option>
										</select>
									</div>
                                    <div id="lblErrorIrr1" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group">
										<label>Type of income - in English <span class="text-danger">*</span></label>
										<select onchange="irrchange(this.value);return false;" id="data1" data-placeholder="Choose an option" class="select-simple" required>
											<option></option>
											<option value="Japan Salary from Certificate of Income (CoI)">Japan Salary from Certificate of Income (CoI)</option>
											<option value="Other payments/allowances from Certificate of Salary">Other payments/allowances from Certificate of Salary</option>
											<option value="Bonuses">Bonuses</option>
										</select>
									</div>
									<div class="form-group money">
										<label>Type of income - in Indonesian</label>
										<input id="data2" type="text" class="form-control border-info text-info" readonly placeholder=""/>
									</div>
                                    <div id="lblErrorIrr2" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group money">
										<label>Name of original Currency</label>
										<input id="data3" type="text" value="JPY" class="form-control border-info text-info" readonly placeholder=""/>
									</div>
                                    <div id="lblErrorIrr3" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
								</div>
                                <div class="col-md-6">
									<div class="form-group money">
										<label>Amount in original currency</label>
										<input id="data4" type="text" class="form-control numberOnly2" placeholder="0.00"/>
									</div>
                                    <div id="lblErrorIrr4" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group money">
										<label>Amount of Income (IDR)</label>
										<input id="data5" type="text" class="form-control numberOnly2" placeholder="0.00"/>
									</div>
                                    <div id="lblErrorIrr5" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group money">
										<label>Tax paid/withheld (IDR)</label>
										<input id="data6" type="text" class="form-control numberOnly2" placeholder="0.00"/>
									</div>
                                    <div id="lblErrorIrr6" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
									<div class="form-group money">
										<label>Allowed Art. 24</label>
										<input id="data7" type="text" class="form-control numberOnly2" placeholder="0.00"/>
									</div>
                                    <div id="lblErrorIrr7" class="form-group ">
                                        <label class="control-label col-sm-12"><span class="text-danger">Please fill required field</span></label>
					                </div>
                                </div>
							</div>
						</div>
					</div>

					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal" >Cancel</button>
						<button id="btnSaveAddIrr" onclick="SaveIrregularJapan(1); return false;" type="submit" class="btn btn-primary">Save and Add Another <i class="icon-floppy-disk position-right"></i></button>
						<button onclick="SaveIrregularJapan(0); return false;" type="submit" class="btn btn-primary">Save and Close <i class="icon-floppy-disk position-right"></i></button>
					</div>
				</form>
			</div>
		</div>
	</div>

    <div id="divexch" class="modal fade">
		<div class="modal-dialog modal-lg">
			<div class="modal-content">
				<div class="modal-header  bg-primary">
					<button type="button" class="close" data-dismiss="modal">&times;</button>
					<h5 id="H1" class="modal-title">Info</h5>
				</div>
				<form action="#" class="form-horizontal">
					<div class="modal-body">
						<div class="form-group">
							<label class="control-label col-sm-3">Exch. Rate Not Available</label>
						</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">OK</button>
					</div>
				</form>
			</div>
		</div>
	</div>
    

    <script type="text/javascript" src="http://localhost:13627/assets/delloite/assets/js/general-information.js"></script>
    <script type="text/javascript" src="http://localhost:13627/assets/delloite/assets/js/overseas-income.js"></script>
    <script type="text/javascript" src="http://localhost:13627/assets/delloite/assets/js/asset-liabilities.js"></script>
    <script id="onready" language="javascript" type="text/javascript">
        $(document).ready(function () {
            isloadcurrency = false;
            $('#hdisActive').val(0);

            $("#successMsg").text("");
            $("#successBox").css("opacity", "0");

            if ($('#t1s8f19').val() == "") {
                $('#t1s8f19').val("N/A");
            }

            $('#hdcurrentTab').val(1);
            RefreshGeneral();
            RefreshOverseas();
            RefreshAsset();

            if ($('#t1s1f7').val() != '' && $('#t1s1f8').val() != '') {
                for (i = 0; i < 7; i++) {
                    $("#steps-uid-1").steps("next", {});
                    $("#steps-uid-2").steps("next", {});
                    $("#steps-uid-0").steps("next", {});
                }
                $("#steps-uid-0-t-0").click();
                $("#steps-uid-2-t-0").click();
                $("#steps-uid-1-t-0").click();
                $('#hdisActive').val(1);
            }
            if ($('#t1s2f13').prop('checked') == true) {
                $('#div2other').css("display", "block");
            }

            for (i = 1; i <= 15; i++) {
                var theyear = parseInt($('#t1s1f3').val());
                $("#txtyear" + i).val(theyear);
                $("#txtrate" + i).val("1");
                $("#txtyear1").val(theyear-1);
                $("#txtyear4").val(theyear - 1);
            }

        });

        function s2other(cb) {
            if (cb.checked == true) {
                $('#div2other').css("display", "block");
            } else {
                $('#div2other').css("display", "none");
            }
        }

        function addfam() {
            $('#lblerrorFamily1').hide();
            $('#lblerrorFamily2').hide();
            $('#lblerrorFamilyedit').hide();
            $('#btnSaveFamilyAdd').css("display", "-webkit-inline-box");
            $('#familyid').val("");
            $('#nameFamily').val("");
            $('#relationshipFamily').val("");
            $('#occupationFamily').val("");
            $('#nikFamily').val("");
            $('#relationshipFamily').trigger("change");
            $('#occupationFamily').trigger("change");
        }

        function addieincome() {
            $('#IEIncomeID').val("");
            $('#lblerrorIEIncome1').hide();
            $('#lblerrorIEIncome2').hide();
            $('#lblerrorIEIncome4').hide();
            $('#lblerrorIEIncome5').hide();
            $('#lblerrorIEIncome6').hide();
            $('#lblerrorIEIncome7').hide();
            $('#lblerrorIEIncome8').hide();
            $('#lblerrorIEIncome9').hide();
            $('#lblerrorIEIncome10').hide();
            $('#lblerrorIEIncome11').hide();
            $('#lblerrorIEIncome12').hide();
            $('#lblerrorIEIncome13').hide();
            $('#lblerrorIEIncome14').hide();
            $('#lblerrorIEIncome15').hide();
            $('#lblerrorIEIncome17').hide();
            $('#lblerrorIEIncome18').hide();
            $('#lblerrorIEIncome20').hide();
            $('#lblerrorIEIncome21').hide();
            $('#lblerrorIEIncome22').hide();
            $('#lblerrorIEIncome23').hide();
            $('#lblerrorIEIncome24').hide();

            $('#lblerrorIEIncomeedit1').hide();
            $('#lblerrorIEIncomeedit2').hide();
            $('#lblerrorIEIncomeedit4').hide();
            $('#lblerrorIEIncomeedit5').hide();
            $('#lblerrorIEIncomeedit6').hide();
            $('#lblerrorIEIncomeedit7').hide();
            $('#lblerrorIEIncomeedit8').hide();
            $('#lblerrorIEIncomeedit9').hide();
            $('#lblerrorIEIncomeedit10').hide();
            $('#lblerrorIEIncomeedit11').hide();
            $('#lblerrorIEIncomeedit12').hide();
            $('#lblerrorIEIncomeedit13').hide();
            $('#lblerrorIEIncomeedit14').hide();
            $('#lblerrorIEIncomeedit15').hide();
            $('#lblerrorIEIncomeedit17').hide();
            $('#lblerrorIEIncomeedit18').hide();
            $('#lblerrorIEIncomeedit20').hide();
            $('#lblerrorIEIncomeedit21').hide();
            $('#lblerrorIEIncomeedit22').hide();
            $('#lblerrorIEIncomeedit23').hide();
            $('#lblerrorIEIncomeedit24').hide();
        }
    </script>
</asp:Content>
