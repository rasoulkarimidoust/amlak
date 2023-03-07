<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="Offer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <center>
        پیام به مدیر
    </center>
    <br />
    <div class="container " style="background-color:#f5f6f4 ">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />
    <div class="row">
    <div class="col-xs-12 col-sm-2 col-md-2 " style="text-align:center  "  >
        نام و نام خانوادگی:<uc1:help runat="server" ID="help" />
    </div> 
            <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtName" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div> 
            <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        ایمیل:<uc1:help runat="server" ID="help2" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtEmail" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div>
         
    </div>
    <div class="row">
    <div class="col-xs-12 col-sm-2 col-md-2 " style="text-align:center  "  >
        شماره تلفن ثابت:<uc1:help runat="server" ID="help1" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtTel" CssClass="textboxReq " Width="100%" runat="server"></asp:TextBox>
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  style="text-align:center  " >
        شماره موبایل:<uc1:help runat="server" ID="help3" />
    </div> 
    <div class="col-xs-12 col-sm-2 col-md-2"  >
        <asp:TextBox ID="txtMobile" CssClass="textboxReq " Width="100%"  runat="server"></asp:TextBox>
    </div> 
         
    </div>
        <div class="row">
        <div class="col-xs-12 col-sm-2 col-md-2" style="text-align:center "  >
           عنوان:<uc1:help runat="server" ID="help4" />
        </div> 
        <div class="col-xs-12 col-sm-10 col-md-10" style="text-align:center "  >
        <asp:TextBox ID="txttitle" CssClass="textboxReq "   Width="100%"  runat="server"></asp:TextBox>
        </div> 
        </div>
        <div class="row">
        <div class="col-xs-12 col-sm-2 col-md-2" style="text-align:center "  >
            متن پیام:<uc1:help runat="server" ID="help5" />
        </div> 
        <div class="col-xs-12 col-sm-10 col-md-10" style="text-align:center "  >
        <asp:TextBox ID="txtDescription" CssClass="textboxReq " TextMode ="MultiLine" Height="100px" Width="100%"  runat="server"></asp:TextBox>
        </div> 
        </div>
        <br /><br />
        <center>
            <asp:Button ID="btnSave" CssClass="MyBtn " runat="server" Text="ثبت"></asp:Button>
        </center>
        <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        </div>
</asp:Content>

