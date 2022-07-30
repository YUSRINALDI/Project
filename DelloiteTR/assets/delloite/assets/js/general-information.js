function RefreshGeneral() {
    isedit = false;
    isnotif = true;
    GetRelationship();
    GetFamiliesBy($('#MainContent_hdTaxPlayerNumber').val(), false);
    GetIEIncomeBy($('#MainContent_hdTaxPlayerNumber').val());

    clearwarningerr();
}

function clearwarningerr() {
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

function closemodal_general(param) {
    isedit = false;
    isnotif = true;
    if (param == 1) {
        GetFamiliesBy($('#MainContent_hdTaxPlayerNumber').val(), false);
    } else if (param == 2) {
        GetIEIncomeBy($('#MainContent_hdTaxPlayerNumber').val());
    }
    clearwarningerr();
}

function TabClick(tab) {
    var jsonData = {};
    jsonData.id = $('#hdtaxformid').val();
    jsonData.ammend = $('#t1s2f2').val();
    jsonData.taxidnumber = $('#t1s1f1').val();
    jsonData.type = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.t1s1f2 = $('#t1s1f2').val();
    jsonData.t1s1f4 = $('#t1s1f4').val();
    jsonData.t1s1f5 = $('#t1s1f5').val();
    jsonData.t1s1f6 = $('#t1s1f6').val();
    jsonData.t1s1f7 = $('#t1s1f7').val();
    jsonData.t1s1f8 = $('#t1s1f8').val();
    jsonData.t1s2f1 = $('#t1s2f1').val();
    jsonData.t1s2f2 = $('#t1s2f2').val();
    jsonData.t1s2f3 = $('#t1s2f3').val();
    jsonData.t1s2f4 = $('#t1s2f4').val();
    jsonData.t1s2f5 = $('#t1s2f5').val();
    jsonData.t1s2f6 = $('#t1s2f6').val();
    jsonData.t1s2f7 = $('#t1s2f7').val();
    jsonData.t1s2f8 = $('#t1s2f8').val();
    jsonData.t1s2f9 = $('#t1s2f9').val();
    jsonData.t1s2f10 = $('#t1s2f10').prop('checked');
    jsonData.t1s2f11 = $('#t1s2f11').prop('checked');
    jsonData.t1s2f12 = $('#t1s2f12').prop('checked');
    jsonData.t1s2f13 = $('#t1s2f13').prop('checked');
    jsonData.t1s2f14 = $('#t1s2f14').prop('checked');
    jsonData.t1s2f15 = $('#t1s2f15').prop('checked');
    jsonData.t1s2f16 = $('#t1s2f16').prop('checked');
    jsonData.t1s2f17 = $('#t1s2f17').prop('checked');
    jsonData.t1s2f18 = $('#t1s2f18').val();
    jsonData.t1s2f19 = $('#t1s2f19').val();
    jsonData.t1s2f20 = $('#t1s2f20').prop('checked');
    jsonData.t1s2f21 = $('#t1s2f21').prop('checked');
    jsonData.t1s2f22 = $('#t1s2f22').prop('checked');
    jsonData.t1s2f23 = $('#t1s2f23').val();
    jsonData.t1s2f24 = $('#t1s2f24').val();
    jsonData.t1s3f1 = $('#t1s3f1').val();
    jsonData.t1s3f2 = $('#t1s3f2').val();
    jsonData.t1s3f3 = $('#t1s3f3').val();
    jsonData.t1s4f1 = $('#t1s4f1').val();
    jsonData.t1s4f2 = $('#t1s4f2').val();
    jsonData.t1s4f3 = $('#t1s4f3').val();
    jsonData.t1s4f4 = $('#t1s4f4').val();
    jsonData.t1s4f5 = $('#t1s4f5').val();
    jsonData.t1s4f6 = $('#t1s4f6').val();
    jsonData.t1s4f7 = $('#t1s4f7').val();
    jsonData.t1s4f8 = $('#t1s4f8').val();
    jsonData.t1s4f9 = $('#t1s4f9').val();
    jsonData.t1s4f10 = $('#t1s4f10').val();
    jsonData.t1s4f11 = $('#t1s4f11').val();
    jsonData.t1s4f12 = $('#t1s4f12').val();
    jsonData.t1s4f13 = $('#t1s4f13').val();
    jsonData.t1s4f14 = $('#t1s4f14').val();
    jsonData.t1s4f15 = $('#t1s4f15').val();
    jsonData.t1s4f16 = $('#t1s4f16').val();
    jsonData.t1s4f17 = $('#t1s4f17').val();
    jsonData.t1s4f18 = $('#t1s4f18').val();
    jsonData.t1s4f19 = $('#t1s4f19').val();
    jsonData.t1s4f20 = $('#t1s4f20').val();
    jsonData.t1s4f21 = $('#t1s4f21').val();
    jsonData.t1s4f22 = $('#t1s4f22').val();
    jsonData.t1s4f23 = $('#t1s4f23').val();
    jsonData.t1s4f24 = $('#t1s4f24').val();
    jsonData.t1s4f25 = $('#t1s4f25').val();
    jsonData.t1s4f26 = $('#t1s4f26').val();
    jsonData.t1s4f27 = $('#t1s4f27').val();
    jsonData.t1s4f28 = $('#t1s4f28').val();
    jsonData.t1s4f29 = $('#t1s4f29').val();
    jsonData.t1s4f30 = $('#t1s4f30').val();
    jsonData.t1s4f31 = $('#t1s4f31').val();
    jsonData.t1s4f32 = $('#t1s4f32').val();
    jsonData.t1s4f33 = $('#t1s4f33').val();
    jsonData.t1s4f34 = $('#t1s4f34').val();
    jsonData.t1s4f35 = $('#t1s4f35').val();
    jsonData.t1s4f36 = $('#t1s4f36').val();
    jsonData.t1s4f37 = $('#t1s4f37').val();
    jsonData.t1s4f38 = $('#t1s4f38').val();
    jsonData.t1s4f39 = $('#t1s4f39').val();
    jsonData.t1s4f40 = $('#t1s4f40').val();
    jsonData.t1s4f41 = $('#t1s4f41').val();
    jsonData.t1s4f42 = $('#t1s4f42').val();
    jsonData.t1s4f43 = $('#t1s4f43').val();
    jsonData.t1s4f44 = $('#t1s4f44').val();
    jsonData.t1s4f45 = $('#t1s4f45').val();
    jsonData.t1s4f46 = $('#t1s4f46').val();
    jsonData.t1s4f47 = $('#t1s4f47').val();
    jsonData.t1s4f48 = $('#t1s4f48').val();
    jsonData.t1s4f49 = $('#t1s4f49').val();
    jsonData.t1s4f50 = $('#t1s4f50').val();
    jsonData.t1s4f51 = $('#t1s4f51').val();
    jsonData.t1s4f52 = $('#t1s4f52').val();
    jsonData.t1s4f53 = $('#t1s4f53').val();
    jsonData.t1s4f54 = $('#t1s4f54').val();
    jsonData.t1s4f55 = $('#t1s4f55').val();
    jsonData.totalemployee = $('#totalemployee').val();
    jsonData.totalperiod = $('#totalperiod').val();
    jsonData.totalsalaries = $('#totalsalaries').val();
    jsonData.totalincome = $('#totalincome').val();
    jsonData.totalother = $('#totalother').val();
    jsonData.totalhonorarium = $('#totalhonorarium').val();
    jsonData.totalinsurance = $('#totalinsurance').val();
    jsonData.totalbenefit = $('#totalbenefit').val();
    jsonData.totalbonus = $('#totalbonus').val();
    jsonData.totalgross = $('#totalgross').val();
    jsonData.totalcost = $('#totalcost').val();
    jsonData.totalpension = $('#totalpension').val();
    jsonData.totalpensioncost = $('#totalpensioncost').val();
    jsonData.totalincome25 = $('#totalincome25').val();
    jsonData.totalincome26 = $('#totalincome26').val();
    jsonData.totalincome27 = $('#totalincome27').val();
    jsonData.totalincome28 = $('#totalincome28').val();
    jsonData.totalincome29 = $('#totalincome29').val();
    jsonData.totaldeductions = $('#totaldeductions').val();
    jsonData.totalnetincome = $('#totalnetincome').val();
    jsonData.totalincometax = $('#totalincometax').val();
    jsonData.totalprevnetincome = $('#totalprevnetincome').val();
    jsonData.totalprevincometax = $('#totalprevincometax').val();
    jsonData.t1s6f1 = $('#t1s6f1').val();
    jsonData.t1s6f2 = $('#t1s6f2').val();
    jsonData.t1s6f3 = $('#t1s6f3').val();
    jsonData.t1s6f4 = $('#t1s6f4').val();
    jsonData.t1s6f5 = $('#t1s6f5').val();
    jsonData.t1s6f6 = $('#t1s6f6').val();
    jsonData.t1s6f7 = $('#t1s6f7').val();
    jsonData.t1s6f8 = $('#t1s6f8').val();
    jsonData.t1s6f9 = $('#t1s6f9').val();
    jsonData.t1s6f10 = $('#t1s6f10').val();
    jsonData.t1s6f11 = $('#t1s6f11').val();
    jsonData.t1s6f12 = $('#t1s6f12').val();
    jsonData.t1s6f13 = $('#t1s6f13').val();
    jsonData.t1s6f14 = $('#t1s6f14').val();
    jsonData.t1s6f15 = $('#t1s6f15').val();
    jsonData.t1s6f16 = $('#t1s6f16').val();
    jsonData.t1s6f17 = $('#t1s6f17').val();
    jsonData.t1s6f18 = $('#t1s6f18').val();
    jsonData.t1s6f19 = $('#t1s6f19').val();
    jsonData.t1s6f20 = $('#t1s6f20').val();
    jsonData.t1s6f21 = $('#t1s6f21').val();
    jsonData.t1s6f22 = $('#t1s6f22').val();
    jsonData.t1s6f23 = $('#t1s6f23').val();
    jsonData.t1s6f24 = $('#t1s6f24').val();
    jsonData.t1s6f25 = $('#t1s6f25').val();
    jsonData.t1s7f1 = $('#t1s7f1').val();
    jsonData.t1s7f2 = $('#t1s7f2').val();
    jsonData.t1s7f3 = $('#t1s7f3').val();
    jsonData.t1s7f4 = $('#t1s7f4').val();
    jsonData.t1s7f5 = $('#t1s7f5').val();
    jsonData.t1s7f6 = $('#t1s7f6').val();
    jsonData.t1s7f7 = $('#t1s7f7').val();
    jsonData.t1s7f8 = $('#t1s7f8').val();
    jsonData.t1s7f9 = $('#t1s7f9').val();
    jsonData.t1s7f10 = $('#t1s7f10').val();
    jsonData.t1s7f11 = $('#t1s7f11').val();
    jsonData.t1s7f12 = $('#t1s7f12').val();
    jsonData.t1s7f13 = $('#t1s7f13').val();
    jsonData.t1s7f14 = $('#t1s7f14').val();
    jsonData.t1s7f15 = $('#t1s7f15').val();
    jsonData.t1s7f16 = $('#t1s7f16').val();
    jsonData.t1s7f17 = $('#t1s7f17').val();
    jsonData.t1s7f18 = $('#t1s7f18').val();
    jsonData.t1s7f19 = $('#t1s7f19').val();
    jsonData.t1s7f20 = $('#t1s7f20').val();
    jsonData.t1s7f21 = $('#t1s7f21').val();
    jsonData.t1s7f22 = $('#t1s7f22').val();
    jsonData.t1s7f23 = $('#t1s7f23').val();
    jsonData.t1s7f24 = $('#t1s7f24').val();
    jsonData.t1s7f25 = $('#t1s7f25').val();
    jsonData.t1s7f26 = $('#t1s7f26').val();
    jsonData.t1s7f27 = $('#t1s7f27').val();
    jsonData.t1s7f28 = $('#t1s7f28').val();
    jsonData.t1s7f29 = $('#t1s7f29').val();
    jsonData.t1s7f30 = $('#t1s7f30').val();
    jsonData.t1s7f31 = $('#t1s7f31').val();
    jsonData.t1s7f32 = $('#t1s7f32').val();
    jsonData.t1s7f33 = $('#t1s7f33').val();
    jsonData.t1s7f34 = $('#t1s7f34').val();
    jsonData.t1s7f35 = $('#t1s7f35').val();
    jsonData.t1s7f36 = $('#t1s7f36').val();
    jsonData.t1s7f37 = $('#t1s7f37').val();
    jsonData.t1s7f38 = $('#t1s7f38').val();
    jsonData.t1s7f39 = $('#t1s7f39').val();

    if ($('#selectedform').val() == "formUs") {
        jsonData.t1s8f1 = $('#t1s8f1').val();
        jsonData.t1s8f2 = $('#t1s8f2').val();
        jsonData.t1s8f3 = $('#t1s8f3').val();
        jsonData.t1s8f4 = $('#t1s8f4').val();
        jsonData.t1s8f5 = $('#t1s8f5').val();
        jsonData.t1s8f32 = $('#t1s8f32').prop('checked');
    } else if ($('#selectedform').val() == "formJapan") {
        jsonData.t1s8f1 = $('#t1s8f1').val();
        jsonData.t1s8f2 = $('#t1s8f2').val();
        jsonData.t1s8f3 = $('#t1s8f3').val();
        jsonData.t1s8f4 = $('#t1s8f4').val();
        jsonData.t1s8f5 = $('#t1s8f5').val();
        jsonData.t1s8f32 = $('#t1s8f32').val();
    } else {
        jsonData.t1s8f1 = $('#t1s8f1').prop('checked');
        jsonData.t1s8f2 = $('#t1s8f2').prop('checked');
        jsonData.t1s8f3 = $('#t1s8f3').prop('checked');
        jsonData.t1s8f4 = $('#t1s8f4').prop('checked');
        jsonData.t1s8f5 = $('#t1s8f5').prop('checked');
        jsonData.t1s8f32 = $('#t1s8f32').prop('checked');
    }
    
    jsonData.t1s8f6 = $('#t1s8f6').val();
    jsonData.t1s8f7 = $('#t1s8f7').val();
    jsonData.t1s8f8 = $('#t1s8f8').val();
    jsonData.t1s8f9 = $('#t1s8f9').val();
    jsonData.t1s8f10 = $('#t1s8f10').val();
    jsonData.t1s8f11 = $('#t1s8f11').val();
    jsonData.t1s8f12 = $('#t1s8f12').val();
    jsonData.t1s8f13 = $('#t1s8f13').val();
    jsonData.t1s8f14 = $('#t1s8f14').val();
    jsonData.t1s8f15 = $('#t1s8f15').val();
    jsonData.t1s8f16 = $('#t1s8f16').val();
    jsonData.t1s8f17 = $('#t1s8f17').val();
    jsonData.t1s8f18 = $('#t1s8f18').val();
    jsonData.t1s8f19 = $('#t1s8f19').val();
    jsonData.t1s8f20 = $('#t1s8f20').val();
    jsonData.t1s8f21 = $('#t1s8f21').val();
    jsonData.t1s8f22 = $('#t1s8f22').val();
    jsonData.t1s8f23 = $('#t1s8f23').val();
    jsonData.t1s8f24 = $('#t1s8f24').val();
    jsonData.t1s8f25 = $('#t1s8f25').val();
    jsonData.t1s8f26 = $('#t1s8f26').val();
    jsonData.t1s8f27 = $('#t1s8f27').val();
    jsonData.t1s8f28 = $('#t1s8f28').val();
    jsonData.t1s8f29 = $('#t1s8f29').val();
    jsonData.t1s8f30 = $('#t1s8f30').val();
    jsonData.t1s8f31 = $('#t1s8f31').val();
    jsonData.t1s8f33 = $('#t1s8f33').val();
    jsonData.t1s8f34 = $('#t1s8f34').val();
    jsonData.t1s8f35 = $('#t1s8f35').val();
    jsonData.t1s8f36 = $('#t1s8f36').val();
    jsonData.t1s8f37 = $('#t1s8f37').val();
    jsonData.t1s8f38 = $('#t1s8f38').val();
    jsonData.t1s8f39 = $('#t1s8f39').val();
    jsonData.t1s8f40 = $('#t1s8f40').val();
    jsonData.t1s8f41 = $('#t1s8f41').val();
    jsonData.t1s8f42 = $('#t1s8f42').val();
    jsonData.t1s8f43 = $('#t1s8f43').val();
    jsonData.total1 = $('#tab1total1').text();
    jsonData.total2 = $('#tab1total2').text();
    jsonData.total3 = $('#tab1total3').text();
    jsonData.total4 = $('#tab1total4').text();
    jsonData.total5 = $('#tab1total5').text();
    jsonData.total6 = $('#tab1total6').text();
    jsonData.total7 = $('#tab2total1').text();
    jsonData.total8 = $('#tab2total2').text();
    jsonData.total9 = $('#tab2total3').text();
    jsonData.total10 = $('#tab2total4').text();
    jsonData.total11 = $('#tab2total5').text();
    jsonData.total12 = $('#tab2total6').text();
    jsonData.total13 = $('#tab3total1').text();
    jsonData.total14 = $('#tab3total2').text();
    jsonData.total15 = $('#tab3total3').text();
    jsonData.total16 = $('#tab3total4').text();
    jsonData.total17 = $('#tab3total5').text();
    jsonData.total18 = $('#tab3total6').text();
    jsonData.total19 = $('#tabCapital1').text();
    jsonData.total20 = $('#tabCapital2').text();
    jsonData.total21 = $('#tabCapital3').text();
    jsonData.total22 = $('#tabCapital4').text();
    jsonData.total23 = $('#tabrental1total1').text();
    jsonData.total24 = $('#tabrental1total2').text();
    jsonData.total25 = $('#tabrental2total1').text();
    jsonData.total26 = $('#tabrental2total2').text();
    jsonData.ren_netamountcurrency = $('#ren_netamountcurrency').val();
    jsonData.ren_netamountrp = $('#ren_netamountrp').val();
    jsonData.ren_nettaxpaidcurrency = $('#ren_nettaxpaidcurrency').val();
    jsonData.ren_nettaxpaidexchrate = $('#ren_nettaxpaidexchrate').val();
    jsonData.ren_nettaxpaidamountrp = $('#ren_nettaxpaidamountrp').val();
    jsonData.tabirregulartotal1 = $('#tabirregulartotal1').text();
    jsonData.tabirregulartotal2 = $('#tabirregulartotal2').text();
    jsonData.irregulartaxcredit = $('#irregulartaxcredit').val();
    jsonData.lbltotalsummary1 = $('#lbltotalsummary1').text();
    jsonData.lbltotalsummary2 = $('#lbltotalsummary2').text();
    jsonData.tabasset1 = $('#tabasset1').text();
    jsonData.tabasset2 = $('#tabasset2').text();
    jsonData.tabasset3 = $('#tabasset3').text();
    jsonData.tabasset4 = $('#tabasset4').text();
    jsonData.tabasset5 = $('#tabasset5').text();
    jsonData.tabasset6 = $('#tabasset6').text();
    jsonData.tabasset10 = $('#tabasset10').text();
    jsonData.tab3nettotalasset = $('#tab3nettotalasset').val();
    jsonData.tab3nettotalliabilities = $('#tab3nettotalliabilities').val();
    jsonData.tab3netasset = $('#tab3netasset').val();
    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    if($('#hdcurrentTab').val()==1){
        for (i = 1; i <= 8;i++) {
            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + i,
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {

                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    }else if($('#hdcurrentTab').val()==2){
        for (i = 1; i <= 7; i++) {
            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + i,
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {

                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    } else if ($('#hdcurrentTab').val()==3) {
        for (i = 1; i <= 7; i++) {
            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + i,
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {

                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    }
    
    $('#hdcurrentTab').val(tab.replace("tab", ""));
}

function GetRelationship() {
    $('#relationshipFamily').empty();
    $('#relationshipFamilyEdit').empty();
    $('#relationshipFamily').append($('<option>', {
        value: "",
        text: "Choose an Option"
    }));
    $('#relationshipFamilyEdit').append($('<option>', {
        value: "",
        text: "Choose an Option"
    }));
    $.ajax({
        url: 'WebService.asmx/GetRelationship',
        dataType: "json",
        method: 'GET',
        success: function (data) {
            $(data).each(function (index, theData) {
                $('#relationshipFamily').append($('<option>', {
                    value: theData.id,
                    text: theData.relationship
                }));
                $('#relationshipFamilyEdit').append($('<option>', {
                    value: theData.id,
                    text: theData.relationship
                }));
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function CheckReliefs(loadirregular) {
    var status = $('#t1s3f1 option:selected').val();
    var dependants = $('#t1s3f2').val();
    var year = $('#t1s1f3').val();
    //year = year.substr(-1);

    reliefs = 0;
    $('#t1s3f3').val(reliefs.toString());


    $.ajax({
        url: 'WebService.asmx/GetReliefs',
        data: 'year=' + year + '&status=' + status,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            //console.log(data);
            $(data).each(function (index, marital) {
                var dependantsamount = marital.dependant;
                if (status == "Married2") {
                    //reliefs = parseInt(marital.amount) + parseInt(dependantsamount) + (parseInt(dependants) * parseInt(dependantsamount));
                    reliefs = parseInt(marital.amount) + (parseInt(dependants) * parseInt(dependantsamount));
                }
                else {
                    reliefs = parseInt(marital.amount) + (parseInt(dependants) * parseInt(dependantsamount));
                }
                $('#t1s3f3').val(reliefs.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                var jsonData = {};
                jsonData.id = $('#hdtaxformid').val();
                jsonData.t1s3f1 = $('#t1s3f1').val();
                jsonData.t1s3f2 = $('#t1s3f2').val();
                jsonData.t1s3f3 = $('#t1s3f3').val();
                $.ajax({
                    url: 'Taxform.asmx/spUpdateFormStep13',
                    method: 'POST',
                    data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function () {
                        //console.log('Data updated');
                    },
                    error: function (err) {
                        console.log(err);
                    }
                });

                var selectedform = $('#selectedform').val();
                var selectedyear = $('#t1s1f3').val();
                var selectedammend = $('#t1s2f2').val();
                if (loadirregular == true || selectedform=="formUs") {
                    GetIrregularIncomeNew($('#MainContent_hdTaxPlayerNumber').val(), selectedform, selectedyear, selectedammend);
                }
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function SaveFamily(isAdd) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();
    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();
    jsonData.Name = $('#nameFamily').val();
    jsonData.Relationship = $('#relationshipFamily').val();
    jsonData.Birthdate = $('#birthdateFamily').val();
    jsonData.Occupation = $('#occupationFamily').val();
    jsonData.NIK = $('#nikFamily').val();
    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscomplete = 1;
    if (jsonData.Name == "") {
        iscomplete = 0;
        $('#lblerrorFamily1').show();
    } else {
        $('#lblerrorFamily1').hide();
    }  
    
    if (jsonData.Relationship == "") {
        iscomplete = 0;
        $('#lblerrorFamily2').show();
    }
    else{
        $('#lblerrorFamily2').hide();
    }

    if (iscomplete==1) {
        $('#lblerrorFamily1').hide();
        $('#lblerrorFamily2').hide();
        
        if ($('#familyid').val() == "") {
            $.ajax({
                url: 'WebService.asmx/AddNewFamily',
                method: 'POST',
                data: '{family: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    $("#successMsg").text("Data has been saved");
                    $("#successBox").css("opacity", "100");
                    $("#successBox").fadeTo(10000, 1).fadeTo(2000, 0);

                    //RefreshGeneral(); 
                    GetFamiliesBy($('#MainContent_hdTaxPlayerNumber').val(), false);

                    clearwarningerr();
                    if (isAdd == 1) {
                        addfam();
                    } else {
                        $('#list-family-form-1770').modal('toggle');
                    }
                    //alert('Data has been saved');
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            $('#list-family-form-1770').modal('toggle');
            jsonData.id = $('#familyid').val();
            $.ajax({
                url: 'WebService.asmx/EditFamily',
                method: 'POST',
                data: '{family: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    //RefreshGeneral();
                    GetFamiliesBy($('#MainContent_hdTaxPlayerNumber').val(), false);

                    clearwarningerr();
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

function GetFamilyByID(id) {
    $('#btnSaveFamilyAdd').css("display", "none");
    $.ajax({
        url: 'WebService.asmx/GetFamiliesByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, family) {
                $('#familyid').val(id);
                $('#nameFamily').val(family.Name);
                $('#relationshipFamily').val(family.RelationshipID);
                $('#relationshipFamily').trigger('change');
                $('#birthdateFamily').val(family.Birthdate);
                $('#occupationFamily').val(family.Occupation);
                $('#occupationFamily').trigger('change');
                $('#nikFamily').val(family.NIK);
                i++;
            });
        },
        error: function (err) {
            console.log(err);
        }
    });
}


function GetFamiliesBy(TaxPayerNumber, loadirregular) {
    $('#nameFamily').val("");
    $('#relationshipFamily').val("");
    $('#birthdateFamily').val("");
    $('#occupationFamily').val("");
    $('#nikFamily').val("");

    $('#nameFamilyEdit').val("");
    $('#relationshipFamilyEdit').val("");
    $('#birthdateFamilyEdit').val("");
    $('#occupationFamilyEdit').val("");
    $('#nikFamilyEdit').val("");

    $('#relationshipFamily').trigger('change');
    $('#relationshipFamilyEdit').trigger('change');
    $('#occupationFamily').trigger('change');
    $('#occupationFamilyEdit').trigger('change');

    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    $.ajax({
        url: 'WebService.asmx/GetFamiliesBy',
        data: 'TaxPayerNumber=' + TaxPayerNumber + '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#familyTable').DataTable();
            theTable.clear().draw();

            var i = 1;
            var depcount = 0;
            $('#t1s3f2').val(0);
            $(data).each(function (index, theData) {
                if (theData.Relationship != "Wife" && theData.Relationship != "Husband") {
                    depcount++;
                }
                if (theData.form == "form1770") {
                    theTable.row.add([
                            i,
                            theData.Name,
                            theData.Relationship,
                            theData.Occupation,
                            theData.NIK,
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetFamilyByID(' + theData.id + ')" data-toggle="modal" data-target="#list-family-form-1770" ><i class=\"icon-pencil7\"></i></a></li><li><a href="#" onclick="DeleteFamily(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);
                } else if (theData.form == "formNonUs" || theData.form == "formUs" || theData.form == "formJapan") {
                    theTable.row.add([
                            i,
                            theData.Name,
                            theData.Relationship,
                            theData.Occupation,
                            theData.NIK,
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetFamilyByID(' + theData.id + ')" data-toggle="modal" data-target="#list-family-form-1770" ><i class=\"icon-pencil7\"></i></a></li><li><a href="#" onclick="DeleteFamily(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);
                } else {
                    theTable.row.add([
                            i,
                            theData.Name,
                            theData.Relationship,
                            theData.Birthdate,
                            theData.Occupation,
                            theData.NIK,
                            '<ul class=\"icons-list\"><li><a href="#" onclick="GetFamilyByID(' + theData.id + ')" data-toggle="modal" data-target="#list-family-form-1770" ><i class=\"icon-pencil7\"></i></a></li><li><a href="#" onclick="DeleteFamily(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                        ]).draw(false);
                }


                i++;
            });
            if (depcount > 3) {
                depcount = 3;
            }
            var status = $('#t1s3f1 option:selected').val();
            $('#t1s3f2').val(depcount);
            if (status != "") {
                CheckReliefs(loadirregular);
            }

            $("#familyTable tbody tr").each(function () {
                $(this).find('td:eq(0)').addClass('cencol');
                $(this).find('td:eq(2)').addClass('cencol');
                $(this).find('td:eq(3)').addClass('cencol');
                $(this).find('td:eq(4)').addClass('cencol');
                $(this).find('td:eq(5)').addClass('cencol');
            });

            $("#familyTable thead tr").each(function () {
                $(this).find('th:eq(0)').addClass('cencol');
                $(this).find('th:eq(1)').addClass('cencol');
                $(this).find('th:eq(2)').addClass('cencol');
                $(this).find('th:eq(3)').addClass('cencol');
                $(this).find('th:eq(4)').addClass('cencol');
                $(this).find('th:eq(5)').addClass('cencol');
            });

            $("#familyTable td.cencol").css('text-align', 'center');
            $("#familyTable td.numcol").css('text-align', 'right');
            $("#familyTable th.cencol").css('text-align', 'center');
            $("#familyTable th.numcol").css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function DeleteFamily(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var family = {};
        family.id = id;

        $.ajax({
            url: 'WebService.asmx/DeleteFamily',
            method: 'POST',
            data: '{family: ' + JSON.stringify(family) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshGeneral();
                GetFamiliesBy($('#MainContent_hdTaxPlayerNumber').val(), false);
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

function SaveIEIncome(isAdd) {
    var jsonData = {};
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.field1 = $('#iefield1').val();
    jsonData.field2 = $('#iefield2').val();
    jsonData.field3 = $('#iefield3').val();
    jsonData.field4 = $('#iefield4').val();
    jsonData.field5 = $('#iefield5').val();
    jsonData.field6 = $('#iefield6').val();
    jsonData.field7 = $('#iefield7').val();
    jsonData.field8 = $('#iefield8').val();
    jsonData.field9 = $('#iefield9').val();
    jsonData.field10 = $('#iefield10').val();
    jsonData.field11 = $('#iefield11').val();
    jsonData.field12 = $('#iefield12').val();
    jsonData.field13 = $('#iefield13').val();
    jsonData.field14 = $('#iefield14').val();
    jsonData.field15 = $('#iefield15').val();
    jsonData.field16 = $('#iefield16').val();
    jsonData.field17 = $('#iefield17').val();
    jsonData.field18 = $('#iefield18').val();
    jsonData.field19 = $('#iefield19').val();
    jsonData.field20 = $('#iefield20').val();
    jsonData.field21 = $('#iefield21').val();
    jsonData.field22 = $('#iefield22').val();
    jsonData.field23 = $('#iefield23').val();

    if (jsonData.form == "form1770") {
        jsonData.field24 = 0;
        jsonData.field25 = 0;
        jsonData.field26 = 0;
        jsonData.field27 = 0;
        jsonData.field28 = 0;
        jsonData.field29 = 0;
    } else if (jsonData.form == "formNonUs") {
        jsonData.field24 = $('#iefield24').val();
        jsonData.field25 = $('#iefield25').val();
        jsonData.field26 = $('#iefield26').val();
        jsonData.field27 = $('#iefield27').val();
        jsonData.field28 = $('#iefield28').val();
        jsonData.field29 = $('#iefield29').val();
    } else if (jsonData.form == "formUs") {
        jsonData.field24 = $('#iefield24').val();
        jsonData.field25 = $('#iefield25').val();
        jsonData.field26 = $('#iefield26').val();
        jsonData.field27 = $('#iefield27').val();
        jsonData.field28 = $('#iefield28').val();
        jsonData.field29 = $('#iefield29').val();
    } else if (jsonData.form == "formJapan") {
        jsonData.field24 = $('#iefield24').val();
        jsonData.field25 = $('#iefield25').val();
        jsonData.field26 = $('#iefield26').val();
        jsonData.field27 = $('#iefield27').val();
        jsonData.field28 = $('#iefield28').val();
        jsonData.field29 = $('#iefield29').val();
    } 
    

    jsonData.createdby = $('#MainContent_hdcreatedby').val();
    jsonData.createddate = $('#MainContent_hdcreateddate').val();
    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscomplete = 1;
    if (jsonData.field1 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncome1').show();
    } else {
        $('#lblerrorIEIncome1').hide();
    }

    if (jsonData.field2 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncome2').show();
    }
    else{
        $('#lblerrorIEIncome2').hide();
    }

    if (jsonData.field4 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncome4').show();
    }
    else {
        $('#lblerrorIEIncome4').hide();
    }

    if (jsonData.field5 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncome5').show();
    }
    else {
        $('#lblerrorIEIncome5').hide();
    }


    if (jsonData.field8 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncome8').show();
    }
    else {
        $('#lblerrorIEIncome8').hide();
    }


    if (iscomplete == 1) {
        if (isAdd == 0) {
            $('#indonesian-employment-income-1770').modal('toggle');
        }

        $('#qualitative-info').addClass("active");
        $('#quantitative-info').removeClass("active");

        $.ajax({
            url: 'WebService.asmx/AddNewIEIncome',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshGeneral();
                GetIEIncomeBy($('#MainContent_hdTaxPlayerNumber').val());

                clearwarningerr();
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

function GetIEIncomeBy(TaxPlayerNumber) {
    var selectedform = $('#selectedform').val();
    var selectedyear = $('#t1s1f3').val();
    var selectedammend = $('#t1s2f2').val();

    addieincome();

    var totalemployee = 0;
    var totalperiod = 0;
    var totalsalaries = 0;
    var totalincome = 0;
    var totalother = 0;
    var totalhonorarium = 0;
    var totalinsurance = 0;
    var totalbenefit = 0;
    var totalbonus = 0;
    var totalgross = 0;
    var totalcost = 0;
    var totalpension = 0;
    var totalpensioncost = 0;
    var totalincome25 = 0;
    var totalincome26 = 0;
    var totalincome27 = 0;
    var totalincome28 = 0;
    var totalincome29 = 0;
    var totaldeductions = 0;
    var totalnetincome = 0;
    var totalincometax = 0;
    var totalprevnetincome = 0;
    var totalprevincometax = 0;

    $('#iefield1').val("");
    $('#iefield2').val("");
    $('#iefield3').val("");
    $('#iefield4').val("");
    $('#iefield5').val("");
    $('#iefield6').val("");
    $('#iefield7').val("");
    $('#iefield8').val("");
    $('#iefield9').val("");
    $('#iefield10').val("");
    $('#iefield11').val("");
    $('#iefield12').val("");
    $('#iefield13').val("");
    $('#iefield14').val("");
    $('#iefield15').val("");
    $('#iefield16').val("");
    $('#iefield17').val("");
    $('#iefield18').val("");
    $('#iefield19').val("");
    $('#iefield20').val("");
    $('#iefield21').val("");
    $('#iefield22').val("");
    $('#iefield23').val("");
    $('#iefield24').val("");
    $('#iefield25').val("");
    $('#iefield26').val("");
    $('#iefield27').val("");
    $('#iefield28').val("");
    $('#iefield29').val("");
    $('#iefield8').trigger('change');

    $('#totalemployee').val(totalemployee);
    $('#totalperiod').val(totalperiod);
    if ($('#selectedform').val() == "formUs") {
        $('#t1s8f18').val(totalperiod);
    }
    $('#totalsalaries').val(totalsalaries.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome').val(totalincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalother').val(totalother.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalhonorarium').val(totalhonorarium.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalinsurance').val(totalinsurance.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalbenefit').val(totalbenefit.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalbonus').val(totalbonus.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalgross').val(totalgross.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalcost').val(totalcost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalpension').val(totalpension.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalpensioncost').val(totalpensioncost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome25').val(totalincome25.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome26').val(totalincome26.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome27').val(totalincome27.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome28').val(totalincome28.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincome29').val(totalincome29.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totaldeductions').val(totaldeductions.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalnetincome').val(totalnetincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalincometax').val(totalincometax.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalprevnetincome').val(totalprevnetincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $('#totalprevincometax').val(totalprevincometax.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    $.ajax({
        url: 'WebService.asmx/GetIEIncomeBy',
        data: 'TaxPlayerNumber=' + TaxPlayerNumber + '&form=' + selectedform + '&year=' + selectedyear + '&ammend=' + selectedammend,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var theTable = $('#IEIncomeTable').DataTable();
            theTable.clear().draw();

            var i = 1;
            $(data).each(function (index, theData) {
                var field20 = 0;
                var field21 = 0;
                if (theData.field20 != "") {
                    field20 = theData.field20;
                }
                if (theData.field21 != "") {
                    field21 = theData.field21;
                }

                theTable.row.add([
                    theData.field4,
                    theData.field3,
                    theData.field5,
                    parseFloat(field20.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    parseFloat(field21.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }),
                    '<ul class=\"icons-list\">'
                + '<li><a onclick="GetIEIncomeDetilByID(' + theData.id + ')" title="View Detail" data-toggle="modal" data-target="#indonesian-employment-income-1770-detail"><i class="icon-eye"></i></a></li>'
                + '<li><a onclick="GetIEIncomeByID(' + theData.id + ')" data-toggle="modal" data-target="#indonesian-employment-income-1770-edit" ><i class=\"icon-pencil7\"></i></a></li>'
                + '<li><a onclick="DeleteIEIncome(' + theData.id + ')" ><i class=\'icon-trash\'></i></a></li></ul>'
                ]).draw(false);



                totalemployee++;
                $('#totalemployee').val(totalemployee);

                totalperiod = parseInt(totalperiod) + parseInt(theData.field3);
                if (totalperiod > 12) {
                    totalperiod = 12;
                }
                $('#totalperiod').val(totalperiod);

                if ($('#selectedform').val() == "formUs") {
                    $('#t1s8f18').val(totalperiod);
                    ceks2();
                }

                if (theData.field9 == "") {
                    field9 = 0;
                } else {
                    field9 = theData.field9;
                }
                totalsalaries = parseInt(totalsalaries) + parseInt(field9.toString().replace(/[$,]+/g, ""));
                $('#totalsalaries').val(totalsalaries.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field10 == "") {
                    field10 = 0;
                } else {
                    field10 = theData.field10;
                }
                totalincome = parseInt(totalincome) + parseInt(field10.toString().replace(/[$,]+/g, ""));
                $('#totalincome').val(totalincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field11 == "") {
                    field11 = 0;
                } else {
                    field11 = theData.field11;
                }
                totalother = parseInt(totalother) + parseInt(field11.toString().replace(/[$,]+/g, ""));
                $('#totalother').val(totalother.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field12 == "") {
                    field12 = 0;
                } else {
                    field12 = theData.field12;
                }
                totalhonorarium = parseInt(totalhonorarium) + parseInt(field12.toString().replace(/[$,]+/g, ""));
                $('#totalhonorarium').val(totalhonorarium.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field13 == "") {
                    field13 = 0;
                } else {
                    field13 = theData.field13;
                }
                totalinsurance = parseInt(totalinsurance) + parseInt(field13.toString().replace(/[$,]+/g, ""));
                $('#totalinsurance').val(totalinsurance.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field14 == "") {
                    field14 = 0;
                } else {
                    field14 = theData.field14;
                }
                totalbenefit = parseInt(totalbenefit) + parseInt(field14.toString().replace(/[$,]+/g, ""));
                $('#totalbenefit').val(totalbenefit.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field15 == "") {
                    field15 = 0;
                } else {
                    field15 = theData.field15;
                }
                totalbonus = parseInt(totalbonus) + parseInt(field15.toString().replace(/[$,]+/g, ""));
                $('#totalbonus').val(totalbonus.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field16 == "") {
                    field16 = 0;
                } else {
                    field16 = theData.field16;
                }
                totalgross = parseInt(totalgross) + parseInt(field16.toString().replace(/[$,]+/g, ""));
                $('#totalgross').val(totalgross.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field17 == "") {
                    field17 = 0;
                } else {
                    field17 = theData.field17;
                }
                totalcost = parseInt(totalcost) + parseInt(field17.toString().replace(/[$,]+/g, ""));
                $('#totalcost').val(totalcost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field18 == "") {
                    field18 = 0;
                } else {
                    field18 = theData.field18;
                }
                totalpension = parseInt(totalpension) + parseInt(field18.toString().replace(/[$,]+/g, ""));
                $('#totalpension').val(totalpension.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field24 == "") {
                    field24 = 0;
                } else {
                    field24 = theData.field24;
                }
                totalpensioncost = parseInt(totalpensioncost) + parseInt(field24.toString().replace(/[$,]+/g, ""));
                $('#totalpensioncost').val(totalpensioncost.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field25 == "") {
                    field25 = 0;
                } else {
                    field25 = theData.field25;
                }
                totalincome25 = parseInt(totalincome25) + parseInt(field25.toString().replace(/[$,]+/g, ""));
                $('#totalincome25').val(totalincome25.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field26 == "") {
                    field26 = 0;
                } else {
                    field26 = theData.field26;
                }
                totalincome26 = parseInt(totalincome26) + parseInt(field26.toString().replace(/[$,]+/g, ""));
                $('#totalincome26').val(totalincome26.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field27 != '') {
                    totalincome27 = parseInt(totalincome27) + parseInt(theData.field27.toString().replace(/[$,]+/g, ""));
                    $('#totalincome27').val(totalincome27.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                }


                if (theData.field28 == "") {
                    field28 = 0;
                } else {
                    field28 = theData.field28;
                }
                totalincome28 = parseInt(totalincome28) + parseInt(field28.toString().replace(/[$,]+/g, ""));
                $('#totalincome28').val(totalincome28.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field29 == "") {
                    field29 = 0;
                } else {
                    field29 = theData.field29;
                }
                totalincome29 = parseInt(totalincome29) + parseInt(field29.toString().replace(/[$,]+/g, ""));
                $('#totalincome29').val(totalincome29.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field19 == "") {
                    field19 = 0;
                } else {
                    field19 = theData.field19;
                }
                totaldeductions = parseInt(totaldeductions) + parseInt(field19.toString().replace(/[$,]+/g, ""));
                $('#totaldeductions').val(totaldeductions.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field20 == "") {
                    field20 = 0;
                } else {
                    field20 = theData.field20;
                }
                totalnetincome = parseInt(totalnetincome) + parseInt(field20.toString().replace(/[$,]+/g, ""));
                $('#totalnetincome').val(totalnetincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field21 == "") {
                    field21 = 0;
                } else {
                    field21 = theData.field21;
                }
                totalincometax = parseInt(totalincometax) + parseInt(field21.toString().replace(/[$,]+/g, ""));
                $('#totalincometax').val(totalincometax.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field22 == "") {
                    field22 = 0;
                } else {
                    field22 = theData.field22;
                }
                totalprevnetincome = parseInt(totalprevnetincome) + parseInt(field22.toString().replace(/[$,]+/g, ""));
                $('#totalprevnetincome').val(totalprevnetincome.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                if (theData.field23 == "") {
                    field23 = 0;
                } else {
                    field23 = theData.field23;
                }
                totalprevincometax = parseInt(totalprevincometax) + parseInt(field23.toString().replace(/[$,]+/g, ""));
                $('#totalprevincometax').val(totalprevincometax.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                i++;
            });

            $("#IEIncomeTable tbody tr").each(function () {
                $(this).find('td:eq(0)').addClass('cencol');
                $(this).find('td:eq(1)').addClass('cencol');
                $(this).find('td:eq(2)').addClass('cencol');
                $(this).find('td:eq(3)').addClass('numcol');
                $(this).find('td:eq(4)').addClass('numcol');
            });

            $('#IEIncomeTable td.cencol').css('text-align', 'center');
            $('#IEIncomeTable td.numcol').css('text-align', 'right');
        },
        error: function (err) {
            console.log(err);
        }
    });
} 
    
function DeleteIEIncome(id) {
    var checkstr = confirm('Are you sure?');
    if (checkstr == true) {
        var jsonData = {};
        jsonData.id = id;

        $.ajax({
            url: 'WebService.asmx/DeleteIEIncome',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshGeneral();
                GetIEIncomeBy($('#MainContent_hdTaxPlayerNumber').val());
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

function GetIEIncomeByID(id) {
    $.ajax({
        url: 'WebService.asmx/GetIEIncomeByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, jsonData) {
                $('#IEIncomeID').val(id);

                $('#iefieldedit1').val(jsonData.field1);
                $('#iefieldedit2').val(jsonData.field2);
                $('#iefieldedit3').val(jsonData.field3);
                $('#iefieldedit4').val(jsonData.field4);
                $('#iefieldedit5').val(jsonData.field5);
                $('#iefieldedit6').val(jsonData.field6);
                $('#iefieldedit7').val(jsonData.field7);
                $('#iefieldedit8').val(jsonData.field8);

                var field9 = 0;
                var field10 = 0;
                var field11 = 0;
                var field12 = 0;
                var field13 = 0;
                var field14 = 0;
                var field15 = 0;
                var field16 = 0;
                var field17 = 0;
                var field18 = 0;
                var field19 = 0;
                var field20 = 0;
                var field21 = 0;
                var field22 = 0;
                var field23 = 0;
                var field24 = 0;
                var field25 = 0;
                var field26 = 0;
                var field27 = 0;
                var field28 = 0;
                var field29 = 0;
                if (jsonData.field9 != "") {
                    field9 = jsonData.field9;
                }
                if (jsonData.field10 != "") {
                    field10 = jsonData.field10;
                }
                if (jsonData.field11 != "") {
                    field11 = jsonData.field11;
                }
                if (jsonData.field12 != "") {
                    field12 = jsonData.field12;
                }
                if (jsonData.field13 != "") {
                    field13 = jsonData.field13;
                }
                if (jsonData.field14 != "") {
                    field14 = jsonData.field14;
                }
                if (jsonData.field15 != "") {
                    field15 = jsonData.field15;
                }
                if (jsonData.field16 != "") {
                    field16 = jsonData.field16;
                }
                if (jsonData.field17 != "") {
                    field17 = jsonData.field17;
                }
                if (jsonData.field18 != "") {
                    field18 = jsonData.field18;
                }
                if (jsonData.fiel19 != "") {
                    field19 = jsonData.field19;
                }
                if (jsonData.field20 != "") {
                    field20 = jsonData.field20;
                }
                if (jsonData.field21 != "") {
                    field21 = jsonData.field21;
                }
                if (jsonData.field22 != "") {
                    field22 = jsonData.field22;
                }
                if (jsonData.field23 != "") {
                    field23 = jsonData.field23;
                }
                if (jsonData.field24 != "") {
                    field24 = jsonData.field24;
                }
                if (jsonData.fiel25 != "") {
                    field25 = jsonData.field25;
                }
                if (jsonData.field26 != "") {
                    field26 = jsonData.field26;
                }
                if (jsonData.field27 != "") {
                    field27 = jsonData.field27;
                }
                if (jsonData.field28 != "") {
                    field28 = jsonData.field28;
                }
                if (jsonData.field129 != "") {
                    field29 = jsonData.field29;
                }

                $('#iefieldedit9').val(parseFloat(field9.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit10').val(parseFloat(field10.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit11').val(parseFloat(field11.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit12').val(parseFloat(field12.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit13').val(parseFloat(field13.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit14').val(parseFloat(field14.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit15').val(parseFloat(field15.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit16').val(parseFloat(field16.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit17').val(parseFloat(field17.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit18').val(parseFloat(field18.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit19').val(parseFloat(field19.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit20').val(parseFloat(field20.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit21').val(parseFloat(field21.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit22').val(parseFloat(field22.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit23').val(parseFloat(field23.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit24').val(parseFloat(field24.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit25').val(parseFloat(field25.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit26').val(parseFloat(field26.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit27').val(parseFloat(field27.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit28').val(parseFloat(field28.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iefieldedit29').val(parseFloat(field29.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                
                $('#iefieldedit8').trigger('change');
                $('#iefieldedit23').trigger('change');
                i++;
            });
        },
        error: function (err) {
            console.log(err);
        }
    });

}

function GetIEIncomeDetilByID(id) {
    $.ajax({
        url: 'WebService.asmx/GetIEIncomeByID',
        data: 'id=' + id,
        dataType: "json",
        method: 'GET',
        success: function (data) {
            var i = 1;
            $(data).each(function (index, jsonData) {
                $('#IEIncomeID').val(id);

                $('#iedetil0').val(jsonData.field1 + " - " + jsonData.field2);
                $('#iedetil3').val(jsonData.field3);
                $('#iedetil4').val(jsonData.field4);
                $('#iedetil5').val(jsonData.field5);
                $('#iedetil6').val(jsonData.field6);
                $('#iedetil7').val(jsonData.field7);
                $('#iedetil8').val(jsonData.field8);
                if (jsonData.field9 == "") {
                    jsonData.field9 = 0;
                }
                if (jsonData.field10 == "") {
                    jsonData.field10 = 0;
                }
                if (jsonData.field11 == "") {
                    jsonData.field11 = 0;
                }
                if (jsonData.field12 == "") {
                    jsonData.field12 = 0;
                }
                if (jsonData.field13 == "") {
                    jsonData.field13 = 0;
                }
                if (jsonData.field14 == "") {
                    jsonData.field14 = 0;
                }
                if (jsonData.field15 == "") {
                    jsonData.field15 = 0;
                }
                if (jsonData.field16 == "") {
                    jsonData.field16 = 0;
                }
                if (jsonData.field17 == "") {
                    jsonData.field17 = 0;
                }
                if (jsonData.field18 == "") {
                    jsonData.field18 = 0;
                }
                if (jsonData.field19 == "") {
                    jsonData.field19 = 0;
                }
                if (jsonData.field20 == "") {
                    jsonData.field20 = 0;
                }
                if (jsonData.field21 == "") {
                    jsonData.field21 = 0;
                }
                if (jsonData.field22 == "") {
                    jsonData.field22 = 0;
                }
                if (jsonData.field23 == "") {
                    jsonData.field23 = 0;
                }
                if (jsonData.field24 == "") {
                    jsonData.field24 = 0;
                }
                $('#iedetil9').val(parseFloat(jsonData.field9.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil10').val(parseFloat(jsonData.field10.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil11').val(parseFloat(jsonData.field11.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil12').val(parseFloat(jsonData.field12.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil13').val(parseFloat(jsonData.field13.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil14').val(parseFloat(jsonData.field14.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil15').val(parseFloat(jsonData.field15.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil16').val(parseFloat(jsonData.field16.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil17').val(parseFloat(jsonData.field17.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil18').val(parseFloat(jsonData.field18.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil19').val(parseFloat(jsonData.field19.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil20').val(parseFloat(jsonData.field20.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil21').val(parseFloat(jsonData.field21.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil22').val(parseFloat(jsonData.field22.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil23').val(parseFloat(jsonData.field23.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#iedetil24').val(parseFloat(jsonData.field24.toString().replace(/[$,]+/g, "")).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

                $('#iedetil8').trigger('change');
                i++;
            });
        },
        error: function (err) {
            console.log(err);
        }
    });

}

function SaveEditIEIncome() {
    var jsonData = {};
    jsonData.id = $('#IEIncomeID').val();
    jsonData.TaxPlayerNumber = $('#MainContent_hdTaxPlayerNumber').val();

    jsonData.form = $('#selectedform').val();
    jsonData.year = $('#t1s1f3').val();
    jsonData.ammend = $('#t1s2f2').val();

    jsonData.field1 = $('#iefieldedit1').val();
    jsonData.field2 = $('#iefieldedit2').val();
    jsonData.field3 = $('#iefieldedit3').val();
    jsonData.field4 = $('#iefieldedit4').val();
    jsonData.field5 = $('#iefieldedit5').val();
    jsonData.field6 = $('#iefieldedit6').val();
    jsonData.field7 = $('#iefieldedit7').val();
    jsonData.field8 = $('#iefieldedit8').val();
    jsonData.field9 = $('#iefieldedit9').val();
    jsonData.field10 = $('#iefieldedit10').val();
    jsonData.field11 = $('#iefieldedit11').val();
    jsonData.field12 = $('#iefieldedit12').val();
    jsonData.field13 = $('#iefieldedit13').val();
    jsonData.field14 = $('#iefieldedit14').val();
    jsonData.field15 = $('#iefieldedit15').val();
    jsonData.field16 = $('#iefieldedit16').val();
    jsonData.field17 = $('#iefieldedit17').val();
    jsonData.field18 = $('#iefieldedit18').val();
    jsonData.field19 = $('#iefieldedit19').val();
    jsonData.field20 = $('#iefieldedit20').val();
    jsonData.field21 = $('#iefieldedit21').val();
    jsonData.field22 = $('#iefieldedit22').val();
    jsonData.field23 = $('#iefieldedit23').val();
    if (jsonData.form == "form1770") {
        jsonData.field24 = 0;
        jsonData.field25 = 0;
        jsonData.field26 = 0;
        jsonData.field27 = 0;
        jsonData.field28 = 0;
        jsonData.field29 = 0;
    } else if (jsonData.form == "formNonUs" || jsonData.form == "formUs" || jsonData.form == "formJapan") {
        
        jsonData.field24 = $('#iefieldedit24').val();
        jsonData.field25 = $('#iefieldedit25').val();
        jsonData.field26 = $('#iefieldedit26').val();
        jsonData.field27 = $('#iefieldedit27').val();
        jsonData.field28 = $('#iefieldedit28').val();
        jsonData.field29 = $('#iefieldedit29').val();
    }

    jsonData.updatedby = $('#MainContent_hdcreatedby').val();
    jsonData.updateddate = $('#MainContent_hdcreateddate').val();

    var iscomplete = 1;
    if (jsonData.field1 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit1').show();
    } else {
        $('#lblerrorIEIncomeedit1').hide();
    }

    if (jsonData.field2 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit2').show();
    }
    else{
        $('#lblerrorIEIncomeedit2').hide();
    }

    if (jsonData.field4 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit4').show();
    }
    else {
        $('#lblerrorIEIncomeedit4').hide();
    }

    if (jsonData.field5 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit5').show();
    }
    else {
        $('#lblerrorIEIncomeedit5').hide();
    }

    if (jsonData.field6 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit6').show();
    }
    else {
        $('#lblerrorIEIncomeedit6').hide();
    }

    if (jsonData.field7 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit7').show();
    }
    else {
        $('#lblerrorIEIncomeedit7').hide();
    }

    if (jsonData.field8 == "") {
        iscomplete = 0;
        $('#lblerrorIEIncomeedit8').show();
    }
    else {
        $('#lblerrorIEIncomeedit8').hide();
    }

    

    /*if (jsonData.form == "formNonUs") {
        if (jsonData.field24 == "") {
            iscomplete = 0;
            $('#lblerrorIEIncomeedit24').show();
        }
        else {
            $('#lblerrorIEIncomeedit24').hide();
        }
    }*/

    if (iscomplete == 1) {
        $('#indonesian-employment-income-1770-edit').modal('toggle');
        $.ajax({
            url: 'WebService.asmx/SaveEditIEIncome',
            method: 'POST',
            data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                //RefreshGeneral();
                GetIEIncomeBy($('#MainContent_hdTaxPlayerNumber').val());

                clearwarningerr();
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

function CalculatePeriode(tb) {
    var dateFrom = $('#iefield1').val();
    var dateto = $('#iefield2').val();

    monthDateFrom = dateFrom.split("/")[1];
    monthDateto = parseInt(dateto.split("/")[1]) + 1;

    yearDateFrom = dateFrom.split("/")[2];
    yearDateto = parseInt(dateto.split("/")[2]);

    if (dateFrom != "" && dateto != "") {
        var dateOne = new Date(dateFrom.split("/")[2], dateFrom.split("/")[1], dateFrom.split("/")[0]);
        var dateTwo = new Date(dateto.split("/")[2], dateto.split("/")[1], dateto.split("/")[0]); 
        if (dateOne < dateTwo) {
            var numPeriod = (monthDateto - monthDateFrom) + ((yearDateto - yearDateFrom) * 12);
            if (numPeriod > 0) {
                if (numPeriod > 12) {
                    numPeriod = 12;
                }
                $('#iefield3').val(numPeriod);
            }
        }else{
            tb.value = "";
            $('#iefield3').val("");
        }
    }
}

function CalculatePeriodeedit(tb) {
    var dateFrom = $('#iefieldedit1').val();
    var dateto = $('#iefieldedit2').val();

    monthDateFrom = dateFrom.split("/")[1];
    monthDateto = parseInt(dateto.split("/")[1]) + 1;

    yearDateFrom = dateFrom.split("/")[2];
    yearDateto = parseInt(dateto.split("/")[2]);

    if (dateFrom != "" && dateto != "") {
        var dateOne = new Date(dateFrom.split("/")[2], dateFrom.split("/")[1], dateFrom.split("/")[0]);
        var dateTwo = new Date(dateto.split("/")[2], dateto.split("/")[1], dateto.split("/")[0]);
        if (dateOne < dateTwo) {
            var numPeriod = (monthDateto - monthDateFrom) + ((yearDateto - yearDateFrom) * 12);
            if (numPeriod > 0) {
                if (numPeriod > 12) {
                    numPeriod = 12;
                }
                $('#iefieldedit3').val(numPeriod);
            }
        } else {
            tb.value = "";
            $('#iefieldedit3').val("");
        }
    }
}