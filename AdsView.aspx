<%@ Page  Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AdsView.aspx.vb" Inherits="Agahi" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
<meta property="og:title" content="<%=dr.Item("title")%>" />
<meta property="og:site_name" content="https://kichipoo.com"/>
<meta property="og:description" content="<%= dr.Item("description")%>" />
<meta property="og:url"  content="https://kichipoo.com/<%= dr.Item("prjid").ToString%>/<%= General.GetStandardLink(dr.Item("title").ToString())%>" />
<meta property="og:image" content="/UserFiles/<%= dr.Item("prjid").ToString%>/1.png" />
<meta property="og:type" content="website">
<meta property="og:image:width" content="1200">
<meta property="og:image:height" content="630">
<meta property="og:image:type" content="image/png" />

<meta name="twitter:image" content="https://kichipoo.com/UserFiles/<%= dr.Item("prjid").ToString%>/1.png" />
<meta name="twitter:card" content="photo">
<meta name="twitter:site" content="@kichio">
<meta name="twitter:creator" content="@kichio">
<meta name="twitter:url" content="https://kichipoo.com/<%= dr.Item("prjid").ToString%>/<%= General.GetStandardLink(dr.Item("title").ToString())%>" />
<meta name="twitter:title" content="<%=dr.item("title")%>" />
<meta name="twitter:description" content="<%=dr.item("description")%>" />
        <meta name="keywords" content="<%=dr.Item("tags")%>" />

    <meta name="description" content="<%=dr.Item("description")%>" />
    <title ><%=dr.item("title")%></title>
        <script src="Scripts/jquery-1.4.1.js" type="text/javascript">
    </script>
         <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCGdnRIzHGuK_Yfye4VFuwurTxdlVh5xTA"></script>
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
                var oldmarker = new google.maps.Marker({ position: newPosition, label: 'محل فروشگاه', map: map });

            }



        }
    </script>

    	<link rel="stylesheet" type="text/css" href="/style3.css">
  <link rel="stylesheet" type="text/css" href="/sliderengine/amazingslider-1.css">


</asp:Content>

<asp:Content runat="server"  ID="cnt" ContentPlaceHolderID="cntTop" >


</asp:Content>

<asp:Content runat="server"  ID="Content3" ContentPlaceHolderID="msgBoxContent" >
        <div  runat="server" id="divConfirm" visible="false" >
<center>

    <br /><br />
            <asp:Button  CssClass="MyBtn " ID="btnDel2" runat="server" Text="حذف شود" />

</center>
            </div> 
    <div id="divReport" runat="server" style="width:100%" visible="false" >
        ایراد :
        <asp:DropDownList ID="ddReport" CssClass="textbox " runat="server">
            <asp:ListItem>انتخاب نمائید</asp:ListItem>
            <asp:ListItem>ایراد در متن</asp:ListItem>
            <asp:ListItem>ایراد در تصویر</asp:ListItem>
            
        </asp:DropDownList>
        <br /><br />
        <asp:TextBox ID="txtReport" CssClass="textbox " runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
        <br /><br />
        <center>
        <asp:Button ID="btnReportReson" CssClass="MyBtn" runat="server" Text="ثبت گزارش" />
            </center>
    </div>

        <div id="divMsg4Ader" runat="server" style="width:100%" visible="false" >
        نام و نام خانوادگی:<br />
        <asp:TextBox ID="txtMsgName" CssClass="textbox " runat="server"  Width="100%" ></asp:TextBox><br />
            ایمیل:<br />
        <asp:TextBox ID="txtMsgEmail" CssClass="textbox " runat="server" TextMode="Email"  Width="100%" ></asp:TextBox><br />
            آدرس:<br />
        <asp:TextBox ID="txtMsgAddress" CssClass="textbox " runat="server" Width="100%" ></asp:TextBox><br />
            شماره تماس:<br />
        <asp:TextBox ID="txtMsgTel" CssClass="textbox " runat="server"   TextMode="Phone"  Width="100%" ></asp:TextBox><br />
            متن پیغام به صاحب فروشگاه:
        <br />
        <asp:TextBox ID="TxtMsgText" CssClass="textbox " runat="server" TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
        <br /><br />
        <center>

        <asp:Button ID="btnSendMsg" CssClass="MyBtn" runat="server" Text="ارسال" />
            </center>
    </div>


</asp:Content>
<asp:Content ID="Content2" ContentplaceholderID="Contentplaceholder1" Runat="Server">


      <div class="row"  itemscope itemtype="http://schema.org/Article"   itemref="publisher-1" >
      <div class="col-md-5 col-xs-12 rightt"  onclick="document.getElementById('Neshan').style.display = 'none';document.getElementById('setare').style.display = 'none';document.getElementById('shabake').style.display = 'none'" >
        <div class="upright"   >
            <div itemprop="name headline" >
            <i class="fa fa-minus minus" aria-hidden="true">
            </i>
            <h5 class="top" style=" font-size:large; font-weight:bold  " ><a href="#"><%=dr.Item("title").ToString%></a></h5>
        </div>
                  <div class="row">

            <div class="col-md-10 col-xs-10 ">
</div>                 
                      <div class="col-md-2 col-xs-2 ">
                </div> 

          </div> 

        <div class="fclock">
            <i class="fa fa-clock-o clock" aria-hidden="true"></i>
            <span ><a href="#"><%=General.GetDateSpan(dr.Item("insertDate").ToString())%></a> </span>
                        <span itemprop="datePublished" style="font-size:xx-small "><%=dr.Item("insertDate").ToString() %></span>

        </div>
        
        <div class="line">
            <div >
                <i class="fa fa-minus minus" aria-hidden="true">
                </i>
                <h5 class="h53" ><a href="#">قیمت به تومان: </a>   </h5>
                <span class="titre3"><%=dr.Item("PriceText").ToString%> </span>
                <span class="titre3"><%=GetSectorName(dr.Item("SectorCode").ToString)%> </span>

            </div>
        </div>

     <div class="froosh"  style="padding-right:20px;  font-size:large ">
                <br />توضیحات:   <span itemprop="articleBody">  <%=dr.Item("description").ToString%></span> 
                  <br /><div id="divFields" runat="server" ></div>

                <br />تعداد بازدید:   <%=dr.Item("viewCount").ToString%>
                    <span id="spnData" runat="server" ></span>
                    <br />
                    &nbsp;
            
                  <div id="divTags" runat="server" ></div>

           </div> 

         </div>
        <div class="bottomright">

         
      <i class="fa fa-info-circle" aria-hidden="true" "></i>
    <span >  ضمانت برگشت پول در صورت نارضایتی.</span> 

     <div class="row"  onclick="document.getElementById('Neshan').style.display = 'none';document.getElementById('setare').style.display = 'none';document.getElementById('shabake').style.display = 'none'" >
     <div class="col-md-12" style=" padding:0; margin:0;">
     <div class="col-md-3"></div>
     <div class="col-md-9">
       <ul class="ui">
                               <asp:LinkButton ID="lbtnMsg" runat="server">پیغام به فروشگاه</asp:LinkButton> |
                               <asp:LinkButton ID="lbtnReport" runat="server">گزارش خطا</asp:LinkButton> |
                               <asp:LinkButton ID="lbtnBazdid" runat="server">گزارش بازدید</asp:LinkButton> 

       </ul>
      
     
     
     </div>
     </div>
     </div>

        </div>
        
      </div>
      <div class="col-md-1 col-xs-12 centter" >
        
           
          
             <div   onclick="document.getElementById('Neshan').style.display = 'none';document.getElementById('setare').style.display = 'inline-block';document.getElementById('shabake').style.display = 'none'"   >

               <a class="starr">
               <i class="fa fa-star-half-o" aria-hidden="true" ></i>
               </a>

			
           </div>
             
             <div id="setare"   >
               <ajax:Rating id="rates"   runat="server"     StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"></ajax:Rating>

             </div>

             <!-- star -->

      <div   onclick="document.getElementById('Neshan').style.display = 'none';document.getElementById('setare').style.display = 'none';document.getElementById('shabake').style.display = 'inline-block'"   >
            <a href="#" id="shair" class="shair" >
              <i class="fa fa-share-alt" aria-hidden="true"></i>
            </a> 
             <!-- shabake -->
   </div>
       <div id="shabake">
           <a target="_blank"  href="https://telegram.me/share/url?url=https://kichipoo.com/<%= dr.Item("prjid").ToString()%>/<%=General.GetStandardLink(dr.Item("title").ToString())%>&text=<%= dr.Item("title")%>"><img src="/img/tel.png" width="30" height="30" /></a>
           <a target="_blank"  href="http://www.facebook.com/sharer.php?u==https://kichipoo.com/<%= dr.Item("prjid").ToString()%>/<%=General.GetStandardLink(dr.Item("title").ToString())%>&text=<%= dr.Item("title")%>"><img src="/img/facebook.png" width="30" height="30" /></a>
           <a target="_blank"  href="https://www.linkedin.com/shareArticle?mini=true&url=https://kichipoo.com/<%= dr.Item("prjid").ToString()%>/<%=General.GetStandardLink(dr.Item("title").ToString())%>&title=<%= dr.Item("title")%>&summary=<%= dr.Item("title")%>&source=https://kichipoo.com"><img src="/img/linkedin.png" width="30" height="30" /></a>
            
     </div>

      
          <div   onclick="document.getElementById('setare').style.display = 'none';document.getElementById('shabake').style.display = 'none';document.getElementById('Neshan').style.display = 'inline-block'"   >
            <a href="#"  class="flag" >
              <i class="<%= getEmptyOrFill(dr.Item("prjid").ToString())%>" aria-hidden="true"></i>
            </a> 
             <!-- shabake -->
   </div>
       <div id="Neshan">
          <asp:LinkButton ID="lbtnNeshan" ForeColor="#843fb8"  runat="server">نشان کردن</asp:LinkButton>
      <%--<i class="" aria-hidden="true"></i>--%>
     </div>




          
      </div>
      <div class="col-md-6 col-xs-12  leftt"  onclick="document.getElementById('Neshan').style.display = 'none';document.getElementById('setare').style.display = 'none';document.getElementById('shabake').style.display = 'none'" >
            <div class="upleft" >




