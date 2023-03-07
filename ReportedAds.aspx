<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ReportedAds.aspx.vb" Inherits="prjManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
        <div id="divConfirm" runat="server" >
        تنظیمات مربوط به پروژه شماره: 
        <asp:Label ID="lblPrj" runat="server" Text=""></asp:Label>
        <br /><br />
            <asp:RadioButton Checked="true"  ID="rbPrj1" Text="نمایش در صفحه اول ، مورد اول" GroupName="rbPrj" runat="server" /><br /><asp:RadioButton Text="نمایش در صفحه اول ، مورد دوم"  GroupName="rbPrj"  ID="rbPrj2" runat="server" />
            <br /><br />
        <asp:Button ID="btnSave" runat="server" Text="ثبت" />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        آگهی های گزارش شده
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
        <br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="prjId" HeaderText="کد آگهی" HeaderStyle-CssClass="hideGridColumn " ItemStyle-CssClass="hideGridColumn " />
                                                            <asp:TemplateField HeaderText="عنوان آگهی" >
    <ItemTemplate>
        <%#"<a target='_blank' href='adsView.aspx?PrjId=" + Eval("prjId").ToString() + "'>" + Eval("title").ToString() + "</a>"%>

    </ItemTemplate>
</asp:TemplateField>

            <asp:BoundField DataField="ReportCount" HeaderText="تعداد گزارش" />
            <asp:BoundField DataField="viewCount" HeaderText="آمار بازدید" />
            <asp:BoundField DataField="Text" HeaderText="شرح گزارش" />
            
                        <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />

        </Columns>
    </asp:GridView>

</asp:Content>

