<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Ads.aspx.vb" Inherits="Ads" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="leaflet/leaflet.css" rel="stylesheet" />
     <script src="leaflet/leaflet.js"></script>
        <script src="Scripts/jquery-1.4.1.js" type="text/javascript">
    </script>
    

<%--         <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCGdnRIzHGuK_Yfye4VFuwurTxdlVh5xTA"></script>--%>
<%--    <script>
        function addBtn() {
            alert(document.getElementById("<%=txtTag.ClientID%>").value);
            var btn = document.createElement("BUTTON");
            var txt = document.getElementById("<%=txtTag.ClientID%>").value;
            var t = document.createTextNode(txt);
            btn.appendChild(t);
            document.getElementById("divTags").appendChild(btn);
        }
</script>--%>
    
    

  

    <style>

        #close{
    position: absolute;
    top: -80px;
    left: 5%;
    width: 30px;
    margin : 10px;
    z-index: 2;
    
}
        input[type="file"] {
  display: block;
}
.imageThumb {
  max-height: 100px;
  border: 2px solid;
  padding: 1px;
  cursor: pointer;
}
.pip {
  display: inline-block;
  margin: 10px 10px 0 0;
}
.remove1,.remove2,.remove3,.remove4,.remove5,.remove6,.remove7,.remove8,.remove9 {
  display: block;
  background: #444;
  border: 1px solid black;
  color: white;
  text-align: center;
  cursor: pointer;
}
.remove:hover {
  background: white;
  color: black;
}
 .img {
            float:left;margin:1%;
            width: 100px;
            height: 100px;
        }
        
    </style>
   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">

    <div  runat="server" id="divConfirm">
<center>
       <br />
        علت رد:
        <asp:TextBox ID="txtDel" Width="80%"  CssClass="textboxReq " runat="server"></asp:TextBox>
    <br /><br />
            <asp:Button  CssClass="MyBtn" BackColor="#1559af" ForeColor="White" ID="btnCancel2" runat="server" Text="رد شود" />

</center>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <br />
    <div class="container">
        <div id="divReport" runat="server"  visible="false" >
                <asp:Label ID="lblReport" runat="server" ForeColor="Red"    Text =""></asp:Label>
            <br />
            <br />
                                            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
        <br />
            </div>
        <asp:UpdatePanel  ID="upPanel1" runat="server" ><ContentTemplate >
            <div class="row">
    <div  class="col-xs-12 col-sm-1 col-md-1">
       دسته:<uc1:help runat="server" ID="help2" />
    </div>
  <%--              <asp:DropDownList ID="ddads" runat="server"></asp:DropDownList>                             
                <asp:DropDownList ID="ddadsType" runat="server"></asp:DropDownList>  --%>                           
                                         <asp:HiddenField ID="txtRootJobCode" runat="server"  />


    <div  class="col-xs-12 col-sm-2 col-md-2">
                <asp:DropDownList  AutoPostBack="true"  ID="ddjob" CssClass="textbox"  Width="100%" runat="server"></asp:DropDownList>
        
        <asp:LinkButton ID="btnUp" Visible="false"  CssClass="MyBtn " Width="100%" runat="server">برگشت</asp:LinkButton>
        </div> 
    <div  class="col-xs-12 col-sm-9 col-md-9">
                <div id="html"   runat="server" ></div>
        </div> 
            </div> 
</ContentTemplate></asp:UpdatePanel>
               <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
        <br />
        <br />
                 <div  id="divReg" style=" text-align:right; padding-right:10px; padding-left:10px;" class="col-xs-12 col-sm-7 col-md-7">
   
 <asp:UpdatePanel  ID="UpdatePanel4" runat="server" ><ContentTemplate >
