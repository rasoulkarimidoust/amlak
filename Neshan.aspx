<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Neshan.aspx.vb" Inherits="Neshan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        آگهی های نشان شده
    </center>
    <br />
    <div class="container ads-cont">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
        <asp:LinkButton ID="lbtnDelcookie" runat="server">حذف همه</asp:LinkButton>
	<div class="row">
                            <asp:repeater  runat="server" ID="ads1"     >
                                            <ItemTemplate>
		<div class="col-md-4 col-sm-6 col-xs-12">

			<div class="ads">
                <div class="img-hover">
				<img width="100%"  height="240"  src="<%# getImage(Container.DataItem("prjid").ToString())%>">
                    <img id="image2" style="position: absolute; top: 0px; left: 0px; display:<%# DisplayIsFori(Container.DataItem("chkFori").ToString())%> " src="img/fori3.png" />

                    <div class="overlay"><a href="AdsView.aspx?prjid=<%# Container.DataItem("prjid").ToString()%>"    ></a></div>
                </div>
				<div class="title-ads" style="height: 120px;">
                    <h6><a  href="AdsView.aspx?prjid=<%# Container.DataItem("prjid").ToString()%>"   style="font-size:medium; font-weight:600; color:#0088c0 ;" ><%# Container.DataItem("title").ToString()%></a>                                  
                        
</h6>
                          
					<h6 class="price" style=" color:black "><%# Container.DataItem("PriceText").ToString()%> تومان</h6>

				</div>
				<div class="times-ads">
					<h6 class="location"><img src="img/loc-ic.png"><span><%# getLocation(Container.DataItem("SectorCode").ToString ,Container.DataItem("CityName"))%></span></h6>
					<h6 class="time"  style="font-weight:bold " ><%# general.getdatespan(Container.DataItem("insertDate").ToString())%></h5>
				</div>
				<div class="stars">
					<i class="<%# getEmptyOrFill(Container.DataItem("prjid").ToString())%>"></i>
                    <img src="img/play.png" style="height:20px; width:20px; margin-top:-5px; display:<%# DisplayHasFilm(Container.DataItem("Filmdar").ToString())%> "  />
					                                                    <div style=" text-align:left; float:left; padding-top:8px  " >
                                                     <ajax:Rating id="tets"  CurrentRating='<%# GetRate(Eval("rate"), Eval("rateCount"))%>' runat="server"  ReadOnly="true"   StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled"></ajax:Rating>
                                                      </div> 

				</div>
                				<div class="title-ads">
                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButtonClick" CommandArgument=<%# Container.DataItem("prjid").ToString()%> runat="server">حذف</asp:LinkButton>
</div> 
			</div>
            		</div>

                                                    </ItemTemplate> 
                                                </asp:repeater>
        
        
        



	</div>

</div>
    <br />
                    <span ID="lblNoData" Visible="false" style="top:30px"  runat="server">موردی برای نمایش وجود ندارد</span>

</asp:Content>

