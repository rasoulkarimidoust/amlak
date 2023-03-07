
Partial Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Cookies("u").Expires = DateTime.Now
        Response.Cookies("p").Expires = DateTime.Now
        Session("user") = Nothing
        Session("UserType") = Nothing
        Session.Abandon()

        Response.Redirect("default.aspx")

    End Sub
End Class
