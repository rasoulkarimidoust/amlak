
Partial Class sendmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Write(General.SendMail("ادورت منو", "123", "karimi_doost@yahoo.com"))
    End Sub
End Class
