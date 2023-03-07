
Partial Class setting
    Inherits System.Web.UI.Page
    Dim dbl As New DataBaseLayer(General.GetConnectionString)
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.CKEditor1.ContentsLangDirection = CKEditor.NET.contentsLangDirections.Rtl
            Me.CKEditor1.ContentsLanguage = "fa-IR"
            CKEditor1.Language = "fa-IR"
            CKEditor1.ToolbarCanCollapse = True
            Me.CKEditor1.config.toolbar = New Object() {New Object() {"Source", "Undo", "Redo", "Cut", "Copy", "Maximize", "Image", "Font", "FontSize", "Bold", "Italic", "Underline", "TextColor", "BGColor", "Link", "Unlink", "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock"}}
            Me.CKEditor1.FilebrowserImageBrowseUrl = "ImageSelector.aspx"
        End If
    End Sub
 

    Protected Sub ddSet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddSet.SelectedIndexChanged
        Dim dr As Data.DataRow
        dr = dbl.SelectAll("txtSetting").Rows(0)
        Me.TextBox1.Visible = False
        Me.CKEditor1.Visible = False
        Me.FileUpload1.Visible = False
        Me.divAuto.Visible = False
        Select Case ddSet.SelectedValue.Substring(0, 4)
            Case "text"
                Me.TextBox1.Visible = True
                Me.TextBox1.Text = dr.Item(ddSet.SelectedValue.Substring(4)).ToString
            Case "html"
                Me.CKEditor1.Visible = True
                Me.CKEditor1.Text = dr.Item(ddSet.SelectedValue.Substring(4)).ToString
            Case "file"
                Me.FileUpload1.Visible = True
            Case "auto"
                Me.lblDateTime.Text = dr.Item(ddSet.SelectedValue.Substring(4)).ToString
                If lblDateTime.Text <> "" Then
                    Me.lblDateTime.Text = "تاریخ اتمام تائید اتوماتیک : " + Me.lblDateTime.Text
                End If
                Me.divAuto.Visible = True
        End Select
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Select Case ddSet.SelectedValue.Substring(0, 4)
                Case "text"
                    dbl.UpdateAField("txtsetting", Me.ddSet.SelectedValue.Substring(4), Me.TextBox1.Text, "id", "1")
                Case "html"
                    Dim html As String = Me.CKEditor1.Text
                    dbl.UpdateAField("txtsetting", Me.ddSet.SelectedValue.Substring(4), html, "id", "1")
                Case "file"
                    Me.FileUpload1.SaveAs(Server.MapPath("~/") + Me.ddSet.SelectedValue.Substring(4) + ".png")
                Case "auto"
                    Dim AdsAutoCheckDate As DateTime = Now.AddDays(-1)
                    If chkDate.Checked Then
                        AdsAutoCheckDate = Now.AddDays(Convert.ToDouble(Me.txtDay.Text)).AddHours(Convert.ToDouble(Me.txtHour.Text))
                    End If
                    dbl.UpdateAField("txtsetting", Me.ddSet.SelectedValue.Substring(4), AdsAutoCheckDate, "id", "1")
            End Select
            General.MyMsgBox("بروز رسانی با موفقیت انجام شد")
        Catch ex As Exception
            General.MyMsgBox("خطا در انجام عملیات")
        End Try

    End Sub
End Class
