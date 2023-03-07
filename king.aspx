<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="king.aspx.vb" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
     <div class="container">   
     <div id="divMenuAdmin" runat="server"  visible="false" >
       
        		<div id="divAds" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="prjManage.aspx" > مدیریت آگهی</a>
        </div> 
        <div id="divJob" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
            <a href="jobs.aspx"  >مدیریت دسته بندی</a>
        </div> 
        <div  id="divnet" runat="server" class="col-md-4 col-sm-6 col-xs-12">
        <a href="setting.aspx"   > تنظیمات</a>
        </div> 
       


        <div class="col-md-4 col-sm-6 col-xs-12">
        <a  id="divMgrs1" runat="server"  href="mgrs.aspx"> مدیریت مدیران</a>
        </div> 
                 <div  id="divMgrs2" runat="server" class="col-md-4 col-sm-6 col-xs-12">
        <a  href="mgrsState.aspx" >گزارش عملکرد مدیران</a>
        </div> 
        <div  id="divMgrs3" runat="server" class="col-md-4 col-sm-6 col-xs-12">
        <a  href="mgr.aspx" >ثبت مدیر جدید</a>
        </div> 

        <div   id="divUser" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="users.aspx"> مدیریت کاربران</a>
        </div> 
        <div id="divContact1" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="contacts.aspx" > پیغامها</a>
        </div> 

        <div  id="divContact2" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="contactsArchived.aspx" >پیغامهای بایگانی</a>
        </div> 

        <div  id="divOffer1" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="offers.aspx" >مشاهده انتقادات و پیشنهادات</a>
        </div> 
        <div  id="divOffer2" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="offersOK.aspx" >مشاهده انتقادات و پیشنهادات تائیدشده</a>
        </div> 
        <div  id="divOffer3" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="offersArchived.aspx" >مشاهده انتقادات و پیشنهادات بایگانی</a>
        </div> 
        <div  id="divEmp1" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="emps.aspx" >مشاهده درخواست همکاری</a>
        </div> 
        <div  id="divEmp2" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="empsok.aspx" > درخواست همکاری تائید شده</a>
        </div> 

        <div   id="divEmp3" runat="server"  class="col-md-4 col-sm-6 col-xs-12">
        <a href="empsArchived.aspx" > درخواست همکاری بایگانی شده</a>
        </div> 

        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="ReportedAds.aspx" >آگهی های گزارش شده</a>
        </div> 
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="mgr.aspx?pr=1"> پروفایل من</a>
        </div> 

        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="logout.aspx" >خروج</a>
        </div> 
    </div>
    <div id="divMenuKarfama" runat="server"  visible="false" style="  height:100%" >
      <div class="row">  
<%--        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="ads.aspx">ثبت آگهی جدید</a>
        </div> 
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="Neshan.aspx" >آگهی های نشان شده من</a>
        </div> 
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="Recent.aspx" >بازدیدهای اخیر</a>
        </div> 
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="KAds.aspx" >آگهی های من</a>
        </div> --%>
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="Profile.aspx">پیامهای بینندگان آگهی</a>
        </div>        
           <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="Profile.aspx">تغییر رمز</a>
        </div> 
        <div class="col-md-4 col-sm-6 col-xs-12">
        <a href="Profile.aspx"> پروفایل من</a>
        </div> 

      </div> 
    </div>
    <div id="divMenuGeneral" runat="server"  visible="false" >
        لطفا وارد پنل کاربری خود شوید
            </div> 
         </div> 
</asp:Content>