<!-- #region Jssor Slider Begin -->
<!-- Generator: Jssor Slider Maker -->
<!-- Source: https://www.jssor.com -->
<!-- This is deep minimized code which works independently. -->
<script type="text/javascript">
    (function (g, j, c, f, e, k, i) {/*! Jssor */
        new (function () { }); var d = { l: function (a) { return a }, Ye: function (a) { return -a * (a - 2) }, n: function (a) { return a * a * a }, Uc: function (a) { return (a -= 1) * a * a + 1 } }; var b = new function () { var h = this, zb = /\S+/g, H = 1, bb = 2, eb = 3, db = 4, hb = 5, I, s = 0, l = 0, t = 0, Z = 0, B = 0, K = navigator, mb = K.appName, o = K.userAgent, p = parseFloat; function Ib() { if (!I) { I = { vf: "ontouchstart" in g || "createTouch" in j }; var a; if (K.pointerEnabled || (a = K.msPointerEnabled)) I.wd = a ? "msTouchAction" : "touchAction" } return I } function w(h) { if (!s) { s = -1; if (mb == "Microsoft Internet Explorer" && !!g.attachEvent && !!g.ActiveXObject) { var e = o.indexOf("MSIE"); s = H; t = p(o.substring(e + 5, o.indexOf(";", e)));/*@cc_on Z=@_jscript_version@*/; l = j.documentMode || t } else if (mb == "Netscape" && !!g.addEventListener) { var d = o.indexOf("Firefox"), b = o.indexOf("Safari"), f = o.indexOf("Chrome"), c = o.indexOf("AppleWebKit"); if (d >= 0) { s = bb; l = p(o.substring(d + 8)) } else if (b >= 0) { var i = o.substring(0, b).lastIndexOf("/"); s = f >= 0 ? db : eb; l = p(o.substring(i + 1, b)) } else { var a = /Trident\/.*rv:([0-9]{1,}[\.0-9]{0,})/i.exec(o); if (a) { s = H; l = t = p(a[1]) } } if (c >= 0) B = p(o.substring(c + 12)) } else { var a = /(opera)(?:.*version|)[ \/]([\w.]+)/i.exec(o); if (a) { s = hb; l = p(a[2]) } } } return h == s } function q() { return w(H) } function xb() { return q() && (l < 6 || j.compatMode == "BackCompat") } function Ab() { return w(bb) } function cb() { return w(eb) } function gb() { return w(hb) } function tb() { return cb() && B > 534 && B < 535 } function L() { w(); return B > 537 || l > 42 || s == H && l >= 11 } function vb() { return q() && l < 9 } function ub(a) { var b, c; return function (f) { if (!b) { b = e; var d = a.substr(0, 1).toUpperCase() + a.substr(1); n([a].concat(["WebKit", "ms", "Moz", "O", "webkit"]), function (g, e) { var b = a; if (e) b = g + d; if (f.style[b] != i) return c = b }) } return c } } function sb(b) { var a; return function (c) { a = a || ub(b)(c) || b; return a } } var M = sb("transform"); function lb(a) { return {}.toString.call(a) } var ib = {}; n(["Boolean", "Number", "String", "Function", "Array", "Date", "RegExp", "Object"], function (a) { ib["[object " + a + "]"] = a.toLowerCase() }); function n(b, d) { var a, c; if (lb(b) == "[object Array]") { for (a = 0; a < b.length; a++) if (c = d(b[a], a, b)) return c } else for (a in b) if (c = d(b[a], a, b)) return c } function E(a) { return a == f ? String(a) : ib[lb(a)] || "object" } function jb(a) { for (var b in a) return e } function C(a) { try { return E(a) == "object" && !a.nodeType && a != a.window && (!a.constructor || {}.hasOwnProperty.call(a.constructor.prototype, "isPrototypeOf")) } catch (b) { } } function v(a, b) { return { x: a, y: b } } function pb(b, a) { setTimeout(b, a || 0) } function J(b, d, c) { var a = !b || b == "inherit" ? "" : b; n(d, function (c) { var b = c.exec(a); if (b) { var d = a.substr(0, b.index), e = a.substr(b.index + b[0].length + 1, a.length - 1); a = d + e } }); a && (c += (!a.indexOf(" ") ? "" : " ") + a); return c } function rb(b, a) { if (l < 9) b.style.filter = a } function Hb(a, b) { if (a === i) a = b; return a } h.lf = Ib; h.kd = q; h.Nf = xb; h.Jf = Ab; h.Kf = cb; h.Mf = L; ub("transform"); h.zd = function () { return l }; h.Ad = function () { return t || l }; h.Of = function () { w(); return B }; h.W = pb; h.Pf = function (a, b) { b.call(a); return D({}, a) }; function W(a) { a.constructor === W.caller && a.bc && a.bc.apply(a, W.caller.arguments) } h.bc = W; h.Db = function (a) { if (h.Qf(a)) a = j.getElementById(a); return a }; function u(a) { return a || g.event } h.Ic = function (b) { b = u(b); var a = b.target || b.srcElement || j; if (a.nodeType == 3) a = h.Nc(a); return a }; h.nd = function (a) { a = u(a); return { x: a.pageX || a.clientX || 0, y: a.pageY || a.clientY || 0 } }; function x(c, d, a) { if (a !== i) c.style[d] = a == i ? "" : a; else { var b = c.currentStyle || c.style; a = b[d]; if (a == "" && g.getComputedStyle) { b = c.ownerDocument.defaultView.getComputedStyle(c, f); b && (a = b.getPropertyValue(d) || b[d]) } return a } } function Y(b, c, a, d) { if (a === i) { a = p(x(b, c)); isNaN(a) && (a = f); return a } if (a == f) a = ""; else d && (a += "px"); x(b, c, a) } function m(c, a) { var d = a ? Y : x, b; if (a & 4) b = sb(c); return function (e, f) { return d(e, b ? b(e) : c, f, a & 2) } } function Cb(b) { if (q() && t < 9) { var a = /opacity=([^)]*)/.exec(b.style.filter || ""); return a ? p(a[1]) / 100 : 1 } else return p(b.style.opacity || "1") } function Eb(b, a, f) { if (q() && t < 9) { var h = b.style.filter || "", i = new RegExp(/[\s]*alpha\([^\)]*\)/g), e = c.round(100 * a), d = ""; if (e < 100 || f) d = "alpha(opacity=" + e + ") "; var g = J(h, [i], d); rb(b, g) } else b.style.opacity = a == 1 ? "" : c.round(a * 100) / 100 } var N = { P: ["rotate"], pb: ["rotateX"], ib: ["rotateY"], Wb: ["skewX"], Xb: ["skewY"] }; if (!L()) N = D(N, { J: ["scaleX", 2], I: ["scaleY", 2], gb: ["translateZ", 1] }); function O(d, a) { var c = ""; if (a) { if (q() && l && l < 10) { delete a.pb; delete a.ib; delete a.gb } b.j(a, function (d, b) { var a = N[b]; if (a) { var e = a[1] || 0; if (P[b] != d) c += " " + a[0] + "(" + d + (["deg", "px", ""])[e] + ")" } }); if (L()) { if (a.tb || a.ub || a.gb != i) c += " translate3d(" + (a.tb || 0) + "px," + (a.ub || 0) + "px," + (a.gb || 0) + "px)"; if (a.J == i) a.J = 1; if (a.I == i) a.I = 1; if (a.J != 1 || a.I != 1) c += " scale3d(" + a.J + ", " + a.I + ", 1)" } } d.style[M(d)] = c } h.If = m("transformOrigin", 4); h.Ff = m("backfaceVisibility", 4); h.Ef = m("transformStyle", 4); h.mf = m("perspective", 6); h.nf = m("perspectiveOrigin", 4); h.of = function (b, a) { if (q() && t < 9 || t < 10 && xb()) b.style.zoom = a == 1 ? "" : a; else { var c = M(b), f = a == 1 ? "" : "scale(" + a + ")", e = b.style[c], g = new RegExp(/[\s]*scale\(.*?\)/g), d = J(e, [g], f); b.style[c] = d } }; h.i = function (a, d, b, c) { a = h.Db(a); if (a.addEventListener) { d == "mousewheel" && a.addEventListener("DOMMouseScroll", b, c); a.addEventListener(d, b, c) } else if (a.attachEvent) { a.attachEvent("on" + d, b); c && a.setCapture && a.setCapture() } }; h.V = function (a, c, d, b) { a = h.Db(a); if (a.removeEventListener) { c == "mousewheel" && a.removeEventListener("DOMMouseScroll", d, b); a.removeEventListener(c, d, b) } else if (a.detachEvent) { a.detachEvent("on" + c, d); b && a.releaseCapture && a.releaseCapture() } }; h.Qb = function (a) { a = u(a); a.preventDefault && a.preventDefault(); a.cancel = e; a.returnValue = k }; h.qf = function (a) { a = u(a); a.stopPropagation && a.stopPropagation(); a.cancelBubble = e }; h.bb = function (d, c) { var a = [].slice.call(arguments, 2), b = function () { var b = a.concat([].slice.call(arguments, 0)); return c.apply(d, b) }; return b }; h.Rb = function (d, c) { for (var b = [], a = d.firstChild; a; a = a.nextSibling) (c || a.nodeType == 1) && b.push(a); return b }; function kb(a, c, e, b) { b = b || "u"; for (a = a ? a.firstChild : f; a; a = a.nextSibling) if (a.nodeType == 1) { if (U(a, b) == c) return a; if (!e) { var d = kb(a, c, e, b); if (d) return d } } } h.Sb = kb; function T(a, d, g, b) { b = b || "u"; var c = []; for (a = a ? a.firstChild : f; a; a = a.nextSibling) if (a.nodeType == 1) { U(a, b) == d && c.push(a); if (!g) { var e = T(a, d, g, b); if (e.length) c = c.concat(e) } } return c } function fb(a, c, d) { for (a = a ? a.firstChild : f; a; a = a.nextSibling) if (a.nodeType == 1) { if (a.tagName == c) return a; if (!d) { var b = fb(a, c, d); if (b) return b } } } h.wf = fb; h.xf = function (b, a) { return b.getElementsByTagName(a) }; h.Jb = function (a, f, d) { d = d || "u"; var e; do { if (a.nodeType == 1) { var c = b.v(a, d); if (c && c == Hb(f, c)) { e = a; break } } a = b.Nc(a) } while (a && a != j.body); return e }; function D() { var e = arguments, d, c, b, a, g = 1 & e[0], f = 1 + g; d = e[f - 1] || {}; for (; f < e.length; f++) if (c = e[f]) for (b in c) { a = c[b]; if (a !== i) { a = c[b]; var h = d[b]; d[b] = g && (C(h) || C(a)) ? D(g, {}, h, a) : a } } return d } h.M = D; function X(f, g) { var d = {}, c, a, b; for (c in f) { a = f[c]; b = g[c]; if (a !== b) { var e; if (C(a) && C(b)) { a = X(a, b); e = !jb(a) } !e && (d[c] = a) } } return d } h.Qc = function (a) { return E(a) == "function" }; h.Qf = function (a) { return E(a) == "string" }; h.Pc = function (a) { return !isNaN(p(a)) && isFinite(a) }; h.j = n; h.Ve = C; function R(a) { return j.createElement(a) } h.Lb = function () { return R("DIV") }; h.Wc = function () { }; function y(b, c, a) { if (a == i) return b.getAttribute(c); b.setAttribute(c, a) } function U(a, b) { return y(a, b) || y(a, "data-" + b) } h.N = y; h.v = U; h.ac = function (d, b, c) { var a = h.Yc(y(d, b)); if (isNaN(a)) a = c; return a }; function z(b, a) { return y(b, "class", a) || "" } function ob(b) { var a = {}; n(b, function (b) { if (b != i) a[b] = b }); return a } function qb(b, a) { return b.match(a || zb) } function Q(b, a) { return ob(qb(b || "", a)) } h.yf = ob; h.zf = qb; function ab(b, c) { var a = ""; n(c, function (c) { a && (a += b); a += c }); return a } function F(a, c, b) { z(a, ab(" ", D(X(Q(z(a)), Q(c)), Q(b)))) } h.Nc = function (a) { return a.parentNode }; h.Y = function (a) { h.Ab(a, "none") }; h.K = function (a, b) { h.Ab(a, b ? "none" : "") }; h.Af = function (b, a) { b.removeAttribute(a) }; h.Bf = function () { return q() && l < 10 }; h.Cf = function (d, a) { if (a) d.style.clip = "rect(" + c.round(a.c || a.E || 0) + "px " + c.round(a.p) + "px " + c.round(a.s) + "px " + c.round(a.f || a.F || 0) + "px)"; else if (a !== i) { var g = d.style.cssText, f = [new RegExp(/[\s]*clip: rect\(.*?\)[;]?/i), new RegExp(/[\s]*cliptop: .*?[;]?/i), new RegExp(/[\s]*clipright: .*?[;]?/i), new RegExp(/[\s]*clipbottom: .*?[;]?/i), new RegExp(/[\s]*clipleft: .*?[;]?/i)], e = J(g, f, ""); b.hd(d, e) } }; h.ob = function () { return +new Date }; h.R = function (b, a) { b.appendChild(a) }; h.Gb = function (b, a, c) { (c || a.parentNode).insertBefore(b, a) }; h.Kc = function (b, a) { a = a || b.parentNode; a && a.removeChild(b) }; h.ve = function (a, b) { n(a, function (a) { h.Kc(a, b) }) }; h.Md = function (a) { h.ve(h.Rb(a, e), a) }; h.Gc = function (a, b) { var c = h.Nc(a); b & 1 && h.ab(a, (h.A(c) - h.A(a)) / 2); b & 2 && h.Z(a, (h.C(c) - h.C(a)) / 2) }; var S = { c: f, p: f, s: f, f: f, G: f, H: f }; h.Ge = function (a) { var b = h.Lb(); r(b, { xc: "block", xb: h.Q(a), c: 0, f: 0, G: 0, H: 0 }); var d = h.sd(a, S); h.Gb(b, a); h.R(b, a); var e = h.sd(a, S), c = {}; n(d, function (b, a) { if (b == e[a]) c[a] = b }); r(b, S); r(b, c); r(a, { c: 0, f: 0 }); return c }; h.Yc = p; function V(d, c, b) { var a = d.cloneNode(!c); !b && h.Af(a, "id"); return a } h.cb = V; h.Fb = function (d, f) { var a = new Image; function b(e, d) { h.V(a, "load", b); h.V(a, "abort", c); h.V(a, "error", c); f && f(a, d) } function c(a) { b(a, e) } if (gb() && l < 11.6 || !d) b(!d); else { h.i(a, "load", b); h.i(a, "abort", c); h.i(a, "error", c); a.src = d } }; h.Yd = function (d, a, e) { var c = d.length + 1; function b(b) { c--; if (a && b && b.src == a.src) a = b; !c && e && e(a) } n(d, function (a) { h.Fb(a.src, b) }); b() }; h.Td = function (a, g, i, h) { if (h) a = V(a); var c = T(a, g); if (!c.length) c = b.xf(a, g); for (var f = c.length - 1; f > -1; f--) { var d = c[f], e = V(i); z(e, z(d)); b.hd(e, d.style.cssText); b.Gb(e, d); b.Kc(d) } return a }; function Fb(a) { var l = this, p = "", r = ["av", "pv", "ds", "dn"], d = [], q, k = 0, f = 0, e = 0; function g() { F(a, q, (d[e || f & 2 || f] || "") + " " + (d[k] || "")); b.zb(a, "pointer-events", e ? "none" : "") } function c() { k = 0; g(); h.V(j, "mouseup", c); h.V(j, "touchend", c); h.V(j, "touchcancel", c) } function o(a) { if (e) h.Qb(a); else { k = 4; g(); h.i(j, "mouseup", c); h.i(j, "touchend", c); h.i(j, "touchcancel", c) } } l.re = function (a) { if (a === i) return f; f = a & 2 || a & 1; g() }; l.Vb = function (a) { if (a === i) return !e; e = a ? 0 : 3; g() }; l.kb = a = h.Db(a); y(a, "data-jssor-button", "1"); var m = b.zf(z(a)); if (m) p = m.shift(); n(r, function (a) { d.push(p + a) }); q = ab(" ", d); d.unshift(""); h.i(a, "mousedown", o); h.i(a, "touchstart", o) } h.Ec = function (a) { return new Fb(a) }; h.zb = x; h.Hb = m("overflow"); h.Z = m("top", 2); h.fe = m("right", 2); h.de = m("bottom", 2); h.ab = m("left", 2); h.A = m("width", 2); h.C = m("height", 2); h.te = m("marginLeft", 2); h.be = m("marginTop", 2); h.Q = m("position"); h.Ab = m("display"); h.L = m("zIndex", 1); h.yc = function (b, a, c) { if (a != i) Eb(b, a, c); else return Cb(b) }; h.hd = function (a, b) { if (b != i) a.style.cssText = b; else return a.style.cssText }; h.ee = function (b, a) { if (a === i) { a = x(b, "backgroundImage") || ""; var c = /\burl\s*\(\s*["']?([^"'\r\n,]+)["']?\s*\)/gi.exec(a) || []; return c[1] } x(b, "backgroundImage", a ? "url('" + a + "')" : "") }; var G; h.ge = G = { a: h.yc, c: h.Z, p: h.fe, s: h.de, f: h.ab, G: h.A, H: h.C, xb: h.Q, xc: h.Ab, T: h.L }; h.sd = function (c, b) { var a = {}; n(b, function (d, b) { if (G[b]) a[b] = G[b](c) }); return a }; function r(g, l) { var e = vb(), b = L(), d = tb(), j = M(g); function k(b, d, a) { var e = b.sb(v(-d / 2, -a / 2)), f = b.sb(v(d / 2, -a / 2)), g = b.sb(v(d / 2, a / 2)), h = b.sb(v(-d / 2, a / 2)); b.sb(v(300, 300)); return v(c.min(e.x, f.x, g.x, h.x) + d / 2, c.min(e.y, f.y, g.y, h.y) + a / 2) } function a(d, a) { a = a || {}; var n = a.gb || 0, p = (a.pb || 0) % 360, q = (a.ib || 0) % 360, u = (a.P || 0) % 360, l = a.J, m = a.I, f = a.Yf; if (l == i) l = 1; if (m == i) m = 1; if (f == i) f = 1; if (e) { n = 0; p = 0; q = 0; f = 0 } var c = new Bb(a.tb, a.ub, n); c.pb(p); c.ib(q); c.je(u); c.ke(a.Wb, a.Xb); c.Kb(l, m, f); if (b) { c.vb(a.F, a.E); d.style[j] = c.le() } else if (!Z || Z < 9) { var o = "", g = { x: 0, y: 0 }; if (a.hb) g = k(c, a.hb, a.rb); h.be(d, g.y); h.te(d, g.x); o = c.Rd(); var s = d.style.filter, t = new RegExp(/[\s]*progid:DXImageTransform\.Microsoft\.Matrix\([^\)]*\)/g), r = J(s, [t], o); rb(d, r) } } r = function (e, c) { c = c || {}; var j = c.F, k = c.E, g; n(G, function (a, b) { g = c[b]; g !== i && a(e, g) }); h.Cf(e, c.g); if (!b) { j != i && h.ab(e, (c.Id || 0) + j); k != i && h.Z(e, (c.Dd || 0) + k) } if (c.Xd) if (d) pb(h.bb(f, O, e, c)); else a(e, c) }; h.Tb = O; if (d) h.Tb = r; if (e) h.Tb = a; else if (!b) a = O; h.O = r; r(g, l) } h.Tb = r; h.O = r; function Bb(j, k, o) { var d = this, b = [1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, j || 0, k || 0, o || 0, 1], i = c.sin, h = c.cos, l = c.tan; function g(a) { return a * c.PI / 180 } function n(a, b) { return { x: a, y: b } } function m(c, e, l, m, o, r, t, u, w, z, A, C, E, b, f, k, a, g, i, n, p, q, s, v, x, y, B, D, F, d, h, j) { return [c * a + e * p + l * x + m * F, c * g + e * q + l * y + m * d, c * i + e * s + l * B + m * h, c * n + e * v + l * D + m * j, o * a + r * p + t * x + u * F, o * g + r * q + t * y + u * d, o * i + r * s + t * B + u * h, o * n + r * v + t * D + u * j, w * a + z * p + A * x + C * F, w * g + z * q + A * y + C * d, w * i + z * s + A * B + C * h, w * n + z * v + A * D + C * j, E * a + b * p + f * x + k * F, E * g + b * q + f * y + k * d, E * i + b * s + f * B + k * h, E * n + b * v + f * D + k * j] } function e(c, a) { return m.apply(f, (a || b).concat(c)) } d.Kb = function (a, c, d) { if (a != 1 || c != 1 || d != 1) b = e([a, 0, 0, 0, 0, c, 0, 0, 0, 0, d, 0, 0, 0, 0, 1]) }; d.vb = function (a, c, d) { b[12] += a || 0; b[13] += c || 0; b[14] += d || 0 }; d.pb = function (c) { if (c) { a = g(c); var d = h(a), f = i(a); b = e([1, 0, 0, 0, 0, d, f, 0, 0, -f, d, 0, 0, 0, 0, 1]) } }; d.ib = function (c) { if (c) { a = g(c); var d = h(a), f = i(a); b = e([d, 0, -f, 0, 0, 1, 0, 0, f, 0, d, 0, 0, 0, 0, 1]) } }; d.je = function (c) { if (c) { a = g(c); var d = h(a), f = i(a); b = e([d, f, 0, 0, -f, d, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1]) } }; d.ke = function (a, c) { if (a || c) { j = g(a); k = g(c); b = e([1, l(k), 0, 0, l(j), 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1]) } }; d.sb = function (c) { var a = e(b, [1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, c.x, c.y, 0, 1]); return n(a[12], a[13]) }; d.le = function () { return "matrix3d(" + b.join(",") + ")" }; d.Rd = function () { return "progid:DXImageTransform.Microsoft.Matrix(M11=" + b[0] + ", M12=" + b[4] + ", M21=" + b[1] + ", M22=" + b[5] + ", SizingMethod='auto expand')" } } new function () { var a = this; function b(d, g) { for (var j = d[0].length, i = d.length, h = g[0].length, f = [], c = 0; c < i; c++) for (var k = f[c] = [], b = 0; b < h; b++) { for (var e = 0, a = 0; a < j; a++) e += d[c][a] * g[a][b]; k[b] = e } return f } a.J = function (b, c) { return a.vd(b, c, 0) }; a.I = function (b, c) { return a.vd(b, 0, c) }; a.vd = function (a, c, d) { return b(a, [[c, 0], [0, d]]) }; a.sb = function (d, c) { var a = b(d, [[c.x], [c.y]]); return v(a[0][0], a[1][0]) } }; var P = { Id: 0, Dd: 0, F: 0, E: 0, X: 1, J: 1, I: 1, P: 0, pb: 0, ib: 0, tb: 0, ub: 0, gb: 0, Wb: 0, Xb: 0 }; h.rd = function (c, d) { var a = c || {}; if (c) if (b.Qc(c)) a = { fb: a }; else if (b.Qc(c.g)) a.g = { fb: c.g }; a.fb = a.fb || d; if (a.g) a.g.fb = a.g.fb || d; return a }; h.td = function (n, j, s, t, B, C, o) { var a = j; if (n) { a = {}; for (var h in j) { var D = C[h] || 1, z = B[h] || [0, 1], g = (s - z[0]) / z[1]; g = c.min(c.max(g, 0), 1); g = g * D; var x = c.floor(g); if (g != x) g -= x; var k = t.fb || d.l, m, E = n[h], p = j[h]; if (b.Pc(p)) { k = t[h] || k; var A = k(g); m = E + p * A } else { m = b.M({ hc: {} }, n[h]); var y = t[h] || {}; b.j(p.hc || p, function (d, a) { k = y[a] || y.fb || k; var c = k(g), b = d * c; m.hc[a] = b; m[a] += b }) } a[h] = m } var w = b.j(j, function (b, a) { return P[a] != i }); w && b.j(P, function (c, b) { if (a[b] == i && n[b] !== i) a[b] = n[b] }); if (w) { if (a.X) a.J = a.I = a.X; a.hb = o.hb; a.rb = o.rb; if (q() && l >= 11 && (j.F || j.E) && s != 0 && s != 1) a.P = a.P || 1e-8; a.Xd = e } } if (j.g && o.vb) { var r = a.g.hc, v = (r.c || 0) + (r.s || 0), u = (r.f || 0) + (r.p || 0); a.f = (a.f || 0) + u; a.c = (a.c || 0) + v; a.g.f -= u; a.g.p -= u; a.g.c -= v; a.g.s -= v } if (a.g && b.Bf() && !a.g.c && !a.g.f && !a.g.E && !a.g.F && a.g.p == o.hb && a.g.s == o.rb) a.g = f; return a } }; function o() { var a = this, d = []; function i(a, b) { d.push({ Bc: a, Ac: b }) } function h(a, c) { b.j(d, function (b, e) { b.Bc == a && b.Ac === c && d.splice(e, 1) }) } a.Mb = a.addEventListener = i; a.removeEventListener = h; a.o = function (a) { var c = [].slice.call(arguments, 1); b.j(d, function (b) { b.Bc == a && b.Ac.apply(g, c) }) } } var l = function (A, E, h, J, M, L) { A = A || 0; var a = this, p, m, n, s, C = 0, G, H, F, D, z = 0, i = 0, l = 0, y, j, d, f, o, x, u = [], w; function O(a) { d += a; f += a; j += a; i += a; l += a; z += a } function r(p) { var g = p; if (o) if (!x && (g >= f || g < d) || x && g >= d) g = ((g - d) % o + o) % o + d; if (!y || s || i != g) { var k = c.min(g, f); k = c.max(k, d); if (!y || s || k != l) { if (L) { var m = (k - j) / (E || 1); if (h.Od) m = 1 - m; var n = b.td(M, L, m, G, F, H, h); if (w) b.j(n, function (b, a) { w[a] && w[a](J, b) }); else b.O(J, n) } a.tc(l - j, k - j); var r = l, q = l = k; b.j(u, function (b, c) { var a = !y && x || g <= i ? u[u.length - c - 1] : b; a.S(l - z) }); i = g; y = e; a.ec(r, q) } } } function B(a, b, e) { b && a.dc(f); if (!e) { d = c.min(d, a.Cd() + z); f = c.max(f, a.lc() + z) } u.push(a) } var v = g.requestAnimationFrame || g.webkitRequestAnimationFrame || g.mozRequestAnimationFrame || g.msRequestAnimationFrame; if (b.Kf() && b.zd() < 7 || !v) v = function (a) { b.W(a, h.db) }; function I() { if (p) { var d = b.ob(), e = c.min(d - C, h.id), a = i + e * n; C = d; if (a * n >= m * n) a = m; r(a); if (!s && a * n >= m * n) K(D); else v(I) } } function q(g, h, j) { if (!p) { p = e; s = j; D = h; g = c.max(g, d); g = c.min(g, f); m = g; n = m < i ? -1 : 1; a.Sc(); C = b.ob(); v(I) } } function K(b) { if (p) { s = p = D = k; a.Tc(); b && b() } } a.Vc = function (a, b, c) { q(a ? i + a : f, b, c) }; a.Xc = q; a.wb = K; a.oe = function (a) { q(a) }; a.jb = function () { return i }; a.fd = function () { return m }; a.lb = function () { return l }; a.S = r; a.vb = function (a) { r(i + a) }; a.dd = function () { return p }; a.ae = function (a) { o = a }; a.dc = O; a.cd = function (a, b) { B(a, 0, b) }; a.Jc = function (a) { B(a, 1) }; a.Cd = function () { return d }; a.lc = function () { return f }; a.ec = a.Sc = a.Tc = a.tc = b.Wc; a.Mc = b.ob(); h = b.M({ db: 16, id: 50 }, h); o = h.Lc; x = h.Wd; w = h.Sd; d = j = A; f = A + E; H = h.Rc || {}; F = h.B || {}; G = b.rd(h.k) }; var m = { jc: "data-scale", Dc: "data-scale-ratio", Cb: "data-autocenter" }, n = new function () { var a = this; a.yb = function (c, a, e, d) { (d || !b.N(c, a)) && b.N(c, a, e) }; a.pc = function (a) { var c = b.ac(a, m.Cb); b.Gc(a, c) } }, q = new function () { var h = this; function g(b, a, c) { c.push(a); b[a] = b[a] || []; b[a].push(c) } h.Vd = function (d) { for (var e = [], a, b = 0; b < d.z; b++) for (a = 0; a < d.q; a++) g(e, c.ceil(1e5 * c.random()) % 13, [b, a]); return e } }, t = function (m, s, p, u, z, A) { var a = this, v, h, g, y = 0, x = u.se, r, i = 8; function t(a) { if (a.c) a.E = a.c; if (a.f) a.F = a.f; b.j(a, function (a) { b.Ve(a) && t(a) }) } function j(h, f, g) { var a = { db: f, m: 1, W: 0, q: 1, z: 1, a: 0, X: 0, g: 0, vb: k, u: k, Od: k, Zd: q.Vd, D: { nb: 0, mb: 0 }, k: d.l, Rc: {}, ic: [], B: {} }; b.M(a, h); if (a.z == 0) a.z = c.round(a.q * g); t(a); a.k = b.rd(a.k, d.l); a.ie = c.ceil(a.m / a.db); a.he = function (c, b) { c /= a.q; b /= a.z; var f = c + "x" + b; if (!a.ic[f]) { a.ic[f] = { G: c, H: b }; for (var d = 0; d < a.q; d++) for (var e = 0; e < a.z; e++) a.ic[f][e + "," + d] = { c: e * b, p: d * c + c, s: e * b + b, f: d * c } } return a.ic[f] }; if (a.sc) { a.sc = j(a.sc, f, g); a.u = e } return a } function n(z, i, a, v, n, l) { var y = this, t, u = {}, h = {}, m = [], f, d, r, p = a.D.nb || 0, q = a.D.mb || 0, g = a.he(n, l), o = B(a), C = o.length - 1, s = a.m + a.W * C, w = v + s, j = a.u, x; w += 50; function B(a) { var b = a.Zd(a); return a.Od ? b.reverse() : b } y.yd = w; y.fc = function (d) { d -= v; var e = d < s; if (e || x) { x = e; if (!j) d = s - d; var f = c.ceil(d / a.db); b.j(h, function (a, e) { var d = c.max(f, a.me); d = c.min(d, a.length - 1); if (a.ud != d) { if (!a.ud && !j) b.K(m[e]); else d == a.ne && j && b.Y(m[e]); a.ud = d; b.O(m[e], a[d]) } }) } }; i = b.cb(i); A(i, 0, 0); b.j(o, function (i, m) { b.j(i, function (G) { var I = G[0], H = G[1], v = I + "," + H, o = k, s = k, x = k; if (p && H % 2) { if (p & 3) o = !o; if (p & 12) s = !s; if (p & 16) x = !x } if (q && I % 2) { if (q & 3) o = !o; if (q & 12) s = !s; if (q & 16) x = !x } a.c = a.c || a.g & 4; a.s = a.s || a.g & 8; a.f = a.f || a.g & 1; a.p = a.p || a.g & 2; var E = s ? a.s : a.c, B = s ? a.c : a.s, D = o ? a.p : a.f, C = o ? a.f : a.p; a.g = E || B || D || C; r = {}; d = { E: 0, F: 0, a: 1, G: n, H: l }; f = b.M({}, d); t = b.M({}, g[v]); if (a.a) d.a = 2 - a.a; if (a.T) { d.T = a.T; f.T = 0 } var K = a.q * a.z > 1 || a.g; if (a.X || a.P) { var J = e; if (J) { d.X = a.X ? a.X - 1 : 1; f.X = 1; var N = a.P || 0; d.P = N * 360 * (x ? -1 : 1); f.P = 0 } } if (K) { var i = t.hc = {}; if (a.g) { var w = a.Vf || 1; if (E && B) { i.c = g.H / 2 * w; i.s = -i.c } else if (E) i.s = -g.H * w; else if (B) i.c = g.H * w; if (D && C) { i.f = g.G / 2 * w; i.p = -i.f } else if (D) i.p = -g.G * w; else if (C) i.f = g.G * w } r.g = t; f.g = g[v] } var L = o ? 1 : -1, M = s ? 1 : -1; if (a.x) d.F += n * a.x * L; if (a.y) d.E += l * a.y * M; b.j(d, function (a, c) { if (b.Pc(a)) if (a != f[c]) r[c] = a - f[c] }); u[v] = j ? f : d; var F = a.ie, A = c.round(m * a.W / a.db); h[v] = new Array(A); h[v].me = A; h[v].ne = A + F - 1; for (var z = 0; z <= F; z++) { var y = b.td(f, r, z / F, a.k, a.B, a.Rc, { vb: a.vb, hb: n, rb: l }); y.T = y.T || 1; h[v].push(y) } }) }); o.reverse(); b.j(o, function (a) { b.j(a, function (c) { var f = c[0], e = c[1], d = f + "," + e, a = i; if (e || f) a = b.cb(i); b.O(a, u[d]); b.Hb(a, "hidden"); b.Q(a, "absolute"); z.pe(a); m[d] = a; b.K(a, !j) }) }) } function w() { var a = this, b = 0; l.call(a, 0, v); a.ec = function (c, a) { if (a - b > i) { b = a; g && g.fc(a); h && h.fc(a) } }; a.Pd = r } a.qe = function () { var a = 0, b = u.oc, d = b.length; if (x) a = y++ % d; else a = c.floor(c.random() * d); b[a] && (b[a].qb = a); return b[a] }; a.ce = function (x, y, k, l, b, t) { a.Bb(); r = b; b = j(b, i, t); var f = l.bd, e = k.bd; f["no-image"] = !l.cc; e["no-image"] = !k.cc; var o = f, q = e, w = b, d = b.sc || j({}, i, t); if (!b.u) { o = e; q = f } var u = d.dc || 0; h = new n(m, q, d, c.max(u - d.db, 0), s, p); g = new n(m, o, w, c.max(d.db - u, 0), s, p); h.fc(0); g.fc(0); v = c.max(h.yd, g.yd); a.qb = x }; a.Bb = function () { m.Bb(); h = f; g = f }; a.Df = function () { var a = f; if (g) a = new w; return a }; if (z && b.Of() < 537) i = 16; o.call(a); l.call(a, -1e7, 1e7) }, p = { Hc: 1 }; var u = function (a, d, i, y, x, w) { var c = this; o.call(c); var j, h, g, l; b.A(a); b.C(a); var s, r; function q(a) { c.o(p.Hc, a, e) } function v(c) { b.K(a, c); b.K(d, c) } function u() { s.Vb(i.Zb || !j.Gf(h)); r.Vb(i.Zb || !j.uf(h)) } c.mc = function (c, a, b) { h = a; !b && u() }; c.nc = v; var t; c.Cc = function () { h = 0; if (!t) { b.i(a, "click", b.bb(f, q, -l)); b.i(d, "click", b.bb(f, q, l)); s = b.Ec(a); r = b.Ec(d); t = e } }; c.Ub = g = b.M({ ue: 1 }, i); l = g.ue; j = w; if (g.Kb == k) { n.yb(a, m.jc, 1); n.yb(d, m.jc, 1) } if (g.eb) { n.yb(a, m.Cb, g.eb); n.yb(d, m.Cb, g.eb) } n.pc(a); n.pc(d) }, r = function (g, E) { var r = this, x, B, u, a, A = [], z, y, d, l, q, t, s, j, v, i, w; o.call(r); g = b.Db(g); function D(m, g) { var h = this, c, l, j; function n() { l.re(u == g) } function i(f) { if (f || !v.tf()) { var c = d - g % d, a = v.Fd((g + c) / d - 1), b = a * d + d - c; if (a < 0) b += x % d; if (a >= B) b -= x % d; r.o(p.Hc, b, k, e) } } h.qb = g; h.Kd = n; j = m.sf || m.cc || b.Lb(); h.Yb = c = b.Td(w, "thumbnailtemplate", j, e); l = b.Ec(c); a.qc & 1 && b.i(c, "click", b.bb(f, i, 0)); a.qc & 2 && b.i(c, "mouseenter", b.bb(f, i, 1)) } r.mc = function (a, f, e) { if (a != u) { var b = u; u = a; b != -1 && A[b].Kd(); A[a].Kd() } !e && v.rf(v.Fd(c.floor(a / d))) }; r.nc = function (a) { b.K(g, a) }; var C; r.Cc = function (F, G) { if (!C) { x = F; B = c.ceil(x / d); u = -1; var f = a.Ob & 1; j = j || c.ceil((z + l) / (t + l) * f + (y + q) / (s + q) * (1 - f)); j = c.min(j, B); var w = t + (t + l) * (d - 1) * (1 - f), p = s + (s + q) * (d - 1) * f, n = w + (w + l) * (j - 1) * f, m = p + (p + q) * (j - 1) * (1 - f); n = c.min(z, n); m = c.min(y, m); var E = (n - t - l) / 2 * f + (m - s - q) / 2 * (1 - f); b.Q(i, "absolute"); b.Hb(i, "hidden"); b.A(i, n); b.C(i, m); b.Gc(i, 3); var o = []; b.j(G, function (k, g) { var h = new D(k, g), e = h.Yb, a = c.floor(g / d), j = g % d; b.ab(e, (t + l) * j * (1 - f)); b.Z(e, (s + q) * j * f); if (!o[a]) { o[a] = b.Lb(); b.R(i, o[a]) } b.R(o[a], e); A.push(h) }); var H = b.M({ Nb: 0, Bd: k, pf: w, Hf: p, pd: l * f + q * (1 - f), md: 12, ld: 200, xd: 1, q: j, Pb: E, Jd: a.Ob, Ed: a.Lf || a.Uf ? 0 : a.Ob }, a); v = new h(g, H); r.jf = v.jf; C = e } }; r.Ub = a = b.M({ vc: 0, wc: 0, Ob: 1, qc: 1 }, E); z = b.A(g); y = b.C(g); i = b.Sb(g, "slides", e); w = b.Sb(i, "prototype"); t = b.A(w); s = b.C(w); b.Kc(w, i); d = a.z || 1; l = a.vc; q = a.wc; j = a.q; a.Kb == k && n.yb(g, m.jc, 1); a.eb &= a.Ob; a.eb && n.yb(g, m.Cb, a.eb); n.pc(g) }; function s(e, d, c) { var a = this; l.call(a, 0, c); a.od = b.Wc; a.Qd = 0; a.qd = c } var h = function () { var a = this; b.Pf(a, o); var Mb = "data-jssor-slider", Zb = "data-jssor-thumb", v, n, U, nb, bb, xb, ab, T, L, K, Cb, Tb = 1, lc = 1, bc = 1, cc = {}, x, V, Eb, Ib, Hb, Ab, zb, yb, jb, r = -1, Pb, q, I, M, sb, ub, vb, gb, G, S, Y, y, W, tb, eb = [], hc, jc, dc, Ub, Fc, u, kb, H, fc, rb, Nb, gc, cb, O = 0, J = Number.MAX_VALUE, E = Number.MIN_VALUE, ic, C, lb, Q, N = 1, Z, A, db, Qb = 0, Rb = 0, P, ob, pb, mb, w, hb, z, Gb, fb = [], Fb = b.lf(), qb = Fb.vf, B = [], D, R, F, Lb, Yb, X; function uc(d, k, o) { var l = this, h = { c: 2, p: 1, s: 2, f: 1 }, n = { c: "top", p: "right", s: "bottom", f: "left" }, g, a, f, i, j = {}; l.kb = d; l.gc = function (q, p, t) { var l, s = q, r = p; if (!f) { f = b.Ge(d); g = d.parentNode; i = { Kb: b.ac(d, m.jc, 1), eb: b.ac(d, m.Cb) }; b.j(n, function (c, a) { j[a] = b.ac(d, "data-scale-" + c, 1) }); a = d; if (k) { a = b.cb(g, e); b.O(a, { c: 0, f: 0 }); b.R(a, d); b.R(g, a) } } if (o) { l = c.max(q, p); if (k) if (t > 0 && t < 1) { var v = c.min(q, p); l = c.min(l / v, 1 / (1 - t)) * v } } else s = r = l = c.pow(L < K ? p : q, i.Kb); b.of(a, l); b.N(a, m.Dc, l); b.A(g, f.G * s); b.C(g, f.H * r); var u = b.kd() && b.Ad() < 9 || b.Ad() < 10 && b.Nf() ? l : 1, w = (s - u) * f.G / 2, x = (r - u) * f.H / 2; b.ab(a, w); b.Z(a, x); b.j(f, function (d, a) { if (h[a] && d) { var e = (h[a] & 1) * c.pow(q, j[a]) * d + (h[a] & 2) * c.pow(p, j[a]) * d / 2; b.ge[a](g, e) } }); b.Gc(g, i.eb) } } function Ec() { var b = this; l.call(b, -1e8, 2e8); b.hf = function () { var a = b.lb(); a = t(a); var d = c.round(a), g = d, f = a - c.floor(a), e = ac(a); return { qb: g, Le: d, xb: f, xc: a, Ke: e } }; b.ec = function (d, b) { var g = t(b); if (c.abs(b - d) > 1e-5) { var f = c.floor(b); if (f != b && b > d && (C & 1 || b > O)) f++; kc(f, g, e) } a.o(h.Je, g, t(d), b, d) } } function Dc() { var a = this; l.call(a, 0, 0, { Lc: q }); b.j(B, function (b) { C & 1 && b.ae(q); a.Jc(b); b.dc(cb / gb) }) } function Cc() { var a = this, b = Gb.kb; l.call(a, -1, 2, { k: d.l, Sd: { xb: pc }, Lc: q }, b, { xb: 1 }, { xb: -2 }); a.Yb = b } function vc(o, m) { var b = this, d, g, i, j, c; l.call(b, -1e8, 2e8, { id: 100 }); b.Sc = function () { Z = e; db = f; a.o(h.Ie, t(w.jb()), w.jb()) }; b.Tc = function () { Z = k; j = k; var b = w.hf(); a.o(h.He, t(w.jb()), w.jb()); if (!A) { Gc(b.Le, r); (!b.xb || b.Ke) && kc(r, b.xc) } }; b.ec = function (f, e) { var a; if (j) a = c; else { a = g; if (i) { var b = e / i; a = n.Hd(b) * (g - d) + d } } w.S(a) }; b.rc = function (a, e, c, f) { d = a; g = e; i = c; w.S(a); b.S(0); b.Xc(c, f) }; b.kf = function (a) { j = e; c = a; b.Vc(a, f, e) }; b.Fe = function (a) { c = a }; w = new Ec; w.cd(o); w.cd(m) } function wc() { var c = this, a = nc(); b.L(a, 0); b.zb(a, "pointerEvents", "none"); c.kb = a; c.pe = function (c) { b.R(a, c); b.K(a) }; c.Bb = function () { b.Y(a); b.Md(a) } } function Bc(m, g) { var d = this, s, J, v, j, y = [], x, A, S, E, P, L, F, i, w, p; l.call(d, -G, G + 1, {}); function K(a) { s && s.od(); R(m, a, 0); L = e; s = new bb.U(m, bb, b.Yc(b.v(m, "idle")) || fc, !u); s.S(0) } function W() { s.Mc < bb.Mc && K() } function N(p, r, o) { if (!E) { E = e; if (j && o) { var f = o.width, c = o.height, m = f, l = c; if (f && c && n.Ib) { if (n.Ib & 3 && (!(n.Ib & 4) || f > I || c > M)) { var i = k, q = I / M * c / f; if (n.Ib & 1) i = q > 1; else if (n.Ib & 2) i = q < 1; m = i ? f * M / c : I; l = i ? M : c * I / f } b.A(j, m); b.C(j, l); b.Z(j, (M - l) / 2); b.ab(j, (I - m) / 2) } b.Q(j, "absolute"); a.o(h.Me, g) } } b.Y(r); p && p(d) } function U(f, b, c, e) { if (e == db && r == g && u) if (!Fc) { var a = t(f); D.ce(a, g, b, d, c, M / I); b.Ee(); hb.dc(a - hb.Cd() - 1); hb.S(a); z.rc(a, a, 0) } } function Y(b) { if (b == db && r == g) { if (!i) { var a = f; if (D) if (D.qb == g) a = D.Df(); else D.Bb(); W(); i = new Ac(m, g, a, s); i.Nd(p) } !i.dd() && i.uc() } } function C(a, e, k) { if (a == g) { if (a != e) B[e] && B[e].Ld(); else !k && i && i.Ce(); p && p.Vb(); var l = db = b.ob(); d.Fb(b.bb(f, Y, l)) } else { var j = c.min(g, a), h = c.max(g, a), o = c.min(h - j, j + q - h), m = G + n.Be - 1; (!P || o <= m) && d.Fb() } } function Z() { if (r == g && i) { i.wb(); p && p.Ae(); p && p.ze(); i.jd() } } function ab() { r == g && i && i.wb() } function X(b) { !Q && a.o(h.ye, g, b) } function O() { p = w.pInstance; i && i.Nd(p) } d.Fb = function (d, c) { c = c || v; if (y.length && !E) { b.K(c); if (!S) { S = e; a.o(h.xe, g); b.j(y, function (a) { if (!b.N(a, "src")) { a.src = b.v(a, "src2") || ""; b.Ab(a, a["display-origin"]) } }) } b.Yd(y, j, b.bb(f, N, d, c)) } else N(d, c) }; d.we = function () { if (q == 1) { d.Ld(); C(g, g) } else if (D) { var a = D.qe(q); if (a) { var h = db = b.ob(), c = g + kb, e = B[t(c)]; return e.Fb(b.bb(f, U, c, e, a, h), v) } } else Bb(kb) }; d.zc = function () { C(g, g, e) }; d.Ld = function () { p && p.Ae(); p && p.ze(); d.Oc(); i && i.De(); i = f; K() }; d.Ee = function () { b.Y(m) }; d.Oc = function () { b.K(m) }; d.Ne = function () { p && p.Vb() }; function R(a, f, c, h) { if (b.N(a, Mb)) return; if (!L) { if (a.tagName == "IMG") { y.push(a); if (!b.N(a, "src")) { P = e; a["display-origin"] = b.Ab(a); b.Y(a) } } var d = b.ee(a); if (d) { var g = new Image; b.v(g, "src2", d); y.push(g) } c && b.L(a, (b.L(a) || 0) + 1) } var i = b.Rb(a); b.j(i, function (a) { var d = a.tagName, g = b.v(a, "u"); if (g == "player" && !w) { w = a; if (w.pInstance) O(); else b.i(w, "dataavailable", O) } if (g == "caption") { if (f) { b.If(a, b.v(a, "to")); b.Ff(a, b.v(a, "bf")); F && b.v(a, "3d") && b.Ef(a, "preserve-3d") } } else if (!L && !c && !j) { if (d == "A") { if (b.v(a, "u") == "image") j = b.wf(a, "IMG"); else j = b.Sb(a, "image", e); if (j) { x = a; b.Ab(x, "block"); b.O(x, jb); A = b.cb(x, e); b.Q(x, "relative"); b.yc(A, 0); b.zb(A, "backgroundColor", "#000") } } else if (d == "IMG" && b.v(a, "u") == "image") j = a; if (j) { j.border = 0; b.O(j, jb) } } R(a, f, c + 1, h) }) } d.tc = function (c, b) { var a = G - b; pc(J, a) }; d.qb = g; o.call(d); F = b.v(m, "p"); b.mf(m, F); b.nf(m, b.v(m, "po")); var H = b.Sb(m, "thumb", e); if (H) { d.sf = b.cb(H); b.Y(H) } b.K(m); v = b.cb(V); b.L(v, 1e3); b.i(m, "click", X); K(e); d.cc = j; d.Zc = A; d.bd = m; d.Yb = J = m; b.R(J, v); a.Mb(203, C); a.Mb(28, ab); a.Mb(24, Z) } function Ac(z, g, p, q) { var c = this, n = 0, v = 0, i, j, f, d, m, t, s, o = B[g]; l.call(c, 0, 0); function w() { b.Md(R); Ub && m && o.Zc && b.R(R, o.Zc); b.K(R, !m && o.cc) } function x() { c.uc() } function y(a) { s = a; c.wb(); c.uc() } c.uc = function () { var b = c.lb(); if (!A && !Z && !s && r == g) { if (!b) { if (i && !m) { m = e; c.jd(e); a.o(h.Oe, g, n, v, i, d) } w() } var k, p = h.ad; if (b != d) if (b == f) k = d; else if (b == j) k = f; else if (!b) k = j; else k = c.fd(); a.o(p, g, b, n, j, f, d); var l = u && (!H || N); if (b == d) (f != d && !(H & 12) || l) && o.we(); else (l || b != f) && c.Xc(k, x) } }; c.Ce = function () { f == d && f == c.lb() && c.S(j) }; c.De = function () { D && D.qb == g && D.Bb(); var b = c.lb(); b < d && a.o(h.ad, g, -b - 1, n, j, f, d) }; c.jd = function (a) { p && b.Hb(Y, a && p.Pd.Tf ? "" : "hidden") }; c.tc = function (c, b) { if (m && b >= i) { m = k; w(); o.Oc(); D.Bb(); a.o(h.Pe, g, n, v, i, d) } a.o(h.gf, g, b, n, j, f, d) }; c.Nd = function (a) { if (a && !t) { t = a; a.Mb($JssorPlayer$.Ud, y) } }; p && c.Jc(p); i = c.lc(); c.Jc(q); j = i + q.Qd; d = c.lc(); f = u ? i + q.qd : d } function Ob(a, c, d) { b.ab(a, c); b.Z(a, d) } function pc(c, b) { var a = y > 0 ? y : U, d = ub * b * (a & 1), e = vb * b * (a >> 1 & 1); Ob(c, d, e) } function Kb(a) { if (!(C & 1)) a = c.min(J, c.max(a, E)); return a } function ac(a) { return !(C & 1) && (a - E < .0001 || J - a < .0001) } function ec() { Lb = Z; Yb = z.fd(); F = w.jb() } function Wb() { ec(); if (A || !N && H & 12) { z.wb(); a.o(h.ff) } } function Vb(g) { if (!A && (N || !(H & 12)) && !z.dd()) { var b = w.jb(), a = F, f = 0; if (g && c.abs(P) >= n.md) { a = b; f = pb } if (ac(b)) { if (!g || Q) a = c.round(a) } else a = c.ceil(a); a = Kb(a + f); if (!(C & 1)) { if (J - a < .5) a = J; if (a - E < .5) a = E } var e = c.abs(a - b); if (e < 1 && n.Hd != d.l) e = 1 - c.pow(1 - e, 5); if (!Q && Lb) z.oe(Yb); else if (b == a) { Pb.Ne(); Pb.zc() } else z.rc(b, a, e * rb) } } function Xb(a) { !b.Jb(b.Ic(a), "nodrag") && b.Qb(a) } function yc(a) { oc(a, 1) } function oc(c, g) { var d = b.Ic(c); tb = k; var l = b.Jb(d, "1", Zb); if ((!l || l === v) && !W && (!g || c.touches.length == 1)) { tb = b.Jb(d, "nodrag") || !lb || !zc(); var n = b.Jb(d, i, m.Dc); if (n) bc = b.N(n, m.Dc); if (g) { var p = c.touches[0]; Qb = p.clientX; Rb = p.clientY } else { var o = b.nd(c); Qb = o.x; Rb = o.y } A = e; db = f; b.i(j, g ? "touchmove" : "mousemove", Db); b.ob(); Q = 0; Wb(); if (!Lb) y = 0; P = 0; ob = 0; pb = 0; a.o(h.ef, t(F), F, c) } } function Db(g) { if (A) { var a; if (g.type != "mousemove") if (g.touches.length == 1) { var o = g.touches[0]; a = { x: o.clientX, y: o.clientY } } else ib(); else a = b.nd(g); if (a) { var d = a.x - Qb, f = a.y - Rb; if (y || c.abs(d) > 1.5 || c.abs(f) > 1.5) { if (c.floor(F) != F) y = y || U & W; if ((d || f) && !y) { if (W == 3) if (c.abs(f) > c.abs(d)) y = 2; else y = 1; else y = W; if (qb && y == 1 && c.abs(f) > c.abs(d) * 2.4) tb = e } var n = f, i = vb; if (y == 1) { n = d; i = ub } if (P - ob < -1.5) pb = 0; else if (P - ob > 1.5) pb = -1; ob = P; P = n; X = F - P / i / bc; if (!(C & 1)) { var l = 0, j = [-F + O, 0, F - q + S - O]; b.j(j, function (b, d) { if (b > 0) { var a = c.pow(b, 1 / 1.6); a = c.tan(a * c.PI / 2); l = (a - b) * (d - 1) } }); var h = l + X, m = k; j = [-h + O, 0, h - q + S - O]; b.j(j, function (a, b) { if (a > 0) { a = c.min(a, i); a = c.atan(a) * 2 / c.PI; a = c.pow(a, 1.6); X = a * (b - 1) + O; if (b) X += q - S; m = e } }); if (!m) X = h } if (P && y && !tb) { b.Qb(g); if (!Z) z.kf(X); else z.Fe(X) } } } } } function ib() { xc(); if (A) { Q = P; b.ob(); b.V(j, "mousemove", Db); b.V(j, "touchmove", Db); Q && u & 8 && (u = 0); z.wb(); A = k; var c = w.jb(); a.o(h.df, t(c), c, t(F), F); H & 12 && ec(); Vb(e) } } function tc(c) { var a = b.Ic(c), d = b.Jb(a, "1", Mb); if (v === d) if (Q) { b.qf(c); while (a && v !== a) { (a.tagName == "A" || b.N(a, "data-jssor-button")) && b.Qb(c); a = a.parentNode } } else u & 4 && (u = 0) } function Hc(d) { if (d != r) { var b = mb.lb(), a = Kb(d), e = c.round(t(a)); if (b - a < .5) a = b; B[r]; r = e; Pb = B[r]; w.S(a) } } function Gc(b, c) { y = 0; Hc(b); if (u & 2 && (kb > 0 && r == q - 1 || kb < 0 && !r)) u = 0; a.o(h.cf, r, c) } function kc(a, d, e) { if (!(C & 1)) { a = c.max(0, a); a = c.min(a, q - S + O); a = c.round(a) } a = t(a); b.j(eb, function (b) { b.mc(a, d, e) }) } function zc() { var b = h.ed || 0, a = lb; h.ed |= a; return W = a & ~b } function xc() { if (W) { h.ed &= ~lb; W = 0 } } function nc() { var a = b.Lb(); b.O(a, jb); b.Q(a, "absolute"); return a } function t(b, a) { a = a || q || 1; return (b % a + a) % a } function Jb(c, a, b) { u & 8 && (u = 0); wb(c, rb, a, b) } function Sb() { b.j(eb, function (a) { a.nc(a.Ub.Wf <= N) }) } function rc() { if (!N) { N = 1; Sb(); if (!A) { H & 12 && Vb(); H & 3 && B[r] && B[r].zc() } } a.o(h.bf) } function qc() { if (N) { N = 0; Sb(); A || !(H & 12) || Wb() } a.o(h.af) } function sc() { b.j(fb, function (a) { b.O(a, jb); b.Q(a, "absolute"); b.Hb(a, "hidden"); b.Y(a) }); b.O(V, jb) } function Bb(b, a) { wb(b, a, e) } function wb(l, f, m, o) { if (!A && (N || !(H & 12)) || n.Bd) { Z = e; A = k; z.wb(); if (f == i) f = rb; var b = t(mb.lb()), d = l; if (m) { d = b + l; d = c.round(d) } var a = d; if (!(C & 1)) { if (o) a = t(a); else if (C & 2 && (a < 0 && c.abs(b - E) < .0001 || a > q - S && c.abs(b - J) < .0001)) a = a < 0 ? J : E; a = Kb(a); if (J - a < .5) a = J; if (a - E < .5) a = E } var j = (a - b) % q; a = b + j; var g = b == a ? 0 : f * c.abs(j), h = 1; if (G > 1) h = (U & 1 ? zb : yb) / gb; g = c.min(g, f * h * 1.5); z.rc(b, a, g || 1) } } a.Nb = function (a) { if (a == i) return u; if (a != u) { u = a; u && B[r] && B[r].zc() } }; a.tf = function () { return Q }; a.hb = function () { return L }; a.rb = function () { return K }; a.Ze = function (b) { if (b == i) return Cb || L; a.gc(b, b / L * K) }; a.gc = function (c, a, d) { b.A(v, c); b.C(v, a); Tb = c / L; lc = a / K; b.j(cc, function (a) { a.gc(Tb, lc, d) }); if (!Cb) { b.Gb(Y, x); b.Z(Y, 0); b.ab(Y, 0) } Cb = c }; a.Gf = function (a) { return c.abs(a - E) < .0001 }; a.uf = function (a) { return c.abs(a - J) < .0001 }; a.rf = wb; a.Vc = function () { a.Nb(u || 1) }; a.Fd = function (a) { a = t(a); if (C & 1) { var e = cb / gb, b = t(mb.lb()), d = t(a - b + e), f = t(c.abs(a - b)); if (d >= G) { if (f > q / 2) if (a > b) a -= q; else a += q } else if (a > b && d < e) a -= q; else if (a < b && d > e) a += q } return a }; a.bc = function (r, l) { a.kb = v = b.Db(r); L = b.A(v); K = b.C(v); n = b.M({ Ib: 0, Be: 1, Eb: 1, Fc: 0, Nb: 0, Zb: 1, kc: e, Bd: e, We: 1, gd: 3e3, xd: 1, ld: 500, Hd: d.Ye, md: 20, pd: 0, q: 1, Pb: 0, Ue: 1, Jd: 1, Ed: 1 }, l); n.kc = n.kc && b.Mf(); if (n.Te != i) n.gd = n.Te; if (n.Se != i) n.Pb = n.Se; U = n.Jd & 3; nb = n.Xe; bb = b.M({ U: s }, n.Rf); xb = n.Sf; ab = n.Re; T = n.Qe; !n.Ue; var w = b.Rb(v); b.j(w, function (a, d) { var c = b.v(a, "u"); if (c == "loading") V = a; else { if (c == "slides") x = a; if (c == "navigator") Eb = a; if (c == "arrowleft") Ib = a; if (c == "arrowright") Hb = a; if (c == "thumbnavigator") Ab = a; if (a.tagName != "STYLE" && a.tagName != "SCRIPT") cc[c || d] = new uc(a, c == "slides", b.yf(["slides", "thumbnavigator"])[c]) } }); V = V || b.Lb(j); zb = b.A(x); yb = b.C(x); I = n.pf || zb; M = n.Hf || yb; jb = { G: I, H: M, c: 0, f: 0 }; sb = n.pd; ub = I + sb; vb = M + sb; gb = U & 1 ? ub : vb; kb = n.We; H = n.xd; fc = n.gd; rb = n.ld; Gb = new wc; if (n.kc && (!b.Jf() || qb)) Ob = function (a, c, d) { b.Tb(a, { tb: c, ub: d }) }; u = n.Nb & 63; a.Ub = l; b.N(v, Mb, "1"); b.L(x, b.L(x) || 0); b.Q(x, "absolute"); Y = b.cb(x, e); b.Gb(Y, x); hb = new Cc; b.R(Y, hb.Yb); b.Hb(x, "hidden"); H &= qb ? 10 : 5; var y = b.Rb(x); b.j(y, function (a) { a.tagName == "DIV" && !b.v(a, "u") && fb.push(a); b.L(a, (b.L(a) || 0) + 1) }); R = nc(); b.zb(R, "backgroundColor", "#000"); b.yc(R, 0); b.L(R, 0); b.Gb(R, x.firstChild, x); q = fb.length; G = c.min(n.q, q); S = ((U & 1) * zb + (U & 2) * yb / 2 + sb) / gb; ic = G < q; C = ic ? n.Zb : 0; if (q) { sc(); cb = G >= q ? 0 : n.Pb; if (nb) { Ub = nb.Xf; Nb = nb.U; gc = !cb && G == 1 && q > 1 && Nb && (!b.kd() || b.zd() >= 9) } if (!(C & 1)) { O = cb / gb; E = O; J = E + q - S } lb = (G > 1 || cb ? U : -1) & n.Ed; Fb.wd && b.zb(x, Fb.wd, ([f, "pan-y", "pan-x", "none"])[lb] || ""); if (gc) D = new Nb(Gb, I, M, nb, qb, Ob); for (var h = 0; h < fb.length; h++) { var m = fb[h], o = new Bc(m, h); B.push(o) } b.Y(V); mb = new Dc; z = new vc(mb, hb); b.i(v, "click", tc, e); b.i(v, "mouseleave", rc); b.i(v, "mouseenter", qc); b.i(v, "mousedown", oc); b.i(v, "touchstart", yc); b.i(v, "dragstart", Xb); b.i(v, "selectstart", Xb); b.i(g, "mouseup", ib); b.i(j, "mouseup", ib); b.i(j, "touchend", ib); b.i(j, "touchcancel", ib); b.i(g, "blur", ib); if (Eb && xb) { hc = new xb.U(Eb, xb, L, K); eb.push(hc) } if (ab && Ib && Hb) { ab.Zb = C; jc = new ab.U(Ib, Hb, ab, L, K, a); eb.push(jc) } if (Ab && T) { T.Fc = n.Fc; T.Eb = T.Eb || 0; dc = new T.U(Ab, T); !T.Lf && b.N(Ab, Zb, "1"); eb.push(dc) } b.j(eb, function (a) { a.Cc(q, B, V); a.Mb(p.Hc, Jb) }); b.zb(v, "visibility", "visible"); a.gc(L, K); Sb(); n.Eb && b.i(j, "keydown", function (a) { if (a.keyCode == 37) Jb(-n.Eb, e); else a.keyCode == 39 && Jb(n.Eb, e) }); var k = n.Fc; k = t(k); wb(k, 0) } }; b.bc(a) }; h.ye = 21; h.ef = 22; h.df = 23; h.Ie = 24; h.He = 25; h.xe = 26; h.Me = 27; h.ff = 28; h.af = 31; h.bf = 32; h.Je = 202; h.cf = 203; h.Oe = 206; h.Pe = 207; h.gf = 208; h.ad = 209; jssor_1_slider_init = function () { var i = [{ m: 1200, x: .3, B: { f: [.3, .7] }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: -.3, u: e, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: -.3, B: { f: [.3, .7] }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, u: e, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, y: .3, B: { c: [.3, .7] }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: -.3, u: e, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: -.3, B: { c: [.3, .7] }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: .3, u: e, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, q: 2, B: { f: [.3, .7] }, D: { nb: 3 }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, q: 2, u: e, D: { nb: 3 }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, y: .3, z: 2, B: { c: [.3, .7] }, D: { mb: 12 }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: .3, z: 2, u: e, D: { mb: 12 }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: .3, q: 2, B: { c: [.3, .7] }, D: { nb: 12 }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, y: -.3, q: 2, u: e, D: { nb: 12 }, k: { c: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, z: 2, B: { f: [.3, .7] }, D: { mb: 3 }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: -.3, z: 2, u: e, D: { mb: 3 }, k: { f: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, y: .3, q: 2, z: 2, B: { f: [.3, .7], c: [.3, .7] }, D: { nb: 3, mb: 12 }, k: { f: d.n, c: d.n, a: d.l }, a: 2 }, { m: 1200, x: .3, y: .3, q: 2, z: 2, B: { f: [.3, .7], c: [.3, .7] }, u: e, D: { nb: 3, mb: 12 }, k: { f: d.n, c: d.n, a: d.l }, a: 2 }, { m: 1200, W: 20, g: 3, k: { g: d.n, a: d.l }, a: 2 }, { m: 1200, W: 20, g: 3, u: e, k: { g: d.Uc, a: d.l }, a: 2 }, { m: 1200, W: 20, g: 12, k: { g: d.n, a: d.l }, a: 2 }, { m: 1200, W: 20, g: 12, u: e, k: { g: d.Uc, a: d.l }, a: 2 }], j = { Nb: 1, Xe: { U: t, oc: i, se: 1 }, Re: { U: u }, Qe: { U: r, q: 5, vc: 5, wc: 5, Pb: 390 } }, f = new h("jssor_1", j), k = 980; function a() { var d = f.kb.parentNode, b = d.clientWidth; if (b) { var e = c.min(k || b, b); f.Ze(e) } else g.setTimeout(a, 30) } a(); b.i(g, "load", a); b.i(g, "resize", a); b.i(g, "orientationchange", a) }
    })(window, document, Math, null, true, false)
