function RefreshOverseas() {
    isedit = false;
    isnotif = true;
    ischangeexch = true;

    month = new Array();
    month[0] = "January";
    month[1] = "February";
    month[2] = "March";
    month[3] = "April";
    month[4] = "May";
    month[5] = "June";
    month[6] = "July";
    month[7] = "August";
    month[8] = "September";
    month[9] = "October";
    month[10] = "November";
    month[11] = "December";
    
    $('#btnSaveAddIncome').css("display", "-webkit-inline-box");
    $('#btnSaveAddCap').css("display", "-webkit-inline-box");
    $('#btnSaveAddRen').css("display", "-webkit-inline-box");
    $('#btnDetailedAdd').css("display", "-webkit-inline-box");

    sumrentals = [];
    theTableirrus = $('#irregulartable').DataTable();
    theTableirrus.clear().draw(false);

    selectedform = $('#selectedform').val();
    selectedyear = $('#t1s1f3').val();
    selectedammend = $('#t1s2f2').val();

    if ($('#selectedform').val() == "formJapan") {
        GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
        GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
        GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
        GetIncomeBy(4, $('#MainContent_hdTaxPlayerNumber').val());
        GetIncomeBy(5, $('#MainContent_hdTaxPlayerNumber').val());
        //GetWeeklyRate();
        GetSummaryJapan($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
        GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
    } else {
        if ($('#selectedform').val() == "formUs") {
            GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
            GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
            
        } else {
            GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
            GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
            GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
            GetRentalBy(1, $('#MainContent_hdTaxPlayerNumber').val());
            GetRentalBy(2, $('#MainContent_hdTaxPlayerNumber').val());
            GetRentalBy(3, $('#MainContent_hdTaxPlayerNumber').val());
            GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
        }
        GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
    }

    if (isloadcurrency==false) {
        GetCurrency();
        isloadcurrency = true;
    }

    clearallwarning();
    
}

function closemodal_overseas(param) {
    isedit = false;
    isnotif = true;

    $('#btnSaveAddIncome').css("display", "-webkit-inline-box");
    $('#btnSaveAddCap').css("display", "-webkit-inline-box");
    $('#btnSaveAddRen').css("display", "-webkit-inline-box");
    $('#btnDetailedAdd').css("display", "-webkit-inline-box");

    sumrentals = [];
    theTableirrus = $('#irregulartable').DataTable();
    theTableirrus.clear().draw(false);

    if (param == 1) {
        if ($('#typeincome').val() == 1) {
            GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#typeincome').val() == 2) {
            GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#typeincome').val() == 3) {
            GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#typeincome').val() == 4) {
            GetIncomeBy(4, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#typeincome').val() == 5) {
            GetIncomeBy(5, $('#MainContent_hdTaxPlayerNumber').val());
        }
    } else if (param == 2) {
        GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
    } else if (param == 3) {
        if ($('#rentype').val() == 1) {
            GetRentalBy(1, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#rentype').val() == 2) {
            GetRentalBy(2, $('#MainContent_hdTaxPlayerNumber').val());
        } else if ($('#rentype').val() == 3) {
            GetRentalBy(3, $('#MainContent_hdTaxPlayerNumber').val());
        }
    } else if (param == 4) {
        GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
    }

    if ($('#selectedform').val() == "formJapan") {
        GetSummaryJapan($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
        GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
    } else {
        GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
    }
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
}

function addcapus() {

    $('#cap_irregularincomediv').show();

    $('#cap_description').val("");
    $('#cap_country').val("");
    $('#cap_currency').val("USD");
    $('#cap_sellingdate').val("");
    $('#cap_dateofreceipt2_1').val("");
    $('#cap_dateofreceipt2_2_1').val("");
    $('#cap_interval').val("");
    $('#cap_exchrate').val("");
    $('#cap_proceeds').val("");
    $('#cap_cost').val("");
    $('#cap_gainloss').val("");
    $('#cap_taxpaid').val("");
    $('#cap_gainlossrp').val("");
    $('#cap_taxpaidrp').val("");
    $('#cap_irregularincome').val("");

    $('#cap_country').trigger("change");
    $('#cap_dateofreceipt2_1').trigger("change");
    $('#cap_interval').trigger("change");
    $('#cap_irregularincome').trigger("change");
    $('#cap_currency').trigger("change");
}

function ClearWarning() {
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
    $('#cap_sellingdate').show();
    $('#cap_dateofreceiptgroup').hide();
}

function ClearWarningIrregular() {
    $('#lblErrorIrr1').hide();
    $('#lblErrorIrr2').hide();
    $('#lblErrorIrr3').hide();
    $('#lblErrorIrr4').hide();
    $('#lblErrorIrr5').hide();

    $('#irregularid').val("");
    $('#country').val("");
    $('#data1').val("");
    $('#data2').val("");
    $('#data3').val("");
    $('#data4').val("");
    $('#country').trigger('change');
    $('#data1').trigger('change');
}

function ClearWarningIrregularUS() {
    $('#lblErrorIrr1').hide();
    $('#lblErrorIrr2').hide();
    $('#lblErrorIrr3').hide();
    $('#lblErrorIrr4').hide();
    $('#lblErrorIrr5').hide();

    $('#irregularid').val("");
    $('#country').val("US");
    $('#data1').val("");
    $('#data2').val("");
    $('#data3').val("");
    $('#data4').val("");
    $('#country').trigger('change');
    $('#data1').trigger('change');
}

function ClearWarningIrregularJapan() {
    $('#lblErrorIrr1').hide();
    $('#lblErrorIrr2').hide();
    $('#lblErrorIrr3').hide();
    $('#lblErrorIrr4').hide();
    $('#lblErrorIrr5').hide();
    $('#lblErrorIrr6').hide();
    $('#lblErrorIrr7').hide();

    $('#irregularid').val("");
    $('#country').val("Japan");
    $('#data1').val("");
    $('#data2').val("");
    $('#data4').val("");
    $('#country').trigger('change');
    $('#data1').trigger('change');
}

function GetCurrency() {
    if (!isloadcurrency) {
        $('#oi_currency').empty();
        $('#as_currency').empty();
        $('#cap_currency').empty();
        $('#ren_currency').empty();
        $('#odi_currency').empty();
        $.ajax({
            url: 'OverseasService.asmx/GetCurrency',
            dataType: "json",
            method: 'GET',
            success: function (data) {
                $(data).each(function (index, rel) {

                    if ($('#selectedform').val() == "formUs") {

                        $('#odi_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                        $('#cap_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                        $('#as_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                    } else {
                        $('#oi_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                        $('#ren_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                        $('#as_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));

                        $('#cap_currency').append($('<option>', {
                            value: rel.currency,
                            text: rel.currency
                        }));
                    }

                });
                $('#oi_currency').append($('<option>', {
                    value: "-",
                    text: "Other"
                }));
                $('#odi_currency').append($('<option>', {
                    value: "-",
                    text: "Other"
                }));
                $('#as_currency').append($('<option>', {
                    value: "-",
                    text: "Other"
                }));
                $('#cap_currency').append($('<option>', {
                    value: "-",
                    text: "Other"
                }));
                $('#ren_currency').append($('<option>', {
                    value: "-",
                    text: "Other"
                }));

                if ($('#selectedform').val() == "formUs") {
                    $('#cap_currency').val("USD");
                    $('#odi_currency').val("USD");
                    $('#as_currency').val("USD");
                    $('#odi_currency').trigger("change");
                    $('#as_currency').trigger("change");
                    $('#cap_currency').trigger("change");
                }
                else if ($('#selectedform').val() == "formJapan") {
                    $('#oi_currency').val("JPY");
                    $('#as_currency').val("JPY");
                    $('#cap_currency').val("JPY");
                    $('#oi_currency').trigger("change");
                    $('#as_currency').trigger("change");
                    $('#cap_currency').trigger("change");
                }
                else {
                    $('#oi_currency').val("");
                    $('#as_currency').val("");
                    $('#cap_currency').val("");
                    $('#oi_currency').trigger("change");
                    $('#as_currency').trigger("change");
                    $('#cap_currency').trigger("change");
                }


            },
            error: function (err) {
                console.log(err);
            }
        });
    }
    
}

function GetWeeklyRate() {
    $('#oi_interval').empty();
    $.ajax({
        url: 'OverseasService.asmx/GetWeeklyRate',
        dataType: "json",
        method: 'GET',
        success: function (data) {
            $(data).each(function (index, rel) {
                $('#oi_interval').append($('<option>', {
                    value: rel.interval + ' ' + rel.year,
                    text: rel.interval + ' ' + rel.year
                }));

            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetIncomeByID(id, title, typeincome) {
    ischangeexch = false;
    ClearWarning();
    $('#btnSaveAddIncome').css("display", "none");
    $('#oi_irregularincomediv').hide();
    $.ajax({
        url: 'OverseasService.asmx/GetIncomeByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#lblTitleIncome').empty();
                $('#lblLegendIncome').empty();
                $('#lblTitleIncome').append(title);
                $('#lblLegendIncome').append(title);
                $('#typeincome').val(typeincome);

                $('#oi_incomecurrency').val(theData.incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_taxpaidcurrency').val(theData.taxpaidcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_incomerp').val(theData.incomerp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_taxpaidrp').val(theData.taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_treatyrate').val(theData.treatyrate);

                if (theData.interval == "4") {
                    $('#oi_dateofreceipt2_1').val(theData.dateofreceipt.substring(0, theData.dateofreceipt.length - 5));
                    $('#oi_dateofreceipt2_2_1').val(theData.dateofreceipt.substring(theData.dateofreceipt.length - 4, theData.dateofreceipt.length));
                } else {
                    $('#oi_dateofreceipt').val(theData.dateofreceipt);
                }


                if (!$("#oi_currency option[value=" + theData.currency + "]").length) {
                    $('#oi_currency').val("-");
                    $('#oi_currencyother').val(theData.currency);
                } else {
                    $('#oi_currency').val(theData.currency);
                }

                $('#oi_irregularincome').val(theData.irregularincome);
                $('#oi_exchrate').val(theData.exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_ftc').val(theData.ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_allowedftc').val(theData.allowedftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#oi_country').val(theData.country);
                $('#oi_interval').val(theData.interval);
                $('#overseasincomeid').val(theData.id);

                $('#oi_currency').trigger('change');
                $('#oi_country').trigger('change');
                $('#oi_irregularincome').trigger('change');
                $('#oi_interval').trigger('change');
                $('#oi_dateofreceipt').trigger('change');
                $('#oi_dateofreceipt2_1').trigger('change');
                $('#oi_dateofreceipt2_2_1').trigger('change');
                i++;
            });
            ischangeexch = true;
        },
        error: function (err) {
            $('#income-form-1770-s123').modal('toggle');
            console.log(err);
        }
    });
}

function GetIrregularByID(id) {
    ischangeexch = false;
    ClearWarningIrregular();
    $('#btnSaveAddIrr').css("display", "none");
    $.ajax({
        url: 'OverseasService.asmx/GetIrregularByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#irregularid').val(theData.id);
                $('#country').val(theData.country);
                $('#data1').val(theData.data1);
                $('#data2').val(theData.data2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#data3').val(theData.data3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#data4').val(theData.data4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                $('#country').trigger('change');
                $('#data1').trigger('change');
                i++;
            });
            ischangeexch = true;
        },
        error: function (err) {
            $('#irregularform').modal('toggle');
            console.log(err);
        }
    });

}

function GetIrregularJapanByID(id) {
    ischangeexch = false;
    ClearWarningIrregularJapan();
    $('#btnSaveAddIrr').css("display", "none");
    $.ajax({
        url: 'OverseasService.asmx/GetIrregularByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#irregularid').val(theData.id);
                $('#country').val(theData.country);
                $('#data1').val(theData.data1);
                $('#data2').val(theData.data2);
                $('#data3').val(theData.data3);
                $('#data4').val(theData.data4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#data5').val(theData.data5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#data6').val(theData.data6.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#data7').val(theData.data7.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                $('#country').trigger('change');
                $('#data1').trigger('change');
                i++;
            });
            ischangeexch = true;
        },
        error: function (err) {
            $('#irregularform').modal('toggle');
            console.log(err);
        }
    });

}

function GetIncomeDetailedByID(id, title, typeincome) {
    ischangeexch = false;
    $('#btnDetailedAdd').css("display", "none");
    $('#od_irregularincomediv').hide();
    $.ajax({
        url: 'OverseasService.asmx/GetIncomeDetailedByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#lblTitleIncome').empty();
                $('#lblLegendIncome').empty();
                $('#lblTitleIncome').append(title);
                $('#lblLegendIncome').append(title);
                $('#typeincome').val(typeincome);

                if (theData.interval == "4") {
                    $('#od_dateofreceipt2_1').val(theData.dateofreceipt.substring(0, theData.dateofreceipt.length - 5));
                    $('#od_dateofreceipt2_2_1').val(theData.dateofreceipt.substring(theData.dateofreceipt.length - 4, theData.dateofreceipt.length));
                } else {
                    $('#od_dateofreceipt').val(theData.dateofreceipt);
                }

                $('#odi_currency').val(theData.currency);
                $('#od_irregularincome').val(theData.irregularincome);
                
                $('#od_interval').val(theData.interval);

                $('#od_desc').val(theData.description);
                $('#od_line').val(theData.line);
                $('#od_fullyearincome').val(theData.fullyearincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_incomecurrency').val(theData.incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_taxpaidcurrency').val(theData.taxpaidcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_incomerp').val(theData.incomerp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_taxpaidrp').val(theData.taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_treatyrate').val(theData.treatyrate);
                $('#od_exchrate').val(theData.exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_ftc').val(theData.ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_allowedftc').val(theData.allowedftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_country').val(theData.country);
                $('#overseasincomeid').val(theData.id);

                $('#odi_currency').trigger('change');
                $('#od_irregularincome').trigger('change');
                $('#od_interval').trigger('change');
                $('#od_dateofreceipt').trigger('change');
                $('#od_dateofreceipt2_1').trigger('change');
                $('#od_dateofreceipt2_2_1').trigger('change');
                i++;
            });
            ischangeexch = true;
        },
        error: function (err) {
            $('#income-form-1770-s123').modal('toggle');
            console.log(err);
        }
    });

}

function GetIncomeDetailedByIDRefresh(id, title, typeincome) {
    ischangeexch = false;
    isforceupdate = true;
    $('#btnDetailedAdd').css("display", "none");
    $('#od_irregularincomediv').hide();
    $.ajax({
        url: 'OverseasService.asmx/GetIncomeDetailedByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#lblTitleIncome').empty();
                $('#lblLegendIncome').empty();
                $('#lblTitleIncome').append(title);
                $('#lblLegendIncome').append(title);
                $('#typeincome').val(typeincome);

                if (theData.interval == "4") {
                    $('#od_dateofreceipt2_1').val(theData.dateofreceipt.substring(0, theData.dateofreceipt.length - 5));
                    $('#od_dateofreceipt2_2_1').val(theData.dateofreceipt.substring(theData.dateofreceipt.length - 4, theData.dateofreceipt.length));
                } else {
                    $('#od_dateofreceipt').val(theData.dateofreceipt);
                }

                $('#odi_currency').val(theData.currency);
                $('#od_irregularincome').val(theData.irregularincome);

                $('#od_interval').val(theData.interval);

                $('#od_desc').val(theData.description);
                $('#od_line').val(theData.line);
                $('#od_fullyearincome').val(theData.fullyearincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_incomecurrency').val(theData.incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_taxpaidcurrency').val(theData.taxpaidcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_incomerp').val(theData.incomerp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_taxpaidrp').val(theData.taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_treatyrate').val(theData.treatyrate);
                $('#od_exchrate').val(theData.exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_ftc').val(theData.ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_allowedftc').val(theData.allowedftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#od_country').val(theData.country);
                $('#overseasincomeid').val(theData.id);

                $('#odi_currency').trigger('change');
                $('#od_irregularincome').trigger('change');
                $('#od_interval').trigger('change');
                $('#od_dateofreceipt').trigger('change');
                $('#od_dateofreceipt2_1').trigger('change');
                $('#od_dateofreceipt2_2_1').trigger('change');
                $('#od_fullyearincome').trigger('change');

                i++;
            });
            ischangeexch = true;
            console.log('test');
            SaveOverseasDetailed(0);
            $('#income-form-1770-s123').modal('toggle');
        },
        error: function (err) {
            $('#income-form-1770-s123').modal('toggle');
            console.log(err);
        }
    });

}

function GetRentalByID(id, title, typeincome) {
    ischangeexch = false;
    ClearWarning();
    $('#btnSaveAddRen').css("display", "none");
    $('#div_ren_irregularincome').hide();
    $.ajax({
        url: 'OverseasService.asmx/GetRentalByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#rentitle').empty();
                $('#rentitle').append(title);
                $('#rentype').val(typeincome);
                $('#renid').val(theData.id);

                $('#ren_information').val(theData.ren_information);
                $('#ren_country').val(theData.ren_country);
                $('#ren_currency').val(theData.ren_currency);

                if (theData.ren_interval == "4") {
                    $('#ren_dateofreceipt2_1').val(theData.ren_dateofreceipt.substring(0, theData.ren_dateofreceipt.length - 5));
                    $('#ren_dateofreceipt2_2_1').val(theData.ren_dateofreceipt.substring(theData.ren_dateofreceipt.length - 4, theData.ren_dateofreceipt.length));
                } else {
                    $('#ren_dateofreceipt').val(theData.ren_dateofreceipt);
                }

                $('#ren_interval').val(theData.ren_interval);
                $('#ren_exchrate').val(theData.ren_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#ren_amountcurrency').val(theData.ren_amountcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#ren_amountrp').val(theData.ren_amountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#ren_irregularincome').val(theData.ren_irregularincome);

                $('#ren_country').trigger('change');
                $('#ren_currency').trigger('change');
                $('#ren_interval').trigger('change');
                $('#ren_irregularincome').trigger('change');
                $('#ren_dateofreceipt2_1').trigger('change');
                $('#ren_dateofreceipt2_2_1').trigger('change');
                $('#ren_dateofreceipt').trigger('change');
                i++;
            });
            ischangeexch = true;
        },
        error: function (err) {
            $('#rental-form-1770').modal('toggle');
            console.log(err);
        }
    });
}

function GetCapitalByID(id) {
    ischangeexch = false;
    ClearWarning();
    $('#btnSaveAddCap').css("display", "none");
    $('#cap_irregularincomediv').hide();
    $.ajax({
        url: 'OverseasService.asmx/GetCapitalByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                $('#capid').val(theData.id);

                $('#cap_description').val(theData.cap_description);
                $('#cap_country').val(theData.cap_country);
                $('#cap_currency').val(theData.cap_currency);
                $('#cap_sellingdate').val(theData.cap_sellingdate);
                $('#cap_interval').val(theData.cap_interval);

                if (theData.cap_interval == "4") {
                    $('#cap_dateofreceipt2_1').val(theData.cap_sellingdate.substring(0, theData.cap_sellingdate.length - 5));
                    $('#cap_dateofreceipt2_2_1').val(theData.cap_sellingdate.substring(theData.cap_sellingdate.length - 4, theData.cap_sellingdate.length));
                } else {
                    $('#cap_sellingdate').val(theData.cap_sellingdate);
                }

                $('#cap_exchrate').val(theData.cap_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_proceeds').val(theData.cap_proceeds.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_cost').val(theData.cap_cost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_gainloss').val(theData.cap_gainloss.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_taxpaid').val(theData.cap_taxpaid.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_gainlossrp').val(theData.cap_gainlossrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_taxpaidrp').val(theData.cap_taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#cap_irregularincome').val(theData.cap_irregularincome).trigger("change");

                $('#cap_country').trigger('change');
                $('#cap_currency').trigger('change');
                $('#cap_interval').trigger('change');
                $('#cap_sellingdate').trigger('change');
                $('#cap_dateofreceipt2_1').trigger('change');
                $('#cap_dateofreceipt2_2_1').trigger('change');
                i++;
            });
        },
        error: function (err) {
            $('#capital-form-1770').modal('toggle');
            console.log(err);
        }
    });
}

function ceks2(){
    if ($('#t1s8f19').val() == "N/A") {
        $('#t1s8f20').val($('#totalperiod').val());
    } else {
        $('#t1s8f20').val($('#t1s8f19').val());
    }
}

