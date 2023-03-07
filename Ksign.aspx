<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Ksign.aspx.vb" Inherits="Ksign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                            <div id="divLogin" class="MsgBox" style="background-color:white; ">
                    
            <center>
                <br />
                <br />

                <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" placeholder="نام کاربری"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPass" TextMode="Password"  placeholder="کلمه عبور" runat="server" CssClass="textbox"></asp:TextBox>

                <br />
                                <br />
                <asp:ImageButton ID="imgBtnLogin" runat="server"
                    ImageUrl="~/TemplateWorld_files/LoginButton.png" />
                <br />
<asp:HyperLink ID="HyperLink1" runat="server">ثبت نام نکردم ، میخواهم ثبت نام کنم</asp:HyperLink>

                <br />

                <asp:Label ID="lblMessage" runat="server" Font-Size="Large"></asp:Label>
            </center>
        </div>              

</asp:Content>

