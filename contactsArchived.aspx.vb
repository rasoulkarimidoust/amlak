
Partial Class contactsArchived
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public dr As Data.DataRow

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.GridView1.DataSource = dbl.SelectAllwhere("contacts", "Archived", "1")
        Me.GridView1.DataBind()
        General.setGridStyle(GridView1)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim No As String = GridView1.DataKeys(Me.GridView1.SelectedIndex).Value.ToString
        Me.lblCode.Text = No
        dr = dbl.SelectAllwhere("contacts", "code", No).Rows(0)
        Me.divDetail.Visible = True
        General.MyMsgBox("")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        dbl.DeleteFromTable("contacts", "code", lblCode.Text)
        Response.Redirect("contactsArchived.aspx")
    End Sub

    Protected Sub btnArchive_Click(sender As Object, e As EventArgs) Handles btnArchive.Click
        dbl.UpdateAField("contacts", "archived", "0", "code", lblCode.Text)
        Response.Redirect("contactsArchived.aspx")

    End Sub


End Class
