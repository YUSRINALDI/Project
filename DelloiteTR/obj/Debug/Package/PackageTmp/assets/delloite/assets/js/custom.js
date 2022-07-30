$(document).ready(function () {
    $('.datepicker').datepicker({
        autoclose: true,
        format: 'dd/mm/yyyy',
        orientation: 'right'
    });
});

// $(document).ready(function () {
//     $('.tax-table').dataTables({
//         filter: true
//     });
// });

$(function () {
    $('.money > div').click(function () {
        $('.money > input:eq(' + $('.money > div').index(this) + ')').focus();
    });
    $('.numberOnly').on('keydown', function (e) {

        if (this.selectionStart || this.selectionStart == 0) {
            // selectionStart won't work in IE < 9

            var key = e.which;
            var prevDefault = true;

            var thouSep = ","; // your seperator for thousands
            var deciSep = "."; // your seperator for decimals
            var deciNumber = 0; // how many numbers after the comma

            var thouReg = new RegExp(thouSep, "g");
            var deciReg = new RegExp(deciSep, "g");

            function spaceCaretPos(val, cPos) {
                /// get the right caret position without the spaces

                if (cPos > 0 && val.substring((cPos - 1), cPos) == thouSep)
                    cPos = cPos - 1;

                if (val.substring(0, cPos).indexOf(thouSep) >= 0) {
                    cPos = cPos - val.substring(0, cPos).match(thouReg).length;
                }

                return cPos;
            }

            function spaceFormat(val, pos) {
                /// add spaces for thousands

                if (val.indexOf(deciSep) >= 0) {
                    var comPos = val.indexOf(deciSep);
                    var int = val.substring(0, comPos);
                    var dec = val.substring(comPos);
                } else {
                    var int = val;
                    var dec = "";
                }
                var ret = [val, pos];

                if ((int.length > 4 && int.includes("-")) || (int.length > 3 && !int.includes("-"))) {

                    var newInt = "";
                    var spaceIndex = int.length;

                    if (int.includes("-")) {
                        while (spaceIndex > 4) {
                            spaceIndex = spaceIndex - 3;
                            newInt = thouSep + int.substring(spaceIndex, spaceIndex + 3) + newInt;
                            if (pos > spaceIndex) pos++;
                        }
                    } else {
                        while (spaceIndex > 3) {
                            spaceIndex = spaceIndex - 3;
                            newInt = thouSep + int.substring(spaceIndex, spaceIndex + 3) + newInt;
                            if (pos > spaceIndex) pos++;
                        }
                    }
                    ret = [int.substring(0, spaceIndex) + newInt + dec, pos];
                }
                return ret;
            }

            $(this).on('keyup', function (ev) {
                var value = $(e.target).val();
                if (ev.which == 8) {
                    // reformat the thousands after backspace keyup

                    //var value = this.value;
                    var caretPos = this.selectionStart;

                    caretPos = spaceCaretPos(value, caretPos);
                    value = value.replace(thouReg, '');

                    var newValues = spaceFormat(value, caretPos);
                    this.value = newValues[0];
                    this.selectionStart = newValues[1];
                    this.selectionEnd = newValues[1];
                    tbchange(this);
                }
            });

            if ((e.ctrlKey && (key == 65 || key == 67 || key == 86 || key == 88 || key == 89 || key == 90)) ||
                (e.shiftKey && key == 9) || key == 189) // You don't want to disable your shortcuts!
                prevDefault = false;

            if ((key < 37 || key > 40) && key != 8 && key != 9 && prevDefault) {
                e.preventDefault();

                if (!e.altKey && !e.shiftKey && !e.ctrlKey) {

                    var value = this.value;
                    if ((key > 95 && key < 106) || (key > 47 && key < 58) ||
                        (deciNumber > 0 && (key == 110 || key == 188 || key == 189 || key == 190))) {

                        var keys = { // reformat the keyCode
                            48: 0,
                            49: 1,
                            50: 2,
                            51: 3,
                            52: 4,
                            53: 5,
                            54: 6,
                            55: 7,
                            56: 8,
                            57: 9,
                            96: 0,
                            97: 1,
                            98: 2,
                            99: 3,
                            100: 4,
                            101: 5,
                            102: 6,
                            103: 7,
                            104: 8,
                            105: 9,
                            110: deciSep,
                            188: deciSep,
                            189: '-',
                            190: deciSep
                        };

                        var caretPos = this.selectionStart;
                        var caretEnd = this.selectionEnd;

                        if (caretPos != caretEnd) // remove selected text
                            value = value.substring(0, caretPos) + value.substring(caretEnd);

                        caretPos = spaceCaretPos(value, caretPos);

                        value = value.replace(thouReg, '');

                        var before = value.substring(0, caretPos);
                        var after = value.substring(caretPos);
                        var newPos = caretPos + 1;

                        if (keys[key] == deciSep && value.indexOf(deciSep) >= 0) {
                            if (before.indexOf(deciSep) >= 0) newPos--;
                            before = before.replace(deciReg, '');
                            after = after.replace(deciReg, '');
                        }
                        var newValue = before + keys[key] + after;

                        if (newValue.substring(0, 1) == deciSep) {
                            newValue = "0" + newValue;
                            newPos++;
                        }

                        while (newValue.length > 1 && newValue.substring(0, 1) == "0" && newValue.substring(1, 2) != deciSep) {
                            newValue = newValue.substring(1);
                            newPos--;
                        }

                        if (newValue.indexOf(deciSep) >= 0) {
                            var newLength = newValue.indexOf(deciSep) + deciNumber + 1;
                            if (newValue.length > newLength) {
                                newValue = newValue.substring(0, newLength);
                            }
                        }

                        newValues = spaceFormat(newValue, newPos);

                        this.value = newValues[0];
                        this.selectionStart = newValues[1];
                        this.selectionEnd = newValues[1];
                    }
                }
            }

            $(this).on('blur', function (e) {
                if (key == 86) {
                    tbchange(this);
                }

                if (deciNumber > 0) {
                    var value = this.value;

                    var noDec = "";
                    for (var i = 0; i < deciNumber; i++) noDec += "0";

                    if (value == "0" + deciSep + noDec) {
                        this.value = ""; //<-- put your default value here
                    } else if (value.length > 0) {
                        if (value.indexOf(deciSep) >= 0) {
                            var newLength = value.indexOf(deciSep) + deciNumber + 1;
                            if (value.length < newLength) {
                                while (value.length < newLength) value = value + "0";
                                this.value = value.substring(0, newLength);
                            }
                        } else this.value = value + deciSep + noDec;
                    }
                }
            });
        }

        //======================================================================
        if (key != 8) {
            tbchange(this);
        }
        //===================================================================
    });

    $('.numberOnly2').on('keydown', function (e) {

        if (this.selectionStart || this.selectionStart == 0) {
            // selectionStart won't work in IE < 9

            var key = e.which;
            var prevDefault = true;

            var thouSep = ","; // your seperator for thousands
            var deciSep = "."; // your seperator for decimals
            var deciNumber = 2; // how many numbers after the comma

            var thouReg = new RegExp(thouSep, "g");
            var deciReg = new RegExp(deciSep, "g");

            function spaceCaretPos(val, cPos) {
                /// get the right caret position without the spaces

                if (cPos > 0 && val.substring((cPos - 1), cPos) == thouSep)
                    cPos = cPos - 1;

                if (val.substring(0, cPos).indexOf(thouSep) >= 0) {
                    cPos = cPos - val.substring(0, cPos).match(thouReg).length;
                }

                return cPos;
            }

            function spaceFormat(val, pos) {
                /// add spaces for thousands

                if (val.indexOf(deciSep) >= 0) {
                    var comPos = val.indexOf(deciSep);
                    var int = val.substring(0, comPos);
                    var dec = val.substring(comPos);
                } else {
                    var int = val;
                    var dec = "";
                }
                var ret = [val, pos];

                if ((int.length > 4 && int.includes("-")) || (int.length > 3 && !int.includes("-"))) {

                    var newInt = "";
                    var spaceIndex = int.length;

                    if (int.includes("-")) {
                        while (spaceIndex > 4) {
                            spaceIndex = spaceIndex - 3;
                            newInt = thouSep + int.substring(spaceIndex, spaceIndex + 3) + newInt;
                            if (pos > spaceIndex) pos++;
                        }
                    } else {
                        while (spaceIndex > 3) {
                            spaceIndex = spaceIndex - 3;
                            newInt = thouSep + int.substring(spaceIndex, spaceIndex + 3) + newInt;
                            if (pos > spaceIndex) pos++;
                        }
                    }
                    
                    ret = [int.substring(0, spaceIndex) + newInt + dec, pos];
                }
                return ret;
            }

            $(this).on('keyup', function (ev) {
                var value = $(e.target).val();
                if (ev.which == 8) {
                    // reformat the thousands after backspace keyup

                    //var value = this.value;
                    var caretPos = this.selectionStart;

                    caretPos = spaceCaretPos(value, caretPos);
                    value = value.replace(thouReg, '');

                    var newValues = spaceFormat(value, caretPos);
                    this.value = newValues[0];
                    this.selectionStart = newValues[1];
                    this.selectionEnd = newValues[1];
                    tbchange(this);
                }
            });

            if ((e.ctrlKey && (key == 65 || key == 67 || key == 86 || key == 88 || key == 89 || key == 90)) ||
                (e.shiftKey && key == 9) || key == 189) // You don't want to disable your shortcuts!
                prevDefault = false;

            if ((key < 37 || key > 40) && key != 8 && key != 9 && prevDefault) {
                e.preventDefault();

                if (!e.altKey && !e.shiftKey && !e.ctrlKey) {

                    var value = this.value;
                    if ((key > 95 && key < 106) || (key > 47 && key < 58) ||
                        (deciNumber > 0 && (key == 110 || key == 188 || key == 189 || key == 190))) {

                        var keys = { // reformat the keyCode
                            48: 0,
                            49: 1,
                            50: 2,
                            51: 3,
                            52: 4,
                            53: 5,
                            54: 6,
                            55: 7,
                            56: 8,
                            57: 9,
                            96: 0,
                            97: 1,
                            98: 2,
                            99: 3,
                            100: 4,
                            101: 5,
                            102: 6,
                            103: 7,
                            104: 8,
                            105: 9,
                            110: deciSep,
                            188: deciSep,
                            189: '-',
                            190: deciSep
                        };

                        var caretPos = this.selectionStart;
                        var caretEnd = this.selectionEnd;

                        if (caretPos != caretEnd) // remove selected text
                            value = value.substring(0, caretPos) + value.substring(caretEnd);

                        caretPos = spaceCaretPos(value, caretPos);

                        value = value.replace(thouReg, '');

                        var before = value.substring(0, caretPos);
                        var after = value.substring(caretPos);
                        var newPos = caretPos + 1;

                        if (keys[key] == deciSep && value.indexOf(deciSep) >= 0) {
                            if (before.indexOf(deciSep) >= 0) newPos--;
                            before = before.replace(deciReg, '');
                            after = after.replace(deciReg, '');
                        }
                        var newValue = before + keys[key] + after;

                        if (newValue.substring(0, 1) == deciSep) {
                            newValue = "0" + newValue;
                            newPos++;
                        }

                        while (newValue.length > 1 && newValue.substring(0, 1) == "0" && newValue.substring(1, 2) != deciSep) {
                            newValue = newValue.substring(1);
                            newPos--;
                        }

                        if (newValue.indexOf(deciSep) >= 0) {
                            var newLength = newValue.indexOf(deciSep) + deciNumber + 1;
                            if (newValue.length > newLength) {
                                newValue = newValue.substring(0, newLength);
                            }
                        }

                        newValues = spaceFormat(newValue, newPos);

                        this.value = newValues[0];
                        this.selectionStart = newValues[1];
                        this.selectionEnd = newValues[1];
                    }
                }
            }

            $(this).on('blur', function (e) {
                if (key == 86) {
                    tbchange(this);
                }

                if (deciNumber > 0) {
                    var value = this.value;

                    var noDec = "";
                    for (var i = 0; i < deciNumber; i++) noDec += "0";

                    if (value == "0" + deciSep + noDec) {
                        this.value = ""; //<-- put your default value here
                    } else if (value.length > 0) {
                        if (value.indexOf(deciSep) >= 0) {
                            var newLength = value.indexOf(deciSep) + deciNumber + 1;
                            if (value.length < newLength) {
                                while (value.length < newLength) value = value + "0";
                                this.value = value.substring(0, newLength);
                            }
                        } else this.value = value + deciSep + noDec;
                    }
                }
            });
        }

        //======================================================================
        if (key != 8) {
            tbchange(this);
        }
        //===================================================================
    });

    $('.price > input:eq(0)').focus();
});