</script>

<div id="jssor_1" style="position:relative;margin:0 auto;top:0px;left:0px;width:980px;height:700px;overflow:hidden;visibility:hidden;">
<!-- Loading Screen -->
<div data-u="loading" class="jssorl-009-spin" style="position:absolute;top:0px;left:0px;width:100%;height:100%;text-align:center;background-color:rgba(0,0,0,0.7);">
<img style="margin-top:-19px;position:relative;top:50%;width:38px;height:38px;" src="img/spin.svg" />
</div>
<div data-u="slides" style="cursor:default;position:relative;top:0px;left:0px;width:980px;height:700px;overflow:hidden;">
                   <asp:repeater  runat="server" ID="ads1"     >
                      <ItemTemplate>
                        <div>
                             <a target="_blank" href="<%# Container.DataItem %>"> <img  itemprop="image" alt="<%= dr.Item("title")%>" title="<%= dr.Item("title")%>"  data-u="image" src="<%#ChangeIfFilm( Container.DataItem) %>" /></a>
                              <img data-u="thumb" src="<%# ChangeIfFilm(Container.DataItem) %>" />
                        </div>
                      </ItemTemplate> 
                   </asp:repeater> 


<a data-u="any" href="https://www.jssor.com" style="display:none">javascript slider</a>
</div>
<!-- Thumbnail Navigator -->
<div data-u="thumbnavigator" class="jssort101" style="position:absolute;left:0px;bottom:0px;width:980px;height:100px;background-color:0 0;" data-autocenter="1" data-scale-bottom="0.75">
<div data-u="slides">
<div data-u="prototype" class="p" style="width:190px;height:90px;">
<div data-u="thumbnailtemplate" class="t"></div>
<svg viewbox="0 0 16000 16000" class="cv">
<circle class="a" cx="10000" cy="10000" r="3238.1"></circle>
<line class="a" x1="6190.5" y1="8000" x2="9809.5" y2="8000"></line>
<line class="a" x1="8000" y1="9809.5" x2="8000" y2="6190.5"></line>
</svg>
</div>
</div>
</div>
<!-- Arrow Navigator -->
<div data-u="arrowleft" class="jssora106" style="width:55px;height:55px;top:300px;left:30px;" data-scale="0.75">
<svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
<circle class="c" cx="8000" cy="8000" r="6260.9"></circle>
<polyline class="a" points="7930.4,5495.7 5426.1,8000 7930.4,10504.3 "></polyline>
<line class="a" x1="10573.9" y1="8000" x2="5426.1" y2="8000"></line>
</svg>
</div>
<div data-u="arrowright" class="jssora106" style="width:55px;height:55px;top:300px;right:30px;" data-scale="0.75">
<svg viewbox="0 0 16000 16000" style="position:absolute;top:0;left:0;width:100%;height:100%;">
<circle class="c" cx="8000" cy="8000" r="6260.9"></circle>
<polyline class="a" points="8069.6,5495.7 10573.9,8000 8069.6,10504.3 "></polyline>
<line class="a" x1="5426.1" y1="8000" x2="10573.9" y2="8000"></line>
</svg>
</div>
</div>
<script type="text/javascript">jssor_1_slider_init();</script>
<!-- #endregion Jssor Slider End -->

            </div>

