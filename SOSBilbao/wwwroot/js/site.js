//// Pasamos las longitudes y las latitudes desde el index de UsuarioSupermercados

//var nombreSupermercado = document.getElementsByClassName("nombreFavoritosSupermercado");
//var latitudSupermercado = document.getElementsByClassName("latitudFavoritosSupermercado");
//var longitudSupermercado = document.getElementsByClassName("longitudFavoritosSupermercado");

//// MAPA BASE DE SUPERMERCADOS (FAVORITOS SUPERMERCADOS)

//let mymap = L.map('mapsupermercado').setView([43.2626276, -2.9475673], 13)

//L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//    maxZoom: 19,
//    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'

//}).addTo(mymap);

//// MAPA BASE DE FARMACIAS (FAVORITOS FARMACIAS)

////let map = L.map('map').setView([43.2626276, -2.9475673], 13)

////    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
////    maxZoom: 19,
////    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'

////}).addTo(map);

////-------------------------------------------------------------------------------------------------

////// Pasamos las longitudes y las latitudes desde el index de farmacias 

////var nombresFarmacias = document.getElementsByClassName("nombrefavoritosfarmacia");
////var latitudesFarmacias = document.getElementsByClassName("latitudfavoritosfarmacia");
////var longitudesFarmacias = document.getElementsByClassName("longitudfavoritosfarmacia");

////// Recorrenos las 5 primeras farmacias y les ponemos sus Markers

////for (let i = 0; i < 5; i++) {
////    var farmacia = [longitudesFarmacias[i].innerText, latitudesFarmacias[i].innerText];
////    var marker = L.marker(farmacia);
////    marker.bindPopup(nombresFarmacias[i]);
////    marker.addTo(map);
////    console.log('')
////}


////// MAPA BASE DE PARADAS DE TAXIS (FAVORITOS MAPAS)

////let mymap = L.map('maptaxi').setView([43.2626276, -2.9475673], 13)

////    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
////    maxZoom: 19,
////    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'

////}).addTo(mymap);


////// Pasamos las longitudes y las latitudes desde el index de farmacias 

////var direccionParadaTaxi = document.getElementsByClassName("direccion");
////var latitudParadaTaxi = document.getElementsByClassName("latitudParadaTaxi");
////var longitudParadaTaxi = document.getElementsByClassName("longitudParadaTaxi");

////// Recorrenos las 5 primeras farmacias y les ponemos sus Markers

////for (let x = 0; x < 5; x++) {
////    var paradaTaxi = [longitudParadaTaxi[x].innerText, latitudParadaTaxi[x].innerText];
////    var marker = L.marker(paradaTaxi);
////    marker.bindPopup(direccionParadaTaxi[x]);
////    marker.addTo(mymap);
////    console.log('')
////}


////-------------------------------------------------------------------------------------------------


//// MAPA BASE DE SUPERMERCADOS (FAVORITOS SUPERMERCADOS)

////let mymap = L.map('mapsupermercado').setView([43.2626276, -2.9475673], 13)

////L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
////    maxZoom: 19,
////    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'

////}).addTo(mymap);




//// Recorrenos las 5 primeros supermercadoss y les ponemos sus Markers

//for (let z = 0; z < 5; z++) {
//    var supermercado = [longitudSupermercado[z].innerText, latitudSupermercado[z].innerText];
//    var marker = L.marker(supermercado);
//    marker.bindPopup(nombreSupermercado[z]);
//    marker.addTo(mymap);
//}



////-------------------------------------------------------------------------------------------------





////var farmacia1 = [43.2633893, -2.9507];
////var marker = L.marker(farmacia1)
////marker.bindPopup('Elena Barrenetxea Mañarikua');
////marker.addTo(map);











////// Es posible meter datos a traves de un JSON y asi mostrarlos en el mapa , en este ejemplo
////// se utiliza "geojson" pero seguro que hay otras librerias json
////let geojson_url = "https://babel.webreactiva.com/labs/arboles_singulares_en_espacios_naturales.geojson"
//////let marker = L.marker([43.2626276, -2.9475673], 13).addTo(map);


////fetch(
////    geojson_url
////).then(
////    res => res.json()

////).then(
////    data => {

////        let geojsonlayer = L.geoJson(data, {
////            onEachFeature: function (feature, layer) {
////                layer.bindPopup(feature.properties['arbol_nombre'])
////            }
////        }).addTo(map)
////        map.fitBounds(geojsonlayer.getBounds())
////    }
////)


// Comprobacion de si Esiste el Favorito en Farmacia

let favoritoFarmacia = document.getElementById('favView').value;

if (favoritoFarmacia == 'existe') {
  alert("Ya existe este Favorito");
};

// Comprobacion de si Existe el Favorito en Supermercado

let favoritoSupermercado = document.getElementById('favViewSupermercado').value;

if (favoritoSupermercado == 'existe') {
    alert("Ya existe este Favorito");
};

// Comprobacion si Existe el Favorito en Parada Taxi
let favoritoParadaTaxi = document.getElementById('favViewParada').value;

if (favoritoParadaTaxi == 'existe') {
    alert("Ya existe este Favorito");
};