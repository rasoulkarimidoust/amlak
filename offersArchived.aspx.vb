
Partial Class offers
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Public dr As Data.DataRow

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Me.GridView1.DataSource = dbl.SelectAllwhere("offer", "Archived", "1")
        Me.GridView1.DataBind()
        General.setGridStyle(GridView1)
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim No As String = GridView1.DataKeys(Me.GridView1.SelectedIndex).Value.ToString
        Me.lblCode.Text = No
        dr = dbl.SelectAllwhere("offer", "offerid", No).Rows(0)
        Me.divDetail.Visible = True
        General.MyMsgBox("")
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        dbl.DeleteFromTable("offer", "offerid", lblCode.Text)
        Response.Redirect("offers.aspx")
    End Sub


    Protected Sub btnAnswer_Click(sender As Object, e As EventArgs) Handles btnAnswer.Click
        dbl.UpdateAField("offer", "archived", "0", "offerid", lblCode.Text)
        Response.Redirect("offers.aspx")


    End Sub
End Class
