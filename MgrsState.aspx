<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MgrsState.aspx.vb" Inherits="Mgrs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <br />
    <center>
        عملکرد مدیران
    </center>
    <br />
    <div class="container " style="background-color:#f5f6f4 ">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="adminid">
        <Columns>
            <asp:BoundField DataField="AdminId" HeaderText="کد" />
            <asp:BoundField DataField="Name" HeaderText="نام مدیر" />
            <asp:BoundField DataField="OkadsCount" HeaderText="تائید آگهی" />
            <asp:BoundField DataField="NOkadsCount" HeaderText="رد آگهی" />

            <asp:BoundField DataField="OKempCount" HeaderText="تائید همکاری" />
            <asp:BoundField DataField="NOKempCount" HeaderText="رد همکاری" />
            <asp:BoundField DataField="ARCempCount" HeaderText="بایگانی همکاری" />

            <asp:BoundField DataField="OkofferCount" HeaderText="تائید پیشنهاد/انتقاد" />
            <asp:BoundField DataField="NOkofferCount" HeaderText="رد پیشنهاد/انتقاد" />
            <asp:BoundField DataField="ARCofferCount" HeaderText="بایگانی پیشنهاد/انتقاد" />

            <asp:BoundField DataField="ARCcontactCount" HeaderText="پاسخ وبایگانی سوالات" />
            <asp:BoundField DataField="NOKcontactCount" HeaderText="پاسخ و حذف سوالات" />
        </Columns>

    </asp:GridView>
                <center>

        <br /> انتخاب عملیات انجام شده توسط مدیر:
        <asp:DropDownList ID="ddAction" AutoPostBack="true" class="textbox " runat="server">
            <asp:ListItem Value="All" >همه عملیات</asp:ListItem>

            <asp:ListItem Value="OkadsCount" >تائید آگهی</asp:ListItem>
            <asp:ListItem Value="NOkadsCount" >رد آگهی</asp:ListItem>

            <asp:ListItem Value="OKempCount" >تائید همکاری</asp:ListItem>
            <asp:ListItem Value="NOKempCount" >رد همکاری</asp:ListItem>
            <asp:ListItem Value="ARCempCount" >بایگانی همکاری</asp:ListItem>

            <asp:ListItem Value="OkofferCount" >تائید پیشنهاد/انتقاد</asp:ListItem>
            <asp:ListItem Value="NOkofferCount" >رد پیشنهاد/انتقاد</asp:ListItem>
            <asp:ListItem Value="ARCofferCount" >بایگانی پیشنهاد/انتقاد</asp:ListItem>

            <asp:ListItem Value="ARCcontactCount" >پاسخ وبایگانی سوالات</asp:ListItem>
            <asp:ListItem Value="NOKcontactCount" >پاسخ و حذف سوالات</asp:ListItem>

        </asp:DropDownList>
<br /><br />
        <asp:Chart ID="Chart1" Width="800px" runat="server">

            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                    <br />
            </center>
        <br />
        </div> 
</asp:Content>

