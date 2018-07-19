 //This example requires the Places library. Include the libraries=places
 ////parameter when you first load the API. For example:
 //<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCIxaqwOzo2dsq8cUsKlkgQcjRH4w1LRRY&libraries=places">

function initMap() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 54.3688, lng: 18.8195 },
        zoom: 13
    });
    var card = document.getElementById('pac-card');
    var input = document.getElementById('pac-input');
    var types = document.getElementById('type-selector');
    var strictBounds = document.getElementById('strict-bounds-selector');

    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

    var autocomplete = new google.maps.places.Autocomplete(input);

    // Bind the map's bounds (viewport) property to the autocomplete object,
    // so that the autocomplete requests use the current map bounds for the
    // bounds option in the request.
    autocomplete.bindTo('bounds', map);

    // Set the data fields to return when the user selects a place.
    autocomplete.setFields(
        ['address_components', 'geometry', 'icon', 'name']);
    
    var infowindow = new google.maps.InfoWindow();
    var infowindowContent = document.getElementById('infowindow-content');
    infowindow.setContent(infowindowContent);
    var marker = new google.maps.Marker({
        map: map,
        anchorPoint: new google.maps.Point(0, -29)
    });

    autocomplete.addListener('place_changed', function () {
        infowindow.close();
        marker.setVisible(false);
        var place = autocomplete.getPlace();
        if (!place.geometry) {
            // User entered the name of a Place that was not suggested and
            // pressed the Enter key, or the Place Details request failed.
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }

        // If the place has a geometry, then present it on a map.
        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  // Why 17? Because it looks good.
        }
        marker.setPosition(place.geometry.location);
        marker.setVisible(true);

        var address = '';
        if (place.address_components) {
            address = [
                (place.address_components[0] && place.address_components[0].short_name || ''),
                (place.address_components[1] && place.address_components[1].short_name || ''),
                (place.address_components[2] && place.address_components[2].short_name || '')
            ].join(' ');
        }

        infowindowContent.children['place-icon'].src = place.icon;
        infowindowContent.children['place-name'].textContent = place.name;
        infowindowContent.children['place-address'].textContent = address;
        infowindow.open(map, marker);
    });


    let userInput = "Gdańsk";

    document.querySelector('button').addEventListener('click', function () {
        userInput = document.querySelector('input#pac-input').value;
    });



    /////////////////////////////////////////////////////////////

    $('#btnPost').on('click', function () {
        var userInputJS = $('#pac-input').val();

        $.ajax({
            type: "POST",
            url: "Map",
            data: {
                userInput: userInputJS
            },
            success: function (response) {
                console.log("wszystko ok");
            },
            error: function (response) {
                console.log("nie działa");
            }
        });
    })

    let typequantity1 = document.querySelector("#type1 .typequantity").innerText;
    let typename1 = document.querySelector("#type1 .typename").innerText;
    let typequantity2 = document.querySelector("#type2 .typequantity").innerText;
    let typename2 = document.querySelector("#type2 .typename").innerText;
    let typequantity3 = document.querySelector("#type3 .typequantity").innerText;
    let typename3 = document.querySelector("#type3 .typename").innerText;
    let typequantity4 = document.querySelector("#type4 .typequantity").innerText;
    let typename4 = document.querySelector("#type4 .typename").innerText;
    let typequantity5 = document.querySelector("#type5 .typequantity").innerText;
    let typename5 = document.querySelector("#type5 .typename").innerText;
    let typequantity6 = document.querySelector("#type6 .typequantity").innerText;
    let typename6 = document.querySelector("#type6 .typename").innerText;

    let ctx = document.getElementById("myChart");
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [typename1, typename2, typename3, typename4, typename5, typename6],
            datasets: [{
                label: 'Number of facilities',
                data: [typequantity1, typequantity2, typequantity3, typequantity4, typequantity5, typequantity6],
                backgroundColor: [
                    '#ff0000',
                    '#000000',
                    '#00ff00',
                    '#0000ff',
                    '#00ffff',
                    '#ffff00',
                ],
                borderColor: [
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });



}