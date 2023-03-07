<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Kmsg.aspx.vb" Inherits="Kmsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .hideGridColumn
    {
        display:none;
    }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
    <div id="divExtra" runat="server" >
            <asp:TextBox ID="txtKComment" CssClass="textbox " TextMode="MultiLine"  Height="100px" Width="100%"   runat="server"></asp:TextBox>
        <br />
        <center>
    <asp:Button ID="btnSaveComment" CssClass="textbox "   runat="server" Text="ثبت" />
            </center>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
    <br />
    <center>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField  DataField="ChatID" HeaderText="کد" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
            <asp:BoundField DataField="peymankarId" HeaderText="کد پیمانکار"  HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
            <asp:BoundField DataField="PRJID" HeaderText="کد پروژه"  HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
            <asp:BoundField DataField="title" HeaderText="عنوان" />
            <asp:BoundField DataField="PeymankarName" HeaderText="نام پیمانکار" />
            <asp:BoundField ItemStyle-Width="50%" DataField="text" HeaderText="متن سوال" />
            <asp:CommandField SelectText="ثبت پاسخ" ShowSelectButton="True" />

        </Columns>
    </asp:GridView>
        </center>

</asp:Content>

