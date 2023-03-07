
Partial Class SetHelp4Controls
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim tbl As Data.DataTable = dbl.SelectAllwhere("Help4Controls", "PageName", Request.QueryString("PageName"), "ControlName", Request.QueryString("ControlName"))
        If tbl.Rows.Count > 0 Then
            If tbl.Rows(0).Item("text").ToString <> "" Then
                Me.TextBox1.Text = tbl.Rows(0).Item("text").ToString
            End If
        End If
        Me.TextBox1.Focus()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tbl As Data.DataTable = dbl.SelectAllwhere("Help4Controls", "PageName", Request.QueryString("PageName"), "ControlName", Request.QueryString("ControlName"))
        If tbl.Rows.Count > 0 Then
            dbl.UpdateAField("Help4Controls", "text", Me.TextBox1.Text, "PageName", Request.QueryString("PageName"), , "ControlName", Request.QueryString("ControlName"))
        Else
            dbl.Insert("Help4Controls", "text", Me.TextBox1.Text, "PageName", Request.QueryString("PageName"), "ControlName", Request.QueryString("ControlName"))

        End If
        General.MyMsgBox("اطلاعات مورد نظر بروز گردید.")
    End Sub
End Class
