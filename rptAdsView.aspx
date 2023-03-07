<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="rptAdsView.aspx.vb" Inherits="rptAdsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <center>
        <br />
        گزارش بازدید آگهی <%= GetAds()%>
        <br />
    <asp:Chart ID="Chart1" runat="server" Height="400px" Width="800px" Visible = "false">
    <Titles>
        <asp:Title ShadowOffset="3" Name="Items" />
    </Titles>
    <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
    <Series>
        <asp:Series Name="گزارش بازدید آگهی" />
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
    </ChartAreas>
</asp:Chart>
        <br /><br />
    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" Caption="پیغامهای کاربران مربوط به این آگهی" CaptionAlign="Top">
        <Columns>
            <asp:BoundField DataField="MsgId" HeaderText="شناسه" />
            <asp:BoundField DataField="Name" HeaderText="نام و نام خانوادگی" />
            <asp:BoundField DataField="Address" HeaderText="آدرس" />
            <asp:BoundField DataField="Email" HeaderText="ایمیل" />
            <asp:BoundField DataField="tel" HeaderText="تلفن" />
            <asp:BoundField DataField="IP" HeaderText="ip" />
            <asp:BoundField DataField="text" HeaderText="متن پیغام" />
        </Columns>
            </asp:GridView>
        </center>
</asp:Content>