<div id="test">
  
</div>


         
<br />
            <div class="bottomleft"  > 

                <div class="zir" >
   <i class="fa fa-angle-double-down" style="color:#9931cc; font-size:30;  vertical-align: -5px;" aria-hidden="true"></i>
      <h5>اطــلاعات تــماس آگـهی دهنده</h5>
    <div class="container" >
      <div class="row ">
        <div class="col-md-5  lftrit" style="padding-top: 10px;">
          
         
            <div class="bttn">
              
              <div class="telegram hvr-shrink">
                                    <span itemprop="author">

               <%=dr.Item("mobile").ToString%> <i class="fa fa-mobile" aria-hidden="true"></i>
                                        </span> 
              </div>

               <div class="telegram hvr-shrink">
                <asp:Label ID="lblEmail" Font-Size="XX-Small"  runat="server" Text=""></asp:Label>
                <i class="fa fa-envelope" aria-hidden="true"></i>

              </div>
               <div class="telegram hvr-shrink">
                <a href="https://telegram.me/<%=dr.Item("telegram").ToString.Replace("@","")%>"><%=dr.Item("telegram").ToString.Replace("@","")%></a>
                <i class="fa fa-send"></i>
              </div>

            </div>
        </div>
        <div class="col-md-7 lftlft " style="width: 100%; text-align: center;"> 

         
                     <div id="dvMap" style=" width:100%;  height:200px; ">    </div>

         
      </div>

      </div>
      
    </div>


  
  </div>
  
  </div>
  </div>
