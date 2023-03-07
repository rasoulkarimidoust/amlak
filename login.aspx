<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <center>

    <div id="divLogin" class="LoginBox" style="background-color:white; width:400px; ">
            <center>
                <br />
                <asp:Label ID="lblLogin" runat="server" Text="نام کاربری:"></asp:Label><br />
                <asp:TextBox ID="txtLogin" runat="server" CssClass="textbox" ></asp:TextBox><br />
                <asp:Label ID="Label1" runat="server" Text="کلمه عبور:"></asp:Label><br />
                <asp:TextBox ID="txtPass" TextMode="Password"  runat="server" CssClass="textbox" ></asp:TextBox>

               <br /><br />
                                <asp:Button ID="BtnLogin" CssClass="MyBtn "   runat="server" Text="ورود"></asp:Button>
<br />
<%--                 <asp:TextBox ID="txtPass" TextMode="Password"  placeholder="کلمه عبور" runat="server" CssClass="textbox"></asp:TextBox>

                <br />--%>
                <a  href="FPass.aspx"  style=" font-size:xx-small ; color:darkblue  ">گذرواژه‌تان را فراموش‌ کرده‌اید؟</a>
                <br />
               
                <a  href="Profile.aspx"  style=" font-size:xx-small ; color:darkblue  ">عضویت</a>&nbsp;
                <a  href="show.aspx?FN=Reg"  style=" font-size:xx-small ; color:darkblue  ">مزایای عضویت</a>
                <br />
                <asp:Label ID="lblMessage" runat="server" Font-Size="Large"></asp:Label>
            </center>
        </div>
        </center>
</asp:Content>

