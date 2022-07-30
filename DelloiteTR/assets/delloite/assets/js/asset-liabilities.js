function RefreshAsset() {
    isedit = false;
    isnotif = true;
    ischangeexch = true;
    
    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    $('#btnSaveAnotherAsset').css("display", "-webkit-inline-box");

    
    GetAssetBy(1, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(2, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(3, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(4, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(5, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(6, $('#MainContent_hdTaxPlayerNumber').val());
    GetAssetBy(10, $('#MainContent_hdTaxPlayerNumber').val());

    GetCurrency();

    clearallwarning();
}

function clearallwarning() {
    $('#lblerrorFamily1').hide();
    $('#lblerrorFamily2').hide();
    $('#lblerrorFamilyedit').hide();

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

    $('#lblerrorOverseasIncome1').hide();
    $('#lblerrorOverseasIncome2').hide();
    $('#lblerrorOverseasIncome3').hide();
    $('#lblerrorOverseasIncome4').hide();
    $('#lblerrorOverseasIncome5').hide();
    $('#lblerrorOverseasIncome6').hide();


    $('#llberrorasset').hide();
    $('#lblErrorren1').hide();
    $('#lblErrorren2').hide();
    $('#lblErrorren3').hide();
    $('#lblErrorren4').hide();
    $('#lblErrorren5').hide();
    $('#lblErrorCapital1').hide();
    $('#lblErrorCapital2').hide();
    $('#lblErrorCapital3').hide();
    $('#lblErrorCapital4').hide();
    if ($('#selectedform').val() != "formUs") {
        $('#lblErrorCapital5').hide();
    }

    $('#lblerrorasset1').hide();
    $('#lblerrorasset2').hide();
    $('#lblerrorasset3').hide();
    $('#lblerrorasset4').hide();
    $('#lblerrorasset5').hide();
    $('#lblerrorasset6').hide();
}

function closemodal_asset() {
    if ($('#astype').val() == 1) {
        GetAssetBy(1, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 2) {
        GetAssetBy(2, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 3) {
        GetAssetBy(3, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 4) {
        GetAssetBy(4, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 5) {
        GetAssetBy(5, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 6) {
        GetAssetBy(6, $('#MainContent_hdTaxPlayerNumber').val());
    } else if ($('#astype').val() == 10) {
        GetAssetBy(10, $('#MainContent_hdTaxPlayerNumber').val());
    }

    isedit = false;
    isnotif = true;
    $('#btnSaveAnotherAsset').css("display", "-webkit-inline-box");
    clearallwarning();
}

function GetDescription(code, form) {
    $('#as_description').empty();
    $('#as_description').append($('<option>', {
        value: "",
        text: ""
    }));
    $.ajax({
        url: 'OverseasService.asmx/GetDescription',
        data: "code=" + code + "&form=" + form,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            $(data).each(function (index, rel) {
                $('#as_description').append($('<option>', {
                    value: rel.id + "-" + rel.code,
                    text: rel.account
                }));
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetAssetByID(id, title, typeincome, form) {

    ischangeexch = false;

    $('#btnSaveAnotherAsset').css("display", "none");

    $('#as_description').empty();
    $('#as_description').append($('<option>', {
        value: "",
        text: ""
    }));
    $.ajax({
        url: 'OverseasService.asmx/GetDescription',
        data: "code=" + typeincome + "&form=" + form,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            $(data).each(function (index, rel) {
                $('#as_description').append($('<option>', {
                    value: rel.id + "-" + rel.code,
                    text: rel.account
                }));
            });

            $.ajax({
                url: 'OverseasService.asmx/GetAssetByID',
                data: 'id=' + id,
                dataType: "json",
                method: 'GET',
                success: function (data) {
                    var i = 1;
                    $(data).each(function (index, theData) {
                        isedit = true;
                        $('#astitle').empty();
                        $('#astitle').append(title);
                        $('#astype').val(typeincome);
                        $('#asid').val(theData.id);
                        
                        $('#as_description').val(theData.as_id + "-" + theData.as_refnumber);
                        $('#as_refnumber').val(theData.as_refnumber);
                        $('#as_details').val(theData.as_details);
                        $('#as_currency').val(theData.as_currency);
                        $('#as_interval').val(theData.as_interval);

                        if (theData.as_interval == "4") {
                            $('#as_dateofreceipt2_1').val(theData.as_balancedate.substring(0, theData.as_balancedate.length - 5));
                            $('#as_dateofreceipt2_2_1').val(theData.as_balancedate.substring(theData.as_balancedate.length - 4, theData.as_balancedate.length));
                        } else {
                            $('#as_balancedate').val(theData.as_balancedate);
                        }

                        $('#as_originalcurrency').val(theData.as_originalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#as_exchrate').val(theData.as_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#as_inrupiah').val(theData.as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        if (theData.form == "form1770") {

                        } else if (theData.form == "formNonUs") {
                            $('#as_owner').val(theData.as_owner);
                            $('#as_address').val(theData.as_address);
                            $('#as_account').val(theData.as_account);
                            $('#as_country').val(theData.as_country);
                            $('#as_owner').trigger('change');
                            $('#as_country').trigger('change');
                        } else if (theData.form == "formUs") {
                            $('#as_owner').val(theData.as_owner);
                        }

                        $('#as_description').trigger('change');
                        $('#as_currency').trigger('change');
                        $('#as_interval').trigger('change');
                        $('#as_dateofreceipt2_1').trigger('change');
                        $('#as_dateofreceipt2_2_1').trigger('change');
                        $('#as_balancedate').trigger('change');

                        if ($('#as_currency').val() == null || $('#as_currency').val() == undefined || $('#as_currency').val() == "") {
                            $('#as_currency').val("-");
                            $('#as_currencyother').val(theData.as_currency);
                            $('#as_currency').trigger('change');
                        }

                        i++;
                    });
                    ischangeexch = true;
                },
                error: function (err) {
                    $('#asset-form-1770').modal('toggle');
                    console.log(err);
                }
            });

        },
        error: function (err) {
            console.log(err);
        }
    });


}

function GetAssetBy(type, TaxPayerNumber) {
    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    $.ajax({
        url: 'OverseasService.asmx/GetAssetBy',
        data: 'type=' + type + '&TaxPlayerNumber=' + TaxPayerNumber
            + '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#assetTable' + type).DataTable();
            theTable.clear().draw();
            var title = "";
            if ($('#selectedform').val() == "formUs") {
                if (type == 1) {
                    title = "Cash And Cash Equivalent";
                } else if (type == 2) {
                    title = "Receivables";
                } else if (type == 3) {
                    title = "Investments";
                } else if (type == 4) {
                    title = "MEAN OF TRANSPORTAION";
                } else if (type == 5) {
                    title = "OTHER MOVEABLE PROPERTY";
                } else if (type == 6) {
                    title = "REAL PROPERTY";
                } else {
                    title = "Liabilities";
                }
            } else {
                if (type == 1) {
                    title = "Cash And Cash Equivalent";
                } else if (type == 2) {
                    title = "Account Receivables";
                } else if (type == 3) {
                    title = "Investments";
                } else if (type == 4) {
                    title = "Vehicles";
                } else if (type == 5) {
                    title = "Moveable Assets";
                } else if (type == 6) {
                    title = "Immoveable Assets";
                } else {
                    title = "Liabilities";
                }
            }

            var i = 1;
            var total1 = 0;
            $('#tabasset' + type).empty();
            $('#tabasset' + type).append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.as_inrupiah.toString().replace(/[$,]+/g, ""));
                $('#tabasset' + type).empty();
                $('#tabasset' + type).append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.form == "form1770") {
                    theTable.row.add([
                    i,
                    theData.as_refnumber,
                    theData.as_description,
                    theData.as_details,
                    theData.as_balancedate,
                    theData.as_currency,
                    theData.as_originalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetAssetByID(' + theData.id + ', \'' + title + '\', ' + type + ', \'' + theData.form + '\')" data-toggle="modal" data-target="#asset-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteAsset(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                } else if (theData.form == "formNonUs") {
                    var owner = "";
                    if (theData.as_owner == "taxPayer") {
                        owner = "Tax Payer";
                    } else if (theData.as_owner == "spouse") {
                        owner = "Spouse";
                    } else if (theData.as_owner == "child") {
                        owner = "Child";
                    } else if (theData.as_owner == "joint") {
                        owner = "Joint";
                    }
                    theTable.row.add([
                    i,
                    theData.as_refnumber,
                    theData.as_description,
                    owner,
                    theData.as_address,
                    theData.as_country,
                    theData.as_details,
                    theData.as_account,
                    theData.as_balancedate,
                    theData.as_currency,
                    theData.as_originalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetAssetByID(' + theData.id + ', \'' + title + '\', ' + type + ', \'' + theData.form + '\')" data-toggle="modal" data-target="#asset-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteAsset(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                }
                else if (theData.form == "formUs") {
                    theTable.row.add([
                    i,
                    theData.as_refnumber,
                    theData.as_description,
                    theData.as_owner,
                    theData.as_balancedate,
                    theData.as_currency,
                    theData.as_originalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetAssetByID(' + theData.id + ', \'' + title + '\', ' + type + ', \'' + theData.form + '\')" data-toggle="modal" data-target="#asset-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteAsset(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                }
                else if (theData.form == "formJapan") {
                    theTable.row.add([
                    i,
                    theData.as_refnumber,
                    theData.as_description,
                    theData.as_owner,
                    theData.as_balancedate,
                    theData.as_currency,
                    theData.as_originalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetAssetByID(' + theData.id + ', \'' + title + '\', ' + type + ', \'' + theData.form + '\')" data-toggle="modal" data-target="#asset-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteAsset(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                }
                i++;
            });

            $("#assetTable" + type + " tbody tr").each(function () {
                if (selectedform == "form1770") {
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                } else if (selectedform == "formNonUs") {
                    $(this).find('td:eq(10)').addClass('numcol');
                    $(this).find('td:eq(11)').addClass('numcol');
                    $(this).find('td:eq(12)').addClass('numcol');
                } else if (selectedform == "formUs") {
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                } else if (selectedform == "formJapan") {
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                }
                
            });
            $("#assetTable" + type + " td.cencol").css('text-align', 'center');
            $("#assetTable" + type + " td.numcol").css('text-align', 'right');

            var tabasset1 = $('#tabasset1').text().toString().replace(/[$,]+/g, "");
            var tabasset2 = $('#tabasset2').text().toString().replace(/[$,]+/g, "");
            var tabasset3 = $('#tabasset3').text().toString().replace(/[$,]+/g, "");
            var tabasset4 = $('#tabasset4').text().toString().replace(/[$,]+/g, "");
            var tabasset5 = $('#tabasset5').text().toString().replace(/[$,]+/g, "");
            var tabasset6 = $('#tabasset6').text().toString().replace(/[$,]+/g, "");
            var tabasset10 = $('#tabasset10').text().toString().replace(/[$,]+/g, "");

            var tab3nettotalasset = parseFloat(tabasset1) + parseFloat(tabasset2) + parseFloat(tabasset3) +
            parseFloat(tabasset4) + parseFloat(tabasset5) + parseFloat(tabasset6);
            var tab3nettotalliabilities = parseFloat(tabasset10);
            var tab3netasset = parseFloat(tab3nettotalasset) - parseFloat(tab3nettotalliabilities);

            $('#tab3nettotalasset').val(tab3nettotalasset.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab3nettotalliabilities').val(tab3nettotalliabilities.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab3netasset').val(tab3netasset.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        },
        error: function (err) {
            console.log(err);
        }
    });
}

function DeleteAsset(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteAsset',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                RefreshAsset();
                //alert('Data has been deleted');
                $("#successMsg").text("Data has been deleted");
                $("#successBox").css("opacity", "100");
                $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);
            },
            error: function (err) {
                console.log(err);
            }
        });
    } else {
        return false;
    }
}

function OverseasAsset(id, title) {
    isedit = false;
    $('#astitle').empty();
    $('#astitle').append(title);
    $('#astype').val(id);
    $('#asid').val("");

    $('#as_dateofreceipt').show();
    $('#as_dateofreceiptgroup').hide();

    $('#as_description').val("");
    $('#as_refnumber').val("");
    $('#as_details').val("");
    $('#as_balancedate').val("");
    $('#as_interval').val("");
    $('#as_originalcurrency').val("");
    $('#as_exchrate').val("");
    $('#as_inrupiah').val("");

    if ($('#selectedform').val() == "form1770") {
        $('#as_currency').val("");

    } else if ($('#selectedform').val() == "formNonUs") {
        $('#as_currency').val("");
        $('#as_owner').val("");
        $('#as_address').val("");
        $('#as_account').val("");
        $('#as_country').val("");
        $('#as_owner').trigger('change');
        $('#as_country').trigger('change');
    } else if ($('#selectedform').val() == "formUs") {
        $('#as_currency').val("USD");
        $('#as_owner').val("");
        $('#as_address').val("");
        $('#as_account').val("");
        $('#as_country').val("");
        $('#as_country').trigger('change');


        if (id==1) {
            $('#as_ownertext').text("Details (Bank's Name/Others)");
        } else if (id == 2) {
            $('#as_ownertext').text("Details (Borrower/Others)");
        } else if (id == 3) {
            $('#as_ownertext').text("Details");
        } else if (id == 4) {
            $('#as_ownertext').text("Details");
        } else if (id == 5) {
            $('#as_ownertext').text("Details");
        } else if (id == 6) {
            $('#as_ownertext').text("Details");
        } else if (id == 10) {
            $('#as_ownertext').text("Details (Type, Borrower, etc)");
        }

    } else if ($('#selectedform').val() == "formJapan") {
        $('#as_currency').val("JPY");
        $('#as_owner').val("");
        $('#as_address').val("");
        $('#as_account').val("");
        $('#as_country').val("");
        $('#as_country').trigger('change');
    }

    $('#as_description').trigger('change');
    $('#as_currency').trigger('change');
    $('#as_interval').trigger('change');
    console.log("asset init");
    GetDescription(id, $('#selectedform').val());
}

function SaveAsset(isAdd) {
    var jsonData = {};
    jsonData.type = $('#astype').val();
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    var value = $('#as_description').val();
    var as_id = value.split("-")[0];
    jsonData.as_id = as_id;
    jsonData.as_refnumber = $('#as_refnumber').val();
    jsonData.as_details = $('#as_details').val();
    jsonData.as_currency = $('#as_currency').val();
    if (jsonData.as_currency == "-") {
        jsonData.as_currency = $('#as_currencyother').val();
    }

    jsonData.as_interval = $('#as_interval').val();
    if (jsonData.as_interval == "4") {
        jsonData.as_balancedate = $('#as_dateofreceipt2_1').val() + " " + $('#as_dateofreceipt2_2_1').val();
    } else {
        jsonData.as_balancedate = $('#as_balancedate').val();
    }

    jsonData.as_interval = $('#as_interval').val();
    jsonData.as_originalcurrency = $('#as_originalcurrency').val();
    jsonData.as_exchrate = $('#as_exchrate').val();
    jsonData.as_inrupiah = $('#as_inrupiah').val();

    if (jsonData.form=="form1770") {
        jsonData.as_owner = "";
        jsonData.as_address = "";
        jsonData.as_account = "";
        jsonData.as_country = "";
    } else if (jsonData.form == "formNonUs" || jsonData.form == "formUs" || jsonData.form == "formJapan") {
        jsonData.as_owner = $('#as_owner').val();
        jsonData.as_address = $('#as_address').val();
        jsonData.as_account = $('#as_account').val();
        jsonData.as_country = $('#as_country').val();
    }
    

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscontinue = true;
    if (jsonData.as_description=="") {
        iscontinue = false;
        $('#lblerrorasset1').show();
    } else {
        $('#lblerrorasset1').hide();
    }
    if (jsonData.form == "form1770") {
        if (jsonData.as_details == "") {
            iscontinue = false;
            $('#lblerrorasset2').show();
        } else {
            $('#lblerrorasset2').hide();
        }
    } else {
        if (jsonData.as_owner == "") {
            iscontinue = false;
            $('#lblerrorasset2').show();
        } else {
            $('#lblerrorasset2').hide();
        }
    }
    if (jsonData.as_currency == "") {
        iscontinue = false;
        $('#lblerrorasset3').show();
    } else {
        $('#lblerrorasset3').hide();
    }
    if (jsonData.as_balancedate == "") {
        iscontinue = false;
        $('#lblerrorasset4').show();
    } else {
        $('#lblerrorasset4').hide();
    }
    if (jsonData.as_interval == "") {
        iscontinue = false;
        $('#lblerrorasset5').show();
    } else {
        $('#lblerrorasset5').hide();
    }
    if (jsonData.as_originalcurrency == "") {
        iscontinue = false;
        $('#lblerrorasset6').show();
    } else {
        $('#lblerrorasset6').hide();
    }

    if (iscontinue==true) {
        if ($('#asid').val() == "") {
            if (isAdd == 0) {
                $('#asset-form-1770').modal('toggle');
            } else {
                $('#as_description').val("");
                $('#as_refnumber').val("");
                $('#as_details').val("");
                $('#as_balancedate').val("");
                $('#as_interval').val("");
                $('#as_originalcurrency').val("");
                $('#as_exchrate').val("");
                $('#as_inrupiah').val("");

                if ($('#selectedform').val() == "form1770") {
                    $('#as_currency').val("");

                } else if ($('#selectedform').val() == "formNonUs") {
                    $('#as_currency').val("");
                    $('#as_owner').val("");
                    $('#as_address').val("");
                    $('#as_account').val("");
                    $('#as_country').val("");
                    $('#as_owner').trigger('change');
                    $('#as_country').trigger('change');
                } else if ($('#selectedform').val() == "formUs") {
                    $('#as_currency').val("USD");
                    $('#as_owner').val("");
                    $('#as_address').val("");
                    $('#as_account').val("");
                    $('#as_country').val("");
                    $('#as_country').trigger('change');
                } else if ($('#selectedform').val() == "formJapan") {
                    $('#as_currency').val("JPY");
                    $('#as_owner').val("");
                    $('#as_address').val("");
                    $('#as_account').val("");
                    $('#as_country').val("");
                    $('#as_country').trigger('change');
                }

                $('#as_description').trigger('change');
                $('#as_currency').trigger('change');
                $('#as_interval').trigger('change');
            }
            $.ajax({
                url: 'OverseasService.asmx/AddAsset',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshAsset();
					GetAssetBy($('#astype').val(), $('#MainContent_hdTaxPlayerNumber').val());
                    //alert('Data has been saved');
                    $("#successMsg").text("Data has been saved");
                    $("#successBox").css("opacity", "100");
                    $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            $('#asset-form-1770').modal('toggle');
            jsonData.id = $('#asid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditAsset',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshAsset();
					GetAssetBy($('#astype').val(), $('#MainContent_hdTaxPlayerNumber').val());
                    //alert('Data has been updated');
                    $("#successMsg").text("Data has been updated");
                    $("#successBox").css("opacity", "100");
                    $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    }

}

function GetExchRateAsset() {
    if (ischangeexch) {
        var jsonData = {};

        if ($('#as_interval').val() == "4") {
            $('#as_balancedate').hide();
            $('#as_dateofreceiptgroup').show();
        } else {
            $('#as_balancedate').show();
            $('#as_dateofreceiptgroup').hide();
        }

        var datearr = $('#as_balancedate').val().split('/');

        jsonData.currency = $('#as_currency').val();
        jsonData.type = $('#as_interval').val();

        if ($('#as_interval').val() == "4") {
            jsonData.interval = $('#as_dateofreceipt2_1').val();
            jsonData.year = $('#as_dateofreceipt2_2_1').val();
        }
        else {
            if (jsonData.type == 1) {
                jsonData.interval = datearr[2] + '-' + datearr[1] + '-' + datearr[0];
            } else if (jsonData.type == 2) {
                var dateObject = new Date(datearr[1] + '/' + datearr[0] + '/' + datearr[2]);
                jsonData.interval = dateObject.toLocaleString('en-us', { month: 'long' });
            } else if (jsonData.type == 3) {
                jsonData.interval = datearr[2];
            }
            jsonData.year = datearr[2];
        }

        if (jsonData.currency == "-") {
            $('#as_currencyother').css("display", "block");
            $('#as_exchrate').prop('disabled', false);
            $('#as_exchrate').prop('readonly', false);
            $('#as_exchrate').removeClass("border-info");
            $('#as_exchrate').focus();
        } else {
            $('#as_currencyother').css("display", "none");

            if (jsonData.currency != null && jsonData.interval != "" && jsonData.type != "" && jsonData.year != "") {
                $.ajax({
                    url: 'OverseasService.asmx/GetExchange',
                    data: 'currency=' + jsonData.currency + '&type=' + jsonData.type + '&interval=' + jsonData.interval + '&year=' + jsonData.year,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        if (data.length == 0) {
                            if ($('#as_exchrate').val() == "") {
                                if ($('#as_exchrate').val() == "") {
                                    alert("Exch. Rate Not Available");
                                    $('#as_exchrate').val("0");
                                    $('#as_exchrate').focus();
                                }
                            }
                            $('#as_exchrate').prop('disabled', false);
                            $('#as_exchrate').prop('readonly', false);
                            $('#as_exchrate').removeClass("border-info");
                        } else {
                            /*$('#as_exchrate').prop('disabled', true);
                            $('#as_exchrate').prop('readonly', true);
                            $('#as_exchrate').removeClass("border-info");
                            $('#as_exchrate').addClass("border-info");*/

                            $('#as_exchrate').prop('disabled', false);
                            $('#as_exchrate').prop('readonly', false);
                            $('#as_exchrate').removeClass("border-info");
                            $(data).each(function (index, theData) {
                                $(data).each(function (index, theData) {
                                    $('#as_exchrate').val(theData.amount.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

                                    UpdateAsset();
                                });
                            });
                        }
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            }
        }
    }
    
}

function SetRefNumber(value) {
    var ref = value.split("-")[1];
    $('#as_refnumber').val(ref);
}