</div>

                <br />
                                            <div class="row" id="divEdit2" style="background-color:white " runat="server" >
                                 
                        <div class="col-xs-12 col-sm-4 col-md-4">
                             <a href="ads.aspx?Code=<%=dr.Item("prjId").ToString%>" target="_blank" >ویرایش </a>       
                        </div>
                        <div class="col-xs-12 col-sm-4 col-md-4">
                           <asp:LinkButton ID="lbtnDel" runat="server">حذف </asp:LinkButton>       
                                    
                        </div>
                        <div class="col-xs-12 col-sm-4 col-md-4">
                             <a href="offer.aspx" target="_blank" >خدمات ویژه</a>       
                                    
                        </div>
                    </div>


    <br />
    

    <span runat="server" id="spnSimilar" class="MyBtn">موارد مشابه:</span>
    <br />
                            <asp:repeater  runat="server" ID="rptSimilar"     >
                                            <ItemTemplate>
		<div class="col-md-4 col-sm-6 col-xs-12">

			<div class="ads" alt="<%# Eval("description")%>"    title ="<%# Eval("description")%>" >
                <div class="img-hover">
				<img width="100%"  height="240"  src="<%# getImage(Container.DataItem("prjid").ToString())%>">
                    <img id="image2" style="position: absolute; top: 0px; left: 0px; display:<%# DisplayIsFori(Container.DataItem("chkFori").ToString())%> " src="/img/fori3.png" />

                    <div class="overlay"><a href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"    ></a></div>
                </div>
				<div class="title-ads">
                    <h6><a  href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"   style="font-size:medium; font-weight:600; color:#0088c0 ;" ><%# Container.DataItem("title").ToString()%></a>                                  
                        
