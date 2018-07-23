
function initMap() {
    let lattitude = parseFloat($("#lattitude").text());
    let longitude = parseFloat($("#longitude").text());
    if (lattitude === 0 || isNaN(lattitude)) {
        lattitude = 54.34;
        longitude = 18.6464;
    }
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: lattitude, lng: longitude },
        zoom: 15
    });
    var card = document.getElementById('pac-card');
    var input = document.getElementById('pac-input');
    var types = document.getElementById('type-selector');
    var strictBounds = document.getElementById('strict-bounds-selector');

    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);

    var autocomplete = new google.maps.places.Autocomplete(input);

    autocomplete.bindTo('bounds', map);

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
            window.alert("No details available for input: '" + place.name + "'");
            return;
        }

        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17);  
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
                    '#DA5D4C',
                    '#86A2C0',
                    '#A39482',
                    '#4E4D53',
                    '#DA5D4C',
                    '#1E3441',
                ],
                borderColor: [
                ],
                borderWidth: 1
            }]
        },
        options: {
            tooltips: {
                callbacks: {
                    labelTextColor: function (tooltipItem, chart) {
                        return '#c623c1';
                    },
                    label: function (tooltipItem, data) {
                        var label = data.datasets[tooltipItem.datasetIndex].label || '';
                        if (label) {
                            label += ': ';
                        }
                        label += Math.round(tooltipItem.yLabel * 100) / 100;
                        return label;
                    }
                }
            },
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