<div class="row">
    
    <div  class="col-xs-12 col-sm-6 col-md-6">
          <asp:DropDownList  AutoPostBack="true"  ID="ddcity" CssClass="textbox"  Width="100%" runat="server">
             
          </asp:DropDownList>
    </div>
     <div  class="col-xs-12 col-sm-6 col-md-6">
           <asp:DropDownList  AutoPostBack="true"  ID="ddsector" CssClass="textbox"  Width="100%" runat="server">
               
           </asp:DropDownList>
    </div>
         
   <%-- فیلدهای تخصصی--%>
   
      <div  class="col-xs-12 col-sm-12 col-md-12">
           <br />
                <asp:UpdatePanel ID="upFields" UpdateMode="Conditional"  runat="server"><ContentTemplate>
                        <div id="divFields" runat="server" ></div>
            </ContentTemplate> </asp:UpdatePanel> 
           <br />
          </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        عنوان:<uc1:help runat="server" ID="help" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">
    <asp:TextBox ID="txtTitle" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div>
     <div  class="col-xs-12 col-sm-12 col-md-12">
         افزودن مشاور +
         </div>
     <div  class="col-xs-12 col-sm-12 col-md-12">
         قیمت کارشناسی این ملک:
         </div>
    </div> 
         </ContentTemplate></asp:UpdatePanel>
<div class="col-xs-12 col-sm-12 col-md-12">
    <div class="col-xs-4 col-sm-4 col-md-4" style="background-color: rgb(251, 192, 45);">بالا</div>
    <div class="col-xs-4 col-sm-4 col-md-4" style="background-color: rgb(124, 179, 66);">منصفانه</div>
    <div class="col-xs-4 col-sm-4 col-md-4" style="background-color: rgb(47, 127, 51);">پایین</div>
    </div>

  
   <div class="col-xs-12 col-sm-12 col-md-12">
       <input type="button" value="ایجاد متن (با ایجاد متن توضیحات دستی اضافه شده از بین خواهد رفت)" style="width:100%" /><br />
           <asp:TextBox ID="TextBox5" TextMode="MultiLine"  Height="80px" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>

       </div>
  
<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        ایمیل:<uc1:help runat="server" ID="help1" />
    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">
        <asp:TextBox ID="txtEmail" CssClass="textbox " TextMode="Email"  Width="100%" runat="server"></asp:TextBox>
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        موبایل:<uc1:help runat="server" ID="help3" />
    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">
        <asp:TextBox ID="txtMobile" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div>
    </div> 
<div class="row">

    <div  class="col-xs-12 col-sm-2 col-md-2">
        محل:<uc1:help runat="server" ID="help4" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">
        <asp:TextBox ID="txtCity" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">

    <div  class="col-xs-12 col-sm-2 col-md-2">
        قیمت:<uc1:help runat="server" ID="help7" />
    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">
       
        <asp:TextBox ID="txtPrice" CssClass="textboxReq price"  onkeyup = "javascript:this.value=Comma(this.value);"  Width="100%" runat="server"></asp:TextBox>

    </div>
    </div> 
   <div class="row">

    <div  class="col-xs-12 col-sm-2 col-md-2">
        نوع فروش:<uc1:help runat="server" ID="help8" />
    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">
        <asp:DropDownList  CssClass="textbox "  Width="100%" ID="ddPricetype" runat="server">
            <asp:ListItem Text="انتخاب شود" Value="0"></asp:ListItem>
            <asp:ListItem Text="توافقی" Value="1"></asp:ListItem>
            <asp:ListItem Text="جهت معاوضه" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        تلفن:<uc1:help runat="server" ID="help14" />
    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">
        <asp:TextBox ID="txtTel" CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
    </div>
