<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="KPrj.aspx.vb" Inherits="KAds" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.ratingEmpty
{
background-image: url(img/ratingStarEmpty.png);
width:18px;
height:18px;
}
.ratingFilled
{
background-image: url(img/ratingStarFilled.png);
width:18px;
height:18px;
}
.ratingSaved
{
 background-image: url(img/ratingStarSaved.gif);
width:18px;
height:18px;
}

</style>
    <script>
        function hide() {
            document.getElementById('divComment').style.display = 'none';

        }
        function show() {
            document.getElementById('divComment').style.display = 'inline';

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
<div id="divRate" runat="server" >
    <asp:RadioButton ID="rbEnd" Checked="true"   onclick="show();"   Text="اتمام پروژه" GroupName="rb1" runat="server" />
    <asp:RadioButton ID="rbCancelAndDelete"   onclick="hide();"  Text="کنسل" GroupName="rb1"  runat="server" />
    <asp:RadioButton ID="rbCancelAndContinue"  onclick="hide();" Text="کنسل و آگهی مجدد" GroupName="rb1"  runat="server" />
    <div id="divComment">
    
<asp:UpdatePanel ID="pnlRating" runat="server">
<ContentTemplate>
                <div class="container"  style="width:100%">
                            <div class="row">
            
            <div class="col-xs-12 col-sm-7 col-md-7">
سرعت عمل:
</div> 
<div class="col-xs-10 col-sm-4 col-md-4">
<ajax:Rating ID="ratingControl1" AutoPostBack="true" runat="server"  OnChanged="ratingControl1_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
</div> 
<div class="col-xs-2 col-sm-1 col-md-1">
 <asp:label ID="Label1" runat="server"/> 
</div> 
</div> 
<div class="row">
                        <div class="col-xs-12 col-sm-7 col-md-7">

انعطاف پذیر نسبت به نظرات کارفرما:
</div> 
<div class="col-xs-10 col-sm-4 col-md-4">
<ajax:Rating ID="ratingControl2" AutoPostBack="true" runat="server"  OnChanged="ratingControl2_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
</div> 
<div class="col-xs-2 col-sm-1 col-md-1">
 <asp:label ID="Label2" runat="server"/> 
    </div>

</div> 
<div class="row">
                        <div class="col-xs-12 col-sm-7 col-md-7">
میزان دانش و حرفه ای بودن :
</div> 
 <div class="col-xs-10 col-sm-4 col-md-4">

    <ajax:Rating ID="ratingControl3" AutoPostBack="true" runat="server"  OnChanged="ratingControl3_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
    </div> 
         <div class="col-xs-2 col-sm-1 col-md-1">
        <asp:label ID="Label3" runat="server"/> 
             </div> 
</div> 
                    <div class="row">

                            <div class="col-xs-12 col-sm-7 col-md-7">

کیفیت کار:
</div> 
<div class="col-xs-10 col-sm-4 col-md-4">

<ajax:Rating ID="ratingControl4" AutoPostBack="true" runat="server"  OnChanged="ratingControl4_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
</div> 
                                        <div class="col-xs-2 col-sm-1 col-md-1">
                                                                    <asp:label ID="Label4" runat="server"/> 
                                            </div> 
                        </div> 
                    <div class="row">

             <div class="col-xs-12 col-sm-7 col-md-7">

قیمت کار :
</div> 
       <div class="col-xs-10 col-sm-4 col-md-4">

<ajax:Rating ID="ratingControl5" AutoPostBack="true" runat="server"  OnChanged="ratingControl5_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
</div> 
                                        <div class="col-xs-2 col-sm-1 col-md-1">

 <asp:label ID="Label5" runat="server"/>

                                        </div> 
                        </div> 
                    <div class="row">

            <div class="col-xs-12 col-sm-7 col-md-7">

قابل اعتماد بودن پیمانکار :
</div> 
                    <div class="col-xs-10 col-sm-4 col-md-4">

                        <ajax:Rating ID="ratingControl6" AutoPostBack="true" runat="server"  OnChanged="ratingControl6_Changed" StarCssClass="ratingEmpty" WaitingStarCssClass="ratingSaved" EmptyStarCssClass="ratingEmpty" FilledStarCssClass="ratingFilled">
</ajax:Rating>
                                            </div> 
                                    <div class="col-xs-2 col-sm-1 col-md-1">
    <asp:label ID="Label6" runat="server"/> 
                                            </div> 
                        </div> 
                    </div> 
    
</ContentTemplate>
</asp:UpdatePanel>
   نظر کارفرما:
        <br />
    <asp:TextBox ID="txtKComment" CssClass="textbox " TextMode="MultiLine" Height="60" Width="100%"  tooltip="نظر کارفرما" runat="server"></asp:TextBox>

        </div>
    <asp:Button ID="btnSaveComment" CssClass="textbox "    runat="server" Text="ثبت" />
    
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="PRJID" HeaderText="کد" />
            <asp:BoundField DataField="title" HeaderText="عنوان" />
            <asp:BoundField DataField="modateEjra" HeaderText="مدت زمان اجرا" />
            <asp:CommandField SelectText="ثبت اتمام یا کنسل و نمره" ShowSelectButton="True" />

        </Columns>
    </asp:GridView>
        </center>
</asp:Content>