function GetIncomeBy(type, TaxPayerNumber) {

    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();
    if (selectedform == "formUs") {
        $('#t1s8f18').val($('#totalperiod').val());
    }


    $.ajax({
        url: 'OverseasService.asmx/GetIncomeBy',
        data: 'type=' + type + '&TaxPlayerNumber=' + TaxPayerNumber +
        '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#incomeTable' + type).DataTable();
            theTable.clear().draw();
            var title = "";

            if ($('#selectedform').val() == "formJapan") {
                if (type == 1) {
                    title = "Japan Salary from Certificate of Income (CoI)";
                } else if (type == 2) {
                    title = "Japan Salary from Certificate of Income (CoI)";
                } else if (type == 3) {
                    title = "Other payments/allowances from Certificate of Salary";
                } else if (type == 4) {
                    title = "Other payments/allowances from Certificate of Salary";
                } else if (type == 5) {
                    title = "Bonuses";
                }
            } else {
                if (type == 1) {
                    title = "Dividend Income";
                } else if (type == 2) {
                    title = "Interest Income";
                } else if (type == 3) {
                    title = "Other Income";
                }
            }

            var i = 1;
            var total1 = 0;
            var total2 = 0;
            var total3 = 0;
            var total4 = 0;
            var total5 = 0;
            var total6 = 0;

            $('#tab' + type + 'total1').empty();
            $('#tab' + type + 'total2').empty();
            $('#tab' + type + 'total3').empty();
            $('#tab' + type + 'total4').empty();
            $('#tab' + type + 'total5').empty();
            $('#tab' + type + 'total6').empty();

            $('#tab' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total5').append(total5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total6').append(total6.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

            $(data).each(function (index, theData) {

                if (theData.incomecurrency != "") {
                    total1 = parseFloat(total1) + parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, ""));
                }
                if (theData.taxpaidcurrency != "") {
                    total2 = parseFloat(total2) + parseFloat(theData.taxpaidcurrency.toString().replace(/[$,]+/g, ""));
                }
                if (theData.incomerp != "") {
                    total3 = parseFloat(total3) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                }
                if (theData.taxpaidrp != "") {
                    total4 = parseFloat(total4) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));
                }
                if (theData.ftc != "") {
                    total5 = parseFloat(total5) + parseFloat(theData.ftc.toString().replace(/[$,]+/g, ""));
                }
                if (theData.allowedftc != "") {
                    total6 = parseFloat(total6) + parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, ""));
                }


                $('#tab' + type + 'total1').empty();
                $('#tab' + type + 'total2').empty();
                $('#tab' + type + 'total3').empty();
                $('#tab' + type + 'total4').empty();
                $('#tab' + type + 'total5').empty();
                $('#tab' + type + 'total6').empty();

                $('#tab' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total5').append(total5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total6').append(total6.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var incomecurrency = 0;
                var taxpaidcurrency = 0;
                var treatyrate = "";

                if (theData.incomecurrency != "") {
                    incomecurrency = theData.incomecurrency;
                }
                if (theData.taxpaidcurrency != "") {
                    taxpaidcurrency = theData.taxpaidcurrency;
                }
                if (theData.treatyrate != "") {
                    treatyrate = parseFloat(theData.treatyrate.toString().replace(/[$,]+/g, "").toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                }

                if (theData.form == "form1770") {
                    theTable.row.add([
                    theData.country,
                    theData.dateofreceipt,
                    theData.currency,
                    parseFloat(incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(taxpaidcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    treatyrate,
                    parseFloat(theData.ftc.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetIncomeByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#income-form-1770-s123" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIncome(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                } else if (theData.form == "formUs") {
                    theTable.row.add([
                    theData.country,
                    theData.allowedftc,
                    theData.dateofreceipt,
                    theData.currency,
                    parseFloat(theData.exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.taxpaidcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetIncomeByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#income-form-1770-s123" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIncome(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                } else if (theData.form == "formJapan") {
                    theTable.row.add([
                    theData.dateofreceipt,
                    theData.currency,
                    parseFloat(incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(taxpaidcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetIncomeByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#income-form-1770-s123" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIncome(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                } else {
                    theTable.row.add([
                    theData.country,
                    theData.dateofreceipt,
                    theData.currency,
                    parseFloat(incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(taxpaidcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetIncomeByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#income-form-1770-s123" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIncome(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);
                }


                i++;
            });


            var selectedform = $('#selectedform').val();
            var selectedyear = $('#t1s1f3').val();
            var selectedammend = $('#t1s2f2').val();

            if (total1 > 0) {
                total1 = total1;
            } else {
                total1 = 0; ;
            }
            if (total2 > 0) {
                total2 = total2;
            } else {
                total2 = 0; ;
            }
            if (total3 > 0) {
                total3 = total3;
            } else {
                total3 = 0; ;
            }
            if (total4 > 0) {
                total4 = total4;
            } else {
                total4 = 0; ;
            }
            if (total5 > 0) {
                total5 = total5;
            } else {
                total5 = 0; ;
            }
            if (total6 > 0) {
                total6 = total6;
            } else {
                total6 = 0; ;
            }

            if (selectedform == "form1770") {
                var theTableFooter = $('#incomeTable' + type + ' tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
            "<td colspan='3'>Sub Total</td>" +
            "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td></td>" +
            "<td style='text-align:right;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "<td style='text-align:right;'>" + total5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total6.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "</tr>");
            } else if (selectedform == "formUs") {
                var theTableFooter = $('#incomeTable' + type + ' tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
            "<td colspan='6'>Sub Total</td>" +
            "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td style='text-align:right;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "</tr>");
            } else if (selectedform == "formJapan") {
                var theTableFooter = $('#incomeTable' + type + ' tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
            "<td colspan='2'>Sub Total</td>" +
            "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td></td>" +
            "<td style='text-align:right;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "</tr>");
            } else {
                var theTableFooter = $('#incomeTable' + type + ' tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
            "<td colspan='3'>Sub Total</td>" +
            "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td></td>" +
            "<td style='text-align:right;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td style='text-align:right;'>" + total6.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "</tr>");
            }

            if (selectedform != "formUs" && selectedform != "formJapan") {
                theTableFooter.append("<tr>" +
            "<td colspan='12'>Sub Total By Country</td>" +
            "</tr>");

                $.ajax({
                    url: 'OverseasService.asmx/GetIncomeByCountry',
                    data: 'type=' + type + '&TaxPlayerNumber=' + TaxPayerNumber +
                '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        $(data).each(function (index, theData) {
                            if (selectedform == "form1770") {
                                theTableFooter.append("<tr>" +
                        "<td colspan='3'>" + theData.country + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.incomecurrency).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.taxpaidcurrency).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                        "<td></td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.incomerp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.taxpaidrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td></td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.ftc).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.allowedftc).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td></td>" +
                        "</tr>");
                            } else if (selectedform == "formNonUs") {
                                theTableFooter.append("<tr>" +
                        "<td colspan='3'>" + theData.country + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.incomecurrency).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.taxpaidcurrency).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                        "<td></td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.incomerp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.taxpaidrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td style='text-align:right;'>" + parseFloat(theData.allowedftc).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                        "<td></td>" +
                        "</tr>");
                            }

                        });
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });

                $("#incomeTable" + type + " tbody tr").each(function () {
                    if (selectedform != "formJapan") {
                        $(this).find('td:eq(2)').addClass('numcol');
                    } else {
                        $(this).find('td:eq(0)').addClass('cencol');
                        $(this).find('td:eq(1)').addClass('cencol');
                        $(this).find('td:eq(2)').addClass('numcol');
                    }
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                    $(this).find('td:eq(9)').addClass('numcol');
                    $(this).find('td:eq(10)').addClass('numcol');
                });

                $("#incomeTable" + type + " tfoot tr").each(function () {
                    $(this).find('td:eq(1)').addClass('numcol');
                    $(this).find('td:eq(2)').addClass('numcol');
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                });

                $("#incomeTable" + type + " td.cencol").css('text-align', 'center');
                $("#incomeTable" + type + " td.numcol").css('text-align', 'right');
            } else {
                $("#incomeTable" + type + " tbody tr").each(function () {
                    if (selectedform != "formJapan") {
                        $(this).find('td:eq(2)').addClass('numcol');
                    } else {
                        $(this).find('td:eq(0)').addClass('cencol');
                        $(this).find('td:eq(1)').addClass('cencol');
                        $(this).find('td:eq(2)').addClass('numcol');
                    }
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                    $(this).find('td:eq(9)').addClass('numcol');
                    $(this).find('td:eq(10)').addClass('numcol');
                });

                $("#incomeTable" + type + " tfoot tr").each(function () {
                    $(this).find('td:eq(1)').addClass('numcol');
                    $(this).find('td:eq(2)').addClass('numcol');
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                });

                $("#incomeTable" + type + " td.cencol").css('text-align', 'center');
                $("#incomeTable" + type + " td.numcol").css('text-align', 'right');
            }
            ischangeexch = true;
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetIncomeDetailedBy(type, TaxPayerNumber) {

    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();
    if (selectedform == "formUs") {
        $('#t1s8f18').val($('#totalperiod').val());
    }


    $.ajax({
        url: 'OverseasService.asmx/GetIncomeDetailedBy',
        data: 'type=' + type + '&TaxPlayerNumber=' + TaxPayerNumber +
        '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#incomeTableDetailed').DataTable();
            theTable.clear().draw();
            var title = "DETAILED OF INCOME AND FTC INFORMATION";

            var i = 1;
            var total1 = 0;
            var total2 = 0;
            var total3 = 0;
            var total4 = 0;

            $('#tab' + type + 'total1').empty();
            $('#tab' + type + 'total2').empty();
            $('#tab' + type + 'total3').empty();
            $('#tab' + type + 'total4').empty();

            $('#tab' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            $('#tab' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
            $('#tab' + type + 'total3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tab' + type + 'total4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, ""));
                total2 = parseFloat(total2) + parseFloat(theData.taxpaidcurrency.toString().replace(/[$,]+/g, ""));
                total3 = parseFloat(total3) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                total4 = parseFloat(total4) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));
                console.log("update " + total3);
                $('#tab' + type + 'total1').empty();
                $('#tab' + type + 'total2').empty();
                $('#tab' + type + 'total3').empty();
                $('#tab' + type + 'total4').empty();

                $('#tab' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                $('#tab' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                $('#tab' + type + 'total3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tab' + type + 'total4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var thedateofreceipt = theData.dateofreceipt;
                if (theData.interval == 3) {
                    var arrthedateofreceipt = theData.dateofreceipt.split("/");
                    thedateofreceipt = arrthedateofreceipt[2];
                }
                else if (theData.interval == 2) {
                    //var arrthedateofreceipt = theData.dateofreceipt.split("/");
                    //thedateofreceipt = month[arrthedateofreceipt[1] - 1] + " " + arrthedateofreceipt[2];

                    thedateofreceipt = theData.dateofreceipt
                }
                else {
                    thedateofreceipt = theData.dateofreceipt
                }

                theTable.row.add([
                    theData.description,
                    theData.line,
                    thedateofreceipt,
                    theData.currency,
                    parseFloat(theData.exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.fullyearincome.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.taxpaidcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\"><li><a href="#" onclick="GetIncomeDetailedByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#income-form-1770-s123" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="GetIncomeDetailedByIDRefresh(' + theData.id + ', \'' + title + '\', ' + type + ')" ><i class=\'icon-spinner\'></i></a></li>'
                + '<li><a href="#" onclick="DeleteIncomeDetailed(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);

                i++;
            });

            $("#incomeTableDetailed tbody tr").each(function () {
                $(this).find('td:eq(4)').addClass('numcol');
                $(this).find('td:eq(5)').addClass('numcol');
                $(this).find('td:eq(6)').addClass('numcol');
                $(this).find('td:eq(7)').addClass('numcol');
                $(this).find('td:eq(8)').addClass('numcol');
                $(this).find('td:eq(9)').addClass('numcol');
            });
            $("#incomeTableDetailed td.cencol").css('text-align', 'center');
            $("#incomeTableDetailed td.numcol").css('text-align', 'right');

            if ($('#selectedform').val() == "formUs") {
                var theTableFooter = $('#incomeTableDetailed tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
                    "<td colspan='3'>Sub Total</td>" +
                    "<td></td>" +
                    "<td></td>" +
                    "<td></td>" +
                    "<td style='text-align: right;'><span id='detailed1'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</span></td>" +
                    "<td style='text-align: right;'><span id='detailed2'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</span></td>" +
                    "<td style='text-align: right;'><span id='lbltotalsummary1' style='display:none;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span>" + "<span id='detailed3'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span></td>" +
                    "<td style='text-align: right;'><span id='lbltotalsummary2' style='display:none;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span>" + "<span id='detailed4'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span></td>" +
                    "<td></td>" +
                    "</tr>");

                detailed1 = 0;
                if ($("#detailed1").text() != '') {
                    detailed1 = $("#detailed1").text();
                }
                totalcap1 = 0;
                if ($("#totalcap1").text() != '') {
                    totalcap1 = $("#totalcap1").text();
                }
                t1s8f9 = parseFloat(detailed1.toString().replace(/[$,]+/g, "")) + parseFloat(totalcap1.toString().replace(/[$,]+/g, ""));
                $("#t1s8f9").val(t1s8f9.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                UpdateS1();

            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetIrregularIncome(TaxPlayerNumber, form, year, ammend) {
    console.log("GetIrregularIncome");
    var total1 = 0;
    var total2 = 0;
    var theTable = $('#irregulartable').DataTable();
    theTable.clear().draw(false);

    $('#tabirregulartotal1').empty();
    $('#tabirregulartotal2').empty();

    $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    var irregulardatas = [];
    var irregulardata = [];
    var irregulardatasidx = 0;

    $.ajax({
        url: 'OverseasService.asmx/GetIrregularIncome1',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));

                var art = 0;
                var art1 = 0;
                var art2 = 0;
                var art3 = 0;

                art1 = parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));

                //=====================================================
                var c_j13 = $('#totalnetincome').val();
                var c_j14 = $('#totalbonus').val();
                c_j13 = c_j13.split(',').join('');
                c_j14 = c_j14.split(',').join('');
                c_j13 = parseFloat(c_j13) - parseFloat(c_j14);
                var c_n15 = parseFloat(c_j13) + parseFloat(c_j14);
                var c_n16 = $('#t1s6f21').val();
                c_n16 = c_n16.split(',').join('');
                if (c_n16 == "") {
                    c_n16 = 0;
                }
                var c_n17 = $('#lbltotalsummary1').text();
                var c_n17 = c_n17.split(',').join('');
                if (c_n17 == "") {
                    c_n17 = 0;
                }
                var c_r18 = +parseFloat(c_n16) + parseFloat(c_n17);
                var wperiode = $('#totalperiod').val();
                wperiode = wperiode.split(',').join('');
                if (wperiode == "") {
                    wperiode = 0;
                }
                var c_j21 = parseFloat(c_j13) / parseFloat(wperiode) * 12;
                var c_j22 = parseFloat(c_j14) / parseFloat(wperiode) * 12;
                var c_n23 = parseFloat(c_j21) + parseFloat(c_j22);
                var c_n24 = parseFloat(c_n16) / parseFloat(wperiode) * 12;
                var c_n25 = parseFloat(c_n17) / parseFloat(wperiode) * 12;
                var c_r26 = parseFloat(c_n23) + parseFloat(c_n24) + parseFloat(c_n25);
                var c_r28 = $('#t1s3f3').val();
                c_r28 = c_r28.split(',').join('');
                if (c_r28 == "") {
                    c_r28 = 0;
                }
                var c_af21 = 0;
                if (c_j21 > 0) {
                    c_af21 = parseInt((c_j21 / 1000) * 1000) - c_r28;
                    c_af21 = Math.floor(c_af21 / 1000) * 1000;

                }
                var c_af22 = c_j22;
                var c_af23 = 0;
                if (c_n23 > 0) {
                    c_af23 = parseInt((c_n23 / 1000) * 1000) - c_r28;
                    c_af23 = Math.floor(c_af23 / 1000) * 1000;
                }
                var c_af31 = parseInt(c_j21) - c_r28;
                var c_af32 = c_j22;
                var c_af33 = parseInt(c_af31) + parseInt(c_af32);
                var c_af34 = c_n24;
                var c_af35 = c_n25;
                var c_af36 = parseInt(c_af33) + parseInt(c_af34) + parseInt(c_af35);
                var c_af37 = 0;

                var c_r30 = 0;
                if (c_af36 > 0) {
                    c_af37 = parseInt((c_af36 / 1000) * 1000);
                    c_af37 = Math.floor(c_af37 / 1000) * 1000;
                    c_r30 = c_af36;
                }
                var c_j33 = 0;
                if (c_af31 <= 0) {
                    c_j33 = 0;
                } else if ((c_af31 > 0) && (c_af31 <= 50000000)) {
                    c_j33 = 0.05 * c_af21;
                } else if ((c_af31 > 50000000) && (c_af31 <= 250000000)) {
                    c_j33 = 0.15 * c_af21;
                } else if ((c_af31 > 250000000) && (c_af31 <= 500000000)) {
                    c_j33 = 0.25 * c_af21;
                } else {
                    c_j33 = 0.3 * c_af21;
                }
                var c_n35 = 0;
                if (c_af33 <= 0) {
                    c_n35 = 0;
                } else if ((c_af33 > 0) && (c_af33 <= 50000000)) {
                    c_n35 = 0.05 * c_af33;
                } else if ((c_af33 > 50000000) && (c_af33 <= 250000000)) {
                    c_n35 = 0.15 * c_af33 - 5000000;
                } else if ((c_af33 > 250000000) && (c_af33 <= 500000000)) {
                    c_n35 = 0.25 * c_af33 - 30000000;
                } else {
                    c_n35 = 0.3 * c_af23 - 55000000;
                }
                var c_j34 = c_n35 - c_j33;
                var c_r37 = 0;
                if (c_af37 <= 0) {
                    c_r37 = 0;
                } else if ((c_af37 > 0) && (c_af37 <= 50000000)) {
                    c_r37 = 0.05 * c_af37;
                } else if ((c_af37 > 50000000) && (c_af37 <= 250000000)) {
                    c_r37 = 0.15 * c_af37 - 5000000;
                } else if ((c_af37 > 250000000) && (c_af37 <= 500000000)) {
                    c_r37 = 0.25 * c_af37 - 30000000;
                } else {
                    c_r37 = 0.3 * c_af37 - 55000000;
                }
                var c_n36 = c_r37 - c_n35;
                var c_j40 = c_j33 / 12 * wperiode;
                var c_j41 = c_j34 / 12 * wperiode;
                var c_n42 = c_j40 + c_j41;
                var c_n43 = c_n36 / 12 * wperiode;
                var c_r44 = c_n42 + c_n43;

                art2 = c_r44;

                var rd = true;
                var at = 0;
                if (rd == true) {
                    at = c_r30;
                } else {
                    at = c_r30;
                }

                var grosincome = parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                art3 = ((((grosincome / wperiode) * 12) / c_r30) * art2);
                //=====================================================
                if (art1 < art2) {
                    art = art1;
                } else {
                    art = art2;
                }
                if (art > art3) {
                    art = art3;
                }

                if (form == "formNonUs") {
                    var sumtotalAll = 0;
                    for (var g = 1; g <= 4; g++) {
                        var t0 = $('#sumtotal_' + g + '_1').text().toString().replace(/[$,]+/g, "");
                        if (parseFloat(t0) > 0) {
                            var t1 = $('#sumtotal_' + g + '_3').text().toString().replace(/[$,]+/g, "");
                            var t3 = ((((parseFloat(t0) / wperiode) * 12) / c_r30) * art2);
                            var t5 = t1;
                            if (t5 > t3) {
                                t5 = t3;
                            }
                            if (t5 > art2) {
                                t5 = art2;
                            }
                            t5 = parseFloat(t5.toString().replace(/[$,]+/g, ""));
                            sumtotalAll = parseFloat(sumtotalAll) + parseFloat(t5);
                            $('#sumtotal_' + g + '_5').text(t5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        }
                    }
                    $('#lbltotalsummary2').text(sumtotalAll.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                }

                if (form == "form1770") {
                    //art = 0;
                }

                total2 = parseFloat(total2) + parseFloat(art);

                $('#tabirregulartotal1').empty();
                $('#tabirregulartotal2').empty();

                total1 = Math.round(total1);
                $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var typeincome = "";
                if (theData.type == 1) {
                    typeincome = "Dividend Income";
                } else if (theData.type == 2) {
                    typeincome = "Interest Income";
                } else if (theData.type == 3) {
                    typeincome = "Other Income";
                }

                if (form == "formUs") {
                    theTable.row.add([
                    typeincome,
                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    ''
                ]).draw(false);
                } else {
                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == theData.country && datairr[2] == typeincome });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(theData.country);
                        irregulardata.push(typeincome);
                        irregulardata.push(parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + art;

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    for (var e = 0; e < irregulardatas.length; e++ ) {
                        theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5]
                        ]).draw(false);
                    }
                    //                    theTable.row.add([
                    //                    theData.country,
                    //                    typeincome,
                    //                    parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    //                    parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    //                    art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                    //                ]).draw(false);
                }



                i++;
            });

            $("#irregulartable tbody tr").each(function () {
                if (form == "formUs") {
                    $(this).find('td:eq(1)').addClass('numcol');
                }
                $(this).find('td:eq(2)').addClass('numcol');
                $(this).find('td:eq(3)').addClass('numcol');
                $(this).find('td:eq(4)').addClass('numcol');
            });
            $("#irregulartable td.cencol").css('text-align', 'center');
            $("#irregulartable td.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });


    if (form == "formUs") {
        $.ajax({
            url: 'OverseasService.asmx/GetIrregularIncomeDetailed1',
            data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
            dataType: "json",
            method: 'GET',
            success: function (data) {
                var i = 1;
                $(data).each(function (index, theData) {

                    total1 = parseFloat(total1) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                    //total2 = parseFloat(total2) + parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, ""));

                    $('#tabirregulartotal1').empty();
                    $('#tabirregulartotal2').empty();


                    var typeincome = "DETAILED OF INCOME AND FTC INFORMATION";

                    var art = 0;
                    var art1 = 0;
                    var art2 = 0;
                    var art3 = 0;

                    art1 = parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));

                    //=====================================================
                    var c_j13 = $('#totalnetincome').val();
                    var c_j14 = $('#totalbonus').val();
                    c_j13 = c_j13.split(',').join('');
                    c_j14 = c_j14.split(',').join('');
                    c_j13 = parseFloat(c_j13) - parseFloat(c_j14);
                    var c_n15 = parseInt(c_j13) + parseInt(c_j14);
                    var c_n16 = $('#t1s6f21').val();
                    c_n16 = c_n16.split(',').join('');
                    if (c_n16 == "") {
                        c_n16 = 0;
                    }
                    if (form == "formUs") {
                        var c_n17 = $('#detailed3').text();
                    } else {
                        var c_n17 = $('#lbltotalsummary1').text();
                    }

                    var c_n17 = c_n17.split(',').join('');
                    if (c_n17 == "") {
                        c_n17 = 0;
                    }

                    var c_r18 = +parseInt(c_n16) + parseInt(c_n17);
                    var wperiode = $('#totalperiod').val();
                    wperiode = wperiode.split(',').join('');
                    if (wperiode == "") {
                        wperiode = 0;
                    }
                    var c_j21 = parseInt(c_j13) / parseInt(wperiode) * 12;
                    var c_j22 = parseInt(c_j14) / parseInt(wperiode) * 12;
                    var c_n23 = parseInt(c_j21) + parseInt(c_j22);
                    var c_n24 = parseInt(c_n16) / parseInt(wperiode) * 12;
                    var c_n25 = parseInt(c_n17) / parseInt(wperiode) * 12;
                    var c_r26 = parseInt(c_n23) + parseInt(c_n24) + parseInt(c_n25);
                    var c_r28 = $('#t1s3f3').val();
                    c_r28 = c_r28.split(',').join('');
                    if (c_r28 == "") {
                        c_r28 = 0;
                    }
                    var c_af21 = 0;
                    if (c_j21 > 0) {
                        c_af21 = parseInt((c_j21 / 1000) * 1000) - c_r28;
                        c_af21 = Math.floor(c_af21 / 1000) * 1000;

                    }
                    var c_af22 = c_j22;
                    var c_af23 = 0;
                    if (c_n23 > 0) {
                        c_af23 = parseInt((c_n23 / 1000) * 1000) - c_r28;
                        c_af23 = Math.floor(c_af23 / 1000) * 1000;
                    }
                    var c_af31 = parseInt(c_j21) - c_r28;
                    var c_af32 = c_j22;
                    var c_af33 = parseInt(c_af31) + parseInt(c_af32);
                    var c_af34 = c_n24;
                    var c_af35 = c_n25;
                    var c_af36 = parseInt(c_af33) + parseInt(c_af34) + parseInt(c_af35);
                    var c_af37 = 0;

                    var c_r30 = 0;
                    if (c_af36 > 0) {
                        c_af37 = parseInt((c_af36 / 1000) * 1000);
                        c_af37 = Math.floor(c_af37 / 1000) * 1000;
                        c_r30 = c_af36;
                    }

                    var c_j33 = 0;
                    if (c_af31 <= 0) {
                        c_j33 = 0;
                    } else if ((c_af31 > 0) && (c_af31 <= 50000000)) {
                        c_j33 = 0.05 * c_af21;
                    } else if ((c_af31 > 50000000) && (c_af31 <= 250000000)) {
                        c_j33 = 0.15 * c_af21 - 5000000;
                    } else if ((c_af31 > 250000000) && (c_af31 <= 500000000)) {
                        c_j33 = 0.25 * c_af21 - 30000000;
                    } else {
                        c_j33 = 0.3 * c_af21 - 55000000;
                    }
                    var c_n35 = 0;
                    if (c_af33 <= 0) {
                        c_n35 = 0;
                    } else if ((c_af33 > 0) && (c_af33 <= 50000000)) {
                        c_n35 = 0.05 * c_af33;
                    } else if ((c_af33 > 50000000) && (c_af33 <= 250000000)) {
                        c_n35 = 0.15 * c_af33 - 5000000;
                    } else if ((c_af33 > 250000000) && (c_af33 <= 500000000)) {
                        c_n35 = 0.25 * c_af33 - 30000000;
                    } else {
                        c_n35 = 0.3 * c_af23 - 55000000;
                    }
                    var c_j34 = c_n35 - c_j33;
                    var c_r37 = 0;
                    if (c_af37 <= 0) {
                        c_r37 = 0;
                    } else if ((c_af37 > 0) && (c_af37 <= 50000000)) {
                        c_r37 = 0.05 * c_af37;
                    } else if ((c_af37 > 50000000) && (c_af37 <= 250000000)) {
                        c_r37 = 0.15 * c_af37 - 5000000;
                    } else if ((c_af37 > 250000000) && (c_af37 <= 500000000)) {
                        c_r37 = 0.25 * c_af37 - 30000000;
                    } else {
                        c_r37 = 0.3 * c_af37 - 55000000;
                    }
                    var c_n36 = c_r37 - c_n35;
                    var c_j40 = c_j33 / 12 * wperiode;
                    var c_j41 = c_j34 / 12 * wperiode;
                    var c_n42 = c_j40 + c_j41;
                    var c_n43 = c_n36 / 12 * wperiode;
                    var c_r44 = c_n42 + c_n43;

                    art2 = c_r44;

                    var rd = true;
                    var at = 0;
                    if (rd == true) {
                        at = c_r30;
                    } else {
                        at = c_r30;
                    }

                    var grosincome = parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                    art3 = ((((grosincome / wperiode) * 12) / c_r30) * art2);

                    //=====================================================
                    if (art1 < art2) {
                        art = art1;
                    } else {
                        art = art2;
                    }
                    if (art > art3) {
                        art = art3;
                    }

                    total2 = parseFloat(total2) + parseFloat(art);

                    total1 = Math.round(total1);
                    $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == "US" && datairr[2] == typeincome });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push("US");
                        irregulardata.push(typeincome);
                        irregulardata.push(parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + art;

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    for (var e = 0; e < irregulardatas.length; e++) {
                        theTable.row.add([
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5]
                        ]).draw(false);
                    }

                    /*theTable.row.add([
                        typeincome,
                        parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                    ]).draw(false);*/
                    i++;
                });

                $("#irregulartable tbody tr").each(function () {
                    if (form == "formUs") {
                        $(this).find('td:eq(1)').addClass('numcol');
                    }
                    $(this).find('td:eq(2)').addClass('numcol');
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                });
                $("#irregulartable td.cencol").css('text-align', 'center');
                $("#irregulartable td.numcol").css('text-align', 'right');
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    $.ajax({
        url: 'OverseasService.asmx/GetIrregularIncome2',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, ""));
                //total2 = parseFloat(total2) + parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, ""));

                var art = 0;
                var art1 = 0;
                var art2 = 0;
                var art3 = 0;

                art1 = parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, ""));

                //=====================================================
                var c_j13 = $('#totalnetincome').val();
                var c_j14 = $('#totalbonus').val();
                c_j13 = c_j13.split(',').join('');
                c_j14 = c_j14.split(',').join('');
                c_j13 = parseFloat(c_j13) - parseFloat(c_j14);
                var c_n15 = parseInt(c_j13) + parseInt(c_j14);
                var c_n16 = $('#t1s6f21').val();
                c_n16 = c_n16.split(',').join('');
                if (c_n16 == "") {
                    c_n16 = 0;
                }
                if (form == "formUs") {
                    var c_n17 = $('#detailed3').text();
                } else {
                    var c_n17 = $('#lbltotalsummary1').text();
                }

                var c_n17 = c_n17.split(',').join('');
                if (c_n17 == "") {
                    c_n17 = 0;
                }

                var c_r18 = +parseInt(c_n16) + parseInt(c_n17);
                var wperiode = $('#totalperiod').val();
                wperiode = wperiode.split(',').join('');
                if (wperiode == "") {
                    wperiode = 0;
                }
                var c_j21 = parseInt(c_j13) / parseInt(wperiode) * 12;
                var c_j22 = parseInt(c_j14) / parseInt(wperiode) * 12;
                var c_n23 = parseInt(c_j21) + parseInt(c_j22);
                var c_n24 = parseInt(c_n16) / parseInt(wperiode) * 12;
                var c_n25 = parseInt(c_n17) / parseInt(wperiode) * 12;
                var c_r26 = parseInt(c_n23) + parseInt(c_n24) + parseInt(c_n25);
                var c_r28 = $('#t1s3f3').val();
                c_r28 = c_r28.split(',').join('');
                if (c_r28 == "") {
                    c_r28 = 0;
                }
                var c_af21 = 0;
                if (c_j21 > 0) {
                    c_af21 = parseInt((c_j21 / 1000) * 1000) - c_r28;
                    c_af21 = Math.floor(c_af21 / 1000) * 1000;

                }
                var c_af22 = c_j22;
                var c_af23 = 0;
                if (c_n23 > 0) {
                    c_af23 = parseInt((c_n23 / 1000) * 1000) - c_r28;
                    c_af23 = Math.floor(c_af23 / 1000) * 1000;
                }
                var c_af31 = parseInt(c_j21) - c_r28;
                var c_af32 = c_j22;
                var c_af33 = parseInt(c_af31) + parseInt(c_af32);
                var c_af34 = c_n24;
                var c_af35 = c_n25;
                var c_af36 = parseInt(c_af33) + parseInt(c_af34) + parseInt(c_af35);
                var c_af37 = 0;

                var c_r30 = 0;
                if (c_af36 > 0) {
                    c_af37 = parseInt((c_af36 / 1000) * 1000);
                    c_af37 = Math.floor(c_af37 / 1000) * 1000;
                    c_r30 = c_af36;
                }

                var c_j33 = 0;
                if (c_af31 <= 0) {
                    c_j33 = 0;
                } else if ((c_af31 > 0) && (c_af31 <= 50000000)) {
                    c_j33 = 0.05 * c_af21;
                } else if ((c_af31 > 50000000) && (c_af31 <= 250000000)) {
                    c_j33 = 0.15 * c_af21 - 5000000;
                } else if ((c_af31 > 250000000) && (c_af31 <= 500000000)) {
                    c_j33 = 0.25 * c_af21 - 30000000;
                } else {
                    c_j33 = 0.3 * c_af21 - 55000000;
                }
                var c_n35 = 0;
                if (c_af33 <= 0) {
                    c_n35 = 0;
                } else if ((c_af33 > 0) && (c_af33 <= 50000000)) {
                    c_n35 = 0.05 * c_af33;
                } else if ((c_af33 > 50000000) && (c_af33 <= 250000000)) {
                    c_n35 = 0.15 * c_af33 - 5000000;
                } else if ((c_af33 > 250000000) && (c_af33 <= 500000000)) {
                    c_n35 = 0.25 * c_af33 - 30000000;
                } else {
                    c_n35 = 0.3 * c_af23 - 55000000;
                }
                var c_j34 = c_n35 - c_j33;
                var c_r37 = 0;
                if (c_af37 <= 0) {
                    c_r37 = 0;
                } else if ((c_af37 > 0) && (c_af37 <= 50000000)) {
                    c_r37 = 0.05 * c_af37;
                } else if ((c_af37 > 50000000) && (c_af37 <= 250000000)) {
                    c_r37 = 0.15 * c_af37 - 5000000;
                } else if ((c_af37 > 250000000) && (c_af37 <= 500000000)) {
                    c_r37 = 0.25 * c_af37 - 30000000;
                } else {
                    c_r37 = 0.3 * c_af37 - 55000000;
                }
                var c_n36 = c_r37 - c_n35;
                var c_j40 = c_j33 / 12 * wperiode;
                var c_j41 = c_j34 / 12 * wperiode;
                var c_n42 = c_j40 + c_j41;
                var c_n43 = c_n36 / 12 * wperiode;
                var c_r44 = c_n42 + c_n43;

                art2 = c_r44;

                var rd = true;
                var at = 0;
                if (rd == true) {
                    at = c_r30;
                } else {
                    at = c_r30;
                }

                var grosincome = parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, ""));
                art3 = ((((grosincome / wperiode) * 12) / c_r30) * art2);

                //=====================================================
                if (art1 < art2) {
                    art = art1;
                } else {
                    art = art2;
                }
                if (art > art3) {
                    art = art3;
                }

                if (form == "form1770") {
                    //art = 0;
                }

                total2 = parseFloat(total2) + parseFloat(art);

                $('#tabirregulartotal1').empty();
                $('#tabirregulartotal2').empty();

                total1 = Math.round(total1);
                $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var typeincome = "Capital Income";
                if (form == "formUs") {
                    typeincome = "CAPITAL GAIN/LOSS";

                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == "US" && datairr[2] == typeincome });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push("US");
                        irregulardata.push(typeincome);
                        irregulardata.push(parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + art;

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    for (var e = 0; e < irregulardatas.length; e++) {
                        theTableirrus.row.add([
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5]
                        ]).draw(false);
                    }

                    /*theTableirrus.row.add([
                    typeincome,
                    parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                ]).draw(false);*/
                } else {
                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == theData.cap_country && datairr[2] == typeincome });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(theData.cap_country);
                        irregulardata.push(typeincome);
                        irregulardata.push(parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + art;

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    for (var e = 0; e < irregulardatas.length; e++) {
                        theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5]
                        ]).draw(false);
                    }

                    /*theTable.row.add([
                    theData.cap_country,
                    typeincome,
                    parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    art.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                    ]).draw(false);*/
                }

                i++;
            });

            $("#irregulartable tbody tr").each(function () {
                if (form == "formUs") {
                    $(this).find('td:eq(1)').addClass('numcol');
                }
                $(this).find('td:eq(2)').addClass('numcol');
                $(this).find('td:eq(3)').addClass('numcol');
                $(this).find('td:eq(4)').addClass('numcol');
            });
            $("#irregulartable td.cencol").css('text-align', 'center');
            $("#irregulartable td.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });
    $.ajax({
        url: 'OverseasService.asmx/GetIrregularIncome3',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.ren_amountrp.toString().replace(/[$,]+/g, ""));
                total2 = parseFloat(total2) + parseFloat(0);

                $('#tabirregulartotal1').empty();
                $('#tabirregulartotal2').empty();

                total1 = Math.round(total1);
                $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var typeincome = "";

                typeincome = "Rental Income/Loss";
                var ren_amountrp = theData.ren_amountrp;
                if (ren_amountrp == "") {
                    ren_amountrp = 0;
                }
                ren_amountrp = parseFloat(ren_amountrp.toString().replace(/[$,]+/g, ""));

                if (theData.type == 1) {
                    ren_amountrp = ren_amountrp * 1;
                } else if (theData.type == 2) {
                    ren_amountrp = ren_amountrp * -1;
                }

                if (form == "formUs") {
                    theTable.row.add([
                    typeincome,
                    ren_amountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    "0",
                    "0"
                ]).draw(false);
                }
                else {
                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == theData.ren_country && datairr[2] == typeincome });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(theData.ren_country);
                        irregulardata.push(typeincome);
                        irregulardata.push(parseFloat(ren_amountrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(0);
                        irregulardata.push(0);

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(ren_amountrp.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + 0;
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + 0;

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    for (var e = 0; e < irregulardatas.length; e++) {
                        theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5]
                        ]).draw(false);
                    }

                    /*theTable.row.add([
                    theData.ren_country,
                    typeincome,
                    ren_amountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    "0",
                    "0"
                    ]).draw(false);
                    */
                }


                i++;
            });

            $("#irregulartable tbody tr").each(function () {
                if (form == "formUs") {
                    $(this).find('td:eq(1)').addClass('numcol');
                }
                $(this).find('td:eq(2)').addClass('numcol');
                $(this).find('td:eq(3)').addClass('numcol');
                $(this).find('td:eq(4)').addClass('numcol');
            });
            $("#irregulartable td.cencol").css('text-align', 'center');
            $("#irregulartable td.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });

}

function GetIrregularIncomeNew(TaxPlayerNumber, form, year, ammend) {
    console.log("new");
    var total1 = 0;
    var total2 = 0;
    var total3 = 0;
    var theTable = $('#irregulartable').DataTable();
    theTable.clear().draw(false);

    $('#tabirregulartotal1').empty();
    $('#tabirregulartotal2').empty();
    $('#tabirregulartotal3').empty();

    $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#tabirregulartotal3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    var irregulardatas = [];
    var irregulardata = [];
    var irregulardatasidx = 0;

    $.ajax({
        url: 'OverseasService.asmx/GetIrregularIncomeNew',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {
                var dt2 = theData.data2;
                var dt3 = theData.data3;
                var dt4 = theData.data4;
                var dt5 = theData.data5;
                var dt6 = theData.data6;
                var dt7 = theData.data7;

                if (dt2 == "") {
                    dt2 = 0;
                }
                if (dt3 == "") {
                    dt3 = 0;
                }
                if (dt4 == "") {
                    dt4 = 0;
                }
                if (dt5 == "") {
                    dt5 = 0;
                }
                if (dt6 == "") {
                    dt6 = 0;
                }
                if (dt7 == "") {
                    dt7 = 0;
                }


                $('#tabirregulartotal1').empty();
                $('#tabirregulartotal2').empty();

                var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == theData.country && datairr[2] == theData.data1 });
                //not group irregular
                dataexist = "";
                //not group irregular
                if (form == "formJapan") {
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(theData.country);
                        irregulardata.push(theData.data1);
                        irregulardata.push(theData.data2);
                        irregulardata.push(theData.data3);

                        irregulardata.push(parseFloat(dt4.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(dt5.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(dt6.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(dt7.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardata.push(theData.id);
                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);
                        irregulardata.push(dataexist[0][3]);
                        irregulardata.push(dataexist[0][4]);

                        var bil1 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + parseFloat(dt2.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][6].toString().replace(/[$,]+/g, "")) + parseFloat(dt3.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][7].toString().replace(/[$,]+/g, "")) + parseFloat(dt4.toString().replace(/[$,]+/g, ""));
                        var bil4 = parseFloat(dataexist[0][8].toString().replace(/[$,]+/g, "")) + parseFloat(dt4.toString().replace(/[$,]+/g, ""));

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }
                } else {
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(theData.country);
                        irregulardata.push(theData.data1);

                        irregulardata.push(parseFloat(dt2.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(dt3.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(dt4.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardata.push(theData.id);
                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);

                        var bil1 = parseFloat(dataexist[0][3].toString().replace(/[$,]+/g, "")) + parseFloat(dt2.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(dt3.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + parseFloat(dt4.toString().replace(/[$,]+/g, ""));

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }
                }

                total1 = 0;
                total2 = 0;
                total3 = 0;
                theTable.clear().draw(false);
                for (var e = 0; e < irregulardatas.length; e++) {
                    if (form == "formUs") {
                        theTable.row.add([
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5],
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetIrregularByID(' + irregulardatas[e][6] + ')" data-toggle="modal" data-target="#irregularform" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIrregular(' + irregulardatas[e][6] + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);

                        total1 = parseFloat(total1) + parseFloat(irregulardatas[e][3].toString().replace(/[$,]+/g, ""));
                        total2 = parseFloat(total2) + parseFloat(irregulardatas[e][5].toString().replace(/[$,]+/g, ""));
                        $('#tabirregulartotal1').empty();
                        $('#tabirregulartotal2').empty();
                        $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    } else if (form == "formJapan") {
                        theTable.row.add([
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5],
                            irregulardatas[e][6],
                            irregulardatas[e][7],
                            irregulardatas[e][8],
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetIrregularJapanByID(' + irregulardatas[e][9] + ')" data-toggle="modal" data-target="#irregularform" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIrregular(' + irregulardatas[e][9] + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);

                        total1 = parseFloat(total1) + parseFloat(irregulardatas[e][6].toString().replace(/[$,]+/g, ""));
                        total2 = parseFloat(total2) + parseFloat(irregulardatas[e][7].toString().replace(/[$,]+/g, ""));
                        total3 = parseFloat(total3) + parseFloat(irregulardatas[e][8].toString().replace(/[$,]+/g, ""));

                        $('#tabirregulartotal1').empty();
                        $('#tabirregulartotal2').empty();
                        $('#tabirregulartotal3').empty();
                        $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#tabirregulartotal3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    } else {
                        theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5],
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetIrregularByID(' + irregulardatas[e][6] + ')" data-toggle="modal" data-target="#irregularform" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a href="#" onclick="DeleteIrregular(' + irregulardatas[e][6] + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);

                        total1 = parseFloat(total1) + parseFloat(irregulardatas[e][3].toString().replace(/[$,]+/g, ""));
                        total2 = parseFloat(total2) + parseFloat(irregulardatas[e][5].toString().replace(/[$,]+/g, ""));
                        $('#tabirregulartotal1').empty();
                        $('#tabirregulartotal2').empty();
                        $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    }
                }

                i++;
            });

            $("#irregulartable tbody tr").each(function () {
                if (form == "formUs") {
                    $(this).find('td:eq(1)').addClass('numcol');
                }
                $(this).find('td:eq(2)').addClass('numcol');
                $(this).find('td:eq(3)').addClass('numcol');
                $(this).find('td:eq(4)').addClass('numcol');
                $(this).find('td:eq(5)').addClass('numcol');
                $(this).find('td:eq(6)').addClass('numcol');
            });
            $("#irregulartable td.cencol").css('text-align', 'center');
            $("#irregulartable td.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function irrchange(val) {
    if (val == "Japan Salary from Certificate of Income (CoI)") {
        $('#data2').val("Penghasilan dari Jepang");
    } else if (val == "Other payments/allowances from Certificate of Salary") {
        $('#data2').val("Penghasilan lainnya");
    } else if (val == "Bonuses") {
        $('#data2').val("Bonus");
    } else {
        $('#data2').val("");
    }
    
}

function GetIrregularIncomeJapan2(TaxPlayerNumber, form, year, ammend) {
    var total1 = 0;
    var total2 = 0;
    var total3 = 0;

    var theTable = $('#irregulartable').DataTable();
    theTable.clear().draw();

    $('#tabirregulartotal1').empty();
    $('#tabirregulartotal2').empty();
    $('#tabirregulartotal3').empty();

    $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#tabirregulartotal3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    var irregulardatas = [];
    var irregulardata = [];
    var irregulardatasidx = 0;

    $.ajax({
        url: 'OverseasService.asmx/GetIrregularIncome1',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                total2 = parseFloat(total2) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, ""));
                total3 = parseFloat(total3) + parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, ""));

                $('#tabirregulartotal1').empty();
                $('#tabirregulartotal2').empty();
                $('#tabirregulartotal3').empty();

                $('#tabirregulartotal1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabirregulartotal2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabirregulartotal3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var typeincome = "";
                if (theData.type == 1) {
                    title = "Japan Salary from Certificate of Income (CoI)";
                    titlebahasa = "Penghasilan dari Jepang";
                } else if (theData.type == 2) {
                    title = "Japan Salary from Certificate of Income (CoI)";
                    titlebahasa = "Penghasilan dari Jepang";
                } else if (theData.type == 3) {
                    title = "Other payments/allowances from Certificate of Salary";
                    titlebahasa = "Penghasilan lainnya";
                } else if (theData.type == 4) {
                    title = "Other payments/allowances from Certificate of Salary";
                    titlebahasa = "Penghasilan lainnya";
                } else if (theData.type == 5) {
                    title = "Bonuses";
                    titlebahasa = "Bonus";
                }

                theTable.row.add([
                    title,
                    titlebahasa,
                    theData.currency,
                    theData.incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.incomerp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    theData.allowedftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                ]).draw(false);

                var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == title });
                if (dataexist.length == 0) {
                    irregulardata = [];
                    irregulardata.push(irregulardatasidx);
                    irregulardata.push(title);
                    irregulardata.push(titlebahasa);
                    irregulardata.push(theData.currency);
                    irregulardata.push(parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(parseFloat(theData.incomerp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(theData.allowedftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    irregulardatas.push(irregulardata);
                    irregulardatasidx++;
                } else {
                    irregulardata = [];
                    irregulardata.push(dataexist[0][0]);
                    irregulardata.push(dataexist[0][1]);
                    irregulardata.push(dataexist[0][2]);
                    irregulardata.push(dataexist[0][3]);

                    var bil1 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(theData.incomecurrency.toString().replace(/[$,]+/g, ""));
                    var bil2 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                    var bil3 = parseFloat(dataexist[0][6].toString().replace(/[$,]+/g, "")) + parseFloat(theData.taxpaidrp.toString().replace(/[$,]+/g, "")); ;
                    var bil4 = parseFloat(dataexist[0][7].toString().replace(/[$,]+/g, "")) + parseFloat(theData.allowedftc.toString().replace(/[$,]+/g, "")); ;

                    irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    irregulardata.push(bil4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    irregulardatas[dataexist[0][0]] = irregulardata;
                }

                total1 = 0;
                total2 = 0;
                total3 = 0;
                theTable.clear().draw(false);
                for (var e = 0; e < irregulardatas.length; e++) {
                    theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5],
                            irregulardatas[e][6],
                            irregulardatas[e][7]
                        ]).draw(false);
                }

                $("#irregulartable tbody tr").each(function () {
                    $(this).find('td:eq(0)').addClass('cencol');
                    $(this).find('td:eq(1)').addClass('cencol');
                    $(this).find('td:eq(2)').addClass('cencol');
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                });
                $("#irregulartable td.cencol").css('text-align', 'center');
                $("#irregulartable td.numcol").css('text-align', 'right');

                i++;
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetRentalBy(type, TaxPlayerNumber) {
    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    $.ajax({
        url: 'OverseasService.asmx/GetRentalBy',
        data: 'type=' + type + '&TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + selectedform
            + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#rentalTable' + type).DataTable();
            theTable.clear().draw();
            var title = "";
            if (type == 1) {
                title = "Rental Income";
            } else if (type == 2) {
                title = "Expenses";
            } else if (type == 3) {
                title = "Tax paid/withheld";
            }

            var i = 1;
            var total1 = 0;
            var total2 = 0;
            $('#tabrental' + type + 'total1').empty();
            $('#tabrental' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tabrental' + type + 'total2').empty();
            $('#tabrental' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

            if (type == 1) {
                ren_nettaxpaidexchrate = 0;
            }

            if ($('#selectedform').val() != "formJapan") {
                $('#ren_nettaxpaidexchrate').val(ren_nettaxpaidexchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

            }

            $(data).each(function (index, theData) {

                var ren_amountcurrency = theData.ren_amountcurrency;
                if (ren_amountcurrency == "") {
                    ren_amountcurrency = 0;
                }

                var ren_exchrate = theData.ren_exchrate;
                if (ren_exchrate == "") {
                    ren_exchrate = 0;
                }

                var ren_amountrp = theData.ren_amountrp;
                if (ren_amountrp == "") {
                    ren_amountrp = 0;
                }

                total1 = parseFloat(total1) + parseFloat(ren_amountcurrency.toString().replace(/[$,]+/g, ""));
                total2 = parseFloat(total2) + parseFloat(ren_amountrp.toString().replace(/[$,]+/g, ""));

                $('#tabrental' + type + 'total1').empty();
                $('#tabrental' + type + 'total1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#tabrental' + type + 'total2').empty();
                $('#tabrental' + type + 'total2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (i == 1 && type == 1) {
                    ren_nettaxpaidexchrate = theData.ren_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
                }



                if (type == 3) {
                    theTable.row.add([
                        i,
                        theData.ren_country,
                        parseFloat(ren_amountcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                        parseFloat(ren_exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                        parseFloat(ren_amountrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        '<ul class=\"icons-list\"><li><a href="#" onclick="GetRentalByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#rental-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteRental(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                    ]).draw(false);
                } else {
                    theTable.row.add([
                        i,
                        theData.ren_country,
                        theData.ren_information,
                        theData.ren_currency,
                        theData.ren_dateofreceipt,
                        parseFloat(ren_amountcurrency.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                        parseFloat(ren_exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                        parseFloat(ren_amountrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        '<ul class=\"icons-list\"><li><a href="#" onclick="GetRentalByID(' + theData.id + ', \'' + title + '\', ' + type + ')" data-toggle="modal" data-target="#rental-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                    + '<li><a href="#" onclick="DeleteRental(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                    ]).draw(false);
                }



                i++;
            });


            if (type != 3) {
                var sub1total1 = $('#tabrental1total1').text().toString().replace(/[$,]+/g, "");
                var sub1total2 = $('#tabrental1total2').text().toString().replace(/[$,]+/g, "");

                var sub2total1 = $('#tabrental2total1').text().toString().replace(/[$,]+/g, "");
                var sub2total2 = $('#tabrental2total2').text().toString().replace(/[$,]+/g, "");
                var ren_netamountcurrency = parseFloat(sub1total1) - parseFloat(sub2total1);
                var ren_netamountrp = parseFloat(sub1total2) - parseFloat(sub2total2);


                $('#ren_netamountcurrency').val(ren_netamountcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#ren_netamountrp').val(ren_netamountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#ren_nettaxpaidexchrate').val(ren_nettaxpaidexchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var theTableFooter = $('#rentalTable' + type + ' tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
            "<td colspan='5'>Sub Total</td>" +
            "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
            "<td></td>" +
            "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
            "<td></td>" +
            "</tr>");

                theTableFooter.append("<tr>" +
            "<td colspan='9'>Sub Total By Country</td>" +
            "</tr>");
            }

            var selectedform = $('#selectedform').val();
            var selectedyear = $('#t1s1f3').val();
            var selectedammend = $('#t1s2f2').val();

            $.ajax({
                url: 'OverseasService.asmx/GetRentalByCountry',
                data: 'type=' + type + '&TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + selectedform
            + '&year=' + selectedyear + '&ammend=' + selectedammend,
                dataType: "json",
                method: 'GET',
                success: function (data) {
                    var datalength = data.length;
                    $(data).each(function (index, theData) {
                        if (type != 3) {
                            theTableFooter.append("<tr>" +
                            "<td colspan='5'>" + theData.ren_country + "</td>" +
                            "<td style='text-align:right;'>" + parseFloat(theData.ren_amountcurrency).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                            "<td></td>" +
                            "<td style='text-align:right;'>" + parseFloat(theData.ren_amountrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                            "<td></td>" +
                            "</tr>");
                        }
                        var sumrental = [];
                        sumrental.push(theData.ren_country);
                        sumrental.push(type);
                        sumrental.push(parseFloat(theData.ren_amountrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        
                        sumrentals.push(sumrental);
                        if (type != 3) {
                            if (index === (datalength - 1) && type == 2 && selectedform != "formJapan") {
                                GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                            }
                        }
                    });
                },
                error: function (err) {
                    console.log(err);
                }
            });

            if (type == 1) {
                $("#rentalTable1 tbody tr").each(function () {
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                });
                $("#rentalTable1 td.cencol").css('text-align', 'center');
                $("#rentalTable1 td.numcol").css('text-align', 'right');
            } else if (type == 2) {
                $("#rentalTable2 tbody tr").each(function () {
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                });
                $("#rentalTable2 td.cencol").css('text-align', 'center');
                $("#rentalTable2 td.numcol").css('text-align', 'right');
            } else if (type == 3) {
                $("#rentalTable3 tbody tr").each(function () {
                    $(this).find('td:eq(2)').addClass('numcol');
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                });
                $("#rentalTable3 td.cencol").css('text-align', 'center');
                $("#rentalTable3 td.numcol").css('text-align', 'right');
            }
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function GetSummary(TaxPlayerNumber, form, year, ammend) {
    var theTable = $('#summarytable').DataTable();
    
    var countryList = [];
    countryList.push("Afganistan");
    countryList.push("Albania");
    countryList.push("Algeria");
    countryList.push("American Samoa");
    countryList.push("Andorra");
    countryList.push("Angola");
    countryList.push("Anguilla");
    countryList.push("Antigua &amp; Barbuda");
    countryList.push("Argentina");
    countryList.push("Armenia");
    countryList.push("Aruba");
    countryList.push("Australia");
    countryList.push("Austria");
    countryList.push("Azerbaijan");
    countryList.push("Bahamas");
    countryList.push("Bahrain");
    countryList.push("Bangladesh");
    countryList.push("Barbados");
    countryList.push("Belarus");
    countryList.push("Belgium");
    countryList.push("Belize");
    countryList.push("Benin");
    countryList.push("Bermuda");
    countryList.push("Bhutan");
    countryList.push("Bolivia");
    countryList.push("Bonaire");
    countryList.push("Bosnia &amp; Herzegovina");
    countryList.push("Botswana");
    countryList.push("Brazil");
    countryList.push("British Indian Ocean Ter");
    countryList.push("Brunei");
    countryList.push("Bulgaria");
    countryList.push("Burkina Faso");
    countryList.push("Burundi");
    countryList.push("Cambodia");
    countryList.push("Cameroon");
    countryList.push("Canada");
    countryList.push("Canary Islands");
    countryList.push("Cape Verde");
    countryList.push("Cayman Islands");
    countryList.push("Central African Republic");
    countryList.push("Chad");
    countryList.push("Channel Islands");
    countryList.push("Chile");
    countryList.push("China");
    countryList.push("Christmas Island");
    countryList.push("Cocos Island");
    countryList.push("Colombia");
    countryList.push("Comoros");
    countryList.push("Congo");
    countryList.push("Cook Islands");
    countryList.push("Costa Rica");
    countryList.push("Cote DIvoire");
    countryList.push("Croatia");
    countryList.push("Cuba");
    countryList.push("Curaco");
    countryList.push("Cyprus");
    countryList.push("Czech Republic");
    countryList.push("Denmark");
    countryList.push("Djibouti");
    countryList.push("Dominica");
    countryList.push("Dominican Republic");
    countryList.push("East Timor");
    countryList.push("Ecuador");
    countryList.push("Egypt");
    countryList.push("El Salvador");
    countryList.push("Equatorial Guinea");
    countryList.push("Eritrea");
    countryList.push("Estonia");
    countryList.push("Ethiopia");
    countryList.push("Falkland Islands");
    countryList.push("Faroe Islands");
    countryList.push("Fiji");
    countryList.push("Finland");
    countryList.push("France");
    countryList.push("French Guiana");
    countryList.push("French Polynesia");
    countryList.push("French Southern Ter");
    countryList.push("Gabon");
    countryList.push("Gambia");
    countryList.push("Georgia");
    countryList.push("Germany");
    countryList.push("Ghana");
    countryList.push("Gibraltar");
    countryList.push("Great Britain");
    countryList.push("Greece");
    countryList.push("Greenland");
    countryList.push("Grenada");
    countryList.push("Guadeloupe");
    countryList.push("Guam");
    countryList.push("Guatemala");
    countryList.push("Guinea");
    countryList.push("Guyana");
    countryList.push("Haiti");
    countryList.push("Hawaii");
    countryList.push("Honduras");
    countryList.push("Hong Kong");
    countryList.push("Hungary");
    countryList.push("Iceland");
    countryList.push("India");
    countryList.push("Indonesia");
    countryList.push("Iran");
    countryList.push("Iraq");
    countryList.push("Ireland");
    countryList.push("Isle of Man");
    countryList.push("Israel");
    countryList.push("Italy");
    countryList.push("Jamaica");
    countryList.push("Japan");
    countryList.push("Jordan");
    countryList.push("Kazakhstan");
    countryList.push("Kenya");
    countryList.push("Kiribati");
    countryList.push("Korea North");
    countryList.push("Korea Sout");
    countryList.push("Kuwait");
    countryList.push("Kyrgyzstan");
    countryList.push("Laos");
    countryList.push("Latvia");
    countryList.push("Lebanon");
    countryList.push("Lesotho");
    countryList.push("Liberia");
    countryList.push("Libya");
    countryList.push("Liechtenstein");
    countryList.push("Lithuania");
    countryList.push("Luxembourg");
    countryList.push("Macau");
    countryList.push("Macedonia");
    countryList.push("Madagascar");
    countryList.push("Malaysia");
    countryList.push("Malawi");
    countryList.push("Maldives");
    countryList.push("Mali");
    countryList.push("Malta");
    countryList.push("Marshall Islands");
    countryList.push("Martinique");
    countryList.push("Mauritania");
    countryList.push("Mauritius");
    countryList.push("Mayotte");
    countryList.push("Mexico");
    countryList.push("Midway Islands");
    countryList.push("Moldova");
    countryList.push("Monaco");
    countryList.push("Mongolia");
    countryList.push("Montserrat");
    countryList.push("Morocco");
    countryList.push("Mozambique");
    countryList.push("Myanmar");
    countryList.push("Nambia");
    countryList.push("Nauru");
    countryList.push("Nepal");
    countryList.push("Netherland Antilles");
    countryList.push("Netherlands");
    countryList.push("Nevis");
    countryList.push("New Caledonia");
    countryList.push("New Zealand");
    countryList.push("Nicaragua");
    countryList.push("Niger");
    countryList.push("Nigeria");
    countryList.push("Niue");
    countryList.push("Norfolk Island");
    countryList.push("Norway");
    countryList.push("Oman");
    countryList.push("Pakistan");
    countryList.push("Palau Island");
    countryList.push("Palestine");
    countryList.push("Panama");
    countryList.push("Papua New Guinea");
    countryList.push("Paraguay");
    countryList.push("Peru");
    countryList.push("Phillipines");
    countryList.push("Pitcairn Island");
    countryList.push("Poland");
    countryList.push("Portugal");
    countryList.push("Puerto Rico");
    countryList.push("Qatar");
    countryList.push("Republic of Montenegro");
    countryList.push("Republic of Serbia");
    countryList.push("Reunion");
    countryList.push("Romania");
    countryList.push("Russia");
    countryList.push("Rwanda");
    countryList.push("St Barthelemy");
    countryList.push("St Eustatius");
    countryList.push("St Helena");
    countryList.push("St Kitts-Nevis");
    countryList.push("St Lucia");
    countryList.push("St Maarten");
    countryList.push("St Pierre &amp; Miquelon");
    countryList.push("St Vincent &amp; Grenadines");
    countryList.push("Saipan");
    countryList.push("Samoa");
    countryList.push("Samoa American");
    countryList.push("San Marino");
    countryList.push("Sao Tome &amp; Principe");
    countryList.push("Saudi Arabia");
    countryList.push("Senegal");
    countryList.push("Serbia");
    countryList.push("Seychelles");
    countryList.push("Sierra Leone");
    countryList.push("Singapore");
    countryList.push("Slovakia");
    countryList.push("Slovenia");
    countryList.push("Solomon Islands");
    countryList.push("Somalia");
    countryList.push("South Africa");
    countryList.push("Spain");
    countryList.push("Sri Lanka");
    countryList.push("Sudan");
    countryList.push("Suriname");
    countryList.push("Swaziland");
    countryList.push("Sweden");
    countryList.push("Switzerland");
    countryList.push("Syria");
    countryList.push("Tahiti");
    countryList.push("Taiwan");
    countryList.push("Tajikistan");
    countryList.push("Tanzania");
    countryList.push("Thailand");
    countryList.push("Togo");
    countryList.push("Tokelau");
    countryList.push("Tonga");
    countryList.push("Trinidad &amp; Tobago");
    countryList.push("Tunisia");
    countryList.push("Turkey");
    countryList.push("Turkmenistan");
    countryList.push("Turks &amp; Caicos Is");
    countryList.push("Tuvalu");
    countryList.push("Uganda");
    countryList.push("Ukraine");
    countryList.push("United Arab Erimates");
    countryList.push("United Kingdom");
    countryList.push("United States of America");
    countryList.push("Uraguay");
    countryList.push("Uzbekistan");
    countryList.push("Vanuatu");
    countryList.push("Vatican City State");
    countryList.push("Venezuela");
    countryList.push("Vietnam");
    countryList.push("Virgin Islands (Brit)");
    countryList.push("Virgin Islands (USA)");
    countryList.push("Wake Island");
    countryList.push("Wallis &amp; Futana Is");
    countryList.push("Yemen");
    countryList.push("Zaire");
    countryList.push("Zambia");
    countryList.push("Zimbabwe");
    var j = 1;
    var k = 0;
    var total = 0;
    var total_2 = 0;
    theTable.clear().draw(false);
    for (var i = 0; i < countryList.length; i++) {
        $.ajax({
            url: 'OverseasService.asmx/GetSummary',
            data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&country=' + countryList[i] + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
            dataType: "json",
            method: 'GET',
            success: function (data) {
                $(data).each(function (index, theData) {
                    var tmpren = 0;
                    var tmpexp = 0;
                    var tmptax = 0;

                    for (var y = 0; y < sumrentals.length; y++) {
                        var tempdataval = sumrentals[y][2];
                        if (sumrentals[y][0] == theData.country && sumrentals[y][1] == 1) {
                            tmpren = parseFloat(tmpren) + parseFloat(tempdataval.toString().replace(/[$,]+/g, ""));
                        } else if (sumrentals[y][0] == theData.country && sumrentals[y][1] == 2) {
                            tmpexp = parseFloat(tmpexp) + parseFloat(tempdataval.toString().replace(/[$,]+/g, ""));
                        } else if (sumrentals[y][0] == theData.country && sumrentals[y][1] == 3) {
                            tmptax = parseFloat(tempdataval.toString().replace(/[$,]+/g, ""));
                        }
                    }

                    /*var ren1 = $('#ren_netamountrp').val().toString().replace(/[$,]+/g, "");
                    ren1 = ren1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });

                    var ren2 = $('#ren_nettaxpaidamountrp').val().toString().replace(/[$,]+/g, "");
                    ren2 = ren2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });*/

                    if (theData.incomerp1 == "") {
                        theData.incomerp1 = 0;
                    }
                    if (theData.incomerp2 == "") {
                        theData.incomerp2 = 0;
                    }
                    if (theData.incomerp3 == "") {
                        theData.incomerp3 = 0;
                    }
                    if (theData.taxpaidrp1 == "") {
                        theData.taxpaidrp1 = 0;
                    }
                    if (theData.taxpaidrp2 == "") {
                        theData.taxpaidrp2 = 0;
                    }
                    if (theData.taxpaidrp3 == "") {
                        theData.taxpaidrp3 = 0;
                    }
                    if (theData.allowedftc1 == "") {
                        theData.allowedftc1 = 0;
                    }
                    if (theData.allowedftc2 == "") {
                        theData.allowedftc2 = 0;
                    }
                    if (theData.allowedftc3 == "") {
                        theData.allowedftc3 = 0;
                    }
                    if (theData.cap_gainlossrp == "") {
                        theData.cap_gainlossrp = 0;
                    }
                    if (theData.cap_taxpaidrp == "") {
                        theData.cap_taxpaidrp = 0;
                    }

                    var ren1 = tmpren - tmpexp;
                    var ren2 = tmptax;

                    if (ren1 == 0) {
                        ren1 = 0;
                    }
                    if (ren1 == 0) {
                        ren2 = 0;
                    }

                    var total1 = 0;
                    var total2 = 0;
                    var total3 = 0;
                    var total4 = 0;
                    var total5 = 0;

                    var cap1 = parseFloat(theData.cap_gainlossrp);
                    if (cap1 < 0) {
                        cap1 = 0;
                    }
                    var cap2 = parseFloat(theData.cap_taxpaidrp);
                    if (cap1 == 0) {
                        cap2 = 0;
                    }
                    var cap3 = cap1;
                    if (cap3 > cap2) {
                        cap3 = cap2;
                    }
                    cap3 = cap2;

                    var dataren1 = parseFloat(ren1);
                    if (dataren1 < 0) {
                        dataren1 = 0;
                    }
                    var dataren2 = parseFloat(ren2);
                    if (dataren1 == 0) {
                        dataren2 = 0;
                    }
                    var dataren3 = dataren1;
                    if (dataren3 > dataren2) {
                        dataren3 = dataren2;
                    }
                    dataren3 = dataren2;

                    if (form == "form1770") {
                        cap3 = 0;
                        dataren3 = 0;
                    }

                    if (isNaN(cap3)) {
                        cap3 = 0;
                    }

                    if (cap3 == -NaN) {
                        cap3 = 0;
                    }

                    if (cap3 == NaN) {
                        cap3 = 0;
                    }

                    total1 = Math.round(parseFloat(theData.incomerp1)) + Math.round(parseFloat(theData.incomerp2)) +
                    Math.round(parseFloat(theData.incomerp3)) + Math.round(parseFloat(cap1)) + Math.round(parseFloat(dataren1));
                    total1 = total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });

                    total2 = Math.round(parseFloat(theData.taxpaidrp1)) + Math.round(parseFloat(theData.taxpaidrp2)) +
                    Math.round(parseFloat(theData.taxpaidrp3)) + Math.round(parseFloat(cap2)) + Math.round(parseFloat(dataren2));
                    total2 = total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });

                    total3 = Math.round(parseFloat(theData.allowedftc1)) + Math.round(parseFloat(theData.allowedftc2)) +
                    Math.round(parseFloat(theData.allowedftc3)) + Math.round(parseFloat(cap3)) + Math.round(parseFloat(dataren3));
                    total3 = total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });


                    if (total1 < 0) {
                        total4 = 0;
                    } else {
                        total4 = total1;
                    }

                    if (form == "form1770" || form == "formNonUs") {
                        total5 = total3;
                    }
                    total = parseFloat(total.toString().replace(/[$,]+/g, "")) + parseFloat(total4.toString().replace(/[$,]+/g, ""));
                    total_2 = parseFloat(total_2.toString().replace(/[$,]+/g, "")) + parseFloat(total5.toString().replace(/[$,]+/g, ""));
                    total4 = total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
                    total5 = total5.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
                    $('#lbltotalsummary1').text(total.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $('#lbltotalsummary2').text(total_2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    theTable.row.add([
                        j,
                        theData.country + '<br />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b>Sub Total</b>',
                        'Dividend<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        'Interest<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        'Other<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        'Capital Gain/loss<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        'Rental income/loss<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;',
                        parseFloat(theData.incomerp1).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.incomerp2).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.incomerp3).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="cap1-' + j + '">' + parseFloat(cap1).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="dataren1-' + j + '">' + parseFloat(dataren1).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b><span id="sumtotal_' + j + '_1' + '">' + total1 + '</span></b>',
                        parseFloat(theData.taxpaidrp1).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.taxpaidrp2).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.taxpaidrp3).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="cap2-' + j + '">' + parseFloat(cap2).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="dataren2-' + j + '">' + parseFloat(dataren2).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b>' + total2 + '</b>',
                        parseFloat(theData.allowedftc1).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.allowedftc2).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        parseFloat(theData.allowedftc3).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="cap3-' + j + '">' + parseFloat(cap3).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<span id="dataren3-' + j + '">' + parseFloat(dataren3).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + '</span>' + '<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b><span id="sumtotal_' + j + '_3' + '">' + total3 + '</span></b>',
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b>' + total4 + '</b>',
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="border-top:0px;margin-top: 0px; margin-bottom:0px;" />' +
                        '&nbsp;<hr style="margin-top: 0px; margin-bottom:0px;" />' +
                        '<b><span id="sumtotal_' + j + '_5' + '">' + total5 + '<span></b>'
                    ]).draw(false);
                    j++;
                    k = j;
                });

                $("#summarytable tbody tr").each(function () {
                    $(this).find('td:eq(3)').addClass('numcol');
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                });
                $("#summarytable td.cencol").css('text-align', 'center');
                $("#summarytable td.numcol").css('text-align', 'right');
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    if (form == "form1770") {
        var lbltotalsummary2 = 0;
        for (var i = 0; i < countryList.length; i++) {
            $.ajax({
                url: 'OverseasService.asmx/GetSummary',
                data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&country=' + countryList[i] + '&form=' + form + '&year=' + year + '&ammend=' + ammend,
                dataType: "json",
                method: 'GET',
                success: function (data) {
                    $(data).each(function (index, theData) {

                        var netbusiness = 0;
                        if ($('#t1s8f1').val() == "on") {
                            var var_1a = 0;
                            var var_1b = 0;
                            var var_1c = 0;
                            var var_1d = 0;
                            var var_1e = 0;
                            if ($('#t1s8f14').val() != "") {
                                var_1a = parseFloat($('#t1s8f14').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f15').val() != "") {
                                var_1b = parseFloat($('#t1s8f15').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f16').val() != "") {
                                var_1d = parseFloat($('#t1s8f16').val().toString().replace(/[$,]+/g, ""));
                            }
                            var_1c = var_1a - var_1b;
                            var_1e = var_1c - var_1d;

                            var var_2a = 0;
                            var var_2b = 0;
                            var var_2c = 0;
                            var var_2d = 0;
                            var var_2e = 0;
                            var var_2f = 0;
                            var var_2g = 0;
                            var var_2h = 0;
                            var var_2i = 0;
                            var var_2j = 0;
                            var var_2k = 0;
                            var var_2l = 0;
                            if ($('#t1s8f17').val() != "") {
                                var_2a = parseFloat($('#t1s8f17').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f18').val() != "") {
                                var_2b = parseFloat($('#t1s8f18').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f19').val() != "") {
                                var_2c = parseFloat($('#t1s8f19').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f20').val() != "") {
                                var_2d = parseFloat($('#t1s8f20').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f21').val() != "") {
                                var_2e = parseFloat($('#t1s8f21').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f22').val() != "") {
                                var_2f = parseFloat($('#t1s8f22').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f23').val() != "") {
                                var_2g = parseFloat($('#t1s8f23').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f24').val() != "") {
                                var_2h = parseFloat($('#t1s8f24').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f25').val() != "") {
                                var_2i = parseFloat($('#t1s8f25').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f26').val() != "") {
                                var_2j = parseFloat($('#t1s8f26').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f27').val() != "") {
                                var_2k = parseFloat($('#t1s8f14').val().toString().replace(/[$,]+/g, ""));
                            }
                            var_2l = var_2a + var_2b + var_2c + var_2d + var_2e + var_2f + var_2g + var_2h + var_2i + var_2j + var_2k;

                            var var_3a = 0;
                            var var_3b = 0;
                            var var_3c = 0;
                            var var_3d = 0;
                            if ($('#t1s8f28').val() != "") {
                                var_3a = parseFloat($('#t1s8f28').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f29').val() != "") {
                                var_3b = parseFloat($('#t1s8f29').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f30').val() != "") {
                                var_3c = parseFloat($('#t1s8f30').val().toString().replace(/[$,]+/g, ""));
                            }
                            var_3d = var_3a + var_3b + var_3c;

                            netbusiness = (var_1e + var_2l) - var_3d;
                        }
                        else if ($('#t1s8f32').val() == "on") {
                            var l245 = 0;
                            var q245 = 0;
                            var l246 = 0;
                            var q246 = 0;
                            var l247 = 0;
                            var q247 = 0;
                            var l248 = 0;
                            var q248 = 0;
                            var l249 = 0;
                            var q249 = 0;

                            var val1 = 0;
                            var val2 = 0;
                            var val3 = 0;
                            var val4 = 0;
                            var val5 = 0;

                            if ($('#t1s8f33').val() != "") {
                                l245 = parseFloat($('#t1s8f33').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f34').val() != "") {
                                q245 = parseFloat($('#t1s8f34').val().toString().replace(/[$,]+/g, "")) / 100;
                            }

                            if ($('#t1s8f35').val() != "") {
                                l246 = parseFloat($('#t1s8f35').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f36').val() != "") {
                                q246 = parseFloat($('#t1s8f14').val().toString().replace(/[$,]+/g, "")) / 100;
                            }

                            if ($('#t1s8f37').val() != "") {
                                l247 = parseFloat($('#t1s8f37').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f38').val() != "") {
                                q247 = parseFloat($('#t1s8f38').val().toString().replace(/[$,]+/g, ""));
                            }

                            if ($('#t1s8f39').val() != "") {
                                l248 = parseFloat($('#t1s8f14').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f40').val() != "") {
                                q248 = parseFloat($('#t1s8f40').val().toString().replace(/[$,]+/g, "")) / 100;
                            }

                            if ($('#t1s8f41').val() != "") {
                                l249 = parseFloat($('#t1s8f41').val().toString().replace(/[$,]+/g, ""));
                            }
                            if ($('#t1s8f42').val() != "") {
                                q249 = parseFloat($('#t1s8f42').val().toString().replace(/[$,]+/g, "")) / 100;
                            }

                            val1 = l245 * q245;
                            val2 = l246 * q246;
                            val3 = l247 * q247;
                            val4 = l248 * q248;
                            val5 = l249 * q249;

                            netbusiness = val1 + val2 + val3 + val4 + val5;

                        }


                        var c_j13 = $('#totalnetincome').val();
                        var c_j14 = $('#totalbonus').val();
                        c_j13 = c_j13.split(',').join('');
                        c_j14 = c_j14.split(',').join('');
                        c_j13 = parseFloat(c_j13) - parseFloat(c_j14);
                        var c_n15 = parseFloat(c_j13) + parseFloat(c_j14);
                        var c_n16 = $('#t1s6f21').val();
                        c_n16 = c_n16.split(',').join('');
                        if (c_n16 == "") {
                            c_n16 = 0;
                        }
                        var c_n17 = $('#lbltotalsummary1').text();
                        var c_n17 = c_n17.split(',').join('');
                        if (c_n17 == "") {
                            c_n17 = 0;
                        }

                        var c_r18 = parseFloat(c_n15) + parseFloat(c_n16) + parseFloat(c_n17) + parseFloat(netbusiness);
                        var wperiode = $('#totalperiod').val();
                        wperiode = wperiode.split(',').join('');
                        if (wperiode == "") {
                            wperiode = 0;
                        }
                        var annualizenetbusiness = 0;
                        if (netbusiness > 0) {
                            annualizenetbusiness = (netbusiness / wperiode) * 12;
                        }
                        var c_j21 = parseFloat(c_j13) / parseFloat(wperiode) * 12;
                        var c_j22 = parseFloat(c_j14) / parseFloat(wperiode) * 12;
                        var c_n23 = parseFloat(c_j21) + parseFloat(c_j22);
                        var c_n24 = parseFloat(c_n16) / parseFloat(wperiode) * 12;
                        var c_n25 = parseFloat(c_n17) / parseFloat(wperiode) * 12;
                        var c_r26 = parseFloat(c_n23) + parseFloat(c_n24) + parseFloat(c_n25) + parseFloat(annualizenetbusiness);
                        var c_r28 = $('#t1s3f3').val();
                        c_r28 = c_r28.split(',').join('');
                        if (c_r28 == "") {
                            c_r28 = 0;
                        }
                        var c_af21 = 0;
                        if (c_j21 > 0) {
                            c_af21 = parseInt((c_j21 / 1000) * 1000) - c_r28;
                            c_af21 = Math.floor(c_af21 / 1000) * 1000;

                        }
                        var c_af22 = c_j22;
                        var c_af23 = 0;
                        if (c_n23 > 0) {
                            c_af23 = parseInt((c_n23 / 1000) * 1000) - c_r28;
                            c_af23 = Math.floor(c_af23 / 1000) * 1000;
                        }
                        var c_af31 = parseInt(c_j21) - c_r28;
                        var c_af32 = c_j22;
                        var c_af33 = parseInt(c_af31) + parseInt(c_af32);
                        var c_af34 = c_n24;
                        var c_af35 = c_n25;
                        var c_af36 = parseInt(c_af33) + parseInt(c_af34) + parseInt(c_af35) + parseFloat(annualizenetbusiness);
                        var c_af37 = 0;

                        var c_r30 = 0;
                        if (c_af36 > 0) {
                            c_af37 = parseInt((c_af36 / 1000) * 1000);
                            c_af37 = Math.floor(c_af37 / 1000) * 1000;
                            c_r30 = c_af36;
                        }
                        var c_j33 = 0;
                        if (c_af31 <= 0) {
                            c_j33 = 0;
                        } else if ((c_af31 > 0) && (c_af31 <= 50000000)) {
                            c_j33 = 0.05 * c_af21;
                        } else if ((c_af31 > 50000000) && (c_af31 <= 250000000)) {
                            c_j33 = 0.15 * c_af21;
                        } else if ((c_af31 > 250000000) && (c_af31 <= 500000000)) {
                            c_j33 = 0.25 * c_af21;
                        } else {
                            c_j33 = 0.3 * c_af21;
                        }
                        var c_n35 = 0;
                        if (c_af33 <= 0) {
                            c_n35 = 0;
                        } else if ((c_af33 > 0) && (c_af33 <= 50000000)) {
                            c_n35 = 0.05 * c_af33;
                        } else if ((c_af33 > 50000000) && (c_af33 <= 250000000)) {
                            c_n35 = 0.15 * c_af33 - 5000000;
                        } else if ((c_af33 > 250000000) && (c_af33 <= 500000000)) {
                            c_n35 = 0.25 * c_af33 - 30000000;
                        } else {
                            c_n35 = 0.3 * c_af23 - 55000000;
                        }
                        var c_j34 = c_n35 - c_j33;
                        var c_r37 = 0;
                        if (c_af37 <= 0) {
                            c_r37 = 0;
                        } else if ((c_af37 > 0) && (c_af37 <= 50000000)) {
                            c_r37 = 0.05 * c_af37;
                        } else if ((c_af37 > 50000000) && (c_af37 <= 250000000)) {
                            c_r37 = 0.15 * c_af37 - 5000000;
                        } else if ((c_af37 > 250000000) && (c_af37 <= 500000000)) {
                            c_r37 = 0.25 * c_af37 - 30000000;
                        } else {
                            c_r37 = 0.3 * c_af37 - 55000000;
                        }
                        var c_n36 = c_r37 - c_n35;
                        var c_j40 = c_j33 / 12 * wperiode;
                        var c_j41 = c_j34 / 12 * wperiode;
                        var c_n42 = c_j40 + c_j41;
                        var c_n43 = c_n36 / 12 * wperiode;
                        var c_r44 = c_n42 + c_n43;


                        var cap1 = parseFloat($('#cap1-' + (j - (k - 1))).text().toString().replace(/[$,]+/g, ""));
                        var cap2 = parseFloat($('#cap2-' + (j - (k - 1))).text().toString().replace(/[$,]+/g, ""));
                        var cap3 = 0;
                        if (cap1 > 0) {
                            cap3 = (((cap1 / 12) * wperiode) / c_r30) * c_r44;
                        }
                        if (cap3 > cap2) {
                            cap3 = cap2;
                        }

                        console.log(cap3);
                        if (isNaN(cap3)) {
                            cap3 = 0;
                        }

                        if (cap3 == -NaN) {
                            cap3 = 0;
                        }

                        if (cap3 == NaN) {
                            cap3 = 0;
                        }

                        var dataren1 = parseFloat($('#dataren1-' + (j - (k - 1))).text().toString().replace(/[$,]+/g, ""));
                        var dataren2 = parseFloat($('#dataren2-' + (j - (k - 1))).text().toString().replace(/[$,]+/g, ""));
                        var dataren3 = 0;
                        if (dataren1 > 0) {
                            dataren3 = ((dataren1 / 12) * wperiode) / c_r30 * c_r44;
                        }


                        if (dataren3 > dataren2) {
                            dataren3 = dataren2;
                        }

                        $('#cap3-' + (j - (k - 1))).text(cap3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#dataren3-' + (j - (k - 1))).text(dataren3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        var sumtotal = parseFloat($('#sumtotal_' + (j - (k - 1)) + "_3").text().toString().replace(/[$,]+/g, ""));
                        sumtotal = sumtotal + cap3 + dataren3;
                        $('#sumtotal_' + (j - (k - 1)) + "_3").text(sumtotal.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        $('#sumtotal_' + (j - (k - 1)) + "_5").text(sumtotal.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        lbltotalsummary2 = lbltotalsummary2 + sumtotal;
                        $('#lbltotalsummary2').text(lbltotalsummary2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        j++;
                    });
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    }

    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), form, year, ammend);

}



function GetSummaryJapan(TaxPayerNumber, form, year, ammend) {
    var theTable = $('#summarytable').DataTable();
    theTable.clear().draw();

    var totalsummary1 = 0;
    var totalsummary2 = 0;
    var totalsummary3 = 0;
    var totalsummary4 = 0;

    var irregulardatas = [];
    var irregulardata = [];
    var irregulardatasidx = 0;

    var j = 0;
    for (var i = 1; i <= 5; i++) {
        type = i;
        $.ajax({
            url: 'OverseasService.asmx/GetIncomeBy',
            data: 'type=' + type + '&TaxPlayerNumber=' + TaxPayerNumber +
        '&form=' + form + '&year=' + year + '&ammend=' + ammend,
            dataType: "json",
            method: 'GET',
            success: function (data) {
                $(data).each(function (index, theData) {
                    var title = "";
                    var titlebahasa = "";

                    if (theData.type == 1) {
                        title = "Japan Salary from Certificate of Income (CoI)";
                        titlebahasa = "Penghasilan dari Jepang";
                    } else if (theData.type == 2) {
                        title = "Japan Salary from Certificate of Income (CoI)";
                        titlebahasa = "Penghasilan dari Jepang";
                    } else if (theData.type == 3) {
                        title = "Other payments/allowances from Certificate of Salary";
                        titlebahasa = "Penghasilan lainnya";
                    } else if (theData.type == 4) {
                        title = "Other payments/allowances from Certificate of Salary";
                        titlebahasa = "Penghasilan lainnya";
                    } else if (theData.type == 5) {
                        title = "Bonuses";
                        titlebahasa = "Bonus";
                    }

                    theTable.row.add([
                        title,
                        titlebahasa,
                        theData.currency,
                        theData.incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        theData.incomerp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        theData.taxpaidcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                        theData.taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 })
                    ]).draw(false);


                    var databil1 = theData.incomecurrency;
                    var databil2 = theData.incomerp;
                    var databil3 = theData.taxpaidcurrency;
                    var databil4 = theData.taxpaidrp;
                    if (databil1 == "") {
                        databil1 = "0";
                    }
                    if (databil2 == "") {
                        databil2 = "0";
                    }
                    if (databil3 == "") {
                        databil3 = "0";
                    }
                    if (databil4 == "") {
                        databil4 = "0";
                    }

                    var dataexist = irregulardatas.filter(function (datairr) { return datairr[1] == title });
                    if (dataexist.length == 0) {
                        irregulardata = [];
                        irregulardata.push(irregulardatasidx);
                        irregulardata.push(title);
                        irregulardata.push(titlebahasa);
                        irregulardata.push(theData.currency);
                        irregulardata.push(parseFloat(databil1.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(databil2.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(databil3.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(parseFloat(databil4.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas.push(irregulardata);
                        irregulardatasidx++;
                    } else {
                        irregulardata = [];
                        irregulardata.push(dataexist[0][0]);
                        irregulardata.push(dataexist[0][1]);
                        irregulardata.push(dataexist[0][2]);
                        irregulardata.push(dataexist[0][3]);

                        var bil1 = parseFloat(dataexist[0][4].toString().replace(/[$,]+/g, "")) + parseFloat(databil1.toString().replace(/[$,]+/g, ""));
                        var bil2 = parseFloat(dataexist[0][5].toString().replace(/[$,]+/g, "")) + parseFloat(databil2.toString().replace(/[$,]+/g, ""));
                        var bil3 = parseFloat(dataexist[0][6].toString().replace(/[$,]+/g, "")) + parseFloat(databil3.toString().replace(/[$,]+/g, ""));
                        var bil4 = parseFloat(dataexist[0][7].toString().replace(/[$,]+/g, "")) + parseFloat(databil4.toString().replace(/[$,]+/g, ""));

                        irregulardata.push(bil1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                        irregulardata.push(bil4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                        irregulardatas[dataexist[0][0]] = irregulardata;
                    }

                    theTable.clear().draw(false);
                    totalsummary1 = 0;
                    for (var e = 0; e < irregulardatas.length; e++) {
                        totalsummary1 += parseFloat(irregulardatas[e][5].toString().replace(/[$,]+/g, ""));
                        theTable.row.add([
                            irregulardatas[e][1],
                            irregulardatas[e][2],
                            irregulardatas[e][3],
                            irregulardatas[e][4],
                            irregulardatas[e][5],
                            irregulardatas[e][6],
                            irregulardatas[e][7]
                        ]).draw(false);
                    }


                    var datasumjapan1 = "Tax allowance";
                    var datasumjapan2 = "Tunjangan pajak";
                    var datasumjapan3 = "IDR";
                    var datasumjapan4 = $('#t1s8f32').val();
                    var datasumjapan5 = $('#t1s8f33').val();
                    var datasumjapan6 = 0;
                    var datasumjapan7 = 0;

                    totalsummary1 += parseFloat(datasumjapan5.toString().replace(/[$,]+/g, ""));

                    theTable.row.add([
                        datasumjapan1,
                        datasumjapan2,
                        datasumjapan3,
                        datasumjapan4,
                        datasumjapan5,
                        datasumjapan6,
                        datasumjapan7
                    ]).draw(false);

                    $("#summarytable tbody tr").each(function () {
                        $(this).find('td:eq(3)').addClass('numcol');
                        $(this).find('td:eq(4)').addClass('numcol');
                        $(this).find('td:eq(5)').addClass('numcol');
                        $(this).find('td:eq(6)').addClass('numcol');
                    });
                    $("#summarytable td.cencol").css('text-align', 'center');
                    $("#summarytable td.numcol").css('text-align', 'right');

                    var ts1 = theData.incomerp;
                    var ts2 = theData.taxpaidcurrency;
                    var ts3 = theData.taxpaidrp;

                    if (ts1 == "") {
                        ts1 = 0;
                    }
                    if (ts2 == "") {
                        ts2 = 0;
                    }
                    if (ts3 == "") {
                        ts3 = 0;
                    }


                    totalsummary2 += parseFloat(ts2.toString().replace(/[$,]+/g, ""));
                    totalsummary3 += parseFloat(ts3.toString().replace(/[$,]+/g, ""));

                    j++;
                    $('#lbltotalsummary1').text(totalsummary1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $('#lbltotalsummary2').text(totalsummary2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    $('#lbltotalsummary3').text(totalsummary3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    if (totalsummary1 > 0) {

                        var art = 0;
                        var art1 = 0;
                        var art2 = 0;
                        var art3 = 0;

                        art1 = parseFloat(totalsummary3.toString().replace(/[$,]+/g, ""));

                        //=====================================================
                        var c_j13 = $('#totalnetincome').val();
                        var c_j14 = $('#totalbonus').val();
                        c_j13 = c_j13.split(',').join('');
                        c_j14 = c_j14.split(',').join('');
                        c_j13 = parseFloat(c_j13) - parseFloat(c_j14);
                        var c_n15 = parseFloat(c_j13) + parseFloat(c_j14);
                        var c_n16 = $('#t1s6f21').val();
                        c_n16 = c_n16.split(',').join('');
                        if (c_n16 == "") {
                            c_n16 = 0;
                        }
                        var c_n17 = $('#lbltotalsummary1').text();
                        var c_n17 = c_n17.split(',').join('');
                        if (c_n17 == "") {
                            c_n17 = 0;
                        }
                        var c_r18 = +parseFloat(c_n16) + parseFloat(c_n17);
                        var wperiode = $('#totalperiod').val();
                        wperiode = wperiode.split(',').join('');
                        if (wperiode == "") {
                            wperiode = 0;
                        }
                        var c_j21 = parseFloat(c_j13) / parseFloat(wperiode) * 12;
                        var c_j22 = parseFloat(c_j14) / parseFloat(wperiode) * 12;
                        var c_n23 = parseFloat(c_j21) + parseFloat(c_j22);
                        var c_n24 = parseFloat(c_n16) / parseFloat(wperiode) * 12;
                        var c_n25 = parseFloat(c_n17) / parseFloat(wperiode) * 12;
                        var c_r26 = parseFloat(c_n23) + parseFloat(c_n24) + parseFloat(c_n25);
                        var c_r28 = $('#t1s3f3').val();
                        c_r28 = c_r28.split(',').join('');
                        if (c_r28 == "") {
                            c_r28 = 0;
                        }
                        var c_af21 = 0;
                        if (c_j21 > 0) {
                            c_af21 = parseInt((c_j21 / 1000) * 1000) - c_r28;
                            c_af21 = Math.floor(c_af21 / 1000) * 1000;

                        }
                        var c_af22 = c_j22;
                        var c_af23 = 0;
                        if (c_n23 > 0) {
                            c_af23 = parseInt((c_n23 / 1000) * 1000) - c_r28;
                            c_af23 = Math.floor(c_af23 / 1000) * 1000;
                        }
                        var c_af31 = parseInt(c_j21) - c_r28;
                        var c_af32 = c_j22;
                        var c_af33 = parseInt(c_af31) + parseInt(c_af32);
                        var c_af34 = c_n24;
                        var c_af35 = c_n25;
                        var c_af36 = parseInt(c_af33) + parseInt(c_af34) + parseInt(c_af35);
                        var c_af37 = 0;

                        var c_r30 = 0;
                        if (c_af36 > 0) {
                            c_af37 = parseInt((c_af36 / 1000) * 1000);
                            c_af37 = Math.floor(c_af37 / 1000) * 1000;
                            c_r30 = c_af36;
                        }
                        var c_j33 = 0;
                        if (c_af31 <= 0) {
                            c_j33 = 0;
                        } else if ((c_af31 > 0) && (c_af31 <= 50000000)) {
                            c_j33 = 0.05 * c_af21;
                        } else if ((c_af31 > 50000000) && (c_af31 <= 250000000)) {
                            c_j33 = 0.15 * c_af21;
                        } else if ((c_af31 > 250000000) && (c_af31 <= 500000000)) {
                            c_j33 = 0.25 * c_af21;
                        } else {
                            c_j33 = 0.3 * c_af21;
                        }
                        var c_n35 = 0;
                        if (c_af33 <= 0) {
                            c_n35 = 0;
                        } else if ((c_af33 > 0) && (c_af33 <= 50000000)) {
                            c_n35 = 0.05 * c_af33;
                        } else if ((c_af33 > 50000000) && (c_af33 <= 250000000)) {
                            c_n35 = 0.15 * c_af33 - 5000000;
                        } else if ((c_af33 > 250000000) && (c_af33 <= 500000000)) {
                            c_n35 = 0.25 * c_af33 - 30000000;
                        } else {
                            c_n35 = 0.3 * c_af23 - 55000000;
                        }
                        var c_j34 = c_n35 - c_j33;
                        var c_r37 = 0;
                        if (c_af37 <= 0) {
                            c_r37 = 0;
                        } else if ((c_af37 > 0) && (c_af37 <= 50000000)) {
                            c_r37 = 0.05 * c_af37;
                        } else if ((c_af37 > 50000000) && (c_af37 <= 250000000)) {
                            c_r37 = 0.15 * c_af37 - 5000000;
                        } else if ((c_af37 > 250000000) && (c_af37 <= 500000000)) {
                            c_r37 = 0.25 * c_af37 - 30000000;
                        } else {
                            c_r37 = 0.3 * c_af37 - 55000000;
                        }
                        var c_n36 = c_r37 - c_n35;
                        var c_j40 = c_j33 / 12 * wperiode;
                        var c_j41 = c_j34 / 12 * wperiode;
                        var c_n42 = c_j40 + c_j41;
                        var c_n43 = c_n36 / 12 * wperiode;
                        var c_r44 = c_n42 + c_n43;

                        art2 = c_r44;

                        var rd = true;
                        var at = 0;
                        if (rd == true) {
                            at = c_r30;
                        } else {
                            at = c_r30;
                        }

                        var grosincome = parseFloat(theData.incomerp.toString().replace(/[$,]+/g, ""));
                        art3 = ((((grosincome / wperiode) * 12) / c_r30) * art2);
                        //=====================================================
                        if (art1 < art2) {
                            art = art1;
                        } else {
                            art = art2;
                        }
                        if (art > art3) {
                            art = art3;
                        }
                        totalsummary4 = art;
                        $('#totalsummary4').text(totalsummary4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    } else {
                        totalsummary4 = 0;
                        $('#totalsummary4').text(totalsummary4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    }
                });
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

    
}

function GetCapitalBy(TaxPayerNumber) {

    $('#cap_description').val("");
    //$('#cap_country').val("");
    //$('#cap_currency').val("");
    $('#cap_sellingdate').val("");
    $('#cap_interval').val("");
    $('#cap_exchrate').val("");
    $('#cap_proceeds').val("");
    $('#cap_cost').val("");
    $('#cap_gainloss').val("");
    $('#cap_taxpaid').val("");
    $('#cap_gainlossrp').val("");
    $('#cap_taxpaidrp').val("");
    $('#cap_irregularincome').val("");

    $('#cap_country').trigger('change');
    $('#cap_currency').trigger('change');
    $('#cap_interval').trigger('change');
    $('#cap_irregularincome').trigger('change');

    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    $.ajax({
        url: 'OverseasService.asmx/GetCapitalBy',
        data: 'TaxPlayerNumber=' + TaxPayerNumber + '&form=' + selectedform +
                '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#capitalTable').DataTable();
            theTable.clear().draw();

            var i = 1;
            var total1 = 0;
            var total2 = 0;
            var total3 = 0;
            var total4 = 0;
            $('#tabCapital1').empty();
            $('#tabCapital1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tabCapital2').empty();
            $('#tabCapital2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tabCapital3').empty();
            $('#tabCapital3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#tabCapital4').empty();
            $('#tabCapital4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $(data).each(function (index, theData) {

                total1 = parseFloat(total1) + parseFloat(theData.cap_gainloss.toString().replace(/[$,]+/g, ""));
                $('#tabCapital1').empty();
                $('#tabCapital1').append(total1.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                var dt2 = theData.cap_taxpaid.toString().replace(/[$,]+/g, "");
                if (dt2 == "") {
                    dt2 = 0;
                }
                total2 = parseFloat(total2) + parseFloat(dt2);
                $('#tabCapital2').empty();
                $('#tabCapital2').append(total2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                total3 = parseFloat(total3) + parseFloat(theData.cap_gainlossrp.toString().replace(/[$,]+/g, ""));
                $('#tabCapital3').empty();
                $('#tabCapital3').append(total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                total4 = parseFloat(total4) + parseFloat(theData.cap_taxpaidrp.toString().replace(/[$,]+/g, ""));
                $('#tabCapital4').empty();
                $('#tabCapital4').append(total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if ($('#selectedform').val() == "formUs") {
                    theTable.row.add([
                            theData.cap_description,
                            theData.cap_currency,
                            theData.cap_sellingdate,
                            theData.cap_proceeds.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_cost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_gainloss.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_taxpaid.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_exchrate.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_gainlossrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            theData.cap_taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetCapitalByID(' + theData.id + ')" data-toggle="modal" data-target="#capital-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                        + '<li><a href="#" onclick="DeleteCapital(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);

                } else {
                    var cap_proceeds = 0;
                    var cap_cost = 0;
                    var cap_gainloss = 0;
                    var cap_exchrate = 0;
                    var cap_taxpaid = 0;
                    var cap_gainlossrp = 0;
                    var cap_taxpaidrp = 0;
                    if (theData.cap_proceeds != "") {
                        cap_proceeds = theData.cap_proceeds
                    }
                    if (theData.cap_taxpaidrp != "") {
                        cap_taxpaidrp = theData.cap_taxpaidrp
                    }
                    if (theData.cap_cost != "") {
                        cap_cost = theData.cap_cost
                    }
                    if (theData.cap_gainloss != "") {
                        cap_gainloss = theData.cap_gainloss
                    }
                    if (theData.cap_exchrate != "") {
                        cap_exchrate = theData.cap_exchrate
                    }
                    if (theData.cap_taxpaid != "") {
                        cap_taxpaid = theData.cap_taxpaid
                    }
                    if (theData.cap_gainlossrp != "") {
                        cap_gainlossrp = theData.cap_gainlossrp
                    }
                    theTable.row.add([
                            theData.cap_country,
                            theData.cap_description,
                            theData.cap_currency,
                            theData.cap_sellingdate,
                            parseFloat(cap_proceeds.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                            parseFloat(cap_cost.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                            parseFloat(cap_gainloss.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                            parseFloat(cap_taxpaid.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                            parseFloat(cap_exchrate.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                            parseFloat(cap_gainlossrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            parseFloat(cap_taxpaidrp.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetCapitalByID(' + theData.id + ')" data-toggle="modal" data-target="#capital-form-1770" ><i class=\"icon-pencil7\"></i></a></li>'
                        + '<li><a href="#" onclick="DeleteCapital(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);
                }


                i++;
            });

            if ($('#selectedform').val() == "formUs") {
                var theTableFooter = $('#capitalTable tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
                    "<td colspan='3'>Sub Total</td>" +
                    "<td></td>" +
                    "<td></td>" +
                    "<td style='text-align:right;'><span id='totalcap1'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</span></td>" +
                    "<td style='text-align:right;'><span id='totalcap2'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</span></td>" +
                    "<td></td>" +
                    "<td style='text-align:right;'><span id='totalcap3'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span></td>" +
                    "<td style='text-align:right;'><span id='totalcap4'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</span></td>" +
                    "<td></td>" +
                    "</tr>");



                if (total1 > 0) {
                    detailed1 = 0;
                    detailed2 = 0;
                    detailed3 = 0;
                    detailed4 = 0;
                    if ($("#detailed1").text() != '') {
                        detailed1 = $("#detailed1").text();
                    }
                    if ($("#detailed2").text() != '') {
                        detailed2 = $("#detailed2").text();
                    }
                    if ($("#detailed3").text() != '') {
                        detailed3 = $("#detailed3").text();
                    }
                    if ($("#detailed4").text() != '') {
                        detailed4 = $("#detailed4").text();
                    }

                    var theTabledetailed = $('#incomeTableDetailed').DataTable();
                    theTabledetailed.row.add([
                    "Capital gain or (loss)",
                    "Line 13",
                    "various",
                    "USD",
                    "various",
                    total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }),
                    total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    ''
                ]).draw(false);

                    totalcap1 = 0;
                    if ($("#totalcap1").text() != '') {
                        totalcap1 = $("#totalcap1").text();
                    }
                    totalcap2 = 0;
                    if ($("#totalcap2").text() != '') {
                        totalcap2 = $("#totalcap2").text();
                    }
                    totalcap3 = 0;
                    if ($("#totalcap3").text() != '') {
                        totalcap3 = $("#totalcap3").text();
                    }
                    totalcap4 = 0;
                    if ($("#totalcap4").text() != '') {
                        totalcap4 = $("#totalcap4").text();
                    }
                    totdetailed1 = parseFloat(detailed1.toString().replace(/[$,]+/g, "")) + parseFloat(totalcap1.toString().replace(/[$,]+/g, ""));
                    totdetailed2 = parseFloat(detailed2.toString().replace(/[$,]+/g, "")) + parseFloat(totalcap2.toString().replace(/[$,]+/g, ""));
                    totdetailed3 = parseFloat(detailed3.toString().replace(/[$,]+/g, "")) + parseFloat(totalcap3.toString().replace(/[$,]+/g, ""));
                    totdetailed4 = parseFloat(detailed4.toString().replace(/[$,]+/g, "")) + parseFloat(totalcap4.toString().replace(/[$,]+/g, ""));
                    t1s8f9 = totdetailed1;

                    $("#detailed1").text(totdetailed1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    $("#detailed2").text(totdetailed2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    $("#detailed3").text(totdetailed3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $("#detailed4").text(totdetailed4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $("#lbltotalsummary1").text(totdetailed3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                    $("#lbltotalsummary2").text(totdetailed4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                    $("#t1s8f9").val(t1s8f9.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    if (t1s8f9 > 0) {
                        var t1s8f15 = $("#t1s8f15").val().toString().replace(/[$,]+/g, "");
                        t1s8f16 = (t1s8f15 / t1s8f9) * 100;
                        $("#t1s8f16").val(t1s8f16.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
                    }
                }
                $("#incomeTableDetailed tbody tr").each(function () {
                    $(this).find('td:eq(4)').addClass('numcol');
                    $(this).find('td:eq(5)').addClass('numcol');
                    $(this).find('td:eq(6)').addClass('numcol');
                    $(this).find('td:eq(7)').addClass('numcol');
                    $(this).find('td:eq(8)').addClass('numcol');
                    $(this).find('td:eq(9)').addClass('numcol');
                });
                $("#incomeTableDetailed td.cencol").css('text-align', 'center');
                $("#incomeTableDetailed td.numcol").css('text-align', 'right');
            } else {
                var theTableFooter = $('#capitalTable tfoot');
                theTableFooter.empty();
                theTableFooter.append("<tr  class='bg-info-300 text-bold'>" +
                    "<td colspan='4'>Sub Total</td>" +
                    "<td></td>" +
                    "<td></td>" +
                    "<td style='text-align:right;'>" + total1.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                    "<td style='text-align:right;'>" + total2.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                    "<td></td>" +
                    "<td style='text-align:right;'>" + total3.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                    "<td style='text-align:right;'>" + total4.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                    "<td></td>" +
                    "</tr>");

                theTableFooter.append("<tr>" +
                    "<td colspan='12'>Sub Total By Country</td>" +
                    "</tr>");

                var selectedform = $('#selectedform').val();
                var selectedyear = $('#t1s1f3').val();
                var selectedammend = $('#t1s2f2').val();

                $.ajax({
                    url: 'OverseasService.asmx/GetCapitalByCountry',
                    data: 'TaxPlayerNumber=' + TaxPayerNumber + '&form=' + selectedform +
                        '&year=' + selectedyear + '&ammend=' + selectedammend,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        $(data).each(function (index, theData) {
                            theTableFooter.append("<tr>" +
                                "<td colspan='4'>" + theData.cap_country + "</td>" +
                                "<td></td>" +
                                "<td></td>" +
                                "<td style='text-align:right;'>" + parseFloat(theData.cap_gainloss).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                                "<td style='text-align:right;'>" + parseFloat(theData.cap_taxpaid).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) + "</td>" +
                                "<td></td>" +
                                "<td style='text-align:right;'>" + parseFloat(theData.cap_gainlossrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                                "<td style='text-align:right;'>" + parseFloat(theData.cap_taxpaidrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }) + "</td>" +
                                "<td></td>" +
                                "</tr>");
                        });
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });
            }

            $("#capitalTable tbody tr").each(function () {
                $(this).find('td:eq(4)').addClass('numcol');
                $(this).find('td:eq(5)').addClass('numcol');
                $(this).find('td:eq(6)').addClass('numcol');
                $(this).find('td:eq(7)').addClass('numcol');
                $(this).find('td:eq(8)').addClass('numcol');
                $(this).find('td:eq(9)').addClass('numcol');
                $(this).find('td:eq(10)').addClass('numcol');
            });
            $("#capitalTable td.cencol").css('text-align', 'center');
            $("#capitalTable td.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function DeleteIncome(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteIncome',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshOverseas();
                if ($('#selectedform').val() == "formJapan") {
                    GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(4, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(5, $('#MainContent_hdTaxPlayerNumber').val());
                } else if ($('#selectedform').val() == "formUs") {
                    GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                } else {
                    GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                    GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                }


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

function DeleteIrregular(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteIrregular',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshOverseas();
                GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);

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

function DeleteIncomeDetailed(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteIncomeDetailed',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshOverseas();
				GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());

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
    
function DeleteRental(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteRental',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshOverseas();
				GetRentalBy(1, $('#MainContent_hdTaxPlayerNumber').val());
				GetRentalBy(2, $('#MainContent_hdTaxPlayerNumber').val());
				GetRentalBy(3, $('#MainContent_hdTaxPlayerNumber').val());
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

function DeleteCapital(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'OverseasService.asmx/DeleteCapital',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                RefreshOverseas();
				GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
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

function Overseas(title, id) {
    $('#btnSaveAddIncome').css("display", "-webkit-inline-box");
    $('#oi_irregularincomediv').show();
    ClearWarning();
    $('#lblTitleIncome').empty();
    $('#lblLegendIncome').empty();
    $('#lblTitleIncome').append(title);

    $('#oi_dateofreceipt').show();
    $('#oi_dateofreceiptgroup').hide();

    if ($('#selectedform').val() == "formJapan") {
        $('#lblLegendIncome').append("General");
        //$('#oi_dateofreceipt').val("0");
    } else {
        $('#lblLegendIncome').append(title);
        $('#oi_dateofreceipt').val("");
    }

    $('#typeincome').val(id);

    $('#oi_incomecurrency').val("");
    $('#oi_dateofreceipt').val("");
    $('#oi_taxpaidcurrency').val("");
    $('#oi_incomerp').val("");
    $('#oi_taxpaidrp').val("");
    $('#oi_treatyrate').val("");
    $('#oi_currency').val("");
    $('#oi_currencyother').val("");
    $('#oi_irregularincome').val("");
    $('#oi_exchrate').val("");
    $('#oi_ftc').val("");
    $('#oi_allowedftc').val("");
    $('#oi_country').val("");
    $('#oi_interval').val("");
    $('#overseasincomeid').val("");

    if ($('#selectedform').val() == "formJapan") {
        $('#oi_currency').val("JPY");
        $('#oi_country').val("Japan");
    }

    isexecute = false;
    $('#oi_currency').trigger('change');
    $('#oi_interval').trigger('change');
    $('#oi_country').trigger('change');
    $('#oi_irregularincome').trigger('change');
    $('#oi_dateofreceipt').trigger('change');
    isexecute = true;
}

function OverseasDetailed(title, id) {
    $('#btnDetailedAdd').css("display", "-webkit-inline-box");
    $('#od_irregularincomediv').show();

    $('#lblTitleIncome').empty();
    $('#lblLegendIncome').empty();
    $('#lblTitleIncome').append(title);
    $('#lblLegendIncome').append(title);
    $('#typeincome').val(id);


    $('#od_dateofreceipt').show();
    $('#od_dateofreceiptgroup').hide();

    $('#od_incomecurrency').val("");
    $('#od_taxpaidcurrency').val("");
    $('#od_incomerp').val("");
    $('#od_taxpaidrp').val("");
    $('#od_treatyrate').val("");
    $('#od_dateofreceipt').val("");
    $('#od_irregularincome').val("");
    $('#od_exchrate').val("");
    $('#od_ftc').val("");
    $('#od_allowedftc').val("");
    $('#od_desc').val("");
    $('#od_line').val("");
    $('#od_fullyearincome').val("");
    $('#od_interval').val("");
    $('#overseasincomeid').val("");

    if ($('#selectedform').val() != "formUs") {
        $('#odi_currency').val("");
        $('#odi_currency').trigger('change');
    }

    
    $('#od_irregularincome').trigger('change');
    $('#od_interval').trigger('change');
    $('#od_dateofreceipt').trigger('change');
}

function OverseasRental(id, title) {
    $('#btnSaveAddRen').css("display", "-webkit-inline-box");
    $('#div_ren_irregularincome').show();
    
    ClearWarning();
    $('#rentitle').empty();
    $('#rentitle').append(title);
    $('#rentype').val(id);
    $('#renid').val("");

    $('#ren_information').val("");
    $('#ren_country').val("");
    $('#ren_currency').val("");
    $('#ren_currencyother').val("");
    $('#ren_dateofreceipt').val("");
    $('#ren_interval').val("");
    $('#ren_exchrate').val("");
    $('#ren_amountcurrency').val("");
    $('#ren_amountrp').val("");
    $('#ren_irregularincome').val("");

    $('#ren_country').trigger('change');
    $('#ren_currency').trigger('change');
    $('#ren_interval').trigger('change');
    $('#ren_irregularincome').trigger('change');

    if(id==3){
        $('#div_ren_information').css("display", "none");
        $('#div_ren_currency').css("display", "none");
        $('#div_ren_dateofreceipt').css("display", "none");
        $('#div_ren_interval').css("display", "none");
        $('#div_ren_irregularincome').css("display", "none");
        $('#ren_exchrate').prop('disabled', false);
        $('#ren_exchrate').prop('readonly', false);
        $('#ren_exchrate').removeClass("border-info");
        $('#ren_irregularincome').val("no");
        $('#ren_irregularincome').trigger('change');
    } else {
        $('#div_ren_information').css("display", "block");
        $('#div_ren_currency').css("display", "block");
        $('#div_ren_dateofreceipt').css("display", "block");
        $('#div_ren_interval').css("display", "block");
        $('#div_ren_irregularincome').css("display", "block");
        $('#ren_exchrate').prop('disabled', true);
        $('#ren_exchrate').prop('readonly', true);
        $('#ren_exchrate').addClass("border-info");
        $('#ren_irregularincome').val("");
        $('#ren_irregularincome').trigger('change');
    }
}

function SaveOverseasIncome(isAdd) {
    var jsonData = {};
    jsonData.type = $('#typeincome').val();
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.country = $('#oi_country').val();
    jsonData.currency = $('#oi_currency').val();
    if (jsonData.currency=="-") {
        jsonData.currency = $('#oi_currencyother').val();
    }
    
    jsonData.interval = $('#oi_interval').val();
    if (jsonData.interval == "4") {
        jsonData.dateofreceipt = $('#oi_dateofreceipt2_1').val() + " " + $('#oi_dateofreceipt2_2_1').val();
    } else {
        jsonData.dateofreceipt = $('#oi_dateofreceipt').val();
    }
    
    jsonData.exchrate = $('#oi_exchrate').val();
    jsonData.incomecurrency = $('#oi_incomecurrency').val();
    jsonData.taxpaidcurrency = $('#oi_taxpaidcurrency').val();
    jsonData.incomerp = $('#oi_incomerp').val();
    jsonData.taxpaidrp = $('#oi_taxpaidrp').val();
    jsonData.treatyrate = $('#oi_treatyrate').val();
    jsonData.ftc = $('#oi_ftc').val();
    jsonData.allowedftc = $('#oi_allowedftc').val();
    jsonData.irregularincome = $('#oi_irregularincome').val();

    
    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscomplete = 1;
    if (jsonData.country == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome1').show();
    } else {
        $('#lblerrorOverseasIncome1').hide();
    }
    if (jsonData.currency == "" || jsonData.currency == null) {
        iscomplete = 0;
        $('#lblerrorOverseasIncome2').show();
    }
    else{
        $('#lblerrorOverseasIncome2').hide();
    }
    
    if (jsonData.dateofreceipt == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome3').show();
    }
    else{
        $('#lblerrorOverseasIncome3').hide();
    }
    
    if (jsonData.interval == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome4').show();
    }
    else{
        $('#lblerrorOverseasIncome4').hide();
    }
    
    if (jsonData.incomecurrency == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome5').show();
    }
    else{
        $('#lblerrorOverseasIncome5').hide();
    }
    
    if (jsonData.irregularincome == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome6').show();
    }
    else{
        $('#lblerrorOverseasIncome6').hide();
    }

    if (iscomplete == 1) {
        if ($('#overseasincomeid').val() == "") {
            $.ajax({
                url: 'OverseasService.asmx/AddOverseasIncome',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    //addirregular

                    if ($('#selectedform').val() != "formJapan") {
                        var data1 = "";
                        if ($('#typeincome').val() == 1) {
                            data1 = "Dividend Income";
                        } else if ($('#typeincome').val() == 2) {
                            data1 = "Interest Income";
                        } else if ($('#typeincome').val() == 3) {
                            data1 = "Other Income";
                        } else if ($('#typeincome').val() == 4) {
                            data1 = "Capital Gain/Loss";
                        } else if ($('#typeincome').val() == 5) {
                            data1 = "Rental Income/loss";
                        }

                        var data2 = $('#oi_incomerp').val();
                        var data3 = $('#oi_taxpaidrp').val();
                        var data4 = $('#oi_allowedftc').val();

                        if (jsonData.irregularincome == "yes") {
                            SaveIrregular2(jsonData.country, data1, data2, data3, data4, "-", "-", "-");
                        }

                    } else {
                        var data1 = "";
                        if ($('#typeincome').val() == 1) {
                            data1 = "Japan Salary from Certificate of Income (CoI)";
                        } else if ($('#typeincome').val() == 2) {
                            data1 = "Japan Salary from Certificate of Income (CoI)";
                        } else if ($('#typeincome').val() == 3) {
                            data1 = "Other payments/allowances from Certificate of Salary";
                        } else if ($('#typeincome').val() == 4) {
                            data1 = "Other payments/allowances from Certificate of Salary";
                        } else if ($('#typeincome').val() == 5) {
                            data1 = "Bonuses";
                        }

                        var data2 = data1;
                        var data3 = $('#oi_currency').val();
                        var data4 = $('#oi_incomecurrency').val();
                        var data5 = $('#oi_incomerp').val();
                        var data6 = $('#oi_taxpaidrp').val();
                        var data7 = $('#oi_allowedftc').val();
                        if (jsonData.irregularincome == "yes") {
                            SaveIrregular2(jsonData.country, data1, data2, data3, data4, data5, data6, data7);
                        }

                    }

                    if ($('#selectedform').val() == "formUs") {
                        GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    } else {
                        if ($('#typeincome').val() == 1) {
                            GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 2) {
                            GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 3) {
                            GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 4) {
                            GetIncomeBy(4, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 5) {
                            GetIncomeBy(5, $('#MainContent_hdTaxPlayerNumber').val());
                        }
                    }

                    if (isAdd == 0) {
                        $('#income-form-1770-s123').modal('toggle');
                    } else {
                        $('#oi_incomecurrency').val("");
                        $('#oi_dateofreceipt').val("");
                        $('#oi_taxpaidcurrency').val("");
                        $('#oi_incomerp').val("");
                        $('#oi_taxpaidrp').val("");
                        $('#oi_treatyrate').val("");
                        $('#oi_currency').val("");
                        $('#oi_currencyother').val("");
                        $('#oi_irregularincome').val("");
                        $('#oi_exchrate').val("");
                        $('#oi_ftc').val("");
                        $('#oi_allowedftc').val("");
                        $('#oi_country').val("");
                        $('#oi_interval').val("");
                        $('#overseasincomeid').val("");

                        if ($('#selectedform').val() == "formJapan") {
                            $('#oi_currency').val("JPY");
                            $('#oi_country').val("Japan");
                        }

                        isexecute = false;
                        $('#oi_currency').trigger('change');
                        $('#oi_interval').trigger('change');
                        $('#oi_country').trigger('change');
                        $('#oi_irregularincome').trigger('change');
                        $('#oi_dateofreceipt').trigger('change');
                        isexecute = true;
                    }

                    clearallwarning();
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
            $('#income-form-1770-s123').modal('toggle');
            jsonData.id = $('#overseasincomeid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditOverseasIncome',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    if ($('#selectedform').val() == "formUs") {
                        GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    } else {
                        if ($('#typeincome').val() == 1) {
                            GetIncomeBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 2) {
                            GetIncomeBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 3) {
                            GetIncomeBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 4) {
                            GetIncomeBy(4, $('#MainContent_hdTaxPlayerNumber').val());
                        } else if ($('#typeincome').val() == 5) {
                            GetIncomeBy(5, $('#MainContent_hdTaxPlayerNumber').val());
                        }
                    }

                    clearallwarning();
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

function SaveOverseasDetailed(isAdd) {
    var jsonData = {};
    jsonData.type = $('#typeincome').val();
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.description = $('#od_desc').val();
    jsonData.line = $('#od_line').val();
    jsonData.currency = $('#odi_currency').val();
    if (jsonData.currency == "-") {
        jsonData.currency = $('#odi_currencyother').val();
    }

    jsonData.interval = $('#od_interval').val();
    if (jsonData.interval == "4") {
        jsonData.dateofreceipt = $('#od_dateofreceipt2_1').val() + " " + $('#od_dateofreceipt2_2_1').val();
    } else {
        jsonData.dateofreceipt = $('#od_dateofreceipt').val();
    }

    jsonData.exchrate = $('#od_exchrate').val();
    jsonData.fullyearincome = $('#od_fullyearincome').val();
    jsonData.incomecurrency = $('#od_incomecurrency').val();
    jsonData.taxpaidcurrency = $('#od_taxpaidcurrency').val();
    jsonData.incomerp = $('#od_incomerp').val();
    jsonData.taxpaidrp = $('#od_taxpaidrp').val();
    jsonData.treatyrate = 0;
    jsonData.ftc = 0;
    jsonData.allowedftc = 0;
    jsonData.irregularincome = $('#od_irregularincome').val();

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscomplete = 1;

    if ($('#od_desc').val() == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome1').show();
    } else {
        $('#lblerrorOverseasIncome1').hide();
    }
    if (jsonData.currency == "" || jsonData.currency == null) {
        iscomplete = 0;
        $('#lblerrorOverseasIncome2').show();
    }
    else {
        $('#lblerrorOverseasIncome2').hide();
    }

    if (jsonData.dateofreceipt == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome3').show();
    }
    else {
        $('#lblerrorOverseasIncome3').hide();
    }

    if (jsonData.interval == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome4').show();
    }
    else {
        $('#lblerrorOverseasIncome4').hide();
    }

    if (jsonData.fullyearincome == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome5').show();
    }
    else {
        $('#lblerrorOverseasIncome5').hide();
    }

    if (jsonData.irregularincome == "") {
        iscomplete = 0;
        $('#lblerrorOverseasIncome6').show();
    }
    else {
        $('#lblerrorOverseasIncome6').hide();
    }

    if (iscomplete == 1) {

        if ($('#overseasincomeid').val() == "") {

            $.ajax({
                url: 'OverseasService.asmx/AddOverseasDetailed',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();

                    var data1 = "";
                    if ($('#typeincome').val() == 1) {
                        data1 = "Various Income";
                    } else if ($('#typeincome').val() == 4) {
                        data1 = "Capital Gain/Loss";
                    }

                    var data2 = $('#od_incomerp').val();
                    var data3 = $('#od_taxpaidrp').val();
                    var data4 = 0;

                    if (jsonData.irregularincome == "yes") {
                        SaveIrregular2("United States", data1, data2, data3, data4, "-", "-", "-");
                    }

                    GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    //disini ada perhitungan reverse;
                    UpdateS1();
                    console.log('test ' + $('#t1s8f17').val());
                    //alert('Data has been saved');

                    if (isAdd == 0) {
                        $('#income-form-1770-s123').modal('toggle');
                    } else {
                        $('#od_incomecurrency').val("");
                        $('#od_taxpaidcurrency').val("");
                        $('#od_incomerp').val("");
                        $('#od_taxpaidrp').val("");
                        $('#od_treatyrate').val("");
                        $('#od_dateofreceipt').val("");
                        $('#od_irregularincome').val("");
                        $('#od_exchrate').val("");
                        $('#od_ftc').val("");
                        $('#od_allowedftc').val("");
                        $('#od_desc').val("");
                        $('#od_line').val("");
                        $('#od_fullyearincome').val("");
                        $('#od_interval').val("");
                        $('#overseasincomeid').val("");

                        if ($('#selectedform').val() != "formUs") {
                            $('#odi_currency').val("");
                            $('#odi_currencyother').val("");
                            $('#odi_currency').trigger('change');
                        }

                        $('#od_irregularincome').trigger('change');
                        $('#od_interval').trigger('change');
                        $('#od_dateofreceipt').trigger('change');
                    }

                    $("#successMsg").text("Data has been saved");
                    $("#successBox").css("opacity", "100");
                    $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            $('#income-form-1770-s123').modal('toggle');
            jsonData.id = $('#overseasincomeid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditOverseasDetailed',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
					GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    //disini ada perhitungan reverse;
                    UpdateS1();
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

function SaveRental(isAdd) {
    var jsonData = {};
    jsonData.type = $('#rentype').val();
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.ren_information = $('#ren_information').val();
    jsonData.ren_country = $('#ren_country').val();
    jsonData.ren_currency = $('#ren_currency').val();
    if (jsonData.ren_currency == "-") {
        jsonData.ren_currency = $('#ren_currencyother').val();
    }

    jsonData.ren_interval = $('#ren_interval').val();
    if (jsonData.ren_interval == "4") {
        jsonData.ren_dateofreceipt = $('#ren_dateofreceipt2_1').val() + " " + $('#ren_dateofreceipt2_2_1').val();
    } else {
        jsonData.ren_dateofreceipt = $('#ren_dateofreceipt').val();
    }

    jsonData.ren_exchrate = $('#ren_exchrate').val();
    jsonData.ren_amountcurrency = $('#ren_amountcurrency').val();
    jsonData.ren_amountrp = $('#ren_amountrp').val();
    jsonData.ren_irregularincome = $('#ren_irregularincome').val();
    
    //addirregular

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();


    isok = true;

    if (jsonData.type == 3) {
        jsonData.ren_information = "-";
        jsonData.ren_currency = "-";
        jsonData.ren_dateofreceipt = "-";
        jsonData.ren_interval = "-";
        jsonData.ren_irregularincome = "no";
    }

    if (jsonData.ren_country != "") {
        $('#lblErrorren1').hide();
    } else {
        $('#lblErrorren1').show();
        isok = false;
    }

    if ((jsonData.ren_currency != "" && jsonData.ren_currency != null) || jsonData.type == 3) {
        $('#lblErrorren2').hide();
    } else {
        $('#lblErrorren2').show();
        isok = false;
    }

    if (jsonData.ren_dateofreceipt != "" || jsonData.type == 3) {
        $('#lblErrorren3').hide();
    } else {
        $('#lblErrorren3').show();
        isok = false;
    }

    if (jsonData.ren_interval != "" || jsonData.type == 3) {
        $('#lblErrorren4').hide();
    } else {
        $('#lblErrorren4').show();
        isok = false;
    }

    if (jsonData.ren_irregularincome != "" || jsonData.type == 3) {
        $('#lblErrorren5').hide();
    } else {
        $('#lblErrorren5').show();
        isok = false;
    }
    
    if(isok==true){
        if ($('#renid').val() == "") {

            $.ajax({
                url: 'OverseasService.asmx/AddRental',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    if ($('#selectedform').val() != "formJapan") {
                        data1 = "Rental Income/loss";

                        var data2 = jsonData.ren_amountrp;
                        var data3 = 0;
                        var data4 = 0;

                        if (jsonData.type == 2) {
                            data2 = parseFloat(data2.toString().replace(/[$,]+/g, "")) * -1;
                        }

                        if (jsonData.ren_irregularincome == "yes") {
                            SaveIrregular2(jsonData.ren_country, data1, data2, data3, data4, "-", "-", "-");
                        }

                    }

                    if (isAdd == 0) {
                        $('#rental-form-1770').modal('toggle');
                    } else {
                        ClearWarning();
                        $('#renid').val("");

                        $('#ren_information').val("");
                        //$('#ren_country').val("");
                        $('#ren_currency').val("");
                        $('#ren_currencyother').val("");
                        $('#ren_dateofreceipt').val("");
                        $('#ren_interval').val("");
                        $('#ren_exchrate').val("");
                        $('#ren_amountcurrency').val("");
                        $('#ren_amountrp').val("");
                        $('#ren_irregularincome').val("");

                        //$('#ren_country').trigger('change');
                        $('#ren_currency').trigger('change');
                        $('#ren_interval').trigger('change');
                        $('#ren_irregularincome').trigger('change');

                        if (jsonData.type == 3) {
                            $('#div_ren_information').css("display", "none");
                            $('#div_ren_currency').css("display", "none");
                            $('#div_ren_dateofreceipt').css("display", "none");
                            $('#div_ren_interval').css("display", "none");
                            $('#div_ren_irregularincome').css("display", "none");
                            $('#ren_exchrate').prop('disabled', false);
                            $('#ren_exchrate').prop('readonly', false);
                            $('#ren_exchrate').removeClass("border-info");
                            $('#ren_irregularincome').val("no");
                            $('#ren_irregularincome').trigger('change');
                        } else {
                            $('#div_ren_information').css("display", "block");
                            $('#div_ren_currency').css("display", "block");
                            $('#div_ren_dateofreceipt').css("display", "block");
                            $('#div_ren_interval').css("display", "block");
                            $('#div_ren_irregularincome').css("display", "block");
                            $('#ren_exchrate').prop('disabled', true);
                            $('#ren_exchrate').prop('readonly', true);
                            $('#ren_exchrate').addClass("border-info");
                            $('#ren_irregularincome').val("");
                            $('#ren_irregularincome').trigger('change');
                        }
                    }
                    //RefreshOverseas();
                    if (jsonData.type == 1) {
                        GetRentalBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    } else if (jsonData.type == 2) {
                        GetRentalBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                    } else if (jsonData.type == 3) {
                        GetRentalBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                    }

                    clearallwarning();

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
            $('#rental-form-1770').modal('toggle');
            jsonData.id = $('#renid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditRental',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    if (jsonData.type == 1) {
                        GetRentalBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                    } else if (jsonData.type == 2) {
                        GetRentalBy(2, $('#MainContent_hdTaxPlayerNumber').val());
                    } else if (jsonData.type == 3) {
                        GetRentalBy(3, $('#MainContent_hdTaxPlayerNumber').val());
                    }

                    clearallwarning();
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

function SaveCapital(isAdd) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.cap_description = $('#cap_description').val();
    jsonData.cap_country = $('#cap_country').val();
    jsonData.cap_currency = $('#cap_currency').val();
    if (jsonData.cap_currency == "-") {
        jsonData.cap_currency = $('#cap_currencyother').val();
    }

    jsonData.cap_interval = $('#cap_interval').val();
    if (jsonData.cap_interval == "4") {
        jsonData.cap_sellingdate = $('#cap_dateofreceipt2_1').val() + " " + $('#cap_dateofreceipt2_2_1').val();
    } else {
        jsonData.cap_sellingdate = $('#cap_sellingdate').val();
    }

    jsonData.cap_exchrate = $('#cap_exchrate').val();
    jsonData.cap_proceeds = $('#cap_proceeds').val();
    jsonData.cap_cost = $('#cap_cost').val();
    jsonData.cap_gainloss = $('#cap_gainloss').val();
    jsonData.cap_taxpaid = $('#cap_taxpaid').val();
    jsonData.cap_gainlossrp = $('#cap_gainlossrp').val();
    jsonData.cap_taxpaidrp = $('#cap_taxpaidrp').val();
    jsonData.cap_irregularincome = $('#cap_irregularincome').val();
    
    //addirregular

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();


    var iscomplete = true;
    if ($('#selectedform').val() != "formUs") {
        if (jsonData.cap_country == "") {
            iscomplete = false;
            $('#lblErrorCapital5').show();
        } else {
            $('#lblErrorCapital5').hide();
        }
    }
    
    if (jsonData.cap_currency == "" || jsonData.cap_currency == null) {
        iscomplete = false;
        $('#lblErrorCapital1').show();
    } else {
        $('#lblErrorCapital1').hide();
    }
    if (jsonData.cap_sellingdate == "") {
        iscomplete = false;
        $('#lblErrorCapital2').show();
    } else {
        $('#lblErrorCapital2').hide();
    }
    if (jsonData.cap_interval == "") {
        iscomplete = false;
        $('#lblErrorCapital3').show();
    } else {
        $('#lblErrorCapital3').hide();
    }
    if (jsonData.cap_irregularincome == "") {
        iscomplete = false;
        $('#lblErrorCapital4').show();
    } else {
        $('#lblErrorCapital4').hide();
    }

    if (iscomplete) {
        if ($('#capid').val() == "") {

            $.ajax({
                url: 'OverseasService.asmx/AddCapital',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
                    RefreshOverseas();

                    if ($('#selectedform').val() != "formJapan") {
                        data1 = "Capital Gain/Loss";

                        var data2 = jsonData.cap_gainlossrp;
                        var data3 = jsonData.cap_taxpaidrp;
                        var data4 = 0;

                        if (jsonData.cap_irregularincome == "yes") {
                            if ($('#selectedform').val() == "formUs") {
                                GetIncomeDetailedBy(1, $('#MainContent_hdTaxPlayerNumber').val());
                                SaveIrregular2("United States", data1, data2, data3, data4, "-", "-", "-");
                                UpdateS1();
                            }else{
                                SaveIrregular2(jsonData.cap_country, data1, data2, data3, data4, "-", "-", "-");
                            }
                        }

                    }


                    if (isAdd == 0) {
                        $('#capital-form-1770').modal('toggle');
                    }

                    $('#cap_country').val("");
                    $('#cap_currency').val("");
                    $('#cap_country').trigger("change");
                    $('#cap_currency').trigger("change");

                    clearallwarning();
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
            $('#capital-form-1770').modal('toggle');
            jsonData.id = $('#capid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditCapital',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    $('#cap_country').val("");
                    $('#cap_currency').val("");
                    $('#cap_country').trigger("change");
                    $('#cap_currency').trigger("change");
                    GetCapitalBy($('#MainContent_hdTaxPlayerNumber').val());
                    RefreshOverseas();

                    UpdateS1();

                    clearallwarning();
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



function SaveIrregular2(country, data1, data2, data3, data4, data5, data6, data7) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.country = country;
    jsonData.data1 = data1;
    jsonData.data2 = data2;
    jsonData.data3 = data3;
    jsonData.data4 = data4;

    jsonData.data5 = data5;
    jsonData.data6 = data6;
    jsonData.data7 = data7;
    jsonData.data8 = "-";
    jsonData.data9 = "-";
    jsonData.data10 = "-";

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();


    var iscomplete = true;

    if (jsonData.country == "") {
        iscomplete = false;
        $('#lblErrorIrr1').show();
    } else {
        $('#lblErrorIrr1').hide();
    }

    if (jsonData.data1 == "") {
        iscomplete = false;
        $('#lblErrorIrr2').show();
    } else {
        $('#lblErrorIrr2').hide();
    }

    if (jsonData.data2 == "") {
        iscomplete = false;
        $('#lblErrorIrr3').show();
    } else {
        $('#lblErrorIrr3').hide();
    }

    if (iscomplete) {
        if (data1 == "Rental Income/loss") {
            $.ajax({
                url: 'OverseasService.asmx/GetIrregularIncomeNewBy',
                data: 'TaxPlayerNumber=' + jsonData.TaxPlayerNumber + '&form=' + jsonData.form + '&year=' + jsonData.year + '&ammend=' + jsonData.ammend + '&country=' + country + '&data1=' + data1,
                dataType: "json",
                method: 'GET',
                success: function (data) {
                    if (data.length > 0) {

                        jsonData.data2 = parseFloat(data[0].data2.toString().replace(/[$,]+/g, "")) + parseFloat(data2.toString().replace(/[$,]+/g, ""));
                        jsonData.data2 = jsonData.data2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 });
                        $.ajax({
                            url: 'OverseasService.asmx/UpdateIrregular',
                            method: 'POST',
                            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function () {
                                //RefreshOverseas();
                                if (jsonData.form == "formUs") {
                                    ClearWarningIrregularUS();
                                } else {
                                    ClearWarningIrregular();
                                }

                                if ($('#selectedform').val() == "formJapan") {
                                    GetSummaryJapan($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                                } else {
                                    GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                                }

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
                        $.ajax({
                            url: 'OverseasService.asmx/AddIrregular',
                            method: 'POST',
                            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function () {
                                //RefreshOverseas();
                                if (jsonData.form == "formUs") {
                                    ClearWarningIrregularUS();
                                } else {
                                    ClearWarningIrregular();
                                }

                                if ($('#selectedform').val() == "formJapan") {
                                    GetSummaryJapan($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend); 
                                } else {
                                    GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                                }

                                //alert('Data has been saved');
                                $("#successMsg").text("Data has been saved");
                                $("#successBox").css("opacity", "100");
                                $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);
                            },
                            error: function (err) {
                                console.log(err);
                            }
                        });
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            $.ajax({
                url: 'OverseasService.asmx/AddIrregular',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    if (jsonData.form == "formUs") {
                        ClearWarningIrregularUS();
                    } else {
                        ClearWarningIrregular();
                    }

                    if ($('#selectedform').val() == "formJapan") {
                        GetSummaryJapan($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                        GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                    } else {
                        GetSummary($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                    }

                    //alert('Data has been saved');
                    $("#successMsg").text("Data has been saved");
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

function SaveIrregular(isAdd) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.country = $('#country').val();
    jsonData.data1 = $('#data1').val();
    jsonData.data2 = $('#data2').val();
    jsonData.data3 = $('#data3').val();
    jsonData.data4 = $('#data4').val();

    jsonData.data5 = "-";
    jsonData.data6 = "-";
    jsonData.data7 = "-";
    jsonData.data8 = "-";
    jsonData.data9 = "-";
    jsonData.data10 = "-";

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();


    var iscomplete = true;

    if (jsonData.country == "") {
        iscomplete = false;
        $('#lblErrorIrr1').show();
    } else {
        $('#lblErrorIrr1').hide();
    }

    if (jsonData.data1 == "") {
        iscomplete = false;
        $('#lblErrorIrr2').show();
    } else {
        $('#lblErrorIrr2').hide();
    }

    if (jsonData.data2 == "") {
        iscomplete = false;
        $('#lblErrorIrr3').show();
    } else {
        $('#lblErrorIrr3').hide();
    }

    if (iscomplete) {
        if ($('#irregularid').val() == "") {
            if (isAdd == 0) {
                $('#irregularform').modal('toggle');
            }
            $.ajax({
                url: 'OverseasService.asmx/AddIrregular',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    if (jsonData.form == "formUs") {
                        ClearWarningIrregularUS();
                    } else {
                        ClearWarningIrregular();
                    }
                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
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
            console.log(jsonData);
            $('#irregularform').modal('toggle');
            jsonData.id = $('#irregularid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditIrregular',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    if (jsonData.form == "formUs") {
                        ClearWarningIrregularUS();
                    } else {
                        ClearWarningIrregular();
                    }
                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
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

function SaveIrregularJapan(isAdd) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.country = $('#country').val();
    jsonData.data1 = $('#data1').val();
    jsonData.data2 = $('#data2').val();
    jsonData.data3 = $('#data3').val();
    jsonData.data4 = $('#data4').val();
    jsonData.data5 = $('#data5').val();
    jsonData.data6 = $('#data6').val();
    jsonData.data7 = $('#data7').val();
    jsonData.data8 = "-";
    jsonData.data9 = "-";
    jsonData.data10 = "-";

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();


    var iscomplete = true;

    if (jsonData.country == "") {
        iscomplete = false;
        $('#lblErrorIrr1').show();
    } else {
        $('#lblErrorIrr1').hide();
    }

    if (jsonData.data1 == "") {
        iscomplete = false;
        $('#lblErrorIrr2').show();
    } else {
        $('#lblErrorIrr2').hide();
    }

    if (jsonData.data2 == "") {
        iscomplete = false;
        $('#lblErrorIrr3').show();
    } else {
        $('#lblErrorIrr3').hide();
    }

    if (iscomplete) {
        if ($('#irregularid').val() == "") {
            if (isAdd == 0) {
                $('#irregularform').modal('toggle');
            }
            $.ajax({
                url: 'OverseasService.asmx/AddIrregular',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    //($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                    GetIrregularIncome($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                    ClearWarningIrregularJapan();
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
            $('#irregularform').modal('toggle');
            jsonData.id = $('#irregularid').val();
            $.ajax({
                url: 'OverseasService.asmx/EditIrregular',
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshOverseas();
                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
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

function GetExchRate() {
    if (ischangeexch) {
        var jsonData = {};

        if ($('#oi_interval').val() == "4") {
            $('#oi_dateofreceipt').hide();
            $('#oi_dateofreceiptgroup').show();
        } else {
            $('#oi_dateofreceipt').show();
            $('#oi_dateofreceiptgroup').hide();
        }

        if ($('#selectedform').val() != "formJapan") {
            if ($('#oi_interval').val() == "4") {
                jsonData.currency = $('#oi_currency').val();
                jsonData.type = $('#oi_interval').val();
                jsonData.interval = $('#oi_dateofreceipt2_1').val();
                jsonData.year = $('#oi_dateofreceipt2_2_1').val();
            } else {
                var datearr = $('#oi_dateofreceipt').val().split('/');

                jsonData.currency = $('#oi_currency').val();
                jsonData.type = $('#oi_interval').val();

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
        } else {
            if ($('#oi_interval').val() == "4") {
                jsonData.currency = $('#oi_currency').val();
                jsonData.type = $('#oi_interval').val();
                jsonData.interval = $('#oi_dateofreceipt2_1').val();
                jsonData.year = $('#oi_dateofreceipt2_2_1').val();
            } else {
                var datearr = $('#oi_dateofreceipt').val().split('/');

                jsonData.currency = $('#oi_currency').val();
                jsonData.type = $('#oi_interval').val();

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
        }

        if (jsonData.currency == "-") {
            $('#oi_currencyother').css("display", "block");
            $('#oi_exchrate').prop('disabled', false);
            $('#oi_exchrate').prop('readonly', false);
            $('#oi_exchrate').removeClass("border-info");
            $('#oi_exchrate').focus();
        } else {

            $('#oi_currencyother').css("display", "none");
            if (jsonData.currency != null && jsonData.type != "" && jsonData.interval != "" && jsonData.year != "") {
                $.ajax({
                    url: 'OverseasService.asmx/GetExchange',
                    data: 'currency=' + jsonData.currency + '&type=' + jsonData.type + '&interval=' + jsonData.interval + '&year=' + jsonData.year,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        if (data.length == 0) {
                            if ($('#oi_exchrate').val() == "") {
                                alert("Exch. Rate Not Available");
                                $('#oi_exchrate').val("0");
                                $('#oi_exchrate').focus();
                            }
                            //$('#divexch').modal('show');
                            $('#oi_exchrate').prop('disabled', false);
                            $('#oi_exchrate').prop('readonly', false);
                            $('#oi_exchrate').removeClass("border-info");
                        } else {
                            /*$('#oi_exchrate').prop('disabled', true);
                            $('#oi_exchrate').prop('readonly', true);
                            $('#oi_exchrate').removeClass("border-info");
                            $('#oi_exchrate').addClass("border-info");*/

                            $('#oi_exchrate').prop('disabled', false);
                            $('#oi_exchrate').prop('readonly', false);
                            $('#oi_exchrate').removeClass("border-info");

                            $(data).each(function (index, theData) {
                                $('#oi_exchrate').val(theData.amount.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

                                UpdateIncome();
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



function GetExchRateDetailed() {
    if (ischangeexch) {
        var jsonData = {};

        if ($('#od_interval').val() == "4") {
            $('#od_dateofreceipt').hide();
            $('#od_dateofreceiptgroup').show();
        } else {
            $('#od_dateofreceipt').show();
            $('#od_dateofreceiptgroup').hide();
        }

        var datearr = $('#od_dateofreceipt').val().split('/');

        jsonData.currency = $('#odi_currency').val();
        jsonData.type = $('#od_interval').val();

        if ($('#od_interval').val() == "4") {
            jsonData.interval = $('#od_dateofreceipt2_1').val();
            jsonData.year = $('#od_dateofreceipt2_2_1').val();
        } else {
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
            $('#odi_currencyother').css("display", "block");
            $('#od_exchrate').prop('disabled', false);
            $('#od_exchrate').prop('readonly', false);
            $('#od_exchrate').removeClass("border-info");
            $('#od_exchrate').focus();
        } else {
            $('#odi_currencyother').css("display", "none");
            if (jsonData.currency != null && jsonData.interval != "" && jsonData.type != "" && jsonData.year != "") {
                $.ajax({
                    url: 'OverseasService.asmx/GetExchange',
                    data: 'currency=' + jsonData.currency + '&type=' + jsonData.type + '&interval=' + jsonData.interval + '&year=' + jsonData.year,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        if (data.length == 0) {
                            if ($('#od_exchrate').val() == "") {
                                alert("Exch. Rate Not Available");
                                $('#od_exchrate').val("0");
                                $('#od_exchrate').focus();
                            }
                            //$('#divexch').modal('show');
                            $('#od_exchrate').prop('disabled', false);
                            $('#od_exchrate').prop('readonly', false);
                            $('#od_exchrate').removeClass("border-info");
                        } else {
                            $('#od_exchrate').prop('disabled', false);
                            $('#od_exchrate').prop('readonly', false);
                            $('#od_exchrate').removeClass("border-info");
                            $('#od_exchrate').addClass("border-info");
                            $(data).each(function (index, theData) {
                                $('#od_exchrate').val(theData.amount.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

                                UpdateDetailed();
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

function GetExchRateRental() {
    if (ischangeexch) {
        var jsonData = {};

        if ($('#ren_interval').val() == "4") {
            $('#ren_dateofreceipt').hide();
            $('#ren_dateofreceiptgroup').show();
        } else {
            $('#ren_dateofreceipt').show();
            $('#ren_dateofreceiptgroup').hide();
        }

        var datearr = $('#ren_dateofreceipt').val().split('/');

        jsonData.currency = $('#ren_currency').val();
        jsonData.type = $('#ren_interval').val();

        if ($('#ren_interval').val() == "4") {
            jsonData.interval = $('#ren_dateofreceipt2_1').val();
            jsonData.year = $('#ren_dateofreceipt2_2_1').val();
        } else {
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
            $('#ren_currencyother').css("display", "block");
            $('#ren_exchrate').prop('disabled', false);
            $('#ren_exchrate').prop('readonly', false);
            $('#ren_exchrate').removeClass("border-info");
            $('#ren_exchrate').focus();
        } else {
            $('#ren_currencyother').css("display", "none");
            if (jsonData.currency != null && jsonData.interval != "" && jsonData.type != "" && jsonData.year != "") {
                $.ajax({
                    url: 'OverseasService.asmx/GetExchange',
                    data: 'currency=' + jsonData.currency + '&type=' + jsonData.type + '&interval=' + jsonData.interval + '&year=' + jsonData.year,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        if (data.length == 0) {
                            if ($('#ren_exchrate').val() == "") {
                                alert("Exch. Rate Not Available");
                                $('#ren_exchrate').val("0");
                                $('#ren_exchrate').focus();
                            }
                            //$('#divexch').modal('show');
                            $('#ren_exchrate').prop('disabled', false);
                            $('#ren_exchrate').prop('readonly', false);
                            $('#ren_exchrate').removeClass("border-info");
                        } else {
                            /*$('#ren_exchrate').prop('disabled', true);
                            $('#ren_exchrate').prop('readonly', true);
                            $('#ren_exchrate').removeClass("border-info");
                            $('#ren_exchrate').addClass("border-info");*/

                            $('#ren_exchrate').prop('disabled', false);
                            $('#ren_exchrate').prop('readonly', false);
                            $('#ren_exchrate').removeClass("border-info");

                            $(data).each(function (index, theData) {
                                $(data).each(function (index, theData) {
                                    $('#ren_exchrate').val(theData.amount.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

                                    UpdateRental();
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

function GetExchRateCapital() {
    if (ischangeexch) {
        var jsonData = {};

        if ($('#cap_interval').val() == "4") {
            $('#cap_sellingdate').hide();
            $('#cap_dateofreceiptgroup').show();
        } else {
            $('#cap_sellingdate').show();
            $('#cap_dateofreceiptgroup').hide();
        }

        var datearr = $('#cap_sellingdate').val().split('/');

        jsonData.currency = $('#cap_currency').val();
        jsonData.type = $('#cap_interval').val();

        if ($('#cap_interval').val() == "4") {
            jsonData.interval = $('#cap_dateofreceipt2_1').val();
            jsonData.year = $('#cap_dateofreceipt2_2_1').val();
        } else {
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
            $('#cap_currencyother').css("display", "block");
            $('#cap_exchrate').prop('disabled', false);
            $('#cap_exchrate').prop('readonly', false);
            $('#cap_exchrate').removeClass("border-info");
            $('#cap_exchrate').focus();
        } else {
            $('#cap_currencyother').css("display", "none");
            if (jsonData.currency != null && jsonData.interval != "" && jsonData.type != "" && jsonData.year != "") {
                $.ajax({
                    url: 'OverseasService.asmx/GetExchange',
                    data: 'currency=' + jsonData.currency + '&type=' + jsonData.type + '&interval=' + jsonData.interval + '&year=' + jsonData.year,
                    dataType: "json",
                    method: 'GET',
                    success: function (data) {
                        if (data.length == 0) {
                            if ($('#cap_exchrate').val() == "") {
                                alert("Exch. Rate Not Available");
                                $('#cap_exchrate').val("0");
                                $('#cap_exchrate').focus();
                            }
                            //$('#divexch').modal('show');
                            $('#cap_exchrate').prop('disabled', false);
                            $('#cap_exchrate').prop('readonly', false);
                            $('#cap_exchrate').removeClass("border-info");
                        } else {
                            /*$('#cap_exchrate').prop('disabled', true);
                            $('#cap_exchrate').prop('readonly', true);
                            $('#cap_exchrate').removeClass("border-info");
                            $('#cap_exchrate').addClass("border-info");*/

                            $('#cap_exchrate').prop('disabled', false);
                            $('#cap_exchrate').prop('readonly', false);
                            $('#cap_exchrate').removeClass("border-info");

                            $(data).each(function (index, theData) {
                                $(data).each(function (index, theData) {
                                    $('#cap_exchrate').val(theData.amount.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

                                    UpdateCapital();
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