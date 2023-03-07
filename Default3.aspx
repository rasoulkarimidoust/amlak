﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default3.aspx.vb" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Leaflet Control Geocoder</title>

    <meta charset="utf-8" />
    <meta
      name="viewport"
      content="width=device-width, user-scalable=no initial-scale=1, maximum-scale=1"
    />

    <link rel="stylesheet" href="https://unpkg.com/leaflet@latest/dist/leaflet.css" />
  

    <script src="https://unpkg.com/leaflet@latest/dist/leaflet-src.js"></script>
<link rel="stylesheet" href="https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.css" />
<script src="https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.js"></script>
    <style type="text/css">
      body {
        margin: 0;
      }
      #map {
        position: absolute;
        width: 100%;
        height: 100%;
      }
    </style>
  </head>
<body>
    <form id="form1" runat="server">
      <div id="map"></div>

    <script type="text/javascript">
        var map = L.map('map').setView([0, 0], 3);

        var geocoder = L.Control.Geocoder.nominatim();
        if (typeof URLSearchParams !== 'undefined' && location.search) {
            // parse /?geocoder=nominatim from URL
            var params = new URLSearchParams(location.search);
            var geocoderString = params.get('geocoder');
            if (geocoderString && L.Control.Geocoder[geocoderString]) {
                console.log('Using geocoder', geocoderString);
                geocoder = L.Control.Geocoder[geocoderString]();
            } else if (geocoderString) {
                console.warn('Unsupported geocoder', geocoderString);
            }
        }

        var control = L.Control.geocoder({
            query: 'Moon',
            placeholder: 'Search here...',
            geocoder: geocoder
        }).addTo(map);
        var marker;

        setTimeout(function () {
            control.setQuery('Earth');
        }, 12000);

        L.tileLayer('https://{s}.tile.osm.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);

        map.on('click', function (e) {
            geocoder.reverse(e.latlng, map.options.crs.scale(map.getZoom()), function (results) {
                var r = results[0];
                if (r) {
                    if (marker) {
                        marker
                            .setLatLng(r.center)
                            .setPopupContent(r.html || r.name)
                            .openPopup();
                    } else {
                        marker = L.marker(r.center)
                            .bindPopup(r.name)
                            .addTo(map)
                            .openPopup();
                    }
                }
            });
        });
    </script>
    </form>


    
  </body>
</html>