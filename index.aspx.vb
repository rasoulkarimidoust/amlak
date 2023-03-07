
Partial Class index
    Inherits System.Web.UI.Page
    Public dr4Ind As Data.DataRow
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Page.IsPostBack = False Then
            dr4Ind = dbl.SelectAll("txtSetting").Rows(0)

        End If
        dr4Ind = dbl.SelectAll("txtSetting").Rows(0)
        Me.txtSearch.Focus()

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Session("txtSearch") = Me.txtSearch.Text

        Response.Redirect("/default.aspx")
    End Sub

    Protected Sub btnAds_Click(sender As Object, e As EventArgs) Handles btnAds.Click
        'Request.Url.OriginalString.Substring(0, Request.Url.OriginalString.LastIndexOf("/")) +
        Response.Redirect("/default.aspx?Nardban=1")
    End Sub
End Class
