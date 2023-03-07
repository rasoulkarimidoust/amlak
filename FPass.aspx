<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FPass.aspx.vb" Inherits="FPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
    <br /><br />
    
   لطفا ایمیل خود را وارد کنید: 
        <br />
    <asp:TextBox ID="txtEmail" TextMode="Email"  runat="server"></asp:TextBox>
        <br />
        <br />
    <asp:Button ID="btnSend" CssClass="MyBtn " runat="server" Text="ارسال کلمه عبور" />
        </center>
</asp:Content>

