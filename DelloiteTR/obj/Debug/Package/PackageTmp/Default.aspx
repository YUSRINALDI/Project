<%@ Page Title="Home | Deloitte GATe" Language="C#" MasterPageFile="~/Delloite.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DelloiteTR._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
                                        Enabled="true">
                                        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                                        <button type="button" class="close" style="right:0px;" data-dismiss="alert" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                        </button>
                                    </asp:Panel>

                                    <section class="content">

                                        <div class="panel-heading">
		                                    <h5 class="panel-title">Tax Payer Data</h5>
	                                    </div>
	                                    <div class="panel-body">
		                                    <table class="table table-striped datatable-responsive">
			                                    <thead>
				                                    <tr>
					                                    <th>No</th>
					                                    <th>Tax ID Number</th>
					                                    <th>Taxpayer's Name</th>
					                                    <th>Company</th>
					                                    <th>Action</th>
				                                    </tr>
			                                    </thead>
			                                    <tbody>
                                                    <asp:Literal ID="dataTable" runat="server"></asp:Literal>
			                                    </tbody>
		                                    </table>
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
    <!-- /.content -->


</asp:Content>
