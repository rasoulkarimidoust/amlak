<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>کی چی پو</title>
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
	<link rel="stylesheet" type="text/css" href="css/bootstrap.css">
	<link rel="stylesheet" type="text/css" href="css/bootstrap-rtl.css">
  <link rel="stylesheet" type="text/css" href="css/font-awesome.css">
	<link rel="stylesheet" type="text/css" href="style2.css">
<style>
                    .textbox
        {
            Width:80%;
             font-family:'IRANSans',Tahoma ;
             font-size:small  ;
             height:30px;
              font-weight:bold ;
              -webkit-border-radius: 6px;
             azimuth: 6px;
             border-radius: 6px;
             color:#555 ;
        }

    * {
  box-sizing: border-box;
}
#myInput {
  background-image: url('/img/combo.png');
  background-position: 0px 0px;
  background-repeat: no-repeat;
  background-size:100%;
  width: 100%;
  font-size: 16px;
  padding:  12px 60px 12px 40px;
  border: 1px solid #ddd;
  margin-bottom: 12px;
}

#myUL {
  list-style-type: none;
  padding: 0;
  margin: 0;
}

#myUL li a {
  border: 1px solid #ddd;
  margin-top: -1px; /* Prevent double borders */
  background-color: #f6f6f6;
  padding: 12px;
  text-decoration: none;
  font-size: 18px;
  color: black;
  display: block
}

#myUL li a:hover:not(.header) {
  background-color: #eee;
}



#myInput1 {
  background-image: url('/img/combo1.png');
  background-position: 0px 0px;
  background-repeat: no-repeat;
  background-size:100%;
  width: 100%;
  font-size: 16px;
  padding:  12px 60px 12px 40px;
  border: 1px solid #ddd;
  margin-bottom: 12px;
}

#myUL1 {
  list-style-type: none;
  padding: 0;
  margin: 0;
}

#myUL1 li a {
  border: 1px solid #ddd;
  margin-top: -1px; /* Prevent double borders */
  background-color: #f6f6f6;
  padding: 12px;
  text-decoration: none;
  font-size: 18px;
  color: black;
  display: block
}

#myUL1 li a:hover:not(.header) {
  background-color: #eee;
}

</style> 
    <script type="text/javascript" src="js/keyboard.js" charset="UTF-8"></script>
 <link rel="stylesheet" type="text/css" href="css/keyboard.css">

    <script>

        function lostFocus() {
            document.getElementById("divlist").style.display = "none";
        }
        function onFocus() {
            document.getElementById("divlist").style.display = "";
        }
        function setText(a) {
            document.getElementById("myInput").value = $(a).text();
        }
        function myFunction() {
            var input, filter, ul, li, a, i;
            var fnd = 0;
            input = document.getElementById("myInput");
            document.getElementById("divlist").style.display = "";
            filter = input.value.toUpperCase();
            ul = document.getElementById("myUL");
            li = ul.getElementsByTagName("li");
            li[0].style.display = "none";
            for (i = 1; i < li.length; i++) {
                a = li[i].getElementsByTagName("a")[0];
                if (a.innerHTML.toUpperCase().indexOf(filter)==0) {
                    fnd = 1;
                    li[i].style.display = "";
                } else {
                    li[i].style.display = "none";
                }

            }
            if (fnd==0)
                li[0].style.display = "";

        }
        function lostFocus1() {
            document.getElementById("divlist1").style.display = "none";
        }
        function onFocus1() {
            document.getElementById("divlist1").style.display = "";
        }
        function setText1(a) {
            document.getElementById("myInput1").value = $(a).text();
        }
        function myFunction1() {
            var input, filter, ul, li, a, i;
            var fnd = 0;
            input = document.getElementById("myInput1");
            document.getElementById("divlist1").style.display = "";
            filter = input.value.toUpperCase();
            ul = document.getElementById("myUL1");
            li = ul.getElementsByTagName("li");
            li[0].style.display = "none";
            for (i = 1; i < li.length; i++) {
                a = li[i].getElementsByTagName("a")[0];
                if (a.innerHTML.toUpperCase().indexOf(filter) == 0) {
                    fnd = 1;
                    li[i].style.display = "";
                } else {
                    li[i].style.display = "none";
                }

            }
            if (fnd == 0)
                li[0].style.display = "";

        }

</script>
</head>
<body>
<form id="form1" runat="server" defaultbutton="btnSearch">

<nav class="navbar navbar-toggleable-md navbar-light bg-faded" style="background-color:white  ">
  <button class="navbar-toggler navbar-toggler-left" type="button" data-toggle="collapse" data-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>   
         <a class="navbar-brand" href="#"><img src="img/logo.png"></a>

	<span class=" sabt">
        <a class=" sabta" href="neshan.aspx">سبد خرید</a>
    </span>
  <div class="collapse navbar-collapse" id="navbarText">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" style="color:green " href="https://blog.kichipoo.com/lifePlus">زندگی مثبت</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" style="color:black " href="default.aspx">قوانین و مقررات</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" style="color:black "  href="show.aspx?FN=about">درباره ما</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" style="color:black "  href="login.aspx">ورود</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" style="color:black "  href="profile.aspx">ثبت نام</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link"  style="color:black " href="https://weblog.kichipoo.com">بلاگ</a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" style="color:black "  href="map.aspx">نقشه</a>
      </li>

      <li class=" sabt">
        <a class=" sabta" href="neshan.aspx">سبد خرید</a>
      </li>          
    </ul>
  </div>
</nav>


		<br />
    <br />
<div class="container">
    <center>
        <img src="img/MainLogo.png" height="200" /><br />
<asp:TextBox ID="txtSearch"  runat="server"  style="width:80%; height:40px"  class="keyboardInput"></asp:TextBox>
        </center>
	</div>
    <div class=" t-search">
        <asp:LinkButton CssClass="search-btn" ID="btnAds" runat="server">آگهی های خاص</asp:LinkButton>

        &nbsp;&nbsp;

        <asp:LinkButton CssClass="search-btn" ID="btnSearch" runat="server">جستجو</asp:LinkButton>

	      </div>
		


<%--	<footer>
<div class="opacit">
<div class="container-fluid">
	
	<div class="row">
		<div class="col-md-1"><center></center></div>
		<div class="col-md-6">

		<ul class="footer">
			<a  target="_blank" href="show.aspx?FN=Law"><li>قوانین سایت</li></a>
			<a  target="_blank" href="show.aspx?FN=help"><li>راهنما</li></a>
		</ul>

		</div>
        
		<div class="col-md-3 hidden-xs-down">
		
		
		<div class="sosials">
		<ul class="sos">
			<a href="<%=dr4Ind.Item("telegram")%>"><li><i class="fa fa-send"></i></li></a>
			<a href="<%=dr4Ind.Item("facebook")%>"><li><i class="fa fa-facebook"></i></li></a>
			<a href="<%=dr4Ind.Item("inista")%>"><li><i class="fa fa-instagram"></i></li></a>
			<a href="<%=dr4Ind.Item("linkedin")%>"><li><i class="fa fa-linkedin"></i></li></a>

		</ul>
</div>

		

		</div>

		<div class="col-md-2 hidden-xs-down">
		<div class="apps">
		<a href="#"><img src="img/android.png"></a><br />
		<a href=""><img src="img/ios.png"></a><br />
		
		</div>
</div>
        
	</div>

</div>
</div>
</footer>--%>

<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/bootstrap.js" type="text/javascript"></script>

    </form> 
</body>
</html>