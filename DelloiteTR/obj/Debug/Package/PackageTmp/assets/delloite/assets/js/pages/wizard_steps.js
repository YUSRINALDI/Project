/* ------------------------------------------------------------------------------
*
*  # Steps wizard
*
*  Specific JS code additions for wizard_steps.html page
*
*  Version: 1.1
*  Latest update: Dec 25, 2015
*
* ---------------------------------------------------------------------------- */

$(function () {


    // Wizard examples
    // ------------------------------

    // Basic wizard setup
    $(".steps-basic").steps({
        headerTag: "h6",
        bodyTag: "fieldset",
        transitionEffect: "fade",
        titleTemplate: '<span class="number">#index#</span> #title#',
        labels: {
            finish: 'Submit'
        },

        onStepChanged: function (event, currentIndex, priorIndex) {

            if ($('#t1s1f7').val() != '' && $('#t1s1f8').val() != '' && $('#hdisActive').val() == '0') {
                for (i = 0; i < 7; i++) {
                    $("#steps-uid-1").steps("next", {});
                    $("#steps-uid-0").steps("next", {});
                    if (i < 6) {
                        $("#steps-uid-2").steps("next", {});
                    }
                }
                if ($('#hdcurrentTab').val() == "1") {
                    $("#steps-uid-0-t-0").click();
                    $("#steps-uid-2-t-0").click();
                    $("#steps-uid-1-t-1").click();
                }
                else if ($('#hdcurrentTab').val() == "2") {
                    $("#steps-uid-0-t-0").click();
                    $("#steps-uid-1-t-0").click();
                    $("#steps-uid-2-t-1").click();
                }
                else if ($('#hdcurrentTab').val() == "3") {
                    $("#steps-uid-2-t-0").click();
                    $("#steps-uid-1-t-0").click();
                    $("#steps-uid-0-t-1").click();
                }

                $('#hdisActive').val(1);
            }
            //console.log($('#hdcurrentTab').val() + " = " + currentIndex);
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

            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + currentIndex,
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

            // Used to skip the "Warning" step if the user is old enough.
            if (currentIndex === 2 && Number($("#age-2").val()) >= 18) {
                form.steps("next");
            }

            // Used to skip the "Warning" step if the user is old enough and wants to the previous step.
            if (currentIndex === 2 && priorIndex === 3) {
                form.steps("previous");
            }
        },

        onFinished: function (event, currentIndex) {
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

            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + 8,
                method: 'POST',
                data: '{jsonData: ' + JSON.stringify(jsonData) + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                    alert('Data has been saved');
                    window.location.href = "taxform.aspx?id=" + $('#MainContent_hdTaxPlayerNumber').val();
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    });


    // Async content loading
    $(".steps-async").steps({
        headerTag: "h6",
        bodyTag: "fieldset",
        transitionEffect: "fade",
        titleTemplate: '<span class="number">#index#</span> #title#',
        labels: {
            finish: 'Submit'
        },
        onContentLoaded: function (event, currentIndex) {
            $(this).find('select.select').select2();

            $(this).find('select.select-simple').select2({
                minimumResultsForSearch: Infinity
            });

            $(this).find('.styled').uniform({
                radioClass: 'choice'
            });

            $(this).find('.file-styled').uniform({
                fileButtonClass: 'action btn bg-warning'
            });
        },
        onFinished: function (event, currentIndex) {
            alert("Form submitted.");
        }
    });


    // Saving wizard state
    $(".steps-state-saving").steps({
        headerTag: "h6",
        bodyTag: "fieldset",
        saveState: true,
        titleTemplate: '<span class="number">#index#</span> #title#',
        autoFocus: true,
        onFinished: function (event, currentIndex) {
            alert("Form submitted.");
        }
    });


    // Specify custom starting step
    $(".steps-starting-step").steps({
        headerTag: "h6",
        bodyTag: "fieldset",
        startIndex: 2,
        titleTemplate: '<span class="number">#index#</span> #title#',
        autoFocus: true,
        onFinished: function (event, currentIndex) {
            alert("Form submitted.");
        }
    });


    //
    // Wizard with validation
    //

    // Show form
    var form = $(".steps-validation").show();


    // Initialize wizard
    $(".steps-validation").steps({
        headerTag: "h6",
        bodyTag: "fieldset",
        transitionEffect: "fade",
        titleTemplate: '<span class="number">#index#</span> #title#',
        autoFocus: true,
        onStepChanging: function (event, currentIndex, newIndex) {

            // Allways allow previous action even if the current form is not valid!
            if (currentIndex > newIndex) {
                return true;
            }

            // Forbid next action on "Warning" step if the user is to young
            if (newIndex === 3 && Number($("#age-2").val()) < 18) {
                return false;
            }

            // Needed in some cases if the user went back (clean up)
            if (currentIndex < newIndex) {

                // To remove error styles
                form.find(".body:eq(" + newIndex + ") label.error").remove();
                form.find(".body:eq(" + newIndex + ") .error").removeClass("error");
            }

            form.validate().settings.ignore = ":disabled,:hidden";
            return form.valid();
        },

        onStepChanged: function (event, currentIndex, priorIndex) {

            if ($('#t1s1f7').val() != '' && $('#t1s1f8').val() != '' && $('#hdisActive').val() == '0') {
                for (i = 0; i < 7; i++) {
                    $("#steps-uid-1").steps("next", {});
                    $("#steps-uid-0").steps("next", {});
                    if (i < 6) {
                        $("#steps-uid-2").steps("next", {});
                    }
                }
                if ($('#hdcurrentTab').val() == "1") {
                    $("#steps-uid-0-t-0").click();
                    $("#steps-uid-2-t-0").click();
                    $("#steps-uid-1-t-1").click();
                }
                else if ($('#hdcurrentTab').val() == "2") {
                    $("#steps-uid-0-t-0").click();
                    $("#steps-uid-1-t-0").click();
                    $("#steps-uid-2-t-1").click();
                }
                else if ($('#hdcurrentTab').val() == "3") {
                    $("#steps-uid-2-t-0").click();
                    $("#steps-uid-1-t-0").click();
                    $("#steps-uid-0-t-1").click();
                }

                $('#hdisActive').val(1);
            }
            //console.log($('#hdcurrentTab').val() + " = " + currentIndex);
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

            if ($('#selectedform').val() == "formUs" && $('#hdcurrentTab').val() == 2 && currentIndex <= 2) {
                $.ajax({
                    url: 'Taxform.asmx/spUpdateFormStep18',
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
            } else {
                if (currentIndex == 0) {
                    currentIndex = 1;
                }
                $.ajax({
                    url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + currentIndex,
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

                if ($('#selectedform').val() == "formJapan" && (($('#hdcurrentTab').val() == 1 && currentIndex == 4) || ($('#hdcurrentTab').val() == 2 && currentIndex == 6))) {
                    $.ajax({
                        url: 'Taxform.asmx/spUpdateFormStep18',
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
                }
            }



            // Used to skip the "Warning" step if the user is old enough.
            if (currentIndex === 2 && Number($("#age-2").val()) >= 18) {
                form.steps("next");
            }

            // Used to skip the "Warning" step if the user is old enough and wants to the previous step.
            if (currentIndex === 2 && priorIndex === 3) {
                form.steps("previous");
            }
        },

        onFinishing: function (event, currentIndex) {
            form.validate().settings.ignore = ":disabled";
            return form.valid();
        },

        onFinished: function (event, currentIndex) {
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
            } else if ($('#selectedform').val() == "formJapan") {
                jsonData.t1s8f1 = $('#t1s8f1').val();
            } else {
                jsonData.t1s8f1 = $('#t1s8f1').prop('checked');
                jsonData.t1s8f2 = $('#t1s8f2').prop('checked');
                jsonData.t1s8f3 = $('#t1s8f3').prop('checked');
                jsonData.t1s8f4 = $('#t1s8f4').prop('checked');
                jsonData.t1s8f5 = $('#t1s8f5').prop('checked');
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
            jsonData.t1s8f32 = $('#t1s8f32').prop('checked');
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

            $.ajax({
                url: 'Taxform.asmx/spUpdateFormStep' + $('#hdcurrentTab').val() + currentIndex,
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
            if ($('#hdcurrentTab').val() == 1) {
                $('a[href="#overseas-income"]').click();
            } else if ($('#hdcurrentTab').val() == 2) {
                $('a[href="#assets-liabilities"]').click();
            }
        }
    });


    // Initialize validation
    $(".steps-validation").validate({
        ignore: 'input[type=hidden], .select2-search__field', // ignore hidden fields
        errorClass: 'validation-error-label',
        successClass: 'validation-valid-label',
        highlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },
        unhighlight: function (element, errorClass) {
            $(element).removeClass(errorClass);
        },

        // Different components require proper error label placement
        errorPlacement: function (error, element) {

            // Styled checkboxes, radios, bootstrap switch
            if (element.parents('div').hasClass("checker") || element.parents('div').hasClass("choice") || element.parent().hasClass('bootstrap-switch-container')) {
                if (element.parents('label').hasClass('checkbox-inline') || element.parents('label').hasClass('radio-inline')) {
                    error.appendTo(element.parent().parent().parent().parent());
                }
                else {
                    error.appendTo(element.parent().parent().parent().parent().parent());
                }
            }

            // Unstyled checkboxes, radios
            else if (element.parents('div').hasClass('checkbox') || element.parents('div').hasClass('radio')) {
                error.appendTo(element.parent().parent().parent());
            }

            // Input with icons and Select2
            else if (element.parents('div').hasClass('has-feedback') || element.hasClass('select2-hidden-accessible')) {
                error.appendTo(element.parent());
            }

            // Inline checkboxes, radios
            else if (element.parents('label').hasClass('checkbox-inline') || element.parents('label').hasClass('radio-inline')) {
                error.appendTo(element.parent().parent());
            }

            // Input group, styled file input
            else if (element.parent().hasClass('uploader') || element.parents().hasClass('input-group')) {
                error.appendTo(element.parent().parent());
            }

            else {
                error.insertAfter(element);
            }
        },
        rules: {
            email: {
                email: true
            }
        }
    });





    // Initialize plugins
    // ------------------------------

    // Select2 selects
    $('.select').select2();


    // Simple select without search
    $('.select-simple').select2({
        minimumResultsForSearch: Infinity
    });


    // Styled checkboxes and radios
    $('.styled').uniform({
        radioClass: 'choice'
    });


    // Styled file input
    $('.file-styled').uniform({
        fileButtonClass: 'action btn bg-blue'
    });

});
