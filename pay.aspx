<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="pay.aspx.vb" Inherits="pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <br />
    <center>
        پرداخت هزینه
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
    <br /><br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
        <asp:ListItem Value="5000">فوری (به مبلغ 5000 تومان)</asp:ListItem>
        <asp:ListItem Value="2000">نردبان (به مبلغ 2000 تومان)</asp:ListItem>
        <asp:ListItem Value="6000">فوری و نردبان(به مبلغ 6000 تومان)</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <center>
    <asp:Button ID="btnPay" CssClass="MyBtn " runat="server" Text="پرداخت" />
    <asp:Button ID="btnBack" CssClass="MyBtn " runat="server" Text="برگشت" />
    </center>
</asp:Content>