function tbchange(_this) {
    var id = _this.id;
    var splitter = "t1s4f";

    if ($('#selectedform').val() == "form1770") {
        if (id == "t1s2f4") {
            var t1s2f4 = 0;
            var t1s4f50 = 0;
            if ($('#t1s2f4').val() != "") {
                t1s2f4 = parseFloat($('#t1s2f4').val().toString().replace(/[$,]+/g, ""));
            } 
            if ($('#t1s4f50').val() != "") {
                t1s4f50 = parseFloat($('#t1s4f50').val().toString().replace(/[$,]+/g, ""));
            }
            var t1s4f53 = t1s4f50 + t1s2f4;
            $('#t1s4f53').val(t1s4f53.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }
    }

    if (id.indexOf(splitter) >= 0 && id != 't1s4f53' && id != 't1s4f54') {
        if ($('#selectedform').val() == "form1770") {
            var nextTb = id.split(splitter)[1];
            var cb = parseInt(nextTb) + 1;

            if (nextTb % 4 != 0) {
                if ($('#' + splitter + cb).val() == "yes") {

                    nextTb1 = parseInt(nextTb) + 2;
                    nextTb2 = parseInt(nextTb) + 3;
                    $('#' + splitter + nextTb2).attr("readonly", true);
                    $('#' + splitter + nextTb1).val(0);
                    $('#' + splitter + nextTb2).val(_this.value);
                } else {
                    nextTb1 = parseInt(nextTb) + 2;
                    nextTb2 = parseInt(nextTb) + 3;
                    $('#' + splitter + nextTb2).attr("readonly", false);
                    $('#' + splitter + nextTb1).val(_this.value);
                    $('#' + splitter + nextTb2).val(0);
                }
            }

            var totalA = 0;
            var totalA2 = 0;
            var totalB = 0;
            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 1;
                var c = parseFloat($('#' + splitter + b).val());
                if (c >= 0) {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalA = parseFloat(totalA) + parseFloat(d);
                }
            }
            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 3;
                var c = parseFloat($('#' + splitter + b).val());
                if (c >= 0) {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalA2 = parseFloat(totalA2) + parseFloat(d);
                }
            }

            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 4;
                var c = parseFloat($('#' + splitter + b).val());
                if (c >= 0) {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalB = parseFloat(totalB) + parseFloat(d);
                }
            }

            var T44 = $('#t1s2f4').val().toString().replace(/[$,]+/g, "");
            var totalC = 0;
            if (T44 >= 0 && T44 != "") {
                totalC = parseFloat(totalA2) + parseFloat(T44);
            } else {
                totalC = parseFloat(totalA2) + 0;
            }

            $('#' + splitter + 49).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#' + splitter + 50).val(totalA2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#' + splitter + 53).val((totalC).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#' + splitter + 51).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            $('#' + splitter + 54).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        } else if ($('#selectedform').val() == "formNonUs" || $('#selectedform').val() == "formUs" || $('#selectedform').val() == "formJapan") {
            var nextTb = id.split(splitter)[1];
            var cb = parseInt(nextTb) + 1;

            if (cb % 4 != 0 && nextTb != "53" && nextTb != "54") {
                nextTb1 = parseInt(nextTb) + 2;
                nextTb2 = parseInt(nextTb) + 3;
                $('#' + splitter + nextTb1).val(_this.value);

                var val_a = 0;
                var val_b = 0;
                if (_this.value!="") {
                    val_a = parseFloat(_this.value.toString().replace(/[$,]+/g, ""));
                }
                if ($('#' + splitter + nextTb1).val() != "") {
                    val_b = parseFloat($('#' + splitter + nextTb1).val().toString().replace(/[$,]+/g, ""));
                }
                var total = val_a - val_b;
                $('#' + splitter + nextTb2).val(total.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                
            } else if (nextTb != "53" && nextTb != "54") {
                nextTb1 = parseInt(nextTb) - 2;
                nextTb2 = parseInt(nextTb) + 1;

                var val_a = 0;
                var val_b = 0;
                if ($('#' + splitter + nextTb1).val() != "") {
                    val_a = parseFloat($('#' + splitter + nextTb1).val().toString().replace(/[$,]+/g, ""));
                }
                if (_this.value != "") {
                    val_b = parseFloat(_this.value.toString().replace(/[$,]+/g, ""));
                }
                var total = val_a - val_b;
                $('#' + splitter + nextTb2).val(total.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                
            }

            var totalA = 0;
            var totalA2 = 0;
            var totalB = 0;
            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 1;
                var c = parseFloat($('#' + splitter + b).val());
                if ($('#' + splitter + b).val() != "") {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalA = parseFloat(totalA) + parseFloat(d);
                }
            }
            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 3;
                var c = parseFloat($('#' + splitter + b).val());
                if ($('#' + splitter + b).val() != "") {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalA2 = parseFloat(totalA2) + parseFloat(d);
                }
            }

            for (var a = 0; a < 12; a++) {
                var b = (a * 4) + 4;
                var c = parseFloat($('#' + splitter + b).val());
                if ($('#' + splitter + b).val()!="") {
                    var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                    totalB = parseFloat(totalB) + parseFloat(d);
                }
            }

            if (nextTb != "53" && nextTb != "54") {
                $('#' + splitter + 49).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#' + splitter + 50).val(totalA2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#' + splitter + 51).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#' + splitter + 53).val(totalA2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#' + splitter + 54).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
                $('#' + splitter + 52).val((parseFloat($('#' + splitter + 53).val().toString().replace(/[$,]+/g, "")) + parseFloat($('#' + splitter + 54).val().toString().replace(/[$,]+/g, ""))).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            } else {
                $('#' + splitter + 52).val((parseFloat($('#' + splitter + 53).val().toString().replace(/[$,]+/g, "")) + parseFloat($('#' + splitter + 54).val().toString().replace(/[$,]+/g, ""))).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
            }

            if ($('#selectedform').val() == "formJapan") {
                $('#t1s8f' + 4).val($('#' + splitter + 1).val());
                $('#t1s8f' + 6).val($('#' + splitter + 5).val());
                $('#t1s8f' + 10).val($('#' + splitter + 9).val());
                $('#t1s8f' + 12).val($('#' + splitter + 13).val());
                $('#t1s8f' + 14).val($('#' + splitter + 17).val());
                $('#t1s8f' + 16).val($('#' + splitter + 21).val());
                $('#t1s8f' + 18).val($('#' + splitter + 25).val());
                $('#t1s8f' + 20).val($('#' + splitter + 29).val());
                $('#t1s8f' + 22).val($('#' + splitter + 33).val());
                $('#t1s8f' + 24).val($('#' + splitter + 37).val());
                $('#t1s8f' + 26).val($('#' + splitter + 41).val());
                $('#t1s8f' + 28).val($('#' + splitter + 45).val());
                
                splitter = "t1s8f";
                UpdateS6("t1s8f2", splitter);
                UpdateS6("t1s8f4", splitter);
                UpdateS6("t1s8f6", splitter);
                UpdateS6("t1s8f8", splitter);
                UpdateS6("t1s8f10", splitter);
                UpdateS6("t1s8f12", splitter);
                UpdateS6("t1s8f14", splitter);
                UpdateS6("t1s8f16", splitter);
                UpdateS6("t1s8f18", splitter);
                UpdateS6("t1s8f20", splitter);
                UpdateS6("t1s8f22", splitter);
                UpdateS6("t1s8f24", splitter);
                UpdateS6("t1s8f26", splitter);
                UpdateS6("t1s8f28", splitter);
            }

        }

    }

    splitter = "iefield";
    if (id.indexOf(splitter) >= 0 && id != 'iefield26' && id != 'iefield27' && id != 'iefield21') {
        var totalA = 0;
        var totalB = 0;
        var personalrelief = $('#t1s3f3').val();
        if (personalrelief=="") {
            personalrelief = 0;
        }
        for (var a = 0; a < 7; a++) {
            var b = a + 9;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalA = parseFloat(totalA) + parseFloat(d);
            }
        }

        for (var a = 0; a < 2; a++) {
            var b = a + 17;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalB = parseFloat(totalB) + parseFloat(d);
            }
        }
        if ($('#selectedform').val() == "formNonUs" || $('#selectedform').val() == "formUs" || $('#selectedform').val() == "formJapan") {
            var d2 = parseFloat($('#' + splitter + 24).val());
            if (d2 > 0) {
                d2 = $('#' + splitter + 24).val().toString().replace(/[$,]+/g, "");
                totalB = parseFloat(totalB) + parseFloat(d2);
            }
        }
        var totalC = parseFloat(totalA) - parseFloat(totalB);

        $('#' + splitter + 16).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 19).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 20).val(totalC.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        var f22 = 0;
        if ($('#' + splitter + 22).val() != "") {
            f22 = $('#' + splitter + 22).val().toString().replace(/[$,]+/g, "");
        }
        var f23 = 0;
        if ($('#' + splitter + 23).val() != "") {
            f23 = $('#' + splitter + 23).val().toString().replace(/[$,]+/g, "");
        }
        var totalD = parseFloat(totalC) + parseFloat(f22);

        $('#' + splitter + 25).val(totalD.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        var totalE = 0;
        if($('#' + splitter + 3).val()=="12"){
            totalE = totalD;
        } else if ($('#' + splitter + 3).val()==0) {
            totalE = 0;
        } else {
            totalE = totalD / parseInt($('#' + splitter + 3).val()) * 12;
        }
        $('#' + splitter + 26).val(totalE.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        var total27 = 0;
        var total27a = 0;
        if ($('#' + splitter + 8).val() == "No") {
            total27a = totalE;
        } else {
            total27a = roundDown(totalE, -3);
        }


        if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 0) {
            total27 = 0;
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 50000000) {
            total27 = 0.05 * (parseFloat(total27a) - parseFloat($('#t1s3f3').val().toString().replace(/[$,]+/g, "")));
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 250000000) {
            total27 = 0.15 * (parseFloat(total27a) - parseFloat($('#t1s3f3').val().toString().replace(/[$,]+/g, ""))) - 5000000;
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 500000000) {
            total27 = 0.25 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, ""))) - 30000000;
        } else {
            total27 = 0.3 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, ""))) - 55000000;
        }

        var totalF = 0;
        if ($('#' + splitter + 3).val() == "12") {
            totalF = total27;
        } else if ($('#' + splitter + 3).val() == 0 || $('#' + splitter + 3).val() == "") {
            totalF = 0;
        } else {
            totalF = total27 / 12 * parseInt($('#' + splitter + 3).val());
        }
        if ($('#selectedform').val() == "formNonUs" || $('#selectedform').val() == "formUs" || $('#selectedform').val() == "formJapan") {
            $('#' + splitter + 21).val(totalF.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }
        var totalG = parseFloat(totalF) + parseFloat(f23);

        console.log(total27);
        $('#' + splitter + 27).val(total27.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 28).val(totalD.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 29).val(totalG.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    splitter = "iefieldedit";
    if (id.indexOf(splitter) >= 0 && id != 'iefieldedit26' && id != 'iefieldedit27' && id != 'iefieldedit21') {
        var totalA = 0;
        var totalB = 0;
        for (var a = 0; a < 7; a++) {
            var b = a + 9;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalA = parseFloat(totalA) + parseFloat(d);
            }
        }

        for (var a = 0; a < 2; a++) {
            var b = a + 17;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalB = parseFloat(totalB) + parseFloat(d);
            }
        }
        if ($('#selectedform').val() == "formNonUs" || $('#selectedform').val() == "formUs" || $('#selectedform').val() == "formJapan") {
            var d2 = parseFloat($('#' + splitter + 24).val());
            if (d2 > 0) {
                d2 = $('#' + splitter + 24).val().toString().replace(/[$,]+/g, "");
                totalB = parseFloat(totalB) + parseFloat(d2);
            }
        }

        var totalC = parseFloat(totalA) - parseFloat(totalB);

        $('#' + splitter + 16).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 19).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 20).val(totalC.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        var f22 = 0;
        if ($('#' + splitter + 22).val() != "") {
            f22 = $('#' + splitter + 22).val().toString().replace(/[$,]+/g, "");
        }
        var f23 = 0;
        if ($('#' + splitter + 23).val() != "") {
            f23 = $('#' + splitter + 23).val().toString().replace(/[$,]+/g, "");
        }
        var totalD = parseFloat(totalC) + parseFloat(f22);

        $('#' + splitter + 25).val(totalD.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        var totalE = 0;
        if ($('#' + splitter + 3).val() == "12") {
            totalE = totalD;
        } else if ($('#' + splitter + 3).val() == 0 || $('#' + splitter + 3).val() == "") {
            totalE = 0;
        } else {
            totalE = totalD / parseInt($('#' + splitter + 3).val()) * 12;
        }
        $('#' + splitter + 26).val(totalE.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        var total27 = 0;
        var total27a = 0;
        if ($('#' + splitter + 8).val() == "Yes") {
            total27a = roundDown(totalE, -3);
        } else {
            total27a = totalE;
        }

        if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 0) {
            total27 = parseFloat(0);
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 50000000) {
            total27 = 0.05 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")));
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 250000000) {
            total27 = 0.15 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, ""))) - 5000000;
        } else if (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, "")) <= 500000000) {
            total27 = 0.25 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, ""))) - 30000000;
        } else {
            total27 = 0.3 * (parseFloat(total27a) - parseFloat(personalrelief.toString().replace(/[$,]+/g, ""))) - 55000000;
        }

        var totalF = 0;
        if ($('#' + splitter + 3).val() == "12") {
            totalF = total27;
        } else if ($('#' + splitter + 3).val() == 0) {
            totalF = 0;
        } else {
            totalF = total27 / 12 * parseInt($('#' + splitter + 3).val());
        }
        if ($('#selectedform').val() == "formNonUs" || $('#selectedform').val() == "formUs" || $('#selectedform').val() == "formJapan") {
            $('#' + splitter + 21).val(totalF.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }
        var totalG = parseFloat(totalF) + parseFloat(f23);

        console.log(total27);
        $('#' + splitter + 27).val(total27.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 28).val(totalD.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 29).val(totalG.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    splitter = "t1s6f";
    if (id.indexOf(splitter) >= 0) {
        var totalA = 0;
        var totalB = 0;
        for (var a = 0; a < 6; a++) {
            var b = (a * 3) + 1;
            var c = parseFloat($('#' + splitter + b).val());
            var d = 0;
            if ($('#' + splitter + b).val() != "") {
                d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
            }
            totalA = parseFloat(totalA) + parseFloat(d);

            var e = (a * 3) + 2;
            var g = (a * 3) + 3;
            var f = 0;
            if ($('#' + splitter + e).val() != "") {
                f = $('#' + splitter + e).val().toString().replace(/[$,]+/g, "");
            }

            var totalA2 = parseFloat(d) - parseFloat(f);
            $('#' + splitter + g).val(totalA2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }

        for (var a = 0; a < 6; a++) {
            var b = (a * 3) + 2;
            var c = parseFloat($('#' + splitter + b).val());
            var d = 0;
            if ($('#' + splitter + b).val() != "") {
                d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
            }
            totalB = parseFloat(totalB) + parseFloat(d);

            var e = (a * 3) + 1;
            var g = (a * 3) + 3;
            var f = 0;
            if ($('#' + splitter + e).val() != "") {
                f = $('#' + splitter + e).val().toString().replace(/[$,]+/g, "");
            }

            var totalB2 = parseFloat(f) - parseFloat(d);
            $('#' + splitter + g).val(totalB2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }

        var h = 0;
        if ($('#' + splitter + 22).val() != "") {
           h = $('#' + splitter + 22).val().toString().replace(/[$,]+/g, "");
        }

        var i = 0;
        if ($('#' + splitter + 23).val() != "") {
           i = $('#' + splitter + 23).val().toString().replace(/[$,]+/g, "");
        }

        var totalD = parseFloat(h) - parseFloat(i);
        $('#' + splitter + 24).val(totalD.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

        var totalC = parseFloat(totalA) - parseFloat(totalB);
        $('#' + splitter + 19).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 20).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 21).val(totalC.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    splitter = "t1s7f";
    if (id.indexOf(splitter) >= 0) {
        var totalA = 0;
        var totalB = 0;
        var totalC = 0;
        for (var a = 0; a < 15; a++) {
            var b = (a * 2) + 1;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalA = parseFloat(totalA) + parseFloat(d);
            }
        }

        for (var a = 0; a < 15; a++) {
            var b = (a * 2) + 2;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalB = parseFloat(totalB) + parseFloat(d);
            }
        }

        for (var a = 0; a < 6; a++) {
            var b = (a) + 33;
            var c = parseFloat($('#' + splitter + b).val());
            if (c >= 0) {
                var d = $('#' + splitter + b).val().toString().replace(/[$,]+/g, "");
                totalC = parseFloat(totalC) + parseFloat(d);
            }
        }

        
        if (id == "t1s7f1") {
            var t1s7f1 = 0;
            if ($('#t1s7f1').val() != "") {
                t1s7f1 = parseFloat($('#t1s7f1').val().toString().replace(/[$,]+/g, ""));
            }
            var t1s7f2 = (t1s7f1 * 20) / 100;
            t1s7f2 = Math.round(t1s7f2);
            $('#t1s7f2').val(t1s7f2.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }

        $('#' + splitter + 31).val(totalA.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 32).val(totalB.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        $('#' + splitter + 39).val(totalC.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    splitter = "oi_";
    if (id.indexOf(splitter) >= 0) {
        UpdateIncome();
    } 
    
    splitter = "od_";
    if (id.indexOf(splitter) >= 0) {
        UpdateDetailed();
    }

    if ($('#selectedform').val() == "formUs") {
        splitter = "t1s8f";
        if (id.indexOf(splitter) >= 0) {
            UpdateS1();
        }
    }

    if ($('#selectedform').val() == "formJapan") {
        splitter = "t1s8f";
        if (id.indexOf(splitter) >= 0 && id != "t1s8f1") {
            UpdateS6(id, splitter);
        }
    }

    splitter = "as_";
    if (id.indexOf(splitter) >= 0) {
        UpdateAsset();
    }

    splitter = "cap_";
    if (id.indexOf(splitter) >= 0) {
        UpdateCapital();
    }

    splitter = "ren_";
    if (id.indexOf(splitter) >= 0) {
        UpdateRental();
    }
}

function roundDown(number, decimals) {
    decimals = decimals || 0;
    return (Math.floor(number * Math.pow(10, decimals)) / Math.pow(10, decimals));
}

function UpdateS6(id, splitter) {
    var currentid = parseInt(id.split(splitter)[1]);
    var nextid = parseInt(id.split(splitter)[1]) + 1;
    if ($("#" + splitter + currentid).val() == "") {
        var amountcurrency = 0;
    } else {
        var amountcurrency = parseInt($("#" + splitter + currentid).val().toString().replace(/[$,]+/g, ""));
    }
    
    var exchrate = parseInt($("#txtrate" + currentid / 2).val().toString().replace(/[$,]+/g, ""));
    console.log(amountcurrency);
    
    var amountidr = amountcurrency * exchrate;

    $("#" + splitter + nextid).val(amountidr.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    var totalcurrency = 0;
    var totalidr = 0;
    for (var a = 1; a <= 15; a++) {
        var tmpcurrency = 0;
        var tmpidr = 0;

        if ($("#" + splitter + (a * 2)).val() != "") {
            tmpcurrency = parseFloat($("#" + splitter + (a * 2)).val().toString().replace(/[$,]+/g, ""));
        }

        if ($("#" + splitter + ((a * 2) +1)).val() != "") {
            tmpidr = parseFloat($("#" + splitter + ((a * 2) + 1)).val().toString().replace(/[$,]+/g, ""));
        }

        totalcurrency += tmpcurrency;
        totalidr += tmpidr;
    }

    $("#" + splitter + 32).val(totalcurrency.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    $("#" + splitter + 33).val(totalidr.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
}

function UpdateS1() {
    var t1s8f1 = $('#t1s8f1').val().toString().replace(/[$,]+/g, "");
    var t1s8f2 = $('#t1s8f2').val().toString().replace(/[$,]+/g, "");
    var t1s8f3 = $('#t1s8f3').val().toString().replace(/[$,]+/g, "");
    var t1s8f4 = $('#t1s8f4').val().toString().replace(/[$,]+/g, "");
    var t1s8f5 = $('#t1s8f5').val().toString().replace(/[$,]+/g, "");

    if (t1s8f2 == "") {
        t1s8f2 = 0;
    }
    if (t1s8f3 == "") {
        t1s8f3 = 0;
    }
    if (t1s8f4 == "") {
        t1s8f4 = 0;
    }
    if (t1s8f5 == "") {
        t1s8f5 = 0;
    }

    var t1s8f6 = parseFloat(t1s8f2) + parseFloat(t1s8f3) + parseFloat(t1s8f4) + parseFloat(t1s8f5);
    var t1s8f7 = ((parseFloat(t1s8f6) / parseFloat(t1s8f1)) * 100);

    if (t1s8f6>=0) {
        $('#t1s8f6').val(t1s8f6.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    if (t1s8f7 >= 0) {
        $('#t1s8f7').val(t1s8f7.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    if (t1s8f2 >= 0) {
        $('#t1s8f10').val(parseFloat(t1s8f2).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    if (t1s8f3 >= 0) {
        $('#t1s8f12').val(parseFloat(t1s8f3).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    if (t1s8f4 >= 0) {
        $('#t1s8f13').val(parseFloat(t1s8f4).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    if (t1s8f5 >= 0) {
        $('#t1s8f14').val(parseFloat(t1s8f5).toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }



    var t1s8f9 = $('#t1s8f9').val().toString().replace(/[$,]+/g, "");
    var t1s8f10 = $('#t1s8f10').val().toString().replace(/[$,]+/g, "");
    var t1s8f11 = $('#t1s8f11').val().toString().replace(/[$,]+/g, "");
    var t1s8f12 = $('#t1s8f12').val().toString().replace(/[$,]+/g, "");
    var t1s8f13 = $('#t1s8f13').val().toString().replace(/[$,]+/g, "");
    var t1s8f14 = $('#t1s8f14').val().toString().replace(/[$,]+/g, "");
    var t1s8f15 = parseFloat(t1s8f10) + (parseFloat(t1s8f11)*-1) + parseFloat(t1s8f12) + parseFloat(t1s8f13) + parseFloat(t1s8f14);


    if (isNaN(t1s8f15)) {
        t1s8f15 = 0;
    }

    $('#t1s8f15').val(t1s8f15.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    

    var t1s8f16 = 0;
    if (t1s8f9 < 0 || t1s8f9=="") {
        $('#t1s8f16').val(0);
    } else {
        t1s8f16 = (t1s8f15 / t1s8f9)* 100;
        if (t1s8f16>=0) {
            $('#t1s8f16').val(t1s8f16.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }

    }

    if (t1s8f7 < t1s8f16) {
        if (t1s8f7 >= 0) {
            $('#t1s8f17').val(t1s8f7.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
    } else {
        if (t1s8f16 >= 0) {
            $('#t1s8f17').val(t1s8f16.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
    }
}

function ChangePayment(thecb) {
    var splitter = "t1s4f";
    var cbid = thecb.id.split(splitter)[1];
    var amountid = parseInt(cbid) - 1;
    $('#' + splitter + amountid).keydown();
}

function UpdateIncome() {
    var exchangerate = $('#oi_exchrate').val().toString().replace(/[$,]+/g, "");
    var incomecurrency = $('#oi_incomecurrency').val().toString().replace(/[$,]+/g, "");
    var taxpaidcurrency = $('#oi_taxpaidcurrency').val().toString().replace(/[$,]+/g, "");
    var treatyrate = $('#oi_treatyrate').val().toString().replace(/[$,]+/g, "");
    var incomerp = incomecurrency * exchangerate;
    var taxpaidrp = taxpaidcurrency * exchangerate;

    
    if ($('#selectedform').val() == "formJapan") {
        $('#oi_incomerp').val(Math.round(incomerp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    } else {
        if (incomerp >= 0) {
            $('#oi_incomerp').val(Math.round(incomerp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }
    }
    if (taxpaidrp >= 0) {
        $('#oi_taxpaidrp').val(Math.round(taxpaidrp).toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    var ftc = 0;
    if (treatyrate != "") {
        ftc = (incomerp * treatyrate) / 100;
        $('#oi_ftc').val(ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    } else {
        ftc = taxpaidrp;
        $('#oi_ftc').val(ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }

    var allowedftc = $('#oi_allowedftc').val().toString().replace(/[$,]+/g, "");
    if (ftc == 0) {
        $('#oi_allowedftc').val(taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    } else {
        if (taxpaidrp > ftc) {
            $('#oi_allowedftc').val(ftc.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        } else {
            $('#oi_allowedftc').val(taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
        }
    }
}



function UpdateDetailed() {
    var exchangerate = $('#od_exchrate').val().toString().replace(/[$,]+/g, "");
    var fullyearincome = $('#od_fullyearincome').val().toString().replace(/[$,]+/g, "");
    var workperiodused = $('#t1s8f20').val().toString().replace(/[$,]+/g, "");

    var t1s8f6 = $('#t1s8f6').val().toString().replace(/[$,]+/g, "");
    var t1s8f1 = $('#t1s8f1').val().toString().replace(/[$,]+/g, "");
    var etaxrate = parseFloat(t1s8f6) / parseFloat(t1s8f1);
    var t1s8f15 = $('#t1s8f15').val().toString().replace(/[$,]+/g, "");
    var t1s8f9 = $('#t1s8f9').val().toString().replace(/[$,]+/g, "");
    var percentage = parseFloat(t1s8f15) / parseFloat(t1s8f9);

    if (etaxrate < percentage) {
        ftcrate = etaxrate;
    } else {
        ftcrate = percentage;
    }

    //var ftcrate = $('#t1s8f17').val().toString().replace(/[$,]+/g, "");
    var incomecurrency = 0;

    if ($('#od_fullyearincome').val()=="0") {
        $('#od_incomecurrency').val(0);
        incomecurrency = 0;
    } else if ($('#od_desc').val().toLowerCase() == "equity compensation") {
        $('#od_incomecurrency').val($('#od_fullyearincome').val());
        incomecurrency = $('#od_fullyearincome').val().toString().replace(/[$,]+/g, "");
    } else {
        incomecurrency = fullyearincome / 12 * workperiodused;
        if (isNaN(incomecurrency)) {
            incomecurrency = 0;
        }
        if (incomecurrency<0) {
            incomecurrency = 0;
        }
        $('#od_incomecurrency').val(incomecurrency.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }

    if ($('#od_desc').val() == "" || $('#od_desc').val().toUpperCase().trim() == "TAX EXEMPT INTEREST" || $('#od_desc').val().toUpperCase().trim() == "WAGES") {
        $('#od_taxpaidcurrency').val("0");
        var taxpaidcurrency = 0;
    } else {
        console.log(incomecurrency);
        console.log(ftcrate);
        var taxpaidcurrency = (incomecurrency * ftcrate);
        if (isNaN(taxpaidcurrency)) {
            taxpaidcurrency = 0;
        }
        if (taxpaidcurrency<0) {
            taxpaidcurrency = 0;
        }
        $('#od_taxpaidcurrency').val(taxpaidcurrency.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }


    if (incomecurrency == "") {
        $('#od_incomerp').val("0");
    } else {
        var incomerp = incomecurrency * exchangerate;
        //incomerp = Math.round(incomerp);
        if (isNaN(incomerp)) {
            incomerp = 0;
        }
        if (incomerp < 0) {
            incomerp = 0;
        }
        $('#od_incomerp').val(incomerp.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }


    if (taxpaidcurrency == 0) {
        $('#od_taxpaidrp').val("0");
    } else {
        var taxpaidrp = taxpaidcurrency * exchangerate;
        if (isNaN(taxpaidrp)) {
            taxpaidrp = 0;
        }
        if (taxpaidrp<0) {
            taxpaidrp = 0;
        }
        $('#od_taxpaidrp').val(taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
}

function UpdateAsset() {
    var as_exchrate = $('#as_exchrate').val().toString().replace(/[$,]+/g, "");
    var as_originalcurrency = $('#as_originalcurrency').val().toString().replace(/[$,]+/g, "");

    var as_inrupiah = Math.round(as_originalcurrency * as_exchrate);

    if (as_inrupiah >= 0) {
        $('#as_inrupiah').val(as_inrupiah.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
}

function UpdateRental() {
    var ren_exchrate = $('#ren_exchrate').val().toString().replace(/[$,]+/g, "");
    var ren_amountcurrency = $('#ren_amountcurrency').val().toString().replace(/[$,]+/g, "");
    var ren_nettaxpaidcurrency = $('#ren_nettaxpaidcurrency').val().toString().replace(/[$,]+/g, "");
    var ren_nettaxpaidexchrate = $('#ren_nettaxpaidexchrate').val().toString().replace(/[$,]+/g, "");

    var ren_nettaxpaidamountrp = ren_nettaxpaidcurrency * ren_nettaxpaidexchrate;
    var ren_amountrp = ren_amountcurrency * ren_exchrate;

    if (ren_amountrp >= 0) {
        $('#ren_amountrp').val(ren_amountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
    if (ren_nettaxpaidamountrp >= 0) {
        $('#ren_nettaxpaidamountrp').val(ren_nettaxpaidamountrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
}

function UpdateCapital() {
    var cap_exchrate = $('#cap_exchrate').val().toString().replace(/[$,]+/g, "");
    var cap_proceeds = $('#cap_proceeds').val().toString().replace(/[$,]+/g, "");
    var cap_cost = $('#cap_cost').val().toString().replace(/[$,]+/g, "");
    var cap_taxpaid = $('#cap_taxpaid').val().toString().replace(/[$,]+/g, "");
    var ftcrate = $('#t1s8f17').val().toString().replace(/[$,]+/g, "");

    var t1s8f6 = $('#t1s8f6').val().toString().replace(/[$,]+/g, "");
    var t1s8f1 = $('#t1s8f1').val().toString().replace(/[$,]+/g, "");
    var etaxrate = parseFloat(t1s8f6) / parseFloat(t1s8f1);
    var t1s8f15 = $('#t1s8f15').val().toString().replace(/[$,]+/g, "");
    var t1s8f9 = $('#t1s8f9').val().toString().replace(/[$,]+/g, "");
    var percentage = parseFloat(t1s8f15) / parseFloat(t1s8f9);

    if (etaxrate < percentage) {
        ftcrate = etaxrate;
    } else {
        ftcrate = percentage;
    }

    var cap_gainloss = cap_proceeds - cap_cost;

    if ($('#selectedform').val() == "formUs") {
        if (cap_gainloss == 0) {
            cap_taxpaid = 0;
        } else {
            cap_taxpaid = cap_gainloss * ftcrate;
        }
    }

    var cap_gainlossrp = cap_gainloss * cap_exchrate;
    var cap_taxpaidrp = cap_taxpaid * cap_exchrate;

    if ($('#selectedform').val() == "formUs") {
        cap_taxpaid = parseFloat(cap_taxpaid);
        if (cap_taxpaid >= 0) {
            $('#cap_taxpaid').val(cap_taxpaid.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
        }
        $('#cap_taxpaid').val(cap_taxpaid.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }

    if (cap_gainloss >= 0) {
        $('#cap_gainloss').val(cap_gainloss.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));
    }
    $('#cap_gainloss').val(cap_gainloss.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 }));

    if (cap_gainlossrp >= 0) {
        $('#cap_gainlossrp').val(cap_gainlossrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
    $('#cap_gainlossrp').val(cap_gainlossrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));

    if (cap_taxpaidrp >= 0) {
        $('#cap_taxpaidrp').val(cap_taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
    }
    $('#cap_taxpaidrp').val(cap_taxpaidrp.toLocaleString('en-US', { minimumFractionDigits: 0, maximumFractionDigits: 0 }));
}

$(function () {
    // Checkbox
    $('textarea[name="show-form-1"]').hide();
    $('label[for="show-form-1"]').hide();

    $('input[name="checkbox6"]').on('click', function () {
        if ($(this).prop('checked')) {
            $('textarea[name="show-form-1"]').fadeIn();
            $('label[for="show-form-1"]').fadeIn();
        } else {
            $('textarea[name="show-form-1"]').hide();
            $('label[for="show-form-1"]').hide();
        }
    });

    // Select
    $('#t1s2f7').on('change', function () {
        if ($(this).val() === "Proxy") {
            $("#proxyChoose").show()
        } else {
            $("#proxyChoose").hide()
        }
    });

    $('#tax-year').on('change', function () {
        if ($(this).val() === "tax-year-version1") {
            $("#TaxYearChoose1").show()
        } else {
            $("#TaxYearChoose1").hide()
        }
    });

    $('#tax-year').on('change', function () {
        if ($(this).val() === "tax-year-version2") {
            $("#TaxYearChoose2").show()
        } else {
            $("#TaxYearChoose2").hide()
        }
    });

    $('#relationship').on('change', function () {
        if ($(this).val() === "Other") {
            $("#otherRelationship").show()
        } else {
            $("#otherRelationship").hide()
        }
    });

    $('#type').on('change', function () {
        if ($(this).val() === "yearly") {
            $("#yearlychoose").show()
            $("#monthlychoose").hide()
            $("#weeklychoose").hide()
        } else if ($(this).val() === "monthly") {
            $("#monthlychoose").show()
            $("#yearlychoose").hide()
            $("#weeklychoose").hide()
        } else if ($(this).val() === "weekly") {
            $("#weeklychoose").show()
            $("#monthlychoose").hide()
            $("#yearlychoose").hide()
        }
    });

    $('.currency').on('change', function () {
        if ($(this).val() === "Other") {
            $(".otherChoose2").show()
            $(".otherChoose1").hide()
        } else {
            $(".otherChoose2").hide()
            $(".otherChoose1").show()
        }
    });

    $(".country").countrySelect();
});