</h6>
                          
					<h6 class="price"><%# getPrice(Container.DataItem("Price").ToString())%></h6>

				</div>
				<div class="times-ads">
					<h6 class="location"><img src="/img/loc-ic.png"><span><%# Container.DataItem("CityName")%></span></h6>
					<h6 class="time"><%# general.getdatespan(Container.DataItem("insertDate").ToString())%></h5>
				</div>
				<div class="stars">
					<i class="<%# getEmptyOrFill(Container.DataItem("prjid").ToString())%>"></i>
                    <img src="/img/play.png" style="height:20px; width:20px; margin-top:-5px; display:<%# DisplayHasFilm(Container.DataItem("Filmdar").ToString())%> "  />

					                                                    <div style=" text-align:left; float:left ; padding-top:8px  " >
                                                     <%--<ajax:Rating id="tets2"  CurrentRating='<%# GetRate(Eval("rate"), Eval("rateCount"))%>' runat="server"  ReadOnly="true"   StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"></ajax:Rating>--%>
                                                      </div> 

				</div>
			</div>
            		</div>

                                                    </ItemTemplate> 
                                                </asp:repeater> 
    <br />
    <asp:TextBox ID="N"   Width="1px"  Height ="1px"  tooltip="مختصات" runat="server"></asp:TextBox><asp:TextBox ID="E"    Width="1px"  Height ="1px"   tooltip="مختصات" runat="server"></asp:TextBox>



</asp:Content>
