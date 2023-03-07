
Partial Class Kmsg
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Me.txtKComment.Text = ""
        Session("Reply") = Me.GridView1.SelectedRow.Cells(0).Text
        Session("PeymankarId") = Me.GridView1.SelectedRow.Cells(1).Text
        Session("PrjId") = Me.GridView1.SelectedRow.Cells(2).Text
        Me.divExtra.Visible = True
        General.MyMsgBox("", "پاسخ کارفرما:")

    End Sub

    Protected Sub btnSaveComment_Click(sender As Object, e As EventArgs) Handles btnSaveComment.Click
        dbl.Insert("chat", "text", Me.txtKComment.Text, "KarfarmaId", Session("User").item("KarfarmaId").ToString, "name", Session("User").item("name"), "PrjId", Session("PrjId"), "reply", Session("Reply").ToString, "peymankarId", Session("PeymankarId"))
        dbl.UpdateAField("chat", "Replyed", "1", "chatId", Session("Reply"))
        Me.divExtra.Visible = False
        General.MyMsgBox("پاسخ شما ثبت شد ", "آها", 5)
        Try
            Me.GridView1.DataSource = dbl.SelectAllwhere("chatAll", "replyed", "0", "reply", "0", "karfarmaId", Session("User").item("KarfarmaId").ToString)
            Me.GridView1.DataBind()
            General.setGridStyle(GridView1)

        Catch ex As Exception
            Response.Redirect("logout.aspx")
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Me.GridView1.DataSource = dbl.SelectAllwhere("chatAll", "replyed", "0", "reply", "0", "karfarmaId", Session("User").item("KarfarmaId").ToString)
            Me.GridView1.DataBind()
            General.setGridStyle(GridView1)

        Catch ex As Exception
            Response.Redirect("logout.aspx")
        End Try

    End Sub
End Class
