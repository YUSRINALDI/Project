<%@ Page Title="Download Report | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true" CodeBehind="report_us.aspx.cs" Inherits="DelloiteTR.report_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="page-container">
	<div class="page-content">
		<div class="content-wrapper">
			<div class="panel panel-white">
				<div class="panel-body">
					<div class="row">
						<div class="panel-heading">
							<h5 class="panel-title">Report</h5>
							<div class="heading-elements">
                                <asp:LinkButton ID="btnBackTaxform" runat="server" class="btn btn-default" onclick="btnBackTaxform_Click" 
                                            ><i class="icon-chevron-left position-left"></i> Back to Taxform</asp:LinkButton>
                                <asp:LinkButton ID="btnBackForm" runat="server" class="btn btn-default" onclick="btnBackForm_Click" 
                                            ><i class="icon-chevron-left position-left"></i> Back to Form</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton20" runat="server" class="btn btn-default" 
                                            onclick="LinkButton20_Click"><i class="icon-download position-left"></i> Download Selected Report</asp:LinkButton>
                                <asp:LinkButton ID="btnDownloadExcel" runat="server" class="btn btn-default" 
                                            onclick="btnDownloadExcel_Click"><i class="icon-download position-left"></i> Download Excel Report</asp:LinkButton>
							</div>
						</div>
						<div class="panel-body">
                            <asp:HiddenField ID="hdid" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdtaxidnumber" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdtaxyear" runat="server" ClientIDMode="Static" />
                            <asp:Panel ID="errorBox" runat="server" style="opacity:100;" 
                                class="alert alert-warning alert-dismissible fade show" role="alert" 
                                Enabled="true">
                                <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                                <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                                </button>
                            </asp:Panel>
                            
                            <asp:LinkButton Visible="false" ID="LinkButton21" runat="server" class="btn btn-default" 
                                            onclick="UnSelect">Select None</asp:LinkButton>
                            <asp:LinkButton Visible="false" ID="LinkButton22" runat="server" class="btn btn-default" 
                                            onclick="Select">Select All</asp:LinkButton>
							<div class="row">
								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox1" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">FE-1770S</h6>
									</div>
								</div>

								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox2" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">FE-1770S-I</h6>
									</div>
								</div>

								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox3" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">FE-1770S-II</h6>
									</div>
								</div>

								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox4" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">Attachment</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-danger text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox5" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">1770S</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-danger text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox6" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">1770S-I</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-danger text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox7" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">1770S-II</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-danger text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox8" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">Lampiran</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox9" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">1721A1</h6>
									</div>
								</div>
								<div class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox10" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">Envelope Form</h6>
									</div>
								</div>
								<div runat="server" id="divinput" class="col-md-3">
									<div class="panel panel-body border-top-primary text-center">
										<asp:CheckBox Visible="false" Checked="true" id="CheckBox11" runat="server"></asp:CheckBox>
										<h6 class="no-margin text-semibold">Input Sheet</h6>
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

<script id="onready" language="javascript" type="text/javascript">
    $(document).ready(function () {
        var taxid = $('#hdid').val();

        $.ajax({
            url: 'Calculation.asmx/GetTaxFormByIDJSON',
            data: 'id=' + taxid,
            dataType: "json",
            method: 'GET',
            success: function (data) {
                $(data).each(function (index, theData) {
                   
                    $('#hdtaxidnumber').val(theData.taxidnumber);
                    $('#hdtaxyear').val(theData.year);
                });
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
</script>

</asp:Content>