</div>
        <div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        توضیحات:<uc1:help runat="server" ID="help9" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">

    <asp:TextBox ID="txtDesc" TextMode="MultiLine"  Height="80px" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
        </div> 
    </div>

        <div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
         لینک:<uc1:help runat="server" ID="help11" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">

    <asp:TextBox ID="txtSite" CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
        </div> 
            </div>
                      <div class="row">

    <div  class="col-xs-12 col-sm-2 col-md-2">
        تلگرام:<uc1:help runat="server" ID="help15" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">

    <asp:TextBox ID="txtTelegram" CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
        </div> 
    </div>
                                                  <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional"  runat="server"><ContentTemplate>

                      <div class="row">

    <div  class="col-xs-12 col-sm-2 col-md-2">
        کلیدواژه:<uc1:help runat="server" ID="help5" />
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">
    <asp:TextBox ID="txtTags" CssClass="textbox " style=" display:none; " runat="server"></asp:TextBox>
    <asp:TextBox ID="txtTag" CssClass="textbox " runat="server"></asp:TextBox><asp:ImageButton  style="vertical-align:middle " ImageUrl="~/img/check1.png" Height="24" Width="24"  ID="ibtnAddTag" runat="server" ImageAlign="Middle" />
        </div> 
    </div>
                      <div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        کلیدواژه ها:
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">

    <div id="divTags" runat="server"  class="row">

    </div> 
        </div> 
                          </div> 
                                                      </ContentTemplate> </asp:UpdatePanel> 
                     </div> 
                        <div  style=" padding-right:5px; padding-left:5px;" class="col-xs-12 col-sm-5 col-md-5">
                                <center>
                <div id="dvMap" style=" width:90%;  height:350px; ">    </div>
                                    <br />
                                    لطفا موقعیت جغرافیایی خود را از نقشه بالا انتخاب کنید.
                                    <br />
                                                <div class="col-xs-12 col-sm-12 col-md-12">
                <asp:TextBox ID="N"   Width="1px"  Height ="1px"  placeholder="مختصات" runat="server"></asp:TextBox><asp:TextBox ID="E"    Width="1px"  Height ="1px"   placeholder="مختصات" runat="server"></asp:TextBox>
</div> 



                </center>

                    </div> 

        <br />
                                    <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
<%--divFields--%>

<br />
       <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional"  runat="server"><ContentTemplate>
        <div class="row">
    <div  class="col-xs-12 col-sm-3 col-md-3" >
        بارگذاری عکس:<uc1:help runat="server" ID="help12" />
        <asp:FileUpload ID="files"  name="files[]" runat="server" AllowMultiple="true"   />
       
        <br />
        <div id="gallery">

        </div>
                <br />
                         <asp:TextBox ID="txtVideoCount" Text="0" Width="1px"  Height ="1px" runat="server"></asp:TextBox>
                         <asp:TextBox ID="txtPicCount" Text="0" Width="1px"  Height ="1px" runat="server"></asp:TextBox>
                         <asp:TextBox ID="txtPic" Width="1px"  Height ="1px"  runat="server"></asp:TextBox>
                         <asp:HiddenField ID="TextBox1" runat="server" Value="" />
                         <asp:HiddenField ID="TextBox2" runat="server" Value="" />
                         <asp:HiddenField ID="TextBox3" runat="server" Value="" />
                         <asp:HiddenField ID="TextBox4" runat="server" Value="" />

        
            
    </div>

    <div  class="col-xs-12 col-sm-9 col-md-9" >
        <div id="divPics" runat="server" >
        <div id="field" ></div>

        </div>
        </div> 
    </div>
            </ContentTemplate></asp:UpdatePanel>
        <br />
        <div id="divOldPics" runat="server" visible="false"   class="row">
                <div  class="col-xs-12 col-sm-3 col-md-3" >
                    عکسهای قبلی:
                    </div> 
                            <div  class="col-xs-12 col-sm-9 col-md-9" >
                                        <asp:UpdatePanel ID="UpdatePanel2"   runat="server"><ContentTemplate>
                                            
<div id="divPics4Edit" runat="server" ></div>
                                            </ContentTemplate> </asp:UpdatePanel> 
</div> 
            </div> 
        <div class="row">
                <div  class="col-xs-12 col-sm-3 col-md-3" >
        بارگذاری فیلم:<uc1:help runat="server" ID="help10" />
            </div> 
                <div  class="col-xs-12 col-sm-9 col-md-9" >

                    <asp:FileUpload ID="FilmUpload1"   runat="server" />
                                       <asp:CustomValidator ID="NewPasswordCustomValidator" runat="server"  
                 ForeColor="Red" 
                    Text="سایز فیلم از 15 مگابایت کمتر و در فرمتهای معمول باشد" ToolTip="FileSize should not exceed 3mb" 
                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files." 
                    ControlToValidate="FilmUpload1"  
                   ClientValidationFunction = "ValidateFilmSize" />

                    </div> 
        </div>
        <br />
                                    <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
<br />
<div class="row">
    <div  class="col-xs-12 col-sm-3 col-md-2">
        <asp:CheckBox ID="chkEmail" Text="نمایش ایمیل" runat="server" />
    </div>

    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="chkNew" Text="نو" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="chkFori" Text="فوری" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="chkNardban" Text="نردبان" runat="server" />

    </div>
