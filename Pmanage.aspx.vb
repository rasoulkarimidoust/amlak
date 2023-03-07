
Partial Class Pmanage
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.GridView1.DataSource = dbl.SelectAllwhere("Peymankar", "AcceptByAdmin", "0")
        Me.GridView1.DataBind()
        General.setGridStyle(Me.GridView1)
        Me.divConfirm.Visible = False
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Me.lblPeymankar.Text = Me.GridView1.Rows(e.RowIndex).Cells(0).Text
        Me.divConfirm.Visible = True
        General.MyMsgBox("")

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        dbl.UpdateAField("Peymankar", "AcceptByAdmin", "1", "peymankarid", Me.GridView1.SelectedRow.Cells(0).Text)
        Me.GridView1.DataSource = dbl.SelectAllwhere("Peymankar", "AcceptByAdmin", "0")
        Me.GridView1.DataBind()
        General.setGridStyle(Me.GridView1)
        Me.divConfirm.Visible = False
        General.MyMsgBox("اطلاعات پیمانکار تائید شد")

    End Sub


    Protected Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click

        dbl.UpdateAField("Peymankar", "AcceptByAdmin", "2", "peymankarid", Me.lblPeymankar.Text)
        Me.GridView1.DataSource = dbl.SelectAllwhere("Peymankar", "AcceptByAdmin", "0")
        Me.GridView1.DataBind()
        General.setGridStyle(Me.GridView1)
        Me.divConfirm.Visible = False
        General.MyMsgBox("پیمانکار حذف شد")

    End Sub
End Class
