<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Fields.aspx.vb" Inherits="Fields" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
        <div runat="server" id="divStudent" visible="false" >
        <center>
            ترتیب: <br />
            <asp:TextBox  CssClass="textbox" ID="txtSort"  MaxLength="2"  TextMode="Number"  runat="server"></asp:TextBox><br />
            عنوان:            <br />
            <asp:TextBox  CssClass="textbox" ID="txtTitle"   runat="server"></asp:TextBox><br />
            نوع:            <br />
            <asp:DropDownList ID="ddDataType" CssClass="textbox" runat="server">
                <asp:ListItem Value="string">متن</asp:ListItem>
                <asp:ListItem Value="number">مبلغ</asp:ListItem>
                 <asp:ListItem Value="list">لیست</asp:ListItem>
                <asp:ListItem Value="bit">تیک</asp:ListItem>
            </asp:DropDownList><br />
            <label id="lbllist">لیست (تعداد آیتمها با کاما از هم جدا شود):<br /></label> 
             <asp:TextBox  CssClass="textbox" TextMode="MultiLine"  ID="txtListitem" Width="300"   runat="server"></asp:TextBox>
            <br />
            توضیحات:<br />
            <asp:TextBox  CssClass="textbox" TextMode="MultiLine"  ID="txtFieldDescription" Width="300"   runat="server"></asp:TextBox><br />
            <asp:CheckBox ID="chkIsControlic" runat="server" Text="کنترلی"></asp:CheckBox><br />
            آیکن:<br />
            <asp:FileUpload ID="FuIcon" runat="server"></asp:FileUpload>
            <br />
            <br />
        <asp:Button  CssClass="MyBtn"  ID="btnSave" runat="server" Text="اضافه" />
            </center>
           
    </div>
    <div  runat="server" id="divConfirm">
<center>
            <asp:Button  CssClass=" MyBtn "  ID="btnDel" runat="server" Text="حذف شود" />

</center>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    فیلدهای مربوط به دسته بندی : <asp:Label ID="lblJobName" runat="server" Text=""></asp:Label><asp:HiddenField ID="hfJobCode" runat="server" /><asp:HiddenField ID="hfEditId" runat="server" />
        <asp:Button  CssClass="MyBtn" ID="btnAdd" runat="server" Text="+" />

    <br />
        <br />
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="id" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="کد" />
            <asp:BoundField DataField="Sort" HeaderText="ترتیب" />
            <asp:BoundField DataField="title" HeaderText="عنوان" />
            <asp:BoundField DataField="dataType" HeaderText="نوع" />
                                                <asp:TemplateField HeaderText="تصویر" >
    <ItemTemplate>
        <%#"<img height='40px' width='40px' src='icons/f" + Eval("id").ToString() + ".png'  />"%>

    </ItemTemplate>
</asp:TemplateField>

            <asp:BoundField DataField="FieldDescription" HeaderText="توضیحات" />
            <asp:CheckBoxField DataField="isControlic" HeaderText="کنترلی" />
            <asp:CommandField DeleteText="حذف" ShowDeleteButton="True" />
            <asp:CommandField SelectText="ویرایش" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br /><br />
    <script>
document.getElementById('msgBoxContent_txtListitem').style.display = "none";
document.getElementById('lbllist').style.display = "none";
document.getElementById("msgBoxContent_ddDataType").onchange = function() {
if(this.value=="list") {
document.getElementById('msgBoxContent_txtListitem').style.display = "block";
document.getElementById('lbllist').style.display = "block";
}
   else{document.getElementById('msgBoxContent_txtListitem').style.display = "none";
document.getElementById('lbllist').style.display = "none";
}

        };
        function commafy(num) {
            num.toString().replace(/\B(?=(?:\d{3})+)$/g, ",");
        }
    </script>
</asp:Content>
