<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="offersArchived.aspx.vb" Inherits="offers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
    <div id="divDetail" runat="server"  visible="false" >
        <div class="row">
                   		<div class="col-md-6 col-sm-6 col-xs-12">

              نام و نام خانوادگی: <%=dr.Item("Name").ToString%>
                               <asp:Label ID="lblCode" runat="server" ForeColor="White"  Text=""></asp:Label>
                        </div> 

                   		<div class="col-md-6 col-sm-6 col-xs-12">

        تلفن : <%=dr.Item("tel").ToString%>
                        </div> 
                   		<div class="col-md-6 col-sm-6 col-xs-12">

        موبایل : <%=dr.Item("mobile").ToString%>
                                                       </div> 
                   		<div class="col-md-6 col-sm-6 col-xs-12">

        ایمیل : <%=dr.Item("Email").ToString%>
                                                       </div> 
                   		<div class="col-md-6 col-sm-6 col-xs-12">

                                                       </div> 
</div> 
                توضیحات : <%=dr.Item("description").ToString%>

        <br />
        <br />
        <center>
        <asp:Button ID="btnAnswer" CssClass="MyBtn " runat="server" Width="120px" Text="برگشت از بایگانی" />&nbsp;&nbsp;<asp:Button CssClass="MyBtn " Width="120px" ID="btnDelete" runat="server" Text="حذف" />
            </center>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        پیشنهادات و انتقادات بایگانی شده
    </center>
    <br />
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />

    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Offerid" AutoGenerateColumns="False">
        <Columns >
            <asp:BoundField DataField="name" HeaderText="نام و نام خانوادگی" />
            <asp:BoundField DataField="description" HeaderText="توضیحات" />
            <asp:BoundField DataField="ArchiveType" HeaderText="نوع بایگانی" />
            <asp:CommandField SelectText="جزئیات" ShowSelectButton="True" />
            
            </Columns>
    </asp:GridView>
</asp:Content>

