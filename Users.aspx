<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Users" %>

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
        مدیریت کاربران
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="karfarmaId">
        <Columns>
            <asp:BoundField DataField="karfarmaId" HeaderText="کد" />
            <asp:BoundField DataField="Name" HeaderText="نام کاربر" />
            <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
        </Columns>

    </asp:GridView>
</asp:Content>

