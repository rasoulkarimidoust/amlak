<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SetHelp4Controls.aspx.vb" Inherits="SetHelp4Controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    متن توضیحات:
    <br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="200" Width="100%"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="بروز رسانی" />
</asp:Content>

