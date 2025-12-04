
$(document).ready(function () {
    $(".day-cell").click(function () {
        var dayOfWeek = $(this).data("day");
        var city = $(this).data("city");

        $.ajax({
            url: dayDetailsUrl, 
            type: "POST",
            data: { dayOfWeek: dayOfWeek, city: city },
            success: function (data) {
                $("#dayDetails").html(data); 
            },
            error: function () {
                alert("Greska prilikom ucitavanja podataka.");
            }
        });
    });
});

