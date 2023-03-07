<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="emp.aspx.vb" Inherits="collaboration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<%--    <script>


        function ValidatePicFile(sender, args) {
            var maxFileSize = 1024; // 1MB -> 1 * 1024 – to check in KB – Kilo Bytes
            var fileUpload = document.getElementById("<%=fuPic.ClientID%>");
            var extOk = false;

            if (typeof (fileUpload.files) != "undefined") {

                    var ext = fileUpload.value.substring(fileUpload.value.lastIndexOf('.') + 1).toLowerCase();
                    if (ext == "png" || ext == "jpg" || ext == "jpeg" || ext == "gif" || ext == "bmp") {
                        extOk = true;

                    }


                var size = parseFloat(fileUpload.files[0].size / 1024).toFixed(2);
                if (size < maxFileSize & extOk ) {
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
                    if (ext == "pdf" || ext=="doc" || ext=="docx" ) {
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

        }--%>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
    <center>
        درخواست همکاری
    </center>
    <br />
    <div class="container " style="background-color:#f5f6f4;font-size:medium ; ">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />

    <div  class="row">
    <div class="col-xs-12 col-sm-2 col-md-2 " style="text-align:center  "  >
        نام:<uc1:help runat="server" ID="help" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtName" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        نام خانوادگی:<uc1:help runat="server" ID="help1" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtLastName" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        نام پدر:<uc1:help runat="server" ID="help2" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtFatherName" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div>
         
    </div>
    <div class="row" >
    <div class="col-xs-12 col-sm-2 col-md-2 " style="text-align:center  "  >
       تلفن ثابت:<uc1:help runat="server" ID="help3" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtTel" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        شماره موبایل:<uc1:help runat="server" ID="help4" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtMobile" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        ایمیل:<uc1:help runat="server" ID="help5" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtEmail" CssClass="textboxReq " TextMode="Email"  Width="100%"  runat="server"></asp:TextBox>
    </div>
         
    </div>
        <div class="row">
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  "  >
        آدرس:<uc1:help runat="server" ID="help6" />
</div> 
    <div class="col-xs-12 col-sm-6 col-md-6"  >
        <asp:TextBox ID="txtAddress" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div>
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  "  >
        تحصیلات:<uc1:help runat="server" ID="help7" />
</div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:DropDownList ID="ddTahsilat"  CssClass="textbox " Width="100%"  runat="server">
            <asp:ListItem>دیپلم</asp:ListItem>
            <asp:ListItem>فوق دیپلم</asp:ListItem>
            <asp:ListItem>لیسانس</asp:ListItem>
            <asp:ListItem>فوق لیسانس</asp:ListItem>
            <asp:ListItem>دکترا</asp:ListItem>

        </asp:DropDownList>
    </div>

        </div>
            <div class="row" >
    <div class="col-xs-12 col-sm-2 col-md-2 " style="text-align:center  "  >
        شغل درخواستی:<uc1:help runat="server" ID="help8" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtjobtitle" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div> 
  
    </div>
        <div class="row">
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        فایل رزومه:<uc1:help runat="server" ID="help9" />
    </div> 
    <div class="col-xs-12 col-sm-4 col-md-4"  >
        <asp:FileUpload ID="fuResume"  Width="100%" runat="server" />
                    <asp:CustomValidator ID="NewPasswordCustomValidator" runat="server"  
                 ForeColor="Red" 
                    Text="سایز فایل از 3 مگابایت کمتر و با پسوندهای پی دی اف و ورد باشد" ToolTip="FileSize should not exceed 1mb" 
                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files." 
                    ControlToValidate="fuResume"  
                   ClientValidationFunction = "ValidateResumeFile" />

    </div> 
                <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        عکس :<uc1:help runat="server" ID="help10" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:FileUpload ID="fuPic" Width="100%" runat="server" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server"  
                 ForeColor="Red" 
                    Text="سایز فایل از 1 مگابایت کمتر و با پسوندهای متعارف باشد" ToolTip="FileSize should not exceed 1mb" 
                    ErrorMessage="FileSize Exceeds the Limits.Please Try uploading smaller size files." 
                    ControlToValidate="fuPic"  
                   ClientValidationFunction = "ValidatePicFile" />

    </div>
       
        </div>
        <div class="row">
        <div class="col-xs-12 col-sm-2 col-md-2" style="text-align:center "  >
            توضیحات:<uc1:help runat="server" ID="help11" />
        </div> 
        <div class="col-xs-12 col-sm-10 col-md-10" style="text-align:center "  >
        <asp:TextBox ID="txtDescription" CssClass="textboxReq " Width="100%" Height="100px"  runat="server"></asp:TextBox>
        </div> 
        </div>
        <br />
        <center>
            <asp:Button ID="btnSave" CssClass="MyBtn " runat="server" Text="ثبت"></asp:Button>
            <br />
            <a style="font-size:xx-small" href="Show.aspx?FN=Emp" target="_blank" >شرایط و مزایای همکاری</a>
        </center>
        <br />
                    <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        </div>
</asp:Content>

