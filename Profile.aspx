<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="KUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
            مشخصات من           
         
  
            </center>        
                        <br />
                    
            <div class="container "  style="background-color:#f5f6f4; text-align:center   " >
                <img alt="" width="100%" height="1px" style="   display: block;" src="TemplateWorld_files/lineb.png" />

        
            <br />
        
                         <div class="row">
                             
           <div class="col-xs-12 col-sm-4 col-md-4">نام و نام خانوادگی:</div>
                                         <div class="col-xs-12 col-sm-8 col-md-8">
                <asp:TextBox ID="txtName" CssClass="textbox"  Width="100%"      tooltip="نام و نام خانوادگی" runat="server"></asp:TextBox>
</div> 
                             
        </div>
                         <div class="row">
                             

                             
           <div class="col-xs-12 col-sm-4 col-md-4">ایمیل:</div>

            <div class="col-xs-12 col-sm-8 col-md-8">
                <asp:TextBox ID="txtEmail" CssClass="textbox" Width="100%"  tooltip="ایمیل" runat="server"></asp:TextBox>
                
</div>

</div> 
                         <div class="row">
           <div class="col-xs-12 col-sm-4 col-md-4">تلفن ثابت:</div>
                             
            <div class="col-xs-12 col-sm-8 col-md-8">
                <asp:TextBox ID="txtTel" CssClass="textbox" Width="100%"     tooltip="تلفن ثابت" runat="server"></asp:TextBox>
</div> 
                             
        </div>
                         <div class="row">
                             
          
                              <div class="col-xs-12 col-sm-4 col-md-4">موبایل:</div>

            <div class="col-xs-12 col-sm-8 col-md-8">
                
                <asp:TextBox ID="txtMobile" CssClass="textbox"  Width="100%"  tooltip="موبایل" runat="server"></asp:TextBox>
</div> 
                             </div>
                         <div class="row">
                             
                              <div class="col-xs-12 col-sm-4 col-md-4">آدرس:</div>
            <div class="col-xs-12 col-sm-8 col-md-8">
                <asp:TextBox ID="txtAddress" CssClass="textbox" Width="100%" ToolTip="آدرس"   runat="server"></asp:TextBox>
</div> 
                             </div>
                         <div class="row">
                              <div class="col-xs-12 col-sm-4 col-md-4">کلمه عبور :</div>
            <div class="col-xs-12 col-sm-8 col-md-8">

                <asp:TextBox ID="txtNewPass" CssClass="textbox"   TextMode="Password" Width="100%"    tooltip="کلمه عبور" runat="server"></asp:TextBox>
</div> 
                             
        </div>
                         <div class="row">
                             

                              <div class="col-xs-12 col-sm-4 col-md-4">تکرار کلمه عبور :</div>
            <div class="col-xs-12 col-sm-8 col-md-8">
               
                <asp:TextBox ID="txtNewPass2"  TextMode="Password" CssClass="textbox"  Width="100%"    tooltip="تکرار کلمه عبور"  runat="server"></asp:TextBox>

            </div> 

</div>

                         <div class="row">





                                                           <div class="col-xs-12 col-sm-4 col-md-4"> کد تائید:</div>


                                         <div class="col-xs-12 col-sm-2 col-md-2">
                                                             <asp:TextBox ID="txtCaptcha"  Width="100%"  CssClass="textbox"   tooltip="کد تائید" runat="server"></asp:TextBox>
                             </div>
                             <div class="col-xs-12 col-sm-2 col-md-2">
                       <img src="Captcha.aspx" />
                

            </div>
                             <div class="col-xs-12 col-sm-1 col-md-1">
                                 <asp:ImageButton ID="ImageButton1" ImageUrl="~/img/Refresh.png" Width="30px" runat="server" /></div> 

                             </div> 
                                    <br />
<br />
                                                                         <asp:Button  CssClass="MyBtn " ID="btnsave" runat="server" Text="ثبت" />

            <br /> 
 
             
                           &nbsp;<br />&nbsp; 
                                <img alt="" width="100%" height="1px" style="   display: block;" src="TemplateWorld_files/lineb.png" />

            </div>
                        

</asp:Content>

