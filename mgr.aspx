<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="mgr.aspx.vb" Inherits="NewAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style>
        #close{
    position: absolute;
    top: -80px;
    left: 5%;
    width: 30px;
    margin : 10px;
    z-index: 2;
    
}

    </style>
        <script>


            function ValidatePicFile(sender, args) {
                var maxFileSize = 512; // 1MB -> 1 * 1024 – to check in KB – Kilo Bytes
                var fileUpload = document.getElementById("<%=fuPic.ClientID%>");
            var extOk = false;

            if (typeof (fileUpload.files) != "undefined") {
                    var ext = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
                    if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "gif" || ext == "bmp") {
                        extOk = true;

                    }


                var size = parseFloat(fileUpload.files[0].size / 1024).toFixed(2);
                if (size < maxFileSize & extOk) {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;
                }

            }
            else {
                alert("You have an outdated browser");

            }

        }
        function ValidateResumeFile(sender, args) {
            var maxFileSize = 3072; // 1MB -> 1 * 1024 – to check in KB – Kilo Bytes
            var fileUpload = document.getElementById("<%=fuResume.ClientID%>");
            var extOk = false;

            if (typeof (fileUpload.files) != "undefined") {
                    var ext = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
                    if (ext == "pdf") {
                        extOk = true;
                    }

                var size = parseFloat(fileUpload.files[0].size / 1024).toFixed(2);
                if (size < maxFileSize & extOk) {
                    args.IsValid = true;

                }
                else {
                    args.IsValid = false;
                }

            }
            else {
                alert("You have an outdated browser");

            }

        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />
    <div class="container">
<div class="row">

    <div  class="col-xs-12 col-sm-10 col-md-10">
<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        نام:
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">

    <asp:TextBox ID="txtName" CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
        </div> 
        <div  class="col-xs-12 col-sm-2 col-md-2">
        عکس:
    </div>
    <div  class="col-xs-12 col-sm-3 col-md-3">
        <asp:FileUpload ID="fuPic" runat="server" />

        </div> 
        <div  class="col-xs-12 col-sm-3 col-md-3">
                     <asp:CustomValidator ID="CustomValidator1" runat="server"  
                 ForeColor="Red" 
                    Text="سایز فایل از 512 کیلوبایت کمتر و با پسوندهای متعارف باشد" ToolTip="FileSize should not exceed 512kb" 
                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files." 
                    ControlToValidate="fuPic"  
                   ClientValidationFunction = "ValidatePicFile" />

</div> 
    </div> 
<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        ایمیل:
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:TextBox ID="txtEmail" CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        تلفن:
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:TextBox ID="txtTel" CssClass="textbox " TextMode="Number"  MaxLength="11" Width="100%" runat="server"></asp:TextBox>
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        موبایل:
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:TextBox ID="txtMobile" CssClass="textbox " TextMode="Number"  MaxLength="11" Width="100%" runat="server"></asp:TextBox>
    </div>
</div>
<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        نام کاربری:
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
       
        <asp:TextBox ID="txtUserName" CssClass="textbox "   Width="100%" runat="server"></asp:TextBox>

    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        کلمه عبور :
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
       
        <asp:TextBox ID="txtPass" CssClass="textbox "   Width="100%" runat="server"></asp:TextBox>

    </div>
        <div  class="col-xs-12 col-sm-2 col-md-2">
        تحصیلات :
    </div>

        <div class="col-xs-12 col-sm-2 col-md-2"  >
    <asp:TextBox ID="txtTahsilat"  CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
        </div> 

</div>
        <div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        آدرس:
    </div>
    <div  class="col-xs-12 col-sm-10 col-md-10">

    <asp:TextBox ID="txtAddress"  CssClass="textbox " Width="100%" runat="server"></asp:TextBox>
        </div> 
    </div>

        <div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:HyperLink ID="hlResume"    runat="server">  رزومه</asp:HyperLink>

    </div>
    <div  class="col-xs-12 col-sm-4 col-md-4">

    <asp:FileUpload ID="fuResume" runat="server" />
        </div> 
                <div  class="col-xs-12 col-sm-6 col-md-6">

                            <asp:CustomValidator ID="NewPasswordCustomValidator" runat="server"  
                 ForeColor="Red" 
                    Text="سایز فایل از 3 مگابایت کمتر و با پسوند پی دی اف باشد" ToolTip="FileSize should not exceed 1mb" 
                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files." 
                    ControlToValidate="fuResume"  
                   ClientValidationFunction = "ValidateResumeFile" />
</div> 
        
        </div> 
    </div>

    <div  class="col-xs-12 col-sm-2 col-md-2">
    <img  runat="server" id="pic" visible="false" height="100" width="75"  />
</div>


    </div> 
        <br />
                                    <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

<br />
<div runat="server" id="divPerms">
                سطوح دسترسی:

<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="chkEmail" Text="مدیریت آگهی" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="jobPerm" Text="مدیریت دسته بندی" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="userPerm" Text="مدیریت کاربران" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="offerPerm" Text="انتقادات و پیشنهادات" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="empPerm" Text="درخواست همکاری" runat="server" />
    </div>
</div>
<div class="row">
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="netPerm" Text="لینک شبکه های اجتماعی" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="faqPerm" Text="سوالات متداول" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
        <asp:CheckBox ID="delJobPerm" Text="حذف دسته بندی" runat="server" />
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
    </div>
    <div  class="col-xs-12 col-sm-2 col-md-2">
    </div>
</div>
 </div> 
        <center>
            <br /><br />
            <asp:Button ID="btnSave"  CssClass= "MyBtn " runat="server" Text="ثبت مدیر"></asp:Button>
            <br />
            </center>
    </div>
</asp:Content>