</div>
<div id="divOnly4Insert" runat="server"  class="row">
    <div  class="col-xs-12 col-sm-12 col-md-4" style="font-weight:bold ; font-size:large ">
        <asp:CheckBox ID="chklaws" runat="server" /> <a href="Show.aspx?FN=Law" target="_blank" style="color:#9931cc"  >قوانین سایت</a> را مطالعه کردم و قبول دارم.
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-1">
        کد تائید:<uc1:help runat="server" ID="help13" />
        </div> 
    <div  class="col-xs-12 col-sm-3 col-md-2">
            <asp:TextBox ID="txtCaptcha" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
</div> 
    <div  class="col-xs-8 col-sm-1 col-md-1">
<img  src="Captcha.aspx" />

</div> 
        <div  class="col-xs-4 col-sm-1 col-md-1">
        <asp:ImageButton Width="30" ID="ImageButton1" ImageUrl="~/img/Refresh.png" runat="server" />
        </div> 
</div> 
        <center>
            <br /><br />

            <asp:Button ID="btnSave" CssClass="MyBtn" runat="server" Text="ثبت "></asp:Button>
            <asp:Button ID="btnCancel"  CssClass="MyBtn"  Visible="false"   runat="server" Text="رد"></asp:Button>
            <asp:Button ID="btnVizheh" Visible="false"   CssClass="MyBtn"  runat="server" Text="خدمات ویژه"></asp:Button>
            <asp:Button ID="btnFrokhtehShod" Visible="false"   CssClass="MyBtn"  runat="server" Text="فروخته شد"></asp:Button>
            <asp:Button ID="btnTamdid" Visible="false"   CssClass="MyBtn"  runat="server" Text="تمدید"></asp:Button>
            <br />
            </center>
    </div>
    <script>
        function Comma(num) {
            //var commas = num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");         
            return (num.toString().replaceAll(",",'').replace(/\B(?=(\d{3})+(?!\d))/g, ","));
        }     
    </script>
    <link rel="stylesheet" href="https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.css" />
<script src="https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.js"></script>
    <style>
        .leaflet-control-geocoder a {
	background-position: 50% 50%;
	background-repeat: no-repeat;
	display: block;
}

.leaflet-control-geocoder {
	box-shadow: 0 1px 7px #999;
	background: #f8f8f9;
	-moz-border-radius: 8px;
	-webkit-border-radius: 8px;
	border-radius: 8px;
}

.leaflet-control-geocoder a {
	background-image: url(images/geocoder.png);
	width: 36px;
	height: 36px;
}

.leaflet-touch .leaflet-control-geocoder a {
	width: 44px;
	height: 44px;
}

.leaflet-control-geocoder .leaflet-control-geocoder-form,
.leaflet-control-geocoder-expanded .leaflet-control-geocoder-toggle {
	display: none;
}

.leaflet-control-geocoder-expanded .leaflet-control-geocoder-form {
	display: block;
	position: relative;
}

