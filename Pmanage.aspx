<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Pmanage.aspx.vb" Inherits="Pmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
    <div id="divConfirm" runat="server" >
        آیا از حذف پیمانکار به شماره 
        <asp:Label ID="lblPeymankar" runat="server" Text=""></asp:Label>
         مطمئن هستید؟
        <br /><br />
        <asp:Button ID="btnDel" runat="server" Text="حذف شود" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="peymankarId" HeaderText="کد پیمانکار" />
                                                <asp:TemplateField HeaderText="نام پیمانکار" >
    <ItemTemplate>
        <%#"<a target='_blank' href='PUpdate.aspx?pid=" + Eval("peymankarId").ToString() + "'>" + Eval("Name").ToString() + "</a>"%>

    </ItemTemplate>
</asp:TemplateField>

            <asp:BoundField DataField="CoName" HeaderText="نام شرکت" />
            <asp:CommandField SelectText="تائید" ShowSelectButton="True" />
            
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
            
        </Columns>
    </asp:GridView>
</asp:Content>

