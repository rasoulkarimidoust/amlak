<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server">
            
    <style>
        .dropdown {
  background-image: url('<%=ResolveUrl("img/down.png") %>');
  background-position: 0px 0px;
  height:24px;
  width:180px;
  background-repeat: no-repeat;
  background-size:22px;
  padding-right:2px;
  font-size: 12px;
  border: 1px solid #ddd;
    -webkit-appearance: none;
                -webkit-border-radius: 10px;
             azimuth: 10px;
             border-radius: 10px;

}
.switch {
  position: relative;
  display: inline-block;
  width: 28px;
  height: 15px;
  top:5px;
}

.switch input {display:none;}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 10px;
  width: 10px;
  left: 4px;
  bottom: 3px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #9931cc;
}


input:checked + .slider:before {
  -webkit-transform: translateX(10px);
  -ms-transform: translateX(10px);
  transform: translateX(10px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 14px;
}

.slider.round:before {
  border-radius: 50%;
}
    </style>
    <script>
        var pageIndex = 1;
        var pageCount;
        function InfiniteScroll() {
            pageIndex++;
            
            $("#loader").show();
            // Async post back to the BindDataAsync code behind web method
            $.ajax({
                type: "POST",
                url: "Default.aspx/BindDataAsync",
                data: '{pageIndex: ' + pageIndex + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data != "") {
                   
                    // Take the results from the web service method and append them to the table
                    $('#divAds').append(data.d);
                    $("#loader").hide();
                }
            }
        });



            //send a query to server side to present new content
            //$.ajax({
            //    type: "POST",
            //    url: "Default.aspx/bind",
            //    data: "{}",
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (data) {
            //        if (data != "") {
            //            $('.divLoadData:last').after(data.d);
            //        }
            //        $('#divPostsLoader').empty();
            //    }
            //})
        };
        $(document).ready(function () {
            var win = $(window);

            // Each time the user scrolls
            win.scroll(function () {
                // End of the document reached?
                if ($(document).height() - win.height() == win.scrollTop()) {
                    InfiniteScroll();
                }
            });
        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cntTop" Runat="Server">
    
   <ul class="breadc">
<div  class="container-fluid" style="background-color:#ffffff">
	<li><i class="fa fa-home"></i></li>
           <div id="html1" style="display:inline "  runat="server" ></div> 
                                                           <asp:DropDownList AutoPostBack="true" style="border:0px solid #000"   ID="ddJobs"  runat="server">
                                                </asp:DropDownList>


</div>
</ul>
    <div  style="background-color:#f0f0f0" >
    <div  class="container ">
                    <br />
                            <div class="row">
 
            <div class="col-xs-12 col-sm-2 col-md-2   ">
                کلید واژه ها:
             </div> 
                                            <div class="col-xs-12 col-sm-4 col-md-4">
                <asp:TextBox ID="txtTags" CssClass="textbox "   Width="100%" runat="server"></asp:TextBox>                    
             </div> 
                                            <div class="col-xs-12 col-sm-1 col-md-1  ">
                قیمت از:
             </div> 
                                            <div class="col-xs-12 col-sm-2 col-md-2">
                <asp:TextBox ID="txtFrom" CssClass="textbox "  placeholder="به تومان" Width="100%" runat="server"></asp:TextBox>                    
             </div> 
            <div class="col-xs-12 col-sm-1 col-md-1">
                 تا:
             </div> 
                                            <div class="col-xs-12 col-sm-2 col-md-2">
                <asp:TextBox ID="txtUntil" CssClass="textbox "  placeholder="به تومان"  Width="100%" runat="server"></asp:TextBox>                    
                                                
             </div> 

                            </div> 
       
                            <asp:UpdatePanel ID="upFields" UpdateMode="Conditional"  runat="server"><ContentTemplate>
                        <div id="divFields"  runat="server" ></div>
            </ContentTemplate> </asp:UpdatePanel> 

       
        <br />
                        <center>
<asp:Button ID="btnSearch" CssClass="MyBtn"   runat="server" Text="جستجو" />&nbsp;&nbsp;
<asp:Button ID="btnClear" CssClass="MyBtn "   runat="server" Text="پاک کردن" />


                        </center>

              </div>  
<div class="container">
    	<div class="row">
		<div class="col-md-4 col-sm-6"><a class="menu-agahi" style="font-weight:bold " href="kads.aspx">آگهی های من</a></div>
		<div class="col-md-4 col-sm-6"><a class="menu-agahi" style="font-weight:bold "  href="neshan.aspx">نشان های من</a></div>
		<div class="col-md-4 col-sm-6"><a class="menu-agahi"  style="font-weight:bold " href="recent.aspx">بازدید های اخیر</a></div>
		<%--<div class="col-md-3 col-sm-6"><a class="menu-agahi"  style="font-weight:bold " href="login.aspx">ورود به پنل</a></div>--%>
	</div>
</div>
        </div>

    </asp:Content> 
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

                                <div  class="ads-cont-item">
                                <div class="col-xs-12 col-sm-5 col-md-3 ads-select-item">
                                                <asp:DropDownList ID="ddOrder" CssClass="dropdown " AutoPostBack="true"  runat="server">
                                                    <asp:ListItem Text="ترتیب نمایش" Value="InsertDate desc"></asp:ListItem>
                                                    <asp:ListItem Text="کمترین قیمت" Value="Price Asc"></asp:ListItem>
                                                    <asp:ListItem Text="بیشترین قیمت" Value="Price Desc"></asp:ListItem>
                                                    <asp:ListItem Text="محبوب ترین" Value="viewCount Desc"></asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                </div> 
            
            <div class="col-xs-6 col-sm-2 col-md-1 LeftAlighn  " style="font-size:medium ; color:black ">
                عکسدار:
</div> 
            <div class="col-xs-6 col-sm-1 col-md-1">
                <%--<asp:ImageButton ID="ibtnAx" ImageUrl="~/img/enable.png" CommandArgument="1" Height="25"  runat="server" />--%>
                <label class="switch">
                    <input  id="chkAx" runat="server"   onserverchange="Server_Changed" type="checkbox"  onclick="javascript: form1.submit();"  value= "1" name="Test" data-label="test"   enableviewstate="true"  />
                    <span class="slider round"></span>
                </label>

                </div> 
            <div class="col-xs-6 col-sm-2 col-md-1 LeftAlighn  " style="font-size:medium ; color:black ">
                فیلم دار:
            </div> 
            <div class="col-xs-6 col-sm-1 col-md-1">
                    <%--<asp:ImageButton ID="ibtnFilm" ImageUrl="~/img/disable.png" CommandArgument="0" Height="25"  runat="server" />--%>
               <label class="switch">
                    <input  id="chkFilm" runat="server"   onserverchange="Server_Changed" type="checkbox"  onclick="javascript: form1.submit();"  value= "1" name="Test" data-label="test"   enableviewstate="true"  />
                    <span class="slider round"></span>
                </label>
            </div> 
            <div class="col-xs-6 col-sm-2 col-md-1 LeftAlighn  " style="font-size:medium ; color:black ">
                فوری:
            </div> 
            <div class="col-xs-6 col-sm-1 col-md-1">
                    <%--<asp:ImageButton ID="ibtnFori" ImageUrl="~/img/disable.png" CommandArgument="0" Height="25"  runat="server" />--%>
                                <label class="switch">
                    <input  id="chkFori" runat="server"   onserverchange="Server_Changed" type="checkbox"  onclick="javascript: form1.submit();"  value= "1" name="Test" data-label="test"   enableviewstate="true"  />
                    <span class="slider round"></span>
                </label>
            </div> 
            <div class="col-xs-6 col-sm-2 col-md-1 LeftAlighn  " style="font-size:medium ; color:black ">
                نو:
            </div> 
            <div class="col-xs-6 col-sm-1 col-md-1">
                    <%--<asp:ImageButton ID="ibtnNo" ImageUrl="~/img/disable.png" CommandArgument="0" Height="25"  runat="server" />--%>
                                <label class="switch">
                    <input  id="chkNew" runat="server"   onserverchange="Server_Changed" type="checkbox"  onclick="javascript: form1.submit();"  value= "1" name="Test" data-label="test"   enableviewstate="true"  />
                    <span class="slider round"></span>
                </label>
            </div> 
            <div class="col-xs-6 col-sm-1 col-md-1 LeftAlighn ">
                    <asp:ImageButton ID="ibtnView" Visible="false"  ImageUrl="~/img/row.png" CommandArgument="1" Height="30"  runat="server" />
            </div> 

                            </div>




    <asp:Label ID="lblNoAds"  Visible="false"  runat="server" Text="موردی یافت نشد."></asp:Label>
    <div id="divAds">
                            <asp:repeater  runat="server" ID="rptThumb"     >
                                            <ItemTemplate>
		<div class="col-md-3 col-sm-6 col-xs-12">

			<div class="ads" alt="<%# Eval("description")%>"    title ="<%# Eval("description")%>" >
                <div class="img-hover">
				<img width="100%"  height="200"  src="<%# getImage(Container.DataItem("prjid").ToString())%>">
                    <img id="image2" style="position: absolute; top: 0px; left: 0px; display:<%# DisplayIsFori(Container.DataItem("chkFori").ToString(),Container.DataItem("InsertDate").ToString())%> " src="img/fori3.png" />

                    <div class="overlay"><a href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"     ></a></div>
                </div>
				<div class="title-ads" style="height: 100px;">
                    <h6><a  href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"   style="font-size:medium; font-weight:600; color:#0088c0 ;" ><%# Container.DataItem("title").ToString()%></a>                                  
                        
</h6>
                          
					<h6 class="price" style=" color:black "><%# Container.DataItem("PriceText").ToString()%> تومان</h6>

				</div>
				<div class="times-ads">
					<h6 class="location"><img src="img/loc-ic.png"><span><%# getLocation(Container.DataItem("SectorCode").ToString ,Container.DataItem("CityName"))%></span></h6>
					<h6 class="time"  style="font-weight:bold " ><%# general.getdatespan(Container.DataItem("insertDate").ToString())%></h5>
				</div>
				<div class="stars">
                    <asp:LinkButton Font-Size="X-Large"  CssClass=<%# getEmptyOrFill(Container.DataItem("prjid").ToString())%> ID="lbtnNeshan" ForeColor="#843fb8"  OnClick="lbtnNeshan_Click"  CommandArgument=<%# Eval("prjid").ToString()%> runat="server"><i ></i></asp:LinkButton>
                    <img src="img/play.png" style="height:20px; width:20px; margin-top:-5px; display:<%# DisplayHasFilm(Container.DataItem("Filmdar").ToString())%> "  />
					                                                    <div style=" text-align:left; float:left; padding-top:8px  " >
                                                      <%# GetRate(Eval("rate"), Eval("rateCount"))%>
                                                      </div> 

				</div>
			</div>
            		</div>

                                                    </ItemTemplate> 
                                                </asp:repeater> 
	</div>
    <center>
      <img id="loader" alt="" height="40" src="img/loading.gif" style="display: none" />
        </center>
                            <asp:repeater  runat="server" ID="rptRow"     >
                                            <ItemTemplate>
		<div class="row">

			<div class="adsRow" alt="<%# Eval("description")%>"    title ="<%# Eval("description")%>" >
                <div class="img-hover col-xs-12 col-sm-4 col-md-4">
				<img width="400"  height="240"  src="<%# getImage(Container.DataItem("prjid").ToString())%>">
                    <img id="image2" style="position: absolute; top: 0px; left: 0px; display:<%# DisplayIsFori(Container.DataItem("chkFori").ToString(),Container.DataItem("InsertDate").ToString())%> " src="img/fori3.png" />

                    <div class="overlay"><a href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"     ></a></div>
                </div>
                <div class="col-xs-12 col-sm-8 col-md-8">
				<div class="title-ads" style="height:300px">
                    <h6><a  href="/<%# Container.DataItem("prjid").ToString()%>/<%#General.GetStandardLink(Container.DataItem("title").ToString())%>"    style="font-size:medium; font-weight:600; color:#0088c0 ;" ><%# Container.DataItem("title").ToString()%></a>                                  
                        
</h6>
     <h6 ><%# Eval("description")%></h6>                     
     <h6><%# Eval("TechDesc")%></h6>   
					<h6 class="price"  style=" color:black "><%# Container.DataItem("PriceText").ToString()%> تومان</h6>

				</div>
				<div class="times-ads">
					<h6 class="location"><img src="img/loc-ic.png"><span><%# getLocation(Container.DataItem("SectorCode").ToString ,Container.DataItem("CityName"))%></span></h6>
					<h6 class="time" style="font-weight:bold " ><%# general.getdatespan(Container.DataItem("insertDate").ToString())%></h5>
				</div>
				<div class="stars">
                    <asp:LinkButton ID="lbtnNeshan" ForeColor="#843fb8"  CommandArgument=<%# Container.DataItem("prjid").ToString()%>  OnClick="lbtnNeshan_Click" runat="server"><i class="<%# getEmptyOrFill(Container.DataItem("prjid").ToString())%>"></i></asp:LinkButton>
					
                    <img src="img/play.png" style="height:20px; width:20px; margin-top:-5px; display:<%# DisplayHasFilm(Container.DataItem("Filmdar").ToString())%> "  />
					                                                    <div style=" text-align:left; float:left; padding-top:8px  " >
                                                                            <%# GetRate(Eval("rate"), Eval("rateCount"))%>
                                                      </div> 

				</div>
                    </div>
			</div>
            		</div>

                                                    </ItemTemplate> 
                                                </asp:repeater> 
	






	
	





</asp:Content>

