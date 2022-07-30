<%@ Page Title="Calculation | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="calculation.aspx.cs" Inherits="DelloiteTR.calculation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-container">
		<div class="page-content">
			<div class="content-wrapper">
				<div class="panel panel-white">
					<div class="panel-body">
						<div class="row">
							<div class="panel panel-flat">
								<div class="panel-heading">
									<h5 class="panel-title">Tax Year - Calculation</h5>
									<div class="heading-elements">
										<asp:LinkButton ID="lbBacktoTaxform" runat="server" type="button" 
                                            class="btn btn-default btn-xs heading-btn" ClientIDMode="Static" 
                                            onclick="lbBacktoTaxform_Click"><i class="icon-chevron-left position-left"></i>
											Back to Taxform</asp:LinkButton>
										<asp:LinkButton ID="lbBacktoForm" runat="server" type="button" 
                                            class="btn btn-default btn-xs heading-btn" ClientIDMode="Static" 
                                            onclick="lbBacktoForm_Click"><i class="icon-file-text position-left"></i>
											Back to Form</asp:LinkButton>
										<asp:LinkButton ID="lbDownload_pdf" runat="server" type="button" 
                                            class="btn btn-default btn-xs heading-btn" ClientIDMode="Static" 
                                            onclick="lbDownload_pdf_Click"><i class="icon-file-pdf position-left"></i>
											Download (PDF)</asp:LinkButton>
										<asp:LinkButton ID="lbDownload_excel" runat="server" type="button" 
                                            class="btn btn-default btn-xs heading-btn" ClientIDMode="Static" 
                                            onclick="lbDownload_excel_Click"><i class="icon-file-excel position-left"></i>
											Download (Excel)</asp:LinkButton>
									</div>
								</div>
								<div class="panel-body">
                                    <asp:Panel ID="errorBox" runat="server" style="opacity:100;" 
                                    class="alert alert-warning alert-dismissible fade show" role="alert" 
                                    Enabled="true">
                                        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                                        <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </asp:Panel>
									<div class="form-group form-group-padding">
										<select name="tax-year" id="tax-year" data-placeholder="Choose" class="select-simple">
											<option></option>
											<option value="tax-year-version1">Version 1 - Article 21 Income Tax Calculation Is Rounded Down</option>
											<option value="tax-year-version2">Version 2 - Article 21 Income Tax Calculation Is Not Rounded</option>
										</select>
									</div>
									<form class="form-horizontal" action="#">
                                        <asp:HiddenField ID="hdid" runat="server" ClientIDMode="Static" />
                                        <asp:HiddenField ID="hdtaxidnumber" runat="server" ClientIDMode="Static" />
                                        <asp:HiddenField ID="hdtaxyear" runat="server" ClientIDMode="Static" />

										<div id="TaxYearChoose1" style="display: none;">
											<div class="tabbable">
												<ul class="nav nav-tabs nav-tabs-highlight">
													<li class="active"><a href="#bordered-justified-pill4" data-toggle="tab">Individual Income Tax Calculation</a></li>
													<li><a href="#bordered-justified-pill5" data-toggle="tab">Calculation of Monthly PPh 25 Installments</a></li>
												</ul>
												<div class="tab-content">

													<div class="tab-pane active" id="bordered-justified-pill4">
														<h5 class="text-bold">Net Income</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net Business / Independent Service Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_0"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_1"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_2"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_3"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_4"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_5"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_6"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="row">
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Net Income</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net business / independent services</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_01"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_7"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_8"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_9"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Other domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_10"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_11"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total annualized net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_12"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
															</div>
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Tax Base</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_13"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_14"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total employment income + bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_15"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Personal Reliefs</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_16"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Annualized Taxable Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_17"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Tax Base</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_18"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_19"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_20"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_21"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_22"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_23"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_24"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_25"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_26"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_27"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_28"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_29"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Actual Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_30"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_31"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_32"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_33"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Total actual income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_34"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
													</div>
													<div class="tab-pane" id="bordered-justified-pill5">
														<div class="row">
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Regular Net Income</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net Business / Independent Service Income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_b1"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular net business income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_b2"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular net business income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_b3"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>

																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_35"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_36"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_37"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Other domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_38"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_39"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_40"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_41"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_42"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_43"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total annualized regular net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_44"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
															</div>
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Tax Base</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_45"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_46"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total employment income + bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_rounded_47"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Personal Reliefs</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_48"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Annualized Taxable Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_49"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Tax Base</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">net business income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_b4"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_50"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_51"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_52"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_53"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_54"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_55"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_56"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold form-group-padding">Annualized Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_57"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_58"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_59"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_60"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_61"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

                                                        <h5 class="text-bold form-group-padding">ANNUALIZED IMCOME TAX DUE</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_b6"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_b7"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base </label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_b8"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<h5 class="text-bold form-group-padding">Actual Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_62"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_63"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_64"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_65"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Total actual income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_66"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold form-group-padding">Tax Credit</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Art. 21 income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_67"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Art. 24 income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_68"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Irregular income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_69"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total tax credit</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_70"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">TAX CREDIT FROM ART. 29</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_b5"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Tax Base To Calculate Art. 25</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_71"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Number of Tax Periods</label>
															<div class="col-sm-8">
																<input style="text-align: right;" clientidmode="Static" runat="server" id="calc_rounded_72"  type="text" class="form-control numberOnly" placeholder="00" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Monthly PPh 25</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_rounded_73"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
													</div>

												</div>
											</div>
										</div>

										<div id="TaxYearChoose2" style="display: none;">
											<div class="tabbable">
												<ul class="nav nav-tabs nav-tabs-highlight">
													<li class="active"><a href="#bordered-justified-pill6" data-toggle="tab">Individual Income Tax Calculation</a></li>
													<li><a href="#bordered-justified-pill7" data-toggle="tab">Calculation of Monthly PPh 25 Installments</a></li>
												</ul>
												<div class="tab-content">

													<div class="tab-pane active" id="bordered-justified-pill6">
														<h5 class="text-bold">Net Income</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net Business / Independent Service Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_0"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_1"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Net employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_2"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_3"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_4"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_5"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_6"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="row">
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Net Income</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net business / independent services</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_01"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_7"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_8"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_9"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Other domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_10"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_11"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total annualized net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_12"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
															</div>
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Tax Base</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_13"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_14"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total employment income + bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_15"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
															</div>
														</div>

														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Personal Reliefs</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_16"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Annualized Taxable Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_17"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Tax Base</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_18"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_19"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_20"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_21"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_22"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_23"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_24"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_25"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_26"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_27"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_28"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_29"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Actual Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_30"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_31"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_32"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_33"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Total actual income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_34"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
													</div>
													<div class="tab-pane" id="bordered-justified-pill7">
														<div class="row">
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Regular Net Income</h5>
																
                                                                <div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net Business / Independent Service Income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_b1"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular net business income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_b2"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular net business income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_b3"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
																	</div>
																</div>

                                                                <div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_35"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Net employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_36"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Subtotal net employment income & bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_37"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Other domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_38"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_39"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular domestic net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_40"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_41"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Irregular overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_42"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Regular overseas net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_43"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total annualized regular net income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_44"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
															</div>
															<div class="col-sm-12">
																<h5 class="text-bold">Annualized Tax Base</h5>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment income</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_45"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Employment bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_46"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
																<div class="form-group form-group-padding">
																	<label class="control-label col-sm-4">Total employment income + bonus</label>
																	<div class="col-sm-8 money">
																		<input clientidmode="Static" runat="server" id="calc_not_47"  type="text" class="form-control numberOnly" placeholder="00.0" />
																	</div>
																</div>
															</div>
														</div>

                                                        <div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">2009 Onward Personal Relief</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b9"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Personal Reliefs</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_48"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Annualized Taxable Income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_49"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Tax Base</h5>
                                                        
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">net business income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b4"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_50"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_51"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_52"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Other domestic net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_53"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Overseas net income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_54"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_55"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_56"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Annualized Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_57"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_58"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_59"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_60"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total annualized income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_61"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

                                                        <h5 class="text-bold form-group-padding">ANNUALIZED IMCOME TAX DUE</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b6"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total employment income + bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b7"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Tax base </label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b8"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<h5 class="text-bold">Actual Income Tax Due</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_62"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Employment bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_63"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Subtotal employment income and bonus</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_64"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">On other income</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_65"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Total actual income tax due</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_66"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<h5 class="text-bold">Tax Credit</h5>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Art. 21 income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_67"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Art. 24 income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_68"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Irregular income tax</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_69"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4">Total tax credit</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_70"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">TAX CREDIT FROM ART. 29</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_b5"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>

														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Tax Base To Calculate Art. 25</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_71"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Number of Tax Periods</label>
															<div class="col-sm-8">
																<input style="text-align: right;" clientidmode="Static" runat="server" id="calc_not_72"  type="text" class="form-control numberOnly" placeholder="00" value="" />
															</div>
														</div>
														<div class="form-group form-group-padding">
															<label class="control-label col-sm-4 text-bold">Monthly PPh 25</label>
															<div class="col-sm-8 money">
																<input clientidmode="Static" runat="server" id="calc_not_73"  type="text" class="form-control numberOnly" placeholder="00.0" value="" />
															</div>
														</div>
													</div>

												</div>
											</div>
										</div>
									</form>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

    <script id="onready" language="javascript" type="text/javascript">
        $(document).ready(function () {

        });
    </script>

</asp:Content>
