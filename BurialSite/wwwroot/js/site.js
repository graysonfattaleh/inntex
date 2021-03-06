// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function StaySelected() {
    // get url params
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    let gender = urlParams.get('genderfilter');
    let location = urlParams.get('locationfilter');
    let custom = urlParams.get('customfilter');

    //get gender

    var selectedGenders = document.getElementById('genderfilter');
    for (var i = 0; i < selectedGenders .length; i++) {

        if (selectedGenders[i].value == gender) {
            selectedGenders[i].selected = true;
        };
    }
    // get location
    var selectedLocations= document.getElementById('locationfilter');
    for (var i = 0; i < selectedLocations.length; i++) {
        if (selectedLocations[i].value == location) {
            selectedLocations[i].selected = true;
        };
    }

    var selectedCustoms = document.getElementById('customfilter');
    for (var i = 0; i < selectedCustoms.length; i++) {
        if (selectedCustoms[i].value == custom) {
            selectedCustoms[i].selected = true;
        };
    }  

}

StaySelected()

function DeleteWarning(numberid) {
    document.getElementById("DeleteForm-" + numberid).style.display = "inline-block";
    document.getElementById("DeletePrecursor-" + numberid).style.display = "none";

}