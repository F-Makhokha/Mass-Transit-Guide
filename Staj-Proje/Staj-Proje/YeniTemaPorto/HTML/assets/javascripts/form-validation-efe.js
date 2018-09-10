function preventNumbers() {
    $('.onlyText').keydown(function (e) {
        if (/*e.shiftKey || */ e.ctrlKey || e.altKey) {
            e.preventDefault();
        }
        else {
            var key = e.keyCode;
            if (!((key == 8) || (key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90) || (key == 222))) {
                e.preventDefault();
            }
        }
    });
}

// Numara isteyen yerlere text girilmesini engellemek
function preventTexts() {
    $('.onlyNumber').keydown(function (e) {
        if (e.shiftKey || e.ctrlKey || e.altKey) {
            e.preventDefault();
        }
        else {
            var key = e.keyCode;
            if (((key == 32) || (key == 46) || (key >= 35 && key <= 40) || (key >= 65 && key <= 90))) {
                e.preventDefault();
            }
        }
    });
}

$(document).ready(function () {
    $('#Send_Button').click(function () {
        validateForm();
    });



    function validateForm() {
        var TC = $('#TC').val();
        var Name = $('#Name').val();
        var Surname = $('#Surname').val();
        var Bus_Selection = $('#Bus_Selection').val();
        var Durak_Adi = $('#Durak_Adi').val();
        var Enlem = $('#Enlem').val();
        var Boylam = $('#Boylam').val();
        var Plaka_No = $('#Plaka_No').val();
        var Guzergah_Adi = $('#Guzergah_Adi').val();
        var Durak_Sira = $('#Durak_Sira').val();
        var error_message = "";
        $("#error").html("");
        
        if (TC == "") {
            error_message += "<p>TC Kimlik Numara alanı zorunludur</p>";
        }
   
        if (Name == "") {
            error_message += "<p>Adı alanı zorunludur</p>";
        }

        if (Surname == "") {
            error_message += "<p>Soyad alanı zorunludur</p>";
        }

        if (Bus_Selection == "") {
            error_message += "<p>Otobüs Numara alanı zorunludur</p>";
        }

        if (Durak_Adi == "") {
            error_message += "<p>Durak Adı boş olamaz</p>";
        }

        if (Enlem == "" || Boylam == "") {
            error_message += "<p>Enlem veya boylam boş olamaz</p>";
        }

        if (Plaka_No == "") {
            error_message += "<p>Plaka No boş olamaz</p>";
        }

        if (Guzergah_Adi == "") {
            error_message += "<p>Güzergah Adi boş olamaz</p>";
        }

        if (Durak_Sira == "") {
            error_message += "<p>Bir durak sirasi seçmelisiniz</p>";
        }

        if (error_message != "") {

            $("#error").html(error_message);
        }

        else {
            $(".driver-form").submit();
        }

    }
    preventNumbers(); preventTexts();
});

