
    
   document.getElementById("cityInput").addEventListener("keypress", function (event) {
       if (event.key === "Enter") {
            
           console.log("Enter pritisnut");
           if (validateSearch()) {
               console.log("Grad je validan, forma se salje");
             
           } else {
               console.log("Grad nije validan");
           }
       }
   });

   
function validateSearch() {
    let allowedCities = ["Ankara", "Moscow", "London", "Berlin", "Madrid", "Kyiv", "Rome", "Paris", "Warsaw", "Barcelona", "Budapest", "Belgrade", "Prague", "Amsterdam", "Dublin", "Ljubljana", "Sarajevo", "Tirana", "Vienna", "Minsk", "Sofia", "Bern", "San Marino", "Oslo", "Brussels"];
    let inputCity = document.getElementById("cityInput").value;

    if (!allowedCities.includes(inputCity)) {
        alert("Molimo unesite validan grad iz liste.");
        return false; 
    }

    return true; 
}
