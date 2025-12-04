$(document).ready(function () {
    console.log("Dokument je spreman.");

    $('#refreshBtn').click(function () {
        console.log("Kliknuto dugme");

        $.ajax({
            url: window.location.href, // URL za ponovni zahtev
            type: 'GET',
            success: function (response) {
                // Pronadji novu .cities sekciju iz odgovora
                var newWeatherData = $(response).find('.cities').html();

                // Proveri da li je sadrzaj promenjen
                if ($('.cities').html() !== newWeatherData) {
                    console.log("Sadrzaj je promenjen");
                    $('.cities').html(newWeatherData);  // Zamenjujemo sadrzaj
                } else {
                    console.log("Sadrzaj nije promenjen");
                }
            },
            error: function (error) {
                console.error("Greska prilikom osvezavanja:", error);
            }
        });
    });
});