<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="empsOk.aspx.vb" Inherits="offers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           <script language="javascript" type="text/javascript">
               function printDiv(divID) {
                   //Get the HTML of div
                   var divElements = document.getElementById(divID).innerHTML;
                   //Get the HTML of whole page
                   var oldPage = document.body.innerHTML;

                   //Reset the page's HTML with div's HTML only
                   document.body.innerHTML =
                     "<html><head><title></title></head><body >" +
                     divElements + "</body>";

                   //Print Page
                   window.print();

                   //Restore orignal HTML
                   document.body.innerHTML = oldPage;


               }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
    <div id="divDetail" runat="server"  visible="false" >
          <div id="printablediv" >
              <div style="direction:rtl ; text-align:right ">
        <div class="row">
                               		<div class="col-md-6 col-sm-6 col-xs-12">
                     عنوان شغلی : <%=dr.Item("jobtitle").ToString%>
                                           <br />
              نام : <%=dr.Item("fName").ToString%>
                                           <br />
               نام خانوادگی: <%=dr.Item("lName").ToString%>

                                           <asp:Label ID="lblCode" ForeColor="White"  runat="server" Text=""></asp:Label>
                                                       </div>
            		<div class="col-md-6 col-sm-6 col-xs-12">

                     <img height="100" width="75" src="UserFiles/emp<%=dr.Item("empId").ToString%>.png"/>
                        </div> 
                   		<div class="col-md-6 col-sm-6 col-xs-12">

              نام پدر : <%=dr.Item("fatherName").ToString%>
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
         تحصیلات : <%=dr.Item("tahsilat").ToString%>

                                                       </div> 
                         <div class="col-md-6 col-sm-6 col-xs-12">
                          <a target="_blank"   href="userfiles/empRes<%=dr.Item("empid").ToString%>.pdf">رزومه</a>

                                                       </div> 

         </div> 
                آدرس : <%=dr.Item("address").ToString%><br />
                توضیحات : <%=dr.Item("description").ToString%>

              </div>
        </div>

        <br />
        <asp:TextBox ID="txtRes" CssClass="textbox " Height="100px" TextMode="MultiLine"  Width="100%" runat="server"></asp:TextBox>
        <br /><br />
        <center>
                    <asp:Button  class="MyBtn"  ID="btnAnswer" runat="server" Text="پاسخ" />
        <asp:Button ID="btnArchive"  class="MyBtn"  runat="server" Text="بایگانی" />
        <asp:Button ID="btnDelete" runat="server"  class="MyBtn" Text="حذف" />
        <input class="MyBtn" type="button" value="چاپ" onclick="javascript: printDiv('printablediv')" />

           </center>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <br />
    <center>
        درخواست همکاریهای تائید شده
    </center>
    <br />
    <div class="container " style="background-color:#f5f6f4 ">
            <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />

        <br />

    <asp:GridView ID="GridView1" runat="server" DataKeyNames="empid" AutoGenerateColumns="False">
        <Columns >
            <asp:BoundField DataField="lname" HeaderText="نام خانوادگی" />
            <asp:BoundField DataField="jobtitle" HeaderText="عنوان شغلی" />
             <asp:CommandField SelectText="جزئیات" ShowSelectButton="True" />
            
            </Columns>
    </asp:GridView>
        </div> 
</asp:Content>

