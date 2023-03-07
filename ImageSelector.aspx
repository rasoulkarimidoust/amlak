<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ImageSelector.aspx.vb" Inherits="ImageSelector" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick(fileUrl) {
            var funcNum = 1;
            window.opener.CKEDITOR.tools.callFunction(funcNum, fileUrl);
            window.close();
        }

// ]]>
    </script>
    <style>
        img{
                 box-shadow: rgba(0,0,0,0.8) 0 0 10px;
        }
               img:hover {-webkit-filter: contrast(180%);filter: contrast(180%);}

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" />
    <br />
    <asp:Repeater ID="RepeaterImages" runat="server">
    <ItemTemplate>
    <a onclick="return Button1_onclick('<%# Container.DataItem %>')" >
        <asp:Image Height="100px" Width="100px" ID="Image" runat="server" Title='<%# Container.DataItem.ToString.Substring(Container.DataItem.ToString.LastIndexOf("/")+1, Container.DataItem.ToString.LastIndexOf(".")-Container.DataItem.ToString.LastIndexOf("/")+3)%>' AlternateText='<%# Container.DataItem.ToString.Substring(Container.DataItem.ToString.LastIndexOf("/")+1, Container.DataItem.ToString.LastIndexOf(".")-Container.DataItem.ToString.LastIndexOf("/")+3)%>' ImageUrl='<%# Container.DataItem %>' />
    </a>
        </ItemTemplate>

</asp:Repeater>
    </form>
</body>
</html>