.leaflet-control-geocoder-expanded .leaflet-control-geocoder-form {
	padding: 5px;
}
    </style>
   <script>
       if (typeof console == "undefined") {
           this.console = { log: function (msg) { /* do nothing since it would otherwise break IE */ } };
       }


       L.Control.OSMGeocoder = L.Control.extend({
           options: {
               collapsed: true,
               position: 'topright',
               text: 'Locate',
               placeholder: '',
               bounds: null, // L.LatLngBounds
               email: null, // String
               callback: function (results) {
                   if (results.length == 0) {
                       console.log("ERROR: didn't find a result");
                       return;
                   }
                   var bbox = results[0].boundingbox,
                       first = new L.LatLng(bbox[0], bbox[2]),
                       second = new L.LatLng(bbox[1], bbox[3]),
                       bounds = new L.LatLngBounds([first, second]);
                   this._map.fitBounds(bounds);
               }
           },

           _callbackId: 0,

           initialize: function (options) {
               L.Util.setOptions(this, options);
           },

           onAdd: function (map) {
               this._map = map;

               var className = 'leaflet-control-geocoder',
                   container = this._container = L.DomUtil.create('div', className);

               L.DomEvent.disableClickPropagation(container);

               var form = this._form = L.DomUtil.create('form', className + '-form');

               var input = this._input = document.createElement('input');
               input.type = "text";
               input.placeholder = this.options.placeholder || '';

               var submit = document.createElement('input');
               submit.type = "submit";
               submit.value = this.options.text;

               form.appendChild(input);
               form.appendChild(submit);

               L.DomEvent.addListener(form, 'submit', this._geocode, this);

               if (this.options.collapsed) {
                   L.DomEvent.addListener(container, 'mouseover', this._expand, this);
                   L.DomEvent.addListener(container, 'mouseout', this._collapse, this);

                   var link = this._layersLink = L.DomUtil.create('a', className + '-toggle', container);
                   link.href = '#';
                   link.title = 'Nominatim Geocoder';

                   L.DomEvent.addListener(link, L.Browser.touch ? 'click' : 'focus', this._expand, this);

                   this._map.on('movestart', this._collapse, this);
               } else {
                   this._expand();
               }

               container.appendChild(form);

               return container;
           },

           /* helper functions for cordinate extraction */
           _createSearchResult: function (lat, lon) {
               //creates an position description similar to the result of a Nominatim search
               var diff = 0.005;
               var result = [];
               result[0] = {};
               result[0]["boundingbox"] = [parseFloat(lat) - diff, parseFloat(lat) + diff, parseFloat(lon) - diff, parseFloat(lon) + diff];
               result[0]["class"] = "boundary";
               result[0]["display_name"] = "Position: " + lat + " " + lon;
               result[0]["lat"] = lat;
               result[0]["lon"] = lon;
               return result;
           },
           _isLatLon: function (q) {
               //"lon lat" => xx.xxx x.xxxxx
               var re = /(-?\d+\.\d+)\s(-?\d+\.\d+)/;
               var m = re.exec(q);
               if (m != undefined) return m;

               //lat...xx.xxx...lon...x.xxxxx
               re = /lat\D*(-?\d+\.\d+)\D*lon\D*(-?\d+\.\d+)/;
               m = re.exec(q);
               //showRegExpResult(m);
               if (m != undefined) return m;
               else return null;
           },
           _isLatLon_decMin: function (q) {
               console.log("is LatLon?: " + q);
               //N 53° 13.785' E 010° 23.887'
               //re = /[NS]\s*(\d+)\D*(\d+\.\d+).?\s*[EW]\s*(\d+)\D*(\d+\.\d+)\D*/;
               re = /([ns])\s*(\d+)\D*(\d+\.\d+).?\s*([ew])\s*(\d+)\D*(\d+\.\d+)/i;
               m = re.exec(q.toLowerCase());
               //showRegExpResult(m);
               if ((m != undefined)) return m;
               else return null;
               // +- dec min +- dec min
           },

           _geocode: function (event) {
               L.DomEvent.preventDefault(event);
               var q = this._input.value;
               //try to find corrdinates
               if (this._isLatLon(q) != null) {
                   var m = this._isLatLon(q);
                   console.log("LatLon: " + m[1] + " " + m[2]);
                   //m = {lon, lat}
                   this.options.callback.call(this, this._createSearchResult(m[1], m[2]));
                   return;
               }
               else if (this._isLatLon_decMin(q) != null) {
                   var m = this._isLatLon_decMin(q);
                   //m: [ns, lat dec, lat min, ew, lon dec, lon min]
                   var temp = new Array();
                   temp['n'] = 1;
                   temp['s'] = -1;
                   temp['e'] = 1;
                   temp['w'] = -1;
                   this.options.callback.call(this, this._createSearchResult(
                       temp[m[1]] * (Number(m[2]) + m[3] / 60),
                       temp[m[4]] * (Number(m[5]) + m[6] / 60)
                   ));
                   return;
               }

               //and now Nominatim
               //http://wiki.openstreetmap.org/wiki/Nominatim
               console.log(this._callbackId);
               window[("_l_osmgeocoder_" + this._callbackId)] = L.Util.bind(this.options.callback, this);


               /* Set up params to send to Nominatim */
               var params = {
                   // Defaults
                   q: this._input.value,
                   json_callback: ("_l_osmgeocoder_" + this._callbackId++),
                   format: 'json'
               };

               if (this.options.bounds && this.options.bounds != null) {
                   if (this.options.bounds instanceof L.LatLngBounds) {
                       params.viewbox = this.options.bounds.toBBoxString();
                       params.bounded = 1;
                   }
                   else {
                       console.log('bounds must be of type L.LatLngBounds');
                       return;
                   }
               }

               if (this.options.email && this.options.email != null) {
                   if (typeof this.options.email == 'string') {
                       params.email = this.options.email;
                   }
                   else {
                       console.log('email must be a string');
                   }
               }

               var protocol = location.protocol;
               if (protocol == "file:") protocol = "https:";
               var url = protocol + "//nominatim.openstreetmap.org/search" + L.Util.getParamString(params),
                   script = document.createElement("script");




               script.type = "text/javascript";
               script.src = url;
               script.id = this._callbackId;
               document.getElementsByTagName("head")[0].appendChild(script);
           },

           _expand: function () {
               L.DomUtil.addClass(this._container, 'leaflet-control-geocoder-expanded');
           },

           _collapse: function () {
               this._container.className = this._container.className.replace(' leaflet-control-geocoder-expanded', '');
           }
       });
   </script>
    <script>
        // Initialize the map
        const map = L.map('dvMap')
        var marker;
        // Get the tile layer from OpenStreetMaps
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {

            // Specify the maximum zoom of the map
            maxZoom: 19,

            // Set the attribution for OpenStreetMaps
            attribution: '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
        var osmGeocoder = new L.Control.OSMGeocoder();

        map.addControl(osmGeocoder);
       // L.Control.geocoder().addTo(map);
        // Set the view of the map
        // with the latitude, longitude and the zoom value
        map.setView([38.0839, 46.3041], 13);
        map.on('click', function (e) {
            if (marker) { // check
                map.removeLayer(marker); // remove
            }
            //map.removeLayer(marker);
            marker = new L.Marker([e.latlng.lat, e.latlng.lng], { draggable: true });
            marker.bindPopup("<strong>مکان من</strong>").addTo(map);
            //var marker = L.marker(
            //    pos,{ draggable: true}
            //);
            marker.on('drag', function (e) {
                //marker = new L.Marker([e.latlng.lat, e.latlng.lng], { draggable: true });
                //marker.bindPopup("<strong>مکان من</strong>").addTo(map);
                var x = e.latlng.lat; var y = e.latlng.lng;
                document.getElementById("ContentPlaceHolder1_N").value = x; document.getElementById("ContentPlaceHolder1_E").value = y;
            });
           // marker.on('dragend', markerDrag);
            //marker.on('drag', function (e) {
            //    //marker = new L.Marker([e.latlng.lat, e.latlng.lng], { draggable: true });
            //    //marker.bindPopup("<strong>مکان من</strong>").addTo(map);
            //   // document.getElementById("ContentPlaceHolder1_N").value = x; document.getElementById("ContentPlaceHolder1_E").value = y;
            //});
            //map.eachLayer(function (e) {
            //    map.removeLayer(e);
            //});
            //alert("Lat, Lon : " + e.latlng.lat + ", " + e.latlng.lng);
            var x = e.latlng.lat; var y = e.latlng.lng;
           // let eiffelMarker = L.marker([e.latlng.lat, e.latlng.lng]).addTo(map);

            // Bind popup to the marker with a popup
          //  eiffelMarker.bindPopup("خانه ما").openPopup();
            document.getElementById("ContentPlaceHolder1_N").value = x; document.getElementById("ContentPlaceHolder1_E").value = y;
        });
        // Set the map view to the user's location
        // Uncomment below to set map according to user location
        // map.locate({setView: true, maxZoom: 16});

        // Show a market at the position of the Eiffel Tower
        $('#ContentPlaceHolder1_ddcity').change(function () {
           // alert($(this).attr("data-latitude"));
        })
        //ContentPlaceHolder1_ddcity
        $('#ContentPlaceHolder1_ddsector').on('change', function () {
            //alert($("#ContentPlaceHolder1_ddcity option:selected").text());
            gotoarea($("#ContentPlaceHolder1_ddcity option:selected").text(), $("#ContentPlaceHolder1_ddsector option:selected").text());
           // $('.leaflet-control-geocoder.leaflet-bar.leaflet-control').trigger("click");
           // $("#ContentPlaceHolder1_ddcity option:selected").text();
        });
    </script>
    <script>
        var count = 0;
        document.addEventListener('change', function (e) {
            var ele = e.target;
            if ($(e.target).is('input[type="file"]')) {
                var files = e.target.files;
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (file.type.match('image')) {
                        var picreader = new FileReader();
                        picreader.addEventListener("load", function (event) {
                            var picture = event.target; 
                            showPreview(picture.result, ele);
                        });
                        picreader.readAsDataURL(file);
                    }
                }
            } else {
                console.log('not file');
            }
        }, true);
        var count = 1;

        function showPreview(pic, ele) {
            $('#gallery').append('<img class="img" src="' + pic +'" />');

            //ele.previousElementSibling.src = pic;
            //ele.setAttribute('style', 'display:none;');
            //ele.nextElementSibling.setAttribute('style', 'display:block;');
            //ele.closest('li').classList.remove('add');
            //if ($('.uploadBtn').length < 5) {
               // $('#gallery').append(' <li class="uploadBtn add"><img class="img" src><input type="file"><a href="javascript:void(0);" class="removePic">X</a></li>');
                count = 1;
            //} else {
            //    return false;
            //}
        }
        //$('body').on('click', '.removePic', function () {
        //    $(this).parents('.uploadBtn').remove();
        //    if ($('.uploadBtn.add').length) {
        //        return false;
        //    } else {
        //        $('.gallery').append(' <li class="uploadBtn add"><img class="img" src><input type="file"><a href="javascript:void(0);" class="removePic">X</a></li>');
        //    }

        //});
    </script>
    <script>
        function bindmarker(x, y) {
           // alert(x + ' ' + y);
            // Initialize the map
           

            // Set the view of the map
            // with the latitude, longitude and the zoom value
            map.setView([38.0839, 46.3041], 13);
            marker = new L.Marker([x.replace('/', '.'), y.replace('/', '.')], { draggable: true });
            marker.bindPopup("<strong>مکان من</strong>").addTo(map);
            //var marker = L.marker(
            //    pos,{ draggable: true}
            //);
            marker.on('drag', function (e) {
                //marker = new L.Marker([e.latlng.lat, e.latlng.lng], { draggable: true });
                //marker.bindPopup("<strong>مکان من</strong>").addTo(map);
                var x = e.latlng.lat; var y = e.latlng.lng;
                document.getElementById("ContentPlaceHolder1_N").value = x; document.getElementById("ContentPlaceHolder1_E").value = y;
            });
        }
        function gotocity(city) {
           
           // alert(city); leaflet-control-geocoder-expanded    leaflet-control-geocoder-toggle
           // $('.leaflet-control-geocoder-icon').parent('div').addClass("leaflet-control-geocoder-expanded");
            $('.leaflet-control-geocoder-toggle').parent('div').addClass("leaflet-control-geocoder-expanded");
          //  $('.leaflet-control-geocoder-icon').click();
            $('.leaflet-control-geocoder-form').find('input[type="text"]').val(city);
            //$('.leaflet-control-geocoder-form').find('input[type="text"]').trigger(
            //    jQuery.Event('keypress', { keyCode: 13 })
            //);
           // $('ul.leaflet-control-geocoder-alternatives li a:first').click();
                
            var e = jQuery.Event("keydown");
            e.which = 13
            e.keyCode = 13
           
            //$('.leaflet-control-geocoder-form').find('input[type="text"]').focus();
            //$('.leaflet-control-geocoder-form').find('input[type="text"]').trigger("select");
            //$('.leaflet-control-geocoder-form').find('input[type="text"]').trigger(e);
            $(":submit[value='Locate']").click();
        }
        function gotoarea(city,area) {
          
            $('.leaflet-control-geocoder-toggle').parent('div').addClass("leaflet-control-geocoder-expanded");
            //  $('.leaflet-control-geocoder-icon').click();
            $('.leaflet-control-geocoder-form').find('input[type="text"]').val(city+','+' '+area);
          

            $(":submit[value='Locate']").click();
        }
    </script>
</asp:Content>

