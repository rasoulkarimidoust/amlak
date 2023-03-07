
Partial Class Show
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dbl As New DataBaseLayer(General.GetConnectionString)
        Me.divHtml.InnerHtml = dbl.SelectAll("txtSetting").Rows(0).Item(Request.QueryString("FN"))

    End Sub
End Class
