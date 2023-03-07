<%@ Page Title="" Language="VB" MasterPageFile="~/masterpage.master" AutoEventWireup="false" CodeFile="setting.aspx.vb" Inherits="setting" %>
    <%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container " style="min-height:400px">
        <br />
    <asp:DropDownList ID="ddSet" AutoPostBack="true" Width="300px"  CssClass="textbox " runat="server">
        <asp:ListItem Value="fileLogo">لوگوی صفحه اول</asp:ListItem>
        <asp:ListItem Value="htmlLaw">قوانین سایت</asp:ListItem>
        <asp:ListItem Value="htmlReg">مزایای عضویت</asp:ListItem>
        <asp:ListItem Value="htmlEmp">شرایط و مزایای همکاری</asp:ListItem>
        <asp:ListItem Value="htmlAbout">درباره ما</asp:ListItem>
        <asp:ListItem Value="htmlfaq">سوالات متداول</asp:ListItem>
        <asp:ListItem Value="htmlHelp">سایت چگونه کار میکند</asp:ListItem>
        <asp:ListItem Value="textExpDay">تعداد روز اعتبار آگهی</asp:ListItem>
        <asp:ListItem Value="textTelegram"> لینک تلگرام</asp:ListItem>
        <asp:ListItem Value="textFacebook"> لینک فیسبوک</asp:ListItem>
        <asp:ListItem Value="textInista"> لینک اینیستاگرام</asp:ListItem>
        <asp:ListItem Value="textLinkedIn"> لینک لینکدین</asp:ListItem>
        <asp:ListItem Value="autoAdsAutoCheckDate">تائید اتوماتیک آگهی ها</asp:ListItem>

    </asp:DropDownList>

   <br /><br />
       <asp:FileUpload ID="FileUpload1" runat="server" />
       <asp:TextBox ID="TextBox1" Visible="false" Height="240px" CssClass="textbox " TextMode="MultiLine"  Width="98%"   runat="server"></asp:TextBox>
    <div id="divAuto" runat="server" visible="false" >
                <asp:Label ID="lblDateTime" runat="server" Text=""></asp:Label><br />
            <asp:CheckBox ID="chkDate" Text="تائید اتوماتیک آگهی" runat="server"></asp:CheckBox> از الان تا 
            <asp:TextBox ID="txtDay" runat="server"></asp:TextBox> روز و <asp:TextBox ID="txtHour" runat="server"></asp:TextBox> ساعت دیگر
</div>
    <CKEditor:CKEditorControl ID="CKEditor1" Visible="false"  BasePath="/ckeditor/" runat="server" 
        Toolbar="Basic"  FullPage="False" Height="240px" DefaultLanguage="fa" 
            DialogButtonsOrder="Rtl"></CKEditor:CKEditorControl>
        </div> 

        <center>
            
            <asp:Button ID="btnUpdate" CssClass="MyBtn" runat="server" Text="بروزرسانی"></asp:Button>
            </center>

</asp:Content>

