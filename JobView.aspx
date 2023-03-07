<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="JobView.aspx.vb" Inherits="JobView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="msgBoxContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="container ">
            <br />
            <center>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </center>
        <br />
    </div>
        
            <div class="container "  style="background-color:#f5f6f4;   " >
    <img alt="" width="100%" height="1px" style="display:block " src="TemplateWorld_files/lineb.png" />
                <div class="row">
                     <div class="col-xs-12 col-sm-8 col-md-8">
                         <br />
                         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                         <br /><br />
       <div id="html" runat="server" ></div>
</div> 
                                          <div class="col-xs-12 col-sm-4 col-md-4">
                                              <br />
                                              سایر شغلها:
                                              <br />
                <asp:repeater  runat="server" ID="Jobss"     >
                                            <ItemTemplate>
                                                 
                                                      <a href="JobView.aspx?code=<%# Container.DataItem("JobCode").ToString()%>">    - <%# Container.DataItem("JobName").ToString()%> (<%# Container.DataItem("prjCount").ToString()%>)</a> 
                                                <br />
                                                </ItemTemplate> 
                                                </asp:repeater> 
                                              <br />
                                          </div> 
                    </div> 
                            <img alt="" width="100%" style="display:block " height="1px" src="TemplateWorld_files/lineb.png" />

                </div> 
</asp:Content>

