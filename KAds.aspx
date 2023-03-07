<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="KAds.aspx.vb" Inherits="KAds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        function showDiv() {
            var elem = document.getElementById("<%=ddDel.ClientID%>")
            if (elem.value == 3)
                document.getElementById('hidden_div').style.display = "block";
            else
                document.getElementById('hidden_div').style.display = "none";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
        <div  runat="server" id="divConfirm">
<center>
    علت حذف:<asp:DropDownList ID="ddDel"  onchange="showDiv()" runat="server">
        <asp:ListItem Text="موفقیت در فروش" Value="0"></asp:ListItem>
        <asp:ListItem Text="عدم موفقیت در فروش" Value="1"></asp:ListItem>
        <asp:ListItem Text="انصراف از فروش" Value="2"></asp:ListItem>
        <asp:ListItem Text="علل دیگر" Value="3"></asp:ListItem>
        </asp:DropDownList>
    <div id="hidden_div" style="display:none;  width:100%" >
       <br />
        علت:
        <asp:TextBox ID="txtDel" Width="80%"  CssClass="textbox " runat="server"></asp:TextBox>
        </div>
    <br /><br />
            <asp:Button  CssClass="textbox" BackColor="#1559af" ForeColor="White" ID="btnDel" runat="server" Text="حذف شود" />

</center>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                   <br />
    <center>
        آگهی های من
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
    <br />
    <center>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="prjid">
        <Columns>
            <asp:BoundField DataField="PRJID" HeaderText="کد" />
                                    <asp:TemplateField HeaderText="عنوان" >
    <ItemTemplate>
        <%#"<a href='adsView.aspx?prjId=" + Eval("PRJID").ToString() + "'>" + Eval("title").ToString() + "</a>"%>

    </ItemTemplate>
</asp:TemplateField>
            <asp:BoundField DataField="adsType" HeaderText="نوع آگهی" />
            <asp:BoundField DataField="Price" HeaderText="مبلغ" />
            <asp:BoundField DataField="ViewCount" HeaderText="بازدید" />
            <asp:BoundField DataField="Rate" HeaderText="میانگین امتیاز" />
            <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
        </center>
</asp:Content>

