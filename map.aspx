<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="map.aspx.vb" Inherits="map" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
             <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCGdnRIzHGuK_Yfye4VFuwurTxdlVh5xTA"></script>
    <script type="text/javascript">
        var map;
        var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        var labelIndex = 0;
        var markers = [];
        function set_event(marker) {
            google.maps.event.addListener(marker, 'click', function () {
                window.location.href = marker.url;
            });
        }
        window.onload = function () {
            var mapOptions;
            var latitude;
            var longitude;
            var AdsNameText;
            var AdsIDText;
            var map;
        
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            if (document.getElementById("<%=E.ClientID%>").value == "") {


            }
            else {
                latitude = document.getElementById("<%=N.ClientID%>").value.split("-");
                longitude = document.getElementById("<%=E.ClientID%>").value.split("-");
                AdsNameText = document.getElementById("<%=AdsName.ClientID%>").value.split("-");
                AdsIDText = document.getElementById("<%=AdsID.ClientID%>").value.split("-");
                mapOptions = {
                    center: new google.maps.LatLng(35.6816314494935,51.3621246814728),
                    zoom: 14,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                var i;
                for (i = 0; i < latitude.length; i++) {
                   var newPosition = new google.maps.LatLng(latitude[i], longitude[i]);
                   markers[i] = new google.maps.Marker({ position: newPosition, label: AdsNameText[i],url: 'AdsView.aspx?prjid='+AdsIDText[i], map: map });

                           // CLICK (Allow each marker to have an info window)
                    //google.maps.event.addListener(, 'click', function () {  });
                    set_event(markers[i]);

                }



            }


        }



    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
       <ul class="breadc">
<div  class="container-fluid" style="background-color:#ffffff">
	<li><i class="fa fa-home"></i></li>
           <div id="html1" style="display:inline "  runat="server" ></div> 
                                                           <asp:DropDownList AutoPostBack="true" style="border:0px solid #000"   ID="ddJobs"  runat="server">
                                                </asp:DropDownList>


</div>
</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <div id="dvMap" style=" width:100%;  height:500px; ">    </div>
    <asp:HiddenField ID="N" runat="server" />
    <asp:HiddenField ID="E" runat="server" />
    <asp:HiddenField ID="AdsName" runat="server" />
    <asp:HiddenField ID="AdsID" runat="server" />
</asp:Content>

