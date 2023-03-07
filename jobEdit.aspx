<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="jobEdit.aspx.vb" Inherits="jobEdit" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container " style="min-height:400px">
        <br />
            نام شغل:
            <br />
        <asp:TextBox  CssClass="textbox" ID="txtName" placeholder="نام شغل"  runat="server"></asp:TextBox><br />
شغل پدر:<br />
        <asp:DropDownList  CssClass="textbox"  ID="ddJobs" placeholder="شغل پدر" runat="server"></asp:DropDownList><br />

   <br /><br />
    
    <CKEditor:CKEditorControl ID="CKEditor1"   BasePath="/ckeditor/" runat="server" 
        Toolbar="Basic"  FullPage="False" Height="240px" DefaultLanguage="fa" 
            DialogButtonsOrder="Rtl"></CKEditor:CKEditorControl>
        </div> 
        <center>
        <asp:ImageButton ID="btnUpdate" ImageUrl="~/images/btnUpdate.png" runat="server" />
            </center>


</asp:Content>

