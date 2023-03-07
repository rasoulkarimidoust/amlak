<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Mgrs.aspx.vb" Inherits="Mgrs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
       <div  runat="server" id="divConfirm">
<center>
            <asp:Button  CssClass="textbox" BackColor="#1559af" ForeColor="White" ID="btnDel" runat="server" Text="حذف شود" />

</center>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        مدیریت مدیران
    </center>
    <br />
    <div class="container " style="background-color:#f5f6f4 ">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="adminid">
        <Columns>
            <asp:BoundField DataField="AdminId" HeaderText="کد" />
            <asp:BoundField DataField="Name" HeaderText="نام مدیر" />
            <asp:BoundField DataField="UserName" HeaderText="نام کاربری" />
            <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
        </Columns>

    </asp:GridView>
        </div> 
</asp:Content>

