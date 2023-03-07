
Partial Class jobEdit
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

            Me.ddJobs.DataSource = dbl.SelectAll("Job")
            Me.ddJobs.DataTextField = "JobName"
            Me.ddJobs.DataValueField = "JOBCODE"
            Me.ddJobs.DataBind()

            With dbl.SelectAllwhere("job", "JOBCODE", Request.QueryString("jobCode").ToString).Rows(0)
                Me.txtName.Text = .Item("jobName")
                Me.CKEditor1.Text = .Item("html").ToString
                Me.ddJobs.SelectedValue = .Item("RootCode")
            End With


        End If
    End Sub

    Protected Sub btnUpdate_Click(sender As Object, e As ImageClickEventArgs) Handles btnUpdate.Click
        dbl.Update("job", "jobname", txtName.Text, "rootName", Me.ddJobs.SelectedItem.Text, "rootCode", Me.ddJobs.SelectedValue.ToString, "html", Me.CKEditor1.Text, , , , , , , , , , , , , "jobcode", Request.QueryString("jobcode").ToString)
        General.MyMsgBox("اطلاعات ذخیره شد")
    End Sub
End Class
