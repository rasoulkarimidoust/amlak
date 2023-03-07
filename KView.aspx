<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="KView.aspx.vb" Inherits="KUpdate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyCGdnRIzHGuK_Yfye4VFuwurTxdlVh5xTA"></script>
    <script type="text/javascript">
        var map;
        var labels = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
        var labelIndex = 0;
        var marker;

        // Adds a marker to the map.
        function addMarker(location, map) {
            if (marker) {
                marker.setMap(null);
            }
            marker = new google.maps.Marker({
                position: location,
                label: labels[0],//labelIndex++ % labels.length
                map: map
            });
            // Add the marker at the clicked location, and add the next-available label
            // from the array of alphabetical characters.
        }
        window.onload = function () {
            var mapOptions;
            var latitude;
            var longitude;
            var map;
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            if (document.getElementById("<%=E.ClientID%>").value == "") {

                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        latitude = position.coords.latitude;
                        longitude = position.coords.longitude;
                        document.getElementById("<%=N.ClientID%>").value = latitude;
                        document.getElementById("<%=E.ClientID%>").value = longitude;
                        mapOptions = { center: new google.maps.LatLng(document.getElementById("<%=N.ClientID%>").value, document.getElementById("<%=E.ClientID%>").value), zoom: 14, mapTypeId: google.maps.MapTypeId.ROADMAP };
                        map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);


                    });



            } else {
                alert("Geolocation API is not supported in your browser.");
            }

        }
        else {
            latitude = document.getElementById("<%=N.ClientID%>").value;
                longitude = document.getElementById("<%=E.ClientID%>").value;
                mapOptions = {
                    center: new google.maps.LatLng(latitude, longitude),
                    zoom: 14,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };

                map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

                var newPosition = new google.maps.LatLng(document.getElementById("<%=N.ClientID%>").value, document.getElementById("<%=E.ClientID%>").value);
                var oldmarker = new google.maps.Marker({ position: newPosition, label: 'کارفرما', map: map });

            }


        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <!-- Section Title -->           
  
                    
                        <br />
                    
            <div class="container "  style="background-color:#f5f6f4; text-align:center   " >
                <img alt="" width="100%" height="1px" style="   display: block;" src="TemplateWorld_files/lineb.png" />

            <div  id="divReg" style="background-color:#f5f6f4; padding-right:10px; padding-left:10px;" class="col-xs-12 col-sm-6 col-md-6">
        
            <br />
        
                         <div class="row">
                             
           <div class="col-xs-12 col-sm-3 col-md-3">نام و نام خانوادگی:</div>
                                         <div class="col-xs-12 col-sm-3 col-md-3">
                <asp:label ID="txtName" CssClass="textbox"  Width="100%"      tooltip="نام و نام خانوادگی" runat="server"></asp:label>
</div> 
                             
<%--           <div class="col-xs-12 col-sm-3 col-md-3">ایمیل:</div>

            <div class="col-xs-12 col-sm-3 col-md-3">
                <asp:TextBox ID="txtEmail" CssClass="textbox" Width="100%"  tooltip="ایمیل" runat="server"></asp:TextBox>
                
</div> --%>
</div> 
<%--                         <div class="row">
           <div class="col-xs-12 col-sm-3 col-md-3">تلفن ثابت:</div>
                             
            <div class="col-xs-12 col-sm-3 col-md-3">
                <asp:TextBox ID="txtTel" CssClass="textbox" Width="100%"     tooltip="تلفن ثابت" runat="server"></asp:TextBox>
</div>           
                              <div class="col-xs-12 col-sm-3 col-md-3">موبایل:</div>

            <div class="col-xs-12 col-sm-3 col-md-3">
                
                <asp:TextBox ID="txtMobile" CssClass="textbox"  Width="100%"  tooltip="موبایل" runat="server"></asp:TextBox>
</div> 
                             </div><br />
                         <div class="row">
                             
                              <div class="col-xs-12 col-sm-3 col-md-3">آدرس:</div>
            <div class="col-xs-12 col-sm-9 col-md-9">
                <asp:TextBox ID="txtAddress" CssClass="textbox" Width="100%" ToolTip="آدرس"   runat="server"></asp:TextBox>
</div> 
                             </div><br />
                         <div class="row">
                              <div class="col-xs-12 col-sm-3 col-md-3">کلمه عبور :</div>
            <div class="col-xs-12 col-sm-3 col-md-3">

                <asp:TextBox ID="txtNewPass" CssClass="textbox"   TextMode="Password" Width="100%"    tooltip="کلمه عبور" runat="server"></asp:TextBox>
</div> 
                              <div class="col-xs-12 col-sm-3 col-md-3">تکرار کلمه عبور :</div>
            <div class="col-xs-12 col-sm-3 col-md-3">
               
                <asp:TextBox ID="txtNewPass2"  TextMode="Password" CssClass="textbox"  Width="100%"    tooltip="تکرار کلمه عبور"  runat="server"></asp:TextBox>

            </div> 

</div>

                         <div class="row">

                                                           <div class="col-xs-12 col-sm-3 col-md-3">نام کاربری:</div>

            <div class="col-xs-12 col-sm-3 col-md-3">
                <asp:TextBox ID="txtNewUserName" CssClass="textbox" Width="100%" ToolTip="نام کاربری" runat="server"></asp:TextBox>
</div> 





                                                           <div class="col-xs-12 col-sm-3 col-md-3"> کد تائید:</div>


                                         <div class="col-xs-12 col-sm-3 col-md-3">
                                                             <asp:TextBox ID="txtCaptcha"  Width="100%"  CssClass="textbox"   tooltip="کد تائید" runat="server"></asp:TextBox>
                             </div>
                             </div> 

 <br />
                         <div class="row">
            <div class="col-xs-12 col-sm-6 col-md-6">
</div> 
            <div class="col-xs-12 col-sm-3 col-md-3">
                
</div> 
            <div class="col-xs-12 col-sm-3 col-md-3">
                       <cpt:CaptchaControl ID="CaptchaControl1" runat="server" Arithmetic="False" 
                                ArithmeticFunction="Random" CaptchaBackgroundNoise="None" 
                                CaptchaChars="0123456789" CaptchaWidth="100"  CaptchaHeight="32" Height="32" Width="100" CaptchaLength="4"
                                CustomValidatorErrorMessage="اطلاعات وارد شده صحیح نمی باشند" FontColor="DarkBlue"  CaptchaLineNoise="Medium"  />
        
                

            </div> 
                                         <div class="col-xs-12 col-sm-3 col-md-3">
                             </div>

</div> 
                                                    <br />
                                    لطفا موقعیت جغرافیایی خود را از نقشه مقابل انتخاب کنید.
                                    <br />--%>
                                                <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="N" Width="1px"  height="1px"  placeholder="مختصات" runat="server"></asp:TextBox><asp:TextBox ID="E"  Width="1px"  height="1px"  placeholder="مختصات" runat="server"></asp:TextBox>
</div> 
 <%--               <br /><br />
                                                                         <asp:Button Width="150px" CssClass="textbox" ID="btnsave" runat="server" Text="ثبت" />

            <br /> --%>
 </div>
             
            <div  style="background-color:#f5f6f4; padding-right:10px; padding-left:10px;" class="col-xs-12 col-sm-6 col-md-6">
                                <center>
                                    <br />
                <div id="dvMap" style=" width:90%;  height:500px; ">    </div>


                </center>

                    </div> 
                           &nbsp;<br />&nbsp; 
                                <img alt="" width="100%" height="1px" style="   display: block;" src="TemplateWorld_files/lineb.png" />

            </div>
                        

</asp:Content>

