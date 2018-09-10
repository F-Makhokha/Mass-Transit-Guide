$(document).ready(function () {
    $('#evet-butonu').click(function () {
        var TC = $('#TC').val();
        $.ajax ({
            url: '/Map/ShowDrivers',
            contentType: "application/json",
            type: 'POST',
            data: { 'TC': TC },
            dataType: 'json',
            success: function (data) {
                
                if (data.islem == 1) {
                    location.reload();
                    alert("Oldu");
                }
                else {
                    alert("Olmadı");
                }
            }
        });
    });
});