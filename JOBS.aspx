<%@ Page Title="" Language="VB" MasterPageFile="~/masterpage.master" AutoEventWireup="false" CodeFile="JOBS.aspx.vb" Inherits="Service" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        مدیریت دسته بندی 
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
<%--    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
        NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
    <ParentNodeStyle Font-Bold="False" />--%>
    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
        VerticalPadding="0px" />
            </asp:TreeView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="msgBoxContent"  Runat="Server">
    <div runat="server" id="divStudent" visible="false" >
        <center>
        <br />
        <asp:TextBox  CssClass="textbox" ID="txtName" placeholder="نام دسته بندی"  runat="server"></asp:TextBox><br />
        <asp:Label ID="lblError"  runat="server" Text=""></asp:Label><br />
                                    <a href="Fields.aspx" target="_blank" >ویرایش فیلدها</a>
<br /><br />
        <asp:Button  CssClass="MyBtn" ID="btnSave" runat="server" Text="ویرایش" />
        <asp:Button  CssClass="MyBtn" ID="BtnDel1" runat="server" Text="حذف" />
            <br />
            <br />
        <asp:TextBox  CssClass="textbox" ID="txtChildName" placeholder="نام دسته بندی زیر مجموعه"  runat="server"></asp:TextBox><br />
            <br />
        <asp:Button  CssClass="MyBtn"  ID="btnAdd" runat="server" Text="اضافه" />
            </center>
           
    </div>
    <div  runat="server" id="divConfirm">
<center>
            <asp:Button  CssClass=" MyBtn "  ID="btnDel" runat="server" Text="حذف شود" />

</center>
    </div>
</asp:Content>

