<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="prjManage.aspx.vb" Inherits="prjManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <br />
    وضعیت آگهی:
    <asp:DropDownList CssClass="textbox " AutoPostBack="true"  ID="ddPrjStatus" runat="server">
        </asp:DropDownList>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="prjId" HeaderText="کد آگهی" HeaderStyle-CssClass="hideGridColumn " ItemStyle-CssClass="hideGridColumn " />
                                                            <asp:TemplateField HeaderText="عنوان آگهی" >
    <ItemTemplate>
        <%#"<a target='_blank' href='adsView.aspx?PrjId=" + Eval("prjId").ToString() + "'>" + Eval("title").ToString() + "</a>"%>

    </ItemTemplate>
</asp:TemplateField>

            <asp:BoundField DataField="JobName" HeaderText="دسته بندی" />
            <asp:BoundField DataField="PriceText" HeaderText="مبلغ" />
                                                                        <asp:TemplateField HeaderText="میانگین امتیاز" >
    <ItemTemplate>
        <%# GetRate(Eval("rate"), Eval("rateCount"))%>

    </ItemTemplate>
</asp:TemplateField>
            <asp:BoundField DataField="viewCount" HeaderText="آمار بازدید" />
            
                        <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />

        </Columns>
    </asp:GridView>

</asp:Content>

