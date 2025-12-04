
$(document).ready(function () {
    console.log('Document is ready');

    $(".day-cell").click(function () {
        console.log('Day cell clicked');
        $(".day-cell").removeClass("active");
        $(this).addClass("active");
        
    
         
    });
});